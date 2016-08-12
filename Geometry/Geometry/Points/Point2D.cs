using System;

namespace GeometryObjects
{
    //<summary>Класс для расчета параметров 2D точки</summary>
    //<remarks>Copyright © Polozkov V. Yury 2015</remarks>
    public class Point2D
    {
        //====================================================================================================
        //================== Методы ввода-вывода (расчета) параметров точки по заданным условиям ==================

        /// <summary>Инициализирует новый экземпляр 2D точки</summary>
        /// <remarks>Исходные координаты точки: X=0; Y=0</remarks>
        public Point2D() { X = 0; Y = 0; SolveError = 0.001; }//Конструктор, устанавливающий исходные значения координат 2D точки

        /// <summary>Инициализирует новый экземпляр 2D точки с указанными координатами</summary>
        /// <remarks></remarks>
        public Point2D(double X, double Y) { this.X = X; this.Y = Y; SolveError = 0.001; }

        /// <summary>Инициализирует новый экземпляр 2D точки</summary>
        /// <remarks></remarks>
        public Point2D(Point2D pt) { X = pt.X; Y = pt.Y; SolveError = 0.001; }//Конструктор, устанавливающий пользовательские значения координат 2D точки

        /// <summary>Получает или задает координату X точки</summary>
        /// <remarks></remarks>
        public double X { get; set; }

        /// <summary>Получает или задает координату Y точки</summary>
        /// <remarks></remarks>
        public double Y { get; set; }

        ///// <summary>Получает или задает точность расчета точек</summary>
        ///// <remarks>Значение по умолчанию 0,001</remarks>
        public double SolveError { get; set; }
        /// <summary>Передвигает ранее заданную 2D точку (изменяет коодинаты на указанные величины по осям в 2D)</summary>
        /// <remarks>Point3D.X += dx; Point3D.Y += dy</remarks>
        public void PointMove(double dx, double dy) { X += dx; Y += dy; }//Конструктор перемещения на указанные величины по осям //MyClass.Ptcls.X += dx : MyClass.Ptcls.Y += dy

        //-------------------- Задание  значений координат точки путем конвертирования текста и контроль соответсвия значению "Nothing" -----------------------

        /// <summary> Задает 2D точку, двумя координатами, представленными в текстовом формате </summary>
        /// <remarks> При корректном задании значений параметров проекций возвращает значение перечислителя: 0 = "CoordinateValue.None"  </remarks>
        /// <param name="XText"> Значение первой координаты в формате "String"</param>
        /// <param name="YText"> Значение второй координаты в формате "String"</param>
        /// <param name="ProectionError"> Значение перечислителя, указывающего индексы координат, для которых отсутствуют значения параметров</param>
        /// <returns> BaseGeometryYVP.GeomObjects.Point2D; в случае отсутсвия значений параметров возвращает возвращает "Nothing" и номер перечислителя "CoordinateValue", указывающего индексы координат, для которых не заданы значения, т.е. имеющие строковое значение "Nothing"</returns>
        public Point2D PointByText(string XText, string YText, ref Enum ProectionError)
        {  //Возвращает метку, соответсвующую координатам, для которых значения координат соответсвуют значению "Nothing"
            ProectionError = PointsPositionControl.CoordinateValue.None;//Исходное значение нумератора
            bool Xbool = false; bool Ybool = false;
            //Контроль не заданных значений координат точки
            if (XText == null) { Xbool = true; }
            if (YText == null) { Ybool = true; }
            //Контроль меток для ввода наименований координат в комментарий
            if (Xbool & Ybool) { ProectionError = PointsPositionControl.CoordinateValue.XY; }
            else if (Xbool & Ybool == false) { ProectionError = PointsPositionControl.CoordinateValue.X; }
            else if (Xbool == false & Ybool) { ProectionError = PointsPositionControl.CoordinateValue.Y; }//Значения координат заданы
            else
            {
                ProectionError = PointsPositionControl.CoordinateValue.None;
                Point2D Point2DByTextVar = new Point2D(Convert.ToDouble(XText), Convert.ToDouble(YText)); return Point2DByTextVar;
            }//Точка для вывода
            return null;
        }
    }
}
