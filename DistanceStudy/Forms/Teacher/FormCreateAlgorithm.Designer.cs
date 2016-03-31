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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.checkBoxBase = new System.Windows.Forms.CheckBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.checkBoxMain = new System.Windows.Forms.CheckBox();
            this.checkBoxProizv = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAddToSelected = new System.Windows.Forms.Button();
            this.listBox6 = new System.Windows.Forms.ListBox();
            this.button_Clear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Точка",
            "Точка 2",
            "Линия 1",
            "Линия 2"});
            this.listBox1.Location = new System.Drawing.Point(1, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(180, 208);
            this.listBox1.TabIndex = 0;
            // 
            // checkBoxBase
            // 
            this.checkBoxBase.AutoSize = true;
            this.checkBoxBase.Location = new System.Drawing.Point(49, 3);
            this.checkBoxBase.Name = "checkBoxBase";
            this.checkBoxBase.Size = new System.Drawing.Size(71, 17);
            this.checkBoxBase.TabIndex = 1;
            this.checkBoxBase.Text = "Базовый";
            this.checkBoxBase.UseVisualStyleBackColor = true;
            this.checkBoxBase.CheckedChanged += new System.EventHandler(this.checkBoxBase_CheckedChanged);
            // 
            // listBox2
            // 
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Items.AddRange(new object[] {
            "Отрезок",
            "Отрезок 2",
            "Отрезок 3"});
            this.listBox2.Location = new System.Drawing.Point(181, 0);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(180, 208);
            this.listBox2.TabIndex = 2;
            // 
            // listBox3
            // 
            this.listBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Items.AddRange(new object[] {
            "Линия и отрезок",
            "Плоскость и линия",
            "Плоскость и плоскость"});
            this.listBox3.Location = new System.Drawing.Point(361, 0);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(186, 208);
            this.listBox3.TabIndex = 3;
            // 
            // checkBoxMain
            // 
            this.checkBoxMain.AutoSize = true;
            this.checkBoxMain.Location = new System.Drawing.Point(221, 4);
            this.checkBoxMain.Name = "checkBoxMain";
            this.checkBoxMain.Size = new System.Drawing.Size(76, 17);
            this.checkBoxMain.TabIndex = 4;
            this.checkBoxMain.Text = "Основной";
            this.checkBoxMain.UseVisualStyleBackColor = true;
            this.checkBoxMain.CheckedChanged += new System.EventHandler(this.checkBoxMain_CheckedChanged);
            // 
            // checkBoxProizv
            // 
            this.checkBoxProizv.AutoSize = true;
            this.checkBoxProizv.Location = new System.Drawing.Point(389, 4);
            this.checkBoxProizv.Name = "checkBoxProizv";
            this.checkBoxProizv.Size = new System.Drawing.Size(96, 17);
            this.checkBoxProizv.TabIndex = 5;
            this.checkBoxProizv.Text = "Производный";
            this.checkBoxProizv.UseVisualStyleBackColor = true;
            this.checkBoxProizv.CheckedChanged += new System.EventHandler(this.checkBoxProizv_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 442);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Подтвердить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(544, 442);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "Отмена";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.Location = new System.Drawing.Point(0, 325);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(178, 95);
            this.listBox4.TabIndex = 12;
            // 
            // listBox5
            // 
            this.listBox5.FormattingEnabled = true;
            this.listBox5.Location = new System.Drawing.Point(184, 325);
            this.listBox5.Name = "listBox5";
            this.listBox5.Size = new System.Drawing.Size(177, 95);
            this.listBox5.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.listBox2);
            this.panel1.Controls.Add(this.listBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 208);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBoxMain);
            this.panel2.Controls.Add(this.checkBoxProizv);
            this.panel2.Controls.Add(this.checkBoxBase);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(547, 24);
            this.panel2.TabIndex = 15;
            // 
            // buttonAddToSelected
            // 
            this.buttonAddToSelected.Location = new System.Drawing.Point(3, 238);
            this.buttonAddToSelected.Name = "buttonAddToSelected";
            this.buttonAddToSelected.Size = new System.Drawing.Size(75, 23);
            this.buttonAddToSelected.TabIndex = 16;
            this.buttonAddToSelected.Text = "Добавить";
            this.buttonAddToSelected.UseVisualStyleBackColor = true;
            this.buttonAddToSelected.Click += new System.EventHandler(this.buttonAddToSelected_Click);
            // 
            // listBox6
            // 
            this.listBox6.FormattingEnabled = true;
            this.listBox6.Location = new System.Drawing.Point(369, 325);
            this.listBox6.Name = "listBox6";
            this.listBox6.Size = new System.Drawing.Size(178, 95);
            this.listBox6.TabIndex = 17;
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(96, 442);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 23);
            this.button_Clear.TabIndex = 18;
            this.button_Clear.Text = "Очистить";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // FormCreateAlgorithm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 477);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.listBox6);
            this.Controls.Add(this.buttonAddToSelected);
            this.Controls.Add(this.listBox5);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCreateAlgorithm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание алгоритма";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox checkBoxBase;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.CheckBox checkBoxMain;
        private System.Windows.Forms.CheckBox checkBoxProizv;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.ListBox listBox5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonAddToSelected;
        private System.Windows.Forms.ListBox listBox6;
        private System.Windows.Forms.Button button_Clear;
    }
}