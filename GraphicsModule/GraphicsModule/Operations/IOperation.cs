using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GeometryObjects;

namespace GraphicsModule
{
    /// <summary>
    /// Интерфейс, определяющий операции над графическими объектами
    /// </summary>
    public interface IOperation
    {
        void Execute(Point mousecoords, Storage strg, Canvas can);
    }
}
