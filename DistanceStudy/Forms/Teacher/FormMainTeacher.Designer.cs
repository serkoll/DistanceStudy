namespace DistanceStudy.Forms.Teacher
{
    partial class FormMainTeacher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainTeacher));
            this.splitContainerPanel = new System.Windows.Forms.SplitContainer();
            this.treeView_thema = new System.Windows.Forms.TreeView();
            this.listView_thema = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderImage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripPanel = new System.Windows.Forms.ToolStrip();
            this.CreateButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.edittoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.exitToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deletetoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.panelMenu = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPanel)).BeginInit();
            this.splitContainerPanel.Panel1.SuspendLayout();
            this.splitContainerPanel.Panel2.SuspendLayout();
            this.splitContainerPanel.SuspendLayout();
            this.toolStripPanel.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerPanel
            // 
            this.splitContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerPanel.Location = new System.Drawing.Point(0, 38);
            this.splitContainerPanel.Name = "splitContainerPanel";
            // 
            // splitContainerPanel.Panel1
            // 
            this.splitContainerPanel.Panel1.Controls.Add(this.treeView_thema);
            // 
            // splitContainerPanel.Panel2
            // 
            this.splitContainerPanel.Panel2.Controls.Add(this.listView_thema);
            this.splitContainerPanel.Size = new System.Drawing.Size(729, 333);
            this.splitContainerPanel.SplitterDistance = 241;
            this.splitContainerPanel.TabIndex = 0;
            // 
            // treeView_thema
            // 
            this.treeView_thema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_thema.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView_thema.Location = new System.Drawing.Point(0, 0);
            this.treeView_thema.Name = "treeView_thema";
            this.treeView_thema.Size = new System.Drawing.Size(241, 333);
            this.treeView_thema.TabIndex = 0;
            this.treeView_thema.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_thema_NodeMouseClick);
            this.treeView_thema.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.treeView_thema_KeyPress);
            // 
            // listView_thema
            // 
            this.listView_thema.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderDesc,
            this.columnHeaderImage});
            this.listView_thema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_thema.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView_thema.Location = new System.Drawing.Point(0, 0);
            this.listView_thema.Name = "listView_thema";
            this.listView_thema.Size = new System.Drawing.Size(484, 333);
            this.listView_thema.TabIndex = 0;
            this.listView_thema.UseCompatibleStateImageBehavior = false;
            this.listView_thema.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Название";
            this.columnHeaderName.Width = 118;
            // 
            // columnHeaderDesc
            // 
            this.columnHeaderDesc.Text = "Описание";
            this.columnHeaderDesc.Width = 124;
            // 
            // columnHeaderImage
            // 
            this.columnHeaderImage.Text = "Графическое представление";
            this.columnHeaderImage.Width = 224;
            // 
            // toolStripPanel
            // 
            this.toolStripPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateButton,
            this.copyToolStripButton,
            this.edittoolStripButton,
            this.exitToolStripButton,
            this.deletetoolStripButton});
            this.toolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.toolStripPanel.Name = "toolStripPanel";
            this.toolStripPanel.Size = new System.Drawing.Size(729, 39);
            this.toolStripPanel.TabIndex = 16;
            this.toolStripPanel.Text = "ToolStrip";
            // 
            // CreateButton
            // 
            this.CreateButton.Image = ((System.Drawing.Image)(resources.GetObject("CreateButton.Image")));
            this.CreateButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CreateButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(86, 36);
            this.CreateButton.Text = "Создать";
            this.CreateButton.ToolTipText = "Создание темы, подтемы или задачи";
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(108, 36);
            this.copyToolStripButton.Text = "Копировать";
            this.copyToolStripButton.ToolTipText = "Копировать тему, подтему или задачу";
            // 
            // edittoolStripButton
            // 
            this.edittoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("edittoolStripButton.Image")));
            this.edittoolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.edittoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.edittoolStripButton.Name = "edittoolStripButton";
            this.edittoolStripButton.Size = new System.Drawing.Size(123, 36);
            this.edittoolStripButton.Text = "Редактировать";
            this.edittoolStripButton.ToolTipText = "Редактировать текст темы, подтемы или подсказки";
            this.edittoolStripButton.Click += new System.EventHandler(this.edittoolStripButton_Click);
            // 
            // exitToolStripButton
            // 
            this.exitToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exitToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exitToolStripButton.Image = global::DistanceStudy.Properties.Resources.exit;
            this.exitToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitToolStripButton.Name = "exitToolStripButton";
            this.exitToolStripButton.Size = new System.Drawing.Size(45, 36);
            this.exitToolStripButton.Text = "Выход";
            this.exitToolStripButton.ToolTipText = "Выход на окно авторизации";
            // 
            // deletetoolStripButton
            // 
            this.deletetoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deletetoolStripButton.Image")));
            this.deletetoolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deletetoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deletetoolStripButton.Name = "deletetoolStripButton";
            this.deletetoolStripButton.Size = new System.Drawing.Size(87, 36);
            this.deletetoolStripButton.Text = "Удалить";
            this.deletetoolStripButton.ToolTipText = "Удалить тему, подтему или задачу";
            this.deletetoolStripButton.Click += new System.EventHandler(this.deletetoolStripButton_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.toolStripPanel);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(729, 38);
            this.panelMenu.TabIndex = 17;
            // 
            // FormMainTeacher
            // 
            this.ClientSize = new System.Drawing.Size(729, 371);
            this.Controls.Add(this.splitContainerPanel);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMainTeacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добро пожаловать, преподаватель!";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMainTeacher_FormClosed);
            this.splitContainerPanel.Panel1.ResumeLayout(false);
            this.splitContainerPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPanel)).EndInit();
            this.splitContainerPanel.ResumeLayout(false);
            this.toolStripPanel.ResumeLayout(false);
            this.toolStripPanel.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView treeView_thema;
        public System.Windows.Forms.SplitContainer splitContainerPanel;
        public System.Windows.Forms.ListView listView_thema;
        public System.Windows.Forms.ColumnHeader columnHeaderName;
        public System.Windows.Forms.ColumnHeader columnHeaderDesc;
        private System.Windows.Forms.ToolStrip toolStripPanel;
        private System.Windows.Forms.ToolStripButton CreateButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton edittoolStripButton;
        private System.Windows.Forms.ColumnHeader columnHeaderImage;
        private System.Windows.Forms.ToolStripButton exitToolStripButton;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.ToolStripButton deletetoolStripButton;
    }
}