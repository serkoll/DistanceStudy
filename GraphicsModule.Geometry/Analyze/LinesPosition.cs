using System;
using System.Drawing;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;

namespace GraphicsModule.Geometry.Analyze
{
    public class LinesPosition
    {
        #region Incidence of Point and Line
        public bool IncidenceOfPoint(Point pt, Line2D ln)
        {
            return Math.Abs((pt.X - ln.Point0.X) * ln.ky - (pt.Y - ln.Point0.Y) * ln.kx) < 0.001;
        }
        public bool IncidenceOfPoint(Point pt, Line2D ln, double solveerror)
        {
            return Math.Abs((pt.X - ln.Point0.X) * ln.ky - (pt.Y - ln.Point0.Y) * ln.kx) < solveerror;
        }
        public bool IncidenceOfPoint(Point2D pt, Line2D ln)
        {
            return Math.Abs((pt.X - ln.Point0.X) * ln.ky - (pt.Y - ln.Point0.Y) * ln.kx) < 0.001;
        }

        public bool IncidenceOfPoint(Point2D pt, Line2D ln, double solveerror)
        {
            return Math.Abs((pt.X - ln.Point0.X) * ln.ky - (pt.Y - ln.Point0.Y) * ln.kx) < solveerror;
        }

        public bool IncidenceOfPoint(Point3D pt, Line3D ln)
        {
            return (Math.Abs((pt.X - ln.Point0.X) * ln.ky - (pt.Y - ln.Point0.Y) * ln.kx) < 0.001) &&
                   (Math.Abs((pt.X - ln.Point0.X) * ln.kz - (pt.Z - ln.Point0.Z) * ln.kx) < 0.001) &&
                   (Math.Abs((pt.Y - ln.Point0.Y) * ln.kz - (pt.Z - ln.Point0.Z) * ln.ky) < 0.001);
        }

