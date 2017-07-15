using System;
using System.Drawing;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;

namespace GraphicsModule.Geometry.Extensions
{
    public static class SegmentPositionExtensions
    {
        #region Incidence of Point and Line

        public static bool IsIncidentalToPoint(this Segment2D sg, Point pt)
        {
            return Math.Abs((pt.X - sg.Point0.X) * sg.Ky - (pt.Y - sg.Point0.Y) * sg.Kx) < 0.001;
        }

        public static bool IsIncidentalToPoint(this Segment2D sg, Point pt, double solveerror)
        {
            return Math.Abs((pt.X - sg.Point0.X) * sg.Ky - (pt.Y - sg.Point0.Y) * sg.Kx) < solveerror;
        }

        public static bool IsIncidentalToPoint(this Segment2D sg, Point2D pt)
        {
            return Math.Abs((pt.X - sg.Point0.X) * sg.Ky - (pt.Y - sg.Point0.Y) * sg.Kx) < 0.001;
        }


        public static bool IsIncidentalToPoint(this Segment2D sg, Point2D pt, double solveerror)
        {
            return Math.Abs((pt.X - sg.Point0.X) * sg.Ky - (pt.Y - sg.Point0.Y) * sg.Kx) < solveerror;
        }

        public static bool IsIncidentalToPoint(this Segment3D sg, Point3D pt)
        {
            return (Math.Abs((pt.X - sg.Point0.X) * sg.Ky - (pt.Y - sg.Point0.Y) * sg.Kx) < 0.001) &&
                   (Math.Abs((pt.X - sg.Point0.X) * sg.Kz - (pt.Z - sg.Point0.Z) * sg.Kx) < 0.001) &&
                   (Math.Abs((pt.Y - sg.Point0.Y) * sg.Kz - (pt.Z - sg.Point0.Z) * sg.Ky) < 0.001);
        }

        public static bool IsIncidentalToPoint(this Segment3D sg, Point3D pt, double solveerror)
        {
            return (Math.Abs((pt.X - sg.Point0.X) * sg.Ky - (pt.Y - sg.Point0.Y) * sg.Kx) < solveerror) &&
                   (Math.Abs((pt.X - sg.Point0.X) * sg.Kz - (pt.Z - sg.Point0.Z) * sg.Kx) < solveerror) &&
                   (Math.Abs((pt.Y - sg.Point0.Y) * sg.Kz - (pt.Z - sg.Point0.Z) * sg.Ky) < solveerror);
        }

        #endregion

        #region IsCoincides of Lines

        public static bool IsCoincides(this Segment2D sg1, Segment2D sg2)
        {
            return sg2.IsIncidentalToPoint(sg1.Point0) && sg2.IsIncidentalToPoint(sg2.Point1);
        }

        public static bool IsCoincides(this Segment3D sg1, Segment3D sg2)
        {
            return sg2.IsIncidentalToPoint(sg1.Point0) && sg2.IsIncidentalToPoint(sg2.Point1);
        }

        public static bool IsCoincides(this SegmentOfPlane1X0Y sg1, SegmentOfPlane1X0Y sg2)
        {
            return IsCoincides(sg1.ToSegment2D(), sg2.ToSegment2D());
        }

        public static bool IsCoincides(this SegmentOfPlane2X0Z sg1, SegmentOfPlane2X0Z sg2)
        {
            return IsCoincides(sg1.ToSegment2D(), sg2.ToSegment2D());
        }

        public static bool IsCoincides(this SegmentOfPlane3Y0Z sg1, SegmentOfPlane3Y0Z sg2)
        {
            return IsCoincides(sg1.ToSegment2D(), sg2.ToSegment2D());
        }

        #endregion

        #region IsParallel of Lines

        public static bool IsParallel(this Segment2D sg1, Segment2D sg2)
        {
            return Math.Abs(sg1.Kx - sg2.Kx) < 0.001 || Math.Abs(sg1.Ky - sg2.Ky) < 0.001;
        }

