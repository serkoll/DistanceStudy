using System;
using System.Drawing;
using GraphicsModule.Geometry.Objects.Line;
using GraphicsModule.Geometry.Objects.Point;
using GraphicsModule.Geometry.Planes;

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

        #region Incidence Of Plane
        public bool IncidenceOfOnePlane(Line3D ln1, Line3D ln2)
        {
            var mrx = new MatrixEvalution.MatrixEvalution();
            var dx = ln2.Point0.X - ln1.Point0.X;
            var dy = ln2.Point0.Y - ln1.Point0.Y;
            var dz = ln2.Point0.Z - ln1.Point0.Z;
            double[,] detlines = { { dx, dy, dz },
                                                { ln1.kx, ln1.ky, ln1.kz},
                                                { ln2.kx, ln2.ky, ln2.kz}};
            var dt = mrx.detMrx3x3(detlines);
            return Math.Abs(dt) <= 0.001;
        }

        public bool IncidenceOfOnePlane(Line3D ln1, Line3D ln2, double solveerror)
        {
            var mrx = new MatrixEvalution.MatrixEvalution();
            var dx = ln2.Point0.X - ln1.Point0.X;
            var dy = ln2.Point0.Y - ln1.Point0.Y;
            var dz = ln2.Point0.Z - ln1.Point0.Z;
            double[,] detlines = { { dx, dy, dz },
                                                { ln1.kx, ln1.ky, ln1.kz},
                                                { ln2.kx, ln2.ky, ln2.kz}};
            var dt = mrx.detMrx3x3(detlines);
            return Math.Abs(dt) <= solveerror;
        }

        public bool IncidenceOfFramePlane(Line3D ln)
        {
            return (Math.Abs(ln.Point0.X) < 0.001) && (Math.Abs(ln.kx) < 0.001) ||
                   (Math.Abs(ln.Point0.Y) < 0.001) && (Math.Abs(ln.ky) < 0.001) ||
                   (Math.Abs(ln.Point0.Z) < 0.001) && (Math.Abs(ln.kz) < 0.001);
        }
        public bool IncidenceOfPlane(Line3D ln, PlaneSpace pl)
        {
            var s = pl.A * ln.kx + pl.B * ln.ky + pl.C * ln.kz;
            var g = pl.A * ln.Point0.X + pl.B * ln.Point0.Y + pl.C * ln.Point0.Z + pl.D;
            return (Math.Abs(s) < 0.001) && (Math.Abs(g) < 0.001);
        }
        public bool IncidenceOfPlane(Line3D ln, PlaneSpace pl, double solveerror)
        {
            var s = pl.A * ln.kx + pl.B * ln.ky + pl.C * ln.kz;
            var g = pl.A * ln.Point0.X + pl.B * ln.Point0.Y + pl.C * ln.Point0.Z + pl.D;
            return (Math.Abs(s) < solveerror) && (Math.Abs(g) < solveerror);
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
        /// <summary>
        /// Не работает
        /// </summary>
        /// <param name="ln1"></param>
        /// <param name="ln2"></param>
        /// <returns></returns>
        public bool Parallelism(Line2D ln1, Line2D ln2)
        {
            return false;
        }
        public bool Parallelism(Line3D ln1, Line3D ln2, double solveerror)
        {
            return false;
        }
        #endregion

        #region Intersection of Lines
        public bool Intersection(Line2D ln1, Line2D ln2)
        {
            var y = (ln2.Point0.Y * ln2.kx * ln1.ky - ln1.Point0.Y * ln2.ky * ln1.kx + ln2.ky * ln1.ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.kx * ln1.ky - ln1.kx * ln2.ky);
            var x = ln1.kx * (y - ln1.Point0.Y) / ln1.ky + ln1.Point0.X;
            return !(y < 0) && !(x < 0);
        }
        public bool Intersection(Line2D ln1, LineOfPlane1X0Y ln, Point frameCenter)
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
        public bool Intersection(Line2D ln1, LineOfPlane2X0Z ln, Point frameCenter)
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
        public bool Intersection(Line2D ln1, LineOfPlane3Y0Z ln, Point frameCenter)
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
        #endregion

        #region Perpendicularity

        public bool PerpendicularityOfPlane(Line3D ln, PlaneSpace pl)
        {
            return (Math.Abs(pl.A * ln.ky - pl.B * ln.kx) >= 0.001) && 
                   (Math.Abs(pl.A * ln.kz - pl.C * ln.kx) >= 0.001) &&
                   (Math.Abs(pl.B * ln.kz - pl.C * ln.ky) >= 0.001);
        }
        public bool PerpendicularityOfPlane(Line3D ln, PlaneSpace pl, double solveerror)
        {
            return (Math.Abs(pl.A * ln.ky - pl.B * ln.kx) >= solveerror) &&
                   (Math.Abs(pl.A * ln.kz - pl.C * ln.kx) >= solveerror) &&
                   (Math.Abs(pl.B * ln.kz - pl.C * ln.ky) >= solveerror);
        }
        #endregion

        #region Crossing
        public bool Crossing(Line3D ln1, Line3D ln2)
        {
            return !IncidenceOfOnePlane(ln1, ln2);
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
        #region Point Of Intersection 

        #endregion
    }
}
