using System.Drawing;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Interfaces
{
    internal interface ILineOfPlane
    {
        void DrawLineOnly(DrawS st, Point framecenter, Graphics g);
    }
}
