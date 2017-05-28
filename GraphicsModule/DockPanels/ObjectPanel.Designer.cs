namespace GraphicsModule.DockPanels
{
    partial class ObjectPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectPanel));
            this.ObjectsBuildMenu = new System.Windows.Forms.ToolStrip();
            this.buttonPointsMenu = new System.Windows.Forms.ToolStripButton();
            this.buttonLinesMenu = new System.Windows.Forms.ToolStripButton();
            this.buttonSegmentMenu = new System.Windows.Forms.ToolStripButton();
            this.buttonPlanesMenu = new System.Windows.Forms.ToolStripButton();
            this.ObjectsBuildMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ObjectsBuildMenu
            // 
            this.ObjectsBuildMenu.BackColor = System.Drawing.SystemColors.Control;
            this.ObjectsBuildMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.ObjectsBuildMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ObjectsBuildMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ObjectsBuildMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonPointsMenu,
            this.buttonLinesMenu,
            this.buttonSegmentMenu,
            this.buttonPlanesMenu});
            this.ObjectsBuildMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.ObjectsBuildMenu.Location = new System.Drawing.Point(0, 0);
            this.ObjectsBuildMenu.Name = "ObjectsBuildMenu";
            this.ObjectsBuildMenu.Size = new System.Drawing.Size(37, 407);
            this.ObjectsBuildMenu.TabIndex = 5;
            // 
            // buttonPointsMenu
            // 
            this.buttonPointsMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPointsMenu.Image = ((System.Drawing.Image)(resources.GetObject("buttonPointsMenu.Image")));
            this.buttonPointsMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPointsMenu.Name = "buttonPointsMenu";
            this.buttonPointsMenu.Size = new System.Drawing.Size(34, 36);
            this.buttonPointsMenu.Text = "Точка";
            // 
            // buttonLinesMenu
            // 
            this.buttonLinesMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonLinesMenu.Image = global::GraphicsModule.Properties.Resources.line;
            this.buttonLinesMenu.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonLinesMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonLinesMenu.Name = "buttonLinesMenu";
            this.buttonLinesMenu.Size = new System.Drawing.Size(34, 36);
            this.buttonLinesMenu.Text = "Прямая";
            // 
            // buttonSegmentMenu
            // 
            this.buttonSegmentMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSegmentMenu.Image = ((System.Drawing.Image)(resources.GetObject("buttonSegmentMenu.Image")));
            this.buttonSegmentMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSegmentMenu.Name = "buttonSegmentMenu";
            this.buttonSegmentMenu.Size = new System.Drawing.Size(34, 36);
            this.buttonSegmentMenu.Text = "Отрезок";
            // 
            // buttonPlanesMenu
            // 
            this.buttonPlanesMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPlanesMenu.Image = ((System.Drawing.Image)(resources.GetObject("buttonPlanesMenu.Image")));
            this.buttonPlanesMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPlanesMenu.Name = "buttonPlanesMenu";
            this.buttonPlanesMenu.Size = new System.Drawing.Size(34, 36);
            this.buttonPlanesMenu.Text = "toolStripButton1";
            this.buttonPlanesMenu.ToolTipText = "Плоскость";
            // 
            // ObjectPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 407);
            this.CloseButton = false;
            this.Controls.Add(this.ObjectsBuildMenu);
            this.HideOnClose = true;
            this.Name = "ObjectPanel";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "\\";
            this.ObjectsBuildMenu.ResumeLayout(false);
            this.ObjectsBuildMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ObjectsBuildMenu;
        private System.Windows.Forms.ToolStripButton buttonPointsMenu;
        private System.Windows.Forms.ToolStripButton buttonLinesMenu;
        private System.Windows.Forms.ToolStripButton buttonSegmentMenu;
        private System.Windows.Forms.ToolStripButton buttonPlanesMenu;
    }
}