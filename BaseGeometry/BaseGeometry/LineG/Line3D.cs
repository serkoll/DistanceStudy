using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualBasic;
using GeomObjects.Points;
using GeomObjects.Plans;
using GeomObjects.Lines;
using GeomObjects.EquationsSysCalc;

namespace GeomObjects.Lines
{
    /// <summary>Класс для задания и расчета параметров 3D прямой</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    //Прямая в пространстве
    public class Line3D : Line2D
    {
        // = Nothing
        private GeomObjects.Lines.LineDraw LineDraw_Cls = new GeomObjects.Lines.LineDraw();


        private GeomObjects.Points.Point3D Point_0_Cls = new GeomObjects.Points.Point3D();

        private GeomObjects.Points.Point3D Point_1_Cls = new GeomObjects.Points.Point3D();
        //Постоянный коэффициент канонического уравнения 3D прямой
        private double kz_Cls;
        //Private Shadows SolveErrorLine_Cls As Double = 0.001 'Точность расчетов

        //====================================================================================================
        //================== Свойства задания и извлечения параметров 3D линии ==================================

        /// <summary>Получает или задает коэффициент kz канонического уравнения прямой</summary>
        /// <remarks></remarks>
        public double kz
        {
            // Свойство коэффициента kz
            //Считывание значения коэффициента kz
            get { return this.kz_Cls; }
            // Установка коэффициента kz
            set { this.kz_Cls = value; }
        }

        /// <summary>Получает или задает базовую 3D точку прямой</summary>
        /// <remarks></remarks>
        public GeomObjects.Points.Point3D Point_0
        {
            // Свойство базовой точки
            // Считывание значения базовой точки
            get { return this.Point_0_Cls; }
            // Установка значения базовой точки
            set { this.Point_0_Cls = value; }
        }

        /// <summary>Получает или задает вторую 3D точку прямой</summary>
        /// <remarks></remarks>
        public GeomObjects.Points.Point3D Point_1
        {
            // Свойство второй точки
            // Считывание значения базовой точки
            get { return this.Point_1_Cls; }
            // Установка значения второй точки
            set { this.Point_1_Cls = value; }
        }

        /// <summary>Получает или задает точность расчета линий</summary>
        /// <remarks>Значение по умолчанию 0,001</remarks>
        public double SolveError
        {
            // Свойство значения точности расчета
            // Считывание значения точности расчета
            get { return base.SolveError; }
            // Установка значения точности расчета
            set { base.SolveError = value; }
        }

        /// <summary>
        /// Получает 3D точки, инцидентной инцидентной ранее заданной 3D прямой по параметру t
        /// </summary>
        /// <param name="t">Параметр, определяющий удаление новой точки от базовой точки прямой</param>
        /// <value></value>
        /// <returns></returns>
        /// <remarks>Расчетные формулы координат новой точки: X = Point_0.X + kx * t; Y = Point_0.Y + ky * t; Z = Point_0.Z + kz * t.</remarks>
        public GeomObjects.Points.Point3D GetPoint(double t)
        {
            //Свойство, возвращающее координаты 3D точки на 3D прямой по параметру t 
            return (new GeomObjects.Points.Point3D(this.Point_0.X + this.kx * t, this.Point_0.Y + this.ky * t, this.Point_0.Z + this.kz * t));
        }

        //Public Overloads ReadOnly Property GetPoint(ByVal X As Double, ByVal isAxis As Boolean) As Point3D
        //    'Свойство, возвращающее координаты 3D точки на 3D прямой по ?????
        //    Get
        //        Dim t As Double
        //        t = (X - Point_0.X) / MyClass.kx
        //        Return (New BaseGeometryYVP.GeomObjects.Points.Point3D(Point_0.X + MyClass.kx * t, Point_0.Y + MyClass.ky * t, Point_0.Z + MyClass.kz * t))
        //    End Get
        //End Property

