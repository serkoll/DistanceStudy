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
            this.buttonAddAlgorithm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
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
            this.splitContainerTextBoxes.Size = new System.Drawing.Size(486, 327);
            this.splitContainerTextBoxes.SplitterDistance = 73;
            this.splitContainerTextBoxes.TabIndex = 0;
            // 
            // textBoxName
            // 
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxName.Location = new System.Drawing.Point(0, 0);
            this.textBoxName.Multiline = true;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(484, 71);
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
            this.textBoxDescription.Size = new System.Drawing.Size(484, 248);
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
            this.splitContainerText_Image.Size = new System.Drawing.Size(915, 331);
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
            this.pictureBoxImageTask.Size = new System.Drawing.Size(415, 297);
            this.pictureBoxImageTask.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImageTask.TabIndex = 0;
            this.pictureBoxImageTask.TabStop = false;
            // 
            // panelForTextBox
            // 
            this.panelForTextBox.Controls.Add(this.buttonOpenFile);
            this.panelForTextBox.Controls.Add(this.textBoxFilePath);
            this.panelForTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelForTextBox.Location = new System.Drawing.Point(0, 297);
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
            // buttonAddAlgorithm
            // 
            this.buttonAddAlgorithm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddAlgorithm.Location = new System.Drawing.Point(3, 36);
            this.buttonAddAlgorithm.Name = "buttonAddAlgorithm";
            this.buttonAddAlgorithm.Size = new System.Drawing.Size(134, 27);
            this.buttonAddAlgorithm.TabIndex = 4;
            this.buttonAddAlgorithm.Text = "Добавить алгоритм";
            this.buttonAddAlgorithm.UseVisualStyleBackColor = true;
            this.buttonAddAlgorithm.Click += new System.EventHandler(this.buttonAddAlgorithm_Click);
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
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelButtons.Controls.Add(this.buttonSave);
            this.panelButtons.Controls.Add(this.buttonAddAlgorithm);
            this.panelButtons.Controls.Add(this.buttonCancel);
            this.panelButtons.Location = new System.Drawing.Point(5, 365);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(146, 167);
            this.panelButtons.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.Location = new System.Drawing.Point(3, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(134, 27);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonAccept_Click);
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
            // 
            // toolStripAddGraphicCondition
            // 
            this.toolStripAddGraphicCondition.Enabled = false;
            this.toolStripAddGraphicCondition.Name = "toolStripAddGraphicCondition";
            this.toolStripAddGraphicCondition.Size = new System.Drawing.Size(165, 22);
            this.toolStripAddGraphicCondition.Text = "Графическое представление";
            this.toolStripAddGraphicCondition.Click += new System.EventHandler(this.toolStripAddGraphicCondition_Click);
            // 
            // FormCreateTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 544);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.toolStripPanel);
            this.Controls.Add(this.splitContainerText_Image);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCreateTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание задачи";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCreateTask_FormClosing);
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
        private System.Windows.Forms.Button buttonAddAlgorithm;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStrip toolStripPanel;
        private System.Windows.Forms.Panel panelForTextBox;
        public System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelHereGraphic;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddParams;
        private System.Windows.Forms.ToolStripLabel toolStripAddGraphicCondition;
        private System.Windows.Forms.Button buttonSave;
    }
}