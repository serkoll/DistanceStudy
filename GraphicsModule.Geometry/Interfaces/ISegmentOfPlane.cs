using System.Drawing;
using GraphicsModule.Configuration;

namespace GraphicsModule.Geometry.Interfaces
{
    internal interface ISegmentOfPlane: IObject
    {
        void DrawSegmentOnly(Blueprint blueprint);
    }
}
