using System.Drawing;
using GraphicsModule.Configuration;
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

        public void Draw(DrawSettings st, Point coordinateSystemCenter, Graphics g)
        {
            g.DrawPie(st.PenPoints, (float)X - st.RadiusPoints, (float)Y - st.RadiusPoints, st.RadiusPoints * 2, st.RadiusPoints * 2, 0, 360);
            g.DrawString(Name.Value, st.TextFont, st.TextBrush, (float)X + Name.Dx, (float)Y + Name.Dy);
        }

        public double X { get; }

        public double Y { get; }

        public Name Name { get; set; }

        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            return Calculate.Distance(mscoords, this) < distance;
        }
    }
}
