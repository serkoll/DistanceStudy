using System;
using System.Drawing;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;

namespace GraphicsModule.Geometry.Extensions
{
    public static class LinesPositionExtensions
    {
        #region Incidence of Point and Line

        public static bool IsIncidentalToPoint(this Line2D ln, Point pt)
        {
            return Math.Abs((pt.X - ln.Point0.X) * ln.ky - (pt.Y - ln.Point0.Y) * ln.kx) < 0.001;
        }

        public static bool IsIncidentalToPoint(this Line2D ln, Point pt, double solveerror)
        {
            return Math.Abs((pt.X - ln.Point0.X) * ln.ky - (pt.Y - ln.Point0.Y) * ln.kx) < solveerror;
        }

        public static bool IsIncidentalToPoint(this Line2D ln, Point2D pt)
        {
            return Math.Abs((pt.X - ln.Point0.X) * ln.ky - (pt.Y - ln.Point0.Y) * ln.kx) < 0.001;
        }

        public static bool IsIncidentalToPoint(this Line2D ln,  Point2D pt, double solveerror)
        {
            return Math.Abs((pt.X - ln.Point0.X) * ln.ky - (pt.Y - ln.Point0.Y) * ln.kx) < solveerror;
        }

        public static bool IsIncidentalToPoint(this Line3D ln, Point3D pt)
        {
            return (Math.Abs((pt.X - ln.Point0.X) * ln.Ky - (pt.Y - ln.Point0.Y) * ln.Kx) < 0.001) &&
                   (Math.Abs((pt.X - ln.Point0.X) * ln.Kz - (pt.Z - ln.Point0.Z) * ln.Kx) < 0.001) &&
                   (Math.Abs((pt.Y - ln.Point0.Y) * ln.Kz - (pt.Z - ln.Point0.Z) * ln.Ky) < 0.001);
        }

        public static bool IsIncidentalToPoint(this Line3D ln, Point3D pt, double solveerror)
        {
            return (Math.Abs((pt.X - ln.Point0.X) * ln.Ky - (pt.Y - ln.Point0.Y) * ln.Kx) < solveerror) &&
                   (Math.Abs((pt.X - ln.Point0.X) * ln.Kz - (pt.Z - ln.Point0.Z) * ln.Kx) < solveerror) &&
                   (Math.Abs((pt.Y - ln.Point0.Y) * ln.Kz - (pt.Z - ln.Point0.Z) * ln.Ky) < solveerror);
        }

        #endregion

        #region IsCoincides of Lines

        public static bool IsCoincides(this Line2D ln1, Line2D ln2)
        {
            return ln2.IsIncidentalToPoint(ln1.Point0) && ln2.IsIncidentalToPoint(ln1.Point1);
        }

        public static bool IsCoincides(this Line3D ln1, Line3D ln2)
        {
            return ln2.IsIncidentalToPoint(ln1.Point0) && ln2.IsIncidentalToPoint(ln1.Point1);
        }

        public static bool IsCoincides(this LineOfPlane1X0Y ln1, LineOfPlane1X0Y ln2)
        {
            return IsCoincides(ln1.ToLine2D(), ln2.ToLine2D());
        }

        public static bool IsCoincides(this LineOfPlane2X0Z ln1, LineOfPlane2X0Z ln2)
        {
            return IsCoincides(ln1.ToLine2D(), ln2.ToLine2D());
        }

        public static bool IsCoincides(this LineOfPlane3Y0Z ln1, LineOfPlane3Y0Z ln2)
        {
            return IsCoincides(ln1.ToLine2D(), ln2.ToLine2D());
        }

        #endregion

        #region IsParallel of Lines

        public static bool IsParallel(this Line2D ln1, Line2D ln2)
        {
            return Math.Abs(ln1.kx - ln2.kx) < 0.001 || Math.Abs(ln1.ky - ln2.ky) < 0.001;
        }

        public static bool IsParallel(this Line2D ln1, Line2D ln2, double solveerror)
        {
            return Math.Abs(ln1.kx - ln2.kx) < solveerror || Math.Abs(ln1.ky - ln2.ky) < solveerror;
        }

        public static bool IsParallel(this Line3D ln1, Line3D ln2)
        {
            return Math.Abs(ln1.Kx - ln2.Kx) < 0.001 || Math.Abs(ln1.Ky - ln2.Ky) < 0.001 || Math.Abs(ln1.Kz - ln2.Kz) < 0.001;
        }

        public static bool IsParallel(this Line3D ln1, Line3D ln2, double solveerror)
        {
            return Math.Abs(ln1.Kx - ln2.Kx) < solveerror || Math.Abs(ln1.Ky - ln2.Ky) < solveerror || Math.Abs(ln1.Kz - ln2.Kz) < solveerror;
        }

        public static bool IsParallel(this Line3D ln1, LineOfPlane1X0Y ln2)
        {
            return IsParallel(ln1.LineOfPlane1X0Y, ln2);
        }

