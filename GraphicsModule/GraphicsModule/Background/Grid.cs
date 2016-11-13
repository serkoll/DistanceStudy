using System;
using System.Drawing;

namespace GraphicsModule
{
    /// <summary>
    /// Класс, содержащий инструменты задания и отрисовки СЕТКИ
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// Массив узловых точек сетки
        /// </summary>
        public Point[,] Knots { get; set; }
        /// <summary>
        /// Размер сетки по высоте (координата Y в пространстве рисунка, направлена вниз)
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Размер сетки по ширине (координата X в пространстве рисунка, направлена вправо)
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Центральная точка сетки
        /// </summary>
        public Point Center { get; set; }
        public GridS Setting { get; set; }
        /// <summary>
        /// Получает значение переключателя сетки
        /// </summary>
        public Grid(Settings settings)
        {
            Setting = settings.GridS;
        }
        /// <summary>
        /// Возвращает массив координат узловых точек координатной сетки
        /// </summary>
        /// <param name="gridHeight">Выстока сетки</param>
        /// <param name="gridWidth">Ширина сетки</param>
        /// <param name="gridHeighStep">Шаг сетки по высоте</param>
        /// <param name="gridWidthStep">Шаг сетки по ширине</param>
        /// <returns></returns>
        public Point[,] CalculateGrid(int gridHeight, int gridWidth, int gridHeighStep, int gridWidthStep)
        {
            Point[,] GridPoints = new Point[(int)(Math.Floor((double)(gridHeight / gridHeighStep))) + 1, (int)(Math.Floor((double)(gridWidth / gridWidthStep))) + 1];
            Point DrawGridPoint = new Point();
            int iArr = 0, jArr = 0;
            for (int i = 0; i <= GridPoints.GetUpperBound(0) * gridHeighStep; i += gridHeighStep)
            {
                iArr++;
                jArr = 0;
                for (int j = 0; j <= GridPoints.GetUpperBound(1) * gridWidthStep; j += gridWidthStep)
                {
                    DrawGridPoint.X = j;
                    DrawGridPoint.Y = i;
                    jArr++;
                    GridPoints[iArr - 1, jArr - 1] = DrawGridPoint;
                }
            }
            
            return GridPoints;
        }
        /// <summary>
        /// Возвращает центральную узловую точку координатной сетки
        /// </summary>
        /// <param name="gridHeight">Высота сетки</param>
        /// <param name="gridWidth">Ширина сетки</param>
        /// <param name="gridHeighStep">Шаг сетки по высоте</param>
        /// <param name="gridWidthStep">Шаг сетки по ширине</param>
        /// <returns></returns>
        public Point CalculateGridCenter(int gridHeight, int gridWidth, int gridHeighStep, int gridWidthStep)
        {
            Point PtCenterGrid = new Point();
            Point[,] GridPoints = CalculateGrid(gridHeight, gridWidth, gridHeighStep, gridWidthStep);
            Point PtCenterGridArr;
            PtCenterGridArr = (Point)GridPoints.GetValue((int)(GridPoints.GetUpperBound(0) / 2), (int)(GridPoints.GetUpperBound(1) / 2));
            PtCenterGrid.X = PtCenterGridArr.X;
            PtCenterGrid.Y = PtCenterGridArr.Y;
            return PtCenterGrid;
        }
        /// <summary>
        /// Возвращает центральную узловую точку координатной сетки
        /// </summary>
        /// <param name="GridKnotPoints">Массив узловых точек координатной сетки</param>
        /// <returns></returns>
        public Point CalculateGridCenter(Point[,] GridKnotPoints)
        {
            Point PtCenterGrid = new Point();
            Point PtCenterGridArr = (Point)GridKnotPoints.GetValue((int)(GridKnotPoints.GetUpperBound(0) / 2), (int)(GridKnotPoints.GetUpperBound(1) / 2));
            PtCenterGrid.X = PtCenterGridArr.X;
            PtCenterGrid.Y = PtCenterGridArr.Y;
            return PtCenterGrid;
        }
        /// <summary>
        /// Возвращает узловую точку координатной сетки
        /// </summary>
        /// <param name="GridKnotPoints">Массив узловых точек координатной сетки</param>
        /// <param name="iGrid">Номер точки по столбцу</param>
        /// <param name="jGrid">Номер точки по строке</param>
        /// <returns></returns>
        public Point GetGridKnotPoint(Point[,] GridKnotPoints, int iGrid, int jGrid)
        {
            Point GridKnotPoint = new Point();
            Point GridKnotPointArr = (Point)GridKnotPoints.GetValue(iGrid, jGrid);
            GridKnotPoint.X = GridKnotPointArr.X;
            GridKnotPoint.Y = GridKnotPointArr.Y;
            return GridKnotPoint;
        }
        /// <summary>
        /// Задает сетку на поверхности Graphics с учетом установленных по умолчанию параметров шага по вертикали и горизонтали, радиуса и цвета узловых точек сетки
        /// </summary>
        /// <param name="g">Заданная поверхность рисования</param>
        /// <remarks>Расчитывает и задает сетку с учетом размеров заданной поверхности рисования Graphics</remarks>
        public void CreateGridToGraphics(Graphics g)
        {
            if (Height == 0 || Width == 0)
            {
                Height = (int)g.VisibleClipBounds.Size.Height;
                Width = (int)g.VisibleClipBounds.Size.Width;
                Knots = CalculateGrid(Height, Width, Setting.StepOfHeight, Setting.StepOfWidth);
                Center = CalculateGridCenter(Knots);
                if (Setting.IsDraw)
                {
                    DrawGrid(Knots, Setting.PointsColor, Setting.PointsSize, g);
                }
            }
            else
            {
                Knots = CalculateGrid(Height, Width, Setting.StepOfHeight, Setting.StepOfWidth);
                Center = CalculateGridCenter(Knots);
                if (Setting.IsDraw)
                {
                    DrawGrid(Knots, Setting.PointsColor, Setting.PointsSize, g);
                }
            }
        }
        /// <summary>
        /// Задает сетку на поверхности Graphics
        /// </summary>
        /// <param name="gridKnotPoints">Заданный массив узловых точек сетки</param>
        /// <param name="knotPointColor">Заданный цвет узловых точек сетки</param>
        /// <param name="knotPointRadius">Размер узловых точек сетки</param>
        /// <param name="graphics">Заданная поверхность рисования</param>
        public void DrawGrid(Point[,] gridKnotPoints, Color knotPointColor, int knotPointRadius, Graphics graphics)
        {
            var pens = new Pen(knotPointColor, knotPointRadius);
            for (int i = 0; i < gridKnotPoints.GetUpperBound(0); i++)
            {
                for (int j = 0; j < gridKnotPoints.GetUpperBound(1); j++)
                {
                    var gridPoint = GetGridKnotPoint(gridKnotPoints, i, j);
                    graphics.DrawPie(pens, gridPoint.X, gridPoint.Y, knotPointRadius, knotPointRadius, 0, 360);
                }
            }
        }
        /// <summary>
        /// Отрисовывает массив узловых точек сетки в заданном PictureBox
        /// </summary>
        /// <param name="gridKnotPoints">Заданный массив узловых точек сетки</param>
        /// <param name="pictureBox">Заданный PictureBox</param>
        /// <param name="pointColor">Заданный цвет узловых точек сетки</param>
        /// <param name="pointRadius">Размер узловых точек сетки</param>
        public void DrawGrid(int[,] gridKnotPoints, System.Windows.Forms.PictureBox pictureBox, Color pointColor, int pointRadius)
        {
            var grPoint = new Point();
            var Pens = new Pen(pointColor, pointRadius);
            var centerX = pictureBox.ClientRectangle.Width / 2;
            var centerY = pictureBox.ClientRectangle.Height / 2;
            for (int i = 0; i < gridKnotPoints.GetUpperBound(0); i++)
            {
                grPoint.X = (int)(centerX + gridKnotPoints[i, 0]);
                grPoint.Y = (int)(centerY + gridKnotPoints[i, 1]);
                pictureBox.CreateGraphics().DrawEllipse(Pens, (int)(grPoint.X - pointRadius / 2), (int)(grPoint.Y - pointRadius / 2), pointRadius, pointRadius);
            }
        }
        /// <summary>
        /// Задает массив узловых точек сетки в заданном Image
        /// </summary>
        /// <param name="gridKnotPoints">Заданный массив узловых точек сетки</param>
        /// <param name="imageSource">Заданный Image</param>
        /// <param name="knotPointColor">Заданный цвет узловых точек сетки</param>
        /// <param name="knotPointRadius">Размер узловых точек сетки</param>
        public void DrawGrid(Point[,] gridKnotPoints, Image imageSource, Color knotPointColor, int knotPointRadius)
        {
            var graphics = Graphics.FromImage(imageSource);
            var pen = new Pen(knotPointColor, knotPointRadius);
            for (int i = 0; i < gridKnotPoints.GetUpperBound(0); i++)
            {
                for (int j = 0; j < gridKnotPoints.GetUpperBound(1); j++)
                {
                    var gridPoint = GetGridKnotPoint(gridKnotPoints, i, j);
                    graphics.DrawPie(pen, gridPoint.Y, gridPoint.X, knotPointRadius, knotPointRadius, 0, 360);
                }
            }
        }
    }
}
