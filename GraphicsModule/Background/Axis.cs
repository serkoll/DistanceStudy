using System.Drawing;
using System.Windows.Forms;
using GraphicsModule.Settings;

namespace GraphicsModule.Background
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
        public Axis(Graphics g)
        {
            var x = g.VisibleClipBounds.Size.Width/2;
            var y = g.VisibleClipBounds.Size.Height/2;
            Center = new Point((int) x, (int) y);
            FinitePoints = new Point[4];
            FinitePoints[0] = new Point(0, Center.Y);
            FinitePoints[1] = new Point((int) g.VisibleClipBounds.Size.Width, Center.Y);
            FinitePoints[2] = new Point(Center.X, 0);
            FinitePoints[3] = new Point(Center.X, (int) g.VisibleClipBounds.Size.Height);
        }
        public void DrawAxis(AxisS sett, Graphics g)
        {
            if (sett.FlagDrawX)
            {
                DrawAxisX(sett, g);
            }
            if (sett.FlagDrawY)
            {
                DrawAxisYHor(sett, g);
                DrawAxisYVert(sett, g);
            }
            if (sett.FlagDrawZ)
            {
                DrawAxisZ(sett, g);
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
            DrawAxis(FinitePoints[1], Center, sett.ColorX, sett.Width, g);
        }
        private void DrawAxisYVert(AxisS sett, Graphics g)
        {
            DrawAxis(FinitePoints[3], Center, sett.ColorX, sett.Width, g);
        }
        private void DrawAxisZ(AxisS sett, Graphics g)
        {
            DrawAxis(FinitePoints[2], Center, sett.ColorX, sett.Width, g);
        }
        //public void CalculateFinitePointsByGrid(Point[,] gridKnotPoints)
        //{
        //    FinitePoints = new Point[4];
        //    var grigGorizLeft = new Point();
        //    var grigGorizRight = new Point();
        //    var grigVertUp = new Point();
        //    var grigVertDown = new Point();

        //    var ptCenterI = gridKnotPoints.GetUpperBound(1) / 2;
        //    var ptCenterJ = gridKnotPoints.GetUpperBound(0) / 2;

        //    var ptGrid = (Point)gridKnotPoints.GetValue(ptCenterJ, 0);
        //    grigGorizLeft.X = ptGrid.X;
        //    grigGorizLeft.Y = ptGrid.Y;
        //    FinitePoints[0] = grigGorizLeft;

        //    ptGrid = (Point)gridKnotPoints.GetValue(ptCenterJ, gridKnotPoints.GetUpperBound(1));

        //    grigGorizRight.X = ptGrid.X;
        //    grigGorizRight.Y = ptGrid.Y;
        //    FinitePoints[1] = grigGorizRight;

        //    ptGrid = (Point)gridKnotPoints.GetValue(0, ptCenterI);

        //    grigVertUp.X = ptGrid.X;
        //    grigVertUp.Y = ptGrid.Y;
        //    FinitePoints[2] = grigVertUp;

        //    ptGrid = (Point)gridKnotPoints.GetValue(gridKnotPoints.GetUpperBound(0), ptCenterI);

        //    grigVertDown.X = ptGrid.X;
        //    grigVertDown.Y = ptGrid.Y;
        //    FinitePoints[3] = grigVertDown;

        //}
    }
}
