using System.Drawing;

namespace GraphicsModule.Interfaces
{
    /// <summary>
    /// Интерфейс, определяющий операции над графическими объектами
    /// </summary>
    public interface IOperation
    {
        void Execute(Point mousecoords, Storage strg, Canvas.Canvas can);
    }
}
