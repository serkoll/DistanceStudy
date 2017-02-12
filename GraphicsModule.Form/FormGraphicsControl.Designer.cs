using GraphicsModule.Controls;

namespace GraphicsModule.Form
{
    partial class FormGraphicsControl
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
            this.graphicsControl1 = new GraphicsModule.Controls.GraphicsControl();
            this.SuspendLayout();
            // 
            // graphicsControl1
            // 
            this.graphicsControl1.AutoSize = true;
            this.graphicsControl1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.graphicsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicsControl1.Location = new System.Drawing.Point(0, 0);
            this.graphicsControl1.Name = "graphicsControl1";
            this.graphicsControl1.Size = new System.Drawing.Size(1182, 613);
            this.graphicsControl1.TabIndex = 0;
            // 
            // FormGraphicsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 613);
            this.Controls.Add(this.graphicsControl1);
            this.KeyPreview = true;
            this.Name = "FormGraphicsControl";
            this.Text = "FormGraphicsControl";
            this.Load += new System.EventHandler(this.FormGraphicsControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GraphicsControl graphicsControl1;
    }
}