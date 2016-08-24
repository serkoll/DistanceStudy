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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainStudent));
            this.treeView_thema = new System.Windows.Forms.TreeView();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxDesc = new System.Windows.Forms.TextBox();
            this.groupBoxTheory = new System.Windows.Forms.GroupBox();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSolve = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCheckTask = new System.Windows.Forms.ToolStripButton();
            this.groupBoxTheory.SuspendLayout();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView_thema
            // 
            this.treeView_thema.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView_thema.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView_thema.Location = new System.Drawing.Point(0, 28);
            this.treeView_thema.Name = "treeView_thema";
            this.treeView_thema.Size = new System.Drawing.Size(340, 447);
            this.treeView_thema.TabIndex = 1;
            this.treeView_thema.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_thema_NodeMouseClick);
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxName.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(3, 16);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(364, 26);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxDesc
            // 
            this.textBoxDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDesc.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDesc.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDesc.Location = new System.Drawing.Point(3, 48);
            this.textBoxDesc.Multiline = true;
            this.textBoxDesc.Name = "textBoxDesc";
            this.textBoxDesc.ReadOnly = true;
            this.textBoxDesc.Size = new System.Drawing.Size(364, 396);
            this.textBoxDesc.TabIndex = 3;
            // 
            // groupBoxTheory
            // 
            this.groupBoxTheory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTheory.Controls.Add(this.textBoxDesc);
            this.groupBoxTheory.Controls.Add(this.textBoxName);
            this.groupBoxTheory.Location = new System.Drawing.Point(337, 28);
            this.groupBoxTheory.Name = "groupBoxTheory";
            this.groupBoxTheory.Size = new System.Drawing.Size(370, 447);
            this.groupBoxTheory.TabIndex = 4;
            this.groupBoxTheory.TabStop = false;
            this.groupBoxTheory.Text = "Описание";
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSolve,
            this.toolStripButtonCheckTask});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(707, 28);
            this.toolStripMenu.TabIndex = 5;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // toolStripButtonSolve
            // 
            this.toolStripButtonSolve.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSolve.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripButtonSolve.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSolve.Image")));
            this.toolStripButtonSolve.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSolve.Name = "toolStripButtonSolve";
            this.toolStripButtonSolve.Size = new System.Drawing.Size(68, 25);
            this.toolStripButtonSolve.Text = "Решить";
            this.toolStripButtonSolve.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolStripButtonSolve.ToolTipText = "Решить";
            this.toolStripButtonSolve.Click += new System.EventHandler(this.toolStripButtonSolve_Click);
            // 
            // toolStripButtonCheckTask
            // 
            this.toolStripButtonCheckTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonCheckTask.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripButtonCheckTask.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCheckTask.Image")));
            this.toolStripButtonCheckTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCheckTask.Name = "toolStripButtonCheckTask";
            this.toolStripButtonCheckTask.Size = new System.Drawing.Size(92, 25);
            this.toolStripButtonCheckTask.Text = "Проверить";
            this.toolStripButtonCheckTask.Visible = false;
            this.toolStripButtonCheckTask.Click += new System.EventHandler(this.toolStripButtonCheckTask_Click);
            // 
            // FormMainStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 475);
            this.Controls.Add(this.treeView_thema);
            this.Controls.Add(this.groupBoxTheory);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "FormMainStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добро пожаловать, студент!";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMainStudent_FormClosed);
            this.Load += new System.EventHandler(this.FormMainStudent_Load);
            this.groupBoxTheory.ResumeLayout(false);
            this.groupBoxTheory.PerformLayout();
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TreeView treeView_thema;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxDesc;
        private System.Windows.Forms.GroupBox groupBoxTheory;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton toolStripButtonSolve;
        private System.Windows.Forms.ToolStripButton toolStripButtonCheckTask;
    }
}