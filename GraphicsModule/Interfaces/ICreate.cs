using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Interfaces;

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
        /// <param name="blueprint">Полотно отрисовки</param>
        void AddToStorageAndDraw(Point pt, Blueprint blueprint);
    }
}
