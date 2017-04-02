using System;
using System.Drawing;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry
{
    public static class Calculate
    {
        #region Distance
        public static double Distance(Point mscoords, Point pt)
        {
            return Math.Sqrt(Math.Pow((mscoords.X - pt.X), 2) + Math.Pow((mscoords.Y - pt.Y), 2));
        }
        public static double Distance(Point mscoords, Point2D pt)
        {
            return Math.Sqrt(Math.Pow((mscoords.X - pt.X), 2) + Math.Pow((mscoords.Y - pt.Y), 2));
        }
        public static double Distance(Point mscoords, float ptR, Point frameCenter, PointOfPlane1X0Y pt)
        {
            var dpt = DeterminePosition.ForPointProjection(pt, ptR, frameCenter);
            return Distance(mscoords, dpt);
        }
        public static double Distance(Point mscoords, float ptR, Point frameCenter, PointOfPlane2X0Z pt)
        {
            var dpt = DeterminePosition.ForPointProjection(pt, ptR, frameCenter);
            return Distance(mscoords, dpt);
        }
        public static double Distance(Point mscoords, float ptR, Point frameCenter, PointOfPlane3Y0Z pt)
        {
            var dpt = DeterminePosition.ForPointProjection(pt, ptR, frameCenter);
            return Distance(mscoords, dpt);
        }
        public static double[] Distance(Point mscoords, float ptR, Point frameCenter, Point3D pt)
        {
            return new[] { Distance(mscoords, ptR, frameCenter, pt.PointOfPlane1X0Y),
                                  Distance(mscoords, ptR, frameCenter, pt.PointOfPlane2X0Z),
                                  Distance(mscoords, ptR, frameCenter, pt.PointOfPlane3Y0Z)};
        }
        #endregion
        #region Crossing
        public static PointF CrossingPoint(Line2D ln1, Line2D ln2)
        {
            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx + ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            var x = ln1.Kx * (y - ln1.Point0.Y) / ln1.Ky + ln1.Point0.X;
            return new PointF((float)x, (float)y);
        }
        public static PointF CrossingPoint(Line2D ln1, LineOfPlane1X0Y ln, Point frameCenter)
        {
            var ln2 = DeterminePosition.ForLineProjection(ln, frameCenter);
            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx + ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            var x = (ln1.Point0.X * ln2.Kx * ln1.Ky - ln2.Point0.X * ln1.Kx * ln2.Ky + ln2.Kx * ln1.Kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.Ky * ln2.Kx - ln1.Kx * ln2.Ky);
            return new PointF((float)x, (float)y);
        }
        public static PointF CrossingPoint(Line2D ln1, LineOfPlane2X0Z ln, Point frameCenter)
        {
            var ln2 = DeterminePosition.ForLineProjection(ln, frameCenter);
            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx + ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                     (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            var x = (ln1.Point0.X * ln2.Kx * ln1.Ky - ln2.Point0.X * ln1.Kx * ln2.Ky + ln2.Kx * ln1.Kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.Ky * ln2.Kx - ln1.Kx * ln2.Ky);
            return new PointF((float)x, (float)y);
        }
        public static PointF CrossingPoint(Line2D ln1, LineOfPlane3Y0Z ln, Point frameCenter)
        {
            var ln2 = DeterminePosition.ForLineProjection(ln, frameCenter);
            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx + ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                     (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            var x = (ln1.Point0.X * ln2.Kx * ln1.Ky - ln2.Point0.X * ln1.Kx * ln2.Ky + ln2.Kx * ln1.Kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.Ky * ln2.Kx - ln1.Kx * ln2.Ky);
            return new PointF((float)x, (float)y);
        }
        #endregion
    }
}
