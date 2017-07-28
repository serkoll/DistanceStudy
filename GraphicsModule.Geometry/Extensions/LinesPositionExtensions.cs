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

        #region IsCrossed

        [Obsolete]
        public static bool IsCrossed(this Line2D ln1, Line2D ln2)
        {
            const int solveError = 5;
            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx +
                     ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            var x = ln1.Kx * (y - ln1.Point0.Y) / ln1.Ky + ln1.Point0.X;
            if (Math.Abs(y) < solveError)
            {
                y = 0;
            }
            if (Math.Abs(x) < solveError)
            {
                x = 0;
            }
            return (y > 0) && (x >= 0);
        }

        [Obsolete]
        public static bool IsCrossed(this Line2D ln1, LineOfPlane1X0Y ln, Point frameCenter)
        {
            var ln2 = ln.ToGlobalCoordinatesLine2D(frameCenter);
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

        [Obsolete]
        public static bool IsCrossed(this Line2D ln1, LineOfPlane2X0Z ln, Point frameCenter)
        {
            var ln2 = ln.ToGlobalCoordinatesLine2D(frameCenter);
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

        [Obsolete]
        public static bool IsCrossed(this Line2D ln1, LineOfPlane3Y0Z ln, Point frameCenter)
        {
            var ln2 = ln.ToGlobalCoordinatesLine2D(frameCenter);
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

        [Obsolete]
        public static bool IsCrossed(this LineOfPlane1X0Y lnOfPlane1, LineOfPlane1X0Y lnOfPlane2, Point frameCenter)
        {
            var ln1 = lnOfPlane1.ToGlobalCoordinatesLine2D(frameCenter);
            var ln2 = lnOfPlane2.ToGlobalCoordinatesLine2D(frameCenter);
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

        [Obsolete]
        public static bool IsCrossed(this LineOfPlane2X0Z lnOfPlane1, LineOfPlane2X0Z lnOfPlane2, Point frameCenter)
        {
            var ln1 = lnOfPlane1.ToGlobalCoordinatesLine2D(frameCenter);
            var ln2 = lnOfPlane2.ToGlobalCoordinatesLine2D(frameCenter);
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

        [Obsolete]
        public static bool IsCrossed(this LineOfPlane3Y0Z lnOfPlane1, LineOfPlane3Y0Z lnOfPlane2, Point frameCenter)
        {
            var ln1 = lnOfPlane1.ToGlobalCoordinatesLine2D(frameCenter);
            var ln2 = lnOfPlane2.ToGlobalCoordinatesLine2D(frameCenter);
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

        [Obsolete]
        public static bool IsCrossed(this SegmentOfPlane1X0Y lnOfPlane1, SegmentOfPlane1X0Y lnOfPlane2,
            Point frameCenter)
        {
            var ln1 = lnOfPlane1.ToGlobalCoordinatesSegment(frameCenter);
            var ln2 = lnOfPlane2.ToGlobalCoordinatesSegment(frameCenter);
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

        [Obsolete]
        public static bool IsCrossed(this SegmentOfPlane2X0Z lnOfPlane1, SegmentOfPlane2X0Z lnOfPlane2,
            Point frameCenter)
        {
            var ln1 = lnOfPlane1.ToGlobalCoordinatesSegment(frameCenter);
            var ln2 = lnOfPlane2.ToGlobalCoordinatesSegment(frameCenter);
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

        [Obsolete]
        public static bool IsCrossed(this SegmentOfPlane3Y0Z lnOfPlane1, SegmentOfPlane3Y0Z lnOfPlane2,
            Point frameCenter)
        {
            var ln1 = lnOfPlane1.ToGlobalCoordinatesSegment(frameCenter);
            var ln2 = lnOfPlane2.ToGlobalCoordinatesSegment(frameCenter);
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

        #region Intersect

        /// <summary>
        /// Вычисляет определитель матрицы системы, состоящей из двух прямых, описанных в общем виде
        /// </summary>
        /// <param name="ln1"></param>
        /// <param name="ln2"></param>
        /// <returns>Значение определителя</returns>
        private static double CalculateDeterminant(ILine ln1, ILine ln2)
        {
            return CalculateDeterminant(ln1.Coefficients.A, ln1.Coefficients.B, ln2.Coefficients.A, ln2.Coefficients.B);
        }

        /// <summary>
        /// Вычисляет определитель матрицы вида |a c|
        ///                                     |b d|
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        private static double CalculateDeterminant(double a, double b, double c, double d)
        {
            return a * d - b * c;
        }

        /// <summary>
        /// Определяет, пересекаются ли заданные прямые
        /// </summary>
        /// <param name="ln1"></param>
        /// <param name="ln2"></param>
        /// <returns></returns>
        public static bool IsIntersect(this Line2D ln1, Line2D ln2)
        {
            var det = CalculateDeterminant(ln1, ln2);
            return !(det < Constants.Tolerance);
        }

        /// <summary>
        /// Определяет, пресекаются ли заданные прямые в границах текущей области
        /// </summary>
        /// <param name="ln1"></param>
        /// <param name="ln2"></param>
        /// <param name="frame">Прямоугольник, описывающий текущую область</param>
        /// <returns></returns>
        public static bool IsIntersect(this Line2D ln1, Line2D ln2, Rectangle frame)
        {
            return GetIntersectPoint(ln1, ln2, frame) != null;
        }

        #endregion

        //TODO: сделать equivalent и parallel функции на основе этих

        #region Get intersect point

        /// <summary>
        /// Возвращает точку пересечения двух прямых
        /// </summary>
        /// <param name="ln1"></param>
        /// <param name="ln2"></param>
        /// <returns>Null, если совпадают или параллельны</returns>
        public static Point2D GetIntersectPoint(this Line2D ln1, Line2D ln2)
        {
            var det = CalculateDeterminant(ln1, ln2);
            if (Math.Abs(det) < Constants.Tolerance)
            {
                return null;
            }
            var x = -CalculateDeterminant(ln1.Coefficients.C, ln1.Coefficients.B, ln2.Coefficients.C,
                        ln2.Coefficients.B) / det;
            var y = -CalculateDeterminant(ln1.Coefficients.A, ln1.Coefficients.B, ln2.Coefficients.A,
                        ln2.Coefficients.B) / det;
            return new Point2D(x, y);
        }

        /// <summary>
        /// Возвращает точку пересечения двух прямых в заданной области
        /// </summary>
        /// <param name="ln1"></param>
        /// <param name="ln2"></param>
        /// <param name="frame"></param>
        /// <returns>Null, если не пересекаются</returns>
        public static Point2D GetIntersectPoint(this Line2D ln1, Line2D ln2, Rectangle frame)
        {
            var ipt = GetIntersectPoint(ln1, ln2);
            if (ipt == null)
            {
                return null;
            }
            if (ipt.X < frame.Left || ipt.X < frame.Right ||
                ipt.Y < frame.Top || ipt.Y > frame.Bottom)
            {
                return null;
            }
            return ipt;
        }

        #endregion

        #region Equivalent

        public static bool IsEquivalent(this Line2D ln1, Line2D ln2)
        {
            var ln1C = ln1.Coefficients;
            var ln2C = ln2.Coefficients;

            return Math.Abs(CalculateDeterminant(ln1C.A, ln1C.B, ln2C.A, ln2C.B)) < Constants.Tolerance
                   && Math.Abs(CalculateDeterminant(ln1C.A, ln1C.C, ln2C.A, ln2C.C)) < Constants.Tolerance
                   && Math.Abs(CalculateDeterminant(ln1C.B, ln1C.C, ln2C.B, ln2C.C)) < Constants.Tolerance;
        }

        #endregion
    }
}



