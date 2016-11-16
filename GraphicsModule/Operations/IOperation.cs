using System.Drawing;

namespace GraphicsModule.Operations
{
    /// <summary>
    /// Интерфейс, определяющий операции над графическими объектами
    /// </summary>
    public interface IOperation
    {
        void Execute(Point mousecoords, Storage strg, Canvas can);
    }
}
