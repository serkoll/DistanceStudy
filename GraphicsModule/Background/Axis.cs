using System.Drawing;
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
        /// <summary>
        /// Переключатель отображения ОСЕЙ (любых)
        /// </summary>
        /// <summary>
        /// Переменная для работы с классом настроек ОСЕЙ
        /// </summary>
        public AxisS Setting { get; set; }
        /// <summary>
        /// Конструкто по умолчанию, инициализирует переменные для работы с классом, расчитывающим оси, и с классом настроек осей
        /// </summary>
        public Axis(Settings.Settings settings)
        {
            Setting = settings.AxisS;
        }
        /// <summary>
        /// Рассчитывает концевые точки ортоганальных 2D осей с началом в центре заданной сетки узловых точек
        /// </summary>
        /// <param name="gridKnotPoints"></param>
        /// <returns>Возвращает массив 4-х концевых точек ортоганальных 2D осей</returns>
        /// <remarks>Первые две точки задают горизонтальную ось. Вторые две точки задают вертикальную ось</remarks>
        private Point[] CalculateAxis(Point[,] gridKnotPoints)
        {
            var axisPoints = new Point[4];
            var grigGorizLeft = new Point();
            var grigGorizRight = new Point();
            var grigVertUp = new Point();
            var grigVertDown = new Point();

            var ptCenterI = gridKnotPoints.GetUpperBound(1) / 2;
            var ptCenterJ = gridKnotPoints.GetUpperBound(0) / 2;

            var ptGrid = (Point)gridKnotPoints.GetValue(ptCenterJ, 0);
            grigGorizLeft.X = ptGrid.X;
            grigGorizLeft.Y = ptGrid.Y;
            axisPoints[0] = grigGorizLeft;

            ptGrid = (Point)gridKnotPoints.GetValue(ptCenterJ, gridKnotPoints.GetUpperBound(1));

            grigGorizRight.X = ptGrid.X;
            grigGorizRight.Y = ptGrid.Y;
            axisPoints[1] = grigGorizRight;

            ptGrid = (Point)gridKnotPoints.GetValue(0, ptCenterI);

            grigVertUp.X = ptGrid.X;
            grigVertUp.Y = ptGrid.Y;
            axisPoints[2] = grigVertUp;

            ptGrid = (Point)gridKnotPoints.GetValue(gridKnotPoints.GetUpperBound(0), ptCenterI);

            grigVertDown.X = ptGrid.X;
            grigVertDown.Y = ptGrid.Y;
            axisPoints[3] = grigVertDown;

            return axisPoints;
        }

        /// <summary>
        /// Отрисовка оси (любой) координат в заданном Graphics
        /// </summary>
        /// <param name="axisFinitePoint">Концевая точка оси</param>
        /// <param name="centerFrame2D">Центр системы координат</param>
        /// <param name="g"> Заданная поверхность рисования для отрисовки оси</param>
        /// <param name="axisColor">Цвет оси</param>
        /// <param name="axisWidth">Толщина оси</param>
        private void DrawAxis(Point axisFinitePoint, Point centerFrame2D, Graphics g, Color axisColor, int axisWidth)
        {
            var pens = new Pen(axisColor, axisWidth);
            g.DrawLine(pens, axisFinitePoint.X, axisFinitePoint.Y, centerFrame2D.X, centerFrame2D.Y);
        }
        /// <summary>
        /// Отрисовка оси Х в заданном Graphics
        /// </summary>
        /// <param name="axisPointLeft">Концевая (левая) точка оси</param>
        /// <param name="centerFrame2D">Центр системы координат</param>
        /// <param name="g">Заданная поверхность рисования для отрисовки осей</param>
        /// <remarks>Цвет и толщина оси устанавливаются параметрами настройки</remarks>
        private void DrawAxisX(Point axisPointLeft, Point centerFrame2D, Graphics g)
        {
            DrawAxis(axisPointLeft, centerFrame2D, g, Setting.ColorX, Setting.Width);
        }
        /// <summary>
        /// Отрисовка горизонтальной оси Y в заданном Graphics
        /// </summary>
        /// <param name="axisPointRight">Концевая (правая) точка оси</param>
        /// <param name="centerFrame2D">Центр системы координат</param>
        /// <param name="g">Заданная поверхность рисования для отрисовки оси</param>
        /// <remarks>Цвет и толщина оси устанавливаются параметрами настройки</remarks>
        private void DrawAxisYHor(Point axisPointRight, Point centerFrame2D, Graphics g)
        {
            DrawAxis(axisPointRight, centerFrame2D, g, Setting.ColorY, Setting.Width);
        }
        /// <summary>
        /// Отрисовка вертикальной оси Y в заданном Graphics
        /// </summary>
        /// <param name="axisPointDown">Концевая (нижняя) точка оси</param>
        /// <param name="centerFrame2D">Центр системы координат</param>
        /// <param name="g">Заданная поверхность рисования для отрисовки оси</param>
        /// <remarks>Цвет и толщина оси устанавливаются параметрами настройки</remarks>
        private void DrawAxisYVert(Point axisPointDown, Point centerFrame2D, Graphics g)
        {
            DrawAxis(axisPointDown, centerFrame2D, g, Setting.ColorY, Setting.Width);
        }
        /// <summary>
        /// Отрисовка оси Z в заданном Graphics
        /// </summary>
        /// <param name="axisPointUp">Концевая (верхняя) точка оси</param>
        /// <param name="centerFrame2D">Центр системы координат</param>
        /// <param name="g">Заданная поверхность рисования для отрисовки оси</param>
        /// <remarks>Цвет и толщина оси устанавливаются параметрами настройки</remarks>
        private void DrawAxisZ(Point axisPointUp, Point centerFrame2D, Graphics g)
        {
            DrawAxis(axisPointUp, centerFrame2D, g, Setting.ColorZ, Setting.Width);
        }

        /// <summary>
        /// Расчитывает массив крайних точек четырех двумерных осей, центр которых находится в центре заданной сетки точек
        /// </summary>
        /// <param name="gridKnotPoints">Заданая сетка точек</param>
        /// <remarks>0-я точка - крайняя левая средняя; 1-я - крайняя правая средняя; 2-я - верхняя средняя средняя; 3-я - нижняя средняя средняя.</remarks>
        public void CalculateByGrid(Point[,] gridKnotPoints)
        {
            FinitePoints = CalculateAxis(gridKnotPoints);
        }
        /// <summary>
        /// Добавляет оси на поверхность Graphics
        /// </summary>
        /// <param name="centerFrame2D">Центр поверхности (картинки) рисования</param>
        /// <param name="g">Заданная поверхность рисования</param>
        public void AddAxisToGraphics(Point centerFrame2D, Graphics g)
        {
            if (Setting.FlagDrawX)
            {
                DrawAxisX(FinitePoints[0], centerFrame2D, g);
            }
            if (Setting.FlagDrawY)
            {
                DrawAxisYHor(FinitePoints[1], centerFrame2D, g);
                DrawAxisYVert(FinitePoints[3], centerFrame2D, g);
            }
            if (Setting.FlagDrawZ)
            {
                DrawAxisZ(FinitePoints[2], centerFrame2D, g);
            }
        }
    }
}
