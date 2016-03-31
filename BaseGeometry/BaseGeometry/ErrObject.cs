using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeomObjects {
    /// <summary>
    /// Класс, отслеживающий ошибки при выполнении
    /// </summary>
    public class ErrObject {
        /// <summary>
        /// Номер ошибки
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Описание ошибки
        /// </summary>
        public string Description { get; set; }
    }
    ///<summary> Перечислитель, указывающий ошибки задания, редактирования, отрисовки линии</summary>
    public enum LineError
    {
        None = 0,
        //Резерв
        KxKyKz_Zero = 1
        //Коэффициенты линии Kx и Ky имеют нулевое значение
    }
}
