namespace GraphicsModule.Settings.Forms
{
    partial class SettingsForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Общие");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Экран");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Файлы");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Печать");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Курсор");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Сетка");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Оси");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("3D-Точка");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Точка");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Линии связи");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Отрезок");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Фон");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Прямая");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Графический редактор", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Отчеты");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Button_Ok = new System.Windows.Forms.Button();
            this.Button_Help = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.settingSegment1 = new SettingSegment();
            this.settingPoint1 = new SettingPoint();
            this.settingLink1 = new SettingLink();
            this.settingCursor1 = new SettingCursor();
            this.settingGrid1 = new SettingGrid();
            this.setting3DPoint1 = new Setting3DPoint();
            this.settingAxis1 = new SettingAxis();
            this.settingBackground1 = new SettingBackground();
            this.settingLine1 = new SettingLine();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            treeNode1.Name = "Node0";
            treeNode1.Text = "Общие";
            treeNode2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            treeNode2.Name = "Node1";
            treeNode2.Text = "Экран";
            treeNode3.Name = "Node2";
            treeNode3.Text = "Файлы";
            treeNode4.Name = "Node3";
            treeNode4.Text = "Печать";
            treeNode5.Name = "Node5";
            treeNode5.Text = "Курсор";
            treeNode6.Name = "Node6";
            treeNode6.Text = "Сетка";
            treeNode7.Name = "Node7";
            treeNode7.Text = "Оси";
            treeNode8.Name = "Node9";
            treeNode8.Text = "3D-Точка";
            treeNode9.Name = "Node4";
            treeNode9.Text = "Точка";
            treeNode10.Name = "Node1";
            treeNode10.Text = "Линии связи";
            treeNode11.Name = "Node1";
            treeNode11.Text = "Отрезок";
            treeNode12.Name = "Node1";
            treeNode12.Text = "Фон";
            treeNode13.Name = "Node1";
            treeNode13.Text = "Прямая";
            treeNode14.Name = "Node4";
            treeNode14.Text = "Графический редактор";
            treeNode15.Name = "Node8";
            treeNode15.Text = "Отчеты";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode14,
            treeNode15});
            this.treeView1.Size = new System.Drawing.Size(189, 500);
            this.treeView1.TabIndex = 1;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(670, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Button_Ok
            // 
            this.Button_Ok.Location = new System.Drawing.Point(622, 531);
            this.Button_Ok.Name = "Button_Ok";
            this.Button_Ok.Size = new System.Drawing.Size(78, 28);
            this.Button_Ok.TabIndex = 5;
            this.Button_Ok.Text = "OK";
            this.Button_Ok.UseVisualStyleBackColor = true;
            this.Button_Ok.Click += new System.EventHandler(this.Button_Ok_Click);
            // 
            // Button_Help
            // 
            this.Button_Help.Location = new System.Drawing.Point(787, 531);
            this.Button_Help.Name = "Button_Help";
            this.Button_Help.Size = new System.Drawing.Size(78, 28);
            this.Button_Help.TabIndex = 6;
            this.Button_Help.Text = "Справка";
            this.Button_Help.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(704, 531);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(77, 28);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.settingLine1);
            this.splitContainer1.Panel2.Controls.Add(this.settingBackground1);
            this.splitContainer1.Panel2.Controls.Add(this.settingSegment1);
            this.splitContainer1.Panel2.Controls.Add(this.settingPoint1);
            this.splitContainer1.Panel2.Controls.Add(this.settingLink1);
            this.splitContainer1.Panel2.Controls.Add(this.settingCursor1);
            this.splitContainer1.Panel2.Controls.Add(this.settingGrid1);
            this.splitContainer1.Panel2.Controls.Add(this.setting3DPoint1);
            this.splitContainer1.Panel2.Controls.Add(this.settingAxis1);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Size = new System.Drawing.Size(862, 500);
            this.splitContainer1.SplitterDistance = 188;
            this.splitContainer1.TabIndex = 12;
            // 
            // settingSegment1
            // 
            this.settingSegment1.Location = new System.Drawing.Point(296, 164);
            this.settingSegment1.Name = "settingSegment1";
            this.settingSegment1.Size = new System.Drawing.Size(119, 103);
            this.settingSegment1.TabIndex = 9;
            // 
            // settingPoint1
            // 
            this.settingPoint1.Location = new System.Drawing.Point(157, 164);
            this.settingPoint1.Name = "settingPoint1";
            this.settingPoint1.Size = new System.Drawing.Size(133, 103);
            this.settingPoint1.TabIndex = 8;
            // 
            // settingLink1
            // 
            this.settingLink1.Location = new System.Drawing.Point(16, 148);
            this.settingLink1.Name = "settingLink1";
            this.settingLink1.Size = new System.Drawing.Size(131, 119);
            this.settingLink1.TabIndex = 7;
            // 
            // settingCursor1
            // 
            this.settingCursor1.Location = new System.Drawing.Point(399, 33);
            this.settingCursor1.Name = "settingCursor1";
            this.settingCursor1.Size = new System.Drawing.Size(135, 116);
            this.settingCursor1.TabIndex = 6;
            // 
            // settingGrid1
            // 
            this.settingGrid1.Location = new System.Drawing.Point(16, 33);
            this.settingGrid1.Name = "settingGrid1";
            this.settingGrid1.Size = new System.Drawing.Size(131, 109);
            this.settingGrid1.TabIndex = 5;
            // 
            // setting3DPoint1
            // 
            this.setting3DPoint1.Location = new System.Drawing.Point(276, 33);
            this.setting3DPoint1.Name = "setting3DPoint1";
            this.setting3DPoint1.Size = new System.Drawing.Size(117, 116);
            this.setting3DPoint1.TabIndex = 4;
            // 
            // settingAxis1
            // 
            this.settingAxis1.Location = new System.Drawing.Point(153, 33);
            this.settingAxis1.Name = "settingAxis1";
            this.settingAxis1.Size = new System.Drawing.Size(117, 116);
            this.settingAxis1.TabIndex = 3;
            // 
            // settingBackground1
            // 
            this.settingBackground1.Location = new System.Drawing.Point(418, 179);
            this.settingBackground1.Name = "settingBackground1";
            this.settingBackground1.Size = new System.Drawing.Size(135, 88);
            this.settingBackground1.TabIndex = 10;
            // 
            // settingLine1
            // 
            this.settingLine1.Location = new System.Drawing.Point(16, 273);
            this.settingLine1.Name = "settingLine1";
            this.settingLine1.Size = new System.Drawing.Size(131, 118);
            this.settingLine1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 571);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.Button_Ok);
            this.Controls.Add(this.Button_Help);
            this.Controls.Add(this.CancelButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox1;
        private SettingAxis settingAxis1;
        internal System.Windows.Forms.Button Button_Ok;
        internal System.Windows.Forms.Button Button_Help;
        internal System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Setting3DPoint setting3DPoint1;
        private SettingGrid settingGrid1;
        private SettingCursor settingCursor1;
        private SettingLink settingLink1;
        private SettingSegment settingSegment1;
        private SettingPoint settingPoint1;
        private SettingBackground settingBackground1;
        private SettingLine settingLine1;
    }
}

