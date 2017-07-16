using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Segments
{
    public class SegmentOfPlane2X0Z : ISegmentOfPlane
    {
        private Name _name;

        public SegmentOfPlane2X0Z()
        {
            Point0 = new PointOfPlane2X0Z();
            Point1 = new PointOfPlane2X0Z();
        }
        public SegmentOfPlane2X0Z(PointOfPlane2X0Z pt0, PointOfPlane2X0Z pt1)
        {
            Point0 = pt0;
            Point1 = pt1;
            Kx = pt1.X - pt0.X;
            Kz = pt1.Z - pt0.Z;
        }
        public SegmentOfPlane2X0Z(Segment3D segment)
        {
            Point0 = new PointOfPlane2X0Z(segment.Point0.X, segment.Point0.Z);
            Point1 = new PointOfPlane2X0Z(segment.Point1.X, segment.Point1.Z);
        }
        public void Draw(DrawSettings settings, Point coordinateSystemCenter, Graphics g)
        {
            Point0.Draw(settings, coordinateSystemCenter, g);
            Point1.Draw(settings, coordinateSystemCenter, g);
            var pt0 = Point0.ToGlobalCoordinatesPoint(settings.RadiusPoints, coordinateSystemCenter);
            var pt1 = Point1.ToGlobalCoordinatesPoint(settings.RadiusPoints, coordinateSystemCenter);
            g.DrawLine(settings.PenLineOfPlane2X0Z, new PointF(pt0.X + settings.RadiusPoints, pt0.Y + settings.RadiusPoints),
                                              new PointF(pt1.X + settings.RadiusPoints, pt1.Y + settings.RadiusPoints));
        } 
        public void DrawSegmentOnly(DrawSettings settings, Point coordinateSystemCenter, Graphics graphics)
        {
            Point0.DrawPointsOnly(settings, coordinateSystemCenter, graphics);
            Point1.DrawPointsOnly(settings, coordinateSystemCenter, graphics);
            var pt0 = Point0.ToGlobalCoordinatesPoint(settings.RadiusPoints, coordinateSystemCenter);
            var pt1 = Point1.ToGlobalCoordinatesPoint(settings.RadiusPoints, coordinateSystemCenter);
            graphics.DrawLine(settings.PenLineOfPlane2X0Z, new PointF(pt0.X + settings.RadiusPoints, pt0.Y + settings.RadiusPoints),
                                              new PointF(pt1.X + settings.RadiusPoints, pt1.Y + settings.RadiusPoints));

        }
        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            var sg = this.ToGlobalCoordinatesSegment(frameCenter);
            return sg.IsIncidentalToPoint(mscoords, 35 * distance);
        }

        public PointOfPlane2X0Z Point0 { get; }

        public PointOfPlane2X0Z Point1 { get; }

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
        public double Kx { get; set; }
        public double Kz { get; set; }
    }
}