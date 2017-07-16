using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Segments
{
    public class SegmentOfPlane2X0Z : ISegmentOfPlane
    {
        public SegmentOfPlane2X0Z(PointOfPlane2X0Z pt0, PointOfPlane2X0Z pt1)
        {
            Point0 = pt0;
            Point1 = pt1;
            Kx = pt1.X - pt0.X;
            Kz = pt1.Z - pt0.Z;
            Name = new Name();
        }

        public SegmentOfPlane2X0Z(Segment3D segment)
        {
            Point0 = new PointOfPlane2X0Z(segment.Point0.X, segment.Point0.Z);
            Point1 = new PointOfPlane2X0Z(segment.Point1.X, segment.Point1.Z);
        }

        public void Draw(DrawSettings settings, Point coordinateSystemCenter, Graphics graphics)
        {
            var pt0 = Point0.ToGlobalCoordinatesPoint(coordinateSystemCenter);
            var pt1 = Point1.ToGlobalCoordinatesPoint(coordinateSystemCenter);

            graphics.DrawLine(settings.PenLineOfPlane2X0Z, pt0, pt1);

            Point0.Draw(settings, coordinateSystemCenter, graphics);
            Point1.Draw(settings, coordinateSystemCenter, graphics);
        } 
        public void DrawSegmentOnly(DrawSettings settings, Point coordinateSystemCenter, Graphics graphics)
        {
            var pt0 = Point0.ToGlobalCoordinatesPoint(coordinateSystemCenter);
            var pt1 = Point1.ToGlobalCoordinatesPoint(coordinateSystemCenter);

            graphics.DrawLine(settings.PenLineOfPlane2X0Z, pt0, pt1);

            Point0.Draw(settings.PenPoints, settings.RadiusPoints, coordinateSystemCenter, graphics);
            Point1.Draw(settings.PenPoints, settings.RadiusPoints, coordinateSystemCenter, graphics);
        }
        public bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            var sg = this.ToGlobalCoordinatesSegment(coordinateSystemCenter);
            return sg.IsIncidentalToPoint(mscoords, 35 * distance);
        }

        public PointOfPlane2X0Z Point0 { get; }

        public PointOfPlane2X0Z Point1 { get; }

        public double Kx { get; set; }

        public double Kz { get; set; }

        public Name Name { get; set; }
    }
}