using System.Drawing;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Points
{
    /// <summary>
    /// 2D точка
    /// </summary>
    public class Point2D: IObject
    {
        /// <summary>Получает или задает координату X точки</summary>
        /// <remarks></remarks>
        public double X { get; set; }
        /// <summary>Получает или задает координату Y точки</summary>
        /// <remarks></remarks>
        public double Y { get; set; }
        public string Name { get; set; } = "";
        /// <summary>Инициализирует новый экземпляр 2D точки</summary>
        /// <remarks>Исходные координаты точки: X=0; Y=0</remarks>
        public Point2D()
        {
            X = 0; Y = 0;
        }
        /// <summary>Инициализирует новый экземпляр 2D точки с указанными координатами</summary>
        /// <remarks></remarks>
        public Point2D(double x, double y)
        {
            X = x; Y = y;
        }
        /// <summary>Инициализирует новый экземпляр 2D точки</summary>
        /// <remarks></remarks>
        public Point2D(Point2D pt)
        {
            X = pt.X; Y = pt.Y;
        }
        public Point2D(Point pt)
        {
            X = pt.X; Y = pt.Y;
        }
        /// <summary>Передвигает ранее заданную 2D точку (изменяет коодинаты на указанные величины по осям в 2D)</summary>
        /// <remarks>Point3D.X += dx; Point3D.Y += dy</remarks>
        public void PointMove(double dx, double dy) { X += dx; Y += dy; }
        public void Draw(DrawS st, Point framecenter, Graphics g)
        {
            g.DrawPie(st.PenPoints, (float)X - st.RadiusPoints, (float)Y - st.RadiusPoints, st.RadiusPoints * 2, st.RadiusPoints * 2, 0, 360);
            g.DrawString(Name, st.TextFont, st.TextBrush, (float)X, (float)Y);
        }
        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            return Calculate.Distance(mscoords, this) < distance;
        }
    }
}
