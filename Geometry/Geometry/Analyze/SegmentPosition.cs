using System;
using System.Drawing;

namespace GeometryObjects
{
    public class SegmentPosition
    {
        #region Incidence of Point and Line
        public bool IncidenceOfPoint(Point pt, Segment2D ln)
        {
            if (Math.Abs((pt.X - ln.Point0.X) * ln.ky - (pt.Y - ln.Point0.Y) * ln.kx) < 0.001)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IncidenceOfPoint(Point pt, Segment2D ln, double solveerror)
        {
            if (Math.Abs((pt.X - ln.Point0.X) * ln.ky - (pt.Y - ln.Point0.Y) * ln.kx) < solveerror)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IncidenceOfPoint(Point2D pt, Segment2D ln)
        {
            if (Math.Abs((pt.X - ln.Point0.X) * ln.ky - (pt.Y - ln.Point0.Y) * ln.kx) < 0.001)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IncidenceOfPoint(Point2D pt, Segment2D ln, double solveerror)
        {
            if (Math.Abs((pt.X - ln.Point0.X) * ln.ky - (pt.Y - ln.Point0.Y) * ln.kx) < solveerror)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IncidenceOfPoint(Point3D pt, Segment3D ln)
        {
            if ((Math.Abs((pt.X - ln.Point0.X) * ln.ky - (pt.Y - ln.Point0.Y) * ln.kx) < 0.001) &&
               (Math.Abs((pt.X - ln.Point0.X) * ln.kz - (pt.Z - ln.Point0.Z) * ln.kx) < 0.001) &&
               (Math.Abs((pt.Y - ln.Point0.Y) * ln.kz - (pt.Z - ln.Point0.Z) * ln.ky) < 0.001))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IncidenceOfPoint(Point3D pt, Segment3D ln, double solveerror)
        {
            if ((Math.Abs((pt.X - ln.Point0.X) * ln.ky - (pt.Y - ln.Point0.Y) * ln.kx) < solveerror) &&
                (Math.Abs((pt.X - ln.Point0.X) * ln.kz - (pt.Z - ln.Point0.Z) * ln.kx) < solveerror) &&
                (Math.Abs((pt.Y - ln.Point0.Y) * ln.kz - (pt.Z - ln.Point0.Z) * ln.ky) < solveerror))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Incidence Of Plane
        public bool IncidenceOfOnePlane(Segment3D ln1, Segment3D ln2)
        {
            var mrx = new MatrixEvalution();
            var dx = ln2.Point0.X - ln1.Point0.X;
            var dy = ln2.Point0.Y - ln1.Point0.Y;
            var dz = ln2.Point0.Z - ln1.Point0.Z;
            double[,] detlines = new double[,]{ { dx, dy, dz },
                                                { ln1.kx, ln1.ky, ln1.kz},
                                                { ln2.kx, ln2.ky, ln2.kz}};
            var dt = mrx.detMrx3x3(detlines);
            if (Math.Abs(dt) <= 0.001)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IncidenceOfOnePlane(Segment3D ln1, Segment3D ln2, double solveerror)
        {
            var mrx = new MatrixEvalution();
            var dx = ln2.Point0.X - ln1.Point0.X;
            var dy = ln2.Point0.Y - ln1.Point0.Y;
            var dz = ln2.Point0.Z - ln1.Point0.Z;
            double[,] detlines = new double[,]{ { dx, dy, dz },
                                                { ln1.kx, ln1.ky, ln1.kz},
                                                { ln2.kx, ln2.ky, ln2.kz}};
            var dt = mrx.detMrx3x3(detlines);
            if (Math.Abs(dt) <= solveerror)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Проверить на работоспособность
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool IncidenceOfFramePlane(Segment3D ln)
        {
            if ((Math.Abs(ln.Point0.X) < 0.001) && (Math.Abs(ln.kx) < 0.001) ||
                (Math.Abs(ln.Point0.Y) < 0.001) && (Math.Abs(ln.ky) < 0.001) ||
                (Math.Abs(ln.Point0.Z) < 0.001) && (Math.Abs(ln.kz) < 0.001))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IncidenceOfPlane(Segment3D ln, PlaneSpace pl)
        {
            var s = pl.A * ln.kx + pl.B * ln.ky + pl.C * ln.kz;
            var g = pl.A * ln.Point0.X + pl.B * ln.Point0.Y + pl.C * ln.Point0.Z + pl.D;
            if ((Math.Abs(s) < 0.001) && (Math.Abs(g) < 0.001))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IncidenceOfPlane(Segment3D ln, PlaneSpace pl, double solveerror)
        {
            var s = pl.A * ln.kx + pl.B * ln.ky + pl.C * ln.kz;
            var g = pl.A * ln.Point0.X + pl.B * ln.Point0.Y + pl.C * ln.Point0.Z + pl.D;
            if ((Math.Abs(s) < solveerror) && (Math.Abs(g) < solveerror))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Coincidence of Lines
        public bool Coincidence(Segment2D ln1, Segment2D ln2)
        {
            if (IncidenceOfPoint(ln1.Point0, ln2) && IncidenceOfPoint(ln1.Point1, ln2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Coincidence(Segment3D ln1, Segment3D ln2)
        {
            if (IncidenceOfPoint(ln1.Point0, ln2) && IncidenceOfPoint(ln1.Point1, ln2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Coincidence(SegmentOfPlane1X0Y ln1, SegmentOfPlane1X0Y ln2)
        {
            return Coincidence(Cnv.ToSegment2D(ln1), Cnv.ToSegment2D(ln2));
        }
        public bool Coincidence(SegmentOfPlane2X0Z ln1, SegmentOfPlane2X0Z ln2)
        {
            return Coincidence(Cnv.ToSegment2D(ln1), Cnv.ToSegment2D(ln2));
        }
        public bool Coincidence(SegmentOfPlane3Y0Z ln1, SegmentOfPlane3Y0Z ln2)
        {
            return Coincidence(Cnv.ToSegment2D(ln1), Cnv.ToSegment2D(ln2));
        }
        #endregion

        #region Parallelism of Lines
        /// <summary>
        /// Не работает
        /// </summary>
        /// <param name="ln1"></param>
        /// <param name="ln2"></param>
        /// <returns></returns>
        public bool Parallelism(Segment2D ln1, Segment2D ln2)
        {
            return false;
        }
        public bool Parallelism(Segment3D ln1, Segment3D ln2, double solveerror)
        {
            return false;
        }
        #endregion

        #region Intersection of Lines
        public bool Intersection(Segment2D ln1, Segment2D ln2)
        {
            var y = (ln2.Point0.Y * ln2.kx * ln1.ky - ln1.Point0.Y * ln2.ky * ln1.kx + ln2.ky * ln1.ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.kx * ln1.ky - ln1.kx * ln2.ky);
            var x = ln1.kx * (y - ln1.Point0.Y) / ln1.ky + ln1.Point0.X;
            if (y < 0 || x < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Intersection(Segment2D ln1, SegmentOfPlane1X0Y ln, Point frameCenter)
        {
            var ln2 = DeterminePosition.ForSegmentProjection(ln, frameCenter);
            var y = (ln2.Point0.Y * ln2.kx * ln1.ky - ln1.Point0.Y * ln2.ky * ln1.kx + ln2.ky * ln1.ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.kx * ln1.ky - ln1.kx * ln2.ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.kx * ln1.ky - ln2.Point0.X * ln1.kx * ln2.ky + ln2.kx * ln1.kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.ky * ln2.kx - ln1.kx * ln2.ky);
            if (x < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Intersection(Segment2D ln1, SegmentOfPlane2X0Z ln, Point frameCenter)
        {
            var ln2 = DeterminePosition.ForSegmentProjection(ln, frameCenter);
            var y = (ln2.Point0.Y * ln2.kx * ln1.ky - ln1.Point0.Y * ln2.ky * ln1.kx + ln2.ky * ln1.ky * (ln1.Point0.X - ln2.Point0.X)) /
                     (ln2.kx * ln1.ky - ln1.kx * ln2.ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.kx * ln1.ky - ln2.Point0.X * ln1.kx * ln2.ky + ln2.kx * ln1.kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.ky * ln2.kx - ln1.kx * ln2.ky);
            if (x < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Intersection(Segment2D ln1, SegmentOfPlane3Y0Z ln, Point frameCenter)
        {
            var ln2 = DeterminePosition.ForSegmentProjection(ln, frameCenter);
            var y = (ln2.Point0.Y * ln2.kx * ln1.ky - ln1.Point0.Y * ln2.ky * ln1.kx + ln2.ky * ln1.ky * (ln1.Point0.X - ln2.Point0.X)) /
                     (ln2.kx * ln1.ky - ln1.kx * ln2.ky);
            if (y < 0)
            {
                return false;
            }
            var x = (ln1.Point0.X * ln2.kx * ln1.ky - ln2.Point0.X * ln1.kx * ln2.ky + ln2.kx * ln1.kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.ky * ln2.kx - ln1.kx * ln2.ky);
            if (x < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Perpendicularity

        public bool PerpendicularityOfPlane(Segment3D ln, PlaneSpace pl)
        {
            if ((Math.Abs(pl.A * ln.ky - pl.B * ln.kx) >= 0.001) &&
                (Math.Abs(pl.A * ln.kz - pl.C * ln.kx) >= 0.001) &&
                (Math.Abs(pl.B * ln.kz - pl.C * ln.ky) >= 0.001))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool PerpendicularityOfPlane(Segment3D ln, PlaneSpace pl, double solveerror)
        {
            if ((Math.Abs(pl.A * ln.ky - pl.B * ln.kx) >= solveerror) &&
                (Math.Abs(pl.A * ln.kz - pl.C * ln.kx) >= solveerror) &&
                (Math.Abs(pl.B * ln.kz - pl.C * ln.ky) >= solveerror))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Crossing
        public bool Crossing(Segment3D ln1, Segment3D ln2)
        {
            if (!IncidenceOfOnePlane(ln1, ln2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Direction of Line
        /// <summary>
        /// Направление не реализовано
        /// </summary>
        /// <param name="ln1"></param>
        /// <param name="ln2"></param>
        /// <returns></returns>
        public bool DirectionCoincidence(Segment3D ln1, Segment3D ln2)
        {
            var newln = new Segment3D();
            return true;
        }
        #endregion
        #region Point Of Intersection 

        #endregion
    }
}

