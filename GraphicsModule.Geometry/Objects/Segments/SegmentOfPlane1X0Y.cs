using System;
using System.Drawing;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Segments
{
    /// <summary>Класс для расчета параметров проекции 3D линии на X0Y плоскость проекций</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class SegmentOfPlane1X0Y : IObject, ISegmentOfPlane
    {
        public PointOfPlane1X0Y Point0 { get; set; }
        public PointOfPlane1X0Y Point1 { get; set; }
        public Name Name { get; set; }
        public double kx { get; set; }
        public double ky { get; set; }
        public SegmentOfPlane1X0Y()
        {
            Point0 = new PointOfPlane1X0Y();
            Point1 = new PointOfPlane1X0Y();
        }
        public SegmentOfPlane1X0Y(PointOfPlane1X0Y pt0, PointOfPlane1X0Y pt1)
        {
            Point0 = pt0;
            Point1 = pt1;
            kx = pt1.X - pt0.X;
            ky = pt1.Y - pt0.Y;
        }
        public SegmentOfPlane1X0Y(Segment2D line)
        {
            Point0.X = line.Point0.X;
            Point0.Y = line.Point0.Y;
            Point1.X = line.Point1.X;
            Point1.Y = line.Point1.Y;
            kx = Point1.X - Point0.X;
            ky = Point1.Y - Point0.Y;
        }
        public SegmentOfPlane1X0Y(Segment3D line)
        {
            Point0.X = line.Point0.X;
            Point0.Y = line.Point0.Y;
            Point1.X = line.Point1.X;
            Point1.Y = line.Point1.Y;
        }
        public void Draw(DrawS st, System.Drawing.Point framecenter, Graphics g)
        {
            
            Point0.Draw(st, framecenter, g);
            Point1.Draw(st, framecenter, g);
            var pt0 = DeterminePosition.ForPointProjection(Point0, st.RadiusPoints, framecenter);
            var pt1 = DeterminePosition.ForPointProjection(Point1, st.RadiusPoints, framecenter);
            g.DrawLine(st.PenLineOfPlane1X0Y, new PointF(pt0.X + st.RadiusPoints, pt0.Y + st.RadiusPoints),
                                             new PointF(pt1.X + st.RadiusPoints, pt1.Y + st.RadiusPoints));

        }
        public void DrawSegmentOnly(DrawS st, System.Drawing.Point framecenter, Graphics g)
        {
            Point0.DrawPointsOnly(st, framecenter, g);
            Point1.DrawPointsOnly(st, framecenter, g);
            var pt0 = DeterminePosition.ForPointProjection(Point0, st.RadiusPoints, framecenter);
            var pt1 = DeterminePosition.ForPointProjection(Point1, st.RadiusPoints, framecenter);
            g.DrawLine(st.PenLineOfPlane1X0Y, new PointF(pt0.X + st.RadiusPoints, pt0.Y + st.RadiusPoints),
                                              new PointF(pt1.X + st.RadiusPoints, pt1.Y + st.RadiusPoints));

        }
        public bool IsSelected(System.Drawing.Point mscoords, float ptR, System.Drawing.Point frameCenter, double distance)
        {
            var sg = DeterminePosition.ForSegmentProjection(this, frameCenter);
            return Analyze.Analyze.SegmentPos.IncidenceOfPoint(mscoords, sg, 35 * distance);
        }
        public Name GetName()
        {
            var name = new Name(Name.Value.Remove(Name.Value.IndexOf("'", StringComparison.Ordinal)), Name.Dx, Name.Dy);
            return name;
        }
        public void SetName(Name name)
        {
            Name = new Name(name);
            Point0.SetName(Name);
            Point1.SetName(Name);
        }
    }
}