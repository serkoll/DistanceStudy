using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Segments
{
    public class SegmentOfPlane1X0Y : ISegmentOfPlane
    {
        public SegmentOfPlane1X0Y(PointOfPlane1X0Y pt0, PointOfPlane1X0Y pt1)
        {
            Point0 = pt0;
            Point1 = pt1;
            Kx = pt1.X - pt0.X;
            Ky = pt1.Y - pt0.Y;
        }

        public SegmentOfPlane1X0Y(Segment3D segment)
        {
            Point0 = new PointOfPlane1X0Y(segment.Point0.X, segment.Point0.Y);
            Point1 = new PointOfPlane1X0Y(segment.Point1.X, segment.Point1.Y);
        }

        public void Draw(DrawSettings settings, Point coordinateSystemCenter, Graphics graphics)
        {
            var pt0 = Point0.ToGlobalCoordinatesPoint(settings.RadiusPoints, coordinateSystemCenter);
            var pt1 = Point1.ToGlobalCoordinatesPoint(settings.RadiusPoints, coordinateSystemCenter);

            Point0.Draw(settings, coordinateSystemCenter, graphics);
            Point1.Draw(settings, coordinateSystemCenter, graphics);
            
            graphics.DrawLine(settings.PenLineOfPlane1X0Y, pt0, pt1);
        }

        public void DrawSegmentOnly(DrawSettings settings, Point coordinateSystemCenter, Graphics graphics)
        {
            var pt0 = Point0.ToGlobalCoordinatesPoint(settings.RadiusPoints, coordinateSystemCenter);
            var pt1 = Point1.ToGlobalCoordinatesPoint(settings.RadiusPoints, coordinateSystemCenter);

            Point0.DrawPointsOnly(settings, coordinateSystemCenter, graphics);
            Point1.DrawPointsOnly(settings, coordinateSystemCenter, graphics);
            
            graphics.DrawLine(settings.PenLineOfPlane1X0Y, pt0, pt1);
        }

        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            var sg = this.ToGlobalCoordinatesSegment(frameCenter);
            return sg.IsIncidentalToPoint(mscoords, 35 * distance);
        }

        public PointOfPlane1X0Y Point0 { get; }

        public PointOfPlane1X0Y Point1 { get; }

        public double Kx { get; }

        public double Ky { get; }

        public Name Name { get; set; }
    }
}