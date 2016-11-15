using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GraphicsModule.Geometry.Objects.Point;
using GraphicsModule.Settings;


namespace GraphicsModule.Geometry.Objects.Line
{
    /// <summary>Класс для задания и расчета параметров 2D прямой</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class Line2D : IObject
    {
        //Прямая на плоскости

        //Переменная для работы с расчетом прямых

        //Базовая точка прямой
        public Point2D Point0 { get; set; }
        //Вторая (расчетная или заданная) точка прямой
        public Point2D Point1 { get; set; }
        //====================================================================================================
        //================== Свойства задания и извлечения параметров 2D линии ==================================
        /// <summary>Получает или задает коэффициент kx канонического уравнения прямой</summary>
        /// <remarks></remarks>
        public double kx { get; set; }
        /// <summary>Получает или задает коэффициент ky канонического уравнения прямой</summary>
        /// <remarks></remarks>
        public double ky { get; set; }

        private List<PointF> pts { get; set; }
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
        public Line2D()
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
        public Line2D(Point2D pt1, Point2D pt2)
        {
            //Контроль совпадения заданных точек
            if (!Analyze.Analyze.PointPos.Coincidence(pt1, pt2))
            {
                Point0 = pt1;
                Point1 = pt2;
                kx = pt2.X - pt1.X;
                ky = pt2.Y - pt1.Y;
            }
        }
        public Line2D(Point2D pt1, Point2D pt2, PictureBox pb)
        {
            //Контроль совпадения заданных точек
            if (!Analyze.Analyze.PointPos.Coincidence(pt1, pt2))
            {
                Point0 = pt1;
                Point1 = pt2;
                kx = pt2.X - pt1.X;
                ky = pt2.Y - pt1.Y;
                CalculatePointsForDraw(pb);
            }
        }

        //====================================================================================================
        //================== Методы ввода-вывода (расчета) параметров линии по заданным условиям ==================

        /// <summary>
        /// Задает перпендикуляр из указанной 2D точки к указанной 2D прямой
        /// </summary>
        /// <param name="line">2D прямая, к которой строится перпендикуляр</param>
        /// <param name="pt">2D точка, из которой выставляется перепендикуляр</param>
        /// <remarks></remarks>
        public Line2D ConstructPerpendicularOfPointToLine(Line2D line, Point2D pt)
        {
            return new Line2D(pt, new Point2D(-line.kx + pt.X, line.ky + pt.Y));
        }

        /// <summary>
        /// Задает 2D прямую, параллельную указанной 2D прямой и проходящую через указанную 2D точку
        /// </summary>
        /// <param name="line">Заданная 2D прямая</param>
        /// <param name="pt">2D точка, через которую должна проходить параллельная прямая</param>
        /// <remarks></remarks>
        public Line2D ConstructParallelOfPointToLine(Line2D line, Point2D pt)
        {
            return new Line2D(pt, new Point2D(line.kx + pt.X, line.ky + pt.Y));
        }

        //====================================================================================================
        //================== Функции расчета параметров 2D линии по заданным условиям ==================

        /// <summary>
        /// Функция расчета значения углового коэффициента 2D прямой
        /// </summary>
        /// <param name="line">Заданная 2D прямая</param>
        /// <returns>Возвращает значение углового коэффициента 2D прямой</returns>
        /// <remarks></remarks>
        public double CalculateSlopeOfLine(Line2D line)
        {
            return line.ky / line.kx;

        }
        public void Draw(DrawS st, System.Drawing.Point framecenter, Graphics g)
        {
            g.DrawPie(st.PenPoints, (float)Point0.X - st.RadiusPoints, (float)Point0.Y - st.RadiusPoints, st.RadiusPoints * 2, st.RadiusPoints * 2, 0, 360);
            g.DrawPie(st.PenPoints, (float)Point1.X - st.RadiusPoints, (float)Point1.Y - st.RadiusPoints, st.RadiusPoints * 2, st.RadiusPoints * 2, 0, 360);
            g.DrawLine(st.PenLine2D, pts[0], pts[1]);
        }
        private void CalculatePointsForDraw(PictureBox pb)
        {
            pts = new List<PointF>();

            if (kx == 0)
            {
                pts.Add(new PointF((float)Point0.X, 0));
                pts.Add(new PointF((float)Point0.X, pb.Height));
            }
            if (ky == 0)
            {
                pts.Add(new PointF(0, (float)Point0.Y));
                pts.Add(new PointF(pb.Width, (float)Point0.Y));
            }
            //y=0
            float x = (float)(-Point0.Y * kx / ky + Point0.X);
            if (x > 0) pts.Add(new PointF(x, 0));
            //y=max
            x = (float)((pb.Height - Point0.Y) * kx / ky + Point0.X);
            if (x < pb.Width) pts.Add(new PointF(x, pb.Height));
            if (CheckListState(pts))
            {
                //x = 0
                var y = (float)(-Point0.X * ky / kx + Point0.Y);
                if (y > 0) pts.Add(new PointF(0, y));
                if (CheckListState(pts))
                {
                    //x = max
                    y = (int)((pb.Width - Point0.X) * ky / kx + Point0.Y);
                    pts.Add(new PointF(pb.Width, y));
                }
            }
        }
        private bool CheckListState(List<PointF> lst)
        {
            if (lst.Count < 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsSelected(System.Drawing.Point mscoords, float ptR, System.Drawing.Point frameCenter, double distance)
        {
            if (Analyze.Analyze.LinesPos.IncidenceOfPoint(mscoords, this, 35 * distance))
                return true;
            else
                return false;
        }
    }
}
