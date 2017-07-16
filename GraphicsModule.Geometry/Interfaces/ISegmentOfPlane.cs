using System.Drawing;
using GraphicsModule.Configuration;

namespace GraphicsModule.Geometry.Interfaces
{
    internal interface ISegmentOfPlane: IObject
    {
        void DrawSegmentOnly(DrawSettings settings, Point coordinateSystemCenter, Graphics graphics);
    }
}
