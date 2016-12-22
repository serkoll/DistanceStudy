using System.Drawing;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Interfaces
{
    internal interface ILineOfPlane
    {
        void DrawLineOnly(DrawS st, System.Drawing.Point framecenter, Graphics g);
    }
}