        /// <summary>
        /// Получает значение параметра t заданной прямой, вычисляемого от базовой до указанной точки прямой
        /// </summary>
        /// <param name="Point">Заданная точка, инцидентная заданной прямой</param>
        /// <param name="Line">Заданная прямая</param>
        /// <value></value>
        /// <returns>Возвращает значение параметра t заданной прямой, вычисляемого от базовой до указанной точки прямой.</returns>
        /// <remarks></remarks>
        public double? GetLine_t(Points.Point3D Point, Line3D Line)
        {
            //Свойство, возвращающее значение параметра t заданной прямой, вычисляемого от базовой до указанной точки прямой 
            double t = 0;
            //Dim LineErr As New LineErrors  'Контроль корректности задания прямой
            if (LinesControl.LineTrue(Line) == false)
            {
                Interaction.MsgBox("Ошибка задания прямой линии." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Расчет параметра t прямой по заданной точке");
                this.LineNon();
                return null;
            }
            //Контроль корректности задания точки
            if (Point.X == Line.Point_0.X & Point.Y == Line.Point_0.Y & Point.Z == Line.Point_0.Z)
            {
                //MsgBox("Параметр t прямой равен 0, т.к.  заданная точка и базовая точка прямой совпадают.", _
                //       MsgBoxStyle.Exclamation, "Расчет параметра t прямой по заданной точке")
                return 0;
            }
            //Расчет
            if ((Point.X - Line.Point_0.X) != 0 & Line.kx != 0)
            {
                t = (Point.X - Line.Point_0.X) / Line.kx;
            }
            else if ((Point.Y - Line.Point_0.Y) != 0 & Line.ky != 0)
            {
                t = (Point.Y - Line.Point_0.Y) / Line.ky;
            }
            else if ((Point.Z - Line.Point_0.Z) != 0 & Line.kz != 0)
            {
                t = (Point.Z - Line.Point_0.Z) / Line.kz;
            }
            else
            {
                //Преобразуем систему параметричеких уравнений прямой x=a+mt и т.д. в уравнения вида: ax1+by1+cz1=0, т.е. ax1+my1-xz1=0
                //Решение системы трех уравнений (определение неизвестного y1, которое представляет собой параметр t)
                EquationsSysCalc.EqSysCalculation EqVar = new EquationsSysCalc.EqSysCalculation();
                double[,] SysEq = new double[3, 4];
                double[] RezEq = null;
                SysEq.SetValue(Line.Point_0.X, 0, 0);
                SysEq.SetValue(Line.kx, 0, 1);
                SysEq.SetValue(-Point.X, 0, 2);
                SysEq.SetValue(0, 0, 3);
                SysEq.SetValue(Line.Point_0.Y, 1, 0);
                SysEq.SetValue(Line.ky, 1, 1);
                SysEq.SetValue(-Point.Y, 1, 2);
                SysEq.SetValue(0, 1, 3);
                SysEq.SetValue(Line.Point_0.Z, 2, 0);
                SysEq.SetValue(Line.kz, 2, 1);
                SysEq.SetValue(-Point.Z, 2, 2);
                SysEq.SetValue(0, 2, 3);
                RezEq = EqVar.KramerEquationsSolution(SysEq);
                Interaction.MsgBox("Внимание! Расчет параметра t прямой проведен на основе" + Constants.vbCrLf + "решения системы трех уравнений с тремя неизвестными", MsgBoxStyle.Exclamation, "Расчет параметра t прямой по заданной точке");
                t = (double)RezEq.GetValue(1);
            }
            return t;
        }

        //Public Overloads ReadOnly Property GetLine(ByVal t As Double) As Line3D
        //    'Свойство, возвращающее базовую точку и коэффициенты 3D линии по заданным значениям
        //    Get
        //        Return (New BaseGeometryYVP.GeomObjects.Points.Point3D(Point_0.x + kx * t, Point_0.y + ky * t, Point_0.z + kz * t))
        //    End Get
        //End Property

        /// <summary>Получает или задает координаты проекции 3D прямой на плоскость X0Y пространственной системы координат</summary>
        /// <remarks></remarks>
        public LineOfPlan1X0Y LineOfPlan1_X0Y
        {
            // Свойство проекции 3D прямой на плоскость X0Y
            // Считывание значений
            get { return new LineOfPlan1X0Y(this.Point_0, this.Point_1); }
        }
        //Set(ByVal Line As GeomObjects.LineOfPlan1_X0Y)
        //    MyClass.Point_0 = Line.Point_0 : MyClass.Point_1 = Line.Point_1
        //End Set

        /// <summary>Получает или задает координаты проекции 3D прямой на плоскость X0Z пространственной системы координат</summary>
        /// <remarks></remarks>
        public Lines.LineOfPlan2X0Z LineOfPlan2_X0Z
        {
            // Свойство проекции 3D прямой на плоскость X0Z
            // Считывание значений
            get { return new Lines.LineOfPlan2X0Z(this.Point_0, this.Point_1); }
        }
        //Set(ByVal Line As GeomObjects.LineOfPlan2_X0Z)
        //    Dim Line_Var As New GeomObjects.PointOfPlan2_X0Z(Line.X, Line.Z)
        //End Set

        /// <summary>Получает или задает координаты проекции 3D прямой на плоскость Y0Z пространственной системы координат</summary>
        /// <remarks></remarks>
        public GeomObjects.Lines.LineOfPlan3Y0Z LineOfPlan3_Y0Z
        {
            // Свойство проекции 3D прямой на плоскость Y0Z
            // Считывание значений
            get { return new GeomObjects.Lines.LineOfPlan3Y0Z(this.Point_0, this.Point_1); }
        }
        //Set(ByVal Line As GeomObjects.LineOfPlan3_Y0Z)
        //    Dim Line_Var As New GeomObjects.PointOfPlan3_Y0Z(Line.Y, Line.Z)
        //End Set

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
        //================== Конструкторы ввода-вывода (расчета) параметров линии по заданным условиям ==================

        /// <summary>Инициализация нового экземпляра 2D прямой</summary>
        /// <remarks>Исходные координаты базовой точки прямой равны нулю.
        /// Исходные коэффициенты канонического уравнения прямой: kx=1; ky=0; kz=0.
        /// </remarks>
        public Line3D()
            : base()
        {
            //Конструктор устанавливает координаты 3D опорной точки (заданной координатами) 3D прямой линии
            //Point_0 = New BaseGeometryYVP.GeomObjects.Points.Point3D(0, 0, 0)
            this.Point_0.Z = 0;
            this.kz = 0;
            this.Point_1.X = this.kx + this.Point_0.X;
            this.Point_1.Y = this.ky + this.Point_0.Y;
            this.Point_1.Z = this.kz + this.Point_0.Z;
        }

        /// <summary>
        /// Инициализирует новый экземпляр 3D прямой с помощью задания опорной точки и значений коэффициентов канонического уравнения
        /// </summary>
        /// <param name="BasePointLine">Заданная опорная точка прямой</param>
        /// <param name="Line_kx">Первый коэффициент канонического уравнения прямой</param>
        /// <param name="Line_ky">Второй коэффициент канонического уравнения прямой</param>
        /// <param name="Line_kz">Третий коэффициент канонического уравнения прямой</param>
        /// <remarks></remarks>
        public Line3D(GeomObjects.Points.Point3D BasePointLine, double Line_kx, double Line_ky, double Line_kz)
        {
            //Конструктор задает 3D опорную точку (заданной координатами) 3D прямой линии и коэффициенты этой прямой
            //Контроль корректности задания прямой + Контроль принадлежности заданной базовой точки заданной прямой
            if (LinesControl.LineTrue(Line_kx, Line_ky, Line_kz) == false)
            {
                Interaction.MsgBox("Не удается построить прямую по заданной точке и трем коэффициентам прямой." + Constants.vbCrLf + "Заданная точка не принадлежит прямой или не верно заданы коэффициенты прямой.", MsgBoxStyle.Critical, "Задание 3D прямой с помощью опорной точки и трех коэффициентов");
                //MyClass.Point_0 = Nothing : MyClass.kx = Nothing : MyClass.ky = Nothing : MyClass.kz = Nothing
                this.LineNon();
            }
            else
            {
                this.Point_0.X = BasePointLine.X;
                this.Point_0.Y = BasePointLine.Y;
                this.Point_0.Z = BasePointLine.Z;
                this.kx = Line_kx;
                this.ky = Line_ky;
                this.kz = Line_kz;
                this.Point_1.X = this.kx + this.Point_0.X;
                this.Point_1.Y = this.ky + this.Point_0.Y;
                this.Point_1.Z = this.kz + this.Point_0.Z;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр 3D прямой с помощью задания двух точек
        /// </summary>
        /// <param name="Point1">Первая (опорная) точка прямой</param>
        /// <param name="Point2">Вторая точка прямой</param>
        /// <remarks>Рассчитывает значения постоянных коэффициентов 3D прямой, заданной двумя 3D точками.
        /// Первая заданная точка записывается в качестве опорной точки прямой.
        /// </remarks>
        public Line3D(GeomObjects.Points.Point3D Point1, GeomObjects.Points.Point3D Point2)
        {
            //Конструктор рассчитывает значения постоянных коэффициентов 3D прямой, заданной двумя 3D точками 
            Points.PointsPositionControl PointVar = new Points.PointsPositionControl();
            //Контроль совпадения заданных точек
            if (PointVar.PointsIsPoints(Point1, Point2) == true)
            {
                Interaction.MsgBox("Не удается построить прямую по двум точкам." + Constants.vbCrLf + "Заданные точки совпадают.", MsgBoxStyle.Critical, "Построение 3D прямой по двум заданным 3D точкам");
                //MyClass.Point_0 = Nothing : MyClass.kx = Nothing : MyClass.ky = Nothing : MyClass.kz = Nothing
                this.LineNon();
                return;
            }
            //Расчет и контроль кооректности коэффициентов канонического уравнения 3D прямой
            if (LinesControl.LineTrue(Point2.X - Point1.X, Point2.Y - Point1.Y, Point2.Z - Point1.Z) == false)
            {
                Interaction.MsgBox("Ошибка построения прямой линии." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Построение 3D прямой по двум заданным 3D точкам");
                this.LineNon();
            }
            else
            {
                this.Point_0 = Point1;
                this.kx = Point2.X - Point1.X;
                this.ky = Point2.Y - Point1.Y;
                this.kz = Point2.Z - Point1.Z;
                this.Point_1.X = this.kx + this.Point_0.X;
                this.Point_1.Y = this.ky + this.Point_0.Y;
                this.Point_1.Z = this.kz + this.Point_0.Z;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр 3D прямой как результат пересечения двух заданных плоскостей
        /// </summary>
        /// <param name="Plane1">Первая заданная плоскость</param>
        /// <param name="Plane2">Вторая заданная плоскость</param>
        /// <remarks>Контролирует условие недопущения параллельности заданных плоскостей</remarks>
        public Line3D(GeomObjects.Plans.PlaneSpace Plane1, GeomObjects.Plans.PlaneSpace Plane2)
        {
            //Конструктор возвращает значения коэффициентов 3D прямой, заданной двумя плоскостями
            Line3D Line = new Line3D();
            GeomObjects.Plans.PlaneSpace PlaneVar = new GeomObjects.Plans.PlaneSpace();
            //Переменная для работы с классом плоскостей
            //Проверка параллельности заданных плоскостей + Контроль корректности задания плоскостей
            if (PlaneVar.PlanToPlanParallele(Plane1, Plane2) == true)
            {
                Interaction.MsgBox("Не удается построить прямую, заданную двумя плоскостями." + Constants.vbCrLf + "Заданные плоскости взаимно параллельны.", MsgBoxStyle.Critical, "Построение 3D прямой, заданной двумя плоскостями");
                this.LineNon();
                return;
            }
            //====== Расчет коэффициентов канонического уравнения 3D прямой =====
            //kx = Plane2.B * Plane1.C - Plane1.B * Plane2.C
            //ky = Plane2.C * Plane1.A - Plane1.C * Plane2.A
            //kz = Plane2.A * Plane1.B - Plane1.A * Plane2.B
            this.kx = Plane1.B * Plane2.C - Plane2.B * Plane1.C;
            this.ky = Plane1.C * Plane2.A - Plane2.C * Plane1.A;
            this.kz = Plane1.A * Plane2.B - Plane2.A * Plane1.B;
            //Расчет базовой точки прямой
            //'I способ (решение системы двух уравнений с тремя неизвестными, с помощью подстановки значения z=0)
            //'Обработка деления на ноль
            //If Plane2.A = 0 Or Plane1.B - (Plane1.A * Plane2.B / Plane2.A) = 0 Then
            //    PlaneVar = Plane1 : Plane1 = Plane2 : Plane2 = PlaneVar 'Перемена номеров плоскостей
            //    If Plane2.A = 0 Or Plane1.B - (Plane1.A * Plane2.B / Plane2.A) = 0 Then
            //        MsgBox("Не удается построить прямую, заданную двумя плоскостями." & vbCrLf & _
            //               "Не обработано деление на ноль.", MsgBoxStyle.Critical, "Построение 3D прямой, заданной двумя плоскостями")
            //        MyClass.LineNon()
            //        Exit Sub
            //    End If
            //End If
            //======Обработать ошибку при равенстве нулю координат x или y базовой точки (в задании плоскостей)
            //If Plane1.A = 0 Or Plane1.B = 0 Or Plane1.C = 0 Or Plane2.A = 0 Or Plane2.B = 0 Or Plane2.C = 0 Then
            //    MsgBox("Один или несколько коээфициентов при координатах равны нулю." & vbCrLf & _
            //           "Возможна ошибка при расчете опорной точки прямой." & vbCrLf & _
            //           "Надо доделать алгоритм расчета.", MsgBoxStyle.AbortRetryIgnore, "Построение 3D прямой, заданной двумя плоскостями")
            //    MyClass.LineNon()
            //    Exit Sub
            //End If
            //Dim k1, k2, k3 As Double
            //Point_0.z = 0
            //k1 = Plane1.B
            //k2 = Plane1.A * Plane2.B / Plane2.A
            //k3 = (Plane1.A * Plane2.D / Plane2.A) - Plane1.D
            //Point_0.y = k3 / (k1 - k2)
            //Point_0.x = (-Plane2.B * Point_0.y - Plane2.D) / Plane2.A

            //II способ (по методу Крамера) считает без погрешности округления (более точно по отношению к I способу)
            MatrixEvalution MrxVal = new MatrixEvalution();
            int MetkaCase = 0;
            double[,] MrxA = new double[2, 2];
            double[,] MrxA1 = new double[2, 2];
            double[,] MrxDet = new double[2, 2];
            double[,] MrxA1DetYZ = new double[2, 2];
            double[,] MrxA1DetXZ = new double[2, 2];
            double MrxRankA = 0;
            double MrxRankA1 = 0;
            double DetXY = 0;
            double DetXZ = 0;
            double DetZY = 0;
            double DetA1X = 0;
            double DetA1Y = 0;
            double W1 = 0;
            double F1P1 = 0;
            double F2P1 = 0;
            double F3P1 = 0;
            double W2 = 0;
            double F1P2 = 0;
            double F2P2 = 0;
            double F3P2 = 0;
            double Det = 0;
            double Rez1 = 0;
            double Rez2 = 0;
            double Rez3 = 0;
            MrxA.SetValue(Plane1.A, 0, 0);
            MrxA.SetValue(Plane1.B, 0, 1);
            MrxA.SetValue(Plane1.C, 0, 2);
            MrxA.SetValue(Plane2.A, 1, 0);
            MrxA.SetValue(Plane2.B, 1, 1);
            MrxA.SetValue(Plane2.C, 1, 2);
            //Расширенная матрица, составленная из коээфициентов уравнений плоскостей
            MrxA1.SetValue(Plane1.A, 0, 0);
            MrxA1.SetValue(Plane1.B, 0, 1);
            MrxA1.SetValue(Plane1.C, 0, 2);
            MrxA1.SetValue(-Plane1.D, 0, 3);
            MrxA1.SetValue(Plane2.A, 1, 0);
            MrxA1.SetValue(Plane2.B, 1, 1);
            MrxA1.SetValue(Plane2.C, 1, 2);
            MrxA1.SetValue(-Plane2.D, 1, 3);
            MrxRankA = MrxVal.RangMrxMxN(MrxA);
            MrxRankA1 = MrxVal.RangMrxMxN(MrxA1);
            //Расчет ранга матриц
            if (MrxRankA == MrxRankA1)
            {
                if (MrxRankA == 2)
                {
                    MrxDet.SetValue(Plane1.A, 0, 0);
                    MrxDet.SetValue(Plane1.B, 0, 1);
                    MrxDet.SetValue(Plane2.A, 1, 0);
                    MrxDet.SetValue(Plane2.B, 1, 1);
                    DetXY = MrxVal.detMrx2x2(MrxDet);
                    if (DetXY == 0)
                    {
                        goto CalcXZ;
                    }
                    else
                    {
                        MetkaCase = 1;
                        F1P1 = Plane1.A;
                        F2P1 = Plane1.B;
                        F3P1 = Plane1.C;
                        F1P2 = Plane2.A;
                        F2P2 = Plane2.B;
                        F3P2 = Plane2.C;
                        Det = DetXY;
                        W1 = 0;
                        W2 = 0;
                        goto CalcSys;
                    }
                }
                else
                {
                    Interaction.MsgBox("Не удается расчитать базовую точку прямой методом Крамера." + Constants.vbCrLf + "Ранги матриц из коэффициентов уравнений заданных плоскостей не равны двум.", MsgBoxStyle.Critical, "Построение 3D прямой, заданной двумя плоскостями");
                    this.LineNon();
                    return;
                }
            }
            else
            {
                Interaction.MsgBox("Не удается расчитать базовую точку прямой методом Крамера." + Constants.vbCrLf + "Ранги матриц из коэффициентов уравнений заданных плоскостей не равны.", MsgBoxStyle.Critical, "Построение 3D прямой, заданной двумя плоскостями");
                this.LineNon();
                return;
            }
        CalcXZ:
            //Перемена местами в уравнениях плоскости членов By и Cz
            MrxDet.SetValue(Plane1.A, 0, 0);
            MrxDet.SetValue(Plane1.C, 0, 1);
            MrxDet.SetValue(Plane2.A, 1, 0);
            MrxDet.SetValue(Plane2.C, 1, 1);
            DetXZ = MrxVal.detMrx2x2(MrxDet);
            if (DetXZ == 0)
            {
                goto CalcYZ;
            }
            else
            {
                MetkaCase = 2;
                F1P1 = Plane1.A;
                F2P1 = Plane1.C;
                F3P1 = Plane1.B;
                F1P2 = Plane2.A;
                F2P2 = Plane2.C;
                F3P2 = Plane2.B;
                Det = DetXZ;
                W1 = 0;
                W2 = 0;
                goto CalcSys;
            }
        CalcYZ:
            //Перемена местами в уравнениях плоскости членов Ax и Cz
            MrxDet.SetValue(Plane1.C, 0, 0);
            MrxDet.SetValue(Plane1.B, 0, 1);
            MrxDet.SetValue(Plane2.C, 1, 0);
            MrxDet.SetValue(Plane2.B, 1, 1);
            DetZY = MrxVal.detMrx2x2(MrxDet);
            if (DetZY == 0)
            {
                Interaction.MsgBox("Не удается расчитать базовую точку прямой методом Крамера." + Constants.vbCrLf + "Определители матриц для расчета координат базовой точки равны нулю.", MsgBoxStyle.Critical, "Построение 3D прямой, заданной двумя плоскостями");
                this.LineNon();
                return;
            }
            else
            {
                MetkaCase = 3;
                F1P1 = Plane1.C;
                F2P1 = Plane1.B;
                F3P1 = Plane1.A;
                F1P2 = Plane2.C;
                F2P2 = Plane2.B;
                F3P2 = Plane2.A;
                Det = DetZY;
                W1 = 0;
                W2 = 0;
                goto CalcSys;
            }
        CalcSys:
            MrxA1DetYZ.SetValue(-Plane1.D - F3P1 * W1, 0, 0);
            MrxA1DetYZ.SetValue(F2P1, 0, 1);
            MrxA1DetYZ.SetValue(-Plane2.D - F3P2 * W2, 1, 0);
            MrxA1DetYZ.SetValue(F2P2, 1, 1);
            DetA1X = MrxVal.detMrx2x2(MrxA1DetYZ);
            MrxA1DetXZ.SetValue(F1P1, 0, 0);
            MrxA1DetXZ.SetValue(-Plane1.D - F3P1 * W1, 0, 1);
            MrxA1DetXZ.SetValue(F1P2, 1, 0);
            MrxA1DetXZ.SetValue(-Plane2.D - F3P2 * W2, 1, 1);
            DetA1Y = MrxVal.detMrx2x2(MrxA1DetXZ);
            Rez1 = DetA1X / Det;
            Rez2 = DetA1Y / Det;
            Rez3 = 0;
            if (MetkaCase == 1)
            {
                this.Point_0.X = Rez1;
                this.Point_0.Y = Rez2;
                this.Point_0.Z = Rez3;
            }
            else if (MetkaCase == 2)
            {
                this.Point_0.X = Rez1;
                this.Point_0.Y = Rez3;
                this.Point_0.Z = Rez2;
            }
            else if (MetkaCase == 3)
            {
                this.Point_0.X = Rez3;
                this.Point_0.Y = Rez2;
                this.Point_0.Z = Rez1;
            }
            this.Point_1.X = this.kx + this.Point_0.X;
            this.Point_1.Y = this.ky + this.Point_0.Y;
            this.Point_1.Z = this.kz + this.Point_0.Z;
            //Расчет второй точки линии
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
            base.LineNon();
            //this.Point_0.Z = 1 / 0;
            //this.Point_1.Z = 1 / 0;
            //this.kz = 1 / 0;
        }

        /// <summary>
        /// Задает 3D прямую по двум 3D точками
        /// </summary>
        /// <param name="Point1">Первая (опорная) точка прямой</param>
        /// <param name="Point2">Вторая точка прямой</param>
        /// <remarks>Рассчитывает значения постоянных коэффициентов 3D прямой, заданной двумя 3D точками.
        /// Первая заданная точка записывается в качестве опорной точки прямой.
        /// </remarks>
        public void LineBy2Points(GeomObjects.Points.Point3D Point1, GeomObjects.Points.Point3D Point2)
        {
            //Конструктор рассчитывает значения постоянных коэффициентов 3D прямой, заданной двумя 3D точками 
            Line3D Line3DNew = new Line3D(Point1, Point2);
            //Отключено по причине дублирования
            //' ''MyClass.Point_0 = Line3DNew.Point_0  'Начальная точка прямой
            // '' ''Коэффициенты уравнения общего вида прямой
            //' ''MyClass.kx = Line3DNew.kx : MyClass.ky = Line3DNew.ky : MyClass.kz = Line3DNew.kz
        }

        //Public Overloads Sub LineCalc(ByVal Point1 As BaseGeometryYVP.GeomObjects.Points.Point3D, ByVal Point2 As BaseGeometryYVP.GeomObjects.Points.Point3D, _
        //                   ByRef A As Double, ByRef B As Double, ByRef C As Double)
        //    'Конструктор расчитывает значения постоянных коэффициентов 3D прямой по двум 3D точкам
        //    Dim pointVar As New BaseGeometryYVP.GeomObjects.Points.Point3D
        //    'Контроль совпадения заданных точек
        //    If pointVar.PointsIsPoints(Point1, Point2) = True Then
        //        MsgBox("Не удается построить прямую по двум точкам." & vbCrLf & _
        //               "Заданные точки совпадают.", MsgBoxStyle.Critical, "Расчет коэффициентов 3D прямой по двум заданным 3D точкам")
        //        'MyClass.Point_0 = Nothing : MyClass.A = Nothing : MyClass.B = Nothing : MyClass.C = Nothing
        //        'MyClass.kx = Nothing : MyClass.ky = Nothing : MyClass.kz = Nothing
        //        MyClass.LineNon()
        //        Exit Sub
        //    End If
        //    'Обработать деление на ноль

        //    '___________Так ли?????___________________________________
        //    A = (Point1.y - Point2.y) / _
        //              (Point1.x * Point2.y - Point2.x * Point1.y - Point2.z * Point1.z)
        //    B = (Point2.x - Point1.x) / _
        //       (Point1.x * Point2.y - Point2.x * Point1.y - Point2.z * Point1.z)
        //    C = (Point2.z - Point1.z) / _
        //   (Point1.x * Point2.y - Point2.x * Point1.y - Point2.z * Point1.z)
        //    MyClass.Point_0 = Point1
        //End Sub

        /// <summary>
        /// Задает 3D прямую двумя пересекающимися плоскостями
        /// </summary>
        /// <param name="Plane1">Первая плоскость</param>
        /// <param name="Plane2">Вторая плоскость</param>
        /// <remarks>Рассчитывает значения постоянных коэффициентов 3D прямой, заданной двумя пересекающимися плоскостями
        /// Контролирует условие недопущения параллельности заданных плоскостей.</remarks>
        public void LineByTwoPlans(GeomObjects.Plans.PlaneSpace Plane1, GeomObjects.Plans.PlaneSpace Plane2)
        {
            //Конструктор возвращает значения коэффициентов 3D прямой, заданной двумя плоскостями
            Line3D Line3DNew = new Line3D(Plane1, Plane2);
            //+Контроль корректности задания плоскостей
            //Отключено по причине дублирования
            //' ''MyClass.kx = Line3DNew.kx : MyClass.ky = Line3DNew.ky : MyClass.kz = Line3DNew.kz
            //' ''Dim NewPoint0 As New BaseGeometryYVP.GeomObjects.Points.Point3D(Line3DNew.Point_0.X, Line3DNew.Point_0.Y, Line3DNew.Point_0.Z)
            //' ''Point_0 = NewPoint0
        }

        /// <summary>
        /// Задает 3D прямую, параллельную указанной 3D прямой и проходящую через указанную 3D точку
        /// </summary>
        /// <param name="Line">Заданная 3D прямая</param>
        /// <param name="Point">3D точка, через которую должна проходить параллельная прямая</param>
        /// <remarks></remarks>
        public void ParallelPointToLine(Line3D Line, GeomObjects.Points.Point3D Point)
        {
            //Конструктор задает параллельную 3D прямую, проходящую через 3D точку
            //Контроль корректности задания прямой
            if (LinesControl.LineTrue(Line) == false)
            {
                Interaction.MsgBox("Ошибка задания прямой линии." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Построение параллельной 3D прямой, проходящей через 3D точку");
                this.LineNon();
            }
            else
            {
                //Расчет
                this.Point_0 = Point;
                this.kx = Line.kx;
                this.ky = Line.ky;
                this.kz = Line.kz;
                this.Point_1.X = this.kx + this.Point_0.X;
                this.Point_1.Y = this.ky + this.Point_0.Y;
                this.Point_1.Z = this.kz + this.Point_0.Z;
            }
        }

        /// <summary>
        /// Задает 3D прямую, проходящую через 3D точку и перпендикулярную двум 3D линиям
        /// </summary>
        /// <param name="Line1">Первая 3D прямая, к которой строится перпендикуляр</param>
        /// <param name="Line2">Вторая 3D прямая, к которой строится перпендикуляр</param>
        /// <param name="Point">3D точка, из которой выставляется перепендикуляр</param>
        /// <remarks></remarks>
        public void PerpendicularPointToTwoLines(Line3D Line1, Line3D Line2, GeomObjects.Points.Point3D Point)
        {
            //Конструктор задает 3D прямую, проходящую через 3D точку и перпендикулярную двум 3D линиям
            Line3D Line3 = new Line3D();
            //Dim Line4 As New Line3D
            //Dim Angle As Double
            //Dim kx = m, ky = n, kz = p As Double
            //Контроль совпадения заданных прямых + Контроль корректности задания прямых
            if (LinePositionControl.LinesIsLines(Line1, Line2) == true)
            {
                Interaction.MsgBox("Заданные прямые совпадают" + Constants.vbCrLf, MsgBoxStyle.Critical, "Построение из заданной 3D точки перпендикуляра к двум 3D прямым");
                this.PerpendicularPointToLine(Line1, Point);
                //Может возникнуть бесконечный цикл!!!
                return;
            }
            if (LinePositionControl.LineToLineParallel(Line1, Line2) == false)
            {
                this.Point_0 = Point;
                this.kx = Line1.ky * Line2.kz - Line2.ky * Line1.kz;
                this.ky = Line2.kx * Line1.kz - Line1.kx * Line2.kz;
                this.kz = Line1.kx * Line2.ky - Line2.kx * Line1.ky;
                this.Point_1.X = this.kx + this.Point_0.X;
                this.Point_1.Y = this.ky + this.Point_0.Y;
                this.Point_1.Z = this.kz + this.Point_0.Z;
                //Расчет второй точки линии
                if (this.kx == 0 & this.ky == 0 & this.kz == 0)
                {
                    Interaction.MsgBox("Ошибка построения перпендикуляра." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Построение из заданной 3D точки перпендикуляра к двум 3D прямым");
                    this.LineNon();
                }
            }
            else
            {
                Line3.LineBy2Points(Line1.Point_0, Line2.Point_0);
                //Angle = MyClass.LineAngle(Line1, Line3)
                this.Point_0 = Point;
                this.kx = Line1.ky * Line3.kz - Line3.ky * Line1.kz;
                this.ky = Line3.kx * Line1.kz - Line1.kx * Line3.kz;
                this.kz = Line1.kx * Line3.ky - Line3.kx * Line1.ky;
                this.Point_1.X = this.kx + this.Point_0.X;
                this.Point_1.Y = this.ky + this.Point_0.Y;
                this.Point_1.Z = this.kz + this.Point_0.Z;
                //Расчет второй точки линии
                if (this.kz == 0 & this.kx == 0 & this.ky == 0)
                {
                    Interaction.MsgBox("Ошибка построения перпендикуляра." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Построение из заданной 3D точки перпендикуляра к двум 3D прямым");
                    this.LineNon();
                }
                else
                {
                    //Line4.kx = kx : Line4.ky = ky : Line4.kz = kz : Line4.Point_0 = Point_0
                    //Angle = MyClass.LineAngle(Line1, Line4)
                }
            }
        }

        //====================================================================================================
        //================== Функции расчета параметров 3D линии по заданным условиям ==================

        /// <summary>
        /// Расчитывает значения коэффициентов основного уравнения 3D прямой, заданной двумя плоскостями
        /// </summary>
        /// <param name="Plane1">Первая плоскость</param>
        /// <param name="Plane2">Вторая плоскость</param>
        /// <returns>Возвращает двумерный массив значений коэффициентов 3D прямой, заданной двумя плоскостями</returns>
        /// <remarks>Возвращаемый массив соответсвует системе уравненений вида:
        /// первая строка массива - ???
        /// и вторая строка массива - ???
        /// </remarks>
        public double[,] LineGeneralEquations(GeomObjects.Plans.PlaneSpace Plane1, GeomObjects.Plans.PlaneSpace Plane2)
        {
            //Конструктор возвращает значения коэффициентов 3D прямой, заданной двумя плоскостями
            Line3D LineByPlans = new Line3D(Plane1, Plane2);
            //Расчет коэффициентов канонического уравнения 3D прямой + Контроль корректности задания плоскостей
            double[,] CoeffLine = new double[2, 4];
            CoeffLine.SetValue(Plane1.A, 0, 0);
            CoeffLine.SetValue(Plane1.B, 0, 1);
            CoeffLine.SetValue(Plane1.C, 0, 2);
            CoeffLine.SetValue(Plane1.D, 0, 3);
            CoeffLine.SetValue(Plane2.A, 1, 0);
            CoeffLine.SetValue(Plane2.B, 1, 1);
            CoeffLine.SetValue(Plane2.C, 1, 2);
            CoeffLine.SetValue(Plane2.D, 1, 3);
            return CoeffLine;
        }

        /// <summary>
        /// Расчитывает значения коэффициентов уравнений 3D прямой в проекциях на плоскости нулевого базиса
        /// </summary>
        /// <param name="Line">Заданная прямая</param>
        /// <returns>Возвращает значения коэффициентов уравнений 3D прямой в проекциях на плоскости нулевого базиса</returns>
        /// <remarks>Возвращаемый массив соответсвует системе уравненений вида:
        /// первая строка массива - A1x+B1y+D1=0 (определяет проекцию заданной прямой на плоскость xOy нулевого базиса)
        /// и вторая строка массива - A2x+C2y+D2=0 (определяет проекцию заданной прямой на плоскость xOz нулевого базиса) 
        /// </remarks>
        public double[,] LineEquationsInProections(Line3D Line)
        {
            double[,] functionReturnValue = null;
            //Конструктор возвращает значения коэффициентов уравнений 3D прямой в проекциях на плоскости нулевого базиса
            //Система уравненений вида: A1x+B1y+D1=0 (определяет проекцию заданной прямой на плоскость xOy нулевого базиса)
            //                        и A2x+C2y+D2=0 (определяет проекцию заданной прямой на плоскость xOz нулевого базиса) 
            double[,] CoeffLine = new double[2, 3];
            double A1 = 0;
            double B1 = 0;
            double D1 = 0;
            double A2 = 0;
            double C2 = 0;
            double D2 = 0;
            //Dim LineErr As New LineErrors  'Контроль корректности задания прямой
            //Контроль корректности задания прямых
            if (LinesControl.LineTrue(Line) == false)
            {
                Interaction.MsgBox("Ошибка задания прямой линии." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Расчет коэффициентов уравнений 3D прямой в проекциях на плоскости нулевого базиса");
                return null;
            }
            A1 = Line.ky;
            B1 = -Line.kx;
            D1 = Line.Point_0.Y * Line.kx - Line.Point_0.X * Line.ky;
            A2 = Line.kz;
            C2 = -Line.kx;
            D2 = Line.Point_0.Z * Line.kx - Line.Point_0.X * Line.kz;
            CoeffLine.SetValue(A1, 0, 0);
            CoeffLine.SetValue(B1, 0, 1);
            CoeffLine.SetValue(D1, 0, 2);
            CoeffLine.SetValue(A2, 1, 0);
            CoeffLine.SetValue(C2, 1, 1);
            CoeffLine.SetValue(D2, 1, 2);
            return CoeffLine;
        }

        /// <summary>
        /// Задает 3D перпендикуляр из заданной 3D точки к заданной 3D прямой 
        /// </summary>
        /// <param name="Point">Заданная 3D точка</param>
        /// <param name="Line">Заданная 3D прямая</param>
        /// <remarks></remarks>
        public void PerpendicularPointToLine(GeomObjects.Points.Point3D Point, Line3D Line)
        {
            //Конструктор задает перпендикуляр из 3D точки к 3D прямой
            dynamic Line2 = null;
            dynamic Line3 = null;
            Line3D Line4 = new Line3D();
            //===== Контроль инцидентности заданных точки и линии =====
            //+ Контроль корректности задания прямой
            if (LinePositionControl.PointOfLine(Point, Line) == true)
            {
                Interaction.MsgBox("Ошибка построения перпендикуляра из точки «Point» к прямой «Line»." + Constants.vbCrLf + "Заданная точка инцидентна заданной прямой.", MsgBoxStyle.Critical, "Построение из заданной 3D точки перпендикуляра к 3D прямой");
                //Point_0 = Nothing : kx = Nothing : ky = Nothing : kz = Nothing
                //A = Nothing : B = Nothing : C = Nothing
                this.LineNon();
                return;
            }
            //===================== Расчет ========================
            Line2.ParallelPointToLine(Line, Point);
            //Из точки проводим параллель (Line2) к Line 
            //Проверяем нахождение линий в одной плоскости
            if (LinePositionControl.TwoLinesOfPlane(Line, Line2) == true)
            {
                Line3.PerpendicularPointToTwoLines(Line, Line2, Point);
                //Из точки (Point) на второй линии проводим перпендикуляр к Line и Line2
                //Проверяем нахождение линий и пепендикуляра в одной плоскости
                if (LinePositionControl.TwoLinesOfPlane(Line, Line3) == true)
                {
                    this.Point_0 = Point;
                    this.kx = Line3.kx;
                    this.ky = Line3.ky;
                    this.kz = Line3.kz;
                    this.Point_1.X = this.kx + this.Point_0.X;
                    this.Point_1.Y = this.ky + this.Point_0.Y;
                    this.Point_1.Z = this.kz + this.Point_0.Z;
                    //Расчет второй точки линии
                }
                else
                {
                    Line4.PerpendicularPointToTwoLines(Line3, Line, Point);
                    //Из точки (Point) на второй линии проводим перпендикуляр к Line и Line2
                    //Проверяем нахождение линий и пепендикуляра в одной плоскости
                    if (LinePositionControl.TwoLinesOfPlane(Line, Line4) == true)
                    {
                        this.Point_0 = Line4.Point_0;
                        this.kx = Line4.kx;
                        this.ky = Line4.ky;
                        this.kz = Line4.kz;
                        this.Point_1.X = this.kx + this.Point_0.X;
                        this.Point_1.Y = this.ky + this.Point_0.Y;
                        this.Point_1.Z = this.kz + this.Point_0.Z;
                        //Расчет второй точки линии
                    }
                    else
                    {
                        Interaction.MsgBox("Ошибка построения перпендикуляра из точки «Point» к прямой «Line»." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Построение из заданной 3D точки перпендикуляра к 3D прямой");
                        //    Point_0 = Nothing : kx = Nothing : ky = Nothing : kz = Nothing
                        //    A = Nothing : B = Nothing : C = Nothing
                        this.LineNon();
                    }
                }
            }
            else
            {
                Interaction.MsgBox("Ошибка построения перпендикуляра из точки «Point» к прямой «Line»." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Построение из заданной 3D точки перпендикуляра к 3D прямой");
                //Point_0 = Nothing : kx = Nothing : ky = Nothing : kz = Nothing
                //A = Nothing : B = Nothing : C = Nothing
                this.LineNon();
            }
        }

        /// <summary>
        /// Расчитывает направляющий вектор заданной 3D прямой
        /// </summary>
        /// <param name="Line">Заданная 3D прямая</param>
        /// <returns>Возвращает значения угловых коэффициентов 3D прямой, т.е. ее направляющего вектора</returns>
        /// <remarks>Point3D.X = CosAlfa; Point3D.Y = CosBetta; Point3D.Z = CosGamma.</remarks>
        public GeomObjects.Points.Point3D DirectingVector3DLine(Line3D Line)
        {
            //Функция возвращает значения угловых коэффициентов 3D прямой, т.е. ее направляющего вектора
            //Контроль корректности задания прямой
            //Dim LineErr As New LineErrors  'Контроль корректности задания прямой
            if (LinesControl.LineTrue(Line) == false)
            {
                Interaction.MsgBox("Ошибка задания прямой линии." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Расчет значения угловых коэффициентов 3D прямой, т.е. ее направляющего вектора");
                return null;
            }
            //Расчет
            //___Почему-то не надо делить на корень?????________________
            double CosAl = 0;
            double CosBt = 0;
            double CosGm = 0;
            CosAl = Line.kx / Math.Sqrt(Math.Pow(Line.kx, 2) + Math.Pow(Line.ky, 2) + Math.Pow(Line.kz, 2));
            CosBt = Line.ky / Math.Sqrt(Math.Pow(Line.kx, 2) + Math.Pow(Line.ky, 2) + Math.Pow(Line.kz, 2));
            CosGm = Line.kz / Math.Sqrt(Math.Pow(Line.kx, 2) + Math.Pow(Line.ky, 2) + Math.Pow(Line.kz, 2));
            return new GeomObjects.Points.Point3D(CosAl, CosBt, CosGm);
        }

        /// <summary>
        /// Функция задает прямую, как проекцию 3D прямой на заданную плоскость
        /// </summary>
        /// <param name="Line">Заданная 3D прямая, проекцию которой необходимо построить </param>
        /// <param name="Plane">Заданная плоскость, на которой должна отображаться заданная 3D прямая</param>
        /// <returns>Возвращает прямую, как проекцию прямой на заданную плоскость</returns>
        /// <remarks>Расчет осуществляется по коэффициентам уравнений прямой и плоскости</remarks>
        public GeomObjects.Lines.Line3D ProectionLineOnPlane(GeomObjects.Lines.Line3D Line, GeomObjects.Plans.PlaneSpace Plane)
        {
            GeomObjects.Lines.Line3D functionReturnValue = default(GeomObjects.Lines.Line3D);
            //Функция возвращает прямую, как проекцию прямой на заданную плоскость
            GeomObjects.Lines.Line3D ProectionLine = new GeomObjects.Lines.Line3D();
            dynamic PlaneLine = default(GeomObjects.Plans.PlaneSpace);
            dynamic NormVectPlane = default(GeomObjects.Plans.PlaneSpace);
            GeomObjects.Plans.PlaneSpace PlaneVar = new GeomObjects.Plans.PlaneSpace();
            double[,] EguationSys1 = null;
            double[,] EguationSys2 = null;
            double[,] EguationSys3 = null;
            double Apr = 0;
            double Bpr = 0;
            double Cpr = 0;
            dynamic MrxVar1 = default(MatrixEvalution);
            dynamic MrxVar2 = default(MatrixEvalution);
            MatrixEvalution MrxVar3 = new MatrixEvalution();
            // Переменые для работы с классом MatrixCalc
            EguationSys1 = new double[2, 2];
            EguationSys2 = new double[2, 2];
            EguationSys3 = new double[2, 2];
            //Контроль инцидентности заданных прямой и плоскости + контроль корректности задания прямой и плоскости
            //If PlaneVar.PlaneSpaceLineOfPlan(Line, Plane) = True Then 'Если прямая инцидентна плоскости
            //    Return Line
            //    Exit Function
            //End If
            //Если прямая инцидентна плоскости
            if (LinePositionControl.LineOfPlan(Line, Plane) == true)
            {
                return Line;
            }
            //Контроль перпендикулярности заданных прямой и плоскости
            //Если прямая перпендикулярна плоскости
            if (LinePositionControl.LineToPlanePerpendiculare(Line, Plane) == true)
            {
                //Dim ProectionPoint As New BaseGeometryYVP.GeomObjects.BaseGeometryYVP.GeomObjects.Points.Point3D
                //ProectionPoint = MyClass.IntersectionPoint_LineAndPlan(Line, Plane)
                //Return ProectionPoint
                Interaction.MsgBox("Заданная прямая перпендикулярна заданной плоскости." + Constants.vbCrLf + "Для нахождения проекции такой прямой используйте расчет точки пересечения с плоскостью," + Constants.vbCrLf + "либо обработайте условие перпендикулярности прямой и плоскости.", MsgBoxStyle.Critical, "Построение проекции прямой на плоскость");
                return null;
            }
            //Заполнение матриц-определителей для решения системы уравнений
            //Для нахождения коэффициента для X
            EguationSys1.SetValue(Line.ky, 0, 0);
            EguationSys1.SetValue(Line.kz, 0, 1);
            EguationSys1.SetValue(Plane.B, 1, 0);
            EguationSys1.SetValue(Plane.C, 1, 1);
            //Для нахождения коэффициента для Y
            //EguationSys2.SetValue(Line.kx, 0, 0) : EguationSys2.SetValue(Line.kz, 0, 1)
            //EguationSys2.SetValue(Plane.A, 1, 0) : EguationSys2.SetValue(Plane.C, 1, 1)
            //По книге меняются столбцы, т.к. коэффициент при y в уравнение подставляется со знаком минус
            EguationSys2.SetValue(Line.kx, 0, 1);
            EguationSys2.SetValue(Line.kz, 0, 0);
            EguationSys2.SetValue(Plane.A, 1, 1);
            EguationSys2.SetValue(Plane.C, 1, 0);
            //Для нахождения коэффициента для Z
            EguationSys3.SetValue(Line.kx, 0, 0);
            EguationSys3.SetValue(Line.ky, 0, 1);
            EguationSys3.SetValue(Plane.A, 1, 0);
            EguationSys3.SetValue(Plane.B, 1, 1);
            //Решение определителей
            Apr = MrxVar1.detMrx2x2(EguationSys1);
            Bpr = MrxVar2.detMrx2x2(EguationSys2);
            Cpr = MrxVar3.detMrx2x2(EguationSys3);
            //Запись полученных коэффициентов для плоскости, проходящей через заданную прямую перпендикулярно заданной плоскости
            PlaneLine.A = Apr;
            PlaneLine.B = Bpr;
            PlaneLine.C = Cpr;
            PlaneLine.D = PlaneLine.A * (-Line.Point_0.X) + PlaneLine.B * (-Line.Point_0.Y) + PlaneLine.C * (-Line.Point_0.Z);
            //Расчет свободного коэффициента новой плоскости
            //Расчет центра плоскости
            PlaneLine.PlaneCentre.X = PlaneLine.A;
            PlaneLine.PlaneCentre.Y = PlaneLine.B;
            PlaneLine.PlaneCentre.Z = PlaneLine.C;
            //Расчет прямой как линии пересечения двух плоскостей
            ProectionLine.LineByTwoPlans(Plane, PlaneLine);
            return ProectionLine;
        }

        // ''' <summary>
        // ''' Функция контроля корректности задания 3D прямой
        // ''' </summary>
        // ''' <param name="Line">Заданная прямая</param>
        // ''' <returns>Возвращает "TRUE", если заданная 3D прямая задана не корректно</returns>
        // ''' <remarks>Реализована и используется в классе LineErrors</remarks>
        //Public Overloads Function LineFalse(ByVal Line As Line3D) As Boolean
        //    'Функция возвращает "TRUE", если заданная 3D прямая задана не корректно
        //    Dim LineErr As New LineErrors
        //    If LineErr.LineFalse(Line) = True And Line.kz = 0 Then
        //        Return True
        //    Else
        //        Return False
        //    End If
        //End Function


        //===================== Конструкторы, методы и функции, работающие с целочисленными значениями ============================
        //================================= выдают результат с нулевой погрешностью ===============================================





        //    Public Sub New(ByVal Plane1 As GeomObjects.Plans.PlaneSpace, ByVal Plane2 As GeomObjects.Plans.PlaneSpace)
        //        'Конструктор возвращает значения коэффициентов 3D прямой, заданной двумя плоскостями
        //        Dim Line As New Line3D
        //        Dim PlaneVar As New GeomObjects.Plans.PlaneSpace 'Переменная для работы с классом плоскостей
        //        'Проверка параллельности заданных плоскостей + Контроль корректности задания плоскостей
        //        If PlaneVar.PlanToPlanParallele(Plane1, Plane2) = True Then
        //            MsgBox("Не удается построить прямую, заданную двумя плоскостями." & vbCrLf & _
        //                   "Заданные плоскости взаимно параллельны.", MsgBoxStyle.Critical, "Построение 3D прямой, заданной двумя плоскостями")
        //            MyClass.LineNon()
        //            Exit Sub
        //        End If
        //        '====== Расчет коэффициентов канонического уравнения 3D прямой =====
        //        'kx = Plane2.B * Plane1.C - Plane1.B * Plane2.C
        //        'ky = Plane2.C * Plane1.A - Plane1.C * Plane2.A
        //        'kz = Plane2.A * Plane1.B - Plane1.A * Plane2.B
        //        kx = Plane1.B * Plane2.C - Plane2.B * Plane1.C
        //        ky = Plane1.C * Plane2.A - Plane2.C * Plane1.A
        //        kz = Plane1.A * Plane2.B - Plane2.A * Plane1.B
        //        'Расчет базовой точки прямой
        //        ''I способ (решение системы двух уравнений с тремя неизвестными, с помощью подстановки значения z=0)
        //        ''Обработка деления на ноль
        //        'If Plane2.A = 0 Or Plane1.B - (Plane1.A * Plane2.B / Plane2.A) = 0 Then
        //        '    PlaneVar = Plane1 : Plane1 = Plane2 : Plane2 = PlaneVar 'Перемена номеров плоскостей
        //        '    If Plane2.A = 0 Or Plane1.B - (Plane1.A * Plane2.B / Plane2.A) = 0 Then
        //        '        MsgBox("Не удается построить прямую, заданную двумя плоскостями." & vbCrLf & _
        //        '               "Не обработано деление на ноль.", MsgBoxStyle.Critical, "Построение 3D прямой, заданной двумя плоскостями")
        //        '        MyClass.LineNon()
        //        '        Exit Sub
        //        '    End If
        //        'End If
        //        '======Обработать ошибку при равенстве нулю координат x или y базовой точки (в задании плоскостей)
        //        'If Plane1.A = 0 Or Plane1.B = 0 Or Plane1.C = 0 Or Plane2.A = 0 Or Plane2.B = 0 Or Plane2.C = 0 Then
        //        '    MsgBox("Один или несколько коээфициентов при координатах равны нулю." & vbCrLf & _
        //        '           "Возможна ошибка при расчете опорной точки прямой." & vbCrLf & _
        //        '           "Надо доделать алгоритм расчета.", MsgBoxStyle.AbortRetryIgnore, "Построение 3D прямой, заданной двумя плоскостями")
        //        '    MyClass.LineNon()
        //        '    Exit Sub
        //        'End If
        //        'Dim k1, k2, k3 As Double
        //        'Point_0.z = 0
        //        'k1 = Plane1.B
        //        'k2 = Plane1.A * Plane2.B / Plane2.A
        //        'k3 = (Plane1.A * Plane2.D / Plane2.A) - Plane1.D
        //        'Point_0.y = k3 / (k1 - k2)
        //        'Point_0.x = (-Plane2.B * Point_0.y - Plane2.D) / Plane2.A

        //        'II способ (по методу Крамера) считает без погрешности округления (более точно по отношению к I способу)
        //        Dim MrxVal As New MatrixCalc
        //        Dim MetkaCase As Integer = 0
        //        Dim MrxA(1, 2), MrxA1(1, 3), MrxDet(1, 1), MrxA1DetYZ(1, 1), MrxA1DetXZ(1, 1) As Double
        //        Dim MrxRankA, MrxRankA1, DetXY, DetXZ, DetZY, DetA1X, DetA1Y As Double
        //        Dim W1, F1P1, F2P1, F3P1, W2, F1P2, F2P2, F3P2, Det As Double
        //        Dim Rez1, Rez2, Rez3 As Double
        //        MrxA.SetValue(Plane1.A, 0, 0) : MrxA.SetValue(Plane1.B, 0, 1) : MrxA.SetValue(Plane1.C, 0, 2)
        //        MrxA.SetValue(Plane2.A, 1, 0) : MrxA.SetValue(Plane2.B, 1, 1) : MrxA.SetValue(Plane2.C, 1, 2)
        //        'Расширенная матрица, составленная из коээфициентов уравнений плоскостей
        //        MrxA1.SetValue(Plane1.A, 0, 0) : MrxA1.SetValue(Plane1.B, 0, 1) : MrxA1.SetValue(Plane1.C, 0, 2) : MrxA1.SetValue(-Plane1.D, 0, 3)
        //        MrxA1.SetValue(Plane2.A, 1, 0) : MrxA1.SetValue(Plane2.B, 1, 1) : MrxA1.SetValue(Plane2.C, 1, 2) : MrxA1.SetValue(-Plane2.D, 1, 3)
        //        MrxRankA = MrxVal.RangMrxMxN(MrxA) : MrxRankA1 = MrxVal.RangMrxMxN(MrxA1) 'Расчет ранга матриц
        //        If MrxRankA = MrxRankA Then
        //            If MrxRankA = 2 Then
        //                MrxDet.SetValue(Plane1.A, 0, 0) : MrxDet.SetValue(Plane1.B, 0, 1)
        //                MrxDet.SetValue(Plane2.A, 1, 0) : MrxDet.SetValue(Plane2.B, 1, 1)
        //                DetXY = MrxVal.detMrx2x2(MrxDet)
        //                If DetXY = 0 Then
        //                    GoTo CalcXZ
        //                Else
        //                    MetkaCase = 1
        //                    F1P1 = Plane1.A : F2P1 = Plane1.B : F3P1 = Plane1.C
        //                    F1P2 = Plane2.A : F2P2 = Plane2.B : F3P2 = Plane2.C
        //                    Det = DetXY
        //                    W1 = 0 : W2 = 0
        //                    GoTo CalcSys
        //                End If
        //            Else
        //                MsgBox("Не удается расчитать базовую точку прямой методом Крамера." & vbCrLf & _
        //                       "Ранги матриц из коэффициентов уравнений заданных плоскостей не равны двум.", MsgBoxStyle.Critical, "Построение 3D прямой, заданной двумя плоскостями")
        //                MyClass.LineNon()
        //                Exit Sub
        //            End If
        //        Else
        //            MsgBox("Не удается расчитать базовую точку прямой методом Крамера." & vbCrLf & _
        //                   "Ранги матриц из коэффициентов уравнений заданных плоскостей не равны.", MsgBoxStyle.Critical, "Построение 3D прямой, заданной двумя плоскостями")
        //            MyClass.LineNon()
        //            Exit Sub
        //        End If
        //CalcXZ:  'Перемена местами в уравнениях плоскости членов By и Cz
        //        MrxDet.SetValue(Plane1.A, 0, 0) : MrxDet.SetValue(Plane1.C, 0, 1)
        //        MrxDet.SetValue(Plane2.A, 1, 0) : MrxDet.SetValue(Plane2.C, 1, 1)
        //        DetXZ = MrxVal.detMrx2x2(MrxDet)
        //        If DetXZ = 0 Then
        //            GoTo CalcYZ
        //        Else
        //            MetkaCase = 2
        //            F1P1 = Plane1.A : F2P1 = Plane1.C : F3P1 = Plane1.B
        //            F1P2 = Plane2.A : F2P2 = Plane2.C : F3P2 = Plane2.B
        //            Det = DetXZ
        //            W1 = 0 : W2 = 0
        //            GoTo CalcSys
        //        End If
        //CalcYZ:  'Перемена местами в уравнениях плоскости членов Ax и Cz
        //        MrxDet.SetValue(Plane1.C, 0, 0) : MrxDet.SetValue(Plane1.B, 0, 1)
        //        MrxDet.SetValue(Plane2.C, 1, 0) : MrxDet.SetValue(Plane2.B, 1, 1)
        //        DetZY = MrxVal.detMrx2x2(MrxDet)
        //        If DetZY = 0 Then
        //            MsgBox("Не удается расчитать базовую точку прямой методом Крамера." & vbCrLf & _
        //                   "Определители матриц для расчета координат базовой точки равны нулю.", MsgBoxStyle.Critical, "Построение 3D прямой, заданной двумя плоскостями")
        //            MyClass.LineNon()
        //            Exit Sub
        //        Else
        //            MetkaCase = 3
        //            F1P1 = Plane1.C : F2P1 = Plane1.B : F3P1 = Plane1.A
        //            F1P2 = Plane2.C : F2P2 = Plane2.B : F3P2 = Plane2.A
        //            Det = DetZY
        //            W1 = 0 : W2 = 0
        //            GoTo CalcSys
        //        End If
        //CalcSys:
        //        MrxA1DetYZ.SetValue(-Plane1.D - F3P1 * W1, 0, 0) : MrxA1DetYZ.SetValue(F2P1, 0, 1)
        //        MrxA1DetYZ.SetValue(-Plane2.D - F3P2 * W2, 1, 0) : MrxA1DetYZ.SetValue(F2P2, 1, 1)
        //        DetA1X = MrxVal.detMrx2x2(MrxA1DetYZ)
        //        MrxA1DetXZ.SetValue(F1P1, 0, 0) : MrxA1DetXZ.SetValue(-Plane1.D - F3P1 * W1, 0, 1)
        //        MrxA1DetXZ.SetValue(F1P2, 1, 0) : MrxA1DetXZ.SetValue(-Plane2.D - F3P2 * W2, 1, 1)
        //        DetA1Y = MrxVal.detMrx2x2(MrxA1DetXZ)
        //        Rez1 = DetA1X / Det
        //        Rez2 = DetA1Y / Det
        //        Rez3 = 0
        //        If MetkaCase = 1 Then
        //            Point_0.x = Rez1
        //            Point_0.y = Rez2
        //            Point_0.z = Rez3
        //        ElseIf MetkaCase = 2 Then
        //            Point_0.x = Rez1
        //            Point_0.y = Rez3
        //            Point_0.z = Rez2
        //        ElseIf MetkaCase = 3 Then
        //            Point_0.x = Rez3
        //            Point_0.y = Rez2
        //            Point_0.z = Rez1
        //        End If
        //    End Sub

        //    Public Overloads Function LinesIntersectPoint(ByVal Line1 As Line3D, ByVal Line2 As Line3D) As BaseGeometryYVP.GeomObjects.Points.Point3D
        //        'Функция возвращает значения координат точки пересечения двух 3D прямых
        //        Dim IntersectPoint As New BaseGeometryYVP.GeomObjects.Points.Point3D
        //        Dim IntersectPoint2D As New BaseGeometryYVP.GeomObjects.Points.Point2D
        //        Dim Lin1New, Lin2New As New Line3D
        //        Dim Lin1New_2D, Lin2New_2D As New Line2D
        //        Dim Denominator As Double 'Знаменатель
        //        Dim Variable As New Line3D 'Переменная для контроля
        //        'Контроль прямых на пересечение + Контроль корректности задания прямой
        //        If Variable.LineToLineIntersect(Line1, Line2) = False Then
        //            MsgBox("Ошибка определения точки пересечения 3D прямых." & vbCrLf & _
        //                   "Заданные прямые не пересекаются.", MsgBoxStyle.Critical, "Расчет точки пересечения 3D прямых")
        //            IntersectPoint = Nothing
        //            Return IntersectPoint
        //            Exit Function
        //        End If
        //        'Контроль совпадения заданных прямых
        //        If MyClass.LinesIsLines(Line1, Line2) = True Then
        //            MsgBox("Заданные прямые совпадают" & vbCrLf, MsgBoxStyle.Exclamation, "Расчет точки пересечения 3D прямых")
        //            'IntersectPoint = Line1.Point_0
        //            'Return IntersectPoint
        //            IntersectPoint = Nothing
        //            Return IntersectPoint
        //            Exit Function
        //        End If
        //        'Расчет
        //        Denominator = -Line1.kz * Line2.ky + Line2.kz * Line1.ky
        //        If Denominator = 0 Then 'Обработка деления на ноль
        //            Lin1New = Line1 : Lin2New = Line2 'Перемена номеров прямых
        //            Line1 = Lin2New : Line2 = Lin1New 'Не нужное преобразование!!!!!
        //            Denominator = -Line1.kz * Line2.ky + Line2.kz * Line1.ky
        //            If Denominator = 0 Then
        //                If Line1.kz = 0 And Line2.kz = 0 Then 'Прямые лежат в плоскости XY
        //                    Lin1New_2D.kx = Line1.kx : Lin1New_2D.ky = Line1.ky
        //                    Lin1New_2D.Point_0.x = Line1.Point_0.x : Lin1New_2D.Point_0.y = Line1.Point_0.y
        //                    Lin2New_2D.kx = Line2.kx : Lin2New_2D.ky = Line2.ky
        //                    Lin2New_2D.Point_0.x = Line2.Point_0.x : Lin2New_2D.Point_0.y = Line2.Point_0.y
        //                    IntersectPoint2D = MyBase.LinesIntersectPoint(Lin1New_2D, Lin2New_2D)
        //                    IntersectPoint.x = IntersectPoint2D.x
        //                    IntersectPoint.y = IntersectPoint2D.y
        //                    IntersectPoint.z = 0
        //                    Return IntersectPoint
        //                    GoTo CalcEhd
        //                ElseIf Line2.ky = 0 And Line1.ky = 0 Then 'Прямые лежат в плоскости XZ
        //                    Lin1New_2D.kx = Line1.kx : Lin1New_2D.ky = Line1.kz
        //                    Lin1New_2D.Point_0.x = Line1.Point_0.x : Lin1New_2D.Point_0.y = Line1.Point_0.z
        //                    Lin2New_2D.kx = Line2.kx : Lin2New_2D.ky = Line2.kz
        //                    Lin2New_2D.Point_0.x = Line2.Point_0.x : Lin2New_2D.Point_0.y = Line2.Point_0.z
        //                    IntersectPoint2D = MyBase.LinesIntersectPoint(Lin1New_2D, Lin2New_2D)
        //                    IntersectPoint.x = IntersectPoint2D.x
        //                    IntersectPoint.z = IntersectPoint2D.y
        //                    IntersectPoint.y = 0
        //                    Return IntersectPoint
        //                    GoTo CalcEhd
        //                ElseIf Line1.ky = 0 And Line1.kz = 0 Then 'Прямая 1 лежит на оси OX
        //                    Dim Linet1 As Double = 0
        //                    Dim Linet2 As Double = 0
        //                    If Line2.ky <> 0 Then
        //                        Linet2 = (Line1.Point_0.y - Line2.Point_0.y) / Line2.ky
        //                        Linet1 = (Line2.Point_0.x + Line2.kx * Linet2 - Line1.Point_0.x) / Line1.kx
        //                    ElseIf Line2.kz <> 0 Then
        //                        Linet2 = (Line1.Point_0.z - Line2.Point_0.z) / Line2.kz
        //                        Linet1 = (Line2.Point_0.x + Line2.kx * Linet2 - Line1.Point_0.x) / Line1.kx
        //                    Else
        //                        MsgBox("Ошибка определения точки пересечения 3D прямых." & vbCrLf & _
        //                               "Заданные прямые совпадают или параллельны между собой.", MsgBoxStyle.Critical, "Расчет точки пересечения 3D прямых")
        //                        IntersectPoint.x = 1 / 0 : IntersectPoint.y = 1 / 0 : IntersectPoint.z = 1 / 0
        //                        Return IntersectPoint
        //                        GoTo CalcEhd
        //                    End If
        //                    IntersectPoint.x = Line1.Point_0.x + Line1.kx * Linet1
        //                    IntersectPoint.y = Line1.Point_0.y
        //                    IntersectPoint.y = Line1.Point_0.z
        //                    Return IntersectPoint
        //                    GoTo CalcEhd
        //                ElseIf Line2.ky = 0 And Line2.kz = 0 Then 'Прямая 2 лежит на оси OX
        //                    Dim Linet1 As Double = 0
        //                    Dim Linet2 As Double = 0
        //                    If Line1.ky <> 0 Then
        //                        Linet1 = (Line2.Point_0.y - Line1.Point_0.y) / Line1.ky
        //                        Linet2 = (Line1.Point_0.x + Line1.kx * Linet1 - Line2.Point_0.x) / Line2.kx
        //                    ElseIf Line1.kz <> 0 Then
        //                        Linet1 = (Line2.Point_0.z - Line1.Point_0.z) / Line1.kz
        //                        Linet2 = (Line1.Point_0.x + Line1.kx * Linet1 - Line2.Point_0.x) / Line2.kx
        //                    Else 'Такого не может быть, т.к. равенство нулю Line1.ky и Line1.kz отслеживалось на шаг раньше
        //                        MsgBox("Ошибка определения точки пересечения 3D прямых." & vbCrLf & _
        //                               "Заданные прямые совпадают или параллельны между собой.", MsgBoxStyle.Critical, "Расчет точки пересечения 3D прямых")
        //                        IntersectPoint.x = 1 / 0 : IntersectPoint.y = 1 / 0 : IntersectPoint.z = 1 / 0
        //                        Return IntersectPoint
        //                        GoTo CalcEhd
        //                    End If
        //                    IntersectPoint.x = Line2.Point_0.x + Line2.kx * Linet2
        //                    IntersectPoint.y = Line2.Point_0.y
        //                    IntersectPoint.y = Line2.Point_0.z
        //                    Return IntersectPoint
        //                    GoTo CalcEhd
        //                Else
        //                    MsgBox("Токого не может быть" & vbCrLf, MsgBoxStyle.Exclamation, "Расчет точки пересечения 3D прямых")
        //                    '????????????????????
        //                    IntersectPoint.x = 1 / 0 : IntersectPoint.y = 1 / 0 : IntersectPoint.z = 1 / 0
        //                    Return IntersectPoint
        //                    GoTo CalcEhd
        //                End If
        //            Else
        //                GoTo Calc
        //            End If
        //        Else
        //            GoTo Calc
        //        End If
        //Calc:   'Расчет 3D точки пересечения двух 3D прямых
        //        IntersectPoint.x = (Line1.kx * Line2.ky * Line1.Point_0.z + Line1.kx * Line2.kz * Line2.Point_0.y - Line1.kx * Line2.ky * Line2.Point_0.z - _
        //                     Line1.kx * Line1.Point_0.y * Line2.kz - Line1.Point_0.x * Line1.kz * Line2.ky + Line1.ky * Line1.Point_0.x * Line2.kz) / _
        //                     Denominator
        //        IntersectPoint.y = (-Line2.ky * Line1.kz * Line1.Point_0.y + Line2.ky * Line1.ky * Line1.Point_0.z + Line1.ky * Line2.kz * Line2.Point_0.y - Line1.ky * Line2.ky * Line2.Point_0.z) / Denominator
        //        IntersectPoint.z = (Line1.kz * Line2.kz * Line2.Point_0.y - Line1.kz * Line2.ky * Line2.Point_0.z - Line1.kz * Line1.Point_0.y * Line2.kz + Line1.ky * Line2.kz * Line1.Point_0.z) / Denominator
        //        Return IntersectPoint
        //CalcEhd:
        //    End Function

        //Public Overloads Function LinesAngle(ByVal Line1 As Line3D, ByVal Line2 As Line3D) As Double
        //    'Функция возвращает значения угла между двумя пересекающимися 3D прямыми
        //    Dim AngleLines As Double
        //    Dim CosAngle1, CosAngle2, CosAngle3, a, b As Double
        //    '_______________Первый способ (Решает правильно если прямые не принадлежат плоскости)_______________
        //    'Обработать ошибку принадлежности плоскости

        //    'Контроль совпадения заданных прямых + Контроль корректности задания прямых
        //    If MyClass.LinesIsLines(Line1, Line2) = True Then
        //        MsgBox("Заданные прямые совпадают" & vbCrLf, MsgBoxStyle.Exclamation, "Расчет угла между двумя пересекающимися 3D прямыми")
        //        Return 0
        //        Exit Function
        //    End If
        //    'Расчет угла
        //    CosAngle1 = (Line1.kx * Line2.kx) + (Line1.ky * Line2.ky) + (Line1.kz * Line2.kz)
        //    a = Math.Sqrt(Line1.kx ^ 2 + Line1.ky ^ 2 + Line1.kz ^ 2)
        //    b = Math.Sqrt(Line2.kx ^ 2 + Line2.ky ^ 2 + Line2.kz ^ 2)
        //    CosAngle2 = CosAngle1 / (a * b)
        //    CosAngle3 = CosAngle2
        //    If CosAngle3 > 1 Then
        //        CosAngle3 = 2 - CosAngle3
        //        AngleLines = Math.Acos(CosAngle3) * 180 / Math.PI
        //        Return AngleLines
        //    Else
        //        AngleLines = Math.Acos(CosAngle3) * 180 / Math.PI
        //        Return AngleLines
        //    End If
        //    'Rad := Grad * Pi / 180; - перевод градусов (Grad) в радианы (Rad) 
        //    'Grad := Rad * 180 / Pi; - обратный перевод 
        //End Function

        //Public Overloads Sub PerpendicularPointToLine(ByVal Line As Line3D, ByVal Point As BaseGeometryYVP.GeomObjects.Points.Point3D)
        //    'Конструктор задает перпендикуляр из 3D точки к 3D прямой
        //    Dim Line2, Line3, Line4 As New Line3D
        //    '===== Контроль инцидентности заданных точки и линии =====
        //    If MyClass.PointOfLine(Point, Line) = True Then '+ Контроль корректности задания прямой
        //        MsgBox("Ошибка построения перпендикуляра из точки «Point» к прямой «Line»." & vbCrLf & _
        //               "Заданная точка инцидентна заданной прямой.", MsgBoxStyle.Critical, "Построение из заданной 3D точки перпендикуляра к 3D прямой")
        //        'Point_0 = Nothing : kx = Nothing : ky = Nothing : kz = Nothing
        //        'A = Nothing : B = Nothing : C = Nothing
        //        MyClass.LineNon()
        //        Exit Sub
        //    End If
        //    '===================== Расчет ========================
        //    Line2.ParallelPointToLine(Line, Point) 'Из точки проводим параллель (Line2) к Line 
        //    If MyClass.TwoLinesOfPlane(Line, Line2) = True Then 'Проверяем нахождение линий в одной плоскости
        //        Line3.PerpendicularPointToTwoLines(Line, Line2, Point) 'Из точки (Point) на второй линии проводим перпендикуляр к Line и Line2
        //        If MyClass.TwoLinesOfPlane(Line, Line3) = True Then  'Проверяем нахождение линий и пепендикуляра в одной плоскости
        //            Point_0 = Point
        //            kx = Line3.kx
        //            ky = Line3.ky
        //            kz = Line3.kz
        //        Else
        //            Line4.PerpendicularPointToTwoLines(Line3, Line, Point) 'Из точки (Point) на второй линии проводим перпендикуляр к Line и Line2
        //            If MyClass.TwoLinesOfPlane(Line, Line4) = True Then 'Проверяем нахождение линий и пепендикуляра в одной плоскости
        //                Point_0 = Line4.Point_0
        //                kx = Line4.kx
        //                ky = Line4.ky
        //                kz = Line4.kz
        //            Else
        //                MsgBox("Ошибка построения перпендикуляра из точки «Point» к прямой «Line»." & vbCrLf & _
        //                       "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Построение из заданной 3D точки перпендикуляра к 3D прямой")
        //                '    Point_0 = Nothing : kx = Nothing : ky = Nothing : kz = Nothing
        //                '    A = Nothing : B = Nothing : C = Nothing
        //                MyClass.LineNon()
        //            End If
        //        End If
        //    Else
        //        MsgBox("Ошибка построения перпендикуляра из точки «Point» к прямой «Line»." & vbCrLf & _
        //               "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Построение из заданной 3D точки перпендикуляра к 3D прямой")
        //        'Point_0 = Nothing : kx = Nothing : ky = Nothing : kz = Nothing
        //        'A = Nothing : B = Nothing : C = Nothing
        //        MyClass.LineNon()
        //    End If
        //End Sub

        //    Public Overloads Sub ParallelPointToLine(ByVal Line As Line3D, ByVal Point As BaseGeometryYVP.GeomObjects.Points.Point3D)
        //        'Конструктор задает параллельную 3D прямую, проходящую через 3D точку
        //        Dim Line2 As New Line3D
        //        'Контроль корректности задания прямой
        //        If MyClass.LineFalse(Line) = True Then
        //            MsgBox("Ошибка задания прямой линии." & vbCrLf & _
        //                   "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Построение параллельной 3D прямой, проходящей через 3D точку")
        //            MyClass.LineNon()
        //            Exit Sub
        //        End If
        //        'Расчет
        //        Point_0 = Point
        //        kx = Line.kx : ky = Line.ky : kz = Line.kz
        //    End Sub

        //    Public Overloads Sub PerpendicularPointToTwoLines(ByVal Line1 As Line3D, ByVal Line2 As Line3D, ByVal Point As BaseGeometryYVP.GeomObjects.Points.Point3D)
        //        'Конструктор задает 3D прямую, проходящую через 3D точку и перпендикулярную двум 3D линиям
        //        Dim Line3, Line4 As New Line3D
        //        Dim Line3Point1, Line3Point2 As New BaseGeometryYVP.GeomObjects.Points.Point3D
        //        'Dim Angle As Double
        //        'Dim kx = m, ky = n, kz = p As Double
        //        'Контроль совпадения заданных прямых + Контроль корректности задания прямых
        //        If MyClass.LinesIsLines(Line1, Line2) = True Then
        //            MsgBox("Заданные прямые совпадают" & vbCrLf, MsgBoxStyle.Critical, "Построение из заданной 3D точки перпендикуляра к двум 3D прямым")
        //            MyClass.PerpendicularPointToLine(Line1, Point)
        //            Exit Sub
        //        End If
        //        If MyClass.LineToLineParallel(Line1, Line2) = False Then
        //            Point_0 = Point
        //            kx = Line1.ky * Line2.kz - Line2.ky * Line1.kz
        //            ky = Line2.kx * Line1.kz - Line1.kx * Line2.kz
        //            kz = Line1.kx * Line2.ky - Line2.kx * Line1.ky
        //            If kx = 0 And ky = 0 And kz = 0 Then
        //                MsgBox("Ошибка построения перпендикуляра." & vbCrLf & _
        //                       "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Построение из заданной 3D точки перпендикуляра к двум 3D прямым")
        //                MyClass.LineNon()
        //            End If
        //        Else
        //            Line3Point1 = Line1.Point_0 : Line3Point2 = Line2.Point_0
        //            Line3.LineBy2Points(Line3Point1, Line3Point2)
        //            'Angle = MyClass.LineAngle(Line1, Line3)
        //            Point_0 = Point
        //            kx = Line1.ky * Line3.kz - Line3.ky * Line1.kz
        //            ky = Line3.kx * Line1.kz - Line1.kx * Line3.kz
        //            kz = Line1.kx * Line3.ky - Line3.kx * Line1.ky
        //            If kz = 0 And kx = 0 And ky = 0 Then
        //                MsgBox("Ошибка построения перпендикуляра." & vbCrLf & _
        //                       "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Построение из заданной 3D точки перпендикуляра к двум 3D прямым")
        //                MyClass.LineNon()
        //                'Else
        //                'Line4.kx = kx : Line4.ky = ky : Line4.kz = kz : Line4.Point_0 = Point_0
        //                'Angle = MyClass.LineAngle(Line1, Line4)
        //            End If
        //        End If
        //    End Sub

        //    Public Function DirectingVector3DLine(ByVal Line As Line3D) As BaseGeometryYVP.GeomObjects.Points.Point3D
        //        'Функция возвращает значения угловых коэффициентов 3D прямой, т.е. ее направляющего вектора
        //        'Контроль корректности задания прямой
        //        If MyClass.LineFalse(Line) = True Then
        //            MsgBox("Ошибка задания прямой линии." & vbCrLf & _
        //                   "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Расчет значения угловых коэффициентов 3D прямой, т.е. ее направляющего вектора")
        //            Return New BaseGeometryYVP.GeomObjects.Points.Point3D(Nothing, Nothing, Nothing)
        //            Exit Function
        //        End If
        //        'Расчет
        //        '___Почему-то не надо делить на корень?????________________
        //        Dim CosAl, CosBt, CosGm As Double
        //        CosAl = Line.kx / Math.Sqrt(Line.kx ^ 2 + Line.ky ^ 2 + Line.kz ^ 2)
        //        CosBt = Line.ky / Math.Sqrt(Line.kx ^ 2 + Line.ky ^ 2 + Line.kz ^ 2)
        //        CosGm = Line.kz / Math.Sqrt(Line.kx ^ 2 + Line.ky ^ 2 + Line.kz ^ 2)
        //        Return New BaseGeometryYVP.GeomObjects.Points.Point3D(CosAl, CosBt, CosGm)
        //    End Function

        //    Public Overloads Function DistantionPointToLine(ByVal Line As Line3D, ByVal Point As BaseGeometryYVP.GeomObjects.Points.Point3D) As Double
        //        'Функция возвращает величину расстояния от заданной 3D точки до 3D прямой
        //        Dim DistPtLn As Double 'Рассчитывается по треугольнику
        //        Dim l_12, l_23, l_13, Perimetr, S As Double
        //        Dim LinePt2 As New BaseGeometryYVP.GeomObjects.Points.Point3D 'Вторая точка линии
        //        Dim L As New BaseGeometryYVP.GeomObjects.Points.Point3D
        //        'Контроль корректности задания прямой
        //        If MyClass.LineFalse(Line) = True Then
        //            MsgBox("Ошибка задания прямой линии." & vbCrLf & _
        //                   "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Расчет расстояния от заданной 3D точки до 3D прямой")
        //            Return Nothing
        //            Exit Function
        //        End If
        //        'Расчет
        //        LinePt2.x = Line.kx + Line.Point_0.x : LinePt2.y = Line.ky + Line.Point_0.y
        //        LinePt2.z = Line.kz + Line.Point_0.z
        //        'Рассчитываем длины сторон треугольника
        //        l_12 = L.PointDistantion(Line.Point_0, LinePt2)
        //        l_13 = L.PointDistantion(Line.Point_0, Point) : l_23 = L.PointDistantion(LinePt2, Point)
        //        Perimetr = (l_12 + l_13 + l_23) / 2
        //        S = Math.Sqrt(Perimetr * (Perimetr - l_12) * (Perimetr - l_13) * (Perimetr - l_23)) 'Площадь треугольника
        //        DistPtLn = S * 2 / l_12 'Расстояние как высота треугольника
        //        Return DistPtLn
        //    End Function

        //    Public Function LineToLineParallel(ByVal Line1 As Line3D, ByVal Line2 As Line3D) As Boolean
        //        'Функция возвращает значение "TRUE" если две 3D прямые взаимно параллельны
        //        'Dim m1, m2, n1, n2, p1, p2 As Double
        //        If MyClass.TwoLinesOfPlane(Line1, Line2) = True Then
        //            If Line2.kx = 0 Or Line2.ky = 0 Or Line2.kz = 0 Then
        //                If Line1.kx = 0 Or Line1.ky = 0 Or Line1.kz = 0 Then
        //                    GoTo CalcZeroPlane
        //                Else
        //                    If Line2.kx / Line1.kx = Line2.ky / Line1.ky And Line2.kx / Line1.kx = Line2.kz / Line1.kz And Line2.ky / Line1.ky = Line2.kz / Line1.kz Then
        //                        Return True
        //                        GoTo CalcEnd
        //                    Else
        //                        Return False
        //                        GoTo CalcEnd
        //                    End If
        //                End If
        //            Else
        //                If Line1.kx / Line2.kx = Line1.ky / Line2.ky And Line1.kx / Line2.kx = Line1.kz / Line2.kz And Line1.ky / Line2.ky = Line1.kz / Line2.kz Then
        //                    Return True
        //                    GoTo CalcEnd
        //                Else
        //                    Return False
        //                    GoTo CalcEnd
        //                End If
        //            End If
        //CalcZeroPlane:
        //            If Line2.kx = 0 And Line2.ky = 0 Then
        //                If Line1.kx <> 0 Or Line1.ky <> 0 Then
        //                    Return False
        //                Else
        //                    Return True
        //                    GoTo CalcEnd
        //                End If
        //            ElseIf Line2.kx = 0 And Line2.kz = 0 Then
        //                If Line1.kx <> 0 Or Line1.kz <> 0 Then
        //                    Return False
        //                Else
        //                    Return True
        //                    GoTo CalcEnd
        //                End If
        //            ElseIf Line2.ky = 0 And Line2.kz = 0 Then
        //                If Line1.ky <> 0 Or Line1.kz <> 0 Then
        //                    Return False
        //                Else
        //                    Return True
        //                    GoTo CalcEnd
        //                End If
        //            Else
        //                GoTo CalcZeroOsi
        //            End If
        //CalcZeroOsi:
        //            If Line2.kx = 0 Then
        //                If Line1.kx <> 0 Then
        //                    Return False
        //                Else
        //                    If Line1.ky / Line2.ky = Line1.kz / Line2.kz Then
        //                        Return True
        //                        GoTo CalcEnd
        //                    Else
        //                        Return False
        //                        GoTo CalcEnd
        //                    End If
        //                End If
        //            End If
        //            If Line2.ky = 0 Then
        //                If Line1.ky <> 0 Then
        //                    Return False
        //                Else
        //                    If Line1.kx / Line2.kx = Line1.kz / Line2.kz Then
        //                        Return True
        //                        GoTo CalcEnd
        //                    Else
        //                        Return False
        //                        GoTo CalcEnd
        //                    End If
        //                End If
        //            End If
        //            If Line2.kz = 0 Then
        //                If Line1.kz <> 0 Then
        //                    Return False
        //                Else
        //                    If Line1.kx / Line2.kx = Line1.ky / Line2.ky Then
        //                        Return True
        //                        GoTo CalcEnd
        //                    Else
        //                        Return False
        //                        GoTo CalcEnd
        //                    End If
        //                End If
        //            End If
        //        Else
        //            Return False
        //        End If
        //CalcEnd:
        //    End Function

        //    Public Overloads Function LineToLineIntersect(ByVal Line1 As Line3D, ByVal Line2 As Line3D) As Boolean
        //        'Функция возвращает значение "TRUE" если две 3D прямые пересекаются
        //        If MyClass.TwoLinesOfPlane(Line1, Line2) = True Then '+ Контроль корректности задания прямой
        //            If MyClass.LineToLineParallel(Line1, Line2) = True Then
        //                Return False
        //            Else
        //                Return True
        //            End If
        //        Else
        //            Return False
        //        End If
        //        'Для расчета с использованием коээфициентов прямых, но надо обработать "деление на ноль"
        //        'If Line1.kx / Line2.kx <> Line1.ky / Line2.ky And Line1.kx / Line2.kx <> Line1.kz / Line2.kz And Line1.ky / Line2.ky <> Line1.kz / Line2.kz Then
        //        '    Return True
        //        'Else
        //        '    Return False
        //        'End If
        //    End Function

        //    Public Function LineToLineCrossing(ByVal Line1 As Line3D, ByVal Line2 As Line3D) As Boolean
        //        'Функция возвращает значение "TRUE" если две 3D прямые скрещиваются
        //        If MyClass.TwoLinesOfPlane(Line1, Line2) = False Then
        //            Return True
        //        Else
        //            Return False
        //        End If
        //    End Function

        //    Public Function LineToLinePerpendiculare(ByVal Line1 As Line3D, ByVal Line2 As Line3D) As Boolean
        //        'Функция возвращает значение "TRUE" если две 3D прямые перпендикулярны друг другу
        //        'Контроль корректности задания прямой
        //        Dim Var As Double
        //        If MyClass.LineFalse(Line1) = True Or MyClass.LineFalse(Line2) = True Then
        //            MsgBox("Ошибка задания прямых линий." & vbCrLf & _
        //                   "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль перпендикулярности 3D прямых")
        //            Return Nothing
        //            Exit Function
        //        End If
        //        'Расчет
        //        Var = Line1.kx * Line2.kx + Line1.ky * Line2.ky + Line1.kz * Line2.kz
        //        If Var = 0 Then 'Условие перпендикулярности прямых
        //            Return True
        //        Else
        //            Return False
        //        End If
        //    End Function

        //    Public Function DistantionLineToLine(ByVal Line1 As Line3D, ByVal Line2 As Line3D) As Double
        //        'Функция, возвращающая величину расстояния между двумя 3D прямыми
        //        Dim Line3 As New Line3D : Dim Line4 As New Line3D
        //        Dim Point1Line3_0 As New BaseGeometryYVP.GeomObjects.Points.Point3D : Dim Point2Line3_0 As New BaseGeometryYVP.GeomObjects.Points.Point3D
        //        Dim DistPoint3D As New BaseGeometryYVP.GeomObjects.Points.Point3D
        //        Dim DistLin As New Double
        //        Dim Agl As New Double

        //        If MyClass.TwoLinesOfPlane(Line1, Line2) = True Then 'Проверяем нахождение линий в одной плоскости
        //            If MyClass.LineToLineIntersect(Line1, Line2) = True Then 'Прямые пересекаются
        //                Return 0
        //            Else
        //                If MyClass.LineToLineParallel(Line1, Line2) = True Then  'Прямые параллельны
        //                    DistLin = MyClass.DistantionPointToLine(Line2, Line1.Point_0)
        //                    Return DistLin
        //                Else
        //                    MsgBox("Ошибка построения прямой линии." & vbCrLf & _
        //                           "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Расчет расстояния между двумя 3D прямыми")

        //                    Return Nothing
        //                End If
        //            End If
        //        Else 'Если MyClass.TwoLineInPlane(Line1, Line2) = False, то прямые скрещиваются.
        //            'Тогда переходим к следующему расчету:
        //            'n - направляющий вектор прямой, задаваемый уравнением n=i*kx+j*ky+k*kz
        //            Dim i, j, k, n_kx, n_ky, n_kz As Double
        //            i = Line2.Point_0.x - Line1.Point_0.x
        //            j = Line2.Point_0.y - Line1.Point_0.y
        //            k = Line2.Point_0.z - Line1.Point_0.z

        //            n_kx = Line1.ky * Line2.kz - Line2.ky * Line1.kz
        //            n_ky = Line2.kx * Line1.kz - Line1.kx * Line2.kz
        //            n_kz = Line1.kx * Line2.ky - Line2.kx * Line1.ky
        //            If Math.Sqrt(n_kx ^ 2 + n_ky ^ 2 + n_kz ^ 2) = 0 Then 'Обработка деления на ноль
        //                MsgBox("Ошибка задания исходных прямых линий." & vbCrLf, MsgBoxStyle.Critical, "Расчет расстояния между двумя 3D прямыми")
        //                Return Nothing
        //            Else
        //                DistLin = (Math.Abs(i * n_kx + j * n_ky + k * n_kz)) / Math.Sqrt(n_kx ^ 2 + n_ky ^ 2 + n_kz ^ 2)
        //                Return DistLin
        //            End If
        //        End If
        //    End Function

        //    Public Function LineOfFramePlane(ByVal Line As Line3D) As Boolean
        //        'Функция возвращает значение "TRUE" если 3D прямая лежит в плоскости базовой системы координат
        //        'Контроль корректности задания прямой
        //        If MyClass.LineFalse(Line) = True Then
        //            MsgBox("Ошибка задания прямой линии." & vbCrLf & _
        //                   "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль инцидентности 3D прямой и базовой плоскости")
        //            Return Nothing
        //            Exit Function
        //        End If
        //        'Расчет
        //        If Line.Point_0.x = 0 And Line.kx = 0 Or Line.Point_0.y = 0 And Line.ky = 0 Or Line.Point_0.z = 0 And Line.kz = 0 Then
        //            MsgBox("Проверь верность данного расчета." & vbCrLf & _
        //                   "?????????? Неправильно! ????????????", MsgBoxStyle.Critical, "Контроль инцидентности 3D прямой и базовой плоскости")
        //            Return True
        //        Else
        //            Return False
        //        End If
        //    End Function

        //    Public Overloads Function PointOfLine(ByVal Point As BaseGeometryYVP.GeomObjects.Points.Point3D, ByVal Line As Line3D) As Boolean
        //        'Функция возвращает значение "TRUE" если точка принадлежит 3D прямой
        //        'Контроль корректности задания прямой
        //        If MyClass.LineFalse(Line) = True Then
        //            MsgBox("Ошибка задания прямой линии." & vbCrLf & _
        //                   "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль инцидентности 3D точки и 3D прямой")
        //            Return Nothing
        //            Exit Function
        //        End If
        //        'Расчет
        //        If Format((Point.x - Line.Point_0.x) * Line.ky, "##########.#####") = Format((Point.y - Line.Point_0.y) * Line.kx, "##########.#####") And _
        //           Format((Point.x - Line.Point_0.x) * Line.kz, "##########.#####") = Format((Point.z - Line.Point_0.z) * Line.kx, "##########.#####") And _
        //            Format((Point.y - Line.Point_0.y) * Line.kz, "##########.#####") = Format((Point.z - Line.Point_0.z) * Line.ky, "##########.#####") Then
        //            Return True
        //        Else
        //            Return False
        //        End If
        //    End Function

        //    'Public Function TwoLinesOfPlane(ByVal Line1 As Line3D, ByVal Line2 As Line3D) As Boolean
        //    '    'Функция возвращает значение "TRUE" если две 3D прямые находятся в одной плоскости
        //    '    'II способ. Проверен.
        //    '    Dim d, d1, d2, d3 As Double
        //    '    'Контроль корректности задания прямых
        //    '    If MyClass.LineFalse(Line1) = True Or MyClass.LineFalse(Line2) = True Then
        //    '        MsgBox("Ошибка задания прямых линий." & vbCrLf & _
        //    '               "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль инцидентности двух 3D прямых одной плоскости")
        //    '        Return Nothing
        //    '        Exit Function
        //    '    End If
        //    '    'Расчет
        //    '    d1 = (Line2.Point_0.x - Line1.Point_0.x) * (Line1.ky * Line2.kz - Line2.ky * Line1.kz)
        //    '    d2 = Line1.kx * (Line2.ky * (Line2.Point_0.z - Line1.Point_0.z) - (Line2.Point_0.y - Line1.Point_0.y) * Line2.kz)
        //    '    d3 = Line2.kx * ((Line2.Point_0.y - Line1.Point_0.y) * Line1.kz - Line1.ky * (Line2.Point_0.z - Line1.Point_0.z))
        //    '    d = d1 + d2 + d3
        //    '    If d = 0 Or Math.Abs(d) < 0.001 Then
        //    '        Return True
        //    '    Else
        //    '        Return False
        //    '    End If
        //    'End Function

        //    Public Function TwoLinesOfPlane(ByVal Line1 As Line3D, ByVal Line2 As Line3D) As Boolean
        //        'Функция возвращает значение "TRUE" если две 3D прямые лежат в одной плоскости
        //        'I способ. Проверен.
        //        'Контроль корректности задания прямой
        //        If MyClass.LineFalse(Line1) = True Or MyClass.LineFalse(Line2) = True Then
        //            MsgBox("Ошибка задания прямой линии." & vbCrLf & _
        //                   "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль инцидентности двух 3D прямых одной плоскости")
        //            Return Nothing
        //            Exit Function
        //        End If
        //        'Расчет
        //        Dim LinesDx, LinesDy, LinesDz, Det As Double
        //        Dim DetLines(2, 2) As Double
        //        Dim MrxVar As New MatrixCalc
        //        LinesDx = Line2.Point_0.x - Line1.Point_0.x : LinesDy = Line2.Point_0.y - Line1.Point_0.y : LinesDz = Line2.Point_0.z - Line1.Point_0.z
        //        DetLines.SetValue(LinesDx, 0, 0) : DetLines.SetValue(LinesDy, 0, 1) : DetLines.SetValue(LinesDz, 0, 2)
        //        DetLines.SetValue(Line1.kx, 1, 0) : DetLines.SetValue(Line1.ky, 1, 1) : DetLines.SetValue(Line1.kz, 1, 2)
        //        DetLines.SetValue(Line2.kx, 2, 0) : DetLines.SetValue(Line2.ky, 2, 1) : DetLines.SetValue(Line2.kz, 2, 2)
        //        Det = MrxVar.detMrx3x3(DetLines)
        //        If Det = 0 Then 'Может возникнуть, обусловленная точностью расчета
        //            Return True
        //        Else
        //            Return False
        //        End If
        //    End Function

        //    Public Overloads Function LinesIsLines(ByVal Line1 As Line3D, ByVal Line2 As Line3D) As Boolean
        //        'Функция возвращает значение "TRUE", если две прямые совпадают
        //        Dim PointLine1_2 As New BaseGeometryYVP.GeomObjects.Points.Point3D
        //        Dim LineVar As New Line3D
        //        Dim Var1, Var2 As Boolean
        //        'Контроль корректности задания прямых
        //        If MyClass.LineFalse(Line1) = True Or MyClass.LineFalse(Line2) = True Then
        //            MsgBox("Ошибка задания прямых линий." & vbCrLf & _
        //                   "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль совпадения двух 3D прямых")
        //            Return Nothing
        //            Exit Function
        //        End If
        //        'Расчет
        //        PointLine1_2 = Line1.GetPoint(1) 'Задание второй точки на первой прямой
        //        'Проверка принадлежности двух точек, заданных на первой прямой ко второй прямой
        //        Var1 = LineVar.PointOfLine(Line1.Point_0, Line2)
        //        Var2 = LineVar.PointOfLine(PointLine1_2, Line2)
        //        If Var1 = True And Var2 = True Then
        //            Return True
        //        Else
        //            Return False
        //        End If
        //    End Function

        //    Public Overloads Function LinesIsLines(ByVal Lines() As Line3D) As Boolean
        //        'Функция возвращает значение "TRUE", если совпадают все прямые, заданные в массиве 
        //        'Dim Var As Boolean
        //        'Обработка деления на ноль
        //        'Реализовать циклом
        //        'Реализовать в 2D и 3D классах
        //        '+ Реализовать совпадение точек в 2D и 3D классах и плоскостей

        //        'Return True
        //    End Function

        //    Public Function DirectionLine1ToLine2(ByVal Line1 As Line3D, ByVal Line2 As Line3D) As Boolean
        //        'Функция возвращает значение "TRUE", если направления заданных прямых совпадают
        //        Dim PointLine1, PointLine2 As New BaseGeometryYVP.GeomObjects.Points.Point3D
        //        Dim NewLine1, LineVarNew As New Line3D
        //        'Контроль совпадения и корректности задания прямых
        //        If MyClass.LinesIsLines(Line1, Line2) = False Then
        //            MsgBox("Ошибка задания прямых линий." & vbCrLf & _
        //                   "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль определения направления двух 3D прямых")
        //            Return Nothing
        //            Exit Function
        //        End If
        //        'Перенос базовой точки второй прямой в базовую точку первой прямой
        //        NewLine1.ParallelPointToLine(Line2, Line1.Point_0)
        //        'Задание точки на первой прямой (t - положительное)
        //        PointLine2 = Line1.GetPoint(10)
        //        'Расчет параметра t2 второй прямой
        //        Dim t2 As Double
        //        t2 = LineVarNew.GetLine_t(NewLine1, PointLine2)
        //        'Контроль значения t
        //        If t2 > 0 Then
        //            Return True
        //        Else
        //            Return False
        //        End If
        //    End Function

        //=============================================================================================================================================================
        //===================================== Функции расчета 3D прямой на основе ее проекций в системе координат Монжа =============================================
        //=============================================================================================================================================================

        /// <summary>Возвращаеет проекцию 3D прямой на плоскость X0Y пространственной системы координат</summary>
        /// <remarks></remarks>
        public LineOfPlan1X0Y PointOf_1PlanX0Y(Line3D Line3D_Source)
        {
            LineOfPlan1X0Y LineVar = new LineOfPlan1X0Y(Line3D_Source);
            return LineVar;
        }

        /// <summary>Возвращает проекцию 3D прямой на плоскость X0Y пространственной системы координат</summary>
        /// <remarks></remarks>
        public LineOfPlan2X0Z PointOf_2PlanX0Z(Line3D Line3D_Source)
        {
            GeomObjects.Lines.LineOfPlan2X0Z LineVar = new GeomObjects.Lines.LineOfPlan2X0Z(Line3D_Source);
            return LineVar;
        }

        /// <summary>Возвращает проекцию 3D прямой на плоскость X0Y пространственной системы координат</summary>
        /// <remarks></remarks>
        public LineOfPlan3Y0Z PointOf_3PlanY0Z(Line3D Line3D_Source)
        {
            GeomObjects.Lines.LineOfPlan3Y0Z LineVar = new GeomObjects.Lines.LineOfPlan3Y0Z(Line3D_Source);
            return LineVar;
        }

        /// <summary>Конвертирует проекцию 3D прямой в GeomObjects.Line2D</summary>
        /// <remarks></remarks>
        public Line2D PointOfPlan_ToPoint2D(LineOfPlan1X0Y Point_Source)
        {
            GeomObjects.Lines.LineOfPlan1X0Y LineVar = new GeomObjects.Lines.LineOfPlan1X0Y();
            return LineVar.CnvLine2D(Point_Source);
        }

        /// <summary>Конвертирует проекцию 3D прямой в GeomObjects.Line2D</summary>
        /// <remarks></remarks>
        public Line2D PointOfPlan_ToPoint2D(LineOfPlan2X0Z Point_Source)
        {
            GeomObjects.Lines.LineOfPlan2X0Z LineVar = new GeomObjects.Lines.LineOfPlan2X0Z();
            return LineVar.CnvLine2D(Point_Source);
        }

        /// <summary> Конвертирует проекцию 3D прямой в GeomObjects.Line2D</summary>
        /// <remarks></remarks>
        public Line2D PointOfPlan_ToPoint2D(LineOfPlan3Y0Z Point_Source)
        {
            GeomObjects.Lines.LineOfPlan3Y0Z LineVar = new GeomObjects.Lines.LineOfPlan3Y0Z();
            return LineVar.CnvLine2D(Point_Source);
        }


    }
}
