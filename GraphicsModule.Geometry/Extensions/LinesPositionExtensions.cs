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
        private static int Tolerance = 5;

        #region Incidence of Point and Line

        public static bool IsIncidentalToPoint(this Line2D ln, Point pt)
        {
            return Math.Abs((pt.X - ln.Point0.X) * ln.Ky - (pt.Y - ln.Point0.Y) * ln.Kx) < 0.001;
        }

        public static bool IsIncidentalToPoint(this Line2D ln, Point pt, double solveerror)
        {
            return Math.Abs((pt.X - ln.Point0.X) * ln.Ky - (pt.Y - ln.Point0.Y) * ln.Kx) < solveerror;
        }

        public static bool IsIncidentalToPoint(this Line2D ln, Point2D pt)
        {
            return Math.Abs((pt.X - ln.Point0.X) * ln.Ky - (pt.Y - ln.Point0.Y) * ln.Kx) < 0.001;
        }

        public static bool IsIncidentalToPoint(this Line2D ln, Point2D pt, double solveerror)
        {
            return Math.Abs((pt.X - ln.Point0.X) * ln.Ky - (pt.Y - ln.Point0.Y) * ln.Kx) < solveerror;
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
            return Math.Abs(ln1.Kx - ln2.Kx) < 0.001 || Math.Abs(ln1.Ky - ln2.Ky) < 0.001;
        }

        public static bool IsParallel(this Line2D ln1, Line2D ln2, double solveerror)
        {
            return Math.Abs(ln1.Kx - ln2.Kx) < solveerror || Math.Abs(ln1.Ky - ln2.Ky) < solveerror;
        }

        public static bool IsParallel(this Line3D ln1, Line3D ln2)
        {
            return Math.Abs(ln1.Kx - ln2.Kx) < 0.001 || Math.Abs(ln1.Ky - ln2.Ky) < 0.001 ||
                   Math.Abs(ln1.Kz - ln2.Kz) < 0.001;
        }

        public static bool IsParallel(this Line3D ln1, Line3D ln2, double solveerror)
        {
            return Math.Abs(ln1.Kx - ln2.Kx) < solveerror || Math.Abs(ln1.Ky - ln2.Ky) < solveerror ||
                   Math.Abs(ln1.Kz - ln2.Kz) < solveerror;
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
            return Math.Abs(ln1.LineOfPlane1X0Y.Kx - ln2.Kx) < solveerror ||
                   Math.Abs(ln1.LineOfPlane1X0Y.Ky - ln2.Ky) < solveerror;
        }

        public static bool IsParallel(this Line3D ln1, ILineOfPlane ln)
        {
            if (ln is LineOfPlane1X0Y)
            {
                return IsParallel(ln1.LineOfPlane1X0Y, (LineOfPlane1X0Y)ln);
            }
            if (ln is LineOfPlane2X0Z)
            {
                return IsParallel(ln1.LineOfPlane2X0Z, (LineOfPlane2X0Z)ln);
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

        #endregion

        #region IsIntersect

        public static bool IsIntersect(this Line2D ln1, Line2D ln2)
        {
            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx +
                     ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            var x = ln1.Kx * (y - ln1.Point0.Y) / ln1.Ky + ln1.Point0.X;
            if (Math.Abs(y) < Constants.Tolerance)
            {
                y = 0;
            }
            if (Math.Abs(x) < Constants.Tolerance)
            {
                x = 0;
            }
            return (y > 0) && (x >= 0);
        }

        public static bool IsIntersect(this Line2D ln1, LineOfPlane1X0Y ln, Point coordinateSystemCenter)
        {
            var ln2 = ln.ToGlobalCoordinates(coordinateSystemCenter);
            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx +
                     ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            if (Math.Abs(y) < Constants.Tolerance)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.Kx * ln1.Ky - ln2.Point0.X * ln1.Kx * ln2.Ky +
                     ln2.Kx * ln1.Kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.Ky * ln2.Kx - ln1.Kx * ln2.Ky);
            return !(Math.Abs(x) < Constants.Tolerance);
        }

        public static bool IsIntersect(this Line2D ln1, LineOfPlane2X0Z ln, Point coordinateSystemCenter)
        {
            var ln2 = ln.ToGlobalCoordinates(coordinateSystemCenter);
            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx +
                     ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.Kx * ln1.Ky - ln2.Point0.X * ln1.Kx * ln2.Ky +
                     ln2.Kx * ln1.Kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.Ky * ln2.Kx - ln1.Kx * ln2.Ky);
            return !(x < 0);
        }

        public static bool IsIntersect(this Line2D ln1, LineOfPlane3Y0Z ln, Point coordinateSystemCenter)
        {
            var ln2 = ln.ToGlobalCoordinates(coordinateSystemCenter);
            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx +
                     ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.Kx * ln1.Ky - ln2.Point0.X * ln1.Kx * ln2.Ky +
                     ln2.Kx * ln1.Kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.Ky * ln2.Kx - ln1.Kx * ln2.Ky);
            return !(x < 0);
        }

        public static bool IsIntersect(this LineOfPlane1X0Y lnOfPlane1, LineOfPlane1X0Y lnOfPlane2, Point coordinateSystemCenter)
        {
            var ln1 = lnOfPlane1.ToGlobalCoordinates(coordinateSystemCenter);
            var ln2 = lnOfPlane2.ToGlobalCoordinates(coordinateSystemCenter);
            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx +
                     ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.Kx * ln1.Ky - ln2.Point0.X * ln1.Kx * ln2.Ky +
                     ln2.Kx * ln1.Kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.Ky * ln2.Kx - ln1.Kx * ln2.Ky);
            return !(x < 0);
        }

        public static bool IsIntersect(this LineOfPlane2X0Z lnOfPlane1, LineOfPlane2X0Z lnOfPlane2, Point coordinateSystemCenter)
        {
            var ln1 = lnOfPlane1.ToGlobalCoordinates(coordinateSystemCenter);
            var ln2 = lnOfPlane2.ToGlobalCoordinates(coordinateSystemCenter);
            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx +
                     ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.Kx * ln1.Ky - ln2.Point0.X * ln1.Kx * ln2.Ky +
                     ln2.Kx * ln1.Kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.Ky * ln2.Kx - ln1.Kx * ln2.Ky);
            return !(x < 0);
        }

        public static bool IsIntersect(this LineOfPlane3Y0Z sg1, LineOfPlane3Y0Z sg2, Point coordinateSystemCenter)
        {
            var ln1 = sg1.ToGlobalCoordinates(coordinateSystemCenter);
            var ln2 = sg2.ToGlobalCoordinates(coordinateSystemCenter);
            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx +
                     ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.Kx * ln1.Ky - ln2.Point0.X * ln1.Kx * ln2.Ky +
                     ln2.Kx * ln1.Kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.Ky * ln2.Kx - ln1.Kx * ln2.Ky);
            return !(x < 0);
        }

        public static bool IsIntersect(this SegmentOfPlane1X0Y sg1, SegmentOfPlane1X0Y sg2, Point coordinateSystemCenter)
        {
            var ln1 = sg1.ToGlobalCoordinates(coordinateSystemCenter);
            var ln2 = sg2.ToGlobalCoordinates(coordinateSystemCenter);
            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx +
                     ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.Kx * ln1.Ky - ln2.Point0.X * ln1.Kx * ln2.Ky +
                     ln2.Kx * ln1.Kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.Ky * ln2.Kx - ln1.Kx * ln2.Ky);
            return !(x < 0);
        }

        public static bool IsIntersect(this SegmentOfPlane2X0Z sg1, SegmentOfPlane2X0Z sg2, Point coordinateSystemCenter)
        {
            var ln1 = sg1.ToGlobalCoordinates(coordinateSystemCenter);
            var ln2 = sg2.ToGlobalCoordinates(coordinateSystemCenter);
            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx +
                     ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.Kx * ln1.Ky - ln2.Point0.X * ln1.Kx * ln2.Ky +
                     ln2.Kx * ln1.Kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.Ky * ln2.Kx - ln1.Kx * ln2.Ky);
            return !(x < 0);
        }

        public static bool IsIntersect(this SegmentOfPlane3Y0Z lnOfPlane1, SegmentOfPlane3Y0Z lnOfPlane2, Point coordinateSystemCenter)
        {
            var ln1 = lnOfPlane1.ToGlobalCoordinates(coordinateSystemCenter);
            var ln2 = lnOfPlane2.ToGlobalCoordinates(coordinateSystemCenter);
            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx +
                     ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.Kx * ln1.Ky - ln2.Point0.X * ln1.Kx * ln2.Ky +
                     ln2.Kx * ln1.Kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.Ky * ln2.Kx - ln1.Kx * ln2.Ky);
            return !(x < 0);
        }

        #endregion

        #region Get Intersect Point

        

        #endregion
    }
}



