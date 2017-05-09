using System.Drawing;
using GraphicsModule.Configuration;
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
        public void Draw(DrawSettings settings, Point framecenter, Graphics g)
        {
            Point0.Draw(settings, framecenter, g);
            Point1.Draw(settings, framecenter, g);
            var pt0 = DeterminePosition.ForPointProjection(Point0, settings.RadiusPoints, framecenter);
            var pt1 = DeterminePosition.ForPointProjection(Point1, settings.RadiusPoints, framecenter);
            g.DrawLine(settings.PenLineOfPlane2X0Z, new PointF(pt0.X + settings.RadiusPoints, pt0.Y + settings.RadiusPoints),
                                              new PointF(pt1.X + settings.RadiusPoints, pt1.Y + settings.RadiusPoints));
        } 
        public void DrawSegmentOnly(DrawSettings st, Point framecenter, Graphics g)
        {
            Point0.DrawPointsOnly(st, framecenter, g);
            Point1.DrawPointsOnly(st, framecenter, g);
            var pt0 = DeterminePosition.ForPointProjection(Point0, st.RadiusPoints, framecenter);
            var pt1 = DeterminePosition.ForPointProjection(Point1, st.RadiusPoints, framecenter);
            g.DrawLine(st.PenLineOfPlane2X0Z, new PointF(pt0.X + st.RadiusPoints, pt0.Y + st.RadiusPoints),
                                              new PointF(pt1.X + st.RadiusPoints, pt1.Y + st.RadiusPoints));

        }
        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            var sg = DeterminePosition.ForSegmentProjection(this, frameCenter);
            return Analyze.Analyze.SegmentsPosition.IncidenceOfPoint(mscoords, sg, 35 * distance);
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