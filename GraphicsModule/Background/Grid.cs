using System;
using System.Drawing;
using System.Windows.Forms;
using GraphicsModule.Settings;

namespace GraphicsModule.Background
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
        public int StepOnWidth { get; set; }
        public int StepOnHeight { get; set; }
        /// <summary>
        /// Центральная точка сетки
        /// </summary>
        public Point CenterPoint { get; set; }

        public Grid(GridS sett, Graphics g)
        {
            StepOnWidth = sett.StepOfWidth;
            StepOnHeight = sett.StepOfHeight;
            Height = (int)g.VisibleClipBounds.Size.Height;
            Width = (int)g.VisibleClipBounds.Size.Width;
            CenterPoint = new Point(Width/2, Height/2);
            CalculateKnotsPoints();
        }

        public void CalculateKnotsPoints()
        {
            var xDim = (int)Math.Floor((double)(Width - CenterPoint.X)/StepOnWidth);
            var yDim = (int)Math.Floor((double)(Height - CenterPoint.Y)/StepOnHeight);

            Knots = new Point[yDim * 2 + 1, xDim * 2 + 1];
            Knots[0, 0] = new Point(CenterPoint.X - xDim*StepOnWidth, CenterPoint.Y - yDim*StepOnHeight);

            for (var i = 0; i <= yDim * 2; i++)
            {
                for (var j = 0; j <= xDim * 2; j++)
                {
                    if((i != 0) || (j != 0))
                    Knots[i,j] = new Point(Knots[0, 0].X + j*StepOnWidth, Knots[0, 0].Y + i * StepOnHeight);
                }
            }
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
            var gridPoints = new Point[(int)(Math.Floor((double)(gridHeight / gridHeighStep))) + 1, (int)(Math.Floor((double)(gridWidth / gridWidthStep))) + 1];
            var drawGridPoint = new Point();
            var iArr = 0;
            for (var i = 0; i <= gridPoints.GetUpperBound(0) * gridHeighStep; i += gridHeighStep)
            {
                iArr++;
                var jArr = 0;
                for (var j = 0; j <= gridPoints.GetUpperBound(1) * gridWidthStep; j += gridWidthStep)
                {
                    drawGridPoint.X = j;
                    drawGridPoint.Y = i;
                    jArr++;
                    gridPoints[iArr - 1, jArr - 1] = drawGridPoint;
                }
            }
            return gridPoints;
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
            var ptCenterGrid = new Point();
            var gridPoints = CalculateGrid(gridHeight, gridWidth, gridHeighStep, gridWidthStep);
            var ptCenterGridArr = (Point)gridPoints.GetValue(gridPoints.GetUpperBound(0) / 2, gridPoints.GetUpperBound(1) / 2);
            ptCenterGrid.X = ptCenterGridArr.X;
            ptCenterGrid.Y = ptCenterGridArr.Y;
            return ptCenterGrid;
        }
        /// <summary>
        /// Возвращает центральную узловую точку координатной сетки
        /// </summary>
        /// <param name="gridKnotPoints">Массив узловых точек координатной сетки</param>
        /// <returns></returns>
        public Point CalculateGridCenter(Point[,] gridKnotPoints)
        {
            var ptCenterGrid = new Point();
            var ptCenterGridArr = (Point)gridKnotPoints.GetValue(gridKnotPoints.GetUpperBound(0) / 2, gridKnotPoints.GetUpperBound(1) / 2);
            ptCenterGrid.X = ptCenterGridArr.X;
            ptCenterGrid.Y = ptCenterGridArr.Y;
            return ptCenterGrid;
        }
        /// <summary>
        /// Возвращает узловую точку координатной сетки
        /// </summary>
        /// <param name="gridKnotPoints">Массив узловых точек координатной сетки</param>
        /// <param name="iGrid">Номер точки по столбцу</param>
        /// <param name="jGrid">Номер точки по строке</param>
        /// <returns></returns>
        public Point GetGridKnotPoint(Point[,] gridKnotPoints, int iGrid, int jGrid)
        {
            var gridKnotPoint = new Point();
            var gridKnotPointArr = (Point)gridKnotPoints.GetValue(iGrid, jGrid);
            gridKnotPoint.X = gridKnotPointArr.X;
            gridKnotPoint.Y = gridKnotPointArr.Y;
            return gridKnotPoint;
        }

        /// <summary>
        /// Задает сетку на поверхности Graphics с учетом установленных по умолчанию параметров шага по вертикали и горизонтали, радиуса и цвета узловых точек сетки
        /// </summary>
        /// <param name="g">Заданная поверхность рисования</param>
        /// <remarks>Расчитывает и задает сетку с учетом размеров заданной поверхности рисования Graphics</remarks>
        //public void CreateGridToGraphics(Graphics g)
        //{
        //    if (Height == 0 || Width == 0)
        //    {
        //        Height = (int)g.VisibleClipBounds.Size.Height;
        //        Width = (int)g.VisibleClipBounds.Size.Width;
        //        Knots = CalculateGrid(Height, Width, Setting.StepOfHeight, Setting.StepOfWidth);
        //        CenterPoint = CalculateGridCenter(Knots);
        //        if (Setting.IsDraw)
        //        {
        //            DrawGrid(Knots, Setting.PointsColor, Setting.PointsSize, g);
        //        }
        //    }
        //    else
        //    {
        //        Knots = CalculateGrid(Height, Width, Setting.StepOfHeight, Setting.StepOfWidth);
        //        CenterPoint = CalculateGridCenter(Knots);
        //        if (Setting.IsDraw)
        //        {
        //            DrawGrid(Knots, Setting.PointsColor, Setting.PointsSize, g);
        //        }
        //    }
        //}
        public void DrawGrid(GridS sett, Graphics g)
        {
            if (sett.IsDraw)
            {
                DrawGrid(Knots, sett.PointsColor, sett.PointsSize, g);
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

    }
}
