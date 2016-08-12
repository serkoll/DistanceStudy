using System;
using System.Windows.Forms;

namespace DistanceStudy.Classes
{
    /// <summary>
    /// Контроллер создания экземпляра типа по самому типу (для форм)
    /// </summary>
    /// <typeparam name="T">Тип создаваемого экземляра</typeparam>
    public static class FormController
    {
        /// <summary>
        /// Создать форму по типу
        /// </summary>
        /// <param name="type">Тип формы</param>
        /// <param name="param">Параметры для конструктора формы</param>
        /// <returns>Форма</returns>
        public static Form CreateFormByType(Type type, params object []param)
        {
            return (Form)Activator.CreateInstance(type, param);
        }
    }
}
