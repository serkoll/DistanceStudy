using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using GeometryObjects;

namespace GraphicsModule
{
    /// <summary>
    /// Определяет метод создания и отрисовки графического объекта
    /// </summary>
    public interface ICreate
    {
        /// <summary>
        /// Добавляет объект в коллекцию графических объектов и отрисовывает его
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="frameCenter">Центр системы координат</param>
        /// <param name="can">Полотно отрисовки</param>
        /// <param name="setting">Настройки</param>
        /// <param name="strg">Хранилище данных</param>
        void AddToStorageAndDraw(Point pt, Point frameCenter,Canvas can, DrawS setting, Storage strg);
    }
}
