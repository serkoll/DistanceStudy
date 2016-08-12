namespace GraphicsModule
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.baseTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.workspaceOperationsStatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1_X_Value = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1_Y_Value = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1_Z_Value = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_ZeroLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4_StatusGrid = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5_SatusAxis = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6_StatusLinkLine = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7_CursorToGridFixation = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_ExternalEntitiy = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Help = new System.Windows.Forms.ToolStripStatusLabel();
            this.graphicsToolBarStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Point2D = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Point3D = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_PointProjectionPi1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_PointProjectionPi2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_PointProjectionPi3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Line2D = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Line3D = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_LineProjectionPi1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_LineProjectionPi2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_LineProjectionPi3 = new System.Windows.Forms.ToolStripButton();
            this.basicToolBarStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_DeleteSelected = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ClearAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Scale = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBox_ScaleSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton34 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инструментыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.окнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.baseTableLayoutPanel.SuspendLayout();
            this.workspaceOperationsStatusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.graphicsToolBarStrip.SuspendLayout();
            this.basicToolBarStrip.SuspendLayout();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // baseTableLayoutPanel
            // 
            this.baseTableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.baseTableLayoutPanel.ColumnCount = 3;
            this.baseTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.baseTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.baseTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.baseTableLayoutPanel.Controls.Add(this.workspaceOperationsStatusStrip1, 0, 4);
            this.baseTableLayoutPanel.Controls.Add(this.statusStrip2, 1, 3);
            this.baseTableLayoutPanel.Controls.Add(this.graphicsToolBarStrip, 0, 2);
            this.baseTableLayoutPanel.Controls.Add(this.basicToolBarStrip, 0, 1);
            this.baseTableLayoutPanel.Controls.Add(this.MainMenu, 0, 0);
            this.baseTableLayoutPanel.Controls.Add(this.MainPictureBox, 1, 2);
            this.baseTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.baseTableLayoutPanel.Name = "baseTableLayoutPanel";
            this.baseTableLayoutPanel.RowCount = 5;
            this.baseTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.baseTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.baseTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.baseTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.baseTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.baseTableLayoutPanel.Size = new System.Drawing.Size(1192, 596);
            this.baseTableLayoutPanel.TabIndex = 7;
            // 
            // workspaceOperationsStatusStrip1
            // 
            this.workspaceOperationsStatusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.baseTableLayoutPanel.SetColumnSpan(this.workspaceOperationsStatusStrip1, 3);
            this.workspaceOperationsStatusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workspaceOperationsStatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1_X_Value,
            this.toolStripStatusLabel1_Y_Value,
            this.toolStripStatusLabel1_Z_Value,
            this.toolStripStatusLabel_ZeroLabel,
            this.toolStripStatusLabel4_StatusGrid,
            this.toolStripStatusLabel5_SatusAxis,
            this.toolStripStatusLabel6_StatusLinkLine,
            this.toolStripStatusLabel7_CursorToGridFixation,
            this.toolStripStatusLabel_ExternalEntitiy});
            this.workspaceOperationsStatusStrip1.Location = new System.Drawing.Point(0, 571);
            this.workspaceOperationsStatusStrip1.Name = "workspaceOperationsStatusStrip1";
            this.workspaceOperationsStatusStrip1.Size = new System.Drawing.Size(1192, 25);
            this.workspaceOperationsStatusStrip1.SizingGrip = false;
            this.workspaceOperationsStatusStrip1.TabIndex = 11;
            this.workspaceOperationsStatusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1_X_Value
            // 
            this.toolStripStatusLabel1_X_Value.Enabled = false;
            this.toolStripStatusLabel1_X_Value.Name = "toolStripStatusLabel1_X_Value";
            this.toolStripStatusLabel1_X_Value.Size = new System.Drawing.Size(22, 20);
            this.toolStripStatusLabel1_X_Value.Text = "X=";
            // 
            // toolStripStatusLabel1_Y_Value
            // 
            this.toolStripStatusLabel1_Y_Value.Name = "toolStripStatusLabel1_Y_Value";
            this.toolStripStatusLabel1_Y_Value.Size = new System.Drawing.Size(22, 20);
            this.toolStripStatusLabel1_Y_Value.Text = "Y=";
            // 
            // toolStripStatusLabel1_Z_Value
            // 
            this.toolStripStatusLabel1_Z_Value.Name = "toolStripStatusLabel1_Z_Value";
            this.toolStripStatusLabel1_Z_Value.Size = new System.Drawing.Size(22, 20);
            this.toolStripStatusLabel1_Z_Value.Text = "Z=";
            // 
            // toolStripStatusLabel_ZeroLabel
            // 
            this.toolStripStatusLabel_ZeroLabel.Name = "toolStripStatusLabel_ZeroLabel";
            this.toolStripStatusLabel_ZeroLabel.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel_ZeroLabel.Text = "  ";
            // 
            // toolStripStatusLabel4_StatusGrid
            // 
            this.toolStripStatusLabel4_StatusGrid.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel4_StatusGrid.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel4_StatusGrid.Name = "toolStripStatusLabel4_StatusGrid";
            this.toolStripStatusLabel4_StatusGrid.Size = new System.Drawing.Size(42, 20);
            this.toolStripStatusLabel4_StatusGrid.Text = "Сетка";
            this.toolStripStatusLabel4_StatusGrid.Click += new System.EventHandler(this.toolStripStatusLabel4_StatusGrid_Click);
            // 
            // toolStripStatusLabel5_SatusAxis
            // 
            this.toolStripStatusLabel5_SatusAxis.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel5_SatusAxis.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel5_SatusAxis.Name = "toolStripStatusLabel5_SatusAxis";
            this.toolStripStatusLabel5_SatusAxis.Size = new System.Drawing.Size(33, 20);
            this.toolStripStatusLabel5_SatusAxis.Text = "Оси";
            this.toolStripStatusLabel5_SatusAxis.Click += new System.EventHandler(this.toolStripStatusLabel5_SatusAxis_Click);
            // 
            // toolStripStatusLabel6_StatusLinkLine
            // 
            this.toolStripStatusLabel6_StatusLinkLine.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel6_StatusLinkLine.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel6_StatusLinkLine.Name = "toolStripStatusLabel6_StatusLinkLine";
            this.toolStripStatusLabel6_StatusLinkLine.Size = new System.Drawing.Size(80, 20);
            this.toolStripStatusLabel6_StatusLinkLine.Text = "Линии связи";
            this.toolStripStatusLabel6_StatusLinkLine.Click += new System.EventHandler(this.toolStripStatusLabel6_StatusLinkLine_Click);
            // 
            // toolStripStatusLabel7_CursorToGridFixation
            // 
            this.toolStripStatusLabel7_CursorToGridFixation.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel7_CursorToGridFixation.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.toolStripStatusLabel7_CursorToGridFixation.Name = "toolStripStatusLabel7_CursorToGridFixation";
            this.toolStripStatusLabel7_CursorToGridFixation.Size = new System.Drawing.Size(104, 20);
            this.toolStripStatusLabel7_CursorToGridFixation.Text = "Привязка к сетке";
            this.toolStripStatusLabel7_CursorToGridFixation.Click += new System.EventHandler(this.toolStripStatusLabel7_CursorToGridFixation_Click);
            // 
            // toolStripStatusLabel_ExternalEntitiy
            // 
            this.toolStripStatusLabel_ExternalEntitiy.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel_ExternalEntitiy.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel_ExternalEntitiy.Name = "toolStripStatusLabel_ExternalEntitiy";
            this.toolStripStatusLabel_ExternalEntitiy.Size = new System.Drawing.Size(104, 20);
            this.toolStripStatusLabel_ExternalEntitiy.Text = "Внешний объект";
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.baseTableLayoutPanel.SetColumnSpan(this.statusStrip2, 2);
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Help});
            this.statusStrip2.Location = new System.Drawing.Point(32, 544);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1160, 27);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 10;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel_Help
            // 
            this.toolStripStatusLabel_Help.Name = "toolStripStatusLabel_Help";
            this.toolStripStatusLabel_Help.Size = new System.Drawing.Size(64, 22);
            this.toolStripStatusLabel_Help.Text = "Подсказка";
            // 
            // graphicsToolBarStrip
            // 
            this.graphicsToolBarStrip.BackColor = System.Drawing.SystemColors.Control;
            this.graphicsToolBarStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.graphicsToolBarStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.graphicsToolBarStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.graphicsToolBarStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Point2D,
            this.toolStripButton_Point3D,
            this.toolStripButton_PointProjectionPi1,
            this.toolStripButton_PointProjectionPi2,
            this.toolStripButton_PointProjectionPi3,
            this.toolStripButton_Line2D,
            this.toolStripButton_Line3D,
            this.toolStripButton_LineProjectionPi1,
            this.toolStripButton_LineProjectionPi2,
            this.toolStripButton_LineProjectionPi3,
            this.toolStripButton1});
            this.graphicsToolBarStrip.Location = new System.Drawing.Point(0, 55);
            this.graphicsToolBarStrip.Name = "graphicsToolBarStrip";
            this.baseTableLayoutPanel.SetRowSpan(this.graphicsToolBarStrip, 2);
            this.graphicsToolBarStrip.Size = new System.Drawing.Size(32, 516);
            this.graphicsToolBarStrip.TabIndex = 4;
            this.graphicsToolBarStrip.Text = "toolStrip2";
            // 
            // toolStripButton_Point2D
            // 
            this.toolStripButton_Point2D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Point2D.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Point2D.Image")));
            this.toolStripButton_Point2D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Point2D.Name = "toolStripButton_Point2D";
            this.toolStripButton_Point2D.Size = new System.Drawing.Size(34, 36);
            this.toolStripButton_Point2D.Text = "Точка";
            this.toolStripButton_Point2D.Click += new System.EventHandler(this.toolStripButton_Point2D_Click);
            // 
            // toolStripButton_Point3D
            // 
            this.toolStripButton_Point3D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Point3D.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Point3D.Image")));
            this.toolStripButton_Point3D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Point3D.Name = "toolStripButton_Point3D";
            this.toolStripButton_Point3D.Size = new System.Drawing.Size(34, 36);
            this.toolStripButton_Point3D.Text = "3D точка";
            this.toolStripButton_Point3D.Click += new System.EventHandler(this.toolStripButton14_Click);
            // 
            // toolStripButton_PointProjectionPi1
            // 
            this.toolStripButton_PointProjectionPi1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_PointProjectionPi1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_PointProjectionPi1.Image")));
            this.toolStripButton_PointProjectionPi1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_PointProjectionPi1.Name = "toolStripButton_PointProjectionPi1";
            this.toolStripButton_PointProjectionPi1.Size = new System.Drawing.Size(34, 36);
            this.toolStripButton_PointProjectionPi1.Text = "Проекция точки на Pi1";
            this.toolStripButton_PointProjectionPi1.Click += new System.EventHandler(this.toolStripButton16_Click);
            // 
            // toolStripButton_PointProjectionPi2
            // 
            this.toolStripButton_PointProjectionPi2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_PointProjectionPi2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_PointProjectionPi2.Image")));
            this.toolStripButton_PointProjectionPi2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_PointProjectionPi2.Name = "toolStripButton_PointProjectionPi2";
            this.toolStripButton_PointProjectionPi2.Size = new System.Drawing.Size(34, 36);
            this.toolStripButton_PointProjectionPi2.Text = "Проекция точки на Pi2";
            this.toolStripButton_PointProjectionPi2.Click += new System.EventHandler(this.toolStripButton17_Click);
            // 
            // toolStripButton_PointProjectionPi3
            // 
            this.toolStripButton_PointProjectionPi3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_PointProjectionPi3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_PointProjectionPi3.Image")));
            this.toolStripButton_PointProjectionPi3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_PointProjectionPi3.Name = "toolStripButton_PointProjectionPi3";
            this.toolStripButton_PointProjectionPi3.Size = new System.Drawing.Size(34, 36);
            this.toolStripButton_PointProjectionPi3.Text = "Проекция точки на Pi3";
            this.toolStripButton_PointProjectionPi3.Click += new System.EventHandler(this.toolStripButton18_Click);
            // 
            // toolStripButton_Line2D
            // 
            this.toolStripButton_Line2D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Line2D.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Line2D.Image")));
            this.toolStripButton_Line2D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Line2D.Name = "toolStripButton_Line2D";
            this.toolStripButton_Line2D.Size = new System.Drawing.Size(34, 36);
            this.toolStripButton_Line2D.Text = "Прямая";
            this.toolStripButton_Line2D.Click += new System.EventHandler(this.toolStripButton26_Click);
            // 
            // toolStripButton_Line3D
            // 
            this.toolStripButton_Line3D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Line3D.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Line3D.Image")));
            this.toolStripButton_Line3D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Line3D.Name = "toolStripButton_Line3D";
            this.toolStripButton_Line3D.Size = new System.Drawing.Size(34, 36);
            this.toolStripButton_Line3D.Text = "3D прямая";
            this.toolStripButton_Line3D.Click += new System.EventHandler(this.toolStripButton27_Click);
            // 
            // toolStripButton_LineProjectionPi1
            // 
            this.toolStripButton_LineProjectionPi1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_LineProjectionPi1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_LineProjectionPi1.Image")));
            this.toolStripButton_LineProjectionPi1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_LineProjectionPi1.Name = "toolStripButton_LineProjectionPi1";
            this.toolStripButton_LineProjectionPi1.Size = new System.Drawing.Size(34, 36);
            this.toolStripButton_LineProjectionPi1.Text = "Проекция прямой на Pi1";
            this.toolStripButton_LineProjectionPi1.Click += new System.EventHandler(this.toolStripButton29_Click);
            // 
            // toolStripButton_LineProjectionPi2
            // 
            this.toolStripButton_LineProjectionPi2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_LineProjectionPi2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_LineProjectionPi2.Image")));
            this.toolStripButton_LineProjectionPi2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_LineProjectionPi2.Name = "toolStripButton_LineProjectionPi2";
            this.toolStripButton_LineProjectionPi2.Size = new System.Drawing.Size(34, 36);
            this.toolStripButton_LineProjectionPi2.Text = "Проекция прямой на Pi2";
            this.toolStripButton_LineProjectionPi2.Click += new System.EventHandler(this.toolStripButton30_Click);
            // 
            // toolStripButton_LineProjectionPi3
            // 
            this.toolStripButton_LineProjectionPi3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_LineProjectionPi3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_LineProjectionPi3.Image")));
            this.toolStripButton_LineProjectionPi3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_LineProjectionPi3.Name = "toolStripButton_LineProjectionPi3";
            this.toolStripButton_LineProjectionPi3.Size = new System.Drawing.Size(34, 36);
            this.toolStripButton_LineProjectionPi3.Text = "Проекция прямой на Pi3";
            this.toolStripButton_LineProjectionPi3.Click += new System.EventHandler(this.toolStripButton31_Click);
            // 
            // basicToolBarStrip
            // 
            this.basicToolBarStrip.BackColor = System.Drawing.SystemColors.Control;
            this.basicToolBarStrip.CanOverflow = false;
            this.baseTableLayoutPanel.SetColumnSpan(this.basicToolBarStrip, 3);
            this.basicToolBarStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.basicToolBarStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.basicToolBarStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripSeparator1,
            this.toolStripButton9,
            this.toolStripButton_DeleteSelected,
            this.toolStripButton_ClearAll,
            this.toolStripSeparator2,
            this.toolStripButton_Scale,
            this.toolStripComboBox_ScaleSize,
            this.toolStripButton34,
            this.toolStripSeparator3});
            this.basicToolBarStrip.Location = new System.Drawing.Point(0, 25);
            this.basicToolBarStrip.Name = "basicToolBarStrip";
            this.basicToolBarStrip.Size = new System.Drawing.Size(1192, 30);
            this.basicToolBarStrip.TabIndex = 2;
            this.basicToolBarStrip.Text = "toolStrip1";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(62, 27);
            this.toolStripButton5.Text = "Вырезать";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(76, 27);
            this.toolStripButton6.Text = "Копировать";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(59, 27);
            this.toolStripButton7.Text = "Вставить";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(58, 27);
            this.toolStripButton8.Text = "Выбрать";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(54, 27);
            this.toolStripButton9.Text = "Стереть";
            this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // toolStripButton_DeleteSelected
            // 
            this.toolStripButton_DeleteSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_DeleteSelected.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_DeleteSelected.Image")));
            this.toolStripButton_DeleteSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_DeleteSelected.Name = "toolStripButton_DeleteSelected";
            this.toolStripButton_DeleteSelected.Size = new System.Drawing.Size(120, 27);
            this.toolStripButton_DeleteSelected.Text = "Удалить выбранное";
            this.toolStripButton_DeleteSelected.Click += new System.EventHandler(this.toolStripButton10_Click);
            // 
            // toolStripButton_ClearAll
            // 
            this.toolStripButton_ClearAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_ClearAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ClearAll.Image")));
            this.toolStripButton_ClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ClearAll.Name = "toolStripButton_ClearAll";
            this.toolStripButton_ClearAll.Size = new System.Drawing.Size(84, 27);
            this.toolStripButton_ClearAll.Text = "Очистить все";
            this.toolStripButton_ClearAll.Click += new System.EventHandler(this.toolStripButton11_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripButton_Scale
            // 
            this.toolStripButton_Scale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Scale.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Scale.Image")));
            this.toolStripButton_Scale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Scale.Name = "toolStripButton_Scale";
            this.toolStripButton_Scale.Size = new System.Drawing.Size(78, 27);
            this.toolStripButton_Scale.Text = "Приблизить";
            // 
            // toolStripComboBox_ScaleSize
            // 
            this.toolStripComboBox_ScaleSize.Name = "toolStripComboBox_ScaleSize";
            this.toolStripComboBox_ScaleSize.Size = new System.Drawing.Size(121, 30);
            this.toolStripComboBox_ScaleSize.Text = "1:1";
            // 
            // toolStripButton34
            // 
            this.toolStripButton34.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton34.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton34.Image")));
            this.toolStripButton34.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton34.Name = "toolStripButton34";
            this.toolStripButton34.Size = new System.Drawing.Size(62, 27);
            this.toolStripButton34.Text = "Сдвинуть";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.baseTableLayoutPanel.SetColumnSpan(this.MainMenu, 3);
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_File,
            this.правкаToolStripMenuItem,
            this.видToolStripMenuItem,
            this.инструментыToolStripMenuItem,
            this.сервисToolStripMenuItem,
            this.окнаToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1192, 25);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            // 
            // toolStripMenuItem_File
            // 
            this.toolStripMenuItem_File.Name = "toolStripMenuItem_File";
            this.toolStripMenuItem_File.Size = new System.Drawing.Size(48, 21);
            this.toolStripMenuItem_File.Text = "Файл";
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // инструментыToolStripMenuItem
            // 
            this.инструментыToolStripMenuItem.Name = "инструментыToolStripMenuItem";
            this.инструментыToolStripMenuItem.Size = new System.Drawing.Size(95, 21);
            this.инструментыToolStripMenuItem.Text = "Инструменты";
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.сервисToolStripMenuItem.Text = "Сервис";
            // 
            // окнаToolStripMenuItem
            // 
            this.окнаToolStripMenuItem.Name = "окнаToolStripMenuItem";
            this.окнаToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.окнаToolStripMenuItem.Text = "Окна";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 21);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.BackColor = System.Drawing.Color.Azure;
            this.baseTableLayoutPanel.SetColumnSpan(this.MainPictureBox, 2);
            this.MainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPictureBox.Location = new System.Drawing.Point(35, 58);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(1154, 483);
            this.MainPictureBox.TabIndex = 6;
            this.MainPictureBox.TabStop = false;
            this.MainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.MainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(34, 19);
            this.toolStripButton1.Text = "Ген";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1192, 596);
            this.Controls.Add(this.baseTableLayoutPanel);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "AOC \"AvtoGraf\"";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.baseTableLayoutPanel.ResumeLayout(false);
            this.baseTableLayoutPanel.PerformLayout();
            this.workspaceOperationsStatusStrip1.ResumeLayout(false);
            this.workspaceOperationsStatusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.graphicsToolBarStrip.ResumeLayout(false);
            this.graphicsToolBarStrip.PerformLayout();
            this.basicToolBarStrip.ResumeLayout(false);
            this.basicToolBarStrip.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel baseTableLayoutPanel;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инструментыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem окнаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStrip basicToolBarStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton toolStripButton_DeleteSelected;
        private System.Windows.Forms.ToolStripButton toolStripButton_ClearAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Scale;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_ScaleSize;
        private System.Windows.Forms.ToolStripButton toolStripButton34;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStrip graphicsToolBarStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton_Point2D;
        private System.Windows.Forms.ToolStripButton toolStripButton_Point3D;
        private System.Windows.Forms.ToolStripButton toolStripButton_PointProjectionPi1;
        private System.Windows.Forms.ToolStripButton toolStripButton_PointProjectionPi2;
        private System.Windows.Forms.ToolStripButton toolStripButton_PointProjectionPi3;
        private System.Windows.Forms.ToolStripButton toolStripButton_Line2D;
        private System.Windows.Forms.ToolStripButton toolStripButton_Line3D;
        private System.Windows.Forms.ToolStripButton toolStripButton_LineProjectionPi1;
        private System.Windows.Forms.ToolStripButton toolStripButton_LineProjectionPi2;
        private System.Windows.Forms.ToolStripButton toolStripButton_LineProjectionPi3;
        private System.Windows.Forms.StatusStrip workspaceOperationsStatusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1_X_Value;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1_Y_Value;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1_Z_Value;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ZeroLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4_StatusGrid;
        protected System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5_SatusAxis;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6_StatusLinkLine;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7_CursorToGridFixation;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ExternalEntitiy;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Help;
        public System.Windows.Forms.PictureBox MainPictureBox;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

