using System;
using System.Windows.Forms;
using DistanceStudy.Classes;


/*
 * Является первичным руководством по работе с приложением
 * TODO: возможность отключить в настройках
 * TODO: ManualForm выводится на экран при запуске приложения
 * TODO: возможность отключить в настройках
 */

namespace DistanceStudy.Forms
{
    public partial class ManualForm : Form
    {
        // считываем данные из xml и создаем объект LoadHelpText
        private readonly LoadHelpText _loadHelp = new LoadHelpText();
        // счетчик номера записи, считанный из xml
        private int _index;

        public ManualForm()
        {
            InitializeComponent();
            /*Вывод текста подсказки на экран*/
            AddTextLabel();
        }

        /// Функция добавления текста подсказки в labeltxtInfo
        /// TODO: подгружается динамически из dll или бд
        /// TODO: ссылки на каждую группу в help
        private void AddTextLabel()
        {
            // Вывод первой подсказки на экран
            textBoxHelp.Text = _loadHelp.HelpText[0];
        }

        // Событие по нажатию на кнопку Отмена. 
        // По нажатию осуществляется закрытие формы ManualForms
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form findForm = FindForm();
            if (findForm != null) findForm.Close();
        }

        // Событие по нажатию на кнопку Далее. 
        private void btnNext_Click(object sender, EventArgs e)
        {
            // Кнопка Назад становится видимой
            btnBack.Visible = true;
            // Если впереди есть еще подсказка, то увеличиваем счетчик
            if (!(_index + 2 > _loadHelp.CountOfpromts)) _index++;
            // Проверяем последняя ли это подсказка : если да, то кнопка Далее невидима, если нет - без изменений
            if(_index == _loadHelp.CountOfpromts - 1) btnNext.Visible = false;
            // Вывод в текстовое поле текста подсказки с номером
            textBoxHelp.Text = _loadHelp.HelpText[_index];
        }

        // Событие по нажатию на кнопку Назад. 
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Кнопка Далее становится видимой
            btnNext.Visible = true;
            // Если впереди есть еще подсказка, то увеличиваем счетчик
            if (!(_index - 1 < 0)) _index--;
            // Проверяем последняя ли это подсказка : если да, то кнопка Назад невидима, если нет - без изменений
            if(_index == 0) btnBack.Visible = false;
            // Вывод в текстовое поле текста подсказки с номером
            textBoxHelp.Text = _loadHelp.HelpText[_index];
        }
    }
    
}
