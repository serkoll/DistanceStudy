using System.Drawing;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Interfaces
{
    internal interface ISegmentOfPlane
    {
        void DrawSegmentOnly(DrawS st, System.Drawing.Point framecenter, Graphics g);
    }
}
