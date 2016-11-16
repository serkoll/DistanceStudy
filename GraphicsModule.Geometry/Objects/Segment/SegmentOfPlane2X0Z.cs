using System.Drawing;
using GraphicsModule.Geometry.Objects.Point;
using GraphicsModule.Geometry.Settings;
using GraphicsModule.Geometry.Settingss;

namespace GraphicsModule.Geometry.Objects.Segment
{
    /// <summary>Класс для расчета параметров проекции 3D линии на X0Z плоскость проекций</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class SegmentOfPlane2X0Z : IObject, ISegmentOfPlane
    { 
        public PointOfPlane2X0Z Point0 { get; set; }
        public PointOfPlane2X0Z Point1 { get; set; }
        public double kx { get; set; }
        public double kz { get; set; }
        public SegmentOfPlane2X0Z()
        {
            Point0 = new PointOfPlane2X0Z();
            Point1 = new PointOfPlane2X0Z();
        }
        public SegmentOfPlane2X0Z(Point3D pt0, Point3D pt1)
        {
            Point0.X = pt0.X;
            Point0.Z = pt0.Z;
            Point1.X = pt1.X;
            Point1.Z = pt1.Z;
        }
        public SegmentOfPlane2X0Z(PointOfPlane2X0Z pt0, PointOfPlane2X0Z pt1)
        {
            Point0 = pt0;
            Point1 = pt1;
            kx = pt1.X - pt0.X;
            kz = pt1.Z - pt0.Z;
        }
        public SegmentOfPlane2X0Z(Segment3D line)
        {
            Point0.X = line.Point0.X;
            Point0.Z = line.Point0.Z;
            Point1.X = line.Point1.X;
            Point1.Z = line.Point1.Z;
        }
        public void Draw(DrawS st, System.Drawing.Point framecenter, Graphics g)
        {
            Point0.Draw(st, framecenter, g);
            Point1.Draw(st, framecenter, g);
            var pt0 = DeterminePosition.ForPointProjection(Point0, st.RadiusPoints, framecenter);
            var pt1 = DeterminePosition.ForPointProjection(Point1, st.RadiusPoints, framecenter);
            g.DrawLine(st.PenLineOfPlane2X0Z, new PointF(pt0.X + st.RadiusPoints, pt0.Y + st.RadiusPoints),
                                              new PointF(pt1.X + st.RadiusPoints, pt1.Y + st.RadiusPoints));
        } 
        public void DrawSegmentOnly(DrawS st, System.Drawing.Point framecenter, Graphics g)
        {
            Point0.DrawPointsOnly(st, framecenter, g);
            Point1.DrawPointsOnly(st, framecenter, g);
            var pt0 = DeterminePosition.ForPointProjection(Point0, st.RadiusPoints, framecenter);
            var pt1 = DeterminePosition.ForPointProjection(Point1, st.RadiusPoints, framecenter);
            g.DrawLine(st.PenLineOfPlane2X0Z, new PointF(pt0.X + st.RadiusPoints, pt0.Y + st.RadiusPoints),
                                              new PointF(pt1.X + st.RadiusPoints, pt1.Y + st.RadiusPoints));

        }
        public bool IsSelected(System.Drawing.Point mscoords, float ptR, System.Drawing.Point frameCenter, double distance)
        {
            var sg = DeterminePosition.ForSegmentProjection(this, frameCenter);
            if (Analyze.Analyze.SegmentPos.IncidenceOfPoint(mscoords, sg, 35 * distance))
                return true;
            else
                return false;
        }
    }
}