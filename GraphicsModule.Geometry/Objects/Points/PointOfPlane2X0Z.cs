using System;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;

namespace GraphicsModule.Geometry.Objects.Points
{
    public class PointOfPlane2X0Z : IPointOfPlane, IObjectOfPlane2X0Z
    {
        public PointOfPlane2X0Z()
        {
            X = 0;
            Z = 0;
            Name = new Name();
        }

        public PointOfPlane2X0Z(double x, double z)
        {
            X = x;
            Z = z;
            Name = new Name();
        }

        public PointOfPlane2X0Z(Point pt, Point center)
        {
            X = -(pt.X - center.X);
            Z = -(pt.Y - center.Y);
            Name = new Name();
        }

        public static bool IsCreatable(Point pt, Point frameCenter)
        {
            return (pt.X - frameCenter.X) <= 0 && (pt.Y - frameCenter.Y) <= 0;
        }

        public void Draw(Pen pen, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            var ptForDraw = this.ToGlobalCoordinates(frameCenter);
            graphics.DrawPie(pen, ptForDraw.X - poitRaduis, ptForDraw.Y - poitRaduis, poitRaduis * 2, poitRaduis * 2, 0, 360);
        }

        public void DrawName(DrawSettings st, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            var ptForDraw = this.ToGlobalCoordinates(frameCenter);
            graphics.DrawString(Name.Value + "''", st.TextFont, st.TextBrush, ptForDraw.X + Name.Dx, ptForDraw.Y + Name.Dy);
        }

        public void Draw(Blueprint blueprint)
        {
            var graphics = blueprint.Graphics;
            var settings = blueprint.Settings.Drawing;
            var linkLineSettings = settings.LinkLinesSettings;
            if (linkLineSettings.Enabled)
            {
                DrawLinkLine(linkLineSettings.PenLinkLineX0ZtoX, linkLineSettings.PenLinkLineX0ZtoZ, blueprint.CoordinateSystemCenterPoint, graphics);
            }

            Draw(settings.PenPoints, settings.RadiusPoints, blueprint.CoordinateSystemCenterPoint, graphics);
            DrawName(settings, settings.RadiusPoints, blueprint.CoordinateSystemCenterPoint, graphics);
        }

        [Obsolete("Изменить на иную логику ")]
        public void DrawPointsOnly(Blueprint blueprint)
        {
            Draw(blueprint.Settings.Drawing.PenPoints, blueprint.Settings.Drawing.RadiusPoints, blueprint.CoordinateSystemCenterPoint, blueprint.Graphics);
            DrawName(blueprint.Settings.Drawing, blueprint.Settings.Drawing.RadiusPoints, blueprint.CoordinateSystemCenterPoint, blueprint.Graphics);
        }

        #region LinkLines

        public void DrawLinkLine(Pen penLinkLineToX, Pen penLinkLineToZ, Point coordinateSystemCenter, Graphics graphics)
        {
            DrawLinkLineToX(penLinkLineToX, coordinateSystemCenter, graphics);
            DrawLinkLineToZ(penLinkLineToZ, coordinateSystemCenter, graphics);
        }

        private void DrawLinkLineToX(Pen penLinkLineToX, Point coordinateSystemCenter, Graphics graphics)
        {
            var pt = this.ToGlobalCoordinates(coordinateSystemCenter);
            const int solveErrorSize = 10;
            graphics.DrawLine(penLinkLineToX, pt, new Point(pt.X, coordinateSystemCenter.Y * 2 + solveErrorSize));
        }

        private void DrawLinkLineToZ(Pen penLinkLineToZ, Point coordinateSystemCenter, Graphics graphics)
        {
            var pt = this.ToGlobalCoordinates(coordinateSystemCenter);
            const int solveErrorSize = 10;
            graphics.DrawLine(penLinkLineToZ, pt, new Point(coordinateSystemCenter.X * 2 + solveErrorSize, pt.Y));
        }

        #endregion

        [Obsolete("Нет необходимости в кусочном включении частей линии связи. Использовать общий метод ")]
        public void DrawLinkLine(Pen penLinkLineX0ZtoX, Pen penLinkLineX0ZtoZ, bool linkPointToX, bool linkPointToZ, bool linkXToBorderPi1, bool linkZToBorderPi3, Point frameCenter, Graphics graphics)
        {
            //Отрисовка линий связи Фронтальной проекции
            if (linkPointToX)//Контроль включения линии связи от проекции точки до оси X
            {//Вертикальная (от Pi2 к Pi1) - Часть 1: от точки до оси X
                graphics.DrawLine(penLinkLineX0ZtoX, Convert.ToInt32(frameCenter.X - X), Convert.ToInt32(frameCenter.Y - Z), Convert.ToInt32(frameCenter.X - X), Convert.ToInt32(frameCenter.Y));
            }
            if (linkXToBorderPi1)//Контроль включения линии связи от оси X до нижней границы плоскости проекций Pi1
            {//Вертикальная (от Pi2 к Pi1) - Часть 2: от оси X до границы Pi1
                graphics.DrawLine(penLinkLineX0ZtoX, Convert.ToInt32(frameCenter.X - X), Convert.ToInt32(frameCenter.Y), Convert.ToInt32(frameCenter.X - X), Convert.ToInt32(frameCenter.Y - Z) + Convert.ToInt32(frameCenter.Y * 2 + 20));
            }
            if (linkPointToZ)//Контроль включения линии связи от проекции точки до оси Z
            {//Горизонтальная (от Pi2 к Pi3) - Часть 3: от точки до оси Z
                graphics.DrawLine(penLinkLineX0ZtoZ, Convert.ToInt32(frameCenter.X - X), Convert.ToInt32(frameCenter.Y - Z), Convert.ToInt32(frameCenter.X), Convert.ToInt32(frameCenter.Y - Z));
            }
            if (linkZToBorderPi3)//Контроль включения линии связи от оси Z правой до границы плоскости проекций Pi3
            {//Горизонтальная (от Pi2 к Pi3) - Часть 4: от оси Z до границы Pi3
                graphics.DrawLine(penLinkLineX0ZtoZ, Convert.ToInt32(frameCenter.X), Convert.ToInt32(frameCenter.Y - Z), Convert.ToInt32(frameCenter.X - X) + Convert.ToInt32(frameCenter.X * 2 + 20), Convert.ToInt32(frameCenter.Y - Z));
            }
        }

        public bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            return this.DistanceToPoint(mscoords, coordinateSystemCenter) < distance;
        }

        public double X { get; }

        public double Z { get; }

        public Name Name { get; set; }
    }
}
