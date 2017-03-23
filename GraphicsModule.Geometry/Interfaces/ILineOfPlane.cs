using System.Drawing;
using GraphicsModule.Configuration;

namespace GraphicsModule.Geometry.Interfaces
{
    public interface ILineOfPlane : IObject
    {
        void DrawLineOnly(DrawS st, Point framecenter, Graphics g);
    }
}
