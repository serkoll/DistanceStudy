using System.Drawing;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.CoordinateSystem
{
    /// <summary>
    /// Класс, содержащий инструменты задания и отрисовки ОСЕЙ
    /// </summary>
    public class Axis
    {
        /// <summary>
        /// Получает или задает значение массива массива концевых точек координатных осей
        /// <remarks>0-я точка - крайняя левая средняя; 1-я - крайняя правая средняя; 2-я - верхняя средняя средняя; 3-я - нижняя средняя средняя</remarks>
        /// </summary>
        public Point[] FinitePoints { get; set; }
        public Point Center { get; set; }
        /// <summary>
        /// Конструкто по умолчанию, инициализирует переменные для работы с классом, расчитывающим оси, и с классом настроек осей
        /// </summary>
        public Axis(Graphics graphics)
        {
            var x = graphics.VisibleClipBounds.Size.Width / 2;
            var y = graphics.VisibleClipBounds.Size.Height / 2;
            Center = new Point((int)x, (int)y);
            CalculateFinitePoints(graphics);
        }
        public Axis(Point centerPoint, Graphics graphics)
        {
            Center = new Point(centerPoint.X, centerPoint.Y);
            CalculateFinitePoints(graphics);
        }
        public void CalculateFinitePoints(Graphics graphics)
        {
            FinitePoints = new Point[4];
            FinitePoints[0] = new Point(0, Center.Y);
            FinitePoints[1] = new Point((int)graphics.VisibleClipBounds.Size.Width, Center.Y);
            FinitePoints[2] = new Point(Center.X, 0);
            FinitePoints[3] = new Point(Center.X, (int)graphics.VisibleClipBounds.Size.Height);
        }
        public void DrawAxis(AxisS settings, Graphics g)
        {
            if(!settings.IsDraw) return;
            if (settings.FlagDrawX)
            {
                DrawAxisX(settings, g);
            }
            if (settings.FlagDrawY)
            {
                DrawAxisYHor(settings, g);
                DrawAxisYVert(settings, g);
            }
            if (settings.FlagDrawZ)
            {
                DrawAxisZ(settings, g);
            }
        }
        private void DrawAxis(Point beginPoint, Point endPoint, Color axisColor, int axisWidth, Graphics g)
        {
            var pens = new Pen(axisColor, axisWidth);
            g.DrawLine(pens, beginPoint.X, beginPoint.Y, endPoint.X, endPoint.Y);
        }
        private void DrawAxisX(AxisS sett, Graphics g)
        {
            DrawAxis(FinitePoints[0], Center, sett.ColorX, sett.Width, g);
        }
        private void DrawAxisYHor(AxisS sett, Graphics g)
        {
            DrawAxis(FinitePoints[1], Center, sett.ColorY, sett.Width, g);
        }
        private void DrawAxisYVert(AxisS sett, Graphics g)
        {
            DrawAxis(FinitePoints[3], Center, sett.ColorY, sett.Width, g);
        }
        private void DrawAxisZ(AxisS sett, Graphics g)
        {
            DrawAxis(FinitePoints[2], Center, sett.ColorZ, sett.Width, g);
        }
    }
}
