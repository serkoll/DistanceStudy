using System.Drawing;
using GraphicsModule.Geometry;

namespace GraphicsModule.Interfaces
{
    /// <summary>
    /// Интерфейс, определяющий операции над графическими объектами
    /// </summary>
    public interface IOperation
    {
        void Execute(Point mousecoords, Blueprint blueprint);
    }
}
