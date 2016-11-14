using System.Drawing;
using GraphicsModule.Geometry.Objects;
using GraphicsModule.Geometry.Objects.Point;

namespace GraphicsModule.Geometry
{
    public static class TypeOf
    {
        public static IObject PointOfPlane(Point pt, Point frameCenter)
        {
            if (PointOfPlane1X0Y.Creatable(pt, frameCenter))
            {
                return new PointOfPlane1X0Y(pt, frameCenter);
            }
            else if (PointOfPlane2X0Z.Creatable(pt, frameCenter))
            {
                return new PointOfPlane2X0Z(pt, frameCenter);
            }
            else if (PointOfPlane3Y0Z.Creatable(pt, frameCenter))
            {
                return new PointOfPlane3Y0Z(pt, frameCenter);
            }
            else return null;
        }
    }
}
