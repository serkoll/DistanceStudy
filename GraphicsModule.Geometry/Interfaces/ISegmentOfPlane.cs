using System.Drawing;
using GraphicsModule.Configuration;

namespace GraphicsModule.Geometry.Interfaces
{
    internal interface ISegmentOfPlane: IObject
    {
        void DrawSegmentOnly(DrawS st, Point framecenter, Graphics g);
    }
}
