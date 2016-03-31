using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace GeomObjects.Lines
{
    /// <summary>Класс для расчета параметров проекции 3D линии на X0Z плоскость проекций</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class LineOfPlan2X0Z
    {
        // = Nothing
        private LineDraw LineDraw_Cls = new LineDraw();

        //Базовая точка прямой
        private GeomObjects.Points.PointOfPlan2X0Z Point_0_Cls = new GeomObjects.Points.PointOfPlan2X0Z();
        //Вторая точка прямой
        private GeomObjects.Points.PointOfPlan2X0Z Point_1_Cls = new GeomObjects.Points.PointOfPlan2X0Z();

        //Для задания точности расчетов
        private GeomObjects.Lines.Line2D Line2D_Cls = new GeomObjects.Lines.Line2D();

        //====================================================================================================
        //================== Конструкторы инициализации параметров двумерной проекции прямой по заданным условиям ==================

        /// <summary>Инициализация нового экземпляра двумерной проекции точки</summary>
        /// <remarks></remarks>
        public LineOfPlan2X0Z()
        {
            //Конструктор, устанавливающий исходные значения базовой и второй точек линии
        }

        /// <summary>Инициализирует новый экземпляр двумерной проекции прямой по заданным проекциям базовой и второй точек</summary>
        /// <remarks></remarks>
        public LineOfPlan2X0Z(GeomObjects.Points.Point3D Point_0, GeomObjects.Points.Point3D Point_1)
        {
            this.Point_0.X = Point_0.X;
            this.Point_0.Z = Point_0.Z;
            this.Point_1.X = Point_1.X;
            this.Point_1.Z = Point_1.Z;
        }

        /// <summary>Инициализирует новый экземпляр двумерной проекции прямой по заданным проекциям базовой и второй точек</summary>
        /// <remarks></remarks>
        public LineOfPlan2X0Z(GeomObjects.Points.PointOfPlan2X0Z Point_0, GeomObjects.Points.PointOfPlan2X0Z Point_1)
        {
            this.Point_0 = Point_0;
            this.Point_1 = Point_1;
        }

        /// <summary>Инициализирует новый экземпляр двумерной проекции точки</summary>
        /// <remarks></remarks>
        public LineOfPlan2X0Z(GeomObjects.Lines.Line3D Line_Source)
        {
            this.Point_0.X = Line_Source.Point_0.X;
            this.Point_0.Z = Line_Source.Point_0.Z;
            this.Point_1.X = Line_Source.Point_1.X;
            this.Point_1.Z = Line_Source.Point_1.Z;
        }

        /// <summary>Получает или задает проекцию базовой точки прямой</summary>
        /// <remarks></remarks>
        public GeomObjects.Points.PointOfPlan2X0Z Point_0
        {
            // Считывание значения X
            get { return this.Point_0_Cls; }
            set { this.Point_0_Cls = value; }
        }

        /// <summary>Получает или задает проекцию второй точки прямой</summary>
        /// <remarks></remarks>
        public GeomObjects.Points.PointOfPlan2X0Z Point_1
        {
            // Считывание значения X
            get { return this.Point_1_Cls; }
            set { this.Point_1_Cls = value; }
        }

        /// <summary>Получает или задает точность расчета двумерных проекций прямых</summary>
        /// <remarks>Значение по умолчанию 0,001</remarks>
        public double SolveError
        {
            // Свойство значения точности расчета
            // Считывание значения точности расчета
            get { return this.Line2D_Cls.SolveError; }
            // Установка значения точности расчета
            set { this.Line2D_Cls.SolveError = value; }
        }

        /// <summary>
        /// Получает или задает инструменты для отрисовки прямой
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public GeomObjects.Lines.LineDraw Line_Draw
        {
            //Считывание значений
            get { return this.LineDraw_Cls; }
            set { this.LineDraw_Cls = value; }
        }

        //====================================================================================================
        //================== Методы ввода-вывода (расчета) параметров двумерной проекции прямой по заданным условиям ==================

        /// <summary>Конвертирует заданную проекцию прямой на плоскость X0Y в GeomObjects.Line2D</summary>
        /// <param name="LineProjection">Заданная прекция прямой</param>
        /// <remarks></remarks>
        public GeomObjects.Lines.Line2D CnvLine2D(LineOfPlan2X0Z LineProjection)
        {
            GeomObjects.Lines.Line2D LineCalc = new GeomObjects.Lines.Line2D(Point_0_Cls.CnvPoint2D(LineProjection.Point_0), Point_1_Cls.CnvPoint2D(LineProjection.Point_1));
            return LineCalc;
        }


    }
}