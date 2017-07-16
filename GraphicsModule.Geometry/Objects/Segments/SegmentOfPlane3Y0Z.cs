using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Segments
{
    public class SegmentOfPlane3Y0Z : ISegmentOfPlane
    {
        private Name _name;

        public SegmentOfPlane3Y0Z(PointOfPlane3Y0Z pt0, PointOfPlane3Y0Z pt1)
        {
            Point0 = pt0;
            Point1 = pt1;
            Ky = pt1.Y - pt0.Y;
            Kz = pt1.Z - pt0.Z;

        }

        public SegmentOfPlane3Y0Z(Segment3D segment)
        {
            Point0 = new PointOfPlane3Y0Z(segment.Point0.Y, segment.Point0.Z);
            Point1 = new PointOfPlane3Y0Z(segment.Point1.Y, segment.Point1.Z);
        }

        public void Draw(DrawSettings settings, Point coordinateSystemCenter, Graphics g)
        {
            Point0.Draw(settings, coordinateSystemCenter, g);
            Point1.Draw(settings, coordinateSystemCenter, g);
            var pt0 = Point0.ToGlobalCoordinatesPoint(settings.RadiusPoints, coordinateSystemCenter);
            var pt1 = Point1.ToGlobalCoordinatesPoint(settings.RadiusPoints, coordinateSystemCenter);
            g.DrawLine(settings.PenLineOfPlane3Y0Z, new PointF(pt0.X + settings.RadiusPoints, pt0.Y + settings.RadiusPoints),
                                              new PointF(pt1.X + settings.RadiusPoints, pt1.Y + settings.RadiusPoints));
        }

        public void DrawSegmentOnly(DrawSettings settings, Point coordinateSystemCenter, Graphics graphics)
        {
            Point0.DrawPointsOnly(settings, coordinateSystemCenter, graphics);
            Point1.DrawPointsOnly(settings, coordinateSystemCenter, graphics);
            var pt0 = Point0.ToGlobalCoordinatesPoint(settings.RadiusPoints, coordinateSystemCenter);
            var pt1 = Point1.ToGlobalCoordinatesPoint(settings.RadiusPoints, coordinateSystemCenter);
            graphics.DrawLine(settings.PenLineOfPlane3Y0Z, new PointF(pt0.X + settings.RadiusPoints, pt0.Y + settings.RadiusPoints),
                                              new PointF(pt1.X + settings.RadiusPoints, pt1.Y + settings.RadiusPoints));
        }

        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            var sg = this.ToGlobalCoordinatesSegment(frameCenter);
            return sg.IsIncidentalToPoint(mscoords, 35 * distance);
        }

        public PointOfPlane3Y0Z Point0 { get; }

        public PointOfPlane3Y0Z Point1 { get; }

        public Name Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Point0.Name = _name;
                Point1.Name = _name;
            }
        }

        public double Ky { get; }

        public double Kz { get; }
    }
}
