namespace ImageRectifier
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PictureBoxRectified = new System.Windows.Forms.PictureBox();
            this.ContextMenuRectified = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.LabelHeight = new System.Windows.Forms.Label();
            this.LabelWidth = new System.Windows.Forms.Label();
            this.NumericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.ButtonCalc = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ProgressBarCalc = new System.Windows.Forms.ProgressBar();
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.ContextMenuOriginal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemParse = new System.Windows.Forms.ToolStripMenuItem();
            this.DrawBoxOriginal = new ImageRectifier.DrawBox();
            this.TableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxRectified)).BeginInit();
            this.ContextMenuRectified.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownWidth)).BeginInit();
            this.ContextMenuOriginal.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel.ColumnCount = 3;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel.Controls.Add(this.PictureBoxRectified, 2, 0);
            this.TableLayoutPanel.Controls.Add(this.DrawBoxOriginal, 0, 0);
            this.TableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 1;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(774, 447);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // PictureBoxRectified
            // 
            this.PictureBoxRectified.ContextMenuStrip = this.ContextMenuRectified;
            this.PictureBoxRectified.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxRectified.Location = new System.Drawing.Point(400, 3);
            this.PictureBoxRectified.Name = "PictureBoxRectified";
            this.PictureBoxRectified.Size = new System.Drawing.Size(371, 441);
            this.PictureBoxRectified.TabIndex = 1;
            this.PictureBoxRectified.TabStop = false;
            // 
            // ContextMenuRectified
            // 
            this.ContextMenuRectified.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemCopy});
            this.ContextMenuRectified.Name = "ContextMenuRectified";
            this.ContextMenuRectified.Size = new System.Drawing.Size(103, 26);
            // 
            // MenuItemCopy
            // 
            this.MenuItemCopy.Name = "MenuItemCopy";
            this.MenuItemCopy.Size = new System.Drawing.Size(102, 22);
            this.MenuItemCopy.Text = "Copy";
            this.MenuItemCopy.Click += new System.EventHandler(this.MenuItemCopy_Click);
            // 
            // LabelHeight
            // 
            this.LabelHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelHeight.AutoSize = true;
            this.LabelHeight.Location = new System.Drawing.Point(600, 507);
            this.LabelHeight.Name = "LabelHeight";
            this.LabelHeight.Size = new System.Drawing.Size(41, 13);
            this.LabelHeight.TabIndex = 3;
            this.LabelHeight.Text = "Height:";
            // 
            // LabelWidth
            // 
            this.LabelWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelWidth.AutoSize = true;
            this.LabelWidth.Location = new System.Drawing.Point(603, 481);
            this.LabelWidth.Name = "LabelWidth";
            this.LabelWidth.Size = new System.Drawing.Size(38, 13);
            this.LabelWidth.TabIndex = 2;
            this.LabelWidth.Text = "Width:";
            // 
            // NumericUpDownHeight
            // 
            this.NumericUpDownHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NumericUpDownHeight.Increment = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.NumericUpDownHeight.Location = new System.Drawing.Point(647, 505);
            this.NumericUpDownHeight.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.NumericUpDownHeight.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.NumericUpDownHeight.Name = "NumericUpDownHeight";
            this.NumericUpDownHeight.Size = new System.Drawing.Size(55, 20);
            this.NumericUpDownHeight.TabIndex = 5;
            this.NumericUpDownHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumericUpDownHeight.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // NumericUpDownWidth
            // 
            this.NumericUpDownWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NumericUpDownWidth.Increment = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.NumericUpDownWidth.Location = new System.Drawing.Point(647, 479);
            this.NumericUpDownWidth.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.NumericUpDownWidth.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.NumericUpDownWidth.Name = "NumericUpDownWidth";
            this.NumericUpDownWidth.Size = new System.Drawing.Size(55, 20);
            this.NumericUpDownWidth.TabIndex = 4;
            this.NumericUpDownWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumericUpDownWidth.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // ButtonCalc
            // 
            this.ButtonCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCalc.Enabled = false;
            this.ButtonCalc.Location = new System.Drawing.Point(708, 476);
            this.ButtonCalc.Name = "ButtonCalc";
            this.ButtonCalc.Size = new System.Drawing.Size(75, 23);
            this.ButtonCalc.TabIndex = 6;
            this.ButtonCalc.Text = "Calcualte";
            this.ButtonCalc.UseVisualStyleBackColor = true;
            this.ButtonCalc.Click += new System.EventHandler(this.ButtonCalc_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSave.Enabled = false;
            this.ButtonSave.Location = new System.Drawing.Point(708, 502);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 7;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ProgressBarCalc
            // 
            this.ProgressBarCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBarCalc.Location = new System.Drawing.Point(708, 476);
            this.ProgressBarCalc.Name = "ProgressBarCalc";
            this.ProgressBarCalc.Size = new System.Drawing.Size(75, 23);
            this.ProgressBarCalc.TabIndex = 8;
            this.ProgressBarCalc.Visible = false;
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonOpen.Location = new System.Drawing.Point(12, 501);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(75, 23);
            this.ButtonOpen.TabIndex = 9;
            this.ButtonOpen.Text = "Open";
            this.ButtonOpen.UseVisualStyleBackColor = true;
            this.ButtonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // ContextMenuOriginal
            // 
            this.ContextMenuOriginal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemParse});
            this.ContextMenuOriginal.Name = "ContextMenuOriginal";
            this.ContextMenuOriginal.Size = new System.Drawing.Size(103, 26);
            // 
            // MenuItemParse
            // 
            this.MenuItemParse.Name = "MenuItemParse";
            this.MenuItemParse.Size = new System.Drawing.Size(102, 22);
            this.MenuItemParse.Text = "Parse";
            this.MenuItemParse.Click += new System.EventHandler(this.MenuItemParse_Click);
            // 
            // DrawBoxOriginal
            // 
            this.DrawBoxOriginal.ContextMenuStrip = this.ContextMenuOriginal;
            this.DrawBoxOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawBoxOriginal.Location = new System.Drawing.Point(3, 3);
            this.DrawBoxOriginal.Name = "DrawBoxOriginal";
            this.DrawBoxOriginal.Size = new System.Drawing.Size(371, 441);
            this.DrawBoxOriginal.TabIndex = 2;
            this.DrawBoxOriginal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DrawBoxOriginal_KeyDown);
            this.DrawBoxOriginal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawBoxOriginal_MouseDown);
            this.DrawBoxOriginal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawBoxOriginal_MouseMove);
            this.DrawBoxOriginal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawBoxOriginal_MouseUp);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 536);
            this.Controls.Add(this.ButtonOpen);
            this.Controls.Add(this.ProgressBarCalc);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonCalc);
            this.Controls.Add(this.NumericUpDownWidth);
            this.Controls.Add(this.NumericUpDownHeight);
            this.Controls.Add(this.LabelWidth);
            this.Controls.Add(this.LabelHeight);
            this.Controls.Add(this.TableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(256, 256);
            this.Name = "FormMain";
            this.Text = "Image Rectifier";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.TableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxRectified)).EndInit();
            this.ContextMenuRectified.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownWidth)).EndInit();
            this.ContextMenuOriginal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        private System.Windows.Forms.PictureBox PictureBoxRectified;
        private DrawBox DrawBoxOriginal;
        private System.Windows.Forms.Label LabelHeight;
        private System.Windows.Forms.Label LabelWidth;
        private System.Windows.Forms.NumericUpDown NumericUpDownHeight;
        private System.Windows.Forms.NumericUpDown NumericUpDownWidth;
        private System.Windows.Forms.Button ButtonCalc;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.ProgressBar ProgressBarCalc;
        private System.Windows.Forms.Button ButtonOpen;
        private System.Windows.Forms.ContextMenuStrip ContextMenuRectified;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCopy;
        private System.Windows.Forms.ContextMenuStrip ContextMenuOriginal;
        private System.Windows.Forms.ToolStripMenuItem MenuItemParse;
    }
}

