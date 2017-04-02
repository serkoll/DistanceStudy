using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Lines
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
        public Name Name { get; set; }
        //====================================================================================================
        //================== Свойства задания и извлечения параметров 2D линии ==================================
        /// <summary>Получает или задает коэффициент Kx канонического уравнения прямой</summary>
        /// <remarks></remarks>
        public double Kx { get; set; }
        /// <summary>Получает или задает коэффициент Ky канонического уравнения прямой</summary>
        /// <remarks></remarks>
        public double Ky { get; set; }
        private List<PointF> pts { get; set; }
        /// <summary>
        /// Возвращает значения координат 2D точки, инцидентной ранее заданной 2D прямой по параметру t 
        /// </summary>
        /// <param name="t">Параметр, определяющий удаление новой точки от базовой точки прямой</param>
        /// <value></value>
        /// <remarks>Расчетные формулы координат новой точки: X = Point_0.X + Kx * t; Y = Point_0.Y + Ky * t.</remarks>
        public Point2D GetPoint1(double t)
        {
            return (new Point2D(Point0.X + Kx * t, Point0.Y + Ky * t));
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
            if (Analyze.Analyze.PointsPosition.Coincidence(pt1, pt2)) return;
            Point0 = pt1;
            Point1 = pt2;
            Kx = pt2.X - pt1.X;
            Ky = pt2.Y - pt1.Y;
            Name = new Name();
            pt1.Name = Name;
            pt2.Name = Name;
        }
        //TODO: избавиться от этого конструктора
        public Line2D(Point2D pt1, Point2D pt2, PictureBox pb)
        {
            //Контроль совпадения заданных точек
            if (Analyze.Analyze.PointsPosition.Coincidence(pt1, pt2)) return;
            Point0 = pt1;
            Point1 = pt2;
            Kx = pt2.X - pt1.X;
            Ky = pt2.Y - pt1.Y;
            CalculatePointsForDraw(pb);
        }
        /// <summary>
        /// Задает перпендикуляр из указанной 2D точки к указанной 2D прямой
        /// </summary>
        /// <param name="line">2D прямая, к которой строится перпендикуляр</param>
        /// <param name="pt">2D точка, из которой выставляется перепендикуляр</param>
        /// <remarks></remarks>
        public Line2D ConstructPerpendicularOfPointToLine(Line2D line, Point2D pt)
        {
            return new Line2D(pt, new Point2D(-line.Kx + pt.X, line.Ky + pt.Y));
        }

        /// <summary>
        /// Задает 2D прямую, параллельную указанной 2D прямой и проходящую через указанную 2D точку
        /// </summary>
        /// <param name="line">Заданная 2D прямая</param>
        /// <param name="pt">2D точка, через которую должна проходить параллельная прямая</param>
        /// <remarks></remarks>
        public Line2D ConstructParallelOfPointToLine(Line2D line, Point2D pt)
        {
            return new Line2D(pt, new Point2D(line.Kx + pt.X, line.Ky + pt.Y));
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
            return line.Ky / line.Kx;

        }
        public void Draw(DrawSettings settings, Point framecenter, Graphics g)
        {
            Point0.Draw(settings, framecenter, g);
            Point1.Draw(settings, framecenter, g);
            g.DrawLine(settings.PenLine2D, pts[0], pts[1]);
        }
        //TODO: исправить логику метода, привести к общему знаменателю
        private void CalculatePointsForDraw(PictureBox pb)
        {
            pts = new List<PointF>();

            if (Math.Abs(Kx) < 0.0001)
            {
                pts.Add(new PointF((float)Point0.X, 0));
                pts.Add(new PointF((float)Point0.X, pb.Height));
            }
            if (Math.Abs(Ky) < 0.0001)
            {
                pts.Add(new PointF(0, (float)Point0.Y));
                pts.Add(new PointF(pb.Width, (float)Point0.Y));
            }
            //y=0
            var x = (float)(-Point0.Y * Kx / Ky + Point0.X);
            if (x > 0) pts.Add(new PointF(x, 0));
            //y=max
            x = (float)((pb.Height - Point0.Y) * Kx / Ky + Point0.X);
            if (x < pb.Width) pts.Add(new PointF(x, pb.Height));
            if (!CheckListState(pts)) return;
            //x = 0
            var y = (float)(-Point0.X * Ky / Kx + Point0.Y);
            if (y > 0) pts.Add(new PointF(0, y));
            if (!CheckListState(pts)) return;
            //x = max
            y = (int)((pb.Width - Point0.X) * Ky / Kx + Point0.Y);
            pts.Add(new PointF(pb.Width, y));
        }
        private bool CheckListState(List<PointF> lst)
        {
            return lst.Count < 2;
        }
        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            return Analyze.Analyze.LinesPosition.IncidenceOfPoint(mscoords, this, 35 * distance);
        }

        public Name GetName()
        {
            return Name;
        }
        public void SetName(Name name)
        {
            Name = new Name(name);
            Point0.SetName(Name);
            Point1.SetName(Name);
        }
    }
}
