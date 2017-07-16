using System;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;

namespace GraphicsModule.Geometry.Objects.Points
{
    public class PointOfPlane1X0Y : IPointOfPlane, IObjectOfPlane1X0Y
    {
        public PointOfPlane1X0Y()
        {
            X = 0;
            Y = 0;
            Name = new Name();
        }

        public PointOfPlane1X0Y(double x, double y)
        {
            X = x;
            Y = y;
            Name = new Name();
        }

        public PointOfPlane1X0Y(double x, double y, Name name)
        {
            X = x;
            Y = y;
            Name = name;
        }

        public PointOfPlane1X0Y(Point pt, Point center)
        {
            X = -(pt.X - center.X);
            Y = pt.Y - center.Y;
        }

        public PointOfPlane1X0Y(Point pt, Point center, Name name)
        {
            X = -(pt.X - center.X);
            Y = pt.Y - center.Y;
            Name = name;
        }

        public static bool IsCreatable(Point pt, Point frameCenter)
        {
            return (pt.X - frameCenter.X) <= 0 && (pt.Y - frameCenter.Y) >= 0;
        }

        public void Draw(Pen pen, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            var ptForDraw = this.ToGlobalCoordinatesPoint(poitRaduis, frameCenter);
            graphics.DrawPie(pen, ptForDraw.X - poitRaduis, ptForDraw.Y - poitRaduis, poitRaduis * 2, poitRaduis * 2, 0, 360);
        }

        public void Draw(DrawSettings settings, Point coordinateSystemCenter, Graphics graphics)
        {
            var linkLineSettings = settings.LinkLinesSettings;
            if (linkLineSettings.IsDraw)
            {
                DrawLinkLine(linkLineSettings.PenLinkLineX0YtoX, linkLineSettings.PenLinkLineX0YtoY, coordinateSystemCenter, graphics);
            }

            Draw(settings.PenPoints, settings.RadiusPoints, coordinateSystemCenter, graphics);

            DrawName(settings, settings.RadiusPoints, coordinateSystemCenter, graphics);
        }
    
        public void DrawName(DrawSettings st, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            var ptForDraw = this.ToGlobalCoordinatesPoint(poitRaduis, frameCenter);
            graphics.DrawString(Name.Value + "'", st.TextFont, st.TextBrush, ptForDraw.X + Name.Dx, ptForDraw.Y + Name.Dy);
        }

        public void DrawPointsOnly(DrawSettings st, Point coordinateSystemCenter, Graphics graphics)
        {
            Draw(st.PenPoints, st.RadiusPoints, coordinateSystemCenter, graphics);
            DrawName(st, st.RadiusPoints, coordinateSystemCenter, graphics);
        }

        #region LinkLines

        public void DrawLinkLine(Pen penLinkLineToX, Pen penLinkLineToY, Point coordinateSystemCenter, Graphics graphics)
        {
            DrawLinkLineToX(penLinkLineToX, coordinateSystemCenter, graphics);
            DrawLinLineToY(penLinkLineToY, coordinateSystemCenter, graphics);
        }

        private void DrawLinkLineToX(Pen penLinkLineToX, Point coordinateSystemCenter, Graphics graphics)
        {
            var pt = this.ToGlobalCoordinatesPoint(coordinateSystemCenter);
            graphics.DrawLine(penLinkLineToX, pt, new Point(pt.X, 0));
        }

        private void DrawLinLineToY(Pen penLinkLineToY, Point coordinateSystemCenter, Graphics graphics)
        {
            var pt = this.ToGlobalCoordinatesPoint(coordinateSystemCenter);
            var ptOnYPi1 = new Point(coordinateSystemCenter.X, pt.Y);
            graphics.DrawLine(penLinkLineToY, pt, ptOnYPi1);

            var ptForArc = new Point(coordinateSystemCenter.X - Convert.ToInt32(Y), coordinateSystemCenter.Y - Convert.ToInt32(Y));
            graphics.DrawArc(penLinkLineToY, ptForArc.X, ptForArc.Y, Convert.ToInt32(Y * 2), Convert.ToInt32(Y * 2), 0, 90);

            var ptOnYPi3 = new Point(coordinateSystemCenter.X + Convert.ToInt32(Y), coordinateSystemCenter.Y);
            graphics.DrawLine(penLinkLineToY, ptOnYPi3, new Point(ptOnYPi3.X, 0));
        }

