using System.Drawing;
using GraphicsModule.Configuration;

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
        public Point[] FinitePoints { get; private set; }

        public Point Center { get; set; }

        /// <summary>
        /// Инициализирует координатные оси по центральной точке системы координат
        /// </summary>
        /// <param name="centerPoint">Центральная точка системы координат</param>
        /// <param name="graphics">Целевой Graphics</param>
        public Axis(Point centerPoint, Graphics graphics)
        {
            Center = new Point(centerPoint.X, centerPoint.Y);
            CalculateFinitePoints(graphics);
        }

        private void CalculateFinitePoints(Graphics graphics)
        {
            FinitePoints = new Point[]
            {
                new Point(0, Center.Y),
                new Point((int) graphics.VisibleClipBounds.Size.Width, Center.Y),
                new Point(Center.X, 0),
                new Point(Center.X, (int) graphics.VisibleClipBounds.Size.Height)
            };
        }

        /// <summary>
        /// Отрисовывает оси согласно настройкам
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="g"></param>
        public void DrawAxis(AxisSettings settings, Graphics g)
        {
            if(!settings.IsDraw)
                return;

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
            g.DrawLine(new Pen(axisColor, axisWidth), beginPoint.X, beginPoint.Y, endPoint.X, endPoint.Y);
        }

        private void DrawAxisX(AxisSettings sett, Graphics g)
        {
            DrawAxis(FinitePoints[0], Center, sett.ColorX, sett.Width, g);
        }

        private void DrawAxisYHor(AxisSettings sett, Graphics g)
        {
            DrawAxis(FinitePoints[1], Center, sett.ColorY, sett.Width, g);
        }

        private void DrawAxisYVert(AxisSettings sett, Graphics g)
        {
            DrawAxis(FinitePoints[3], Center, sett.ColorY, sett.Width, g);
        }

        private void DrawAxisZ(AxisSettings sett, Graphics g)
        {
            DrawAxis(FinitePoints[2], Center, sett.ColorZ, sett.Width, g);
        }
    }
}
