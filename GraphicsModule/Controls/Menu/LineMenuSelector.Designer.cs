namespace GraphicsModule.Controls.Menu
{
    partial class LineMenuSelector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineMenuSelector));
            this.mainStrip = new System.Windows.Forms.ToolStrip();
            this.buttonLine2D = new System.Windows.Forms.ToolStripButton();
            this.buttonLineOfPlane1X0Y = new System.Windows.Forms.ToolStripButton();
            this.buttonLineOfPlane2X0Z = new System.Windows.Forms.ToolStripButton();
            this.buttonLineOfPlane3Y0Z = new System.Windows.Forms.ToolStripButton();
            this.buttonLine3D = new System.Windows.Forms.ToolStripButton();
            this.buttonGenerateLine3D = new System.Windows.Forms.ToolStripButton();
            this.mainStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainStrip
            // 
            this.mainStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonLine2D,
            this.buttonLineOfPlane1X0Y,
            this.buttonLineOfPlane2X0Z,
            this.buttonLineOfPlane3Y0Z,
            this.buttonLine3D,
            this.buttonGenerateLine3D});
            this.mainStrip.Location = new System.Drawing.Point(0, 0);
            this.mainStrip.Name = "mainStrip";
            this.mainStrip.Size = new System.Drawing.Size(157, 38);
            this.mainStrip.TabIndex = 1;
            this.mainStrip.Text = "toolStrip2";
            this.mainStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mainStrip_ItemClicked);
            // 
            // buttonLine2D
            // 
            this.buttonLine2D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonLine2D.Image = global::GraphicsModule.Properties.Resources.line;
            this.buttonLine2D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonLine2D.Name = "buttonLine2D";
            this.buttonLine2D.Size = new System.Drawing.Size(23, 35);
            this.buttonLine2D.Text = "Линия";
            this.buttonLine2D.Click += new System.EventHandler(this.buttonLine2D_Click);
            // 
            // buttonLineOfPlane1X0Y
            // 
            this.buttonLineOfPlane1X0Y.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonLineOfPlane1X0Y.Image = global::GraphicsModule.Properties.Resources.lineX0Y;
            this.buttonLineOfPlane1X0Y.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonLineOfPlane1X0Y.Name = "buttonLineOfPlane1X0Y";
            this.buttonLineOfPlane1X0Y.Size = new System.Drawing.Size(23, 35);
            this.buttonLineOfPlane1X0Y.Text = "Проекция линии на плоскость X0Y";
            this.buttonLineOfPlane1X0Y.Click += new System.EventHandler(this.buttonLineOfPlane1X0Y_Click);
            // 
            // buttonLineOfPlane2X0Z
            // 
            this.buttonLineOfPlane2X0Z.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonLineOfPlane2X0Z.Image = global::GraphicsModule.Properties.Resources.lineX0Z;
            this.buttonLineOfPlane2X0Z.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonLineOfPlane2X0Z.Name = "buttonLineOfPlane2X0Z";
            this.buttonLineOfPlane2X0Z.Size = new System.Drawing.Size(23, 35);
            this.buttonLineOfPlane2X0Z.Text = "Проекция линии на плоскость X0Z";
            this.buttonLineOfPlane2X0Z.Click += new System.EventHandler(this.buttonLineOfPlane2X0Z_Click);
            // 
            // buttonLineOfPlane3Y0Z
            // 
            this.buttonLineOfPlane3Y0Z.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonLineOfPlane3Y0Z.Image = global::GraphicsModule.Properties.Resources.lineY0Z;
            this.buttonLineOfPlane3Y0Z.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonLineOfPlane3Y0Z.Name = "buttonLineOfPlane3Y0Z";
            this.buttonLineOfPlane3Y0Z.Size = new System.Drawing.Size(23, 35);
            this.buttonLineOfPlane3Y0Z.Text = "Проекция линии на плоскость Y0Z";
            this.buttonLineOfPlane3Y0Z.Click += new System.EventHandler(this.buttonLineOfPlane3Y0Z_Click);
            // 
            // buttonLine3D
            // 
            this.buttonLine3D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonLine3D.Image = global::GraphicsModule.Properties.Resources.line3D;
            this.buttonLine3D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonLine3D.Name = "buttonLine3D";
            this.buttonLine3D.Size = new System.Drawing.Size(23, 35);
            this.buttonLine3D.Text = "toolStripButton5";
            this.buttonLine3D.Click += new System.EventHandler(this.buttonLine3D_Click);
            // 
            // buttonGenerateLine3D
            // 
            this.buttonGenerateLine3D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonGenerateLine3D.Image = ((System.Drawing.Image)(resources.GetObject("buttonGenerateLine3D.Image")));
            this.buttonGenerateLine3D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonGenerateLine3D.Name = "buttonGenerateLine3D";
            this.buttonGenerateLine3D.Size = new System.Drawing.Size(23, 35);
            this.buttonGenerateLine3D.Text = "toolStripButton6";
            this.buttonGenerateLine3D.Click += new System.EventHandler(this.buttonGenerateLine3D_Click);
            // 
            // LineMenuSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainStrip);
            this.Name = "LineMenuSelector";
            this.Size = new System.Drawing.Size(157, 38);
            this.mainStrip.ResumeLayout(false);
            this.mainStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainStrip;
        private System.Windows.Forms.ToolStripButton buttonLine2D;
        private System.Windows.Forms.ToolStripButton buttonLineOfPlane1X0Y;
        private System.Windows.Forms.ToolStripButton buttonLineOfPlane2X0Z;
        private System.Windows.Forms.ToolStripButton buttonLineOfPlane3Y0Z;
        private System.Windows.Forms.ToolStripButton buttonLine3D;
        private System.Windows.Forms.ToolStripButton buttonGenerateLine3D;
    }
}
