﻿using System;
using System.Drawing;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Extensions
{
    public static class ObjectsCalculateExtensions
    {
        #region DistanceToPoint

        public static double DistanceToPoint(this Point pt, Point targetPt)
        {
            return Math.Sqrt(Math.Pow((targetPt.X - pt.X), 2) + Math.Pow((targetPt.Y - pt.Y), 2));
        }

        public static double DistanceToPoint(this Point2D pt, Point targetPt)
        {
            return Math.Sqrt(Math.Pow((targetPt.X - pt.X), 2) + Math.Pow((targetPt.Y - pt.Y), 2));
        }

        public static double DistanceToPoint(this PointOfPlane1X0Y pt, Point targetPt, Point coordinateSystemCenter)
        {
            var dpt = pt.ToGlobalCoordinates(coordinateSystemCenter);
            return DistanceToPoint(targetPt, dpt);
        }

        public static double DistanceToPoint(this PointOfPlane2X0Z pt, Point targetPt, Point coordinateSystemCenter)
        {
            var dpt = pt.ToGlobalCoordinates(coordinateSystemCenter);
            return DistanceToPoint(targetPt, dpt);
        }

        public static double DistanceToPoint(this PointOfPlane3Y0Z pt, Point targetPt, Point coordinateSystemCenter)
        {
            var dpt = pt.ToGlobalCoordinates(coordinateSystemCenter);
            return DistanceToPoint(targetPt, dpt);
        }

        public static double[] DistanceToPoint(this Point3D pt, Point targetPt, Point coordinateSystemCenter)
        {
            return new[] { DistanceToPoint(pt.PointOfPlane1X0Y, targetPt, coordinateSystemCenter),
                           DistanceToPoint(pt.PointOfPlane2X0Z, targetPt, coordinateSystemCenter),
                           DistanceToPoint(pt.PointOfPlane3Y0Z, targetPt, coordinateSystemCenter)};
        }

        #endregion

        #region GetCrossingPoint

        public static PointF? GetCrossingPoint(this Line2D ln1, Line2D ln2)
        {
            if (!ln1.IsIntersect(ln2))
            {
                return null;
            }

            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx + ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            var x = ln1.Kx * (y - ln1.Point0.Y) / ln1.Ky + ln1.Point0.X;

            return new PointF((float)x, (float)y);
        }

        public static PointF? GetCrossingPoint(this LineOfPlane1X0Y ln, Line2D ln1, Point coordinateSystemCenter)
        {
            var ln2 = ln.ToGlobalCoordinates(coordinateSystemCenter);
            if (!ln1.IsIntersect(ln2))
            {
                return null;
            }
            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx + ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                    (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            var x = (ln1.Point0.X * ln2.Kx * ln1.Ky - ln2.Point0.X * ln1.Kx * ln2.Ky + ln2.Kx * ln1.Kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.Ky * ln2.Kx - ln1.Kx * ln2.Ky);
            return new PointF((float)x, (float)y);
        }

        public static PointF? GetCrossingPoint(this LineOfPlane2X0Z ln, Line2D ln1, Point coordinateSystemCenter)
        {
            var ln2 = ln.ToGlobalCoordinates(coordinateSystemCenter);
            if (!ln1.IsIntersect(ln2))
            {
                return null;
            }

            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx + ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                     (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            var x = (ln1.Point0.X * ln2.Kx * ln1.Ky - ln2.Point0.X * ln1.Kx * ln2.Ky + ln2.Kx * ln1.Kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.Ky * ln2.Kx - ln1.Kx * ln2.Ky);
            return new PointF((float)x, (float)y);
        }

        public static object GetCrossingPoint(this LineOfPlane3Y0Z ln, Line2D ln1,  Point coordinateSystemCenter)
        {
            var ln2 = ln.ToGlobalCoordinates(coordinateSystemCenter);
            if (!ln1.IsIntersect(ln2))
            {
                return null;
            }

            var y = (ln2.Point0.Y * ln2.Kx * ln1.Ky - ln1.Point0.Y * ln2.Ky * ln1.Kx + ln2.Ky * ln1.Ky * (ln1.Point0.X - ln2.Point0.X)) /
                     (ln2.Kx * ln1.Ky - ln1.Kx * ln2.Ky);
            var x = (ln1.Point0.X * ln2.Kx * ln1.Ky - ln2.Point0.X * ln1.Kx * ln2.Ky + ln2.Kx * ln1.Kx * (ln2.Point0.Y - ln1.Point0.Y)) /
                    (ln1.Ky * ln2.Kx - ln1.Kx * ln2.Ky);

            return new PointF((float)x, (float)y);
        }

        #endregion
    }
}
