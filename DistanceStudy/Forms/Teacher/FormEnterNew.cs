using System;
using System.Drawing;
using System.Windows.Forms;
using DistanceStudy.Properties;
using Service.HandlerUI;

namespace DistanceStudy.Forms.Teacher
{
    public partial class FormEnterNew : Form
    {
        // Экземпляр класса для работы с деревом
        private readonly WorkTree _wt;
        // Редактируемый экземпляр
        private readonly dynamic _edited = null;
        /// <summary>
        /// Инициализация компонентов формы и задание начальным
        /// текстам подсказок серого цвета
        /// </summary>
        public FormEnterNew(WorkTree workTree)
        {
            _wt = workTree;
            InitializeComponent();
            InitControlValues(Color.Black, Color.Gray, string.Empty, string.Empty, new Size(600, 500), false);
        }

        /// <summary>
        /// Инициализация конструктора для редактирования темы/подтемы
        /// </summary>
        public FormEnterNew(WorkTree workTree, dynamic item)
        {
            _edited = item;
            _wt = workTree;
            InitializeComponent();
            InitControlValues(Color.Black, (item.Description == null) ? Color.Gray : Color.Black, _edited.Name, _edited.Description, new Size(600, 500), true);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int[] id;
            dynamic method;
            if (_edited == null)
            {
                method = _wt.GetMethodForCreateNeededObject(out id);
                method(textBoxName.Text, textBoxDescription.Text, id);
            }
            else
            {
                method = _wt.GetMethodForUpdateNeededObject(_edited, out id);
                method(textBoxName.Text, textBoxDescription.Text, id);
            }
            _wt.UpdateTree();
            Dispose();
        }

        /// <summary>
        /// Инициализация значения свойств контролов
        /// </summary>
        private void InitControlValues(Color nameColor, Color descClor, string txtBoxNameVal, string txtBoxDescVal, Size sizeForm, bool buttonEnabled)
        {
            textBoxName.ForeColor = nameColor;
            textBoxName.Text = txtBoxNameVal;
            textBoxDescription.ForeColor = descClor;
            textBoxDescription.Text = txtBoxDescVal;
            MinimumSize = sizeForm;
            buttonAccept.Enabled = buttonEnabled;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            buttonAccept.Enabled = textBoxName.Text != string.Empty && textBoxName.Text != Resources.EnterName;
        }

        #region Обработка событий попадания курсора на текстовые поля. Появление и исчезновение текста подсказок.

        private void textBox_head_Enter(object sender, EventArgs e)
        {
            EnterTextBox(textBoxName, Resources.EnterName);
        }

        private void textBox_head_Leave(object sender, EventArgs e)
        {
            LeaveTextBox(textBoxName, Resources.EnterName);
        }

        private void textBox_description_Enter(object sender, EventArgs e)
        {
            EnterTextBox(textBoxDescription, Resources.EnterDescription);
        }

        private void textBox_description_Leave(object sender, EventArgs e)
        {
            LeaveTextBox(textBoxDescription, Resources.EnterDescription);
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