        public static bool IsParallel(this Line3D ln1, LineOfPlane2X0Z ln2)
        {
            return IsParallel(ln1.LineOfPlane2X0Z, ln2);
        }

        public static bool IsParallel(this Line3D ln1, LineOfPlane3Y0Z ln2)
        {
            return IsParallel(ln1.LineOfPlane3Y0Z, ln2);
        }

        public static bool IsParallel(this Line3D ln1, LineOfPlane1X0Y ln2, double solveerror)
        {
            return Math.Abs(ln1.LineOfPlane1X0Y.Kx - ln2.Kx) < solveerror || Math.Abs(ln1.LineOfPlane1X0Y.Ky - ln2.Ky) < solveerror;
        }

        public static bool IsParallel(this Line3D ln1, ILineOfPlane ln)
        {
            if (ln is LineOfPlane1X0Y)
            {
                return IsParallel(ln1.LineOfPlane1X0Y, (LineOfPlane1X0Y) ln);
            }
            if (ln is LineOfPlane2X0Z)
            {
                return IsParallel(ln1.LineOfPlane2X0Z, (LineOfPlane2X0Z) ln);
            }
            return IsParallel(ln1.LineOfPlane3Y0Z, (LineOfPlane3Y0Z)ln);
        }

        public static bool IsParallel(this LineOfPlane1X0Y ln1, LineOfPlane1X0Y ln2)
        {
            return Math.Abs(ln1.Kx - ln2.Kx) < 0.001 || Math.Abs(ln1.Ky - ln2.Ky) < 0.001;
        }

        public static bool IsParallel(this LineOfPlane2X0Z ln1, LineOfPlane2X0Z ln2)
        {
            return Math.Abs(ln1.Kx - ln2.Kx) < 0.001 || Math.Abs(ln1.Kz - ln2.Kz) < 0.001;
        }

        public static bool IsParallel(this LineOfPlane3Y0Z ln1, LineOfPlane3Y0Z ln2)
        {
            return Math.Abs(ln1.Kz - ln2.Kz) < 0.001 || Math.Abs(ln1.Ky - ln2.Ky) < 0.001;
        }

        public static bool IsParallel(this SegmentOfPlane1X0Y sg1, SegmentOfPlane1X0Y sg2)
        {
            return Math.Abs(sg1.Kx - sg2.Kx) < 0.001 || Math.Abs(sg1.Ky - sg2.Ky) < 0.001;
        }

        public static bool IsParallel(this SegmentOfPlane2X0Z sg1, SegmentOfPlane2X0Z sg2)
        {
            return Math.Abs(sg1.Kx - sg2.Kx) < 0.001 || Math.Abs(sg1.Kz - sg2.Kz) < 0.001;
        }

        public static bool IsParallel(this SegmentOfPlane3Y0Z sg1, SegmentOfPlane3Y0Z sg2)
        {
            return Math.Abs(sg1.Kz - sg2.Kz) < 0.001 || Math.Abs(sg1.Ky - sg2.Ky) < 0.001;
        }

        #endregion

        #region IsCrossed of lines

        public static bool IsCrossed(this Line2D ln1, Line2D ln2)
        {
            var y = (ln2.Point0.Y * ln2.kx * ln1.ky - ln1.Point0.Y * ln2.ky * ln1.kx + ln2.ky * ln1.ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.kx * ln1.ky - ln1.kx * ln2.ky);
            var x = ln1.kx * (y - ln1.Point0.Y) / ln1.ky + ln1.Point0.X;
            return !(y < 0) && !(x < 0);
        }

        public static bool IsCrossed(this Line2D ln1, LineOfPlane1X0Y ln, Point frameCenter)
        {
            var ln2 = DeterminePosition.ForLineProjection(ln, frameCenter);
            var y = (ln2.Point0.Y * ln2.kx * ln1.ky - ln1.Point0.Y * ln2.ky * ln1.kx + ln2.ky * ln1.ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.kx * ln1.ky - ln1.kx * ln2.ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.kx * ln1.ky - ln2.Point0.X * ln1.kx * ln2.ky + ln2.kx * ln1.kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.ky * ln2.kx - ln1.kx * ln2.ky);
            return !(x < 0);
        }

        public static bool IsCrossed(this Line2D ln1, LineOfPlane2X0Z ln, Point frameCenter)
        {
            var ln2 = DeterminePosition.ForLineProjection(ln, frameCenter);
            var y = (ln2.Point0.Y * ln2.kx * ln1.ky - ln1.Point0.Y * ln2.ky * ln1.kx + ln2.ky * ln1.ky * (ln1.Point0.X - ln2.Point0.X)) /
                     (ln2.kx * ln1.ky - ln1.kx * ln2.ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.kx * ln1.ky - ln2.Point0.X * ln1.kx * ln2.ky + ln2.kx * ln1.kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.ky * ln2.kx - ln1.kx * ln2.ky);
            return !(x < 0);
        }

