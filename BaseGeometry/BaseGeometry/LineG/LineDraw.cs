using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using GeomObjects.Points;
using GeomObjects.Plans;
using GeomObjects.Lines;
using GeomObjects.EquationsSysCalc;

namespace GeomObjects.Lines
{
    /// <summary>Класс отрисовки 2D и 3D прямых</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class LineDraw
    {
        public PointDraw PointDraw { get; set; }
        public Line2D LineOfPlan1X0YPositionByPicture { get; set; }
        public Line2D LineOfPlan2X0ZPositionByPicture { get; set; }
        public Line2D LineOfPlan3Y0ZPositionByPicture { get; set; }
        public Line2D LineOfPlan1X0YPositionByFrame { get; set; }
        public Line2D LineOfPlan2X0ZPositionByFrame { get; set; }
        public Line2D LineOfPlan3Y0ZPositionByFrame { get; set; }

        public Pen PenPointsX0Y { get; set; }
        public Pen PenPointsX0Z { get; set; }
        public Pen PenPointsY0Z { get; set; }

        public Pen PenLineX0Y = new Pen(Color.Black, 4);
        public Pen PenLineX0Z = new Pen(Color.Black, 4);
        public Pen PenLineY0Z = new Pen(Color.Black, 4);

        public bool FlagDrawPointPlan1X0Y { get; set; }//Флаг необходимости отрисовки горизонтальной проекции
        public bool FlagDrawPointPlan2X0Z { get; set; }//Флаг необходимости отрисовки фронтальной проекции
        public bool FlagDrawPointPlan3Y0Z { get; set; }//Флаг необходимости отрисовки профильной проекции

        //Экземпляры переменных для отрисовки линий связи проекций 3D точки
        //private Pen Pen_LinkLineXoYtoX = new System.Drawing.Pen(Color.Black, 1);
        //private Pen Pen_LinkLineXoYtoY = new System.Drawing.Pen(Color.Black, 1);
        //private Pen Pen_LinkLineXoZtoX = new System.Drawing.Pen(Color.Black, 1);
        //private Pen Pen_LinkLineXoZtoZ = new System.Drawing.Pen(Color.Black, 1);
        //private Pen Pen_LinkLineYoZtoY = new System.Drawing.Pen(Color.Black, 1);
        //private Pen Pen_LinkLineYoZtoZ = new System.Drawing.Pen(Color.Black, 1);

        public Pen PenLinkLineXoYtoX { get; set; }
        public Pen PenLinkLineXoYtoY { get; set; }
        public Pen PenLinkLineXoZtoX { get; set; }
        public Pen PenLinkLineXoZtoZ { get; set; }
        public Pen PenLinkLineYoZtoY { get; set; }
        public Pen PenLinkLineYoZtoZ { get; set; }

        public void SetPensValue()
        {
            PointDraw.Pen_LinkLineXoY_toX = this.PenLinkLineXoYtoX;
            PointDraw.Pen_LinkLineXoY_toY = this.PenLinkLineXoYtoY;
            PointDraw.Pen_LinkLineXoZ_toX = this.PenLinkLineXoZtoX;
            PointDraw.Pen_LinkLineXoZ_toZ = this.PenLinkLineXoZtoZ;
            PointDraw.Pen_LinkLineYoZ_toY = this.PenLinkLineYoZtoY;
            PointDraw.Pen_LinkLineYoZ_toZ = this.PenLinkLineYoZtoZ;
        }
        /// <summary>
        /// Инициализация нового экземпляра LineDraw
        /// </summary>
        public LineDraw()
        {
            PointDraw = new PointDraw();

            LineOfPlan1X0YPositionByFrame = new Line2D();
            LineOfPlan2X0ZPositionByFrame = new Line2D();
            LineOfPlan3Y0ZPositionByFrame = new Line2D();

            LineOfPlan1X0YPositionByPicture = new Line2D();
            LineOfPlan2X0ZPositionByPicture = new Line2D();
            LineOfPlan3Y0ZPositionByPicture = new Line2D();
        }
        /// <summary>
        /// Инициализация нового экземпляра PointDraw
        /// </summary>
        /// <param name="Line3DSource"></param>
        public LineDraw(Line3D Line3DSource)
        {
            PointDraw = new PointDraw();

            LineOfPlan1X0YPositionByFrame = new Line2D();
            LineOfPlan2X0ZPositionByFrame = new Line2D();
            LineOfPlan3Y0ZPositionByFrame = new Line2D();

            LineOfPlan1X0YPositionByPicture = this.CnvLine3DProjection(Line3DSource.LineOfPlan1_X0Y);
            LineOfPlan2X0ZPositionByPicture = this.CnvLine3DProjection(Line3DSource.LineOfPlan2_X0Z);
            LineOfPlan3Y0ZPositionByPicture = this.CnvLine3DProjection(Line3DSource.LineOfPlan3_Y0Z);
        }
        /// <summary>
        /// Инициализация нового экземпляра PointDraw
        /// </summary>
        /// <param name="Line3DSource"></param>
        /// <param name="FrameCentreSource"></param>
        public LineDraw(Line3D Line3DSource, Point FrameCentreSource)
        {

        }
        /// <summary>
        /// Инициализация нового экземпляра PointDraw
        /// </summary>
        /// <param name="LineOfPlan1X0YSource"></param>
        /// <param name="LineOfPlan2X0ZSource"></param>
        /// <param name="LineOfPlan3Y0ZSource"></param>
        public LineDraw(LineOfPlan1X0Y LineOfPlan1X0YSource, LineOfPlan2X0Z LineOfPlan2X0ZSource, LineOfPlan3Y0Z LineOfPlan3Y0ZSource)
        {
            if (LineOfPlan1X0YSource != null)
            {
                LineOfPlan1X0YPositionByFrame = new Line2D();
                LineOfPlan1X0YPositionByPicture = this.CnvLine3DProjection(LineOfPlan1X0YSource);
            }
            if (LineOfPlan2X0ZSource != null)
            {
                LineOfPlan2X0ZPositionByFrame = new Line2D();
                LineOfPlan2X0ZPositionByPicture = this.CnvLine3DProjection(LineOfPlan2X0ZSource);
            }
            if (LineOfPlan3Y0ZSource != null)
            {
                LineOfPlan3Y0ZPositionByFrame = new Line2D();
                LineOfPlan3Y0ZPositionByPicture = this.CnvLine3DProjection(LineOfPlan3Y0ZSource);
            }
        }
        /// <summary>
        /// Инициализация нового экземпляра PointDraw
        /// </summary>
        /// <param name="LineOfPlan1X0YSource"></param>
        /// <param name="LineOfPlan2X0ZSource"></param>
        /// <param name="LineOfPlan3Y0ZSource"></param>
        /// <param name="FrameCentreSource"></param>
        public LineDraw(LineOfPlan1X0Y LineOfPlan1X0YSource, LineOfPlan2X0Z LineOfPlan2X0ZSource, LineOfPlan3Y0Z LineOfPlan3Y0ZSource, Point FrameCentreSource)
        {
            if (LineOfPlan1X0YSource != null)
            {
                LineOfPlan1X0YPositionByPicture = this.CnvLine3DProjection(LineOfPlan1X0YSource);
                LineOfPlan1X0YPositionByFrame = this.LinePositionCorrection(this.LineOfPlan1X0YPositionByPicture, this.PenLineX0Y.Width, FrameCentreSource);

            }
            if (LineOfPlan2X0ZSource != null)
            {
                LineOfPlan2X0ZPositionByPicture = this.CnvLine3DProjection(LineOfPlan2X0ZSource);
                LineOfPlan2X0ZPositionByFrame = this.LinePositionCorrection(this.LineOfPlan2X0ZPositionByPicture, this.PenLineX0Z.Width, FrameCentreSource);

            }
            if (LineOfPlan3Y0ZSource != null)
            {
                LineOfPlan3Y0ZPositionByPicture = this.CnvLine3DProjection(LineOfPlan3Y0ZSource);
                LineOfPlan3Y0ZPositionByFrame = this.LinePositionCorrection(this.LineOfPlan3Y0ZPositionByPicture, this.PenLineY0Z.Width, FrameCentreSource);

            }
        }
        /// <summary>
        /// Инициализация нового экземпляра LineDraw
        /// </summary>
        /// <param name="lineOfPlan1X0YSource"></param>
        /// <param name="lineOfPlan2X0ZSource"></param>
        /// <param name="lineOfPlan3Y0ZSource"></param>
        /// <param name="frameCentreSource"></param>
        public LineDraw(LineOfPlan1X0Y lineOfPlan1X0YSource, 
                        LineOfPlan2X0Z lineOfPlan2X0ZSource, 
                        LineOfPlan3Y0Z lineOfPlan3Y0ZSource, 
                        Pen penPointsX0Y, 
                        Pen penPointsX0Z,
                        Pen penPointsY0Z,
                        Pen penLineX0Y,
                        Pen penLineX0Z,
                        Pen penLineY0Z,
                        Point frameCentreSource)
        {
            if (lineOfPlan1X0YSource != null)
            {
                PenPointsX0Y = penPointsX0Y;
                PenLineX0Y = penLineX0Y;
                LineOfPlan1X0YPositionByPicture = LinePositionCorrection(this.CnvLine3DProjection(lineOfPlan1X0YSource), frameCentreSource);
                LineOfPlan1X0YPositionByFrame = LinePositionCorrection(this.CnvLine3DProjection(lineOfPlan1X0YSource), this.PenPointsX0Y.Width, frameCentreSource);

            }
            if (lineOfPlan2X0ZSource != null)
            {
                PenPointsX0Z = penPointsX0Z;
                PenLineX0Z = penLineX0Z;
                LineOfPlan2X0ZPositionByPicture = LinePositionCorrection(this.CnvLine3DProjection(lineOfPlan2X0ZSource), frameCentreSource);
                LineOfPlan2X0ZPositionByFrame = LinePositionCorrection(this.CnvLine3DProjection(lineOfPlan2X0ZSource), this.PenPointsX0Z.Width, frameCentreSource);

            }
            if (lineOfPlan3Y0ZSource != null)
            {
                PenPointsY0Z = penPointsY0Z;
                PenLineY0Z = penLineY0Z;
                LineOfPlan3Y0ZPositionByPicture = LinePositionCorrection(this.CnvLine3DProjection(lineOfPlan3Y0ZSource), frameCentreSource);
                LineOfPlan3Y0ZPositionByFrame = LinePositionCorrection(this.CnvLine3DProjection(lineOfPlan3Y0ZSource), this.PenPointsY0Z.Width, frameCentreSource);

            }
        }
        /// <summary>
        /// Корректирует координаты точек прямой
        /// </summary>
        /// <param name="line2DSource"></param>
        /// <param name="PointDiametre"></param>
        /// <param name="frameCentreSource"></param>
        /// <returns></returns>
        public Line2D LinePositionCorrection(Line2D line2DSource, Point frameCentreSource)
        {
            Line2D line2DVar = new Line2D();

            line2DVar.Point_0.X = line2DSource.Point_0.X + frameCentreSource.X;
            line2DVar.Point_0.Y = line2DSource.Point_0.Y + frameCentreSource.Y;

            line2DVar.Point_1.X = line2DSource.Point_1.X + frameCentreSource.X;
            line2DVar.Point_1.Y = line2DSource.Point_1.Y + frameCentreSource.Y;

            return line2DVar;
        }
        /// <summary>
        /// Корректирует координаты точек прямой для отрисовки
        /// </summary>
        /// <param name="Line2DSource"></param>
        /// <param name="PointDiametre"></param>
        /// <param name="FrameCentreSource"></param>
        /// <returns></returns>
        public Line2D LinePositionCorrection(Line2D Line2DSource, float PointDiametre, Point FrameCentreSource)
        {
            Line2D Line2DVar = new Line2D();

            Line2DVar.Point_0.X = Line2DSource.Point_0.X + FrameCentreSource.X - (int)PointDiametre / 2;
            Line2DVar.Point_0.Y = Line2DSource.Point_0.Y + FrameCentreSource.Y - (int)PointDiametre / 2;

            Line2DVar.Point_1.X = Line2DSource.Point_1.X + FrameCentreSource.X - (int)PointDiametre / 2;
            Line2DVar.Point_1.Y = Line2DSource.Point_1.Y + FrameCentreSource.Y - (int)PointDiametre / 2;

            return Line2DVar;
        }
        /// <summary>
        /// Инициализация нового экземпляра PointDraw
        /// </summary>
        /// <param name="Point0Source"></param>
        /// <param name="Point1Source"></param>
        /// <returns></returns>
        public LineOfPlan1X0Y CnvPointsToLineOfPlan1X0Y(Point3D Point0Source, Point3D Point1Source)
        {
            return new LineOfPlan1X0Y(Point0Source, Point1Source);
        }

        public LineOfPlan2X0Z CnvPointsToLineOfPlan2X0Z(Point3D Point0Source, Point3D Point1Source)
        {
            return new LineOfPlan2X0Z(Point0Source, Point1Source);
        }

        public LineOfPlan3Y0Z CnvPointsToLineOfPlan3Y0Z(Point3D Point0Source, Point3D Point1Source)
        {
            return new LineOfPlan3Y0Z(Point0Source, Point1Source);
        }

        public Line2D CnvPointsToLine2D(Point Point0Source, Point Point1Source)
        {
            return new Line2D(PointDraw.CnvPoint_ToPoint2D(Point0Source), PointDraw.CnvPoint_ToPoint2D(Point1Source));
        }

        public Line2D CnvPointsToLine2D(PointF Point0Source, PointF Point1Source)
        {
            return new Line2D(PointDraw.CnvPointF_ToPoint2D(Point0Source), PointDraw.CnvPointF_ToPoint2D(Point1Source));
        }

        //================================================================ Методы расчета крайних точек для отрисовки прямой линии =============================================================

        /// <summary>
        /// Рассчитывает точки, принадлежащие прямой и находящиеся на границе заданной области отрисовки в абсолютных координатах
        /// </summary>
        /// <param name="point0">Первая точка прямой</param>
        /// <param name="point1">Вторая точка прямой</param>
        /// <param name="width">Ширина области отрисовки</param>
        /// <param name="height">Высота области отрисовки</param>
        /// <returns>Массив, состоящий из двух точек, лежащих на границе области отрисовки</returns>
        public static Point[] CalculatePointsToDrawLineInPictureBox(Point point0, Point point1, int width, int height)
        {
            int A = point0.Y - point1.Y;
            int B = point1.X - point0.X;
            int C = point0.X * point1.Y - point1.X * point0.Y;
            List<Point> linePoints = new List<Point>();
            if (A == 0)
            {
                return new Point[]
                {
                    new Point(0, point0.Y),
                    new Point(width, point0.Y)
                };
            }
            else if (B == 0)
            {
                return new Point[]
                {
                    new Point(point0.X, 0),
                    new Point(point0.X, height)
                };
            }

            /// предполагаем, что y = 0, и смотрим, имеется ли такая положительная координата
            if ((-C / A) >= 0)
            {
                linePoints.Add(new Point((int)Math.Round((double)(-C / A)), 0));
            }
            // x = 0
            if ((-C / B) >= 0)
            {
                linePoints.Add(new Point(0, (int)Math.Round((double)(-C / B))));

            }
            /// x = max
            if ((-(A * width + C) / B) >= 0)
            {
                linePoints.Add(new Point(width, (int)Math.Round((double)-(A * width + C) / B)));
            }
            /// y = max
            if ((-(B * height + C) / A) >= 0)
            {
                linePoints.Add(new Point((int)Math.Round((double)-(B * height + C) / A), height));
            }
            return new Point[]
                {
                    new Point(linePoints[0].X, linePoints[0].Y),
                    new Point(linePoints[1].X, linePoints[1].Y)
                };
        }
        /// <summary>
        /// Рассчитывает точки, принадлежащие прямой и находящиеся на границе заданной области отрисовки в абсолютных координатах
        /// </summary>
        /// <param name="point0">Первая точка прямой</param>
        /// <param name="point1">Вторая точка прямой</param>
        /// <param name="width">Ширина области отрисовки</param>
        /// <param name="height">Высота области отрисовки</param>
        /// <param name="coordStart">Точка, являющая собой верхний левый угол</param>
        /// <returns>Массив, состоящий из двух точек, лежащих на границе области отрисовки</returns>
        public static Point[] CalculatePointsToDrawLineInPictureBox(Point point0, Point point1, int width, int height, Point coordStart)
        {
            //1. Вычисляем коэффициенты общего уравнениия прямой
            double A = point0.Y - point1.Y;
            double B = point1.X - point0.X;
            double C = point0.X * point1.Y - point1.X * point0.Y;
            List<Point> linePoints = new List<Point>(); // возвращаемый массив
            if (A == 0)
            {
                return new Point[]
                {
                    new Point(coordStart.X, point0.Y),
                    new Point(coordStart.X + width, point0.Y)
                };
            }
            else if (B == 0)
            {
                return new Point[]
                {
                    new Point(point0.X, coordStart.Y),
                    new Point(point0.X, coordStart.Y + height)
                };
            }

            /// предполагаем, что y = 0, и смотрим, имеется ли такая положительная координата
            if ((-(B * coordStart.Y + C) / A) >= coordStart.X && (-(B * coordStart.Y + C) / A) <= (coordStart.X + width))
            {
                linePoints.Add(new Point((int)Math.Round((double)(-(B * coordStart.Y + C) /A)), coordStart.Y));
            }
            // x = 0
            if ((-(A * coordStart.X + C) / B) >= coordStart.Y && (-(A * coordStart.X + C) / B) <= (coordStart.Y + height))
            {
                linePoints.Add(new Point(coordStart.X, (int)Math.Round((double)(-(A * coordStart.X + C) / B))));

            }
            /// x = max
            if ((-(A * (coordStart.X + width) + C) / B) >= coordStart.Y && (-(A * (coordStart.X + width) + C) / B) <= (coordStart.Y + height))
            {
                linePoints.Add(new Point(coordStart.X + width, (int)Math.Round((double)-(A * (coordStart.X + width) + C) / B)));
            }
            /// y = max
            if ((-(B * (coordStart.Y + height) + C) / A) >= coordStart.X && (-(B * (coordStart.Y + height) + C) / A) <= (coordStart.X + width))
            {
                linePoints.Add(new Point((int)Math.Round((double)-(B * (coordStart.Y + height) + C) / A), coordStart.Y + height));
            }

            return new Point[]
                {
                    new Point(linePoints[0].X, linePoints[0].Y),
                    new Point(linePoints[1].X, linePoints[1].Y)
                };
        }

        //======================== Функции преобразования объектов Line3D в Line2D ========================
        //-------------------------- Функции преобразования без корректировки центра системы координат и пера для рисования --------------------------

        public Line2D CnvLine3DProjection(LineOfPlan1X0Y lineProjection)
        {
            var Point0Var = new Point2D(-(int)lineProjection.Point_0.X, (int)lineProjection.Point_0.Y);
            var Point1Var = new Point2D(-(int)lineProjection.Point_1.X, (int)lineProjection.Point_1.Y);
            return new Line2D(Point0Var, Point1Var);
        }

        public Line2D CnvLine3DProjection(LineOfPlan2X0Z lineProjection)
        {
            var Point0Var = new Point2D(-(int)lineProjection.Point_0.X, -(int)lineProjection.Point_0.Z);
            var Point1Var = new Point2D(-(int)lineProjection.Point_1.X, -(int)lineProjection.Point_1.Z);
            return new Line2D(Point0Var, Point1Var);
        }

        public Line2D CnvLine3DProjection(LineOfPlan3Y0Z lineProjection)
        {
            var Point0Var = new Point2D((int)lineProjection.Point_0.Y, -(int)lineProjection.Point_0.Z);
            var Point1Var = new Point2D((int)lineProjection.Point_1.Y, -(int)lineProjection.Point_1.Z);
            return new Line2D(Point0Var, Point1Var);
        }

        //================================================================ Методы отрисовки проекций 3D прямой =============================================================

        /// <summary>
        /// Отрисовка заданной проекции 3D прямой, расположенной на Горизонтальной плоскости проекций (Pi1) системы координат Монжа
        /// </summary>
        /// <param name="lineOfPlan1X0Y">Заданная проекция прямой</param>
        /// <param name="pointRadius">Заданный радиус точки, которая будет отрисована</param>
        /// <param name="prame2DCentre">Точка, определяющая положение начала системы координат Монжа</param>
        /// <param name="width">Ширина области отрисовки</param>
        /// <param name="height">Высота области отрисовки</param>
        /// <param name="graphicsSource">Поверхность для отрисовки</param>
        /// <remarks>Положение центра точки корректируется в зависимости от центра системы координат Монжа и заданного радиуса точки</remarks>
        public void DrawLineProjection(LineOfPlan1X0Y lineOfPlan1X0Y, int pointRadius, Point prame2DCentre, int width, int height, ref Graphics graphicsSource)
        {
            var point0ProectionTemp = PointDraw.PointPositionCorrection(PointDraw.CnvPoint3DProjection_ToPoint(lineOfPlan1X0Y.Point_0), pointRadius, prame2DCentre);
            var point1ProectionTemp = PointDraw.PointPositionCorrection(PointDraw.CnvPoint3DProjection_ToPoint(lineOfPlan1X0Y.Point_1), pointRadius, prame2DCentre);

            graphicsSource.DrawPie(PenPointsX0Y, Convert.ToInt32(point0ProectionTemp.X), Convert.ToInt32(point0ProectionTemp.Y), pointRadius * 2 + 1, pointRadius * 2 + 1, 0, 360);
            graphicsSource.DrawPie(PenPointsX0Y, Convert.ToInt32(point1ProectionTemp.X), Convert.ToInt32(point1ProectionTemp.Y), pointRadius * 2 + 1, pointRadius * 2 + 1, 0, 360);

            Point[] points = CalculatePointsToDrawLineInPictureBox(point0ProectionTemp, point1ProectionTemp, width, height);

            graphicsSource.DrawLine(PenLineX0Y, points[0], points[1]);
        }

        /// <summary>
        /// Отрисовка заданной проекции 3D прямой, расположенной на Фронтальной плоскости проекций (Pi2) системы координат Монжа
        /// </summary>
        /// <param name="lineOfPlan2X0Z">Заданная проекция прямой</param>
        /// <param name="pointRadius">Заданный радиус точки, которая будет отрисована</param>
        /// <param name="prame2DCentre">Точка, определяющая положение начала системы координат Монжа</param>
        /// <param name="width">Ширина области отрисовки</param>
        /// <param name="height">Высота области отрисовки</param>
        /// <param name="graphicsSource">Поверхность для отрисовки</param>
        /// <remarks>Положение центра точки корректируется в зависимости от центра системы координат Монжа и заданного радиуса точки</remarks>
        public void DrawLineProjection(LineOfPlan2X0Z lineOfPlan2X0Z, int pointRadius, Point prame2DCentre, int width, int height, ref Graphics graphicsSource)
        {
            var point0ProectionTemp = PointDraw.PointPositionCorrection(PointDraw.CnvPoint3DProjection_ToPoint(lineOfPlan2X0Z.Point_0), pointRadius, prame2DCentre);
            var point1ProectionTemp = PointDraw.PointPositionCorrection(PointDraw.CnvPoint3DProjection_ToPoint(lineOfPlan2X0Z.Point_1), pointRadius, prame2DCentre);

            graphicsSource.DrawPie(PenPointsX0Y, Convert.ToInt32(point0ProectionTemp.X), Convert.ToInt32(point0ProectionTemp.Y), pointRadius * 2 + 1, pointRadius * 2 + 1, 0, 360);
            graphicsSource.DrawPie(PenPointsX0Y, Convert.ToInt32(point1ProectionTemp.X), Convert.ToInt32(point1ProectionTemp.Y), pointRadius * 2 + 1, pointRadius * 2 + 1, 0, 360);

            Point[] points = CalculatePointsToDrawLineInPictureBox(point0ProectionTemp, point1ProectionTemp, width, height);

            graphicsSource.DrawLine(PenPointsX0Y, points[0], points[1]);
        }

        /// <summary>
        /// Отрисовка заданной проекции 3D прямой, расположенной на Профильной плоскости проекций (Pi3) системы координат Монжа
        /// </summary>
        /// <param name="lineOfPlan3Y0Z">Заданная проекция прямой</param>
        /// <param name="pointRadius">Заданный радиус точки, которая будет отрисована</param>
        /// <param name="prame2DCentre">Точка, определяющая положение начала системы координат Монжа</param>
        /// <param name="width">Ширина области отрисовки</param>
        /// <param name="height">Высота области отрисовки</param>
        /// <param name="graphicsSource">Поверхность для отрисовки</param>
        /// <remarks>Положение центра точки корректируется в зависимости от центра системы координат Монжа и заданного радиуса точки</remarks>
        public void DrawLineProjection(LineOfPlan3Y0Z lineOfPlan3Y0Z, int pointRadius, Point prame2DCentre, int width, int height, ref Graphics graphicsSource)
        {
            var point0ProectionTemp = PointDraw.PointPositionCorrection(PointDraw.CnvPoint3DProjection_ToPoint(lineOfPlan3Y0Z.Point_0), pointRadius, prame2DCentre);
            var point1ProectionTemp = PointDraw.PointPositionCorrection(PointDraw.CnvPoint3DProjection_ToPoint(lineOfPlan3Y0Z.Point_1), pointRadius, prame2DCentre);

            graphicsSource.DrawPie(PenPointsX0Y, Convert.ToInt32(point0ProectionTemp.X), Convert.ToInt32(point0ProectionTemp.Y), pointRadius * 2 + 1, pointRadius * 2 + 1, 0, 360);
            graphicsSource.DrawPie(PenPointsX0Y, Convert.ToInt32(point1ProectionTemp.X), Convert.ToInt32(point1ProectionTemp.Y), pointRadius * 2 + 1, pointRadius * 2 + 1, 0, 360);

            Point[] points = CalculatePointsToDrawLineInPictureBox(point0ProectionTemp, point1ProectionTemp, width, height);

            graphicsSource.DrawLine(PenPointsX0Y, points[0], points[1]);
        }

        //================================================================ Методы отрисовки линий связи =============================================================

        /// <summary>
        /// Отрисовка линий связи из проекции прямой, расположенной на Горизонтальной плоскости проекций (Pi1) системы координат Монжа
        /// </summary>
        /// <param name="lineOfPlan1X0Y">Заданная проекция прямой</param>
        /// <param name="linkPointsToX">Метка включения вертикального участка линии связи, проходящего от заданной проекции прямой до горизонтальной оси X горизонтальной плоскости проекций (Pi1)</param>
        /// <param name="linkPointsToY">Метка включения горизонтального участка линии связи, проходящего от заданной проекции прямой до вертикальной оси Y горизонтальной плоскости проекций (Pi1)</param>
        /// <param name="linkXToBorderPi2">Метка включения вертикального участка линии связи, проходящего от горизонтальной оси X до верхней границы фронтальной плоскости проекций (Pi2)</param>
        /// <param name="linkYToBorderPi3">Метка включения вертикального участка линии связи, проходящего от горизонтальной оси Y профильной плоскости проекций (Pi3) до верхней границы профильной плоскости проекций (Pi3)</param>
        /// <param name="linkCurveY1ToY3">Метка включения участка линии связи - дуги, проходящей от вертикальной оси Y горизонтальной плоскости проекций (Pi1) до горизонтальной оси Y профильной плоскости проекций (Pi3)</param>
        /// <param name="frame2DCentre">Точка, определяющая положение начала системы координат Монжа</param>
        /// <param name="graphicsSource">Поверхность для отрисовки</param>
        /// <remarks>Отрисовывает линии связи, исходящие от заданной проекции линии до границ области</remarks>
        public void DrawLinkLine(LineOfPlan1X0Y lineOfPlan1X0Y, bool linkPointsToX, bool linkPointsToY, bool linkXToBorderPi2, bool linkYToBorderPi3, bool linkCurveY1ToY3, Point frame2DCentre, ref Graphics graphicsSource)
        {
            PointDraw.DrawLinkLine(lineOfPlan1X0Y.Point_0, linkPointsToX, linkPointsToY, linkXToBorderPi2, linkYToBorderPi3, linkCurveY1ToY3, frame2DCentre, ref graphicsSource);
            PointDraw.DrawLinkLine(lineOfPlan1X0Y.Point_1, linkPointsToX, linkPointsToY, linkXToBorderPi2, linkYToBorderPi3, linkCurveY1ToY3, frame2DCentre, ref graphicsSource);
        }

        /// <summary>
        /// Отрисовка линий связи из проекции прямой, расположенной на Фронтальной плоскости проекций (Pi2) системы координат Монжа
        /// </summary>
        /// <param name="lineOfPlan3Y0Z">Заданная проекция прямой</param>
        /// <param name="linkPointsToY">Метка включения вертикального участка линии связи, проходящего от заданной проекции прямой до горизонтальной оси X фронтальной плоскости проекций (Pi2)</param>
        /// <param name="linkPointsToZ">Метка включения горизонтального участка линии связи, проходящего от заданной проекции прямой до вертикальной оси Z фронтальной плоскости проекций (Pi2)</param>
        /// <param name="linkXToBorderPi1">Метка включения вертикального участка линии связи, проходящего от горизонтальной оси X до нижней границы горизонтальной плоскости проекций (Pi1)</param>
        /// <param name="linkYToBorderPi2">Метка включения горизонтального участка линии связи, проходящего от вертикальной оси Z до правой границы профильной плоскости проекций (Pi3)</param>
        /// <param name="frame2DCentre">Точка, определяющая положение начала системы координат Монжа</param>
        /// <param name="graphicsSource">Поверхность для отрисовки</param>
        /// <remarks>Отрисовывает линии связи, исходящие от заданной проекции прямой до границ области рисования</remarks>
        public void DrawLinkLine(LineOfPlan2X0Z lineOfPlan2X0Z, bool linkPointsToX, bool linkPointsToZ, bool linkXToBorderPi1, bool linkYToBorderPi3, Point frame2DCentre, ref Graphics graphicsSource)
        {
            PointDraw.DrawLinkLine(lineOfPlan2X0Z.Point_0, linkPointsToX, linkPointsToZ, linkXToBorderPi1, linkYToBorderPi3, frame2DCentre, ref graphicsSource);
            PointDraw.DrawLinkLine(lineOfPlan2X0Z.Point_1, linkPointsToX, linkPointsToZ, linkXToBorderPi1, linkYToBorderPi3, frame2DCentre, ref graphicsSource);
        }

        /// <summary>
        /// Отрисовка линий связи из проекции прямой, расположенной на Профильной плоскости проекции (Pi3) системы координат Монжа
        /// </summary>
        /// <param name="lineOfPlan3Y0Z">Заданная проекция прямой</param>
        /// <param name="linkPointsToY">Метка включения вертикального участка линии связи, проходящего от заданной проекции прямой до оси горизонтальной Y профильной плоскости проекций (Pi3)</param>
        /// <param name="linkPointsToZ">Метка включения горизонтального участка линии связи, проходящего от заданной проекции прямой до вертикальной оси Z профильной плоскости проекций (Pi3)</param>
        /// <param name="linkXToBorderPi1">Метка включения горизонтального участка линии связи, проходящего от вертикальной оси Y горизонтальной плоскости проекций (Pi1) до левой границы горизонтальной плоскости проекций (Pi1)</param>
        /// <param name="linkYToBorderPi2">Метка включения горизонтального участка линии связи, проходящего от вертикальной оси Z фронтальной плоскости проекций (Pi2) до левой границы фронтальной плоскости проекций (Pi2)</param>
        /// <param name="linkCurveY3ToY1">Метка включения участка линии связи - дуги, проходящей от горизонтальной оси Y профильной плоскости проекций (Pi3) до вертикальной оси Y горизонтальной плоскости проекций (Pi1)</param>
        /// <param name="frame2DCentre">Точка, определяющая положение начала системы координат Монжа</param>
        /// <param name="graphicsSource">Поверхность для отрисовки</param>
        /// <remarks>При нулевом значении координаты Y заданной проекции точки линии связи не отрисовываются</remarks>
        public void DrawLinkLine(LineOfPlan3Y0Z lineOfPlan3Y0Z, bool linkPointsToY, bool linkPointsToZ, bool linkXToBorderPi1, bool linkYToBorderPi2, bool linkCurveY3ToY1, Point frame2DCentre, ref Graphics graphicsSource)
        {
            PointDraw.DrawLinkLine(lineOfPlan3Y0Z.Point_0, linkPointsToY, linkPointsToZ, linkXToBorderPi1, linkYToBorderPi2, linkCurveY3ToY1, frame2DCentre, ref graphicsSource);
            PointDraw.DrawLinkLine(lineOfPlan3Y0Z.Point_1, linkPointsToY, linkPointsToZ, linkXToBorderPi1, linkYToBorderPi2, linkCurveY3ToY1, frame2DCentre, ref graphicsSource);
        }

        /// <summary>
        /// Отрисовка линий связи из проекций прямой, расположенных на Горизонтальной, Фронтальной, Профильной плоскостей проекций (Pi1, Pi2, Pi3) системы координат Монжа
        /// </summary>
        /// <param name="lineOfPlan1X0Y">Заданная проекция прямой на Горизонтальной плоскости проекций (Pi1)</param>
        /// <param name="lineOfPlan2X0Z">Заданная проекция прямой на Фронтальной плоскости проекций (Pi2)</param>
        /// <param name="lineOfPlan3Y0Z">Заданная проекция прямой на Профильной плоскости проекций (Pi3)</param>
        /// <param name="frame2DCentre">Точка, определяющая положение начала системы координат Монжа</param>
        /// <param name="graphicsSource">Инструмент прорисовки прямой</param>
        /// /// <remarks>Контролирует значение "null" заданных проекций точек. Контролирует нулевые значения координат заданных проекций точек.
        ///  Исходя из результатов контроля осуществляет различную отрисовку линий связи.</remarks>
        public void DrawLinkLine(LineOfPlan1X0Y lineOfPlan1X0Y, LineOfPlan2X0Z lineOfPlan2X0Z, LineOfPlan3Y0Z lineOfPlan3Y0Z, Point frame2DCentre, ref Graphics graphicsSource)
        {
            PointDraw.DrawLinkLine(lineOfPlan1X0Y.Point_0, lineOfPlan2X0Z.Point_0, lineOfPlan3Y0Z.Point_0, frame2DCentre, ref graphicsSource);
            PointDraw.DrawLinkLine(lineOfPlan1X0Y.Point_1, lineOfPlan2X0Z.Point_1, lineOfPlan3Y0Z.Point_1, frame2DCentre, ref graphicsSource);
        }

        /// <summary>
        /// Отрисовка линий связи, исходящих из трех проекций (Горизонтальной, Фронтальной и Профильной) заданной 3D прямой
        /// </summary>
        /// <param name="line3DSource">Заданная 3D прямая</param>
        /// <param name="frame2DCentre">Точка, определяющая положение начала системы координат Монжа</param>
        /// <param name="graphicsSource">Инструмент прорисовки линии</param>
        /// /// <remarks>Контролирует значение "null" заданных проекций точек. Контролирует нулевые значения координат заданных проекций точек.
        ///  Исходя из результатов контроля осуществляет различную отрисовку линий связи.</remarks>
        public void DrawLinkLine(Line3D line3DSource, Point frame2DCentre, ref Graphics graphicsSource)
        {
            this.DrawLinkLine(line3DSource.LineOfPlan1_X0Y, line3DSource.LineOfPlan2_X0Z, line3DSource.LineOfPlan3_Y0Z, frame2DCentre, ref graphicsSource);
        }

        //======================================================================================================================
        /// <summary>
        /// Определяет тип проекции (квадрант системы координат Монжа) 3D точки, к которой принадлежит заданная (отрисованная) прямая
        /// </summary>
        /// <param name="PointProection_Source">Заданная (отриосванная) прямая</param>
        /// <param name="Frame2D_Centre">Заданный центр системы координат</param>
        /// <returns>Возвращает проекцию 3D прямой, соответвующую плоскости проекций системы координат Монжа, в которой находится заданная (отрисованная) прямая</returns>
        /// <remarks></remarks>
        public object CreateProectionByLine2D(Line2D lineProjectionSource, Point frame2DCentre)
        {
            var lineVar = new Line2D();
            var lineOfPlan1X0Y = new LineOfPlan1X0Y();
            var lineOfPlan2X0Z = new LineOfPlan2X0Z();
            var lineOfPlan3Y0Z = new LineOfPlan3Y0Z();
            //Экземпляр горизонтальной проекции 3D точки для отрисовки в Graphics
            lineVar.Point_0.X = lineProjectionSource.Point_0.X - frame2DCentre.X;
            lineVar.Point_0.Y = lineProjectionSource.Point_0.Y - frame2DCentre.Y;
            lineVar.Point_1.X = lineProjectionSource.Point_1.X - frame2DCentre.X;
            lineVar.Point_1.Y = lineProjectionSource.Point_1.Y - frame2DCentre.Y;
            //Расчет координат указанной точки в заданной системе координат
            //FrontView() '(2-й квадрант)
            if (lineVar.Point_0.X <= 0 &&
                lineVar.Point_0.Y <= 0 &&
                lineVar.Point_1.X <= 0 &&
                lineVar.Point_1.Y <= 0
                )
            {
                lineOfPlan2X0Z.Point_0.X = -lineVar.Point_0.X;
                lineOfPlan2X0Z.Point_0.Z = -lineVar.Point_0.Y;
                lineOfPlan2X0Z.Point_1.X = -lineVar.Point_1.X;
                lineOfPlan2X0Z.Point_1.Z = -lineVar.Point_1.Y;
                return lineOfPlan1X0Y;
            }//"-" добавлен для задания реальной (имеющей только положительные координаты) 3D точки в базисе Монжа//GorizontalView() '(3-й квадрант)
            else if (lineVar.Point_0.X <= 0 &&
                lineVar.Point_0.Y >= 0 &&
                lineVar.Point_1.X <= 0 &&
                lineVar.Point_1.Y >= 0
                )
            {
                lineOfPlan1X0Y.Point_0.X = -lineVar.Point_0.X;
                lineOfPlan1X0Y.Point_0.Y = lineVar.Point_0.Y;
                lineOfPlan1X0Y.Point_1.X = -lineVar.Point_1.X;
                lineOfPlan1X0Y.Point_1.Y = lineVar.Point_1.Y;
                return lineOfPlan1X0Y;
            }//"-" добавлен для задания реальной (имеющей только положительные координаты) 3D точки в базисе Монжа//ProfileView '(1-й квадрант)
            else if (lineVar.Point_0.X >= 0 &&
                lineVar.Point_0.Y <= 0 &&
                lineVar.Point_1.X >= 0 &&
                lineVar.Point_1.Y <= 0
                )
            {
                lineOfPlan3Y0Z.Point_0.Y = lineVar.Point_0.X;
                lineOfPlan3Y0Z.Point_0.Z = -lineVar.Point_0.Y;
                lineOfPlan3Y0Z.Point_1.Y = lineVar.Point_1.X;
                lineOfPlan3Y0Z.Point_1.Z = -lineVar.Point_1.Y;
                return lineOfPlan3Y0Z;
            }//"-" добавлен для задания реальной (имеющей только положительные координаты) 3D точки в базисе Монжа//None '(4-й квадрант)
            else { return null; }//MessageBox.Show("Здесь рисовать нельзя")
        }

        public object TypeOfProjectionByPoints(Point point0ProjectionSource, Point point1ProjectionSource, Point frame2DCentre)
        {

            var point0Var = new Point();
            var point1Var = new Point();
            Line2D lineVar = new Line2D();
            var lineOfPlan1X0YVar = new LineOfPlan1X0Y();
            var lineOfPlan2X0ZVar = new LineOfPlan2X0Z();
            var lineOfPlan3Y0ZVar = new LineOfPlan3Y0Z();
            //Экземпляр горизонтальной проекции 3D точки для отрисовки в Graphics
            point0Var.X = point0ProjectionSource.X - frame2DCentre.X;
            point0Var.Y = point0ProjectionSource.Y - frame2DCentre.Y;
            point1Var.X = point1ProjectionSource.X - frame2DCentre.X;
            point1Var.Y = point1ProjectionSource.Y - frame2DCentre.Y;
            //Расчет координат указанной точки в заданной системе координат
            //FrontView() '(2-й квадрант)
            if (point0Var.X <= 0 & point0Var.Y <= 0 & point1Var.X <= 0 & point1Var.Y <= 0)
            {
                lineOfPlan2X0ZVar.Point_0.X = -point0Var.X;
                lineOfPlan2X0ZVar.Point_0.Z = -point0Var.Y;
                lineOfPlan2X0ZVar.Point_1.X = -point1Var.X;
                lineOfPlan2X0ZVar.Point_1.Z = -point1Var.Y;
                return lineOfPlan2X0ZVar;
            }//"-" добавлен для задания реальной (имеющей только положительные координаты) 3D прямой в базисе Монжа//GorizontalView() '(3-й квадрант)
            else if (point0Var.X <= 0 & point0Var.Y >= 0 & point1Var.X <= 0 & point1Var.Y >= 0)
            {
                lineOfPlan1X0YVar.Point_0.X = -point0Var.X;
                lineOfPlan1X0YVar.Point_0.Y = point0Var.Y;
                lineOfPlan1X0YVar.Point_1.X = -point1Var.X;
                lineOfPlan1X0YVar.Point_1.Y = point1Var.Y;
                return lineOfPlan1X0YVar;
            }//"-" добавлен для задания реальной (имеющей только положительные координаты) 3D прямой в базисе Монжа//ProfileView '(1-й квадрант)
            else if (point0Var.X >= 0 & point0Var.Y <= 0 & point0Var.X >= 0 & point0Var.Y <= 0)
            {
                lineOfPlan3Y0ZVar.Point_0.Y = point0Var.X;
                lineOfPlan3Y0ZVar.Point_0.Z = -point0Var.Y;
                lineOfPlan3Y0ZVar.Point_1.Y = point0Var.X;
                lineOfPlan3Y0ZVar.Point_1.Z = -point1Var.Y;
                return lineOfPlan3Y0ZVar;
            }//"-" добавлен для задания реальной (имеющей только положительные координаты) 3D прямой в базисе Монжа//None '(4-й квадрант)
            else { return null; }//MessageBox.Show("Здесь рисовать нельзя")
        }


    }
}