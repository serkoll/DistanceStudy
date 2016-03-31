using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GeomObjects.Points;
using GeomObjects.Lines;
using GeomObjects.EquationsSysCalc;
using GeomObjects.Plans;

namespace DrawG
{
    /// <summary>
    /// Класс, содержащий инструменты расчёта сетки
    /// </summary>
    class GridCalculation
    {
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
            Point[,] GridPoints=new Point[(int)(Math.Floor((double)(gridHeight/gridHeighStep))) + 1,(int)(Math.Floor((double)(gridWidth/gridWidthStep))) + 1];
            Point DrawGridPoint= new Point();
            int iArr=0, jArr=0;
            for (int i = 0; i <= GridPoints.GetUpperBound(0) * gridHeighStep; i+=gridHeighStep )
            {
                iArr++;
                jArr = 0;
                for(int j = 0 ;j <= GridPoints.GetUpperBound(1) * gridWidthStep; j+=gridWidthStep)
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
        public Point CalculateGridCentre(int gridHeight, int gridWidth, int gridHeighStep, int gridWidthStep)
        {
            Point PtCenterGrid= new Point();
            Point[,] GridPoints = CalculateGrid(gridHeight, gridWidth, gridHeighStep, gridWidthStep);
            Point PtCenterGridArr;
            PtCenterGridArr = (Point)GridPoints.GetValue((int)(GridPoints.GetUpperBound(0)/2),(int)(GridPoints.GetUpperBound(1)/2));
            PtCenterGrid.X = PtCenterGridArr.X;
            PtCenterGrid.Y = PtCenterGridArr.Y;
            return PtCenterGrid;
        }
        /// <summary>
        /// Возвращает центральную узловую точку координатной сетки
        /// </summary>
        /// <param name="GridKnotPoints">Массив узловых точек координатной сетки</param>
        /// <returns></returns>
        public Point CalculateGridCentre(Point[,] GridKnotPoints)
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
    }
}
