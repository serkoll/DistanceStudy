using System;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;

namespace GraphicsModule.Geometry.Objects.Points
{
    public class PointOfPlane3Y0Z : IPointOfPlane, IObjectOfPlane3Y0Z
    {
        public PointOfPlane3Y0Z()
        {
            Y = 0;
            Z = 0;
            Name = new Name();
        }

        public PointOfPlane3Y0Z(double y, double z)
        {
            Y = y;
            Z = z;
            Name = new Name();
        }

        public PointOfPlane3Y0Z(Point pt, Point center)
        {
            Y = pt.X - center.X;
            Z = -(pt.Y - center.Y);
            Name = new Name();
        }

        public static bool IsCreatable(Point pt, Point frameCenter)
        {
            return (pt.X - frameCenter.X) >= 0 && (pt.Y - frameCenter.Y) <= 0;
        }

        public void Draw(Pen pen, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            var ptForDraw = this.ToGlobalCoordinates(frameCenter);
            graphics.DrawPie(pen, ptForDraw.X - poitRaduis, ptForDraw.Y - poitRaduis, poitRaduis * 2, poitRaduis * 2, 0, 360);
        }

        public void Draw(Blueprint blueprint)
        {
            var graphics = blueprint.Graphics;
            var settings = blueprint.Settings.Drawing;
            var linkLineSettings = settings.LinkLinesSettings;
            if (linkLineSettings.Enabled)
            {
                DrawLinkLine(linkLineSettings.PenLinkLineX0ZtoZ, linkLineSettings.PenLinkLineY0ZtoY, blueprint.CoordinateSystemCenterPoint, graphics);
            }

            Draw(settings.PenPoints, settings.RadiusPoints, blueprint.CoordinateSystemCenterPoint, graphics);

            DrawName(settings, settings.RadiusPoints, blueprint.CoordinateSystemCenterPoint, graphics);
        }

        [Obsolete("Поменять название")]
        public void DrawPointsOnly(Blueprint blueprint)
        {
            var settings = blueprint.Settings.Drawing;
            Draw(settings.PenPoints, settings.RadiusPoints, blueprint.CoordinateSystemCenterPoint, blueprint.Graphics);
            DrawName(settings, settings.RadiusPoints, blueprint.CoordinateSystemCenterPoint, blueprint.Graphics);
        }

        public void DrawName(DrawSettings st, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            var ptForDraw = this.ToGlobalCoordinates(frameCenter);
            graphics.DrawString(Name.Value + "'''", st.TextFont, st.TextBrush, ptForDraw.X + Name.Dx, ptForDraw.Y + Name.Dy);
        }

        #region LinkLines

        public void DrawLinkLine(Pen penLinkLineToZ, Pen penLinkLineToY, Point coordinateSystemCenter, Graphics graphics)
        {
            DrawLinkLineToZ(penLinkLineToZ, coordinateSystemCenter, graphics);
            DrawLinkLineToY(penLinkLineToY, coordinateSystemCenter, graphics);
        }

        private void DrawLinkLineToZ(Pen penLinkLineToZ, Point coordinateSystemCenter, Graphics graphics)
        {
            var pt = this.ToGlobalCoordinates(coordinateSystemCenter);
            graphics.DrawLine(penLinkLineToZ, pt, new Point(0, pt.Y));
        }

        private void DrawLinkLineToY(Pen penLinkLineToY, Point coordinateSystemCenter, Graphics graphics)
        {
            var pt = this.ToGlobalCoordinates(coordinateSystemCenter);
            var ptOnYPi3 = new Point(pt.X, coordinateSystemCenter.Y);
            graphics.DrawLine(penLinkLineToY, pt, ptOnYPi3);

            var ptForArc = new Point(coordinateSystemCenter.X - Convert.ToInt32(Y), coordinateSystemCenter.Y - Convert.ToInt32(Y));
            graphics.DrawArc(penLinkLineToY, ptForArc.X, ptForArc.Y, Convert.ToInt32(Y * 2), Convert.ToInt32(Y * 2), 0, 90);

            var ptOnYPi1 = new Point(coordinateSystemCenter.X, coordinateSystemCenter.Y + Convert.ToInt32(Y));
            graphics.DrawLine(penLinkLineToY, ptOnYPi1, new Point(0, ptOnYPi1.Y));
        }

