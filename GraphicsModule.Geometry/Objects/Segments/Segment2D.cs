using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Segments
{
    /// <summary>Класс для задания и расчета параметров 2D прямой</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class Segment2D : IObject
    {
        private Name _name;

        public Segment2D(Point2D pt1, Point2D pt2)
        {
            if (pt1.IsCoincides(pt2)) return;
            Point0 = pt1;
            Point1 = pt2;
            Kx = pt2.X - pt1.X;
            Ky = pt2.Y - pt1.Y;
        }
        public void Draw(Blueprint blueprint)
        {
            Point0.Draw(blueprint);
            Point1.Draw(blueprint);
            blueprint.Graphics.DrawLine(blueprint.Settings.Drawing.PenLine2D, Point0.ToPointF(), Point1.ToPointF());
        }
        public bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            return this.IsIncidentalToPoint(mscoords, 35 * distance);
        }
        public Name GetName()
        {
            return Name;
        }
        public void SetName(Name name)
        {
            Name = new Name(name);
            Point0.Name = Name;
            Point1.Name = Name;
        }
        public Point2D Point0 { get; }

        public Point2D Point1 { get; }

        public Name Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Point0.Name = value;
                Point1.Name = value;
            }
        }

        public double Kx { get; }

        public double Ky { get; }
    }
}
