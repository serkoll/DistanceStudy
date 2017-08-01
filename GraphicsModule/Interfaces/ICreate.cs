using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry;

namespace GraphicsModule.Interfaces
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
        /// <param name="blueprint">Полотно отрисовки</param>
        /// <param name="settings">Настройки</param>
        /// <param name="storage">Хранилище данных</param>
        void AddToStorageAndDraw(Point pt, Point frameCenter,Blueprint blueprint, DrawSettings settings, Storage storage);
    }
}
