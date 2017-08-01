using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Extensions
{
    public static class LineEndingPointsExtensions
    {
        public static IList<PointF> CalculateEndingPointsOnFrame(this LineOfPlane1X0Y ln1, Point coordinateSystemCenter)
        {
            const int frameSizeSolveError = 20;
            var ln = ln1.ToGlobalCoordinates(coordinateSystemCenter);
            var topLeftPoint = new Point(0, coordinateSystemCenter.Y);
            var bottomRightPoint = new Point(coordinateSystemCenter.X, coordinateSystemCenter.Y * 2 + frameSizeSolveError);
            var res0 = GetTopOrLeftPoints(ln, topLeftPoint, bottomRightPoint);
            if (res0 != null && res0.Count == 2)
            {
                return res0;
            }

            var res1 = GetBottomOrRightPoints(ln, topLeftPoint, bottomRightPoint);
            if (res1 != null && res1.Count == 2)
            {
                return res1;
            }

            return res0.Concat(res1).ToList();
        }

        public static IList<PointF> CalculateEndingPointsOnFrame(this LineOfPlane2X0Z ln2, Point coordinateSystemCenter)
        {
            var ln = ln2.ToGlobalCoordinates(coordinateSystemCenter);

            var topLeftPoint = new Point(0, 0);
            var bottomrightPoint = coordinateSystemCenter;

            var res0 = GetTopOrLeftPoints(ln, topLeftPoint, bottomrightPoint);
            if (res0 != null && res0.Count == 2)
            {
                return res0;
            }

            var res1 = GetBottomOrRightPoints(ln, topLeftPoint, bottomrightPoint);
            if (res1 != null && res1.Count == 2)
            {
                return res1;
            }

            return res0.Concat(res1).ToList();
        }

        public static IList<PointF> CalculateEndingPointsOnFrame(this LineOfPlane3Y0Z ln3, Point coordinateSystemCenter)
        {
            const int frameSizeSolveError = 20;
            var ln = ln3.ToGlobalCoordinates(coordinateSystemCenter);

            var topLeftPoint = new Point(coordinateSystemCenter.X, 0);
            var bottomrightPoint = new Point(coordinateSystemCenter.X * 2 + frameSizeSolveError, coordinateSystemCenter.Y);

            var res0 = GetTopOrLeftPoints(ln, topLeftPoint, bottomrightPoint);
            if (res0 != null && res0.Count == 2)
            {
                return res0;
            }

            var res1 = GetBottomOrRightPoints(ln, topLeftPoint, bottomrightPoint);
            if (res1 != null && res1.Count == 2)
            {
                return res1;
            }

            return res0.Concat(res1).ToList();
        }

        private static IList<PointF> GetTopOrLeftPoints(Line2D ln, Point topLeftPlanePoint, Point bottomRightPlanePoint)
        {
            var topLine = new Line2D(topLeftPlanePoint.ToPoint2D(), new Point2D(bottomRightPlanePoint.X, topLeftPlanePoint.Y));
            var leftLine = new Line2D(topLeftPlanePoint.ToPoint2D(), new Point2D(topLeftPlanePoint.X, bottomRightPlanePoint.Y));

            var topCrossingPoint = ln.GetCrossingPoint(topLine);
            var leftCrossingPoint = ln.GetCrossingPoint(leftLine);

            return CreateResultCrossingPointsList(topCrossingPoint, leftCrossingPoint, topLeftPlanePoint, bottomRightPlanePoint);
        }

        private static IList<PointF> GetBottomOrRightPoints(Line2D ln, Point topLeftPlanePoint, Point bottomRightPlanePoint)
        {
            var bottomLine = new Line2D(bottomRightPlanePoint.ToPoint2D(), new Point2D(topLeftPlanePoint.X, bottomRightPlanePoint.Y));
            var rightLine = new Line2D(bottomRightPlanePoint.ToPoint2D(), new Point2D(bottomRightPlanePoint.X, topLeftPlanePoint.Y));

            var bottommCrossingPoint = ln.GetCrossingPoint(bottomLine);
            var rightCrossingPoint = ln.GetCrossingPoint(rightLine);

            return CreateResultCrossingPointsList(bottommCrossingPoint, rightCrossingPoint, topLeftPlanePoint, bottomRightPlanePoint);
        }

        private static IList<PointF> CreateResultCrossingPointsList(PointF? crossingPoint0, PointF? crossingPoint1, Point topLeftPlanePoint, Point bottomRightPlanePoint)
        {
            var result = new List<PointF>();

            if (crossingPoint0 != null && IsCrossingPointInFrame((PointF)crossingPoint0, topLeftPlanePoint, bottomRightPlanePoint))
            {
                result.Add((PointF)crossingPoint0);
            }

            if (crossingPoint1 != null && IsCrossingPointInFrame((PointF)crossingPoint1, topLeftPlanePoint, bottomRightPlanePoint))
            {
                result.Add((PointF)crossingPoint1);
            }

            if (result.Count == 2)
            {
                if (((PointF)crossingPoint0).IsCoincides((PointF)crossingPoint1))
                {
                    result.RemoveAt(1);
                }
            }

            return result.Count != 0 ? result : null;
        }

        private static bool IsCrossingPointInFrame(PointF crossingPoint, Point topLeftPlanePoint, Point bottomRightPlanePoint)
        {
            const int solveError = 10;
            return (crossingPoint.X + solveError) >= topLeftPlanePoint.X 
                    && crossingPoint.Y + solveError >= topLeftPlanePoint.Y 
                    && crossingPoint.X <= (bottomRightPlanePoint.X + solveError) 
                    && crossingPoint.Y <= (bottomRightPlanePoint.Y + solveError);
        }
    }
}
