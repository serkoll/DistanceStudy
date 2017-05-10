using System.Drawing;
using GraphicsModule.Configuration;

namespace GraphicsModule.Geometry.Interfaces
{
    internal interface ISegmentOfPlane: IObject
    {
        void DrawSegmentOnly(DrawSettings st, Point framecenter, Graphics g);
    }
}
