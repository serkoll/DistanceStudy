namespace DistanceStudy.Forms.Admin
{
    partial class FormAdminPanel
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
            this.buttonCreateForm = new System.Windows.Forms.Button();
            this.textBoxNameTask = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCreateForm
            // 
            this.buttonCreateForm.Location = new System.Drawing.Point(12, 133);
            this.buttonCreateForm.Name = "buttonCreateForm";
            this.buttonCreateForm.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateForm.TabIndex = 0;
            this.buttonCreateForm.Text = "Решить";
            this.buttonCreateForm.UseVisualStyleBackColor = true;
            this.buttonCreateForm.Click += new System.EventHandler(this.buttonCreateForm_Click);
            // 
            // textBoxNameTask
            // 
            this.textBoxNameTask.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxNameTask.Location = new System.Drawing.Point(12, 12);
            this.textBoxNameTask.Multiline = true;
            this.textBoxNameTask.Name = "textBoxNameTask";
            this.textBoxNameTask.Size = new System.Drawing.Size(265, 89);
            this.textBoxNameTask.TabIndex = 1;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(12, 107);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(265, 20);
            this.textBoxDescription.TabIndex = 2;
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(94, 134);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonCheck.TabIndex = 3;
            this.buttonCheck.Text = "Проверить";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // FormAdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 365);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxNameTask);
            this.Controls.Add(this.buttonCreateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Окно администратора";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdminPanel_FormClosing);
            this.Load += new System.EventHandler(this.FormAdminPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateForm;
        private System.Windows.Forms.TextBox textBoxNameTask;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonCheck;
    }
}