﻿using System.Drawing;
using System.Windows.Forms;

namespace GraphicsModule.Controls
{
    partial class GraphicsControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphicsControl));
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.baseTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.WorkspaceOperations = new System.Windows.Forms.StatusStrip();
            this.labelValueX = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelValueY = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelValueZ = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_ZeroLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelStatusGrid = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelSatusAxis = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelStatusLinkLine = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelCursorToGridFixation = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelExternalEntitiy = new System.Windows.Forms.ToolStripStatusLabel();
            this.ObjectsPropertyMenu = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Help = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonNameMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.buttonNameMenuTopLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonNameMenuTopRight = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonNameMenuBottomLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonNameMenuBottomRight = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonPlaneTypeMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.buttonPlaneType3Points = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonPlaneTypeLinePoint = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonPlaneTypeParallelLine = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonPlaneTypeCrossedLine = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonPlaneTypeSegmentPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonPlaneTypeParallelSegment = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonPlaneTypeCrossedSegment = new System.Windows.Forms.ToolStripMenuItem();
            this.ObjectsBuildMenu = new System.Windows.Forms.ToolStrip();
            this.buttonPointsMenu = new System.Windows.Forms.ToolStripButton();
            this.buttonLinesMenu = new System.Windows.Forms.ToolStripButton();
            this.buttonSegmentMenu = new System.Windows.Forms.ToolStripButton();
            this.buttonPlanesMenu = new System.Windows.Forms.ToolStripButton();
            this.BaseOperationsMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.buttonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.buttonSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonErase = new System.Windows.Forms.ToolStripButton();
            this.buttonDeleteSelected = new System.Windows.Forms.ToolStripButton();
            this.buttonClearAll = new System.Windows.Forms.ToolStripButton();
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
            this.buttonSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.окнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solidWorksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.доступностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baseTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.WorkspaceOperations.SuspendLayout();
            this.ObjectsPropertyMenu.SuspendLayout();
            this.ObjectsBuildMenu.SuspendLayout();
            this.BaseOperationsMenu.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 6);
            // 
            // baseTableLayoutPanel
            // 
            this.baseTableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.baseTableLayoutPanel.ColumnCount = 3;
            this.baseTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.baseTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.baseTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.baseTableLayoutPanel.Controls.Add(this.MainPictureBox, 1, 2);
            this.baseTableLayoutPanel.Controls.Add(this.WorkspaceOperations, 0, 4);
            this.baseTableLayoutPanel.Controls.Add(this.ObjectsPropertyMenu, 1, 3);
            this.baseTableLayoutPanel.Controls.Add(this.ObjectsBuildMenu, 0, 2);
            this.baseTableLayoutPanel.Controls.Add(this.BaseOperationsMenu, 0, 1);
            this.baseTableLayoutPanel.Controls.Add(this.MainMenu, 0, 0);
            this.baseTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.baseTableLayoutPanel.Name = "baseTableLayoutPanel";
            this.baseTableLayoutPanel.RowCount = 5;
            this.baseTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.baseTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.baseTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.baseTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.baseTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.baseTableLayoutPanel.Size = new System.Drawing.Size(1239, 593);
            this.baseTableLayoutPanel.TabIndex = 7;
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.BackColor = System.Drawing.Color.Azure;
            this.baseTableLayoutPanel.SetColumnSpan(this.MainPictureBox, 2);
            this.MainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPictureBox.Location = new System.Drawing.Point(39, 58);
            this.MainPictureBox.Name = "MainPictureBox";
            this.baseTableLayoutPanel.SetRowSpan(this.MainPictureBox, 2);
            this.MainPictureBox.Size = new System.Drawing.Size(1197, 507);
            this.MainPictureBox.TabIndex = 14;
            this.MainPictureBox.TabStop = false;
            this.MainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseDown);
            // 
            // WorkspaceOperations
            // 
            this.WorkspaceOperations.BackColor = System.Drawing.SystemColors.Control;
            this.baseTableLayoutPanel.SetColumnSpan(this.WorkspaceOperations, 3);
            this.WorkspaceOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkspaceOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelValueX,
            this.labelValueY,
            this.labelValueZ,
            this.toolStripStatusLabel_ZeroLabel,
            this.labelStatusGrid,
            this.labelSatusAxis,
            this.labelStatusLinkLine,
            this.labelCursorToGridFixation,
            this.labelExternalEntitiy});
            this.WorkspaceOperations.Location = new System.Drawing.Point(0, 568);
            this.WorkspaceOperations.Name = "WorkspaceOperations";
            this.WorkspaceOperations.Size = new System.Drawing.Size(1239, 25);
            this.WorkspaceOperations.SizingGrip = false;
            this.WorkspaceOperations.TabIndex = 11;
            this.WorkspaceOperations.Text = "statusStrip1";
            // 
            // labelValueX
            // 
            this.labelValueX.Enabled = false;
            this.labelValueX.Name = "labelValueX";
            this.labelValueX.Size = new System.Drawing.Size(22, 20);
            this.labelValueX.Text = "X=";
            // 
            // labelValueY
            // 
            this.labelValueY.Name = "labelValueY";
            this.labelValueY.Size = new System.Drawing.Size(22, 20);
            this.labelValueY.Text = "Y=";
            // 
            // labelValueZ
            // 
            this.labelValueZ.Name = "labelValueZ";
            this.labelValueZ.Size = new System.Drawing.Size(22, 20);
            this.labelValueZ.Text = "Z=";
            // 
            // toolStripStatusLabel_ZeroLabel
            // 
            this.toolStripStatusLabel_ZeroLabel.Name = "toolStripStatusLabel_ZeroLabel";
            this.toolStripStatusLabel_ZeroLabel.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel_ZeroLabel.Text = "  ";
            // 
            // labelStatusGrid
            // 
            this.labelStatusGrid.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.labelStatusGrid.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.labelStatusGrid.Name = "labelStatusGrid";
            this.labelStatusGrid.Size = new System.Drawing.Size(42, 20);
            this.labelStatusGrid.Text = "Сетка";
            this.labelStatusGrid.Click += new System.EventHandler(this.labelStatusGrid_Click);
            // 
            // labelSatusAxis
            // 
            this.labelSatusAxis.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.labelSatusAxis.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.labelSatusAxis.Name = "labelSatusAxis";
            this.labelSatusAxis.Size = new System.Drawing.Size(33, 20);
            this.labelSatusAxis.Text = "Оси";
            this.labelSatusAxis.Click += new System.EventHandler(this.labelSatusAxis_Click);
            // 
            // labelStatusLinkLine
            // 
            this.labelStatusLinkLine.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.labelStatusLinkLine.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.labelStatusLinkLine.Name = "labelStatusLinkLine";
            this.labelStatusLinkLine.Size = new System.Drawing.Size(80, 20);
            this.labelStatusLinkLine.Text = "Линии связи";
            this.labelStatusLinkLine.Click += new System.EventHandler(this.labelStatusLinkLine_Click);
            // 
            // labelCursorToGridFixation
            // 
            this.labelCursorToGridFixation.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.labelCursorToGridFixation.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.labelCursorToGridFixation.Name = "labelCursorToGridFixation";
            this.labelCursorToGridFixation.Size = new System.Drawing.Size(104, 20);
            this.labelCursorToGridFixation.Text = "Привязка к сетке";
            this.labelCursorToGridFixation.Click += new System.EventHandler(this.labelCursorToGridFixation_Click);
            // 
            // labelExternalEntitiy
            // 
            this.labelExternalEntitiy.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.labelExternalEntitiy.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.labelExternalEntitiy.Name = "labelExternalEntitiy";
            this.labelExternalEntitiy.Size = new System.Drawing.Size(104, 20);
            this.labelExternalEntitiy.Text = "Внешний объект";
            // 
            // ObjectsPropertyMenu
            // 
            this.ObjectsPropertyMenu.BackColor = System.Drawing.SystemColors.Control;
            this.baseTableLayoutPanel.SetColumnSpan(this.ObjectsPropertyMenu, 2);
            this.ObjectsPropertyMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjectsPropertyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Help,
            this.buttonNameMenu,
            this.buttonPlaneTypeMenu});
            this.ObjectsPropertyMenu.Location = new System.Drawing.Point(36, 541);
            this.ObjectsPropertyMenu.Name = "ObjectsPropertyMenu";
            this.ObjectsPropertyMenu.Size = new System.Drawing.Size(1203, 27);
            this.ObjectsPropertyMenu.SizingGrip = false;
            this.ObjectsPropertyMenu.TabIndex = 10;
            this.ObjectsPropertyMenu.Text = "statusStrip2";
            this.ObjectsPropertyMenu.Visible = false;
            // 
            // toolStripStatusLabel_Help
            // 
            this.toolStripStatusLabel_Help.Name = "toolStripStatusLabel_Help";
            this.toolStripStatusLabel_Help.Size = new System.Drawing.Size(64, 22);
            this.toolStripStatusLabel_Help.Text = "Подсказка";
            // 
            // buttonNameMenu
            // 
            this.buttonNameMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonNameMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonNameMenuTopLeft,
            this.buttonNameMenuTopRight,
            this.buttonNameMenuBottomLeft,
            this.buttonNameMenuBottomRight});
            this.buttonNameMenu.Image = ((System.Drawing.Image)(resources.GetObject("buttonNameMenu.Image")));
            this.buttonNameMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonNameMenu.Name = "buttonNameMenu";
            this.buttonNameMenu.Size = new System.Drawing.Size(104, 25);
            this.buttonNameMenu.Text = "Левый верхний";
            this.buttonNameMenu.ToolTipText = "buttonNamePosition";
            // 
            // buttonNameMenuTopLeft
            // 
            this.buttonNameMenuTopLeft.Name = "buttonNameMenuTopLeft";
            this.buttonNameMenuTopLeft.Size = new System.Drawing.Size(166, 22);
            this.buttonNameMenuTopLeft.Text = "Левый верхний";
            this.buttonNameMenuTopLeft.Click += new System.EventHandler(this.buttonNameMenuTopLeftMenuItem_Click);
            // 
            // buttonNameMenuTopRight
            // 
            this.buttonNameMenuTopRight.Name = "buttonNameMenuTopRight";
            this.buttonNameMenuTopRight.Size = new System.Drawing.Size(166, 22);
            this.buttonNameMenuTopRight.Text = "Правый верхний";
            this.buttonNameMenuTopRight.Click += new System.EventHandler(this.buttonNameMenuTopRightMenuItem_Click);
            // 
            // buttonNameMenuBottomLeft
            // 
            this.buttonNameMenuBottomLeft.Name = "buttonNameMenuBottomLeft";
            this.buttonNameMenuBottomLeft.Size = new System.Drawing.Size(166, 22);
            this.buttonNameMenuBottomLeft.Text = "Левый нижний";
            this.buttonNameMenuBottomLeft.Click += new System.EventHandler(this.buttonNameMenuBottomLeftMenuItem_Click);
            // 
            // buttonNameMenuBottomRight
            // 
            this.buttonNameMenuBottomRight.Name = "buttonNameMenuBottomRight";
            this.buttonNameMenuBottomRight.Size = new System.Drawing.Size(166, 22);
            this.buttonNameMenuBottomRight.Text = "Правый нижний";
            this.buttonNameMenuBottomRight.Click += new System.EventHandler(this.buttonNameMenuBottomRightMenuItem_Click);
            // 
            // buttonPlaneTypeMenu
            // 
            this.buttonPlaneTypeMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonPlaneTypeMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonPlaneType3Points,
            this.buttonPlaneTypeLinePoint,
            this.buttonPlaneTypeParallelLine,
            this.buttonPlaneTypeCrossedLine,
            this.buttonPlaneTypeSegmentPoint,
            this.buttonPlaneTypeParallelSegment,
            this.buttonPlaneTypeCrossedSegment});
            this.buttonPlaneTypeMenu.Image = ((System.Drawing.Image)(resources.GetObject("buttonPlaneTypeMenu.Image")));
            this.buttonPlaneTypeMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPlaneTypeMenu.Name = "buttonPlaneTypeMenu";
            this.buttonPlaneTypeMenu.Size = new System.Drawing.Size(76, 25);
            this.buttonPlaneTypeMenu.Text = "Три точки";
            this.buttonPlaneTypeMenu.ToolTipText = "buttonPlaneType";
            this.buttonPlaneTypeMenu.Visible = false;
            // 
            // buttonPlaneType3Points
            // 
            this.buttonPlaneType3Points.Name = "buttonPlaneType3Points";
            this.buttonPlaneType3Points.Size = new System.Drawing.Size(219, 22);
            this.buttonPlaneType3Points.Text = "Три точки";
            this.buttonPlaneType3Points.Click += new System.EventHandler(this.buttonPlaneType3Points_Click);
            // 
            // buttonPlaneTypeLinePoint
            // 
            this.buttonPlaneTypeLinePoint.Name = "buttonPlaneTypeLinePoint";
            this.buttonPlaneTypeLinePoint.Size = new System.Drawing.Size(219, 22);
            this.buttonPlaneTypeLinePoint.Text = "Прямая и точка";
            this.buttonPlaneTypeLinePoint.Click += new System.EventHandler(this.buttonPlaneTypeLinePoint_Click);
            // 
            // buttonPlaneTypeParallelLine
            // 
            this.buttonPlaneTypeParallelLine.Name = "buttonPlaneTypeParallelLine";
            this.buttonPlaneTypeParallelLine.Size = new System.Drawing.Size(219, 22);
            this.buttonPlaneTypeParallelLine.Text = "Параллельные прямые";
            this.buttonPlaneTypeParallelLine.Click += new System.EventHandler(this.buttonPlaneTypeParrLine_Click);
            // 
            // buttonPlaneTypeCrossedLine
            // 
            this.buttonPlaneTypeCrossedLine.Name = "buttonPlaneTypeCrossedLine";
            this.buttonPlaneTypeCrossedLine.Size = new System.Drawing.Size(219, 22);
            this.buttonPlaneTypeCrossedLine.Text = "Пересекающиеся прямые";
            this.buttonPlaneTypeCrossedLine.Click += new System.EventHandler(this.buttonPlaneTypeCrossedLine_Click);
            // 
            // buttonPlaneTypeSegmentPoint
            // 
            this.buttonPlaneTypeSegmentPoint.Name = "buttonPlaneTypeSegmentPoint";
            this.buttonPlaneTypeSegmentPoint.Size = new System.Drawing.Size(219, 22);
            this.buttonPlaneTypeSegmentPoint.Text = "Отрезок и точка";
            this.buttonPlaneTypeSegmentPoint.Click += new System.EventHandler(this.buttonPlaneTypeSegmentPoint_Click);
            // 
            // buttonPlaneTypeParallelSegment
            // 
            this.buttonPlaneTypeParallelSegment.Name = "buttonPlaneTypeParallelSegment";
            this.buttonPlaneTypeParallelSegment.Size = new System.Drawing.Size(219, 22);
            this.buttonPlaneTypeParallelSegment.Text = "Параллельные отрезки";
            this.buttonPlaneTypeParallelSegment.Click += new System.EventHandler(this.buttonPlaneTypeParallelSegment_Click);
            // 
            // buttonPlaneTypeCrossedSegment
            // 
            this.buttonPlaneTypeCrossedSegment.Name = "buttonPlaneTypeCrossedSegment";
            this.buttonPlaneTypeCrossedSegment.Size = new System.Drawing.Size(219, 22);
            this.buttonPlaneTypeCrossedSegment.Text = "Пересекающиеся отрезки";
            this.buttonPlaneTypeCrossedSegment.Click += new System.EventHandler(this.buttonPlaneTypeCrossedSegment_Click);
            // 
            // ObjectsBuildMenu
            // 
            this.ObjectsBuildMenu.BackColor = System.Drawing.SystemColors.Control;
            this.ObjectsBuildMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.ObjectsBuildMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ObjectsBuildMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ObjectsBuildMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonPointsMenu,
            this.buttonLinesMenu,
            this.buttonSegmentMenu,
            this.buttonPlanesMenu});
            this.ObjectsBuildMenu.Location = new System.Drawing.Point(0, 55);
            this.ObjectsBuildMenu.Name = "ObjectsBuildMenu";
            this.baseTableLayoutPanel.SetRowSpan(this.ObjectsBuildMenu, 2);
            this.ObjectsBuildMenu.Size = new System.Drawing.Size(36, 513);
            this.ObjectsBuildMenu.TabIndex = 4;
            // 
            // buttonPointsMenu
            // 
            this.buttonPointsMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPointsMenu.Image = ((System.Drawing.Image)(resources.GetObject("buttonPointsMenu.Image")));
            this.buttonPointsMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPointsMenu.Name = "buttonPointsMenu";
            this.buttonPointsMenu.Size = new System.Drawing.Size(34, 36);
            this.buttonPointsMenu.Text = "Точка";
            this.buttonPointsMenu.Click += new System.EventHandler(this.buttonPointsMenu_Click);
            // 
            // buttonLinesMenu
            // 
            this.buttonLinesMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonLinesMenu.Image = global::GraphicsModule.Properties.Resources.line;
            this.buttonLinesMenu.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonLinesMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonLinesMenu.Name = "buttonLinesMenu";
            this.buttonLinesMenu.Size = new System.Drawing.Size(34, 36);
            this.buttonLinesMenu.Text = "Прямая";
            this.buttonLinesMenu.Click += new System.EventHandler(this.lnPointsMenu_Click);
            // 
            // buttonSegmentMenu
            // 
            this.buttonSegmentMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSegmentMenu.Image = global::GraphicsModule.Properties.Resources.line3D;
            this.buttonSegmentMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSegmentMenu.Name = "buttonSegmentMenu";
            this.buttonSegmentMenu.Size = new System.Drawing.Size(34, 36);
            this.buttonSegmentMenu.Text = "Отрезок";
            this.buttonSegmentMenu.Click += new System.EventHandler(this.buttonSegmentMenu_Click);
            // 
            // buttonPlanesMenu
            // 
            this.buttonPlanesMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPlanesMenu.Image = global::GraphicsModule.Properties.Resources.dot3D;
            this.buttonPlanesMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPlanesMenu.Name = "buttonPlanesMenu";
            this.buttonPlanesMenu.Size = new System.Drawing.Size(34, 36);
            this.buttonPlanesMenu.Text = "toolStripButton1";
            this.buttonPlanesMenu.ToolTipText = "Плоскость";
            this.buttonPlanesMenu.Click += new System.EventHandler(this.buttonPlaneMenu_Click);
            // 
            // BaseOperationsMenu
            // 
            this.BaseOperationsMenu.BackColor = System.Drawing.SystemColors.Control;
            this.BaseOperationsMenu.CanOverflow = false;
            this.baseTableLayoutPanel.SetColumnSpan(this.BaseOperationsMenu, 3);
            this.BaseOperationsMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseOperationsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.BaseOperationsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.buttonCopy,
            this.toolStripButton7,
            this.buttonSelect,
            this.toolStripSeparator1,
            this.buttonErase,
            this.buttonDeleteSelected,
            this.buttonClearAll,
            this.toolStripSeparator2,
            this.toolStripButton_Scale,
            this.toolStripComboBox_ScaleSize,
            this.toolStripButton34,
            this.toolStripSeparator3});
            this.BaseOperationsMenu.Location = new System.Drawing.Point(0, 25);
            this.BaseOperationsMenu.Name = "BaseOperationsMenu";
            this.BaseOperationsMenu.Size = new System.Drawing.Size(1239, 30);
            this.BaseOperationsMenu.TabIndex = 2;
            this.BaseOperationsMenu.Text = "toolStrip1";
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
            // buttonCopy
            // 
            this.buttonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonCopy.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopy.Image")));
            this.buttonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(76, 27);
            this.buttonCopy.Text = "Копировать";
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
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
            // buttonSelect
            // 
            this.buttonSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonSelect.Image = ((System.Drawing.Image)(resources.GetObject("buttonSelect.Image")));
            this.buttonSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(58, 27);
            this.buttonSelect.Text = "Выбрать";
            this.buttonSelect.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // buttonErase
            // 
            this.buttonErase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonErase.Image = ((System.Drawing.Image)(resources.GetObject("buttonErase.Image")));
            this.buttonErase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonErase.Name = "buttonErase";
            this.buttonErase.Size = new System.Drawing.Size(54, 27);
            this.buttonErase.Text = "Стереть";
            this.buttonErase.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // buttonDeleteSelected
            // 
            this.buttonDeleteSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonDeleteSelected.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeleteSelected.Image")));
            this.buttonDeleteSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDeleteSelected.Name = "buttonDeleteSelected";
            this.buttonDeleteSelected.Size = new System.Drawing.Size(120, 27);
            this.buttonDeleteSelected.Text = "Удалить выбранное";
            this.buttonDeleteSelected.Click += new System.EventHandler(this.buttonErase_Click);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonClearAll.Image = ((System.Drawing.Image)(resources.GetObject("buttonClearAll.Image")));
            this.buttonClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(84, 27);
            this.buttonClearAll.Text = "Очистить все";
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
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
            this.buttonSettings,
            this.окнаToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.импортToolStripMenuItem,
            this.доступностьToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1239, 25);
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
            // buttonSettings
            // 
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(79, 21);
            this.buttonSettings.Text = "Настройки";
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
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
            // импортToolStripMenuItem
            // 
            this.импортToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solidWorksToolStripMenuItem});
            this.импортToolStripMenuItem.Name = "импортToolStripMenuItem";
            this.импортToolStripMenuItem.Size = new System.Drawing.Size(63, 21);
            this.импортToolStripMenuItem.Text = "Импорт";
            // 
            // solidWorksToolStripMenuItem
            // 
            this.solidWorksToolStripMenuItem.Name = "solidWorksToolStripMenuItem";
            this.solidWorksToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.solidWorksToolStripMenuItem.Text = "SolidWorks";
            this.solidWorksToolStripMenuItem.Click += new System.EventHandler(this.solidWorksToolStripMenuItem_Click);
            // 
            // доступностьToolStripMenuItem
            // 
            this.доступностьToolStripMenuItem.Name = "доступностьToolStripMenuItem";
            this.доступностьToolStripMenuItem.Size = new System.Drawing.Size(89, 21);
            this.доступностьToolStripMenuItem.Text = "Доступность";
            this.доступностьToolStripMenuItem.Click += new System.EventHandler(this.доступностьToolStripMenuItem_Click);
            // 
            // GraphicsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Controls.Add(this.baseTableLayoutPanel);
            this.DoubleBuffered = true;
            this.Name = "GraphicsControl";
            this.Size = new System.Drawing.Size(1239, 593);
            this.Load += new System.EventHandler(this.GraphicsControl_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GraphicsControl_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseMove);
            this.Resize += new System.EventHandler(this.GraphicsControl_Resize);
            this.baseTableLayoutPanel.ResumeLayout(false);
            this.baseTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            this.WorkspaceOperations.ResumeLayout(false);
            this.WorkspaceOperations.PerformLayout();
            this.ObjectsPropertyMenu.ResumeLayout(false);
            this.ObjectsPropertyMenu.PerformLayout();
            this.ObjectsBuildMenu.ResumeLayout(false);
            this.ObjectsBuildMenu.PerformLayout();
            this.BaseOperationsMenu.ResumeLayout(false);
            this.BaseOperationsMenu.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel baseTableLayoutPanel;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инструментыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonSettings;
        private System.Windows.Forms.ToolStripMenuItem окнаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStrip BaseOperationsMenu;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton buttonCopy;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton buttonSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonErase;
        private System.Windows.Forms.ToolStripButton buttonDeleteSelected;
        private System.Windows.Forms.ToolStripButton buttonClearAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Scale;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_ScaleSize;
        private System.Windows.Forms.ToolStripButton toolStripButton34;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStrip ObjectsBuildMenu;
        private System.Windows.Forms.ToolStripButton buttonLinesMenu;
        private System.Windows.Forms.StatusStrip WorkspaceOperations;
        private System.Windows.Forms.ToolStripStatusLabel labelValueX;
        private System.Windows.Forms.ToolStripStatusLabel labelValueY;
        private System.Windows.Forms.ToolStripStatusLabel labelValueZ;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ZeroLabel;
        private System.Windows.Forms.ToolStripStatusLabel labelStatusGrid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        protected System.Windows.Forms.ToolStripStatusLabel labelSatusAxis;
        private System.Windows.Forms.ToolStripStatusLabel labelStatusLinkLine;
        private System.Windows.Forms.ToolStripStatusLabel labelCursorToGridFixation;
        private System.Windows.Forms.ToolStripStatusLabel labelExternalEntitiy;
        private System.Windows.Forms.StatusStrip ObjectsPropertyMenu;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Help;
        private ToolStripButton buttonPointsMenu;
        private ToolStripButton buttonSegmentMenu;
        private ToolStripMenuItem импортToolStripMenuItem;
        private ToolStripMenuItem solidWorksToolStripMenuItem;
        private ToolStripDropDownButton buttonNameMenu;
        private ToolStripMenuItem buttonNameMenuTopLeft;
        private ToolStripMenuItem buttonNameMenuTopRight;
        private ToolStripMenuItem buttonNameMenuBottomLeft;
        private ToolStripMenuItem buttonNameMenuBottomRight;
        private ToolStripButton buttonPlanesMenu;
        private ToolStripDropDownButton buttonPlaneTypeMenu;
        private ToolStripMenuItem buttonPlaneType3Points;
        private ToolStripMenuItem buttonPlaneTypeLinePoint;
        private ToolStripMenuItem buttonPlaneTypeParallelLine;
        private ToolStripMenuItem buttonPlaneTypeCrossedLine;
        private ToolStripMenuItem buttonPlaneTypeSegmentPoint;
        private ToolStripMenuItem buttonPlaneTypeParallelSegment;
        private ToolStripMenuItem buttonPlaneTypeCrossedSegment;
        private ToolStripMenuItem доступностьToolStripMenuItem;
        public PictureBox MainPictureBox;
    }
}
