using System.Drawing;
using GraphicsModule.Configuration;

namespace GraphicsModule.Geometry.Interfaces
{
    public interface ILineOfPlane : ILine
    {
        void DrawLineOnly(Blueprint blueprint);
    }
}
