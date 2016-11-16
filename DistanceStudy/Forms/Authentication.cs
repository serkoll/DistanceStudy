using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DistanceStudy.Forms.Admin;
using DistanceStudy.Forms.Teacher;
using DistanceStudy.Properties;
using DistanceStudy.Forms.Student;
using Service.Authentication;

namespace DistanceStudy.Forms
{
    /// <summary>
    /// Форма, всплывающая при запуске приложения
    /// </summary>

    public partial class AuthenticationForm : Form
    {
        /// <summary>
        /// Инициализация форм и словаря для пользователей с определенными правами
        /// </summary>
        private readonly Dictionary<string, Form> _dictionaryForms; 
        public AuthenticationForm()
        {
            _dictionaryForms = new Dictionary<string, Form>
            {
                {"teacher", new FormMainTeacher()},
                {"user", new FormMainStudent()},
                {"admin", new FormAdminPanel()}
            };
            // Заполнение словаря значениями для соответствующих пользователей
            InitializeComponent();
        }
        /// <summary>
        /// Событие, возникающее при нажатии на кнопку Отмена
        /// Вызывает закрытие всего приложения в целом
        /// Запускает сборщик мусора принудительно
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DeallocMemory();
        }
        /// <summary>
        /// Событие, возникающее при нажатии на кнопку Далее
        /// </summary>
        private void buttonNext_Click(object sender, EventArgs e)
        {
            AuthenticationModule module = new AuthenticationModule(textLogin.Text, textPassword.Text, _dictionaryForms);
            var usersForm = module.CreateUserForm();
            if (usersForm == null)
            {
                MessageBox.Show(Resources.WrongPasswordOrLogin);
            }
            else
            {
                usersForm.Show();
                usersForm.Visible = true;
                Visible = false;
            }
        }
        /// <summary>
        /// Событие, срабатывающее при закрытии формы -> очистка ресурсов и освобождение памяти
        /// </summary>
        private void AuthenticationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeallocMemory();
        }

        /// <summary>
        /// Освобождение памяти приложения и завершение его работы
        /// </summary>
        private void DeallocMemory()
        {
            GC.Collect();
            Application.Exit();
        }
    }
}
