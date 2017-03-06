using System;
using System.Drawing;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Segments
{
    /// <summary>Класс для расчета параметров проекции 3D линии на X0Y плоскость проекций</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class SegmentOfPlane1X0Y : ISegmentOfPlane
    {
        public PointOfPlane1X0Y Point0 { get; set; }
        public PointOfPlane1X0Y Point1 { get; set; }
        public Name Name { get; set; }
        public double Kx { get; set; }
        public double Ky { get; set; }
        public SegmentOfPlane1X0Y(PointOfPlane1X0Y pt0, PointOfPlane1X0Y pt1)
        {
            Point0 = pt0;
            Point1 = pt1;
            Kx = pt1.X - pt0.X;
            Ky = pt1.Y - pt0.Y;
        }
        public SegmentOfPlane1X0Y(Segment3D line)
        {
            Point0.X = line.Point0.X;
            Point0.Y = line.Point0.Y;
            Point1.X = line.Point1.X;
            Point1.Y = line.Point1.Y;
        }
        public void Draw(DrawS st, Point framecenter, Graphics g)
        {
            
            Point0.Draw(st, framecenter, g);
            Point1.Draw(st, framecenter, g);
            var pt0 = DeterminePosition.ForPointProjection(Point0, st.RadiusPoints, framecenter);
            var pt1 = DeterminePosition.ForPointProjection(Point1, st.RadiusPoints, framecenter);
            g.DrawLine(st.PenLineOfPlane1X0Y, new PointF(pt0.X + st.RadiusPoints, pt0.Y + st.RadiusPoints),
                                             new PointF(pt1.X + st.RadiusPoints, pt1.Y + st.RadiusPoints));

        }
        public void DrawSegmentOnly(DrawS st, Point framecenter, Graphics g)
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
        public Name GetName()
        {
            return Name;
        }
        public void SetName(Name name)
        {
            Name = new Name(name);
            Name.Value += "'";
            Point0.Name = Name;
            Point1.Name = Name;
        }
    }
}