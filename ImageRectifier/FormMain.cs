using MathTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageRectifier
{
    public partial class FormMain : Form
    {
        private const int dragDistanceSquared = 100; // maximum distance to successfully grab a vertex
        private int markMouseOver; // vertex which is currently mouseovered
        private readonly Polygon markedArea; // area marked to rectify
        private bool grabed; // true if vertex is currently grabbed

        private Point lastPosition; // last mouse position

        private const String fileFilter = "BMP (*.bmp)|*.bmp|PNG (*.png)|*.png|All files (*.*)|*.*";

        public FormMain()
        {
            InitializeComponent();

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            PictureBoxRectified.SizeMode = PictureBoxSizeMode.Zoom;
            
            markMouseOver = -1;
            markedArea = new Polygon(new Pen(Color.Red,2),
                                     new SolidBrush(Color.FromArgb(128, 0, 255, 255)),
                                     5,
                                     new PointF(0, 0), 
                                     new PointF(DrawBoxOriginal.Width - 1, 0), 
                                     new PointF(DrawBoxOriginal.Width - 1, DrawBoxOriginal.Height - 1), 
                                     new PointF(0, DrawBoxOriginal.Height - 1));

            DrawBoxOriginal.AddObject(markedArea);
        }

        private void DrawBoxOriginal_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                if (e.KeyCode == Keys.V)
                {
                    ParseClipboard();
                }
            }
        }
        private void MenuItemParse_Click(object sender, EventArgs e)
        {
            ParseClipboard();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            Parse(e.Data);
        }

        private void ParseClipboard()
        {
            if (Clipboard.ContainsImage())
            {
                Parse(Clipboard.GetImage());
            }
            else
            {
                Parse(Clipboard.GetDataObject());
            }
        }

        private void Parse(Image data)
        {
            DrawBoxOriginal.BackgroundImage = data;
            ButtonCalc.Enabled = DrawBoxOriginal.BackgroundImage != null;
        }

        private void Parse(IDataObject data)
        {
            if (data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])data.GetData(DataFormats.FileDrop);
                DrawBoxOriginal.BackgroundImage = Image.FromFile(files[0]);
            }
            else if (data.GetDataPresent(DataFormats.Html))
            {
                string htmlCode = (string)data.GetData(DataFormats.Html);
                Console.WriteLine("Parsed:\n" + htmlCode);

                //Pattern: <img src="Link"/>
                Regex rgx = new Regex("<img\\s*src=\"(?<Link>[^\"]*)\"/>");
                Match match = rgx.Match(htmlCode);
                Console.WriteLine("Found: " + match.Groups["Link"]);

                try
                {
                    // Get image from link
                    using (WebClient webClient = new WebClient())
                    {
                        using (Stream stream = webClient.OpenRead(match.Groups["Link"].Value))
                        {
                            DrawBoxOriginal.BackgroundImage = new Bitmap(stream);
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString(), "Failed to load image! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            ButtonCalc.Enabled = DrawBoxOriginal.BackgroundImage != null;
        }

        private void Redraw()
        {
            // No image loaded
            if (DrawBoxOriginal.BackgroundImage == null)
                return;

            // Empty image
            if (DrawBoxOriginal.BackgroundImage.Width == 0 || DrawBoxOriginal.BackgroundImage.Height == 0)
                return;

            // Still processing
            if (ProgressBarCalc.Visible)
                return;

            // Check if vertices overlap
            for (int i = 0; i < 4; ++i)
            {
                for (int j = i + 1; j < 4; ++j)
                {
                    if (markedArea.vertices[i] == markedArea.vertices[j])
                    {
                        MessageBox.Show("Vertices must not overlap!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            ButtonSave.Enabled = false;
            ButtonCalc.Visible = false;
            ProgressBarCalc.Visible = true;
            
            // Worker to calculate the rectified image
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;

            int width = (int)NumericUpDownWidth.Value;
            int height = (int)NumericUpDownHeight.Value;
            bw.DoWork += (sender, e) => RedrawFunction(sender as BackgroundWorker, new Bitmap(DrawBoxOriginal.BackgroundImage), width, height, markedArea);

            bw.ProgressChanged += (sender, e) =>
            {
                ProgressBarCalc.Value = e.ProgressPercentage;
            };
            bw.RunWorkerCompleted += (sender, e) =>
            {
                ButtonSave.Enabled = true;
                ButtonCalc.Visible = true;
                ProgressBarCalc.Visible = false;
                ProgressBarCalc.Value = 0;
            };

            bw.RunWorkerAsync();
        }
        private void RedrawFunction(BackgroundWorker worker, Bitmap original, int width, int height, Polygon markedArea)
        {
            float xScale = (float)original.Width / DrawBoxOriginal.Width;
            float yScale = (float)original.Height / DrawBoxOriginal.Height;

            IList<PointF> vertices = markedArea.vertices;
            Vector3 v1 = new Vector3(vertices[0].X * xScale, vertices[0].Y * yScale, 1);
            Vector3 v2 = new Vector3(vertices[1].X * xScale, vertices[1].Y * yScale, 1);
            Vector3 v3 = new Vector3(vertices[2].X * xScale, vertices[2].Y * yScale, 1);
            Vector3 v4 = new Vector3(vertices[3].X * xScale, vertices[3].Y * yScale, 1);

            Matrix3 m = MT.GetPerspectiveMatrix(width, height, new Vector3[] { v1, v2, v3, v4 });

            Bitmap rectified = new Bitmap(width, height);

            // generate rectified image by applying the matrix to each pixel
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Vector3 projectionPosition = m * new Vector3(x, y, 1);
                    float originalX = projectionPosition.x / projectionPosition.z;
                    float originalY = projectionPosition.y / projectionPosition.z;

                    rectified.SetPixel(x, y, MT.BilinearInterpolation(original, originalX, originalY));
                }
                worker.ReportProgress(100 * y / height);
            }

            PictureBoxRectified.Image = rectified;
        }

        private void DrawBoxOriginal_MouseMove(object sender, MouseEventArgs e)
        {
            if (!grabed)
            {
                // get closest vertex
                int nearest = 0;
                float nearestDistanceSq = MT.LengthSquared(markedArea.vertices[nearest], e.Location);
                for (int i = 1; i < 4; i++)
                {
                    float testDistanceSq = MT.LengthSquared(markedArea.vertices[i], e.Location);
                    if (testDistanceSq < nearestDistanceSq)
                    {
                        nearest = i;
                        nearestDistanceSq = testDistanceSq;
                    }
                }

                // grab if close enough
                if (nearestDistanceSq < dragDistanceSquared)
                {
                    Cursor.Current = Cursors.Hand;
                    markMouseOver = nearest;
                }
                else
                {
                    markMouseOver = -1;
                }
            }
            else
            {
                // move grabed vertex
                PointF shift = MT.SubtractPoint(e.Location, lastPosition);
                markedArea.ShiftVertexClamp(markMouseOver, shift, new RectangleF(PointF.Empty, new Size(DrawBoxOriginal.Width - 1, DrawBoxOriginal.Height - 1)));
            }

            lastPosition = e.Location;
        }
        private void DrawBoxOriginal_MouseDown(object sender, MouseEventArgs e)
        {
            if (markMouseOver != -1)
            {
                Cursor.Current = Cursors.Hand;
                grabed = true;
            }
        }
        private void DrawBoxOriginal_MouseUp(object sender, MouseEventArgs e)
        {
            grabed = false;
        }

        private void ButtonCalc_Click(object sender, EventArgs e)
        {
            Redraw();
        }

        private void MenuItemCopy_Click(object sender, EventArgs e)
        {
            if (PictureBoxRectified.Image != null)
                Clipboard.SetImage(PictureBoxRectified.Image);
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = fileFilter,
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DrawBoxOriginal.BackgroundImage = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = fileFilter,
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (PictureBoxRectified.Image != null)
                    {
                        PictureBoxRectified.Image.Save(saveFileDialog.FileName);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString(), "Image could not be saved! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
