using System;
using System.Collections.Generic;
using System.Drawing;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Structures
{
    public class LineEndingPoints
    {
        public LineEndingPoints(Line2D ln, Rectangle frame)
        {
            Point0 = null;
            Point1 = null;
            if (Math.Abs(ln.Kx) < Constants.Tolerance)
            {
                Point0 = new Point2D(ln.Point0.X, frame.Top);
                Point1 = new Point2D(ln.Point0.X, frame.Bottom);
                return;
            }
            if (Math.Abs(ln.Ky) < Constants.Tolerance)
            {
                Point0 = new Point2D(frame.Left, ln.Point0.Y);
                Point1 = new Point2D(frame.Right, ln.Point0.Y);
                return;
            }
            //y= 0
            var cvalue = (frame.Top - ln.Point0.Y) * ln.Kx / ln.Ky + ln.Point0.X;
            if (cvalue > frame.Left && cvalue < frame.Right)
                InitializePoint(new Point2D(cvalue, frame.Top));

            //y= max
            cvalue = (frame.Bottom - ln.Point0.Y) * ln.Kx / ln.Ky + ln.Point0.X;
            if (cvalue > frame.Left && cvalue < frame.Right)
                InitializePoint(new Point2D(cvalue, frame.Bottom));

            if (IsInitialized)
                return;

            //x = 0
            cvalue = (frame.Left - ln.Point0.X) * ln.Ky / ln.Kx + ln.Point0.Y;
            if (cvalue > frame.Top && cvalue < frame.Bottom)
                InitializePoint(new Point2D(frame.Left, cvalue));

            //x = max
            cvalue = (frame.Right - ln.Point0.X) * ln.Ky / ln.Kx + ln.Point0.Y;
                InitializePoint(new Point2D(frame.Right, cvalue));

            if (!IsInitialized)
            {
                var msg = "Не удалось рассчитать конечные точки прямой в рамках заданной области.";
                throw new ArgumentException(msg);
            }
        }

        private void InitializePoint(Point2D pt)
        {
            if (IsInitialized)
                return;
            if (Point0 == null)
            {
                Point0 = pt;
            }
            else if (Point1 == null)
            {
                Point1 = pt;
            }
        }

        [Obsolete("На будущее")]
        public IList<Line2D> GetFrameBorders(Rectangle frame)
        {
            var top = new Line2D(new Point2D(frame.X, frame.Y), new Point2D(frame.Right, frame.Y));
            var bottom = new Line2D(new Point2D(frame.X, frame.Bottom), new Point2D(frame.Right, frame.Bottom));
            var left = new Line2D(new Point2D(frame.X, frame.Y), new Point2D(frame.X, frame.Bottom));
            var right = new Line2D(new Point2D(frame.Right, frame.Y), new Point2D(frame.Right, frame.Bottom));

            return new List<Line2D>() { top, bottom, left, right };
        }

        public Point2D Point0 { get; private set; }

        public Point2D Point1 { get; private set; }

        public bool IsInitialized => Point0 != null && Point1 != null;
    }
}
