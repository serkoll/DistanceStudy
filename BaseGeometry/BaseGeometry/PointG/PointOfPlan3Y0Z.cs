using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeomObjects.Points
{
    /// <summary>Класс для расчета параметров проекции 3D точки на Y0Z плоскость проекций</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2013</remarks>
    public class PointOfPlan3Y0Z
    {
        private PointDraw PointDraw_Var = new PointDraw();

        private Point2D SolveErrorPtcls = new Points.Point2D();//Точность расчетов

        //====================================================================================================
        //================== Методы ввода-вывода (расчета) параметров двумерной проекции точки по заданным условиям ==================

        /// <summary>Инициализация нового экземпляра двумерной проекции точки</summary>
        /// <remarks>Исходные координаты точки: Y=0; Z=0</remarks>
        public PointOfPlan3Y0Z() { this.Y = 0; this.Z = 0; }//Конструктор, устанавливающий исходные значения координат двумерной проекции точки

        /// <summary>Инициализирует новый экземпляр двумерной проекции точки с указанными координатами</summary>
        /// <remarks></remarks>
        public PointOfPlan3Y0Z(double Y, double Z) { this.Y = Y; this.Z = Z; }//Конструктор, устанавливающий пользовательские значения координат 2D точки

        /// <summary>Инициализирует новый экземпляр двумерной проекции точки</summary>
        /// <remarks></remarks>
        public PointOfPlan3Y0Z(Points.PointOfPlan3Y0Z pt) { this.Y = pt.Y; this.Z = pt.Z; }//Конструктор, устанавливающий пользовательские значения координат 2D точки

        /// <summary>Получает или задает координату Y двумерной проекции точки</summary>
        /// <remarks></remarks>
        public double Y { get; set; }

        /// <summary>Получает или задает координату Z двумерной проекции точки</summary>
        /// <remarks></remarks>
        public double Z { get; set; }
        /// <summary>
        /// Получает или задает инструменты для отрисовки 3D точки
        /// </summary>
        public PointDraw Point3D_Draw { get { return this.PointDraw_Var; } set { this.PointDraw_Var = value; } }
        /// <summary>Получает или задает точность расчета двумерных проекций точек</summary>
        /// <remarks>Значение по умолчанию 0,001</remarks>
        /// <summary>Получает или задает точность расчета двумерных проекций точек</summary>
        /// <remarks>Значение по умолчанию 0,001</remarks>
        public double SolveError
        {
            get { return this.SolveErrorPtcls.SolveError; }
            set { this.SolveErrorPtcls.SolveError = value; }
        } // Свойство значения точности расчета



        /// <summary>Передвигает ранее заданную двумерную проекцию точку
        /// (изменяет коодинаты на указанные величины по осям в 2D)
        /// </summary>
        /// <remarks>PointOfPlan3_Y0Z.Y += dy; PointOfPlan3_Y0Z.Z += dz</remarks>
        public void PointMove(double dy, double dz) { this.Y += dy; this.Z += dz; }//Конструктор перемещения на указанные величины по осям

        //-------------------- Задание  значений координат точки путем конвертирования текста и контроль соответсвия значению "Nothing" -----------------------

        /// <summary> Задает проекцию 3D точки в плоскости Y0Z, двумя координатами, представленными в текстовом формате </summary>
        /// <remarks> При корректном задании значений параметров проекций возвращает значение перечислителя: 0 = "CoordinateValue.None"  </remarks>
        /// <param name="Y_Text"> Значение первой координаты в формате "String"</param>
        /// <param name="Z_Text"> Значение второй координаты в формате "String"</param>
        /// <param name="ProectionError"> Значение перечислителя, указывающего индексы координат, для которых отсутствуют значения параметров</param>
        /// <returns> BaseGeometryYVP.GeomObjects.PointOfPlan2_Y0Z; в случае отсутсвия значений параметров возвращает возвращает "Nothing" и номер перечислителя "CoordinateValue", указывающего индексы координат, для которых не заданы значения, т.е. имеющие строковое значение "Nothing"</returns>
        public GeomObjects.Points.PointOfPlan3Y0Z PointByText(string Y_Text, string Z_Text, Enum ProectionError)
        {//Контроль не заданных значений координат горизонтальной проекции точки //Возвращает метку, соответсвующую координатам, для которых значения координат соответсвуют значению "Nothing"
            ProectionError = GeomObjects.Points.PointsPositionControl.CoordinateValue.None; //Исходное значение нумератора
            //Контроль не заданных значений координат точки
            ProectionError = PointsPositionControl.CoordinateValue.None;//Исходное значение нумератора
            bool Ybool = false, Zbool = false;
            //Контроль наличия отрицательных координат
            if (Y_Text == null) { Ybool = true; }
            if (Z_Text == null) { Zbool = true; }
            //Контроль меток для ввода наименований координат в комментарий
            if (Ybool & Zbool) { ProectionError = GeomObjects.Points.PointsPositionControl.CoordinateValue.YZ; }
            else if (Ybool & Zbool == false) { ProectionError = GeomObjects.Points.PointsPositionControl.CoordinateValue.Y; }
            else if (Ybool == false & Zbool) { ProectionError = GeomObjects.Points.PointsPositionControl.CoordinateValue.Z; }
            else { ProectionError = GeomObjects.Points.PointsPositionControl.CoordinateValue.None; GeomObjects.Points.PointOfPlan3Y0Z Point2DByTextVar = new GeomObjects.Points.PointOfPlan3Y0Z(Convert.ToDouble(Y_Text), Convert.ToDouble(Z_Text)); return Point2DByTextVar; } //Значения координат заданы //Точка для вывода
            return null;
        }
        /// <summary>Конвертирует заданную проекцию точки на плоскость X0Z в GeomObjects.Point2D</summary>
        /// <remarks>PointOfPlan2_X0Z.X = Point2D.X; PointOfPlan2_X0Z.Z = Point2D.Y</remarks>
        public Points.Point2D CnvPoint2D(PointOfPlan3Y0Z PointProjection) { Points.Point2D PointCalc = new Points.Point2D(PointProjection.Y, PointProjection.Z); return PointCalc; }//Конструктор перемещения на указанные величины по осям
    }
}
