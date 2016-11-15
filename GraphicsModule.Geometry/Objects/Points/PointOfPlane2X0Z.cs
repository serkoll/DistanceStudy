using System;
using System.Drawing;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Points
{
    /// <summary>Класс для расчета параметров проекции 3D точки на X0Z плоскость проекций</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2013</remarks>
    public class PointOfPlane2X0Z : IObject, IPointOfPlane
    {

        //====================================================================================================
        //================== Методы ввода-вывода (расчета) параметров двумерной проекции точки по заданным условиям ==================

        /// <summary>Инициализация нового экземпляра двумерной проекции точки</summary>
        /// <remarks>Исходные координаты точки: X=0; Z=0</remarks>
        public PointOfPlane2X0Z() { X = 0; Z = 0; }//Конструктор, устанавливающий исходные значения координат 2D точки

        /// <summary>Инициализирует новый экземпляр двумерной проекции точки с указанными координатами</summary>
        /// <remarks></remarks>
        public PointOfPlane2X0Z(double x, double z) { X = x; Z = z; }//Конструктор, устанавливающий пользовательские значения координат 2D точки
        public PointOfPlane2X0Z(System.Drawing.Point pt, System.Drawing.Point center)
        {
            X = -(pt.X - center.X);
            Z = -(pt.Y - center.Y);
        }
        /// <summary>Инициализирует новый экземпляр двумерной проекции точки</summary>
        /// <remarks></remarks>
        public PointOfPlane2X0Z(PointOfPlane2X0Z pt) { X = pt.X; Z = pt.Z; }//Конструктор, устанавливающий пользовательские значения координат 2D точки
        public static bool Creatable(System.Drawing.Point pt, System.Drawing.Point frameCenter)
        {
            var temp = new System.Drawing.Point(pt.X - frameCenter.X, pt.Y - frameCenter.Y);
            return temp.X <= 0 && temp.Y <= 0;
        }
        /// <summary>Получает или задает координату X двумерной проекции точки</summary>
        /// <remarks></remarks>
        public double X { get; set; }

        /// <summary>Получает или задает координату Z двумерной проекции точки</summary>
        /// <remarks></remarks>
        public double Z { get; set; }
        /// <summary>Передвигает ранее заданную двумерную проекцию точку
        /// (изменяет коодинаты на указанные величины по осям в 2D)</summary>
        /// <remarks>PointOfPlan2_X0Z.X += dx; PointOfPlan2_X0Z.Z += dz</remarks>
        public void PointMove(double dx, double dz) { X += dx; Z += dz; }//Конструктор перемещения на указанные величины по осям
        public void Draw(Pen pen, float poitRaduis, System.Drawing.Point frameCenter, Graphics graphics)
        {
            var ptForDraw = DeterminePosition.ForPointProjection(this, poitRaduis, frameCenter);
            graphics.DrawPie(pen, ptForDraw.X, ptForDraw.Y, poitRaduis * 2, poitRaduis * 2, 0, 360);
        }
        public void Draw(DrawS st, System.Drawing.Point frameCenter, Graphics g)
        {
            Draw(st.PenPoints, st.RadiusPoints, frameCenter, g);
            if (st.LinkLineSettings.IsDraw)
            {
                DrawLinkLine(st.LinkLineSettings.LinkLineX0ZToX, st.LinkLineSettings.LinkLineX0ZToZ, true, true, true, true, frameCenter, g);
            }
        }
        public void DrawPointsOnly(DrawS st, System.Drawing.Point frameCenter, Graphics g)
        {
            Draw(st.PenPoints, st.RadiusPoints, frameCenter, g);
        }
        public void DrawLinkLine(Pen penLinkLineX0ZtoX, Pen penLinkLineX0ZtoZ, bool linkPointToX, bool linkPointToZ, bool linkXToBorderPi1, bool linkZToBorderPi3, System.Drawing.Point frameCenter, Graphics graphics)
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
        public bool IsSelected(System.Drawing.Point mscoords, float ptR, System.Drawing.Point frameCenter, double distance)
        {
            return Calculate.Distance(mscoords, ptR, frameCenter, this) < distance;
        }
    }
}
