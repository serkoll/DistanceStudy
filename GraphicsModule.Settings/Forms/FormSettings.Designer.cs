namespace GraphicsModule.Settings.Forms
{
    partial class FormSettings
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
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Общие");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Точка");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Прямая");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Отрезок");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Примитивы", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Сетка");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Оси");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Курсор");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Фон");
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.labelTitle = new System.Windows.Forms.Label();
            this.groupBoxControls = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.treeView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxControls, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(571, 324);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Control;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            treeNode10.Name = "NodeGeneral";
            treeNode10.Text = "Общие";
            treeNode11.Name = "NodePoint";
            treeNode11.Text = "Точка";
            treeNode12.Name = "NodeLine";
            treeNode12.Text = "Прямая";
            treeNode13.Name = "NodeSegment";
            treeNode13.Text = "Отрезок";
            treeNode14.Name = "NodeObjects";
            treeNode14.Text = "Примитивы";
            treeNode15.Name = "NodeGrid";
            treeNode15.Text = "Сетка";
            treeNode16.Name = "NodeAxis";
            treeNode16.Text = "Оси";
            treeNode17.Name = "NodeCursor";
            treeNode17.Text = "Курсор";
            treeNode18.Name = "NodeBackground";
            treeNode18.Text = "Фон";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            this.tableLayoutPanel1.SetRowSpan(this.treeView1, 3);
            this.treeView1.Size = new System.Drawing.Size(108, 318);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Location = new System.Drawing.Point(117, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(451, 30);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "labelTitle";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxControls
            // 
            this.groupBoxControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxControls.Location = new System.Drawing.Point(117, 33);
            this.groupBoxControls.Name = "groupBoxControls";
            this.tableLayoutPanel1.SetRowSpan(this.groupBoxControls, 2);
            this.groupBoxControls.Size = new System.Drawing.Size(451, 288);
            this.groupBoxControls.TabIndex = 2;
            this.groupBoxControls.TabStop = false;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 324);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.GroupBox groupBoxControls;
    }
}