        #endregion

        [Obsolete("Нет необходимости в кусочном включении частей линии связи. Использовать общий метод ")]
        public void DrawLinkLine(Pen penLinkLineToX, Pen penLinkLinetoY, bool linkPointToX, bool linkPointToY, bool linkXToBorderPi2, bool linkYToBorderPi3, bool linkCurveY1ToY3, Point frameCenter, Graphics graphics)
        {
            const double tolerance = 0.0001;
            if (Math.Abs(Y) < tolerance) return;
            if (linkPointToX) //Контроль включения линии связи от проекции точки до оси X
            {
                //Горизонтальная (от Pi1 к Pi3) - Часть 1: отрезок от заданной точки до оси X
                graphics.DrawLine(penLinkLineToX, Convert.ToInt32(frameCenter.X - X), Convert.ToInt32(frameCenter.Y + Y), Convert.ToInt32(frameCenter.X - X), Convert.ToInt32(frameCenter.Y));
            }
            if (linkXToBorderPi2)//Контроль включения линии связи от оси X до верхней границы плоскости проекций Pi2
            {
                //Горизонтальная (от Pi1 к Pi3) - Часть 2: отрезок от оси X до верхней границы области рисования (верхней границы плоскости проекций Pi2)
                graphics.DrawLine(penLinkLineToX, Convert.ToInt32(frameCenter.X - X), Convert.ToInt32(frameCenter.Y), Convert.ToInt32(frameCenter.X - X), -Convert.ToInt32(2 * frameCenter.Y + 20));
            }
            if (linkPointToY)//Контроль включения линии связи от проекции точки до оси Y
            {
                //Горизонтальная (от Pi1 к Pi3) - Часть 3: отрезок от заданной точки до вертикальной оси Y (оси Y плоскости проекций Pi1)
                graphics.DrawLine(penLinkLinetoY, Convert.ToInt32(frameCenter.X - X), Convert.ToInt32(frameCenter.Y + Y), Convert.ToInt32(frameCenter.X), Convert.ToInt32(frameCenter.Y + Y));
            }
            if (linkCurveY1ToY3)//Контроль включения линии связи (дуги) от вертикальной оси Y плоскости Pi1 до горизонтальной оси Y плоскости Pi3
            {
                //Горизонтальная (от Pi1 к Pi3) - Часть 4: дуга от вертикальной оси Y до горизонтальной оси Y
                graphics.DrawArc(penLinkLinetoY, Convert.ToInt32(frameCenter.X) - Convert.ToInt32(Y), Convert.ToInt32(frameCenter.Y) - Convert.ToInt32(Y), Convert.ToInt32(2 * Y), Convert.ToInt32(2 * Y), 0, 90);
            }
            if (linkYToBorderPi3) //Контроль включения линии связи от горизонтальной оси Y до верхней границы плоскости проекций Pi3
            {
                //Вертикальная (от Pi1 к Pi2) - Часть 5: отрезок от горизонтальной оси Y до границы области рисования (верхней границы плоскости проекций Pi3)
                graphics.DrawLine(penLinkLinetoY, Convert.ToInt32(frameCenter.X + Y), frameCenter.Y, Convert.ToInt32(frameCenter.X + Y), 0);
            }
        }
        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            return Calculate.Distance(mscoords, ptR, frameCenter, this) < distance;
        }

        public double X { get; private set; }

        public double Y { get; private set; }

        public Name Name { get; set; }
    }
}
