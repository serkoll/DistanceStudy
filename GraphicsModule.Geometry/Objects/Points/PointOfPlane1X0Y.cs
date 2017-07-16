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
        }

        public PointOfPlane1X0Y(double x, double y)
        {
            X = x;
            Y = y;
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

        public void PointMove(double dx, double dy) { X += dx; Y += dy; }

        public void Draw(Pen pen, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            var ptForDraw = this.ToGlobalCoordinatesPoint(poitRaduis, frameCenter);
            graphics.DrawPie(pen, ptForDraw.X, ptForDraw.Y, poitRaduis * 2, poitRaduis * 2, 0, 360);
        }

        public void DrawName(DrawSettings st, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            var ptForDraw = this.ToGlobalCoordinatesPoint(poitRaduis, frameCenter);
            graphics.DrawString(Name.Value + "'", st.TextFont, st.TextBrush, ptForDraw.X + Name.Dx, ptForDraw.Y + Name.Dy);
        }

        public void Draw(DrawSettings st, Point frameCenter, Graphics g)
        {
            this.Draw(st.PenPoints, st.RadiusPoints, frameCenter, g);
            if (st.LinkLinesSettings.IsDraw)
            {
                this.DrawLinkLine(st.LinkLinesSettings.PenLinkLineX0YtoX, st.LinkLinesSettings.PenLinkLineX0YtoY, true, true, true, true, true, frameCenter, g);
            }
            if (Name != null)
                this.DrawName(st, st.RadiusPoints, frameCenter, g);
        }

        public void DrawPointsOnly(DrawSettings st, Point frameCenter, Graphics g)
        {
            Draw(st.PenPoints, st.RadiusPoints, frameCenter, g);
            DrawName(st, st.RadiusPoints, frameCenter, g);
        }
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

        public double X { get; private set; }

        public double Y { get; private set; }

        public Name Name { get; set; }

        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            return Calculate.Distance(mscoords, ptR, frameCenter, this) < distance;
        }
    }
}
