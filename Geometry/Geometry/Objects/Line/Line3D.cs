using System;
using System.Windows.Forms;
using System.Linq;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Collections.ObjectModel;

namespace GeometryObjects
{
    /// <summary>Класс для задания и расчета параметров 3D прямой</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class Line3D : IObject
    {
        public Point3D Point0 { get; set; }
        public Point3D Point1 { get; set; }
        public LineOfPlane1X0Y LineOfPlane1X0Y { get; set; }
        public LineOfPlane2X0Z LineOfPlane2X0Z { get; set; }
        public LineOfPlane3Y0Z LineOfPlane3Y0Z { get; set; }
        public double kx { get; set; }
        public double ky { get; set; }
        public double kz { get; set; }

        //====================================================================================================
        //================== Свойства задания и извлечения параметров 3D линии ==================================

        /// <summary>
        /// Получает 3D точки, инцидентной инцидентной ранее заданной 3D прямой по параметру t
        /// </summary>
        /// <param name="t">Параметр, определяющий удаление новой точки от базовой точки прямой</param>
        /// <value></value>
        /// <returns></returns>
        /// <remarks>Расчетные формулы координат новой точки: X = Point_0.X + kx * t; Y = Point_0.Y + ky * t; Z = Point_0.Z + kz * t.</remarks>
        public Point3D GetPoint(double t)
        {
            //Свойство, возвращающее координаты 3D точки на 3D прямой по параметру t 
            return (new Point3D(Point0.X + kx * t, Point0.Y + ky * t, Point0.Z + kz * t));
        }
        /// <summary>Инициализация нового экземпляра 2D прямой</summary>
        /// <remarks>Исходные координаты базовой точки прямой равны нулю.
        /// Исходные коэффициенты канонического уравнения прямой: kx=1; ky=0; kz=0.
        /// </remarks>
        public Line3D()
        {
            Point0 = new Point3D(0, 0, 0);
            kx = 1;
            ky = 0;
            kz = 0;
            Point1.X = kx + Point0.X;
            Point1.Y = ky + Point0.Y;
            Point1.Z = kz + Point0.Z;
        }
        public static Line3D Create(Collection<IObject> lst)
        {
            if (lst[0].GetType().Name == "LineOfPlane1X0Y")
            {
                if (lst[1].GetType().Name == "LineOfPlane2X0Z")
                    return new Line3D((LineOfPlane1X0Y)lst[0], (LineOfPlane2X0Z)lst[1]);
                else
                    return new Line3D((LineOfPlane1X0Y)lst[0], (LineOfPlane3Y0Z)lst[1]);
            }
            else if (lst[0].GetType().Name == "LineOfPlane2X0Z")
            {
                if (lst[1].GetType().Name == "LineOfPlane1X0Y")
                    return new Line3D((LineOfPlane1X0Y)lst[1], (LineOfPlane2X0Z)lst[0]);
                else
                    return new Line3D((LineOfPlane2X0Z)lst[0], (LineOfPlane3Y0Z)lst[1]);
            }
            else if (lst[1].GetType().Name == "LineOfPlane1X0Y")
                return new Line3D((LineOfPlane1X0Y)lst[1], (LineOfPlane3Y0Z)lst[0]);
            else
                return new Line3D((LineOfPlane2X0Z)lst[1], (LineOfPlane3Y0Z)lst[0]);
        }
        /// <summary> Задает 3D точку, заданную двумя (горизонтальной и фронтальной) проекциями</summary>
        /// <remarks> При неправильном заднии проекций возвращает "Nothing" </remarks>
        /// <param name="pointPi1"> Горизонтальная проекция 3D точки</param>
        /// <param name="pointPi2"> Фронтальная проекция 3D точки</param>
        public Line3D(LineOfPlane1X0Y linePi1, LineOfPlane2X0Z linePi2)
        {
            Point0 = new Point3D();
            Point1 = new Point3D();
            if (linePi1.Point0.X == linePi2.Point0.X &&
                linePi1.Point1.X == linePi2.Point1.X)
            {
                Point0.X = linePi1.Point0.X;
                Point0.Y = linePi1.Point0.Y;
                Point0.Z = linePi2.Point0.Z;
                Point1.X = linePi1.Point1.X;
                Point1.Y = linePi1.Point1.Y;
                Point1.Z = linePi2.Point1.Z;
                LineOfPlane1X0Y = linePi1;
                LineOfPlane2X0Z = linePi2;
                LineOfPlane3Y0Z = new LineOfPlane3Y0Z(new PointOfPlane3Y0Z(linePi1.Point0.Y, linePi2.Point0.Z), new PointOfPlane3Y0Z(linePi1.Point1.Y, linePi2.Point1.Z));
                Point0.InitializePointsOfPlane();
                Point1.InitializePointsOfPlane();
            }
            else if (linePi1.Point0.X == linePi2.Point1.X &&
                     linePi1.Point1.X == linePi2.Point0.X)
            {
                Point0.X = linePi1.Point1.X;
                Point0.Y = linePi1.Point1.Y;
                Point0.Z = linePi2.Point0.Z;
                Point1.X = linePi1.Point0.X;
                Point1.Y = linePi1.Point0.Y;
                Point1.Z = linePi2.Point1.Z;
                Point0.InitializePointsOfPlane();
                Point1.InitializePointsOfPlane();
                LineOfPlane1X0Y = linePi1;
                LineOfPlane2X0Z = linePi2;
                LineOfPlane3Y0Z = new LineOfPlane3Y0Z(new PointOfPlane3Y0Z(linePi1.Point1.Y, linePi2.Point0.Z), new PointOfPlane3Y0Z(linePi1.Point0.Y, linePi2.Point1.Z));
            }
        }
        /// <summary> Задает 3D точку, заданную двумя (горизонтальной и профильной) проекциями</summary>
        /// <remarks> При неправильном заднии проекций возвращает "Nothing" </remarks>
        /// <param name="pointPi1"> Горизонтальная проекция 3D точки</param>
        /// <param name="linePi3"> Профильная проекция 3D точки</param>
        public Line3D(LineOfPlane1X0Y linePi1, LineOfPlane3Y0Z linePi3)
        {
            Point0 = new Point3D();
            Point1 = new Point3D();
            if (linePi1.Point0.Y == linePi3.Point0.Y &&
                linePi1.Point1.Y == linePi3.Point1.Y)
            {
                Point0.X = linePi1.Point0.X;
                Point0.Y = linePi1.Point0.Y;
                Point0.Z = linePi3.Point0.Z;
                Point1.X = linePi1.Point1.X;
                Point1.Y = linePi1.Point1.Y;
                Point1.Z = linePi3.Point1.Z;
                Point0.InitializePointsOfPlane();
                Point1.InitializePointsOfPlane();
                LineOfPlane1X0Y = linePi1;
                LineOfPlane2X0Z = new LineOfPlane2X0Z(new PointOfPlane2X0Z(linePi1.Point0.X, linePi3.Point0.Z), new PointOfPlane2X0Z(linePi1.Point1.X, linePi3.Point1.Z));
                LineOfPlane3Y0Z = linePi3;
            }
            else if (linePi1.Point0.Y == linePi3.Point1.Y &&
                     linePi1.Point1.Y == linePi3.Point0.Y)
            {
                Point0.X = linePi1.Point0.X;
                Point0.Y = linePi1.Point0.Y;
                Point0.Z = linePi3.Point1.Z;
                Point1.X = linePi1.Point1.X;
                Point1.Y = linePi1.Point1.Y;
                Point1.Z = linePi3.Point0.Z;
                Point0.InitializePointsOfPlane();
                Point1.InitializePointsOfPlane();
                LineOfPlane1X0Y = linePi1;
                LineOfPlane2X0Z = new LineOfPlane2X0Z(new PointOfPlane2X0Z(linePi1.Point0.X, linePi3.Point1.Z), new PointOfPlane2X0Z(linePi1.Point1.X, linePi3.Point0.Z));
                LineOfPlane3Y0Z = linePi3;
            }
        }
        /// <summary> Задает 3D точку, заданную двумя (фронтальной и профильной) проекциями</summary>
        /// <remarks> При неправильном заднии проекций возвращает "Nothing" </remarks>
        /// <param name="pointPi2"> Фронтальня проекция 3D точки</param>
        /// <param name="pointPi3"> Профильная проекция 3D точки</param>
        public Line3D(LineOfPlane2X0Z linePi2, LineOfPlane3Y0Z linePi3)
        {
            Point0 = new Point3D();
            Point1 = new Point3D();
            if (linePi2.Point0.Z == linePi3.Point0.Z &&
               linePi2.Point1.Z == linePi3.Point1.Z)
            {
                Point0.X = linePi2.Point0.X;
                Point0.Y = linePi3.Point0.Y;
                Point0.Z = linePi2.Point0.Z;
                Point1.X = linePi2.Point1.X;
                Point1.Y = linePi3.Point1.Y;
                Point1.Z = linePi2.Point1.Z;
                Point0.InitializePointsOfPlane();
                Point1.InitializePointsOfPlane();
                LineOfPlane1X0Y = new LineOfPlane1X0Y(new PointOfPlane1X0Y(linePi2.Point0.X, linePi3.Point0.Y), new PointOfPlane1X0Y(linePi2.Point1.X, linePi3.Point1.Y));
                LineOfPlane2X0Z = linePi2;
                LineOfPlane3Y0Z = linePi3;
            }
            else if (linePi2.Point1.Z == linePi3.Point0.Z &&
                    linePi2.Point0.Z == linePi3.Point1.Z)
            {
                Point0.X = linePi2.Point0.X;
                Point0.Y = linePi3.Point1.Y;
                Point0.Z = linePi2.Point0.Z;
                Point1.X = linePi2.Point1.X;
                Point1.Y = linePi3.Point0.Y;
                Point1.Z = linePi2.Point1.Z;
                Point0.InitializePointsOfPlane();
                Point1.InitializePointsOfPlane();
                LineOfPlane1X0Y = new LineOfPlane1X0Y(new PointOfPlane1X0Y(linePi2.Point0.X, linePi3.Point1.Y), new PointOfPlane1X0Y(linePi2.Point1.X, linePi3.Point0.Y));
                LineOfPlane2X0Z = linePi2;
                LineOfPlane3Y0Z = linePi3;
            }
        }
        public void Draw(DrawS st, Point frameCenter, Graphics g)
        {
            LineOfPlane1X0Y.DrawLineOnly(st, frameCenter, g);
            LineOfPlane2X0Z.DrawLineOnly(st, frameCenter, g);
            LineOfPlane3Y0Z.DrawLineOnly(st, frameCenter, g);
            if (st.LinkLineSettings.IsDraw)
            {
                DrawLinkLine(st.LinkLineSettings.LinkLineX0YToX, st.LinkLineSettings.LinkLineX0YToY, st.LinkLineSettings.LinkLineX0ZToX, st.LinkLineSettings.LinkLineX0ZToZ,
                             st.LinkLineSettings.LinkLineY0ZToZ, st.LinkLineSettings.LinkLineY0ZToY, frameCenter, ref g);
            }

        }
        public void DrawLinkLine(Pen penLinkLineX0YToX, Pen penLinkLineX0YToY, Pen penLinkLineX0ZToX, Pen penLinkLineX0ZToZ, Pen penLinkLineY0ZToZ, Pen penLinkLineY0ZToY, Point frameCenter, ref Graphics graphics)
        {
            Point0.DrawLinkLine(penLinkLineX0YToX, penLinkLineX0YToY, penLinkLineX0ZToX, penLinkLineX0ZToZ,
                         penLinkLineY0ZToZ, penLinkLineY0ZToY, frameCenter, ref graphics);
            Point1.DrawLinkLine(penLinkLineX0YToX, penLinkLineX0YToY, penLinkLineX0ZToX, penLinkLineX0ZToZ,
                          penLinkLineY0ZToZ, penLinkLineY0ZToY, frameCenter, ref graphics);
        }
        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            if (LineOfPlane1X0Y.IsSelected(mscoords, ptR, frameCenter, distance) ||
               LineOfPlane2X0Z.IsSelected(mscoords, ptR, frameCenter, distance) ||
               LineOfPlane3Y0Z.IsSelected(mscoords, ptR, frameCenter, distance))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void CalculatePointsForDraw(Point frameCenter, RectangleF rc1, RectangleF rc2, RectangleF rc3)
        {
            LineOfPlane1X0Y.CalculatePointsForDraw(frameCenter, rc1);
            LineOfPlane2X0Z.CalculatePointsForDraw(frameCenter, rc2);
            LineOfPlane3Y0Z.CalculatePointsForDraw(frameCenter, rc3);
        }
        public void SpecifyBoundaryPoints(Point frameCenter, RectangleF rc1, RectangleF rc2, RectangleF rc3)
        {
            CalculatePointsForDraw(frameCenter, rc1, rc2, rc3);
            CutLineX0YtoX0Z(frameCenter, rc1);
            CutLineX0ZtoX0Y(frameCenter, rc1);
            CutLineX0ZtoY0Z(frameCenter, rc1);
            CutLineY0ZtoX0Z(frameCenter, rc1);
        }
        private void CutLineX0YtoX0Z(Point frameCenter, RectangleF rc)
        {
            if((LineOfPlane1X0Y.pts[0].X > LineOfPlane2X0Z.pts[0].X) && (LineOfPlane1X0Y.pts[0].Y == rc.Top))
            {
                var ln = new Line2D(new Point2D(LineOfPlane1X0Y.pts[0].X, LineOfPlane1X0Y.pts[0].Y),
                                    new Point2D(LineOfPlane1X0Y.pts[0].X, LineOfPlane1X0Y.pts[0].Y - 10));
                LineOfPlane2X0Z.pts[0] = Calculate.IntersectionPoint(ln, LineOfPlane2X0Z, frameCenter);
            }
            if(LineOfPlane1X0Y.pts[1].X < LineOfPlane2X0Z.pts[1].X && (LineOfPlane1X0Y.pts[1].Y == rc.Top))
            {
                var ln = new Line2D(new Point2D(LineOfPlane1X0Y.pts[1].X, LineOfPlane1X0Y.pts[1].Y),
                                    new Point2D(LineOfPlane1X0Y.pts[1].X, LineOfPlane1X0Y.pts[1].Y - 10));
                LineOfPlane2X0Z.pts[1] = Calculate.IntersectionPoint(ln, LineOfPlane2X0Z, frameCenter);
            }
        }
        private void CutLineX0ZtoX0Y(Point frameCenter, RectangleF rc)
        {
            if ((LineOfPlane2X0Z.pts[0].X > LineOfPlane1X0Y.pts[0].X) && (LineOfPlane2X0Z.pts[0].Y == rc.Top))
            {
                var ln = new Line2D(new Point2D(LineOfPlane2X0Z.pts[0].X, LineOfPlane2X0Z.pts[0].Y),
                                    new Point2D(LineOfPlane2X0Z.pts[0].X, LineOfPlane2X0Z.pts[0].Y - 10));
                LineOfPlane1X0Y.pts[0] = Calculate.IntersectionPoint(ln, LineOfPlane1X0Y, frameCenter);
            }
            if ((LineOfPlane2X0Z.pts[1].X < LineOfPlane1X0Y.pts[1].X) && (LineOfPlane2X0Z.pts[1].Y == rc.Top))
            {
                var ln = new Line2D(new Point2D(LineOfPlane2X0Z.pts[1].X, LineOfPlane2X0Z.pts[1].Y),
                                    new Point2D(LineOfPlane2X0Z.pts[1].X, LineOfPlane2X0Z.pts[1].Y - 10));
                LineOfPlane1X0Y.pts[1] = Calculate.IntersectionPoint(ln, LineOfPlane1X0Y, frameCenter);
            }
        }
        private void CutLineX0ZtoY0Z(Point frameCenter, RectangleF rc)
        {
            if ((LineOfPlane2X0Z.pts[0].Y < LineOfPlane3Y0Z.pts[0].Y) && (LineOfPlane2X0Z.pts[0].X == rc.Right))
            {
                var ln = new Line2D(new Point2D(LineOfPlane2X0Z.pts[0].X, LineOfPlane2X0Z.pts[0].Y),
                                    new Point2D(LineOfPlane2X0Z.pts[0].X - 10, LineOfPlane2X0Z.pts[0].Y));
                LineOfPlane3Y0Z.pts[0] = Calculate.IntersectionPoint(ln, LineOfPlane3Y0Z, frameCenter);
            }
            if((LineOfPlane2X0Z.pts[1].Y > LineOfPlane3Y0Z.pts[1].Y) && (LineOfPlane2X0Z.pts[1].X == rc.Right))
            {
                var ln = new Line2D(new Point2D(LineOfPlane2X0Z.pts[1].X, LineOfPlane2X0Z.pts[1].Y),
                                    new Point2D(LineOfPlane2X0Z.pts[1].X - 10, LineOfPlane2X0Z.pts[1].Y));
                LineOfPlane3Y0Z.pts[1] = Calculate.IntersectionPoint(ln, LineOfPlane3Y0Z, frameCenter);
            }
        }
        private void CutLineY0ZtoX0Z(Point frameCenter, RectangleF rc)
        {
            if ((LineOfPlane3Y0Z.pts[0].Y > LineOfPlane2X0Z.pts[0].Y) && (LineOfPlane3Y0Z.pts[0].X == rc.Right))
            {
                var ln = new Line2D(new Point2D(LineOfPlane3Y0Z.pts[0].X, LineOfPlane3Y0Z.pts[0].Y),
                                    new Point2D(LineOfPlane3Y0Z.pts[0].X - 10, LineOfPlane3Y0Z.pts[0].Y));
                LineOfPlane2X0Z.pts[0] = Calculate.IntersectionPoint(ln, LineOfPlane2X0Z, frameCenter);
            }
            if ((LineOfPlane3Y0Z.pts[1].Y > LineOfPlane2X0Z.pts[1].Y) && (LineOfPlane3Y0Z.pts[1].X == rc.Right))
            {
                var ln = new Line2D(new Point2D(LineOfPlane3Y0Z.pts[1].X, LineOfPlane3Y0Z.pts[1].Y),
                                    new Point2D(LineOfPlane3Y0Z.pts[1].X - 10, LineOfPlane3Y0Z.pts[1].Y));
                LineOfPlane2X0Z.pts[1] = Calculate.IntersectionPoint(ln, LineOfPlane2X0Z, frameCenter);
            }
        }
    }
}
