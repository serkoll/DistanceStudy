using System;
using System.Drawing;
using GraphicsModule.Configuration;
// ReSharper disable PossibleLossOfFraction

namespace GraphicsModule.Geometry.CoordinateSystem
{
    /// <summary>
    /// Класс, содержащий инструменты задания и отрисовки СЕТКИ
    /// </summary>
    public class Grid
    { 
        private Point[,] _knots;
        private readonly int _width;
        private readonly int _height;
        private Point _coordinateSystemCenterPoint;

        /// <summary>
        /// Конструктор для инициализации сетки по заданным настройкам и центру точке системы координат
        /// </summary>
        /// <param name="settings">Настройки сетки</param>
        /// <param name="centerPoint">Центр системы координат</param>
        /// <param name="graphics">Graphics</param>
        public Grid(GridSettings settings, Point centerPoint, Graphics graphics)
        {
            StepOnWidth = settings.StepOfWidth;
            StepOnHeight = settings.StepOfHeight;
            _height = (int)graphics.VisibleClipBounds.Size.Height;
            _width = (int)graphics.VisibleClipBounds.Size.Width;
            _coordinateSystemCenterPoint = new Point(centerPoint.X, centerPoint.Y);
            CalculateKnotsPoints();
        }

        /// <summary>
        /// Отрисовывает сетку согласно настройкам
        /// </summary>
        /// <param name="sett">Настройки сетки</param>
        /// <param name="g">Graphics</param>
        public void DrawGrid(GridSettings sett, Graphics g)
        {
            if (sett.IsDraw)
            {
                DrawGrid(_knots, sett.PointsColor, sett.PointsSize, g);
            }
        }

        private void DrawGrid(Point[,] gridKnotPoints, Color knotPointColor, int knotPointRadius, Graphics graphics)
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

        private void CalculateKnotsPoints()
        {
            var xDim = (int)Math.Floor((double)(_width - _coordinateSystemCenterPoint.X)/StepOnWidth);
            var yDim = (int)Math.Floor((double)(_height - _coordinateSystemCenterPoint.Y)/StepOnHeight);

            _knots = new Point[yDim * 2 + 1, xDim * 2 + 1];
            _knots[0, 0] = new Point(_coordinateSystemCenterPoint.X - xDim*StepOnWidth, _coordinateSystemCenterPoint.Y - yDim*StepOnHeight);

            for (var i = 0; i <= yDim * 2; i++)
            {
                for (var j = 0; j <= xDim * 2; j++)
                {
                    if((i != 0) || (j != 0))
                    _knots[i,j] = new Point(_knots[0, 0].X + j*StepOnWidth, _knots[0, 0].Y + i * StepOnHeight);
                }
            }
        }

        private Point GetGridKnotPoint(Point[,] gridKnotPoints, int iGrid, int jGrid)
        {
            var gridKnotPoint = new Point();
            var gridKnotPointArr = (Point)gridKnotPoints.GetValue(iGrid, jGrid);
            gridKnotPoint.X = gridKnotPointArr.X;
            gridKnotPoint.Y = gridKnotPointArr.Y;
            return gridKnotPoint;
        }

        /// <summary>
        /// Шаг сетки по ширине
        /// </summary>
        public int StepOnWidth { get; }

        /// <summary>
        /// Шаг сетки по высоте
        /// </summary>
        public int StepOnHeight { get; }

    }
}
