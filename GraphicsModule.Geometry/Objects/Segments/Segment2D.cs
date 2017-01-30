using System.Drawing;
using System.Windows.Forms;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Segments
{
    /// <summary>Класс для задания и расчета параметров 2D прямой</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class Segment2D : IObject
    {
        //Прямая на плоскости

        //Переменная для работы с расчетом прямых

        //Базовая точка прямой
        public Point2D Point0 { get; set; }
        //Вторая (расчетная или заданная) точка прямой
        public Point2D Point1 { get; set; }
        public Name Name { get; set; }
        //====================================================================================================
        //================== Свойства задания и извлечения параметров 2D линии ==================================
        /// <summary>Получает или задает коэффициент kx канонического уравнения прямой</summary>
        /// <remarks></remarks>
        public double kx { get; set; }
        /// <summary>Получает или задает коэффициент ky канонического уравнения прямой</summary>
        /// <remarks></remarks>
        public double ky { get; set; }
        /// <summary>
        /// Возвращает значения координат 2D точки, инцидентной ранее заданной 2D прямой по параметру t 
        /// </summary>
        /// <param name="t">Параметр, определяющий удаление новой точки от базовой точки прямой</param>
        /// <value></value>
        /// <remarks>Расчетные формулы координат новой точки: X = Point_0.X + kx * t; Y = Point_0.Y + ky * t.</remarks>
        public Point2D GetPoint1(double t)
        {
            //Свойство, возвращающее координаты 2D точки на 2D прямой по параметру t 
            return (new Point2D(Point0.X + kx * t, Point0.Y + ky * t));
        }

        //====================================================================================================
        //================== Конструкторы ввода-вывода (расчета) параметров линии по заданным условиям ==================

        /// <summary>Инициализация нового экземпляра 2D прямой</summary>
        /// <remarks>Исходные координаты базовой точки прямой равны нулю.
        /// Исходные коэффициенты канонического уравнения прямой: kx=1; ky=0.
        /// </remarks>
        public Segment2D()
        {
            //Конструктор возвращает 2D опорную точку (заданной координатами) 2D прямой линии
            Point0 = new Point2D(0, 0);
            Point1 = new Point2D(1, 0);
            kx = 1;
            ky = 0;
        }
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
            //Контроль совпадения заданных точек
            if (Analyze.Analyze.PointPos.Coincidence(pt1, pt2)) return;
            Point0 = pt1;
            Point1 = pt2;
            kx = pt2.X - pt1.X;
            ky = pt2.Y - pt1.Y;
        }
        public Segment2D(Point2D pt1, Point2D pt2, PictureBox pb)
        {
            //Контроль совпадения заданных точек
            if (Analyze.Analyze.PointPos.Coincidence(pt1, pt2)) return;
            Point0 = pt1;
            Point1 = pt2;
            kx = pt2.X - pt1.X;
            ky = pt2.Y - pt1.Y;
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
