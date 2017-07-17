using System.Drawing;
using GraphicsModule.Configuration;

namespace GraphicsModule.Geometry.Interfaces
{
    public interface ILineOfPlane : IObject
    {
        void DrawLineOnly(DrawSettings settings, Point framecenter, Graphics graphics);
    }
}
