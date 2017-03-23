using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Points
{
    /// <summary>Класс для расчета параметров 3D точки</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class Point3D : IObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Name Name { get; set; }
        public PointOfPlane1X0Y PointOfPlane1X0Y { get; set; }
        /// <summary>Получает или задает координаты проекции 3D точки на плоскость X0Z пространственной системы координат</summary>
        /// <remarks></remarks>
        public PointOfPlane2X0Z PointOfPlane2X0Z { get; set; }
        /// <summary>Получает или задает координаты проекции 3D точки на плоскость Y0Z пространственной системы координат</summary>
        /// <remarks></remarks>
        public PointOfPlane3Y0Z PointOfPlane3Y0Z { get; set; }
        /// <summary>Инициализация нового экземпляра 3D точки</summary>
        /// <remarks>Исходные координаты точки: X=0; Y=0; Z=0</remarks>
        public Point3D()
        {
            Z = 0;
            InitializePointsOfPlane();
        }
        /// <summary>Инициализирует новый экземпляр 3D точки с указанными координатами</summary>
        /// <remarks></remarks>
        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            InitializePointsOfPlane();
        }
        /// <summary>Преобразует 2D точку в 3D точку путем добавления третьей координаты</summary>
        /// <remarks></remarks>
        public Point3D(Point2D pt, double z)
        {
            X = pt.X;
            Y = pt.Y;
            Z = z;
            InitializePointsOfPlane();
        }
        public Point3D(PointOfPlane1X0Y pt1, PointOfPlane2X0Z pt2)
        {
            X = pt1.X;
            Y = pt1.Y;
            Z = pt2.Z;
            InitializePointsOfPlane();
        }
        public Point3D(PointOfPlane1X0Y pt1, PointOfPlane3Y0Z pt3)
        {
            X = pt1.X;
            Y = pt1.Y;
            Z = pt3.Z;
            InitializePointsOfPlane();
        }
        public Point3D(PointOfPlane2X0Z pt2, PointOfPlane3Y0Z pt3)
        {
            X = pt2.X;
            Y = pt3.Y;
            Z = pt2.Z;
            InitializePointsOfPlane();
        }

        public Point3D(PointOfPlane1X0Y pt1, PointOfPlane2X0Z pt2, PointOfPlane3Y0Z pt3)
        {
            X = pt1.X;
            Y = pt3.Y;
            Z = pt2.Z;
            InitializePointsOfPlane();
        }
        public static Point3D Create(Collection<IObject> points)
        {
            if (points.Count != 2) return null;
            if (points.First().GetType() == typeof(PointOfPlane1X0Y))
            {
                return points[1].GetType() == typeof(PointOfPlane2X0Z) ?
                    CreateByPointOfPlane1And2((PointOfPlane1X0Y)points[0], (PointOfPlane2X0Z)points[1]) :
                    CreateByPointOfPlane1And3((PointOfPlane1X0Y)points[0], (PointOfPlane3Y0Z)points[1]);
            }
            if (points.First().GetType() == typeof(PointOfPlane2X0Z))
            {
                return points[1].GetType() == typeof(PointOfPlane1X0Y) ?
                    CreateByPointOfPlane1And2((PointOfPlane1X0Y)points[1], (PointOfPlane2X0Z)points[0]) :
                    CreateByPointOfPlane2And3((PointOfPlane2X0Z)points[0], (PointOfPlane3Y0Z)points[1]);
            }
            return points.First().GetType() == typeof(PointOfPlane3Y0Z) ?
                CreateByPointOfPlane1And3((PointOfPlane1X0Y)points[1], (PointOfPlane3Y0Z)points[0]) :
                CreateByPointOfPlane2And3((PointOfPlane2X0Z)points[1], (PointOfPlane3Y0Z)points[0]);
        }

        public static bool IsCreatable(IList<IPointOfPlane> points)
        {
            if (points.Count != 2) return false;

            return false;
        }
        private static Point3D CreateByPointOfPlane1And2(PointOfPlane1X0Y pt1, PointOfPlane2X0Z pt2)
        {
            return Math.Abs(pt1.X - pt2.X) < 0.0001 ? new Point3D(pt1, pt2) : null;
        }
        private static Point3D CreateByPointOfPlane1And3(PointOfPlane1X0Y pt1, PointOfPlane3Y0Z pt3)
        {
            return Math.Abs(pt1.Y - pt3.Y) < 0.0001 ? new Point3D(pt1, pt3) : null;
        }
        private static Point3D CreateByPointOfPlane2And3(PointOfPlane2X0Z pt2, PointOfPlane3Y0Z pt3)
        {
            return Math.Abs(pt2.Z - pt3.Z) < 0.0001 ? new Point3D(pt2, pt3) : null;
        }
        public void InitializePointsOfPlane()
        {
            PointOfPlane1X0Y = new PointOfPlane1X0Y(X, Y);
            PointOfPlane2X0Z = new PointOfPlane2X0Z(X, Z);
            PointOfPlane3Y0Z = new PointOfPlane3Y0Z(Y, Z);
        }
        /// <summary>Передвигает ранее заданную 3D точку
        /// (изменяет коодинаты на указанные величины по осям в 3D)
        /// </summary>
        /// <remarks>Point3D.X += dx; Point3D.Y += dy; Point3D.Z += dz</remarks>
        public void PointMove(double dx, double dy, double dz) { X += dx; Y += dy; Z += dz; }//Конструктор перемещения на указанные величины по осям в 3D 
        public void Draw(Pen pen, float ptR, Point frameCenter, Graphics graphics)
        {
            PointOfPlane1X0Y.Draw(pen, ptR, frameCenter, graphics);
            PointOfPlane2X0Z.Draw(pen, ptR, frameCenter, graphics);
            PointOfPlane3Y0Z.Draw(pen, ptR, frameCenter, graphics);
        }
        public void Draw(DrawS st, Point frameCenter, Graphics g)
        {
            Draw(st.PenPoints, st.RadiusPoints, frameCenter, g);
            DrawLinkLine(st.LinkLineSettings.PenLinkLineX0YtoX, st.LinkLineSettings.PenLinkLineX0YtoY, st.LinkLineSettings.PenLinkLineX0ZtoX, st.LinkLineSettings.PenLinkLineX0ZtoZ,
                         st.LinkLineSettings.PenLinkLineY0ZtoZ, st.LinkLineSettings.PenLinkLineY0ZtoY, frameCenter, ref g);
            DrawName(st, st.RadiusPoints, frameCenter, g);
        }
        public void DrawName(DrawS st, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            PointOfPlane1X0Y.DrawName(st, poitRaduis, frameCenter, graphics);
            PointOfPlane2X0Z.DrawName(st, poitRaduis, frameCenter, graphics);
            PointOfPlane3Y0Z.DrawName(st, poitRaduis, frameCenter, graphics);
        }
        public void DrawLinkLine(Pen penLinkLineToX, Pen penLinkLinetoY, Pen penLinkLineX0ZtoX, Pen penLinkLineX0ZtoZ, Pen penLinkLineY0ZtoZ, Pen penLinkLineY0ZtoY, Point frameCenter, ref Graphics graphics)
        {
            //Отрисовка линий связи
            //Горизонтальная, фронтальная и профильная проекция имеют нулевые значения координат
            //2. Контроль равенства нулю координат двух проекций точки
            const double tolerance = 0.0001;
            if (Math.Abs(PointOfPlane1X0Y.X) < tolerance & Math.Abs(PointOfPlane1X0Y.Y) < tolerance & Math.Abs(PointOfPlane2X0Z.X) < tolerance & Math.Abs(PointOfPlane2X0Z.Z) < tolerance)//Горизонтальная и фронтальная проекции имеют нулевые значения координат
            {
                PointOfPlane3Y0Z.DrawLinkLine(penLinkLineY0ZtoZ, penLinkLineY0ZtoY, true, true, true, true, true, frameCenter, graphics);//Отрисовка линий связи Профильной проекции без ограничений
            }
            else if (Math.Abs(PointOfPlane1X0Y.X) < tolerance & Math.Abs(PointOfPlane1X0Y.Y) < tolerance & Math.Abs(PointOfPlane3Y0Z.Y) < tolerance & Math.Abs(PointOfPlane3Y0Z.Z) < tolerance)//Горизонтальная и профильная проекции имеют нулевые значения координат
            {
                PointOfPlane2X0Z.DrawLinkLine(penLinkLineX0ZtoX, penLinkLineX0ZtoZ, true, true, true, true, frameCenter, graphics); //Отрисовка линий связи Фронтальной проекции без ограничений
            }
            else if (Math.Abs(PointOfPlane2X0Z.X) < tolerance & Math.Abs(PointOfPlane2X0Z.Z) < tolerance & Math.Abs(PointOfPlane3Y0Z.Y) < tolerance & Math.Abs(PointOfPlane3Y0Z.Z) < tolerance)//Фронтальная и профильная проекции имеют нулевые значения координат
            {
                PointOfPlane1X0Y.DrawLinkLine(penLinkLineToX, penLinkLinetoY, true, true, true, true, true, frameCenter, graphics);//Отрисовка линий связи Горизонтальной проекции без ограничений
            }
            //3. Контроль равенства нулю координат одной проекции точки
            else if (Math.Abs(PointOfPlane1X0Y.X) < tolerance & Math.Abs(PointOfPlane1X0Y.Y) < tolerance)//Горизонтальная проекция имеет нулевые значения координат
            {
                PointOfPlane2X0Z.DrawLinkLine(penLinkLineX0ZtoX, penLinkLineX0ZtoZ, true, true, true, false, frameCenter, graphics); //Отрисовка линий связи Фронтальной проекции с ограничениями (не отображается связь от Z до правой границы Pi3)
                PointOfPlane3Y0Z.DrawLinkLine(penLinkLineY0ZtoZ, penLinkLineY0ZtoY, true, true, true, false, true, frameCenter, graphics);//Отрисовка линий связи Профильной проекции с ограничениями (не отображается связь от Z до левой границы Pi2)
            }
            else if (Math.Abs(PointOfPlane2X0Z.X) < tolerance & Math.Abs(PointOfPlane2X0Z.Z) < tolerance)//Фронтальная проекция имеет нулевые значения координат
            {
                //Отрисовка линий связи Горизонтальной проекции без ограничений (не отображается связь от Y до верхней границы Pi3)
                PointOfPlane1X0Y.DrawLinkLine(penLinkLineToX, penLinkLinetoY, true, true, true, false, true, frameCenter, graphics);
                //Отрисовка линий связи Профильной проекции с ограничениями (не отображается связь от Y до левой границы Pi1 и дуга (для дуги устраняется повторная отрисовка))
                PointOfPlane3Y0Z.DrawLinkLine(penLinkLineY0ZtoZ, penLinkLineY0ZtoY, true, true, false, true, false, frameCenter, graphics);
            }
            else if (Math.Abs(PointOfPlane3Y0Z.Y) < tolerance & Math.Abs(PointOfPlane3Y0Z.Z) < tolerance)//Профильная проекция имеет нулевые значения координат
            {
                //Отрисовка линий связи Горизонтальной проекции без ограничений (не отображается связь от X до верхней границы Pi2)
                PointOfPlane1X0Y.DrawLinkLine(penLinkLineToX, penLinkLinetoY, true, true, false, true, true, frameCenter, graphics);
                //Отрисовка линий связи Фронтальной проекции с ограничениями (не отображается связь от X до нижней границы Pi1)
                PointOfPlane2X0Z.DrawLinkLine(penLinkLineX0ZtoX, penLinkLineX0ZtoZ, true, true, false, false, frameCenter, graphics);
            }
            else
            //4. Все проекции не имеют нулевые значения координат
            {
                PointOfPlane1X0Y.DrawLinkLine(penLinkLineToX, penLinkLinetoY, true, true, false, false, true, frameCenter, graphics);  //Отрисовка линий связи Горизонтальной проекции без ограничений (не отображаются связи от осей до границ плоскотсей проекций)
                PointOfPlane2X0Z.DrawLinkLine(penLinkLineX0ZtoX, penLinkLineX0ZtoZ, true, true, false, false, frameCenter, graphics); //Отрисовка линий связи Фронтальной проекции с ограничениями (не отображаются связи от осей до границ плоскотсей проекций)
                PointOfPlane3Y0Z.DrawLinkLine(penLinkLineY0ZtoZ, penLinkLineY0ZtoY, true, true, false, false, false, frameCenter, graphics); //Отрисовка линий связи Профильной проекции с ограничениями (не отображаются связи от осей до границ плоскотсей проекций и дуга (для дуги устраняется повторная отрисовка))
            }
        }
        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            var dst = Calculate.Distance(mscoords, ptR, frameCenter, this);
            return dst[0] < distance || dst[1] < distance || dst[2] < distance;
        }

        public Name GetName()
        {
            return Name;
        }
        public void SetName(Name name)
        {
            Name = new Name(name);
            PointOfPlane1X0Y.Name = new Name(Name);
            PointOfPlane1X0Y.Name.Value += "'";
            PointOfPlane2X0Z.Name = new Name(Name);
            PointOfPlane2X0Z.Name.Value += "''";
            PointOfPlane3Y0Z.Name = new Name(Name);
            PointOfPlane3Y0Z.Name.Value += "'''";
        }
    }
}

