namespace DistanceStudy.Forms.Teacher
{
    partial class FormCreateAlgorithm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateAlgorithm));
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.checkedListBoxProectionsControls = new System.Windows.Forms.CheckedListBox();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.listBoxInitialParams = new System.Windows.Forms.ListBox();
            this.textBoxDesc = new System.Windows.Forms.TextBox();
            this.listBoxUserParams = new System.Windows.Forms.ListBox();
            this.labelTeacherParams = new System.Windows.Forms.Label();
            this.labelUserParams = new System.Windows.Forms.Label();
            this.labelDesc = new System.Windows.Forms.Label();
            this.groupBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(10, 442);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(90, 23);
            this.buttonAccept.TabIndex = 9;
            this.buttonAccept.Text = "Подтвердить";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(187, 442);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(106, 442);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 23);
            this.button_Clear.TabIndex = 18;
            this.button_Clear.Text = "Очистить";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // checkedListBoxProectionsControls
            // 
            this.checkedListBoxProectionsControls.FormattingEnabled = true;
            this.checkedListBoxProectionsControls.Location = new System.Drawing.Point(12, 12);
            this.checkedListBoxProectionsControls.Name = "checkedListBoxProectionsControls";
            this.checkedListBoxProectionsControls.Size = new System.Drawing.Size(250, 409);
            this.checkedListBoxProectionsControls.TabIndex = 19;
            this.checkedListBoxProectionsControls.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxProectionsControls_SelectedIndexChanged);
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.listBoxInitialParams);
            this.groupBoxInfo.Controls.Add(this.textBoxDesc);
            this.groupBoxInfo.Controls.Add(this.listBoxUserParams);
            this.groupBoxInfo.Controls.Add(this.labelTeacherParams);
            this.groupBoxInfo.Controls.Add(this.labelUserParams);
            this.groupBoxInfo.Controls.Add(this.labelDesc);
            this.groupBoxInfo.Location = new System.Drawing.Point(269, 13);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(239, 408);
            this.groupBoxInfo.TabIndex = 20;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Информация об алгоритме";
            // 
            // listBoxInitialParams
            // 
            this.listBoxInitialParams.FormattingEnabled = true;
            this.listBoxInitialParams.Location = new System.Drawing.Point(9, 206);
            this.listBoxInitialParams.Name = "listBoxInitialParams";
            this.listBoxInitialParams.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxInitialParams.Size = new System.Drawing.Size(224, 82);
            this.listBoxInitialParams.TabIndex = 5;
            // 
            // textBoxDesc
            // 
            this.textBoxDesc.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxDesc.Location = new System.Drawing.Point(7, 33);
            this.textBoxDesc.Multiline = true;
            this.textBoxDesc.Name = "textBoxDesc";
            this.textBoxDesc.ReadOnly = true;
            this.textBoxDesc.Size = new System.Drawing.Size(223, 53);
            this.textBoxDesc.TabIndex = 4;
            // 
            // listBoxUserParams
            // 
            this.listBoxUserParams.FormattingEnabled = true;
            this.listBoxUserParams.Location = new System.Drawing.Point(9, 105);
            this.listBoxUserParams.Name = "listBoxUserParams";
            this.listBoxUserParams.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxUserParams.Size = new System.Drawing.Size(224, 82);
            this.listBoxUserParams.TabIndex = 3;
            // 
            // labelTeacherParams
            // 
            this.labelTeacherParams.AutoSize = true;
            this.labelTeacherParams.Location = new System.Drawing.Point(6, 190);
            this.labelTeacherParams.Name = "labelTeacherParams";
            this.labelTeacherParams.Size = new System.Drawing.Size(147, 13);
            this.labelTeacherParams.TabIndex = 2;
            this.labelTeacherParams.Text = "Параметры инициализации";
            // 
            // labelUserParams
            // 
            this.labelUserParams.AutoSize = true;
            this.labelUserParams.Location = new System.Drawing.Point(6, 89);
            this.labelUserParams.Name = "labelUserParams";
            this.labelUserParams.Size = new System.Drawing.Size(154, 13);
            this.labelUserParams.TabIndex = 1;
            this.labelUserParams.Text = "Параметры от пользователя";
            // 
            // labelDesc
            // 
            this.labelDesc.AutoSize = true;
            this.labelDesc.Location = new System.Drawing.Point(6, 16);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(57, 13);
            this.labelDesc.TabIndex = 0;
            this.labelDesc.Text = "Описание";
            // 
            // FormCreateAlgorithm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 477);
            this.Controls.Add(this.groupBoxInfo);
            this.Controls.Add(this.checkedListBoxProectionsControls);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormCreateAlgorithm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание алгоритма";
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.CheckedListBox checkedListBoxProectionsControls;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Label labelTeacherParams;
        private System.Windows.Forms.Label labelUserParams;
        private System.Windows.Forms.Label labelDesc;
        private System.Windows.Forms.TextBox textBoxDesc;
        private System.Windows.Forms.ListBox listBoxUserParams;
        private System.Windows.Forms.ListBox listBoxInitialParams;
    }
}