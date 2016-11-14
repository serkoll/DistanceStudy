using System.Drawing;

namespace GeometryObjects
{
    public class CoordinateConverter
    {
        public Point FromPointProjectionToPoint(PointOfPlan1X0Y pointProjection)
        { 
            return new Point(-(int)pointProjection.X, (int)pointProjection.Y);
        }
        public Point FromPointProjectionToPoint(PointOfPlan2X0Z pointProjection)
        {
            return new Point(-(int)pointProjection.X, -(int)pointProjection.Z);
        }
        public Point FromPointProjectionToPoint(PointOfPlan3Y0Z pointProjection)
        {
            return new Point((int)pointProjection.Y, -(int)pointProjection.Z);
        }
    }
}
