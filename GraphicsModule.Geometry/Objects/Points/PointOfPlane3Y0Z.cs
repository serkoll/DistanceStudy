using System;
using System.Drawing;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Points
{
    /// <summary>Класс для расчета параметров проекции 3D точки на Y0Z плоскость проекций</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2013</remarks>
    public class PointOfPlane3Y0Z : IObject, IPointOfPlane, IObjectOfPlane3Y0Z
    {
        /// <summary>Инициализация нового экземпляра двумерной проекции точки</summary>
        /// <remarks>Исходные координаты точки: Y=0; Z=0</remarks>
        public PointOfPlane3Y0Z() { Y = 0; Z = 0; }
        /// <summary>Инициализирует новый экземпляр двумерной проекции точки с указанными координатами</summary>
        /// <remarks></remarks>
        public PointOfPlane3Y0Z(double y, double z) { Y = y; Z = z; }
        public PointOfPlane3Y0Z(Point pt, Point center)
        {
            Y = pt.X - center.X;
            Z = -(pt.Y - center.Y);
        }
        /// <summary>Инициализирует новый экземпляр двумерной проекции точки</summary>
        /// <remarks></remarks>
        public PointOfPlane3Y0Z(PointOfPlane3Y0Z pt) { Y = pt.Y; Z = pt.Z; }
        public static bool Creatable(Point pt, Point frameCenter)
        {
            var temp = new Point(pt.X - frameCenter.X, pt.Y - frameCenter.Y);
            return temp.X >= 0 && temp.Y <= 0;
        }
        /// <summary>Получает или задает координату Y двумерной проекции точки</summary>
        /// <remarks></remarks>
        public double Y { get; set; }
        /// <summary>Получает или задает координату Z двумерной проекции точки</summary>
        /// <remarks></remarks>
        public double Z { get; set; }
        public string Name { get; set; }
        /// <summary>Передвигает ранее заданную двумерную проекцию точку
        /// (изменяет коодинаты на указанные величины по осям в 2D)
        /// </summary>
        /// <remarks>PointOfPlan3_Y0Z.Y += dy; PointOfPlan3_Y0Z.Z += dz</remarks>
        public void PointMove(double dy, double dz) { Y += dy; Z += dz; }
        /// <summary>Конвертирует заданную проекцию точки на плоскость X0Z в GeomObjects.Point2D</summary>
        /// <remarks>PointOfPlan2_X0Z.X = Point2D.X; PointOfPlan2_X0Z.Z = Point2D.Y</remarks>
        public void Draw(Pen pen, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            var ptForDraw = DeterminePosition.ForPointProjection(this, poitRaduis, frameCenter);
            graphics.DrawPie(pen, ptForDraw.X, ptForDraw.Y, poitRaduis * 2, poitRaduis * 2, 0, 360);
        }
        public void DrawName(DrawS st, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            var ptForDraw = DeterminePosition.ForPointProjection(this, poitRaduis, frameCenter);
            graphics.DrawString(Name, st.TextFont, st.TextBrush, ptForDraw.X, ptForDraw.Y);
        }
        public void Draw(DrawS st, Point frameCenter, Graphics g)
        {
            Draw(st.PenPoints, st.RadiusPoints, frameCenter, g);
            if (st.LinkLineSettings.IsDraw)
            {
                DrawLinkLine(st.LinkLineSettings.PenLinkLineX0ZtoZ, st.LinkLineSettings.PenLinkLineY0ZtoY, true, true, true, true, true, frameCenter, g);
            }
            DrawName(st, st.RadiusPoints, frameCenter, g);
        }
        public void DrawPointsOnly(DrawS st, Point frameCenter, Graphics g)
        {
            Draw(st.PenPoints, st.RadiusPoints, frameCenter, g);
        }
        public void DrawLinkLine(Pen penLinkLineY0ZtoZ, Pen penLinkLineY0ZtoY, bool linkPointToY, bool linkPointToZ, bool linkYToBorderPi1, bool linkZToBorderPi2, bool linkCurveY3ToY1, Point frameCenter, Graphics graphics)
        {
            //Отрисовка линий связи Профильной проекции
            //Контроль нулевого значения координаты Y Горизонтальной проекции точки
            //Проекция точки инцидентна оси X, следовательно отрисовка линий связи не требуется (обрабатывается ошибка существования нулевой ширины и высоты прямоугольника, в который вписывается дуга окружности)
            if (Y == 0) { return; }
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
        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            return Calculate.Distance(mscoords, ptR, frameCenter, this) < distance;
        }
    }
}
