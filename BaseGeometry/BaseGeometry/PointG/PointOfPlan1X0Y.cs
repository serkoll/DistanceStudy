using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeomObjects.Points
{
    /// <summary>Класс для расчета параметров проекции 3D точки на X0Y плоскость проекций</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class PointOfPlan1X0Y
    {
        private PointDraw PointDraw_Var = new PointDraw();
        //private double Xcls;private double Ycls;
        private Point2D Point2D_Var = new Point2D(); //Точность расчетов
        //====================================================================================================
        //================== Методы ввода-вывода (расчета) параметров двумерной проекции точки по заданным условиям ==================

        /// <summary>Инициализация нового экземпляра двумерной проекции точки</summary>
        /// <remarks>Исходные координаты точки: X=0; Y=0</remarks>
        public PointOfPlan1X0Y() { this.X = 0; this.Y = 0; }//Конструктор, устанавливающий исходные значения координат 2D точки

        /// <summary>Инициализирует новый экземпляр двумерной проекции точки с указанными координатами</summary>
        /// <remarks></remarks>
        public PointOfPlan1X0Y(double X, double Y) { this.X = X; this.Y = Y; }//Конструктор, устанавливающий пользовательские значения координат 2D точки

        /// <summary>Инициализирует новый экземпляр двумерной проекции точки</summary>
        /// <remarks></remarks>
        public PointOfPlan1X0Y(Points.PointOfPlan1X0Y pt) { this.X = pt.X; this.Y = pt.Y; }//Конструктор, устанавливающий пользовательские значения координат 2D точки

        /// <summary>Получает или задает координату X двумерной проекции точки</summary>
        /// <remarks></remarks>
        public double X { get; set; }// Свойство координаты X

        /// <summary>Получает или задает координату Y двумерной проекции точки</summary>
        /// <remarks></remarks>
        public double Y { get; set; }// Свойство координаты Y

        /// <summary>Получает или задает точность расчета двумерных проекций точек</summary>
        /// <remarks>Значение по умолчанию 0,001</remarks>
        public double SolveError
        {
            get { return this.Point2D_Var.SolveError; }
            set { this.Point2D_Var.SolveError = value; }
        }// Свойство значения точности расчета
        /// <summary>
        /// Получает или задает инструменты для отрисовки 3D точки
        /// </summary>
        public PointDraw Point3D_Draw { get { return this.PointDraw_Var; } set { this.PointDraw_Var = value; } }
        /// <summary>Передвигает ранее заданную двумерную проекцию точку
        /// (изменяет коодинаты на указанные величины по осям в 2D)</summary>
        /// <remarks>PointOfPlan1_X0Y.X += dx; PointOfPlan1_X0Y.Y += dy</remarks>
        public void PointMove(double dx, double dy) { this.X += dx; this.Y += dy; }//Конструктор перемещения на указанные величины по осям

        //-------------------- Задание  значений координат точки путем конвертирования текста и контроль соответсвия значению "Nothing" -----------------------

        /// <summary> Задает проекцию 3D точки в плоскости X0Z, двумя координатами, представленными в текстовом формате </summary>
        /// <remarks> При корректном задании значений параметров проекций возвращает значение перечислителя: 0 = "CoordinateValue.None"  </remarks>
        /// <param name="X_Text"> Значение первой координаты в формате "String"</param>
        /// <param name="Y_Text"> Значение второй координаты в формате "String"</param>
        /// <param name="ProectionError"> Значение перечислителя, указывающего индексы координат, для которых отсутствуют значения параметров</param>
        /// <returns> BaseGeometryYVP.GeomObjects.PointOfPlan1_X0Y; в случае отсутсвия значений параметров возвращает возвращает "Nothing" и номер перечислителя "CoordinateValue", указывающего индексы координат, для которых не заданы значения, т.е. имеющие строковое значение "Nothing"</returns>
        public GeomObjects.Points.PointOfPlan1X0Y PointByText(string X_Text, string Y_Text, Enum ProectionError)
        {//Контроль не заданных значений координат горизонтальной проекции точки//Возвращает метку, соответсвующую координатам, для которых значения координат соответсвуют значению "Nothing"
            ProectionError = GeomObjects.Points.PointsPositionControl.CoordinateValue.None;//Исходное значение нумератора
            //Контроль не заданных значений координат точки
            ProectionError = GeomObjects.Points.PointsPositionControl.CoordinateValue.None;//Исходное значение нумератора
            bool Xbool = false; bool Ybool = false;
            //Контроль наличия отрицательных координат
            if (X_Text == null) { Xbool = true; }
            if (Y_Text == null) { Ybool = true; }
            //Контроль меток для ввода наименований координат в комментарий
            if (Xbool & Ybool) { ProectionError = GeomObjects.Points.PointsPositionControl.CoordinateValue.XY; }
            else if (Xbool & Ybool == false) { ProectionError = GeomObjects.Points.PointsPositionControl.CoordinateValue.X; }
            else if (Xbool == false & Ybool) { ProectionError = GeomObjects.Points.PointsPositionControl.CoordinateValue.Y; }
            else { ProectionError = GeomObjects.Points.PointsPositionControl.CoordinateValue.None; GeomObjects.Points.PointOfPlan1X0Y Point2DByTextVar = new GeomObjects.Points.PointOfPlan1X0Y(Convert.ToDouble(X_Text), Convert.ToDouble(Y_Text)); return Point2DByTextVar; }//Точка для вывода//Значения координат заданы
            return null;
        }

        /// <summary>Конвертирует заданную проекцию точки на плоскость X0Y в GeomObjects.Point2D</summary>
        /// <param name="PointProjection">Заданная прекция точки</param>
        /// <remarks>PointOfPlan1_X0Y.X = Point2D.X; PointOfPlan1_X0Y.Z = Point2D.Y</remarks>
        public Point2D CnvPoint2D(PointOfPlan1X0Y PointProjection) { Points.Point2D PointCalc = new Points.Point2D(PointProjection.X, PointProjection.Y); return PointCalc; }//Конструктор перемещения на указанные величины по осям


    }
}
