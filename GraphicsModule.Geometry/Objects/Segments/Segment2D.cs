using System.Drawing;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Segments
{
    /// <summary>Класс для задания и расчета параметров 2D прямой</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class Segment2D : IObject
    {
        public Point2D Point0 { get; set; }
        //Вторая (расчетная или заданная) точка прямой
        public Point2D Point1 { get; set; }
        public Name Name { get; set; }
        /// <summary>Получает или задает коэффициент kx канонического уравнения прямой</summary>
        /// <remarks></remarks>
        public double Kx { get; set; }
        /// <summary>Получает или задает коэффициент ky канонического уравнения прямой</summary>
        /// <remarks></remarks>
        public double Ky { get; set; }
        /// <summary>
        /// Инициализирует новый экземпляр 2D прямой с помощью задания двух точек
        /// </summary>
        /// <param name="pt1">Первая (опорная) точка прямой</param>
        /// <param name="pt2">Вторая точка прямой</param>
        /// <remarks>Рассчитывает значения постоянных коэффициентов 2D прямой, заданной двумя 2D точками.
        /// Первая заданная точка записывается в качестве опорной точки прямой.
        /// </remarks>
        public Segment2D(Point2D pt1, Point2D pt2)
        {
            if (Analyze.Analyze.PointPos.Coincidence(pt1, pt2)) return;
            Point0 = pt1;
            Point1 = pt2;
            Kx = pt2.X - pt1.X;
            Ky = pt2.Y - pt1.Y;
        }
        public void Draw(DrawS st, Point framecenter, Graphics g)
        {
            Point0.Draw(st, framecenter, g);
            Point1.Draw(st, framecenter, g);
            g.DrawLine(st.PenLine2D, new PointF((float)Point0.X, (float)Point0.Y), 
                                     new PointF((float)Point1.X, (float)Point1.Y));
        }
        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            return Analyze.Analyze.SegmentPos.IncidenceOfPoint(mscoords, this, 35 * distance);
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
    }
}
