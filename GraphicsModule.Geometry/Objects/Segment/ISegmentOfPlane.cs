using System.Drawing;
using GraphicsModule.Geometry.Settings;
using GraphicsModule.Geometry.Settingss;

namespace GraphicsModule.Geometry.Objects.Segment
{
    interface ISegmentOfPlane
    {
        void DrawSegmentOnly(DrawS st, System.Drawing.Point framecenter, Graphics g);
    }
}
