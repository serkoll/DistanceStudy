using System;
using System.Drawing;
using System.Windows.Forms;
using BaseLibrary.Classes;
using DistanceStudy.Properties;

namespace DistanceStudy.Forms.Teacher
{
    public partial class FormEnterNew : Form
    {
        private readonly WorkTree _wt;
        /// <summary>
        /// Инициализация компонентов формы и задание начальным
        /// текстам подсказок серого цвета
        /// </summary>
        public FormEnterNew(TreeView tree)
        {
            _wt = new WorkTree(tree);
            InitializeComponent();
            textBox_head.ForeColor = Color.Gray;
            textBox_head.Text = "s";
            textBox_description.ForeColor = Color.Gray;
            textBox_description.Text = "s";
            MinimumSize = new Size(600, 500);
            buttonOK.Enabled = false;
        }
        /// <summary>
        /// Инициализация конструктора для редактирования темы/подтемы
        /// </summary>
        public FormEnterNew(TreeView tree, dynamic thema)
        {
            _wt = new WorkTree(tree);
            InitializeComponent();
            textBox_head.ForeColor = Color.Black;
            textBox_head.Text = thema.Name;
            textBox_description.ForeColor = Color.Black;
            textBox_description.Text = thema.Description;
            MinimumSize = new Size(600, 500);
            buttonOK.Enabled = false;
        }
        /// <summary>
        /// Подтверждение ввода названия темы\подтемы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            _wt.CreateThemaSubthemaByForm(textBox_head.Text, textBox_description.Text);
            _wt.UpdateTree();
            Dispose();
        }

        #region Обработка событий попадания курсора на текстовые поля. Появление и исчезновение текста подсказок.

        private void textBox_head_Enter(object sender, EventArgs e)
        {
            EnterTextBox(textBox_head, Resources.EnterName);
        }

        private void textBox_head_Leave(object sender, EventArgs e)
        {
            LeaveTextBox(textBox_head, Resources.EnterName);
        }

        private void textBox_description_Enter(object sender, EventArgs e)
        {
            EnterTextBox(textBox_description, Resources.EnterDescription);
        }

        private void textBox_description_Leave(object sender, EventArgs e)
        {
            LeaveTextBox(textBox_description, Resources.EnterDescription);
        }

        private void LeaveTextBox(TextBox txtBox, string text)
        {
            if (txtBox.Text == string.Empty)
            {
                txtBox.ForeColor = Color.Gray;
                txtBox.Text = text;
            }
        }

        private void EnterTextBox(TextBox txtBox, string text)
        {
            if (txtBox.Text == text)
            {
                txtBox.Text = string.Empty;
                txtBox.ForeColor = Color.Black;
            }
        }
        #endregion

        /// <summary>
        /// Отмена введения названия и описания темы\подтемы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        /// <summary>
        /// Событие проверки на пустой текстбокс с названием
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_head_TextChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = textBox_head.Text != string.Empty && textBox_head.Text != Resources.EnterName;
        }
    }
}
