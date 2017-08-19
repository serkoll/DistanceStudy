using System.Drawing;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;

namespace GraphicsModule.Geometry.Objects.Points
{
    /// <summary>
    /// 2D точка
    /// </summary>
    public class Point2D : IObject
    {
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
            Name = new Name();
        }

        public Point2D(Point pt)
        {
            X = pt.X;
            Y = pt.Y;
            Name = new Name();
        }

        public virtual void Draw(Blueprint blueprint)
        {
            var g = blueprint.Graphics;
            var settings = blueprint.Settings.Drawing;
            g.DrawPie(settings.PenPoints, (float)X - settings.RadiusPoints, (float)Y - settings.RadiusPoints, settings.RadiusPoints * 2, settings.RadiusPoints * 2, 0, 360);
            g.DrawString(Name.Value, settings.TextFont, settings.TextBrush, (float)X + Name.Dx, (float)Y + Name.Dy);
        }

        public virtual bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            return this.DistanceToPoint(mscoords) < distance;
        }

        public double X { get; }

        public double Y { get; }

        public Name Name { get; set; }
    }
}