        public static bool IsParallel(this Segment3D sg1, Segment3D sg2, double solveerror)
        {
            return Math.Abs(sg1.Kx - sg2.Kx) < solveerror || Math.Abs(sg1.Ky - sg2.Ky) < solveerror;
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

        #region IsCrossed of Lines

        public static bool IsCrossed(this Segment2D sg1, Segment2D sg2)
        {
            var y = (sg2.Point0.Y * sg2.Kx * sg1.Ky - sg1.Point0.Y * sg2.Ky * sg1.Kx + sg2.Ky * sg1.Ky * (sg1.Point0.X - sg2.Point0.X)) /
                    (sg2.Kx * sg1.Ky - sg1.Kx * sg2.Ky);
            var x = sg1.Kx * (y - sg1.Point0.Y) / sg1.Ky + sg1.Point0.X;
            return !(y < 0) && !(x < 0);
        }

        public static bool IsCrossed(this Segment2D sg1, SegmentOfPlane1X0Y ln, Point frameCenter)
        {
            var ln2 = DeterminePosition.ForSegmentProjection(ln, frameCenter);
            var y = (ln2.Point0.Y * ln2.Kx * sg1.Ky - sg1.Point0.Y * ln2.Ky * sg1.Kx + ln2.Ky * sg1.Ky * (sg1.Point0.X - ln2.Point0.X)) /
                    (ln2.Kx * sg1.Ky - sg1.Kx * ln2.Ky);
            if (y < 0)
            {
                return false;
            }
            var x = (sg1.Point0.X * ln2.Kx * sg1.Ky - ln2.Point0.X * sg1.Kx * ln2.Ky + ln2.Kx * sg1.Kx * (ln2.Point0.Y - sg1.Point0.Y)) /
                    (sg1.Ky * ln2.Kx - sg1.Kx * ln2.Ky);
            return !(x < 0);
        }

        public static bool IsCrossed(this Segment2D sg1, SegmentOfPlane2X0Z ln, Point frameCenter)
        {
            var ln2 = DeterminePosition.ForSegmentProjection(ln, frameCenter);
            var y = (ln2.Point0.Y * ln2.Kx * sg1.Ky - sg1.Point0.Y * ln2.Ky * sg1.Kx + ln2.Ky * sg1.Ky * (sg1.Point0.X - ln2.Point0.X)) /
                     (ln2.Kx * sg1.Ky - sg1.Kx * ln2.Ky);
            if (y < 0)
            {
                return false;
            }
            var x = (sg1.Point0.X * ln2.Kx * sg1.Ky - ln2.Point0.X * sg1.Kx * ln2.Ky + ln2.Kx * sg1.Kx * (ln2.Point0.Y - sg1.Point0.Y)) /
                    (sg1.Ky * ln2.Kx - sg1.Kx * ln2.Ky);
            return !(x < 0);
        }

        public static bool IsCrossed(this Segment2D sg1, SegmentOfPlane3Y0Z ln, Point frameCenter)
        {
            var ln2 = DeterminePosition.ForSegmentProjection(ln, frameCenter);
            var y = (ln2.Point0.Y * ln2.Kx * sg1.Ky - sg1.Point0.Y * ln2.Ky * sg1.Kx + ln2.Ky * sg1.Ky * (sg1.Point0.X - ln2.Point0.X)) /
                     (ln2.Kx * sg1.Ky - sg1.Kx * ln2.Ky);
            if (y < 0)
            {
                return false;
            }
            var x = (sg1.Point0.X * ln2.Kx * sg1.Ky - ln2.Point0.X * sg1.Kx * ln2.Ky + ln2.Kx * sg1.Kx * (ln2.Point0.Y - sg1.Point0.Y)) /
                    (sg1.Ky * ln2.Kx - sg1.Kx * ln2.Ky);
            return !(x < 0);
        }

        #endregion
    }
}

