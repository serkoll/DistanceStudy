using System.Drawing;
using GraphicsModule.Configuration;

namespace GraphicsModule.Geometry.Interfaces
{
    public interface ILineOfPlane : IObject
    {
        void DrawLineOnly(DrawSettings st, Point framecenter, Graphics g);
    }
}
