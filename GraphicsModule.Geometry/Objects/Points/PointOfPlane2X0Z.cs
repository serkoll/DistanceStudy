using System;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Interfaces;

namespace GraphicsModule.Geometry.Objects.Points
{
    /// <summary>Класс для расчета параметров проекции 3D точки на X0Z плоскость проекций</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2013</remarks>
    public class PointOfPlane2X0Z : IPointOfPlane, IObjectOfPlane2X0Z
    {
        /// <summary>Инициализация нового экземпляра двумерной проекции точки</summary>
        /// <remarks>Исходные координаты точки: X=0; Z=0</remarks>
        public PointOfPlane2X0Z() { X = 0; Z = 0; }
        /// <summary>Инициализирует новый экземпляр двумерной проекции точки с указанными координатами</summary>
        /// <remarks></remarks>
        public PointOfPlane2X0Z(double x, double z) { X = x; Z = z; }//Конструктор, устанавливающий пользовательские значения координат 2D точки
        public PointOfPlane2X0Z(Point pt, Point center)
        {
            X = -(pt.X - center.X);
            Z = -(pt.Y - center.Y);
        }
        /// <summary>Инициализирует новый экземпляр двумерной проекции точки</summary>
        /// <remarks></remarks>
        public PointOfPlane2X0Z(PointOfPlane2X0Z pt) { X = pt.X; Z = pt.Z; }
        public static bool IsCreatable(Point pt, Point frameCenter)
        {
            return (pt.X - frameCenter.X) <= 0 && (pt.Y - frameCenter.Y) <= 0;
        }
        /// <summary>Получает или задает координату X двумерной проекции точки</summary>
        /// <remarks></remarks>
        public double X { get; set; }
        /// <summary>Получает или задает координату Z двумерной проекции точки</summary>
        /// <remarks></remarks>
        public double Z { get; set; }
        public Name Name { get; set; }
        /// <summary>Передвигает ранее заданную двумерную проекцию точку
        /// (изменяет коодинаты на указанные величины по осям в 2D)</summary>
        /// <remarks>PointOfPlan2_X0Z.X += dx; PointOfPlan2_X0Z.Z += dz</remarks>
        public void PointMove(double dx, double dz) { X += dx; Z += dz; }
        public void Draw(Pen pen, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            var ptForDraw = DeterminePosition.ForPointProjection(this, poitRaduis, frameCenter);
            graphics.DrawPie(pen, ptForDraw.X, ptForDraw.Y, poitRaduis * 2, poitRaduis * 2, 0, 360);
        }
        public void DrawName(DrawSettings st, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            var ptForDraw = DeterminePosition.ForPointProjection(this, poitRaduis, frameCenter);
            graphics.DrawString(Name.Value, st.TextFont, st.TextBrush, ptForDraw.X + Name.Dx, ptForDraw.Y + Name.Dy);
        }
        public void Draw(DrawSettings st, Point frameCenter, Graphics g)
        {
            Draw(st.PenPoints, st.RadiusPoints, frameCenter, g);
            if (st.LinkLinesSettings.IsDraw)
            {
                DrawLinkLine(st.LinkLinesSettings.PenLinkLineX0ZtoX, st.LinkLinesSettings.PenLinkLineX0ZtoZ, true, true, true, true, frameCenter, g);
            }
            if (Name != null)
                DrawName(st, st.RadiusPoints, frameCenter, g);
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
        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            return Calculate.Distance(mscoords, ptR, frameCenter, this) < distance;
        }
        public Name GetName()
        {
            var name = new Name(Name.Value.Remove(Name.Value.IndexOf("'", StringComparison.Ordinal)), Name.Dx, Name.Dy);
            return name;
        }
        public void SetName(Name name)
        {
            Name = new Name(name);
            Name.Value += "''";
        }
    }
}
