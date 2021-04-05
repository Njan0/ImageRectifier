using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImageRectifier
{
    public class DrawBox : UserControl
    {
        private Image _backgroundImage;
        public new Image BackgroundImage
        {
            get
            {
                return _backgroundImage;
            }
            set
            {
                _backgroundImage = value;
                this.Invalidate();
            }
        }

        private readonly List<DrawBoxObject> drawObjects;

        private Size lastSize;

        public DrawBox()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | 
                          ControlStyles.UserPaint |
                          ControlStyles.DoubleBuffer,
                          true);
            drawObjects = new List<DrawBoxObject>();

            this.SizeChanged += new EventHandler(this.OnSizeChanged);
            this.Load += new EventHandler(this.OnLoad);
        }
        public void OnLoad(object obj, EventArgs e)
        {
            lastSize = this.Size;
        }

        public void AddObject(DrawBoxObject obj)
        {
            drawObjects.Add(obj);
            obj.RegisterObject(this);
            this.Invalidate();
        }
        

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            if (this.BackgroundImage != null)
                e.Graphics.DrawImage(this.BackgroundImage, new Rectangle(0, 0, this.Width, this.Height));

            foreach (DrawBoxObject obj in drawObjects)
                obj.Draw(e);
        }
        private void OnSizeChanged(object sender, EventArgs e)
        {
            float widthScale = (float)this.Width / lastSize.Width;
            float heightScale = (float)this.Height / lastSize.Height;

            foreach (DrawBoxObject obj in drawObjects)
                obj.Scale(widthScale, heightScale);

            lastSize = this.Size;
        }
    }
}
