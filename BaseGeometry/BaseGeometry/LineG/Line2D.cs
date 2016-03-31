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
    /// <summary>Класс для задания и расчета параметров 2D прямой</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class Line2D
    {
        //Прямая на плоскости

        //Переменная для работы с расчетом прямых

        //Базовая точка прямой
        private GeomObjects.Points.Point2D Point_0_Cls = new GeomObjects.Points.Point2D();
        //Вторая (расчетная или заданная) точка прямой
        private GeomObjects.Points.Point2D Point_1_Cls = new GeomObjects.Points.Point2D();

        private double kx_Cls;
        //Постоянные коэффициенты канонического уравнения 3D прямой
        private double ky_Cls;
        //Точность расчетов
        private double SolveErrorLine_Cls = 0.001;

        //====================================================================================================
        //================== Свойства задания и извлечения параметров 2D линии ==================================

        /// <summary>Получает или задает базовую 2D точку прямой</summary>
        /// <remarks></remarks>
        public GeomObjects.Points.Point2D Point_0
        {
            // Свойство базовой точки
            // Считывание значения базовой точки
            get { return this.Point_0_Cls; }
            // Установка значения базовой точки
            set { this.Point_0_Cls = value; }
        }

        /// <summary>Получает или задает вторую 2D точку прямой</summary>
        /// <remarks></remarks>
        public GeomObjects.Points.Point2D Point_1
        {
            // Свойство второй точки
            // Считывание значения базовой точки
            get { return this.Point_1_Cls; }
            // Установка значения второй точки
            set { this.Point_1_Cls = value; }
        }

        /// <summary>Получает или задает коэффициент kx канонического уравнения прямой</summary>
        /// <remarks></remarks>
        public double kx
        {
            // Свойство коэффициента kx
            //Считывание значения коэффициента kx
            get { return this.kx_Cls; }
            // Установка коэффициента kx
            set { this.kx_Cls = value; }
        }

        /// <summary>Получает или задает коэффициент ky канонического уравнения прямой</summary>
        /// <remarks></remarks>
        public double ky
        {
            // Свойство коэффициента ky
            //Считывание значения коэффициента ky
            get { return this.ky_Cls; }
            // Установка коэффициента kx
            set { this.ky_Cls = value; }
        }

        /// <summary>Получает или задает точность расчета линий</summary>
        /// <remarks>Значение по умолчанию 0,001</remarks>
        public double SolveError
        {
            // Свойство значения точности расчета
            // Считывание значения точности расчета
            get { return this.SolveErrorLine_Cls; }
            // Установка значения точности расчета
            set { this.SolveErrorLine_Cls = value; }
        }

        /// <summary>
        /// Возвращает значения координат 2D точки, инцидентной ранее заданной 2D прямой по параметру t 
        /// </summary>
        /// <param name="t">Параметр, определяющий удаление новой точки от базовой точки прямой</param>
        /// <value></value>
        /// <remarks>Расчетные формулы координат новой точки: X = Point_0.X + kx * t; Y = Point_0.Y + ky * t.</remarks>
        public GeomObjects.Points.Point2D GetPoint1(double t)
        {
            //Свойство, возвращающее координаты 2D точки на 2D прямой по параметру t 
            return (new GeomObjects.Points.Point2D(Point_0.X + kx * t, Point_0.Y + ky * t));
        }

        //====================================================================================================
        //================== Конструкторы ввода-вывода (расчета) параметров линии по заданным условиям ==================

        /// <summary>Инициализация нового экземпляра 2D прямой</summary>
        /// <remarks>Исходные координаты базовой точки прямой равны нулю.
        /// Исходные коэффициенты канонического уравнения прямой: kx=1; ky=0.
        /// </remarks>
        public Line2D()
        {
            //Конструктор возвращает 2D опорную точку (заданной координатами) 2D прямой линии
            this.Point_0.X = 0;
            this.Point_0.Y = 0;
            this.Point_1.X = 1;
            this.Point_1.Y = 0;
            this.kx = 1;
            this.ky = 0;
        }

        /// <summary>
        /// Инициализирует новый экземпляр 2D прямой с помощью задания опорной точки и значений коэффициентов канонического уравнения
        /// </summary>
        /// <param name="BasePointLine">Опорная точка прямой</param>
        /// <param name="Line_kx">Первый коэффициент канонического уравнения прямой</param>
        /// <param name="Line_ky">Второй коэффициент канонического уравнения прямой</param>
        /// <remarks></remarks>
        public Line2D(GeomObjects.Points.Point2D BasePointLine, double Line_kx, double Line_ky)
        {
            //Конструктор возвращает 2D опорную точку (заданной координатами) 2D прямой линии и коэффициенты этой прямой
            if (LinesControl.LineTrue(this.kx, this.ky) == false)
            {
                Interaction.MsgBox("Не удается построить прямую по заданной точке и двум коэффициентам прямой." + Constants.vbCrLf + "Заданная точка не принадлежит прямой или не верно заданы коэффициенты прямой.", MsgBoxStyle.Critical, "Задание 2D прямой с помощью опорной точки и двум коэффициентам");
                this.Point_0 = null;
                this.Point_1 = null;
                //this.kx = 1 / 0;
                //this.ky = 1 / 0;
                //MyClass.LineNothing()
            }
            else
            {
                this.Point_0.X = BasePointLine.X;
                this.Point_0.Y = BasePointLine.Y;
                this.kx = Line_kx;
                this.ky = Line_ky;
                this.Point_1.X = this.kx + this.Point_0.X;
                this.Point_1.Y = this.ky + this.Point_0.Y;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр 2D прямой с помощью задания двух точек
        /// </summary>
        /// <param name="Point1">Первая (опорная) точка прямой</param>
        /// <param name="Point2">Вторая точка прямой</param>
        /// <remarks>Рассчитывает значения постоянных коэффициентов 2D прямой, заданной двумя 2D точками.
        /// Первая заданная точка записывается в качестве опорной точки прямой.
        /// </remarks>
        public Line2D(GeomObjects.Points.Point2D Point1, GeomObjects.Points.Point2D Point2)
        {
            //Конструктор рассчитывает значения постоянных коэффициентов 2D прямой, заданной двумя 2D точками 
            Points.PointsPositionControl PointVar = new Points.PointsPositionControl();
            //Контроль совпадения заданных точек
            if (PointVar.PointsIsPoints(Point1, Point2) == true)
            {
                Interaction.MsgBox("Не удается построить прямую по двум точкам." + Constants.vbCrLf + "Заданные точки совпадают.", MsgBoxStyle.Critical, "Построение 2D прямой по двум заданным 2D точкам");
                //Point_0 = Nothing : kx = Nothing : ky = Nothing
                this.LineNon();
                return;
            }
            //if (LinesControl.LineTrue(this.kx, this.ky) == false)
            //{
            //    Interaction.MsgBox("Ошибка построения прямой линии." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Построение 2D прямой по двум заданным 2D точкам");
            //    this.LineNon();
            //}
            else
            {
                this.Point_0 = Point1;
                this.Point_1 = Point2;
                this.kx = Point2.X - Point1.X;
                this.ky = Point2.Y - Point1.Y;
            }
        }

        //====================================================================================================
        //================== Методы ввода-вывода (расчета) параметров линии по заданным условиям ==================

        /// <summary>
        /// Устанавливает значение "Неизвестно" всем параметрам классов Line2D и Line3D
        /// </summary>
        /// <remarks>Используется для отработки ошибок</remarks>
        protected void LineNon()
        {
            //Конструктор устанавливает значение "Неизвестно" параметрам класса Line3D
            //Используется для отработки ошибок
            //this.Point_0.X = 1 / 0;
            //this.Point_0.Y = 1 / 0;
            //this.Point_1.X = 1 / 0;
            //this.Point_1.Y = 1 / 0;
            //this.kx = 1 / 0;
            //this.ky = 1 / 0;
        }

        /// <summary>
        /// Рассчитывает значения постоянных коэффициентов 2D прямой, заданной двумя 2D точками
        /// </summary>
        /// <param name="Point1">Первая (опорная) точка прямой</param>
        /// <param name="Point2">Вторая точка прямой</param>
        /// <remarks>Рассчитывает значения постоянных коэффициентов 2D прямой, заданной двумя 2D точками.
        /// Первая заданная точка записывается в качестве опорной точки прямой.
        /// </remarks>
        public void LineBy2Points(GeomObjects.Points.Point2D Point1, GeomObjects.Points.Point2D Point2)
        {
            //Конструктор рассчитывает значения постоянных коэффициентов 2D прямой, заданной двумя 2D точками 
            Line2D Line2DNew = new Line2D(Point1, Point2);
            this.Point_0 = Line2DNew.Point_0;
            //Начальная точка прямой
            this.Point_1 = Line2DNew.Point_1;
            //Вторая точка прямой
            //Коэффициенты уравнения общего вида прямой
            this.kx = Line2DNew.kx;
            this.ky = Line2DNew.ky;
            //'Коэффициенты уравнения общего вида прямой
            //'-------------- ????? ------------
            //'MyClass.A = Line3DNew.A : MyClass.B = Line3DNew.B 
        }

        //Public Sub LineCalc(ByVal Point1 As BaseGeometryYVP.GeomObjects.Points.Point2D, ByVal Point2 As BaseGeometryYVP.GeomObjects.Points.Point2D, _
        //                       ByRef A As Double, ByRef B As Double)
        //    'Конструктор возвращает значения постоянных коэффициентов 2D прямой по двум 2D точкам
        //    Dim PointVar As New BaseGeometryYVP.GeomObjects.Points.Point2D
        //    'Контроль совпадения заданных точек
        //    If PointVar.PointsIsPoints(Point1, Point2) = True Then
        //        MsgBox("Не удается построить прямую по двум точкам." & vbCrLf & _
        //               "Заданные точки совпадают.", MsgBoxStyle.Critical, "Построение 2D прямой по двум заданным 2D точкам")
        //        MyClass.LineNon()
        //        A = Nothing : B = Nothing
        //        Exit Sub
        //    End If
        //    A = (Point1.y - Point2.y) / _
        //       (Point1.x * Point2.y - Point2.x * Point1.y)

        //    B = (Point2.x - Point1.x) / _
        //       (Point1.x * Point2.y - Point2.x * Point1.y)
        //    Point_0 = Point1
        //End Sub


        //Public Overloads ReadOnly Property GetPoint(ByVal x As Double, ByVal isAxis As Boolean) As BaseGeometryYVP.GeomObjects.Points.Point2D
        //Свойство, возвращающее координаты 2D точки на 2D прямой по ?????
        //    Get
        //        Dim t As Double
        //        t = (x - Point0.x) / kx
        //        Return (New BaseGeometryYVP.GeomObjects.Points.Point2D(Point0.x + kx * t, Point0.y + ky * t))
        //    End Get
        //End Property

        //Public Overloads ReadOnly Property GetLine(ByVal t As Double) As Line2D
        //    'Свойство, возвращающее базовую точку и коэффициенты 2D линии по заданным значениям
        //    Get
        //        Return (New Point3D(Point_0.x + kx * t, Point_0.y + ky * t, Point_0.z + kz * t))
        //    End Get
        //End Property

        /// <summary>
        /// Задает перпендикуляр из указанной 2D точки к указанной 2D прямой
        /// </summary>
        /// <param name="Line">2D прямая, к которой строится перпендикуляр</param>
        /// <param name="Point">2D точка, из которой выставляется перепендикуляр</param>
        /// <remarks></remarks>
        public void PerpendicularPointToLine(Line2D Line, GeomObjects.Points.Point2D Point)
        {
            //Конструктор задает перпендикуляр из 2D точки к 2D прямой
            //Dim LineErr As New LineErrors
            //Контроль корректности задания прямой
            if (LinesControl.LineTrue(Line) == false)
            {
                Interaction.MsgBox("Ошибка задания прямой линии." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Задание перпендикуляра из 2D точки к 2D прямой");
                //Point_0 = Nothing : kx = Nothing : ky = Nothing
                this.LineNon();
            }
            else
            {
                this.Point_0 = Point;
                this.kx = Line.ky;
                this.ky = -Line.kx;
                this.Point_1.X = this.kx + this.Point_0.X;
                this.Point_1.Y = this.ky + this.Point_0.Y;
            }
        }

        /// <summary>
        /// Задает 2D прямую, параллельную указанной 2D прямой и проходящую через указанную 2D точку
        /// </summary>
        /// <param name="Line">Заданная 2D прямая</param>
        /// <param name="Point">2D точка, через которую должна проходить параллельная прямая</param>
        /// <remarks></remarks>
        public void ParallelPointToLine(Line2D Line, GeomObjects.Points.Point2D Point)
        {
            //Конструктор задает параллельную прямую через 2D точку к 2D прямой
            //Dim LineErr As New LineErrors
            //Контроль корректности задания прямой
            if (LinesControl.LineTrue(Line) == false)
            {
                Interaction.MsgBox("Ошибка задания прямой линии." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Задание параллельной прямой через 2D точку к 2D прямой");
                //Point_0 = Nothing : kx = Nothing : ky = Nothing
                this.LineNon();
            }
            else
            {
                this.Point_0 = Point;
                this.kx = Line.kx;
                this.ky = Line.ky;
                this.Point_1.X = this.kx + this.Point_0.X;
                this.Point_1.Y = this.ky + this.Point_0.Y;
            }
        }

        //====================================================================================================
        //================== Функции расчета параметров 2D линии по заданным условиям ==================

        /// <summary>
        /// Функция расчета значения углового коэффициента 2D прямой
        /// </summary>
        /// <param name="Line">Заданная 2D прямая</param>
        /// <returns>Возвращает значение углового коэффициента 2D прямой</returns>
        /// <remarks></remarks>
        public double? SlopeDirectLine(Line2D Line)
        {
            //Функция возвращает значение углового коэффициента 2D прямой
            double? k = 0;
            //Dim LineErr As New LineErrors
            //Контроль корректности задания прямой
            if (LinesControl.LineTrue(Line) == false)
            {
                Interaction.MsgBox("Ошибка задания прямой линии." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Расчет углового коэффициента 2D прямой");
                k = null;
                return k;
            }
            k = Line.ky / Line.kx;
            return k;
        }

    }
}
