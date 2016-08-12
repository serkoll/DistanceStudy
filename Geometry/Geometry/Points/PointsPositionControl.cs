using System;
using System.Windows.Forms;

namespace GeometryObjects
{
    // <summary>Класс анализа расположения 2D и 3D точек</summary>
    //<remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class PointsPositionControl
    {
        //Переменная для действий с 2D точками
        private Point2D Point2DCalc = new Point2D();
        //Переменная для действий с 3D точками
        private Point3D Point3DCalc = new Point3D();
        //Переменная для действий с классом проекций точек на горизонтальную плоскость 1_X0Y 
        private PointOfPlan1X0Y PointOfPlan1X0YVar = new PointOfPlan1X0Y();
        //Переменная для действий с классом проекций точек на фронтальную плоскость 2_X0Z 
        private PointOfPlan2X0Z PointOfPlan2_X0Z_Var = new PointOfPlan2X0Z();
        //Переменная для действий с классом проекций точек на профильную плоскость 3_Y0Z 
        private PointOfPlan3Y0Z PointOfPlan3_Y0Z_Var = new PointOfPlan3Y0Z();

        ///<summary> Перечислитель, указывающий индексы координат</summary>
        public enum CoordinateValue//Метки соответсвия координат заданному значению
        { None = 0, X = 1, Y = 2, Z = 3, XY = 4, XZ = 5, YZ = 6, XYZ = 7 }//Если CoordinateValue принимает значение None(0), то координаты не имеют заданное значение

        ///<summary> Перечислитель, указывающий индексы значений анализа задания и принадлежности точек осям и плоскостям системы координат </summary>
        ///<remarks>Метки принадлежности 3D точки и ее проекций плоскостям проекций и осям системы координат Монжа</remarks>
        public enum PointError
        { None = 0, СoordinateNothing = 1, Minus = 2, PointOfTop = 3 }// При PointError=Minus(2) - точка имеет отрицательные координаты

        //==================================================================================
        //==================== Расчет совпадения двух точек =======================
        //==================================================================================

        //-------------------- Расчет совпадения двух 2D точек -----------------------

        /// <summary>Возвращает значение "TRUE", если координаты X заданных 2D точек совпадают</summary>
        /// <remarks>Ось X направлена вправо.</remarks>
        public bool Point1_XisPoint2_X(Point2D Point1, Point2D Point2) { if (Point2.X - Point1.X == 0) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если координаты X заданных 2D точек совпадают</summary>
        /// <remarks>Параметр "SolveError" устанавливает погрешность расчета.
        /// Ось X направлена вправо.</remarks>
        public bool Point1_XisPoint2_X(Point2D Point1, Point2D Point2, double SolveError) { if (Math.Abs(Point2.X - Point1.X) <= SolveError) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если координаты Y заданных 2D точек совпадают</summary>
        /// <remarks>Ось Y направлена вверх.</remarks>
        public bool Point1_YisPoint2_Y(Point2D Point1, Point2D Point2) { if (Point2.Y - Point1.Y == 0) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если координаты Y заданных 2D точек совпадают</summary>
        /// <remarks>Параметр "SolveError" устанавливает погрешность расчета.
        /// Ось Y направлена вверх.</remarks>
        public bool Point1_YisPoint2_Y(Point2D Point1, Point2D Point2, double SolveError) { if (Math.Abs(Point2.Y - Point1.Y) <= SolveError) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если совпадают заданные 2D точки</summary>
        /// <remarks></remarks>
        public bool PointsIsPoints(Point2D Point1, Point2D Point2) { if (Math.Abs(Point1.X - Point2.X) == 0 & Math.Abs(Point1.Y - Point2.Y) == 0) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если совпадают заданные 2D точки</summary>
        /// <remarks>Параметр "SolveError" устанавливает погрешность расчета</remarks>
        public bool PointsIsPoints(Point2D Point1, Point2D Point2, double SolveError) { if (Math.Abs(Point1.X - Point2.X) <= SolveError & Math.Abs(Point1.Y - Point2.Y) <= SolveError) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если все 2D точки, заданные в массиве, совпадают</summary>
        /// <remarks></remarks>
        public bool PointsIsPoints(Point2D[] Points)//Реализовать в 2D и 3D классах + Реализовать совпадение точек в 2D и 3D классах и плоскостей
        {
            int i = 0; bool BoolVar = false;
            for (i = 0; i <= Points.GetUpperBound(0) - 1; i++)
            {
                if (i == Points.GetUpperBound(0)) { break; }
                if (PointsIsPoints(Points[i], Points[i + 1]) == true) { BoolVar = true; }
                else { BoolVar = false; break; }
            }
            return BoolVar;
        }

        /// <summary>Возвращает значение "TRUE", если все 2D точки заданного массива совпадают</summary>
        /// <remarks>Параметр "SolveError" устанавливает погрешность расчета</remarks>
        public bool PointsIsPoints(Point2D[] Points, double SolveError)//Реализовать в 2D и 3D классах + Реализовать совпадение точек в 2D и 3D классах и плоскостей
        {
            int i = 0; bool BoolVar = false;
            for (i = 0; i <= Points.GetUpperBound(0) - 1; i++)
            {
                if (i == Points.GetUpperBound(0)) { break; }
                if (PointsIsPoints(Points[i], Points[i + 1], SolveError) == true) { BoolVar = true; }
                else { BoolVar = false; break; }
            }
            return BoolVar;
        }

        //-------------------- Расчет совпадения двух 3D точек -----------------------

        /// <summary>Возвращает значение "TRUE", если координаты X заданных 3D точек совпадают</summary>
        /// <remarks>Ось X направлена вправо.</remarks>
        public bool Point1_XisPoint2_X(Point3D Point1, Point3D Point2) { if (Point2.X - Point1.X == 0) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если координаты X заданных 3D точек совпадают</summary>
        /// <remarks>Параметр "SolveError" устанавливает погрешность расчета.
        /// Ось X направлена вправо.</remarks>
        public bool Point1_XisPoint2_X(Point3D Point1, Point3D Point2, double SolveError) { if (Math.Abs(Point2.X - Point1.X) <= SolveError) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если координаты Y заданных 3D точек совпадают</summary>
        /// <remarks>Ось Y направлена вверх.</remarks>
        public bool Point1_YisPoint2_Y(Point3D Point1, Point3D Point2) { if (Point2.Y - Point1.Y == 0) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если координаты Y заданных 3D точек совпадают</summary>
        /// <remarks>Параметр "SolveError" устанавливает погрешность расчета.
        /// Ось Y направлена вверх.</remarks>
        public bool Point1_YisPoint2_Y(Point3D Point1, Point3D Point2, double SolveError) { if (Math.Abs(Point2.Y - Point1.Y) <= SolveError) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если координаты Z заданных 3D точек совпадают</summary>
        /// <remarks>Ось Z направлена наблюдателю.</remarks>
        public bool Point1_ZisPoint2_Z(Point3D Point1, Point3D Point2) { if (Point2.Z - Point1.Z == 0) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если координаты Z заданных 3D точек совпадают</summary>
        /// <remarks>Параметр "SolveError" устанавливает погрешность расчета.
        /// Ось Z направлена к наблюдателю.</remarks>
        public bool Point1_ZisPoint2_Z(Point3D Point1, Point3D Point2, double SolveError) { if (Math.Abs(Point2.Z - Point1.Z) <= SolveError) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если совпадают заданные 3D точки</summary>
        /// <remarks></remarks>
        public bool PointsIsPoints(Point3D Point1, Point3D Point2) { if (PointsIsPoints(Point1, Point2) == true & Math.Abs(Point1.Z - Point2.Z) == 0) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если совпадают заданные 3D точки</summary>
        /// <remarks>Параметр "SolveError" устанавливает погрешность расчета</remarks>
        public bool PointsIsPoints(Point3D Point1, Point3D Point2, double SolveError) { if (PointsIsPoints(Point1, Point2, SolveError) == true & Math.Abs(Point1.Z - Point2.Z) <= SolveError) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если все 3D точки, заданные в массиве совпадают</summary>
        /// <remarks></remarks>
        public bool PointsIsPoints(Point3D[] Points)
        {
            int i = 0; bool BoolVar = false;
            for (i = 0; i <= Points.GetUpperBound(0) - 1; i++)
            {
                if (i == Points.GetUpperBound(0)) { break; }
                if (PointsIsPoints(Points[i], Points[i + 1]) == true) { BoolVar = true; }
                else { BoolVar = false; break; }
            }
            return BoolVar;
        }

        /// <summary>Возвращает значение "TRUE", если все 3D точки, заданные в массиве совпадают</summary>
        /// <remarks>Параметр "SolveError" устанавливает погрешность расчета</remarks>
        public bool PointsIsPoints(Point3D[] Points, double SolveError)
        {
            int i = 0; bool BoolVar = false;
            for (i = 0; i <= Points.GetUpperBound(0) - 1; i++)
            {
                if (i == Points.GetUpperBound(0)) { break; }
                if (PointsIsPoints(Points[i], Points[i + 1], SolveError) == true) { BoolVar = true; }
                else { BoolVar = false; break; }
            }
            return BoolVar;
        }

        /// <summary>Сравнивает положение двух заданных проекций точек на плоскость X0Y</summary>
        /// <param name="PointProjection_1">Первая заданная проекция точки на плоскость X0Y</param>
        /// <param name="PointProjection_2">Вторая заданная проекция точки на плоскость X0Y</param>
        /// <returns>Возвращает "True" при совпадении положения двух заданных проекций точек. В противном случае возвращает "False"</returns>
        /// <remarks>Точность расчетов не регламентируется</remarks>
        public bool PointsIsPoints(GeometryObjects.PointOfPlan1X0Y PointProjection_1, GeometryObjects.PointOfPlan1X0Y PointProjection_2) { return PointsIsPoints(PointOfPlan1X0YVar.CnvPoint2D(PointProjection_1), PointOfPlan1X0YVar.CnvPoint2D(PointProjection_2)); }

        /// <summary>Сравнивает положение двух заданных проекций точек на плоскость X0Z</summary>
        /// <param name="PointProjection_1">Первая заданная проекция точки на плоскость X0Z</param>
        /// <param name="PointProjection_2">Вторая заданная проекция точки на плоскость X0Z</param>
        /// <returns>Возвращает "True" при совпадении положения двух заданных проекций точек. В противном случае возвращает "False"</returns>
        /// <remarks>Точность расчетов не регламентируется</remarks>
        public bool PointsIsPoints(PointOfPlan2X0Z PointProjection_1, PointOfPlan2X0Z PointProjection_2) { return PointsIsPoints(PointOfPlan2_X0Z_Var.CnvPoint2D(PointProjection_1), PointOfPlan2_X0Z_Var.CnvPoint2D(PointProjection_2)); }

        /// <summary>Сравнивает положение двух заданных проекций точек на плоскость Y0Z</summary>
        /// <param name="PointProjection_1">Первая заданная проекция точки на плоскость Y0Z</param>
        /// <param name="PointProjection_2">Вторая заданная проекция точки на плоскость Y0Z</param>
        /// <returns>Возвращает "True" при совпадении положения двух заданных проекций точек. В противном случае возвращает "False"</returns>
        /// <remarks>Точность расчетов не регламентируется</remarks>
        public bool PointsIsPoints(GeometryObjects.PointOfPlan3Y0Z PointProjection_1, GeometryObjects.PointOfPlan3Y0Z PointProjection_2) { return PointsIsPoints(PointOfPlan3_Y0Z_Var.CnvPoint2D(PointProjection_1), PointOfPlan3_Y0Z_Var.CnvPoint2D(PointProjection_2)); }

        //==================================================================================
        //==================== Расчет взаимного положения двух точек =======================
        //==================================================================================

        //-------------------- Расчет взаимного положения двух 2D точек -----------------------

        /// <summary>Возвращает значение "TRUE", если 2D точка 2 левее 2D точки 1</summary>
        /// <remarks>Ось X направлена вправо.</remarks>
        public bool Point2AtLeftPoint1(Point2D Point1, Point2D Point2) { if (Point2.X - Point1.X < 0) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 2D точка 2 левее 2D точки 1</summary>
        /// <remarks>Параметр "SolveError" устанавливает погрешность расчета.
        /// Ось X направлена вправо.</remarks>
        public bool Point2AtLeftPoint1(Point2D Point1, Point2D Point2, double SolveError)
        { if (Point2.X - Point1.X < SolveError) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 2D точка 2 правее 2D точки 1</summary>
        /// <remarks>Ось X направлена вправо.</remarks>
        public bool Point2AtRightPoint1(Point2D Point1, Point2D Point2) { if (Point2.X - Point1.X > 0) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 2D точка 2 правее 2D точки 1</summary>
        /// <remarks>Параметр "SolveError" устанавливает погрешность расчета.
        /// Ось X направлена вправо.</remarks>
        public bool Point2AtRightPoint1(Point2D Point1, Point2D Point2, double SolveError) { if (Point2.X - Point1.X > SolveError) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 2D точка 2 выше 2D точки 1</summary>
        /// <remarks>Ось Y направлена вверх.</remarks>
        public bool Point2ОverPoint1(Point2D Point1, Point2D Point2) { if (Point2.Y - Point1.Y > 0) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 2D точка 2 выше 2D точки 1</summary>
        /// <remarks>Параметр "SolveError" устанавливает погрешность расчета.
        /// Ось Y направлена вверх.</remarks>
        public bool Point2ОverPoint1(Point2D Point1, Point2D Point2, double SolveError) { if (Point2.Y - Point1.Y > SolveError) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 2D точка 2 ниже 2D точки 1</summary>
        /// <remarks>Ось Y направлена вверх.</remarks>
        public bool Point2UnderPoint1(Point2D Point1, Point2D Point2) { if (Point2.Y - Point1.Y < 0) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 2D точка 2 ниже 2D точки 1</summary>
        /// <remarks>Параметр "SolveError" устанавливает погрешность расчета.
        /// Ось Y направлена вверх.</remarks>
        public bool Point2UnderPoint1(Point2D Point1, Point2D Point2, double SolveError) { if (Point2.Y - Point1.Y < SolveError) { return true; } else { return false; } }

        //-------------------- Расчет взаимного положения двух 3D точек -----------------------

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 левее 3D точки 1</summary>
        /// <remarks>Ось X направлена вправо.</remarks>
        public bool Point2AtLeftPoint1(Point3D Point1, Point3D Point2) { if (Point2.X - Point1.X < 0) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 левее 3D точки 1</summary>
        /// <remarks>Параметр "SolveError" устанавливает погрешность расчета.
        /// Ось X направлена вправо.</remarks>
        public bool Point2AtLeftPoint1(Point3D Point1, Point3D Point2, double SolveError) { if (Point2.X - Point1.X < SolveError) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 правее 3D точки 1</summary>
        /// <remarks>Ось X направлена вправо.</remarks>
        public bool Point2AtRightPoint1(Point3D Point1, Point3D Point2) { if (Point2.X - Point1.X > 0) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 правее 3D точки 1</summary>
        /// <remarks>Параметр "SolveError" устанавливает погрешность расчета.
        /// Ось X направлена вправо.</remarks>
        public bool Point2AtRightPoint1(Point3D Point1, Point3D Point2, double SolveError) { if (Point2.X - Point1.X > SolveError) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 выше 3D точки 1</summary>
        /// <remarks>Ось Z направлена вверх.</remarks>
        public bool Point2ОverPoint1(Point3D Point1, Point3D Point2) { if (Point2.Z - Point1.Z > 0) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 выше 3D точки 1</summary>
        /// <remarks>Параметр "SolveError" устанавливает погрешность расчета.
        /// Ось Z направлена вверх.</remarks>
        public bool Point2ОverPoint1(Point3D Point1, Point3D Point2, double SolveError) { if (Point2.Z - Point1.Z > SolveError) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 ниже 3D точки 1</summary>
        /// <remarks>Ось Z направлена вверх.</remarks>
        public bool Point2UnderPoint1(Point3D Point1, Point3D Point2) { if (Point2.Z - Point1.Z < 0) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 ниже 3D точки 1</summary>
        /// <remarks>Параметр "SolveError" устанавливает погрешность расчета.
        /// Ось Z направлена вверх.</remarks>
        public bool Point2UnderPoint1(Point3D Point1, Point3D Point2, double SolveError) { if (Point2.Z - Point1.Z < SolveError) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 перед 3D точкой 1</summary>
        /// <remarks>Ось Y направлена к наблюдателю.</remarks>
        public bool Point2BeforePoint1(Point3D Point1, Point3D Point2) { if (Point2.Y - Point1.Y > 0) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 перед 3D точкой 1</summary>
        /// <remarks>Ось Y направлена к наблюдателю.</remarks>
        public bool Point2BeforePoint1(Point3D Point1, Point3D Point2, double SolveError) { if (Point2.Y - Point1.Y > SolveError) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 за 3D точкой 1</summary>
        /// <remarks>Ось Y направлена к наблюдателю.</remarks>
        public bool Point2AfterPoint1(Point3D Point1, Point3D Point2) { if (Point2.Y - Point1.Y < 0) { return true; } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 за 3D точкой 1</summary>
        /// <remarks>Ось Y направлена к наблюдателю.</remarks>
        public bool Point2AfterPoint1(Point3D Point1, Point3D Point2, double SolveError) { if (Point2.Y - Point1.Y < SolveError) { return true; } else { return false; } }

        //-------------------- Расчет !!!строгого!!! взаимного положения двух 2D точек -----------------------

        /// <summary>Возвращает значение "TRUE", если 2D точка 2 строго левее 2D точки 1</summary>
        /// <remarks>Координаты Y обеих точек равны.
        /// Ось X направлена вправо.</remarks>
        public bool Point2AtLeftPoint1Only(Point2D Point1, Point2D Point2) { if (Point2.Y - Point1.Y == 0) { if (Point2.X - Point1.X < 0) { return true; } else { return false; } } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 2D точка 2 строго левее 2D точки 1</summary>
        /// <remarks>Координаты Y обеих точек равны.
        /// Ось X направлена вправо. Параметр "SolveError" устанавливает погрешность расчета.</remarks>
        public bool Point2AtLeftPoint1Only(Point2D Point1, Point2D Point2, double SolveError) { if (Math.Abs(Point2.Y - Point1.Y) <= SolveError) { if (Point2.X - Point1.X < SolveError) { return true; } else { return false; } } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 2D точка 2 строго правее 2D точки 1</summary>
        /// <remarks>Координаты Y обеих точек равны.
        /// Ось X направлена вправо.</remarks>
        public bool Point2AtRightPoint1Only(Point2D Point1, Point2D Point2) { if (Point2.Y - Point1.Y == 0) { if (Point2.X - Point1.X > 0) { return true; } else { return false; } } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 2D точка 2 строго правее 2D точки 1</summary>
        /// <remarks>Координаты Y обеих точек равны.
        /// Ось X направлена вправо. Параметр "SolveError" устанавливает погрешность расчета.</remarks>
        public bool Point2AtRightPoint1Only(Point2D Point1, Point2D Point2, double SolveError) { if (Math.Abs(Point2.Y - Point1.Y) <= SolveError) { if (Point2.X - Point1.X > SolveError) { return true; } else { return false; } } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 2D точка 2 строго выше 2D точки 1</summary>
        /// <remarks>Ось Y направлена вверх.</remarks>
        public bool Point2ОverPoint1Only(Point2D Point1, Point2D Point2) { if (Point2.X - Point1.X == 0) { if (Point2.Y - Point1.Y > 0) { return true; } else { return false; } } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 2D точка 2 строго выше 2D точки 1</summary>
        /// <remarks>Ось Y направлена вверх.</remarks>
        public bool Point2ОverPoint1Only(Point2D Point1, Point2D Point2, double SolveError) { if (Math.Abs(Point2.X - Point1.X) <= SolveError) { if (Point2.Y - Point1.Y > SolveError) { return true; } else { return false; } } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 2D точка 2 строго ниже 2D точки 1</summary>
        /// <remarks>Ось Y направлена вверх.</remarks>
        public bool Point2UnderPoint1Only(Point2D Point1, Point2D Point2) { if (Point2.X - Point1.X == 0) { if (Point2.Y - Point1.Y < 0) { return true; } else { return false; } } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 2D точка 2 строго ниже 2D точки 1</summary>
        /// <remarks>Ось Y направлена вверх.</remarks>
        public bool Point2UnderPoint1Only(Point2D Point1, Point2D Point2, double SolveError) { if (Math.Abs(Point2.X - Point1.X) <= SolveError) { if (Point2.Y - Point1.Y < SolveError) { return true; } else { return false; } } else { return false; } }

        //-------------------- Расчет строгого взаимного положения двух 3D точек -----------------------

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 строго левее 3D точки 1</summary>
        /// <remarks>Координаты Y и Z обеих точек равны.
        /// Ось X направлена влево.</remarks>
        public bool Point2AtLeftPoint1Only(Point3D Point1, Point3D Point2) { if (Point2.Y - Point1.Y == 0 & Point2.Z - Point1.Z == 0) { if (Point2.X - Point1.X < 0) { return true; } else { return false; } } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 строго левее 3D точки 1</summary>
        /// <remarks>Координаты Y и Z обеих точек равны.
        /// Ось X направлена влево. Параметр "SolveError" устанавливает погрешность расчета.</remarks>
        public bool Point2AtLeftPoint1Only(Point3D Point1, Point3D Point2, double SolveError) { if (Math.Abs(Point2.Y - Point1.Y) <= SolveError & Math.Abs(Point2.Z - Point1.Z) <= SolveError) { if (Point2.X - Point1.X < SolveError) { return true; } else { return false; } } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 строго правее 3D точки 1</summary>
        /// <remarks>Координаты Y и Z обеих точек равны.
        /// Ось X направлена влево.</remarks>
        public bool Point2AtRightPoint1Only(Point3D Point1, Point3D Point2) { if (Point2.Y - Point1.Y == 0 & Point2.Z - Point1.Z == 0) { if (Point2.X - Point1.X > 0) { return true; } else { return false; } } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 строго правее 3D точки 1</summary>
        /// <remarks>Координаты Y и Z обеих точек равны.
        /// Ось X направлена влево. Параметр "SolveError" устанавливает погрешность расчета.</remarks>
        public bool Point2AtRightPoint1Only(Point3D Point1, Point3D Point2, double SolveError) { if (Math.Abs(Point2.Y - Point1.Y) <= SolveError & Math.Abs(Point2.Z - Point1.Z) <= SolveError) { if (Point2.X - Point1.X > SolveError) { return true; } else { return false; } } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 строго выше 3D точки 1</summary>
        /// <remarks>Ось Z направлена вверх.</remarks>
        public bool Point2ОverPoint1Only(Point3D Point1, Point3D Point2) { if (Point2.X - Point1.X == 0 & Point2.Y - Point1.Y == 0) { if (Point2.Z - Point1.Z > 0) { return true; } else { return false; } } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 строго выше 3D точки 1</summary>
        /// <remarks>Ось Z направлена вверх.</remarks>
        public bool Point2ОverPoint1Only(Point3D Point1, Point3D Point2, double SolveError) { if (Math.Abs(Point2.X - Point1.X) <= SolveError & Math.Abs(Point2.Y - Point1.Y) <= SolveError) { if (Point2.Z - Point1.Z > SolveError) { return true; } else { return false; } } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 строго ниже 3D точки 1</summary>
        /// <remarks>Ось Z направлена вверх.</remarks>
        public bool Point2UnderPoint1Only(Point3D Point1, Point3D Point2) { if (Point2.X - Point1.X == 0 & Point2.Y - Point1.Y == 0) { if (Point2.Z - Point1.Z < 0) { return true; } else { return false; } } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 строго ниже 3D точки 1</summary>
        /// <remarks>Ось Z направлена вверх.</remarks>
        public bool Point2UnderPoint1Only(Point3D Point1, Point3D Point2, double SolveError) { if (Math.Abs(Point2.X - Point1.X) <= SolveError & Math.Abs(Point2.Y - Point1.Y) <= SolveError) { if (Point2.Z - Point1.Z < SolveError) { return true; } else { return false; } } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 строго перед 3D точкой 1</summary>
        /// <remarks>Ось Y направлена к наблюдателю.</remarks>
        public bool Point2BeforePoint1Only(Point3D Point1, Point3D Point2)
        {
            if (Point2.X - Point1.X == 0 & Point2.Z - Point1.Z == 0)
            {
                if (Point2.Y - Point1.Y > 0) { return true; }
                else { return false; }
            }
            else { return false; }
        }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 строго перед 3D точкой 1</summary>
        /// <remarks>Ось Y направлена к наблюдателю.</remarks>
        public bool Point2BeforePoint1Only(Point3D Point1, Point3D Point2, double SolveError)
        {
            if (Math.Abs(Point2.X - Point1.X) <= SolveError & Math.Abs(Point2.Z - Point1.Z) <= SolveError)
            {
                if (Point2.Y - Point1.Y > SolveError) { return true; }
                else { return false; }
            }
            else { return false; }
        }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 строго за 3D точкой 1</summary>
        /// <remarks>Ось Y направлена к наблюдателю.</remarks>
        public bool Point2AfterPoint1Only(Point3D Point1, Point3D Point2) { if (Point2.X - Point1.X == 0 & Point2.Z - Point1.Z == 0) { if (Point2.Y - Point1.Y < 0) { return true; } else { return false; } } else { return false; } }

        /// <summary>Возвращает значение "TRUE", если 3D точка 2 строго за 3D точкой 1</summary>
        /// <remarks>Ось Y направлена к наблюдателю.</remarks>
        public bool Point2AfterPoint1Only(Point3D Point1, Point3D Point2, double SolveError) { if (Math.Abs(Point2.X - Point1.X) <= SolveError & Math.Abs(Point2.Z - Point1.Z) <= SolveError) { if (Point2.Y - Point1.Y < SolveError) { return true; } else { return false; } } else { return false; } }

        //==================================================================================
        //======== Расчет соответсвия значений координат точки заданному значению ==========
        //==================================================================================

        //-------------------- Расчет соответсвия значений координат точки некоторому заданному значению -----------------------

        /// <summary>Возвращает номер перечисления "CoordinateValue", указывающего индексы координат, которые соответсвуют заданному значению</summary>
        /// <remarks>Возвращается CoordinateValue.None, если координаты точки не равны заданному значению</remarks>
        public Enum CoordinateIsValue(Point3D Point3D, double Value)//Контроль значений координат точки заданному значению //Возвращает метку, соответсвующую координатам, для которых соответсвие выполняется
        {
            Enum CoordinateValueVar = CoordinateValue.None;//Исходное значение нумератора
            bool Xbool = false; bool Ybool = false; bool Zbool = false;
            //Контроль наличия отрицательных координат
            if (Point3D.X == Value) { Xbool = true; } if (Point3D.Y == Value) { Ybool = true; } if (Point3D.Z == Value) { Zbool = true; }
            //Контроль меток для ввода в наименований координат в комментарий
            if (Xbool & Ybool & Zbool) { CoordinateValueVar = CoordinateValue.XYZ; }
            else if (Xbool & Ybool & Zbool == false) { CoordinateValueVar = CoordinateValue.XY; }
            else if (Xbool & Ybool == false & Zbool) { CoordinateValueVar = CoordinateValue.XZ; }
            else if (Xbool == false & Ybool & Zbool) { CoordinateValueVar = CoordinateValue.YZ; }
            else if (Xbool & Ybool == false & Zbool == false) { CoordinateValueVar = CoordinateValue.X; }
            else if (Xbool == false & Ybool & Zbool == false) { CoordinateValueVar = CoordinateValue.Y; }
            else if (Xbool == false & Ybool == false & Zbool) { CoordinateValueVar = CoordinateValue.Z; }
            else { CoordinateValueVar = CoordinateValue.None; }//Значения координат положительные или равны заданному значению
            return CoordinateValueVar;
        }

        //-------------------- Контроль отрицательных значений координат точки -----------------------

        /// <summary> Возвращает значение "True", если имеются отрицательные значения координат</summary>
        /// <param name="Point3D"> Заданная 3D точка</param>
        public bool PointMinus(Point3D Point3D)//Контроль отрицательных координат
        {
            Enum EnumPointError = PointError.Minus;//Исходное значение нумератора
            return PointMinus(Point3D, EnumPointError);
        }

        /// <summary> Возвращает значение "True" и номер перечисления "CoordinateValue", указывающего индексы координат, имеющих отрицательные значения</summary>
        /// <param name="Point3D"> Заданная 3D точка</param>
        /// <param name="EnumPointError"> Значение перечисления, указывающего индексы координат, имеющих отрицательные значения</param>
        public bool PointMinus(Point3D Point3D, Enum EnumPointError)//Контроль отрицательных координат
        {
            bool Ptbool = false; string CommentPt_Var = null; Ptbool = PointMinus(Point3D, CommentPt_Var, EnumPointError);
            if (Ptbool) { MessageBox.Show(CommentPt_Var, "Контроль ввода координат", MessageBoxButtons.OK, MessageBoxIcon.Error); }//MsgBox(CommentPt_Var & Environment.NewLine &"Параметры геометрической формы двумерного объекта не должны быть меньше или равны нулю.", MsgBoxStyle.Critical, "Контроль ввода координат")
            return Ptbool;
        }

        /// <summary> Возвращает значение "True", если имеются отрицательные значения координат</summary>
        /// <remarks> Позволяет отображать MessagerBox, возникающий в случае существования отрицательных значений координат</remarks>
        /// <param name="Point3D"> Заданная 3D точка</param>
        /// <param name="MessagerBoxShow"> Устанавливает отображение MessagerBox с комментариями, возникающего в случае существования отрицательных значений координат</param>
        public bool PointMinus(Point3D Point3D, bool MessagerBoxShow)//Контроль отрицательных координат
        {
            bool MinusBool = false; Enum EnumPointError = PointError.Minus;//Исходное значение нумератора
            if (MessagerBoxShow == true) { MinusBool = PointMinus(Point3D, EnumPointError); }
            else { MinusBool = PointMinus(Point3D, null, EnumPointError); }
            return MinusBool;
        }

        /// <summary> Возвращает значение "True" и номер перечисления "CoordinateValue", указывающего индексы координат, имеющих отрицательные значения</summary>
        /// <remarks> Позволяет вставлять комментарий в MessagerBox, возникающий в случае существования отрицательного значения координат</remarks>
        /// <param name="Point3D"> Заданная 3D точка</param>
        /// <param name="CommentMinus"> Пользовательский комментарий в MessagerBox, возникающий в случае существования отрицательные значения координат</param>
        /// <param name="EnumPointError"> Значение перечисления, указывающего индексы координат, имеющих отрицательные значения</param>
        public bool PointMinus(Point3D Point3D, string CommentMinus, Enum EnumPointError)//Контроль отрицательных координат
        {
            bool Xbool = false; bool Ybool = false; bool Zbool = false; bool Ptbool = true; EnumPointError = PointError.Minus;//Исходное значение нумератора
            //Контроль наличия отрицательных координат
            if (Point3D.X < 0) { Xbool = true; Ptbool = true; }
            if (Point3D.Y < 0) { Ybool = true; Ptbool = true; }
            if (Point3D.Z < 0) { Zbool = true; Ptbool = true; }
            //Контроль комментария на случай отсутствия внешнего значения
            if (CommentMinus == null) { CommentMinus = "Заданная точка не должна иметь отрицательных координат"; }
            //Контроль меток для ввода наименований координат в комментарий
            if (Xbool & Ybool & Zbool) { CommentMinus = "Заданные координаты" + " X" + "; " + " Y" + ";" + " Z" + " имеют отрицательные значения" + Environment.NewLine + Environment.NewLine + CommentMinus; }
            else if (Xbool & Ybool & Zbool == false) { CommentMinus = "Заданные координаты" + " X" + "; " + " Y" + " имеют отрицательные значения" + Environment.NewLine + Environment.NewLine + CommentMinus; }
            else if (Xbool & Ybool == false & Zbool) { CommentMinus = "Заданные координаты" + " X" + ";" + " Z" + " имеют отрицательные значения" + Environment.NewLine + Environment.NewLine + CommentMinus; }
            else if (Xbool == false & Ybool & Zbool) { CommentMinus = "Заданные координаты" + " Y" + ";" + " Z" + " имеют отрицательные значения" + Environment.NewLine + Environment.NewLine + CommentMinus; }
            else if (Xbool & Ybool == false & Zbool == false) { CommentMinus = "Заданная координата" + " X" + " имеет отрицательное значение" + Environment.NewLine + Environment.NewLine + CommentMinus; }
            else if (Xbool == false & Ybool & Zbool == false) { CommentMinus = "Заданная координата" + " Y" + " имеет отрицательное значение" + Environment.NewLine + Environment.NewLine + CommentMinus; }
            else if (Xbool == false & Ybool == false & Zbool) { CommentMinus = "Заданная координата" + " Z" + " имеет отрицательное значение" + Environment.NewLine + Environment.NewLine + CommentMinus; }
            else { Ptbool = false; EnumPointError = PointError.None; }//Значения координат положительные или равны нулю
            return Ptbool;
        }

    }
}