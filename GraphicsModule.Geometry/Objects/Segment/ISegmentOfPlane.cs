using System.Drawing;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Segment
{
    interface ISegmentOfPlane
    {
        void DrawSegmentOnly(DrawS st, System.Drawing.Point framecenter, Graphics g);
    }
}
