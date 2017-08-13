using System;
using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;

namespace GraphicsModule.Geometry.Objects.Points
{
    public class Point3D : IObject
    {
        private Name _name;

        #region Constructors

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            _name = new Name();
            InitializePointsOfPlane();
        }

        public Point3D(Point2D pt, double z)
        {
            X = pt.X;
            Y = pt.Y;
            Z = z;
            _name = new Name();
            InitializePointsOfPlane();
        }
        public Point3D(PointOfPlane1X0Y pt1, PointOfPlane2X0Z pt2)
        {
            X = pt1.X;
            Y = pt1.Y;
            Z = pt2.Z;
            InitializePointsOfPlane();
            _name = new Name();
        }
        public Point3D(PointOfPlane1X0Y pt1, PointOfPlane3Y0Z pt3)
        {
            X = pt1.X;
            Y = pt1.Y;
            Z = pt3.Z;
            _name = new Name();
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

        private void InitializePointsOfPlane()
        {
            PointOfPlane1X0Y = new PointOfPlane1X0Y(X, Y);
            PointOfPlane2X0Z = new PointOfPlane2X0Z(X, Z);
            PointOfPlane3Y0Z = new PointOfPlane3Y0Z(Y, Z);
        }

        #endregion

        public void Draw(Blueprint blueprint)
        {
            var graphics = blueprint.Graphics;
            var settings = blueprint.Settings.Drawing;
            var linkLineSettings = settings.LinkLinesSettings;
            if (linkLineSettings.Enabled)
            {
                DrawLinkLine(linkLineSettings.PenLinkLineX0YtoX, linkLineSettings.PenLinkLineX0YtoY, linkLineSettings.PenLinkLineX0ZtoZ, blueprint.CoordinateSystemCenterPoint, graphics);
            }

            Draw(settings.PenPoints, settings.RadiusPoints, blueprint.CoordinateSystemCenterPoint, graphics);
            DrawName(settings, settings.RadiusPoints, blueprint.CoordinateSystemCenterPoint, graphics);
        }

        private void Draw(Pen pen, float ptR, Point coordinateSystemCenter, Graphics graphics)
        {
            PointOfPlane1X0Y.Draw(pen, ptR, coordinateSystemCenter, graphics);
            PointOfPlane2X0Z.Draw(pen, ptR, coordinateSystemCenter, graphics);
            PointOfPlane3Y0Z.Draw(pen, ptR, coordinateSystemCenter, graphics);
        }

        public void DrawName(DrawSettings st, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            PointOfPlane1X0Y.DrawName(st, poitRaduis, frameCenter, graphics);
            PointOfPlane2X0Z.DrawName(st, poitRaduis, frameCenter, graphics);
            PointOfPlane3Y0Z.DrawName(st, poitRaduis, frameCenter, graphics);
        }

        #region LinkLines

        public void DrawLinkLine(Pen penLinkLineToX, Pen penLinkLineToY, Pen penLinkLineToZ, Point coordinateSystemCenter, Graphics graphics)
        {
            DrawLinkLineToX(penLinkLineToX, coordinateSystemCenter, graphics);
            DrawLinkLineToY(penLinkLineToY, coordinateSystemCenter, graphics);
            DrawLinkLineToZ(penLinkLineToZ, coordinateSystemCenter, graphics);
        }

        private void DrawLinkLineToX(Pen penLinkLineToX, Point coordinateSystemCenter, Graphics graphics)
        {
            var ptX0Y = PointOfPlane1X0Y.ToGlobalCoordinates(coordinateSystemCenter);
            var ptX0Z = PointOfPlane2X0Z.ToGlobalCoordinates(coordinateSystemCenter);
            graphics.DrawLine(penLinkLineToX, ptX0Y, ptX0Z);
        }

        private void DrawLinkLineToY(Pen penLinkLineToY, Point coordinateSystemCenter, Graphics graphics)
        {
            var ptX0Y = PointOfPlane1X0Y.ToGlobalCoordinates(coordinateSystemCenter);
            var ptY0Z = PointOfPlane3Y0Z.ToGlobalCoordinates(coordinateSystemCenter);

            var ptOnYPi1 = new Point(coordinateSystemCenter.X, ptX0Y.Y);
            graphics.DrawLine(penLinkLineToY, ptX0Y, ptOnYPi1);

            var ptForArc = new Point(coordinateSystemCenter.X - Convert.ToInt32(Y), coordinateSystemCenter.Y - Convert.ToInt32(Y));
            graphics.DrawArc(penLinkLineToY, ptForArc.X, ptForArc.Y, Convert.ToInt32(Y * 2), Convert.ToInt32(Y * 2), 0, 90);

            var ptOnYPi3 = new Point(coordinateSystemCenter.X + Convert.ToInt32(Y), coordinateSystemCenter.Y);
            graphics.DrawLine(penLinkLineToY, ptOnYPi3, ptY0Z);
        }

        private void DrawLinkLineToZ(Pen penLinkLineToZ, Point coordinateSystemCenter, Graphics graphics)
        {
            var ptX0Z = PointOfPlane2X0Z.ToGlobalCoordinates(coordinateSystemCenter);
            var ptY0Z = PointOfPlane3Y0Z.ToGlobalCoordinates(coordinateSystemCenter);
            graphics.DrawLine(penLinkLineToZ, ptX0Z, ptY0Z);
        }

        #endregion

        [Obsolete("Нет необходимости в кусочном включении частей линии связи. Использовать общий метод ")]
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

        public bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            var dst = this.DistanceToPoint(mscoords, coordinateSystemCenter);
            return dst.Any(x => x < distance);
        }

        public double X { get; }

        public double Y { get; }

        public double Z { get; }

        public Name Name
        {
            get
            {
                return _name;
            }
            set
            {
                PointOfPlane1X0Y.Name = value;
                PointOfPlane2X0Z.Name = value;
                PointOfPlane3Y0Z.Name = value;
                _name = value;
            }
        }
        public PointOfPlane1X0Y PointOfPlane1X0Y { get; private set; }

        public PointOfPlane2X0Z PointOfPlane2X0Z { get; private set; }

        public PointOfPlane3Y0Z PointOfPlane3Y0Z { get; private set; }
    }
}

