using System;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;

namespace GraphicsModule.Geometry.Objects.Points
{
    public class PointOfPlane2X0Z : IPointOfPlane, IObjectOfPlane2X0Z
    {
        public PointOfPlane2X0Z() { X = 0; Z = 0; }
 
        public PointOfPlane2X0Z(double x, double z) { X = x; Z = z; }

        public PointOfPlane2X0Z(Point pt, Point center)
        {
            X = -(pt.X - center.X);
            Z = -(pt.Y - center.Y);
        }

        public PointOfPlane2X0Z(PointOfPlane2X0Z pt) { X = pt.X; Z = pt.Z; }

        public static bool IsCreatable(Point pt, Point frameCenter)
        {
            return (pt.X - frameCenter.X) <= 0 && (pt.Y - frameCenter.Y) <= 0;
        }
     
        public void PointMove(double dx, double dz) { X += dx; Z += dz; }

        public void Draw(Pen pen, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            var ptForDraw = this.ToGlobalCoordinatesPoint(poitRaduis, frameCenter);
            graphics.DrawPie(pen, ptForDraw.X, ptForDraw.Y, poitRaduis * 2, poitRaduis * 2, 0, 360);
        }

        public void DrawName(DrawSettings st, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            var ptForDraw = this.ToGlobalCoordinatesPoint(poitRaduis, frameCenter);
            graphics.DrawString(Name.Value + "''", st.TextFont, st.TextBrush, ptForDraw.X + Name.Dx, ptForDraw.Y + Name.Dy);
        }

        public void Draw(DrawSettings st, Point coordinateSystemCenter, Graphics g)
        {
            Draw(st.PenPoints, st.RadiusPoints, coordinateSystemCenter, g);
            if (st.LinkLinesSettings.IsDraw)
            {
                DrawLinkLine(st.LinkLinesSettings.PenLinkLineX0ZtoX, st.LinkLinesSettings.PenLinkLineX0ZtoZ, true, true, true, true, coordinateSystemCenter, g);
            }
            if (Name != null)
                DrawName(st, st.RadiusPoints, coordinateSystemCenter, g);
        }

        public void DrawPointsOnly(DrawSettings st, Point frameCenter, Graphics g)
        {
            Draw(st.PenPoints, st.RadiusPoints, frameCenter, g);
            DrawName(st, st.RadiusPoints, frameCenter, g);
        }

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

        public double X { get; private set; }

        public double Z { get; private set; }

        public Name Name { get; set; }

        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            return Calculate.Distance(mscoords, ptR, frameCenter, this) < distance;
        }
    }
}
