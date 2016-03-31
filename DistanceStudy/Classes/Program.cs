using System;
using System.Windows.Forms;
using DistanceStudy.Forms;

/*Приложение Distance Study 0.1
Разработали: Шиененко В. и Колядко С.
Руководитель: Полозков Ю.В.*/


namespace DistanceStudy.Classes
{
    /// <summary>
    /// Создание 2 форм: форма ManualForm (Начальный help) и форма аутентификации пользователя.
    /// Отображение их на экране
    /// Класс представляет собой контекст запуска
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        public static AuthenticationForm MainForm;
        [STAThread]
        private static void Main()
        {
            MainForm = new AuthenticationForm();
            Application.EnableVisualStyles();
            Application.Run(MainForm);
        }
    }
}
