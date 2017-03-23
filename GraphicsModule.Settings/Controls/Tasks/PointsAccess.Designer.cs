namespace GraphicsModule.Settings.Controls.Tasks
{
    partial class PointsAccess
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
            this.CheckBoxFlagDrawAxisY = new System.Windows.Forms.CheckBox();
            this.CheckBoxFlagDrawAxisZ = new System.Windows.Forms.CheckBox();
            this.CheckBoxFlagDrawAxisX = new System.Windows.Forms.CheckBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.colorDialogX = new System.Windows.Forms.ColorDialog();
            this.colorDialogY = new System.Windows.Forms.ColorDialog();
            this.colorDialogZ = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // CheckBoxFlagDrawAxisY
            // 
            this.CheckBoxFlagDrawAxisY.AutoSize = true;
            this.CheckBoxFlagDrawAxisY.Checked = true;
            this.CheckBoxFlagDrawAxisY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxFlagDrawAxisY.Location = new System.Drawing.Point(147, 37);
            this.CheckBoxFlagDrawAxisY.Name = "CheckBoxFlagDrawAxisY";
            this.CheckBoxFlagDrawAxisY.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxFlagDrawAxisY.TabIndex = 19;
            this.CheckBoxFlagDrawAxisY.UseVisualStyleBackColor = true;
            this.CheckBoxFlagDrawAxisY.CheckedChanged += new System.EventHandler(this.CheckBoxFlagDrawAxisY_CheckedChanged);
            // 
            // CheckBoxFlagDrawAxisZ
            // 
            this.CheckBoxFlagDrawAxisZ.AutoSize = true;
            this.CheckBoxFlagDrawAxisZ.Checked = true;
            this.CheckBoxFlagDrawAxisZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxFlagDrawAxisZ.Location = new System.Drawing.Point(147, 62);
            this.CheckBoxFlagDrawAxisZ.Name = "CheckBoxFlagDrawAxisZ";
            this.CheckBoxFlagDrawAxisZ.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxFlagDrawAxisZ.TabIndex = 20;
            this.CheckBoxFlagDrawAxisZ.UseVisualStyleBackColor = true;
            this.CheckBoxFlagDrawAxisZ.CheckedChanged += new System.EventHandler(this.CheckBoxFlagDrawAxisZ_CheckedChanged);
            // 
            // CheckBoxFlagDrawAxisX
            // 
            this.CheckBoxFlagDrawAxisX.AutoSize = true;
            this.CheckBoxFlagDrawAxisX.Checked = true;
            this.CheckBoxFlagDrawAxisX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxFlagDrawAxisX.Location = new System.Drawing.Point(147, 13);
            this.CheckBoxFlagDrawAxisX.Name = "CheckBoxFlagDrawAxisX";
            this.CheckBoxFlagDrawAxisX.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxFlagDrawAxisX.TabIndex = 21;
            this.CheckBoxFlagDrawAxisX.UseVisualStyleBackColor = true;
            this.CheckBoxFlagDrawAxisX.CheckedChanged += new System.EventHandler(this.CheckBoxFlagDrawAxisX_CheckedChanged);
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(3, 37);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(115, 13);
            this.Label14.TabIndex = 22;
            this.Label14.Text = "Отображение оси OY";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(3, 62);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(115, 13);
            this.Label15.TabIndex = 23;
            this.Label15.Text = "Отображение оси OY";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(3, 13);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(115, 13);
            this.Label13.TabIndex = 24;
            this.Label13.Text = "Отображение оси OX";
            // 
            // PointsAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CheckBoxFlagDrawAxisY);
            this.Controls.Add(this.CheckBoxFlagDrawAxisZ);
            this.Controls.Add(this.CheckBoxFlagDrawAxisX);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.Label13);
            this.Name = "PointsAccess";
            this.Size = new System.Drawing.Size(555, 258);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox CheckBoxFlagDrawAxisY;
        public System.Windows.Forms.CheckBox CheckBoxFlagDrawAxisZ;
        public System.Windows.Forms.CheckBox CheckBoxFlagDrawAxisX;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label13;
        public System.Windows.Forms.ColorDialog colorDialogX;
        public System.Windows.Forms.ColorDialog colorDialogY;
        public System.Windows.Forms.ColorDialog colorDialogZ;
    }
}
