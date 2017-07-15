using GraphicsModule.Geometry.Extensions;

namespace GraphicsModule.Geometry.Objects.Points
{
    //TODO: из CNV сюда всё перенести
    public static class PointExtensions
    {
        public static Point2D ToPoint2D(this PointOfPlane1X0Y pt)
        {
            return ConvertObjectsExtensions.ToPoint2D(pt);
        }
        public static Point2D ToPoint2D(this PointOfPlane2X0Z pt)
        {
            return ConvertObjectsExtensions.ToPoint2D(pt);
        }
        public static Point2D ToPoint2D(this PointOfPlane3Y0Z pt)
        {
            return ConvertObjectsExtensions.ToPoint2D(pt);
        }
    }
}
