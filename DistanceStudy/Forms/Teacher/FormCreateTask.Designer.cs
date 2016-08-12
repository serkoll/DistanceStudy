namespace DistanceStudy.Forms.Teacher
{
    partial class FormCreateTask
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Фактическая", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Плановая", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateTask));
            this.splitContainerTextBoxes = new System.Windows.Forms.SplitContainer();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.splitContainerText_Image = new System.Windows.Forms.SplitContainer();
            this.labelHereGraphic = new System.Windows.Forms.Label();
            this.pictureBoxImageTask = new System.Windows.Forms.PictureBox();
            this.panelForTextBox = new System.Windows.Forms.Panel();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.tabControlTaskSettings = new System.Windows.Forms.TabControl();
            this.tabPageDefault = new System.Windows.Forms.TabPage();
            this.dataGridViewDefault = new System.Windows.Forms.DataGridView();
            this.ColumnField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelParametrsHasNot = new System.Windows.Forms.Label();
            this.tabPageStatus = new System.Windows.Forms.TabPage();
            this.radioButtonDerivative = new System.Windows.Forms.RadioButton();
            this.radioButtonMain = new System.Windows.Forms.RadioButton();
            this.radioButtonBase = new System.Windows.Forms.RadioButton();
            this.tabPageDifficult = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeaderFact = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPlane = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageTime = new System.Windows.Forms.TabPage();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelHour = new System.Windows.Forms.Label();
            this.labelTimePlane = new System.Windows.Forms.Label();
            this.textBoxTimePlaneMin = new System.Windows.Forms.TextBox();
            this.textBoxTimePlaneHour = new System.Windows.Forms.TextBox();
            this.textBoxtimeFactMin = new System.Windows.Forms.TextBox();
            this.textBoxtimeFactHour = new System.Windows.Forms.TextBox();
            this.labelTimeFact = new System.Windows.Forms.Label();
            this.labelParams = new System.Windows.Forms.Label();
            this.buttonAcceptTask = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripPanel = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddParams = new System.Windows.Forms.ToolStripButton();
            this.toolStripAddGraphicCondition = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTextBoxes)).BeginInit();
            this.splitContainerTextBoxes.Panel1.SuspendLayout();
            this.splitContainerTextBoxes.Panel2.SuspendLayout();
            this.splitContainerTextBoxes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerText_Image)).BeginInit();
            this.splitContainerText_Image.Panel1.SuspendLayout();
            this.splitContainerText_Image.Panel2.SuspendLayout();
            this.splitContainerText_Image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageTask)).BeginInit();
            this.panelForTextBox.SuspendLayout();
            this.tabControlTaskSettings.SuspendLayout();
            this.tabPageDefault.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDefault)).BeginInit();
            this.tabPageStatus.SuspendLayout();
            this.tabPageDifficult.SuspendLayout();
            this.tabPageTime.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.toolStripPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerTextBoxes
            // 
            this.splitContainerTextBoxes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerTextBoxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerTextBoxes.Location = new System.Drawing.Point(3, 3);
            this.splitContainerTextBoxes.Name = "splitContainerTextBoxes";
            this.splitContainerTextBoxes.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTextBoxes.Panel1
            // 
            this.splitContainerTextBoxes.Panel1.Controls.Add(this.textBoxName);
            // 
            // splitContainerTextBoxes.Panel2
            // 
            this.splitContainerTextBoxes.Panel2.Controls.Add(this.textBoxDescription);
            this.splitContainerTextBoxes.Size = new System.Drawing.Size(486, 339);
            this.splitContainerTextBoxes.SplitterDistance = 76;
            this.splitContainerTextBoxes.TabIndex = 0;
            // 
            // textBoxName
            // 
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxName.Location = new System.Drawing.Point(0, 0);
            this.textBoxName.Multiline = true;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(484, 74);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            this.textBoxName.Enter += new System.EventHandler(this.textBoxName_Enter);
            this.textBoxName.Leave += new System.EventHandler(this.textBoxName_Leave);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(0, 0);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(484, 257);
            this.textBoxDescription.TabIndex = 0;
            this.textBoxDescription.Enter += new System.EventHandler(this.textBoxDescription_Enter);
            this.textBoxDescription.Leave += new System.EventHandler(this.textBoxDescription_Leave);
            // 
            // splitContainerText_Image
            // 
            this.splitContainerText_Image.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerText_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerText_Image.Location = new System.Drawing.Point(0, 28);
            this.splitContainerText_Image.Name = "splitContainerText_Image";
            // 
            // splitContainerText_Image.Panel1
            // 
            this.splitContainerText_Image.Panel1.Controls.Add(this.splitContainerTextBoxes);
            // 
            // splitContainerText_Image.Panel2
            // 
            this.splitContainerText_Image.Panel2.Controls.Add(this.labelHereGraphic);
            this.splitContainerText_Image.Panel2.Controls.Add(this.pictureBoxImageTask);
            this.splitContainerText_Image.Panel2.Controls.Add(this.panelForTextBox);
            this.splitContainerText_Image.Size = new System.Drawing.Size(915, 343);
            this.splitContainerText_Image.SplitterDistance = 494;
            this.splitContainerText_Image.TabIndex = 1;
            // 
            // labelHereGraphic
            // 
            this.labelHereGraphic.AutoSize = true;
            this.labelHereGraphic.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHereGraphic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHereGraphic.ForeColor = System.Drawing.Color.DimGray;
            this.labelHereGraphic.Location = new System.Drawing.Point(0, 0);
            this.labelHereGraphic.Name = "labelHereGraphic";
            this.labelHereGraphic.Size = new System.Drawing.Size(205, 17);
            this.labelHereGraphic.TabIndex = 4;
            this.labelHereGraphic.Text = "Графическое условие задачи";
            // 
            // pictureBoxImageTask
            // 
            this.pictureBoxImageTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxImageTask.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImageTask.Name = "pictureBoxImageTask";
            this.pictureBoxImageTask.Size = new System.Drawing.Size(415, 309);
            this.pictureBoxImageTask.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImageTask.TabIndex = 0;
            this.pictureBoxImageTask.TabStop = false;
            // 
            // panelForTextBox
            // 
            this.panelForTextBox.Controls.Add(this.buttonOpenFile);
            this.panelForTextBox.Controls.Add(this.textBoxFilePath);
            this.panelForTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelForTextBox.Location = new System.Drawing.Point(0, 309);
            this.panelForTextBox.Name = "panelForTextBox";
            this.panelForTextBox.Size = new System.Drawing.Size(415, 32);
            this.panelForTextBox.TabIndex = 3;
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOpenFile.Location = new System.Drawing.Point(339, 5);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(72, 24);
            this.buttonOpenFile.TabIndex = 1;
            this.buttonOpenFile.Text = "Обзор...";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilePath.Enabled = false;
            this.textBoxFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFilePath.Location = new System.Drawing.Point(3, 6);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.ReadOnly = true;
            this.textBoxFilePath.Size = new System.Drawing.Size(330, 23);
            this.textBoxFilePath.TabIndex = 2;
            this.textBoxFilePath.Text = "Локальный путь к графическому условию...";
            this.textBoxFilePath.Enter += new System.EventHandler(this.textBoxFilePath_Enter);
            this.textBoxFilePath.Leave += new System.EventHandler(this.textBoxFilePath_Leave);
            // 
            // tabControlTaskSettings
            // 
            this.tabControlTaskSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlTaskSettings.Controls.Add(this.tabPageDefault);
            this.tabControlTaskSettings.Controls.Add(this.tabPageStatus);
            this.tabControlTaskSettings.Controls.Add(this.tabPageDifficult);
            this.tabControlTaskSettings.Controls.Add(this.tabPageTime);
            this.tabControlTaskSettings.Location = new System.Drawing.Point(160, 387);
            this.tabControlTaskSettings.Name = "tabControlTaskSettings";
            this.tabControlTaskSettings.SelectedIndex = 0;
            this.tabControlTaskSettings.Size = new System.Drawing.Size(755, 168);
            this.tabControlTaskSettings.TabIndex = 2;
            // 
            // tabPageDefault
            // 
            this.tabPageDefault.Controls.Add(this.dataGridViewDefault);
            this.tabPageDefault.Controls.Add(this.labelParametrsHasNot);
            this.tabPageDefault.Location = new System.Drawing.Point(4, 22);
            this.tabPageDefault.Name = "tabPageDefault";
            this.tabPageDefault.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDefault.Size = new System.Drawing.Size(747, 142);
            this.tabPageDefault.TabIndex = 3;
            this.tabPageDefault.Text = "Исходные данные";
            this.tabPageDefault.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDefault
            // 
            this.dataGridViewDefault.AllowUserToOrderColumns = true;
            this.dataGridViewDefault.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDefault.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewDefault.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDefault.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnField,
            this.ColumnValue,
            this.ColumnDescription});
            this.dataGridViewDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDefault.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGridViewDefault.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewDefault.Name = "dataGridViewDefault";
            this.dataGridViewDefault.Size = new System.Drawing.Size(741, 136);
            this.dataGridViewDefault.TabIndex = 0;
            this.dataGridViewDefault.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridViewDefault_ColumnWidthChanged);
            // 
            // ColumnField
            // 
            this.ColumnField.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnField.Frozen = true;
            this.ColumnField.HeaderText = "Исходный параметр";
            this.ColumnField.MinimumWidth = 15;
            this.ColumnField.Name = "ColumnField";
            this.ColumnField.Width = 360;
            // 
            // ColumnValue
            // 
            this.ColumnValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnValue.Frozen = true;
            this.ColumnValue.HeaderText = "Значение";
            this.ColumnValue.Name = "ColumnValue";
            this.ColumnValue.Width = 200;
            // 
            // ColumnDescription
            // 
            this.ColumnDescription.Frozen = true;
            this.ColumnDescription.HeaderText = "Примечание";
            this.ColumnDescription.Name = "ColumnDescription";
            this.ColumnDescription.ReadOnly = true;
            this.ColumnDescription.Width = 240;
            // 
            // labelParametrsHasNot
            // 
            this.labelParametrsHasNot.AutoSize = true;
            this.labelParametrsHasNot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelParametrsHasNot.Location = new System.Drawing.Point(3, 0);
            this.labelParametrsHasNot.Name = "labelParametrsHasNot";
            this.labelParametrsHasNot.Size = new System.Drawing.Size(374, 17);
            this.labelParametrsHasNot.TabIndex = 1;
            this.labelParametrsHasNot.Text = "Для текущей задачи начальные параметры не заданы";
            // 
            // tabPageStatus
            // 
            this.tabPageStatus.Controls.Add(this.radioButtonDerivative);
            this.tabPageStatus.Controls.Add(this.radioButtonMain);
            this.tabPageStatus.Controls.Add(this.radioButtonBase);
            this.tabPageStatus.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatus.Name = "tabPageStatus";
            this.tabPageStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStatus.Size = new System.Drawing.Size(747, 142);
            this.tabPageStatus.TabIndex = 0;
            this.tabPageStatus.Text = "Статус задачи";
            this.tabPageStatus.UseVisualStyleBackColor = true;
            // 
            // radioButtonDerivative
            // 
            this.radioButtonDerivative.AutoSize = true;
            this.radioButtonDerivative.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonDerivative.Location = new System.Drawing.Point(6, 65);
            this.radioButtonDerivative.Name = "radioButtonDerivative";
            this.radioButtonDerivative.Size = new System.Drawing.Size(132, 24);
            this.radioButtonDerivative.TabIndex = 2;
            this.radioButtonDerivative.TabStop = true;
            this.radioButtonDerivative.Text = "Производный";
            this.radioButtonDerivative.UseVisualStyleBackColor = true;
            this.radioButtonDerivative.CheckedChanged += new System.EventHandler(this.radioButtonMain_CheckedChanged);
            // 
            // radioButtonMain
            // 
            this.radioButtonMain.AutoSize = true;
            this.radioButtonMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonMain.Location = new System.Drawing.Point(6, 35);
            this.radioButtonMain.Name = "radioButtonMain";
            this.radioButtonMain.Size = new System.Drawing.Size(101, 24);
            this.radioButtonMain.TabIndex = 1;
            this.radioButtonMain.TabStop = true;
            this.radioButtonMain.Text = "Основной";
            this.radioButtonMain.UseVisualStyleBackColor = true;
            this.radioButtonMain.CheckedChanged += new System.EventHandler(this.radioButtonMain_CheckedChanged);
            // 
            // radioButtonBase
            // 
            this.radioButtonBase.AutoSize = true;
            this.radioButtonBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonBase.Location = new System.Drawing.Point(6, 6);
            this.radioButtonBase.Name = "radioButtonBase";
            this.radioButtonBase.Size = new System.Drawing.Size(93, 24);
            this.radioButtonBase.TabIndex = 0;
            this.radioButtonBase.TabStop = true;
            this.radioButtonBase.Text = "Базовый";
            this.radioButtonBase.UseVisualStyleBackColor = true;
            this.radioButtonBase.CheckedChanged += new System.EventHandler(this.radioButtonMain_CheckedChanged);
            // 
            // tabPageDifficult
            // 
            this.tabPageDifficult.Controls.Add(this.comboBox2);
            this.tabPageDifficult.Controls.Add(this.comboBox1);
            this.tabPageDifficult.Controls.Add(this.listView1);
            this.tabPageDifficult.Location = new System.Drawing.Point(4, 22);
            this.tabPageDifficult.Name = "tabPageDifficult";
            this.tabPageDifficult.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDifficult.Size = new System.Drawing.Size(747, 142);
            this.tabPageDifficult.TabIndex = 1;
            this.tabPageDifficult.Text = "Сложность";
            this.tabPageDifficult.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBox2.Location = new System.Drawing.Point(134, 27);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBox1.Location = new System.Drawing.Point(7, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFact,
            this.columnHeaderPlane});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "Фактическая";
            listViewGroup1.Name = "listViewGroupFact";
            listViewGroup2.Header = "Плановая";
            listViewGroup2.Name = "listViewGroupPlane";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(741, 136);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderFact
            // 
            this.columnHeaderFact.Text = "Фактическая";
            this.columnHeaderFact.Width = 157;
            // 
            // columnHeaderPlane
            // 
            this.columnHeaderPlane.Text = "Плановая";
            this.columnHeaderPlane.Width = 128;
            // 
            // tabPageTime
            // 
            this.tabPageTime.Controls.Add(this.labelMin);
            this.tabPageTime.Controls.Add(this.labelHour);
            this.tabPageTime.Controls.Add(this.labelTimePlane);
            this.tabPageTime.Controls.Add(this.textBoxTimePlaneMin);
            this.tabPageTime.Controls.Add(this.textBoxTimePlaneHour);
            this.tabPageTime.Controls.Add(this.textBoxtimeFactMin);
            this.tabPageTime.Controls.Add(this.textBoxtimeFactHour);
            this.tabPageTime.Controls.Add(this.labelTimeFact);
            this.tabPageTime.Location = new System.Drawing.Point(4, 22);
            this.tabPageTime.Name = "tabPageTime";
            this.tabPageTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTime.Size = new System.Drawing.Size(747, 142);
            this.tabPageTime.TabIndex = 2;
            this.tabPageTime.Text = "Время";
            this.tabPageTime.UseVisualStyleBackColor = true;
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMin.Location = new System.Drawing.Point(411, 29);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(45, 24);
            this.labelMin.TabIndex = 11;
            this.labelMin.Text = "мин";
            // 
            // labelHour
            // 
            this.labelHour.AutoSize = true;
            this.labelHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHour.Location = new System.Drawing.Point(267, 29);
            this.labelHour.Name = "labelHour";
            this.labelHour.Size = new System.Drawing.Size(20, 24);
            this.labelHour.TabIndex = 8;
            this.labelHour.Text = "ч";
            // 
            // labelTimePlane
            // 
            this.labelTimePlane.AutoSize = true;
            this.labelTimePlane.Location = new System.Drawing.Point(8, 49);
            this.labelTimePlane.Name = "labelTimePlane";
            this.labelTimePlane.Size = new System.Drawing.Size(94, 13);
            this.labelTimePlane.TabIndex = 7;
            this.labelTimePlane.Text = "Время плановое:";
            // 
            // textBoxTimePlaneMin
            // 
            this.textBoxTimePlaneMin.Location = new System.Drawing.Point(305, 49);
            this.textBoxTimePlaneMin.Name = "textBoxTimePlaneMin";
            this.textBoxTimePlaneMin.Size = new System.Drawing.Size(100, 20);
            this.textBoxTimePlaneMin.TabIndex = 6;
            // 
            // textBoxTimePlaneHour
            // 
            this.textBoxTimePlaneHour.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxTimePlaneHour.Location = new System.Drawing.Point(153, 49);
            this.textBoxTimePlaneHour.MaxLength = 20;
            this.textBoxTimePlaneHour.Name = "textBoxTimePlaneHour";
            this.textBoxTimePlaneHour.Size = new System.Drawing.Size(100, 20);
            this.textBoxTimePlaneHour.TabIndex = 5;
            // 
            // textBoxtimeFactMin
            // 
            this.textBoxtimeFactMin.Enabled = false;
            this.textBoxtimeFactMin.Location = new System.Drawing.Point(305, 10);
            this.textBoxtimeFactMin.Name = "textBoxtimeFactMin";
            this.textBoxtimeFactMin.Size = new System.Drawing.Size(100, 20);
            this.textBoxtimeFactMin.TabIndex = 4;
            // 
            // textBoxtimeFactHour
            // 
            this.textBoxtimeFactHour.Enabled = false;
            this.textBoxtimeFactHour.Location = new System.Drawing.Point(153, 10);
            this.textBoxtimeFactHour.Name = "textBoxtimeFactHour";
            this.textBoxtimeFactHour.Size = new System.Drawing.Size(100, 20);
            this.textBoxtimeFactHour.TabIndex = 3;
            // 
            // labelTimeFact
            // 
            this.labelTimeFact.AutoSize = true;
            this.labelTimeFact.Location = new System.Drawing.Point(8, 13);
            this.labelTimeFact.Name = "labelTimeFact";
            this.labelTimeFact.Size = new System.Drawing.Size(112, 13);
            this.labelTimeFact.TabIndex = 2;
            this.labelTimeFact.Text = "Время фактическое:";
            // 
            // labelParams
            // 
            this.labelParams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelParams.AutoSize = true;
            this.labelParams.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelParams.Location = new System.Drawing.Point(8, 387);
            this.labelParams.Name = "labelParams";
            this.labelParams.Size = new System.Drawing.Size(150, 20);
            this.labelParams.TabIndex = 3;
            this.labelParams.Text = "Параметры задачи";
            // 
            // buttonAcceptTask
            // 
            this.buttonAcceptTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAcceptTask.Location = new System.Drawing.Point(3, 36);
            this.buttonAcceptTask.Name = "buttonAcceptTask";
            this.buttonAcceptTask.Size = new System.Drawing.Size(134, 27);
            this.buttonAcceptTask.TabIndex = 4;
            this.buttonAcceptTask.Text = "Добавить алгоритм";
            this.buttonAcceptTask.UseVisualStyleBackColor = true;
            this.buttonAcceptTask.Click += new System.EventHandler(this.buttonAcceptTask_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(3, 69);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(134, 27);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelButtons.Controls.Add(this.buttonAccept);
            this.panelButtons.Controls.Add(this.buttonAcceptTask);
            this.panelButtons.Controls.Add(this.buttonCancel);
            this.panelButtons.Location = new System.Drawing.Point(12, 456);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(146, 99);
            this.panelButtons.TabIndex = 5;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAccept.Location = new System.Drawing.Point(3, 3);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(134, 27);
            this.buttonAccept.TabIndex = 4;
            this.buttonAccept.Text = "Подтвердить";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStripPanel
            // 
            this.toolStripPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddParams,
            this.toolStripAddGraphicCondition});
            this.toolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.toolStripPanel.Name = "toolStripPanel";
            this.toolStripPanel.Size = new System.Drawing.Size(915, 25);
            this.toolStripPanel.TabIndex = 7;
            this.toolStripPanel.Text = "ToolStrip";
            // 
            // toolStripButtonAddParams
            // 
            this.toolStripButtonAddParams.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAddParams.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddParams.Image")));
            this.toolStripButtonAddParams.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddParams.Name = "toolStripButtonAddParams";
            this.toolStripButtonAddParams.Size = new System.Drawing.Size(128, 22);
            this.toolStripButtonAddParams.Text = "Добавить параметры";
            this.toolStripButtonAddParams.Click += new System.EventHandler(this.toolStripButtonAddParams_Click);
            // 
            // toolStripAddGraphicCondition
            // 
            this.toolStripAddGraphicCondition.Name = "toolStripAddGraphicCondition";
            this.toolStripAddGraphicCondition.Size = new System.Drawing.Size(165, 22);
            this.toolStripAddGraphicCondition.Text = "Графическое представление";
            this.toolStripAddGraphicCondition.Click += new System.EventHandler(this.toolStripAddGraphicCondition_Click);
            // 
            // FormCreateTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 556);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.toolStripPanel);
            this.Controls.Add(this.labelParams);
            this.Controls.Add(this.splitContainerText_Image);
            this.Controls.Add(this.tabControlTaskSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCreateTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание задачи";
            this.Resize += new System.EventHandler(this.FormCreateTask_Resize);
            this.splitContainerTextBoxes.Panel1.ResumeLayout(false);
            this.splitContainerTextBoxes.Panel1.PerformLayout();
            this.splitContainerTextBoxes.Panel2.ResumeLayout(false);
            this.splitContainerTextBoxes.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTextBoxes)).EndInit();
            this.splitContainerTextBoxes.ResumeLayout(false);
            this.splitContainerText_Image.Panel1.ResumeLayout(false);
            this.splitContainerText_Image.Panel2.ResumeLayout(false);
            this.splitContainerText_Image.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerText_Image)).EndInit();
            this.splitContainerText_Image.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageTask)).EndInit();
            this.panelForTextBox.ResumeLayout(false);
            this.panelForTextBox.PerformLayout();
            this.tabControlTaskSettings.ResumeLayout(false);
            this.tabPageDefault.ResumeLayout(false);
            this.tabPageDefault.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDefault)).EndInit();
            this.tabPageStatus.ResumeLayout(false);
            this.tabPageStatus.PerformLayout();
            this.tabPageDifficult.ResumeLayout(false);
            this.tabPageTime.ResumeLayout(false);
            this.tabPageTime.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.toolStripPanel.ResumeLayout(false);
            this.toolStripPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerTextBoxes;
        public System.Windows.Forms.TextBox textBoxName;
        public System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.SplitContainer splitContainerText_Image;
        private System.Windows.Forms.PictureBox pictureBoxImageTask;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.TabPage tabPageStatus;
        private System.Windows.Forms.TabPage tabPageDifficult;
        private System.Windows.Forms.Label labelParams;
        private System.Windows.Forms.TabControl tabControlTaskSettings;
        private System.Windows.Forms.TabPage tabPageTime;
        private System.Windows.Forms.Button buttonAcceptTask;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeaderFact;
        private System.Windows.Forms.ColumnHeader columnHeaderPlane;
        private System.Windows.Forms.Label labelTimeFact;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStrip toolStripPanel;
        private System.Windows.Forms.Label labelTimePlane;
        private System.Windows.Forms.TextBox textBoxTimePlaneMin;
        private System.Windows.Forms.TextBox textBoxTimePlaneHour;
        private System.Windows.Forms.TextBox textBoxtimeFactMin;
        private System.Windows.Forms.TextBox textBoxtimeFactHour;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Label labelHour;
        private System.Windows.Forms.Panel panelForTextBox;
        public System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelHereGraphic;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabPage tabPageDefault;
        private System.Windows.Forms.DataGridView dataGridViewDefault;
        private System.Windows.Forms.RadioButton radioButtonDerivative;
        private System.Windows.Forms.RadioButton radioButtonMain;
        private System.Windows.Forms.RadioButton radioButtonBase;
        private System.Windows.Forms.Label labelParametrsHasNot;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddParams;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnField;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
        private System.Windows.Forms.ToolStripLabel toolStripAddGraphicCondition;
        private System.Windows.Forms.Button buttonAccept;
    }
}