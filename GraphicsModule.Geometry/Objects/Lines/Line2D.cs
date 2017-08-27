using System.Drawing;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Structures;

namespace GraphicsModule.Geometry.Objects.Lines
{
    public class Line2D : ILine
    {
        public Line2D()
        {
            Point0 = new Point2D(0, 0);
            Point1 = new Point2D(1, 0);
            Kx = 1;
            Ky = 0;
            Name = new Name();
        }

        public Line2D(Point2D pt1, Point2D pt2)
        {
            Point0 = pt1;
            Point1 = pt2;
            Kx = pt2.X - pt1.X;
            Ky = pt2.Y - pt1.Y;
            Name = new Name();
            EndingPoints = null;
        }

        public Line2D(Point2D pt1, Point2D pt2, Rectangle frame)
        {
            Point0 = pt1;
            Point1 = pt2;
            Kx = pt2.X - pt1.X;
            Ky = pt2.Y - pt1.Y;
            Name = new Name();
            EndingPoints = new LineEndingPoints(this, frame);
        }

        public void Draw(Blueprint blueprint)
        {
            Point0.Draw(blueprint);
            Point1.Draw(blueprint);
            blueprint.Graphics.DrawLine(blueprint.Settings.Drawing.PenLine2D, EndingPoints.Point0.ToPoint(), EndingPoints.Point1.ToPoint());
        }

        public bool IsSelected(Point mscoords, Point coordinateSystemCenter, double distance)
        {
            return this.IsIncidentalToPoint(mscoords, 35 * distance);
        }

        public Point2D Point0 { get; }

        public Point2D Point1 { get; }

        public Name Name { get; set; }

        public double Kx { get; }

        public double Ky { get; }

        public LineEndingPoints EndingPoints { get; }
    }
}
