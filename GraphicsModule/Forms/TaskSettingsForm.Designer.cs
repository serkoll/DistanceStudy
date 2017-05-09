namespace GraphicsModule.Forms
{
    partial class TaskSettingsForm
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
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Общие");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Точка");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Прямая");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Отрезок");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Плоскость");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Примитивы", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17});
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MainTreeView = new System.Windows.Forms.TreeView();
            this.titleLabel = new System.Windows.Forms.Label();
            this.groupBoxControls = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel.Controls.Add(this.MainTreeView, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.titleLabel, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.groupBoxControls, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.button1, 1, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.747293F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.25271F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(731, 324);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // MainTreeView
            // 
            this.MainTreeView.BackColor = System.Drawing.SystemColors.Control;
            this.MainTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTreeView.Location = new System.Drawing.Point(3, 3);
            this.MainTreeView.Name = "MainTreeView";
            treeNode13.Name = "NodeGeneral";
            treeNode13.Text = "Общие";
            treeNode14.Name = "NodePoint";
            treeNode14.Text = "Точка";
            treeNode15.Name = "NodeLine";
            treeNode15.Text = "Прямая";
            treeNode16.Name = "NodeSegment";
            treeNode16.Text = "Отрезок";
            treeNode17.Name = "NodePlane";
            treeNode17.Text = "Плоскость";
            treeNode18.Name = "NodePrimitive";
            treeNode18.Text = "Примитивы";
            this.MainTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode18});
            this.tableLayoutPanel.SetRowSpan(this.MainTreeView, 3);
            this.MainTreeView.Size = new System.Drawing.Size(140, 318);
            this.MainTreeView.TabIndex = 0;
            this.MainTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.mainTreeView_NodeMouseClick);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Location = new System.Drawing.Point(149, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(579, 28);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Настройки";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxControls
            // 
            this.groupBoxControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxControls.Location = new System.Drawing.Point(149, 31);
            this.groupBoxControls.Name = "groupBoxControls";
            this.groupBoxControls.Size = new System.Drawing.Size(579, 259);
            this.groupBoxControls.TabIndex = 2;
            this.groupBoxControls.TabStop = false;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(653, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TaskSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 324);
            this.Controls.Add(this.tableLayoutPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskSettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TreeView MainTreeView;
        private System.Windows.Forms.GroupBox groupBoxControls;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button button1;
    }
}