        public static bool IsCrossed(this Line2D ln1, LineOfPlane3Y0Z ln, Point frameCenter)
        {
            var ln2 = DeterminePosition.ForLineProjection(ln, frameCenter);
            var y = (ln2.Point0.Y * ln2.kx * ln1.ky - ln1.Point0.Y * ln2.ky * ln1.kx + ln2.ky * ln1.ky * (ln1.Point0.X - ln2.Point0.X)) /
                     (ln2.kx * ln1.ky - ln1.kx * ln2.ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.kx * ln1.ky - ln2.Point0.X * ln1.kx * ln2.ky + ln2.kx * ln1.kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.ky * ln2.kx - ln1.kx * ln2.ky);
            return !(x < 0);
        }

        public static bool IsCrossed(this LineOfPlane1X0Y lnOfPlane1, LineOfPlane1X0Y lnOfPlane2, Point frameCenter)
        {
            var ln1 = DeterminePosition.ForLineProjection(lnOfPlane1, frameCenter);
            var ln2 = DeterminePosition.ForLineProjection(lnOfPlane2, frameCenter);
            var y = (ln2.Point0.Y * ln2.kx * ln1.ky - ln1.Point0.Y * ln2.ky * ln1.kx + ln2.ky * ln1.ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.kx * ln1.ky - ln1.kx * ln2.ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.kx * ln1.ky - ln2.Point0.X * ln1.kx * ln2.ky + ln2.kx * ln1.kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.ky * ln2.kx - ln1.kx * ln2.ky);
            return !(x < 0);
        }

        public static bool IsCrossed(this LineOfPlane2X0Z lnOfPlane1, LineOfPlane2X0Z lnOfPlane2, Point frameCenter)
        {
            var ln1 = DeterminePosition.ForLineProjection(lnOfPlane1, frameCenter);
            var ln2 = DeterminePosition.ForLineProjection(lnOfPlane2, frameCenter);
            var y = (ln2.Point0.Y * ln2.kx * ln1.ky - ln1.Point0.Y * ln2.ky * ln1.kx + ln2.ky * ln1.ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.kx * ln1.ky - ln1.kx * ln2.ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.kx * ln1.ky - ln2.Point0.X * ln1.kx * ln2.ky + ln2.kx * ln1.kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.ky * ln2.kx - ln1.kx * ln2.ky);
            return !(x < 0);
        }

        public static bool IsCrossed(this LineOfPlane3Y0Z lnOfPlane1, LineOfPlane3Y0Z lnOfPlane2, Point frameCenter)
        {
            var ln1 = DeterminePosition.ForLineProjection(lnOfPlane1, frameCenter);
            var ln2 = DeterminePosition.ForLineProjection(lnOfPlane2, frameCenter);
            var y = (ln2.Point0.Y * ln2.kx * ln1.ky - ln1.Point0.Y * ln2.ky * ln1.kx + ln2.ky * ln1.ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.kx * ln1.ky - ln1.kx * ln2.ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.kx * ln1.ky - ln2.Point0.X * ln1.kx * ln2.ky + ln2.kx * ln1.kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.ky * ln2.kx - ln1.kx * ln2.ky);
            return !(x < 0);
        }

        public static bool IsCrossed(this SegmentOfPlane1X0Y lnOfPlane1, SegmentOfPlane1X0Y lnOfPlane2, Point frameCenter)
        {
            var ln1 = DeterminePosition.ForSegmentProjection(lnOfPlane1, frameCenter);
            var ln2 = DeterminePosition.ForSegmentProjection(lnOfPlane2, frameCenter);
            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx + ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.Kx * ln1.Ky - ln2.Point0.X * ln1.Kx * ln2.Ky + ln2.Kx * ln1.Kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.Ky * ln2.Kx - ln1.Kx * ln2.Ky);
            return !(x < 0);
        }

        public static bool IsCrossed(this SegmentOfPlane2X0Z lnOfPlane1, SegmentOfPlane2X0Z lnOfPlane2, Point frameCenter)
        {
            var ln1 = DeterminePosition.ForSegmentProjection(lnOfPlane1, frameCenter);
            var ln2 = DeterminePosition.ForSegmentProjection(lnOfPlane2, frameCenter);
            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx + ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.Kx * ln1.Ky - ln2.Point0.X * ln1.Kx * ln2.Ky + ln2.Kx * ln1.Kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.Ky * ln2.Kx - ln1.Kx * ln2.Ky);
            return !(x < 0);
        }

        public static bool IsCrossed(this SegmentOfPlane3Y0Z lnOfPlane1, SegmentOfPlane3Y0Z lnOfPlane2, Point frameCenter)
        {
            var ln1 = DeterminePosition.ForSegmentProjection(lnOfPlane1, frameCenter);
            var ln2 = DeterminePosition.ForSegmentProjection(lnOfPlane2, frameCenter);
            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx + ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.Kx * ln1.Ky - ln2.Point0.X * ln1.Kx * ln2.Ky + ln2.Kx * ln1.Kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.Ky * ln2.Kx - ln1.Kx * ln2.Ky);
            return !(x < 0);
        }

        #endregion
    }
}
