using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistanceStudy.Classes
{
    /// <summary>
    /// Контроллер создания экземпляра типа по самому типу (для форм)
    /// </summary>
    /// <typeparam name="T">Тип создаваемого экземляра</typeparam>
    public static class FormController<T> where T : Form
    {
        /// <summary>
        /// Создать форму по типу
        /// </summary>
        /// <param name="param">Параметры для конструктора формы</param>
        /// <returns>Форма</returns>
        public static T CreateFormByType(params object []param)
        {
            Type type = typeof(T);
            return (T)Activator.CreateInstance(type, param);
        }
    }
}
