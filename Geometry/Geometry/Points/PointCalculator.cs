using System;

namespace GeometryObjects
{ 
    /// <summary>
    /// Класс действий с параметрами 2D и 3D точек
    /// </summary>
    /// Copyright © Polozkov V. Yury, 2013
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    class PointCalculator
    {
        private Point2D PointCalcVar2D = new Point2D();//Переменная для действий с 2D точками
        private Point3D PointCalcVar3D = new Point3D();  //Переменная для действий с 3D точками

        //-------------------- Расчет расстояния от начала координат до 3D точки -----------------------

        /// <summary>Возвращает расстояние от начала координат до точки</summary>
        /// <remarks>По умолчанию начало координат в точке (0; 0; 0)</remarks>
        public double PointLength(Point3D Point)
        { Point3D Point1L = new Point3D(); return PointDistantion(Point1L, Point); }//Функция возвращает значение расстояния от начала координат до 3D точки

        //==================================================================================
        //==================== Расчет расстояния между двумя точками =======================
        //==================================================================================

        //-------------------- Расчет расстояния между двумя 2D точками -----------------------

        /// <summary>Возвращает расстояние от ранее заданной 2D точки до 2D точки, заданной указанными координатами</summary>
        /// <remarks>По умолчанию ранее заданная 2D точка имеет координаты (0; 0)</remarks>
        public double PointDistantion(double X, double Y) { return Math.Sqrt(Math.Pow((PointCalcVar2D.X - X), 2) + Math.Pow((PointCalcVar2D.Y - Y), 2)); }//Вычисление расстояния до точки с указанными координатами

        /// <summary>Возвращает расстояние от ранее заданной 2D точки до 2D точки, заданной указанными координатами</summary>
        /// <remarks></remarks>
        public double PointDistantion(double X1, double Y1, double X2, double Y2) { return Math.Sqrt(Math.Pow((X1 - X2), 2) + Math.Pow((Y1 - Y2), 2)); }//Вычисление расстояния до точки с указанными координатами

        /// <summary>Возвращает расстояние от ранее заданной 2D точки до 2D точки, заданной указанными координатами</summary>
        /// <remarks>По умолчанию ранее заданная 2D точка имеет координаты (0; 0)</remarks>
        public double PointDistantion(Point2D Point) { return Math.Sqrt(Math.Pow((PointCalcVar2D.X - Point.X), 2) + Math.Pow((PointCalcVar2D.Y - Point.Y), 2)); }//Вычисление расстояния до указанной точки

        /// <summary>Возвращает расстояние от первой 2D точки до второй 2D точки</summary>
        /// <remarks></remarks>
        public double PointDistantion(Point2D Point1, Point2D Point2) { double d; d = Math.Pow((Point1.X - Point2.X), 2) + Math.Pow((Point1.Y - Point2.Y), 2); return Math.Sqrt(d); }

        //-------------------- Расчет расстояния между двумя 3D точками -----------------------

        /// <summary>Возвращает расстояние от ранее заданной 3D точки до 3D точки, заданной указанными координатами</summary>
        /// <remarks>По умолчанию ранее заданная 3D точка имеет координаты (0; 0; 0)</remarks>
        public double PointDistantion(double X, double Y, double Z) { return Math.Sqrt(Math.Pow((PointCalcVar3D.X - X), 2) + Math.Pow((PointCalcVar3D.Y - Y), 2) + Math.Pow((PointCalcVar3D.Z - Z), 2)); }//Вычисление расстояния до 3D точки с указанными координатами

        /// <summary>Возвращает расстояние от ранее заданной 3D точки до 3D точки, заданной указанными координатами</summary>
        /// <remarks>По умолчанию ранее заданная 3D точка имеет координаты (0; 0; 0)</remarks>
        public double PointDistantion(double X1, double Y1, double Z1, double X2, double Y2, double Z2) { return Math.Sqrt(Math.Pow((X1 - X2), 2) + Math.Pow((Y1 - Y2), 2) + Math.Pow((Z1 - Z2), 2)); } //Вычисление расстояния до 3D точки с указанными координатами

        /// <summary>Возвращает расстояние от ранее заданной 3D точки до указанной 3D точки</summary>
        /// <remarks>По умолчанию ранее заданная 3D точка имеет координаты (0; 0; 0)</remarks>
        public double PointDistantion(Point3D pt) { return Math.Sqrt(Math.Pow((PointCalcVar3D.X - pt.X), 2) + Math.Pow((PointCalcVar3D.Y - pt.Y), 2) + Math.Pow((PointCalcVar3D.Z - pt.Z), 2)); }//Вычисление расстояния до указанной 3D точки

        /// <summary>Возвращает расстояние от первой 3D точки до второй 3D точки</summary>
        /// <remarks></remarks>
        public double PointDistantion(Point3D Point1, Point3D Point2) { double d; d = Math.Pow((Point1.X - Point2.X), 2) + Math.Pow((Point1.Y - Point2.Y), 2) + Math.Pow((Point1.Z - Point2.Z), 2); return Math.Sqrt(d); }//Вычисление расстояния до указанной 3D точки

        //-------------------- Расчет приращений координат между двумя 2D точками -----------------------

        /// <summary>Возвращает приращениe координаты X от первой 2D точки до второй 2D точки</summary>
        /// <remarks></remarks>
        public double PointDeltaX(Point2D Point1, Point2D Point2) { double PtDeltaX = (Point2.X - Point1.X); return PtDeltaX; }//Возвращает приращениe координаты X от первой 2D точки до второй 2D точки

        /// <summary>Возвращает приращениe координаты Y от первой 2D точки до второй 2D точки</summary>
        /// <remarks></remarks>
        public double PointDeltaY(Point2D Point1, Point2D Point2) { double PtDeltaY = (Point2.Y - Point1.Y); return PtDeltaY; }//Возвращает приращениe координаты Y от первой 2D точки до второй 2D точки

        /// <summary>Возвращает (по ссылке "ref") приращения координат X и Y от первой 2D точки до второй 2D точки</summary>
        /// <remarks></remarks>
        public void PointDelta(Point2D Point1, Point2D Point2, ref double Delta_X, ref double Delta_Y) { Delta_X = PointDeltaX(Point1, Point2); Delta_Y = PointDeltaY(Point1, Point2); }//Возвращает приращения координат X и Y от первой 2D точки до второй 2D точки

        //-------------------- Расчет приращений координат между двумя 3D точками -----------------------

        /// <summary>Возвращает приращениe координаты X от первой 3D точки до второй 3D точки</summary>
        /// <remarks></remarks>
        public double PointDeltaX(Point3D Point1, Point3D Point2) { double PtDeltaX = (Point2.X - Point1.X); return PtDeltaX; }//Возвращает приращениe координаты X от первой 2D точки до второй 2D точки

        /// <summary>Возвращает приращениe координаты Y от первой 2D точки до второй 3D точки</summary>
        /// <remarks></remarks>
        public double PointDeltaY(Point3D Point1, Point3D Point2) { double PtDeltaY = (Point2.Y - Point1.Y); return PtDeltaY; }//Возвращает приращениe координаты Y от первой 3D точки до второй 3D точки

        /// <summary>Возвращает приращениe координаты Z от первой 3D точки до второй 3D точки</summary>
        /// <remarks></remarks>
        public double PointDeltaZ(Point3D Point1, Point3D Point2) { double PtDeltaZ = (Point2.Z - Point1.Z); return PtDeltaZ; } //Возвращает приращениe координаты Z от первой 3D точки до второй 3D точки

        /// <summary>Возвращает (по ссылке "ref") приращения координат X и Y от первой 2D точки до второй 2D точки</summary>
        /// <remarks></remarks>
        public void PointDelta(Point2D Point1, Point2D Point2, ref double Delta_X, ref double Delta_Y, ref double Delta_Z) { Delta_X = PointDeltaX(Point1, Point2); Delta_Y = PointDeltaY(Point1, Point2); Delta_Z = 0; }

        /// <summary>Возвращает (по ссылке "ref") приращения координат X и Y от первой 3D точки до второй 3D точки</summary>
        /// <remarks></remarks>
        public void PointDelta(Point3D Point1, Point3D Point2, ref double Delta_X, ref double Delta_Y, ref double Delta_Z) { Delta_X = PointDeltaX(Point1, Point2); Delta_Y = PointDeltaY(Point1, Point2); Delta_Z = PointDeltaZ(Point1, Point2); }


    }
}