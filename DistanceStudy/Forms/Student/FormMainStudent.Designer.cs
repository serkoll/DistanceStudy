namespace DistanceStudy.Forms.Student
{
    partial class FormMainStudent
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
            this.treeView_thema = new System.Windows.Forms.TreeView();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxDesc = new System.Windows.Forms.TextBox();
            this.groupBoxTheory = new System.Windows.Forms.GroupBox();
            this.groupBoxTheory.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView_thema
            // 
            this.treeView_thema.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView_thema.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView_thema.Location = new System.Drawing.Point(0, 0);
            this.treeView_thema.Name = "treeView_thema";
            this.treeView_thema.Size = new System.Drawing.Size(340, 475);
            this.treeView_thema.TabIndex = 1;
            this.treeView_thema.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_thema_NodeMouseDoubleClick);
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxName.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxName.Enabled = false;
            this.textBoxName.Location = new System.Drawing.Point(3, 16);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(364, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxDesc
            // 
            this.textBoxDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDesc.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxDesc.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxDesc.Enabled = false;
            this.textBoxDesc.Location = new System.Drawing.Point(3, 42);
            this.textBoxDesc.Multiline = true;
            this.textBoxDesc.Name = "textBoxDesc";
            this.textBoxDesc.ReadOnly = true;
            this.textBoxDesc.Size = new System.Drawing.Size(364, 430);
            this.textBoxDesc.TabIndex = 3;
            // 
            // groupBoxTheory
            // 
            this.groupBoxTheory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTheory.Controls.Add(this.textBoxDesc);
            this.groupBoxTheory.Controls.Add(this.textBoxName);
            this.groupBoxTheory.Location = new System.Drawing.Point(337, 0);
            this.groupBoxTheory.Name = "groupBoxTheory";
            this.groupBoxTheory.Size = new System.Drawing.Size(370, 475);
            this.groupBoxTheory.TabIndex = 4;
            this.groupBoxTheory.TabStop = false;
            this.groupBoxTheory.Text = "Описание";
            // 
            // FormMainStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 475);
            this.Controls.Add(this.treeView_thema);
            this.Controls.Add(this.groupBoxTheory);
            this.Name = "FormMainStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добро пожаловать, студент!";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMainStudent_FormClosed);
            this.Load += new System.EventHandler(this.FormMainStudent_Load);
            this.groupBoxTheory.ResumeLayout(false);
            this.groupBoxTheory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView treeView_thema;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxDesc;
        private System.Windows.Forms.GroupBox groupBoxTheory;
    }
}