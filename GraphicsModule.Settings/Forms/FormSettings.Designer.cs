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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.treeView = new System.Windows.Forms.TreeView();
            this.labelTitle = new System.Windows.Forms.Label();
            this.groupBoxControls = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel.Controls.Add(this.treeView, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelTitle, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.groupBoxControls, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.buttonCancel, 3, 3);
            this.tableLayoutPanel.Controls.Add(this.buttonOK, 2, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(658, 324);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.SystemColors.Control;
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.treeView.Location = new System.Drawing.Point(3, 3);
            this.treeView.Name = "treeView";
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
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            this.tableLayoutPanel.SetRowSpan(this.treeView, 4);
            this.treeView.Size = new System.Drawing.Size(91, 318);
            this.treeView.TabIndex = 0;
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel.SetColumnSpan(this.labelTitle, 3);
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Location = new System.Drawing.Point(100, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(555, 30);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Общие настройки";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxControls
            // 
            this.tableLayoutPanel.SetColumnSpan(this.groupBoxControls, 3);
            this.groupBoxControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxControls.Location = new System.Drawing.Point(100, 33);
            this.groupBoxControls.Name = "groupBoxControls";
            this.tableLayoutPanel.SetRowSpan(this.groupBoxControls, 2);
            this.groupBoxControls.Size = new System.Drawing.Size(555, 258);
            this.groupBoxControls.TabIndex = 2;
            this.groupBoxControls.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(575, 297);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 24);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOK.Location = new System.Drawing.Point(490, 297);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(79, 24);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 324);
            this.Controls.Add(this.tableLayoutPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.GroupBox groupBoxControls;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelTitle;
    }
}