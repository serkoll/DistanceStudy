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
    /// Класс для расчёта осей координат
    /// </summary>
    class AxisCalculation
    {
        /// <summary>
        /// Рассчитывает концевые точки ортоганальных 2D осей с началом в центре заданной сетки узловых точек
        /// </summary>
        /// <param name="GridKnotPoints"></param>
        /// <returns>Возвращает массив 4-х концевых точек ортоганальных 2D осей</returns>
        /// <remarks>Первые две точки задают горизонтальную ось. Вторые две точки задают вертикальную ось</remarks>
        public Point[] CalculateAxis(Point[,] GridKnotPoints)
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
        public Point GetAxisFinitePoint(Point[] axisFinitePoints, int pointNumber)
        {
            return (Point)axisFinitePoints.GetValue(pointNumber);
        }
    }
}