        public bool IncidenceOfPoint(Point3D pt, Line3D ln, double solveerror)
        {
            return (Math.Abs((pt.X - ln.Point0.X) * ln.ky - (pt.Y - ln.Point0.Y) * ln.kx) < solveerror) &&
                   (Math.Abs((pt.X - ln.Point0.X) * ln.kz - (pt.Z - ln.Point0.Z) * ln.kx) < solveerror) &&
                   (Math.Abs((pt.Y - ln.Point0.Y) * ln.kz - (pt.Z - ln.Point0.Z) * ln.ky) < solveerror);
        }
        #endregion
        #region Coincidence of Lines
        public bool Coincidence(Line2D ln1, Line2D ln2)
        {
            return IncidenceOfPoint(ln1.Point0, ln2) && IncidenceOfPoint(ln1.Point1, ln2);
        }
        public bool Coincidence(Line3D ln1, Line3D ln2)
        {
            return IncidenceOfPoint(ln1.Point0, ln2) && IncidenceOfPoint(ln1.Point1, ln2);
        }
        public bool Coincidence(LineOfPlane1X0Y ln1, LineOfPlane1X0Y ln2)
        {
            return Coincidence(Cnv.ToLine2D(ln1), Cnv.ToLine2D(ln2));
        }
        public bool Coincidence(LineOfPlane2X0Z ln1, LineOfPlane2X0Z ln2)
        {
            return Coincidence(Cnv.ToLine2D(ln1), Cnv.ToLine2D(ln2));
        }
        public bool Coincidence(LineOfPlane3Y0Z ln1, LineOfPlane3Y0Z ln2)
        {
            return Coincidence(Cnv.ToLine2D(ln1), Cnv.ToLine2D(ln2));
        }
        #endregion
        #region Parallelism of Lines
        public bool Parallelism(Line2D ln1, Line2D ln2)
        {
            return Math.Abs(ln1.kx - ln2.kx) < 0.001 || Math.Abs(ln1.ky - ln2.ky) < 0.001;
        }
        public bool Parallelism(Line2D ln1, Line2D ln2, double solveerror)
        {
            return Math.Abs(ln1.kx - ln2.kx) < solveerror || Math.Abs(ln1.ky - ln2.ky) < solveerror;
        }
        public bool Parallelism(Line3D ln1, Line3D ln2)
        {
            return Math.Abs(ln1.kx - ln2.kx) < 0.001 || Math.Abs(ln1.ky - ln2.ky) < 0.001 || Math.Abs(ln1.kz - ln2.kz) < 0.001;
        }
        public bool Parallelism(Line3D ln1, Line3D ln2, double solveerror)
        {
            return Math.Abs(ln1.kx - ln2.kx) < solveerror || Math.Abs(ln1.ky - ln2.ky) < solveerror || Math.Abs(ln1.kz - ln2.kz) < solveerror;
        }
        public bool Parallelism(Line3D ln1, LineOfPlane1X0Y ln2)
        {
            return Parallelism(ln1.LineOfPlane1X0Y, ln2);
        }
        public bool Parallelism(Line3D ln1, LineOfPlane2X0Z ln2)
        {
            return Parallelism(ln1.LineOfPlane2X0Z, ln2);
        }
        public bool Parallelism(Line3D ln1, LineOfPlane3Y0Z ln2)
        {
            return Parallelism(ln1.LineOfPlane3Y0Z, ln2);
        }
        public bool Parallelism(Line3D ln1, LineOfPlane1X0Y ln2, double solveerror)
        {
            return Math.Abs(ln1.LineOfPlane1X0Y.Kx - ln2.Kx) < solveerror || Math.Abs(ln1.LineOfPlane1X0Y.Ky - ln2.Ky) < solveerror;
        }
        public bool Parallelism(Line3D ln1, ILineOfPlane ln)
        {
            var type = ln.GetType();
            if (type == typeof(LineOfPlane1X0Y))
                return Parallelism(ln1.LineOfPlane1X0Y, (LineOfPlane1X0Y)ln);
            if (type == typeof(LineOfPlane2X0Z))
                return Parallelism(ln1.LineOfPlane2X0Z, (LineOfPlane2X0Z)ln);
            return Parallelism(ln1.LineOfPlane3Y0Z, (LineOfPlane3Y0Z)ln);
        }
        public bool Parallelism(LineOfPlane1X0Y ln1, LineOfPlane1X0Y ln2)
        {
            return Math.Abs(ln1.Kx - ln2.Kx) < 0.001 || Math.Abs(ln1.Ky - ln2.Ky) < 0.001;
        }
        public bool Parallelism(LineOfPlane2X0Z ln1, LineOfPlane2X0Z ln2)
        {
            return Math.Abs(ln1.Kx - ln2.Kx) < 0.001 || Math.Abs(ln1.Kz - ln2.Kz) < 0.001;
        }
        public bool Parallelism(LineOfPlane3Y0Z ln1, LineOfPlane3Y0Z ln2)
        {
            return Math.Abs(ln1.Kz - ln2.Kz) < 0.001 || Math.Abs(ln1.Ky - ln2.Ky) < 0.001;
        }
        public bool Parallelism(SegmentOfPlane1X0Y sg1, SegmentOfPlane1X0Y sg2)
        {
            return Math.Abs(sg1.kx - sg2.kx) < 0.001 || Math.Abs(sg1.ky - sg2.ky) < 0.001;
        }
        public bool Parallelism(SegmentOfPlane2X0Z sg1, SegmentOfPlane2X0Z sg2)
        {
            return Math.Abs(sg1.kx - sg2.kx) < 0.001 || Math.Abs(sg1.kz - sg2.kz) < 0.001;
        }
        public bool Parallelism(SegmentOfPlane3Y0Z sg1, SegmentOfPlane3Y0Z sg2)
        {
            return Math.Abs(sg1.kz - sg2.kz) < 0.001 || Math.Abs(sg1.ky - sg2.ky) < 0.001;
        }
        #endregion
        #region Crossing of lines
        public bool Crossing(Line2D ln1, Line2D ln2)
        {
            var y = (ln2.Point0.Y * ln2.kx * ln1.ky - ln1.Point0.Y * ln2.ky * ln1.kx + ln2.ky * ln1.ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.kx * ln1.ky - ln1.kx * ln2.ky);
            var x = ln1.kx * (y - ln1.Point0.Y) / ln1.ky + ln1.Point0.X;
            return !(y < 0) && !(x < 0);
        }
        public bool Crossing(Line2D ln1, LineOfPlane1X0Y ln, Point frameCenter)
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
        public bool Crossing(Line2D ln1, LineOfPlane2X0Z ln, Point frameCenter)
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
        public bool Crossing(Line2D ln1, LineOfPlane3Y0Z ln, Point frameCenter)
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
        public bool Crossing(LineOfPlane1X0Y lnOfPlane1, LineOfPlane1X0Y lnOfPlane2, Point frameCenter)
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
        public bool Crossing(LineOfPlane2X0Z lnOfPlane1, LineOfPlane2X0Z lnOfPlane2, Point frameCenter)
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
        public bool Crossing(LineOfPlane3Y0Z lnOfPlane1, LineOfPlane3Y0Z lnOfPlane2, Point frameCenter)
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
        public bool Crossing(SegmentOfPlane1X0Y lnOfPlane1, SegmentOfPlane1X0Y lnOfPlane2, Point frameCenter)
        {
            var ln1 = DeterminePosition.ForSegmentProjection(lnOfPlane1, frameCenter);
            var ln2 = DeterminePosition.ForSegmentProjection(lnOfPlane2, frameCenter);
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
        public bool Crossing(SegmentOfPlane2X0Z lnOfPlane1, SegmentOfPlane2X0Z lnOfPlane2, Point frameCenter)
        {
            var ln1 = DeterminePosition.ForSegmentProjection(lnOfPlane1, frameCenter);
            var ln2 = DeterminePosition.ForSegmentProjection(lnOfPlane2, frameCenter);
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
        public bool Crossing(SegmentOfPlane3Y0Z lnOfPlane1, SegmentOfPlane3Y0Z lnOfPlane2, Point frameCenter)
        {
            var ln1 = DeterminePosition.ForSegmentProjection(lnOfPlane1, frameCenter);
            var ln2 = DeterminePosition.ForSegmentProjection(lnOfPlane2, frameCenter);
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
        #endregion
        #region Direction of Line
        /// <summary>
        /// Направление не реализовано
        /// </summary>
        /// <param name="ln1"></param>
        /// <param name="ln2"></param>
        /// <returns></returns>
        public bool DirectionCoincidence(Line3D ln1, Line3D ln2)
        {
            return true;
        }
        #endregion
        #region Point Of Crossing 

        #endregion
    }
}
