namespace GraphicsModule.Settings
{
    partial class SettingPoint
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
            this.label5 = new System.Windows.Forms.Label();
            this.pointIconsList = new System.Windows.Forms.ListBox();
            this.pointColorBox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pointColorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Значок";
            // 
            // pointIconsList
            // 
            this.pointIconsList.FormattingEnabled = true;
            this.pointIconsList.Items.AddRange(new object[] {
            "icon1",
            "icon2",
            "icon3"});
            this.pointIconsList.Location = new System.Drawing.Point(182, 56);
            this.pointIconsList.Name = "pointIconsList";
            this.pointIconsList.Size = new System.Drawing.Size(107, 95);
            this.pointIconsList.TabIndex = 25;
            // 
            // pointColorBox
            // 
            this.pointColorBox.BackColor = System.Drawing.SystemColors.Control;
            this.pointColorBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pointColorBox.Location = new System.Drawing.Point(182, 18);
            this.pointColorBox.Name = "pointColorBox";
            this.pointColorBox.Size = new System.Drawing.Size(36, 31);
            this.pointColorBox.TabIndex = 24;
            this.pointColorBox.TabStop = false;
            this.pointColorBox.Click += new System.EventHandler(this.pointColorBox_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Цвет";
            // 
            // SettingPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pointIconsList);
            this.Controls.Add(this.pointColorBox);
            this.Controls.Add(this.label6);
            this.Name = "SettingPoint";
            this.Size = new System.Drawing.Size(377, 262);
            ((System.ComponentModel.ISupportInitialize)(this.pointColorBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ListBox pointIconsList;
        public System.Windows.Forms.PictureBox pointColorBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}
