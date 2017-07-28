using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Structures;

namespace GraphicsModule.Geometry.Objects.Lines
{
    /// <summary>Класс для задания и расчета параметров 2D прямой</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class Line2D : ILine
    {
        public Line2D()
        {
            Point0 = new Point2D(0, 0);
            Point1 = new Point2D(1, 0);
            Kx = 1;
            Ky = 0;
            Name = new Name();
            Coefficients = new LineCoefficients(Point0, Point1);
        }

        public Line2D(Point2D pt1, Point2D pt2)
        {
            Point0 = pt1;
            Point1 = pt2;
            Kx = pt2.X - pt1.X;
            Ky = pt2.Y - pt1.Y;
            Name = new Name();
            EndingPoints = null;
            Coefficients = new LineCoefficients(Point0, Point1);
        }

        public Line2D(Point2D pt1, Point2D pt2, PictureBox pb)
        {
            Point0 = pt1;
            Point1 = pt2;
            Kx = pt2.X - pt1.X;
            Ky = pt2.Y - pt1.Y;
            Coefficients = new LineCoefficients(Point0, Point1);
            EndingPoints = new LineEndingPoints(this, pb.ClientRectangle);
        }

        public Line2D ConstructPerpendicularOfPointToLine(Line2D line, Point2D pt)
        {
            return new Line2D(pt, new Point2D(-line.Kx + pt.X, line.Ky + pt.Y));
        }

        public Line2D ConstructParallelOfPointToLine(Line2D line, Point2D pt)
        {
            return new Line2D(pt, new Point2D(line.Kx + pt.X, line.Ky + pt.Y));
        }

        public void Draw(DrawSettings settings, Point coordinateSystemCenter, Graphics g)
        {
            Point0.Draw(settings, coordinateSystemCenter, g);
            Point1.Draw(settings, coordinateSystemCenter, g);
            g.DrawLine(settings.PenLine2D, EndingPoints.Point0.ToPoint(), EndingPoints.Point1.ToPoint());
        }

        public bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            return this.IsIncidentalToPoint(mscoords, 35 * distance);
        }

        public Point2D Point0 { get; }

        public Point2D Point1 { get; }

        public Name Name { get; set; }

        public double Kx { get; }

        public double Ky { get; }

        public LineCoefficients Coefficients { get; }

        public LineEndingPoints EndingPoints { get; }
    }
}
