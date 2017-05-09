using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Segments
{
    public class SegmentOfPlane1X0Y : ISegmentOfPlane
    {
        private Name _name;
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
        public void Draw(DrawSettings st, Point framecenter, Graphics g)
        {
            
            Point0.Draw(st, framecenter, g);
            Point1.Draw(st, framecenter, g);
            var pt0 = DeterminePosition.ForPointProjection(Point0, st.RadiusPoints, framecenter);
            var pt1 = DeterminePosition.ForPointProjection(Point1, st.RadiusPoints, framecenter);
            g.DrawLine(st.PenLineOfPlane1X0Y, new PointF(pt0.X + st.RadiusPoints, pt0.Y + st.RadiusPoints),
                                             new PointF(pt1.X + st.RadiusPoints, pt1.Y + st.RadiusPoints));

        }
        public void DrawSegmentOnly(DrawSettings st, Point framecenter, Graphics g)
        {
            Point0.DrawPointsOnly(st, framecenter, g);
            Point1.DrawPointsOnly(st, framecenter, g);
            var pt0 = DeterminePosition.ForPointProjection(Point0, st.RadiusPoints, framecenter);
            var pt1 = DeterminePosition.ForPointProjection(Point1, st.RadiusPoints, framecenter);
            g.DrawLine(st.PenLineOfPlane1X0Y, new PointF(pt0.X + st.RadiusPoints, pt0.Y + st.RadiusPoints),
                                              new PointF(pt1.X + st.RadiusPoints, pt1.Y + st.RadiusPoints));

        }
        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            var sg = DeterminePosition.ForSegmentProjection(this, frameCenter);
            return Analyze.Analyze.SegmentPos.IncidenceOfPoint(mscoords, sg, 35 * distance);
        }
        public PointOfPlane1X0Y Point0 { get; private set; }
        public PointOfPlane1X0Y Point1 { get; private set; }

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
        public double Kx { get; private set; }
        public double Ky { get; private set; }
    }
}