using System.Drawing;
using GraphicsModule.Configuration;
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

        public void Draw(DrawSettings st, Point framecenter, Graphics g)
        {
            Point0.Draw(st, framecenter, g);
            Point1.Draw(st, framecenter, g);
            var pt0 = DeterminePosition.ForPointProjection(Point0, st.RadiusPoints, framecenter);
            var pt1 = DeterminePosition.ForPointProjection(Point1, st.RadiusPoints, framecenter);
            g.DrawLine(st.PenLineOfPlane3Y0Z, new PointF(pt0.X + st.RadiusPoints, pt0.Y + st.RadiusPoints),
                                              new PointF(pt1.X + st.RadiusPoints, pt1.Y + st.RadiusPoints));
        }

        public void DrawSegmentOnly(DrawSettings st, Point framecenter, Graphics g)
        {
            Point0.DrawPointsOnly(st, framecenter, g);
            Point1.DrawPointsOnly(st, framecenter, g);
            var pt0 = DeterminePosition.ForPointProjection(Point0, st.RadiusPoints, framecenter);
            var pt1 = DeterminePosition.ForPointProjection(Point1, st.RadiusPoints, framecenter);
            g.DrawLine(st.PenLineOfPlane3Y0Z, new PointF(pt0.X + st.RadiusPoints, pt0.Y + st.RadiusPoints),
                                              new PointF(pt1.X + st.RadiusPoints, pt1.Y + st.RadiusPoints));
        }

        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            var sg = DeterminePosition.ForSegmentProjection(this, frameCenter);
            return Analyze.Analyze.SegmentsPosition.IncidenceOfPoint(mscoords, sg, 35 * distance);
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