        #endregion

        [Obsolete("Нет необходимости в кусочном включении частей линии связи. Использовать общий метод ")]
        public void DrawLinkLine(Pen penLinkLineY0ZtoZ, Pen penLinkLineY0ZtoY, bool linkPointToY, bool linkPointToZ, bool linkYToBorderPi1, bool linkZToBorderPi2, bool linkCurveY3ToY1, Point frameCenter, Graphics graphics)
        {
            //Отрисовка линий связи Профильной проекции
            //Контроль нулевого значения координаты Y Горизонтальной проекции точки
            //Проекция точки инцидентна оси X, следовательно отрисовка линий связи не требуется (обрабатывается ошибка существования нулевой ширины и высоты прямоугольника, в который вписывается дуга окружности)v
            const double tolerance = 0.0001;
            if (Math.Abs(Y) < tolerance) { return; }
            //В отличие от отключенных условий заменены координаты центра X на Y и наоборот
            if (linkPointToZ) //Контроль включения линии связи от проекции точки до оси Z
            {//Горизонтальная (от Pi3 к Pi2) - часть 1: отрезок от заданной точки до оси Z на Pi2
                graphics.DrawLine(penLinkLineY0ZtoZ, Convert.ToInt32(frameCenter.X + Y), Convert.ToInt32(frameCenter.Y - Z), Convert.ToInt32(frameCenter.X), Convert.ToInt32(frameCenter.Y - Z));
            }
            if (linkPointToY)//Контроль включения линии связи от проекции точки до оси Y
            {
                graphics.DrawLine(penLinkLineY0ZtoY, Convert.ToInt32(frameCenter.X + Y), Convert.ToInt32(frameCenter.Y - Z), Convert.ToInt32(frameCenter.X + Y), Convert.ToInt32(frameCenter.Y));
                //Вертикальная (от Pi3 к Pi2) - часть 2: отрезок от заданной точки до оси Y на Pi3
            }
            if (linkCurveY3ToY1)//Контроль включения линии связи (дуги) от проекции горизонтальной оси Y плоскости Pi3 до вертикальной оси Y плоскости Pi1 
            {    //Часть 3: дуга (от Pi3 к Pi1)  от точки пересечения с горизонтальной осью Y до вертикальной оси Y
                graphics.DrawArc(penLinkLineY0ZtoY, Convert.ToInt32(frameCenter.X) - Convert.ToInt32(Y), Convert.ToInt32(frameCenter.Y) - Convert.ToInt32(Y), Convert.ToInt32(2 * Y), Convert.ToInt32(2 * Y), 0, 90);
            }
            //Дополнительно от осей до границ области отрисовки
            if (linkYToBorderPi1) //Контроль включения линии связи от оси Y до границы плоскости проекций Pi1
            { //Горизонтальная (от Pi3 к Pi2) - часть 4: отрезок от вертикальной оси Y на Pi1 до границы области рисования
                graphics.DrawLine(penLinkLineY0ZtoY, Convert.ToInt32(frameCenter.X), Convert.ToInt32(frameCenter.Y + Y), 0, Convert.ToInt32(frameCenter.Y + Y));
            }
            if (linkZToBorderPi2)//Контроль включения линии связи от оси Z до границы плоскости проекций Pi2
            {//Горизонтальная (от Pi3 к Pi2) - часть 4: отрезок от заданной точки до оси Z на Pi2
                graphics.DrawLine(penLinkLineY0ZtoZ, Convert.ToInt32(frameCenter.X), Convert.ToInt32(frameCenter.Y - Z), 0, Convert.ToInt32(frameCenter.Y - Z));
            }
        }

        public bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            return this.DistanceToPoint(mscoords, coordinateSystemCenter) < distance;
        }

        public double Y { get; }

        public double Z { get; }

        public Name Name { get; set; }
        
    }
}
