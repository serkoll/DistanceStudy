using System.Drawing;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Line
{
    internal interface ILineOfPlane
    {
        void DrawLineOnly(DrawS st, System.Drawing.Point framecenter, Graphics g);
    }
}
