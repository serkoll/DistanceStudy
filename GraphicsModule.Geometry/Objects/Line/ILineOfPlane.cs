using System.Drawing;
using GraphicsModule.Geometry.Settings;
using GraphicsModule.Geometry.Settingss;

namespace GraphicsModule.Geometry.Objects.Line
{
    interface ILineOfPlane
    {
        void DrawLineOnly(DrawS st, System.Drawing.Point framecenter, Graphics g);
    }
}
