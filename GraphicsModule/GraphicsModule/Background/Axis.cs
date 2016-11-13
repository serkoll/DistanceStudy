using System.Drawing;

namespace GraphicsModule
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
        public Axis(Settings settings)
        {
            Setting = settings.AxisS;
        }
        /// <summary>
        /// Рассчитывает концевые точки ортоганальных 2D осей с началом в центре заданной сетки узловых точек
        /// </summary>
        /// <param name="GridKnotPoints"></param>
        /// <returns>Возвращает массив 4-х концевых точек ортоганальных 2D осей</returns>
        /// <remarks>Первые две точки задают горизонтальную ось. Вторые две точки задают вертикальную ось</remarks>
        private Point[] CalculateAxis(Point[,] GridKnotPoints)
        {
            Point[] axisPoints = new Point[4];
            var grigGorizLeft = new Point();
            var grigGorizRight = new Point();
            var grigVertUp = new Point();
            var grigVertDown = new Point();
            var ptGrid = new Point();

            int PtCenter_i = (int)(GridKnotPoints.GetUpperBound(1) / 2);
            int PtCenter_j = (int)(GridKnotPoints.GetUpperBound(0) / 2);

            ptGrid = (Point)GridKnotPoints.GetValue(PtCenter_j, 0);
            grigGorizLeft.X = ptGrid.X;
            grigGorizLeft.Y = ptGrid.Y;
            axisPoints[0] = grigGorizLeft;

            ptGrid = (Point)GridKnotPoints.GetValue(PtCenter_j, GridKnotPoints.GetUpperBound(1));

            grigGorizRight.X = ptGrid.X;
            grigGorizRight.Y = ptGrid.Y;
            axisPoints[1] = grigGorizRight;

            ptGrid = (Point)GridKnotPoints.GetValue(0, PtCenter_i);

            grigVertUp.X = ptGrid.X;
            grigVertUp.Y = ptGrid.Y;
            axisPoints[2] = grigVertUp;

            ptGrid = (Point)GridKnotPoints.GetValue(GridKnotPoints.GetUpperBound(0), PtCenter_i);

            grigVertDown.X = ptGrid.X;
            grigVertDown.Y = ptGrid.Y;
            axisPoints[3] = grigVertDown;

            return axisPoints;
        }
        /// <summary>
        /// Возвращает концевую точку координатных осей из заданного массива концевых точек по ее номеру
        /// </summary>
        /// <param name="axisFinitePoints">Заданный массив концевых точек осей</param>
        /// <param name="pointNumber">Номер заданной точки</param>
        /// <returns>Возвращает концевую точку координатных осей из заданного массива концевых точек</returns>
        private Point GetAxisFinitePoint(Point[] axisFinitePoints, int pointNumber)
        {
            return (Point)axisFinitePoints.GetValue(pointNumber);
        }
        /// <summary>
        /// Отрисовка оси (любой) координат в заданном Graphics
        /// </summary>
        /// <param name="Axis_FinitePoint">Концевая точка оси</param>
        /// <param name="centerFrame2D">Центр системы координат</param>
        /// <param name="g"> Заданная поверхность рисования для отрисовки оси</param>
        /// <param name="axisColor">Цвет оси</param>
        /// <param name="axisWidth">Толщина оси</param>
        private void DrawAxis(Point axisFinitePoint, Point centerFrame2D, Graphics g, Color axisColor, int axisWidth)
        {
            Pen pens = new Pen(axisColor, axisWidth);
            g.DrawLine(pens, axisFinitePoint.X, axisFinitePoint.Y, centerFrame2D.X, centerFrame2D.Y);

        }
        /// <summary>
        /// Отрисовка оси Х в заданном Graphics
        /// </summary>
        /// <param name="axisPointLeft">Концевая (левая) точка оси</param>
        /// <param name="Frame2D_Center">Центр системы координат</param>
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
        /// Отрисовка горизонтальной оси, проходящей через все изображение в заданном Graphics
        /// </summary>
        /// <param name="axisPointLeft">Концевая (левая) точка оси</param>
        /// <param name="axisPointRight">Концевая (правая) точка оси</param>
        /// <param name="g">Заданная поверхность рисования для отрисовки оси</param>
        /// <remarks>Цвет и толщина оси устанавливаются параметрами настройки для оси X</remarks>
        private void DrawAxisHor(Point axisPointLeft, Point axisPointRight, Graphics g)
        {
            DrawAxis(axisPointLeft, axisPointRight, g, Setting.ColorX, Setting.Width);
        }
        /// <summary>
        /// Отрисовка вертикальной оси, проходящей через все изображение в заданном Graphics
        /// </summary>
        /// <param name="axisPointUp">Концевая (верхняя) точка оси</param>
        /// <param name="axisPointDown">Концевая (нижняя) точка оси</param>
        /// <param name="g">Заданная поверхность рисования для отрисовки оси</param>
        /// <remarks>Цвет и толщина оси устанавливаются параметрами настройки для оси Y</remarks>
        private void DrawAxisVert(Point axisPointUp, Point axisPointDown, Graphics g)
        {
            DrawAxis(axisPointUp, axisPointDown, g, Setting.ColorY, Setting.Width);
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
