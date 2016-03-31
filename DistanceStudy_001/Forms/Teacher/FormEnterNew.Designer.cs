namespace DistanceStudy.Forms.Teacher
{
    partial class FormEnterNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEnterNew));
            this.textBox_head = new System.Windows.Forms.TextBox();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.panelTextBoxesButton = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelTextBoxesButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_head
            // 
            this.textBox_head.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_head.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_head.Location = new System.Drawing.Point(3, 3);
            this.textBox_head.Name = "textBox_head";
            this.textBox_head.Size = new System.Drawing.Size(656, 21);
            this.textBox_head.TabIndex = 0;
            this.textBox_head.Text = "Введите название...";
            this.textBox_head.TextChanged += new System.EventHandler(this.textBox_head_TextChanged);
            this.textBox_head.Enter += new System.EventHandler(this.textBox_head_Enter);
            this.textBox_head.Leave += new System.EventHandler(this.textBox_head_Leave);
            // 
            // textBox_description
            // 
            this.textBox_description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_description.Location = new System.Drawing.Point(3, 37);
            this.textBox_description.Multiline = true;
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_description.Size = new System.Drawing.Size(656, 286);
            this.textBox_description.TabIndex = 1;
            this.textBox_description.Text = "Введите описание...";
            this.textBox_description.Enter += new System.EventHandler(this.textBox_description_Enter);
            this.textBox_description.Leave += new System.EventHandler(this.textBox_description_Leave);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOK.Location = new System.Drawing.Point(3, 329);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(120, 30);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "Продолжить";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // panelTextBoxesButton
            // 
            this.panelTextBoxesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTextBoxesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelTextBoxesButton.Controls.Add(this.buttonCancel);
            this.panelTextBoxesButton.Controls.Add(this.textBox_head);
            this.panelTextBoxesButton.Controls.Add(this.textBox_description);
            this.panelTextBoxesButton.Controls.Add(this.buttonOK);
            this.panelTextBoxesButton.Location = new System.Drawing.Point(12, 12);
            this.panelTextBoxesButton.Name = "panelTextBoxesButton";
            this.panelTextBoxesButton.Size = new System.Drawing.Size(662, 363);
            this.panelTextBoxesButton.TabIndex = 5;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(539, 330);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 30);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormEnterNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 387);
            this.Controls.Add(this.panelTextBoxesButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEnterNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создать";
            this.panelTextBoxesButton.ResumeLayout(false);
            this.panelTextBoxesButton.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox textBox_head;
        public System.Windows.Forms.TextBox textBox_description;
        public System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Panel panelTextBoxesButton;
        private System.Windows.Forms.Button buttonCancel;
    }
}