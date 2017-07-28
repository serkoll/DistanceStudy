using System;
using System.Collections.Generic;
using System.Drawing;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
// ReSharper disable CompareOfFloatsByEqualityOperator

namespace GraphicsModule.Geometry.Structures
{
    public class LineEndingPoints
    {
        public Point2D Point0 { get; }

        public Point2D Point1 { get; }

        public LineEndingPoints(Line2D ln, Rectangle frame)
        {
            if (ln.Coefficients.A == 0 && ln.Coefficients.B == 0 && ln.Coefficients.C == 0)
            {
                var msg = "Не рассчины коэффициенты общего уравнения прямой";
                throw new ArgumentNullException(msg);
            }

            var borders = GetFrameBorders(frame);
            foreach (var border in borders)
            {
                if (ln.IsEquivalent(border))
                {
                    Point0 = border.Point0;
                    Point1 = border.Point1;
                    return;
                }

                var pt = ln.GetIntersectPoint(border, frame);
                if (pt == null)
                {
                    continue;
                }

                if (Point0 == null)
                {
                    Point0 = pt;
                }
                else if (Point1 == null)
                {
                    Point1 = pt;
                    return;
                }
            }
            if (Point0 == null || Point1 == null)
            {
                var msg = "Не удалось рассчитать конечную точку для отрисовки прямой";
                throw new ArgumentNullException(msg);
            }
        }

        private IList<Line2D> GetFrameBorders(Rectangle frame)
        {
            var top = new Line2D(new Point2D(frame.X, frame.Y), new Point2D(frame.Right, frame.Y) );
            var bottom = new Line2D(new Point2D(frame.X, frame.Bottom), new Point2D(frame.Right, frame.Bottom));
            var left = new Line2D(new Point2D(frame.X, frame.Y), new Point2D(frame.X, frame.Bottom));
            var right = new Line2D(new Point2D(frame.Right, frame.Y), new Point2D(frame.Right, frame.Bottom));

            return new List<Line2D>() { top, bottom, left, right };
        }
    }
}
