using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualBasic;
using GeomObjects.Lines;

namespace GeomObjects.Plans
{
    public class PlaneSpace
    {
        //Inherits BaseGeometryYVP.GeomObjects.Lines.Line3D
        //Начальная точка плоскости
        public GeomObjects.Points.Point3D PlaneCentre = new GeomObjects.Points.Point3D();
        public double A;
        public double B;
        public double C;
        //Коэффициенты уравнения общего вида плоскости
        public double D;
        //Точность расчетов
        public double SolveErrorPl = 0.001;

        public PlaneSpace()
        {
            //Конструктор создания базовой (XY) плоскости с началом в точке (0,0,0)
            dynamic ZeroAxis1 = default(GeomObjects.Lines.Line3D);
            GeomObjects.Lines.Line3D ZeroAxis2 = new GeomObjects.Lines.Line3D();
            dynamic PlaneCentre = default(GeomObjects.Points.Point3D);
            dynamic Pt1 = default(GeomObjects.Points.Point3D);
            GeomObjects.Points.Point3D Pt2 = new GeomObjects.Points.Point3D();
            //Установка начальной точки системы координат
            ZeroAxis1.kx = 1;
            ZeroAxis1.ky = 0;
            ZeroAxis1.kz = 0;
            //Ось 1(X)
            ZeroAxis2.kx = 0;
            ZeroAxis2.ky = 1;
            ZeroAxis2.kz = 0;
            //Ось 2(Y)
            this.PlaneSpaceCreation(PlaneCentre, ZeroAxis1.GetPoint(10), ZeroAxis2.GetPoint(10));
        }

        public PlaneSpace(double A, double B, double C, double D, GeomObjects.Points.Point3D PlaneCentre)
        {
            //Конструктор создания плоскости по заданным постоянным коэффициентам с началом в заданной точке
            PlaneSpace Plane = new PlaneSpace();
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
            this.PlaneCentre = PlaneCentre;
            //Контроль принадлежности заданной точки заданной плоскости
            Plane.A = this.A;
            Plane.B = this.B;
            Plane.C = this.C;
            Plane.D = this.D;
            Plane.PlaneCentre.X = this.A;
            Plane.PlaneCentre.Y = this.B;
            Plane.PlaneCentre.Z = this.C;
            if (this.PointOfPlanePosition(PlaneCentre, Plane) != 0)
            {
                this.PlaneCentre = null;
            }
        }

        public PlaneSpace(double A, double B, double C, double D)
        {
            //Конструктор создания плоскости по заданным постоянным коэффициентам
            //Dim FrameZeroPoint, PointPlane1 As New BaseGeometryYVP.GeomObjects.Points.Point3D
            //Dim Plane1 As New PlaneSpace
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
            //Задание постоянных коэффициентов плоскости
            //PerpendicularPointToPlane(FrameZeroPoint, Plane1) 'Прямая, инидентная нормальному вектору первой плоскости 
            //PointPlane1 = IntersectionPoint_LineAndPlan(PerpendicularPointToPlane(FrameZeroPoint, Plane1), Plane1) 'Точка пересечения нормального вектора с заданной плоскостью
            //MyClass.PlaneCentre = PointPlane1
            this.PlaneCentre.X = A;
            this.PlaneCentre.Y = B;
            this.PlaneCentre.Z = C;
        }

        public PlaneSpace(GeomObjects.Points.Point3D Point1, GeomObjects.Points.Point3D Point2, GeomObjects.Points.Point3D Point3)
        {
            //Конструктор создания плоскости по трем точкам
            //"Overloads PlaneSpaceCreation"
            double[,] MrxPt = new double[2, 3];
            MatrixEvalution MrxVar = new MatrixEvalution();
            dynamic LineVar = default(GeomObjects.Lines.Line3D);
            dynamic Line1 = default(GeomObjects.Lines.Line3D);
            dynamic Line2 = default(GeomObjects.Lines.Line3D);
            GeomObjects.Lines.Line3D Line3 = new GeomObjects.Lines.Line3D();
            GeomObjects.Points.Point3D PtPeres = new GeomObjects.Points.Point3D();
            //Dim PlaneCentre = New BaseGeometryYVP.GeomObjects.Points.Point3D
            //Контроль совпадения точек
            if ((Point1.X == Point2.X & Point1.Y == Point2.Y & Point1.Z == Point2.Z) | (Point1.X == Point3.X & Point1.Y == Point3.Y & Point1.Z == Point3.Z) | (Point2.X == Point3.X & Point2.Y == Point3.Y & Point2.Z == Point3.Z))
            {
                Interaction.MsgBox("Не удается задать плоскость по трем точкам." + Constants.vbCrLf + "Некоторые или все заданные точки совпадают.", MsgBoxStyle.Exclamation, "Конструктор задания плоскости по трем точкам");
                PlaneCentre = null;
                return;
            }
            //Контроль принадлежности точек одной прямой
            MrxPt.SetValue((Point2.X - Point1.X), 0, 0);
            MrxPt.SetValue((Point2.Y - Point1.Y), 0, 1);
            MrxPt.SetValue((Point2.Z - Point1.Z), 1, 2);
            MrxPt.SetValue((Point3.X - Point1.X), 1, 0);
            MrxPt.SetValue((Point3.Y - Point1.Y), 1, 1);
            MrxPt.SetValue((Point3.Z - Point1.Z), 1, 2);
            if (MrxVar.RangMrxMxN(MrxPt) == 2)
            {
                A = Point1.Y * (Point2.Z - Point3.Z) + Point2.Y * (Point3.Z - Point1.Z) + Point3.Y * (Point1.Z - Point2.Z);
                //Коэффициент при X
                B = Point1.Z * (Point2.X - Point3.X) + Point2.Z * (Point3.X - Point1.X) + Point3.Z * (Point1.X - Point2.X);
                //Коэффициент при Y
                C = Point1.X * (Point2.Y - Point3.Y) + Point2.X * (Point3.Y - Point1.Y) + Point3.X * (Point1.Y - Point2.Y);
                //Коэффициент при Z
                D = (Point1.X * (Point2.Y * Point3.Z - Point3.Y * Point2.Z) + Point2.X * (Point3.Y * Point1.Z - Point1.Y * Point3.Z) + Point3.X * (Point1.Y * Point2.Z - Point2.Y * Point1.Z)) / -1;
                //Свободный коэффициент 
                this.PlaneCentre.X = A;
                this.PlaneCentre.Y = B;
                this.PlaneCentre.Z = C;
            }
            else if (MrxVar.RangMrxMxN(MrxPt) == 1)
            {
                Interaction.MsgBox("Не удается задать плоскость по трем точкам." + Constants.vbCrLf + "Исходные точки принадлежат одной прямой.", MsgBoxStyle.Exclamation, "Конструктор задания плоскости по трем точкам");
                this.PlaneSpaceNon();
            }
            else
            {
                Interaction.MsgBox("Не удается задать плоскость по трем точкам." + Constants.vbCrLf + "Проверьте исходные данные.", MsgBoxStyle.Exclamation, "Конструктор задания плоскости по трем точкам");
                this.PlaneSpaceNon();
            }
            //Коррекция коэффициентов плоскости решением системы линейных уравнений
            //!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!
        }

        public PlaneSpace(GeomObjects.Lines.Line3D Line, GeomObjects.Points.Point3D Point)
        {
            //Конструктор задания плоскости точкой и прямой
            //Переменная для работы с контролем прямой
            GeomObjects.Points.Point3D BasePoint = new GeomObjects.Points.Point3D();
            //Контроль взаимного положения точки и прямой + контроль корректности задания прямой
            //Если точка принадлежит прямой
            if (LinePositionControl.PointOfLine(Point, Line) == true)
            {
                Interaction.MsgBox("Не удается задать плоскость по точке и прямой." + Constants.vbCrLf + "Точка не должна принадлежать прямой.", MsgBoxStyle.Exclamation, "Конструктор задания плоскости по точке и прямой");
                //PlaneCentre = Nothing : A = Nothing : B = Nothing : C = Nothing : D = Nothing
                this.PlaneSpaceNon();
            }
            else
            {
                BasePoint = Line.GetPoint(10);
                //Задание некоторой точки на прямой
                this.PlaneSpaceCreation(Line.Point_0, BasePoint, Point);
                //Расчет коэффициентов плоскости
            }
        }

        public PlaneSpace(GeomObjects.Lines.Line3D Line1, GeomObjects.Lines.Line3D Line2)
        {
            //Конструктор задания плоскости двумя прямыми
            //"Overloads PlaneSpaceCreation"
            dynamic LinesVal = default(GeomObjects.Lines.Line3D);
            GeomObjects.Lines.Line3D IntersectLines = new GeomObjects.Lines.Line3D();


            dynamic BasePoint1 = default(GeomObjects.Points.Point3D);
            dynamic BasePoint2 = default(GeomObjects.Points.Point3D);
            dynamic PtIntersectLines = default(GeomObjects.Points.Point3D);
            GeomObjects.Points.Point3D PointVar = new GeomObjects.Points.Point3D();
            //Контроль взаимного положения прямых + контроль корректности задания прямых
            //Если прямые пересекаются
            if (LinePositionControl.LineToLineIntersect(Line1, Line2) == true)
            {
                //'Первый способ по трем точкам, принадлежащим прямым (менее точный)
                //'Проверка совпадения базовых точек прямых
                //If PointVar.PointsIsPoints(Line1.Point_0, Line2.Point_0) = True Then 'Если базовые точки совпадают
                //    'Задание новых точек на прямых
                //    BasePoint1 = Line1.GetPoint(1)
                //    BasePoint2 = Line2.GetPoint(-1)
                //    MyClass.PlaneSpaceCreation(Line1.Point_0, BasePoint1, BasePoint2) 'Расчет коэффициентов плоскости
                //Else  'Если базовые точки не совпадают
                //    BasePoint1 = Line1.GetPoint(1) 'Задание третьей точки на первой прямой
                //    'Контроль совпадения заданной третьей точки и базовой точки второй прямой
                //    If PointVar.PointsIsPoints(BasePoint1, Line2.Point_0) = True Then 'Если заданная третья точка совпадает с базовой точкой 
                //        BasePoint2 = Line2.GetPoint(1) 'Задание третьей точки на второй прямой
                //        MyClass.PlaneSpaceCreation(Line1.Point_0, Line2.Point_0, BasePoint2) 'Расчет коэффициентов плоскости
                //    End If
                //    MyClass.PlaneSpaceCreation(Line1.Point_0, Line2.Point_0, BasePoint1) 'Расчет коэффициентов плоскости
                //End If
                //Второй способ - по двум пересекающимся прямым и точке (пересечения прямых)
                PtIntersectLines = LinesCalculator.LinesIntersectPoint(Line1, Line2);
                this.ParallelePlaneTo2LineFromPoint(PtIntersectLines, Line1, Line2);
                //Если прямые параллельны
            }
            else if (LinePositionControl.LineToLineParallel(Line1, Line2) == true)
            {
                //Первый способ - по трем точкам (плохо работает)
                //BasePoint2 = Line2.GetPoint(1) 'Задание некоторой точки на второй прямой
                //MyClass.PlaneSpaceCreation(Line1.Point_0, Line2.Point_0, BasePoint2) 'Расчет коэффициентов плоскости
                //Второй способ - по двум параллельным прямым и точке
                IntersectLines.PerpendicularPointToLine(Line2, Line1.Point_0);
                this.ParallelePlaneTo2LineFromPoint(Line1.Point_0, Line1, IntersectLines);
                //Если прямые совпадают
            }
            else if (LinePositionControl.LinesIsLines(Line1, Line2) == true)
            {
                Interaction.MsgBox("Не удается задать плоскость по двум прямым." + Constants.vbCrLf + "Заданные прямые совпадают.", MsgBoxStyle.Exclamation, "Конструктор задания плоскости по двум прямым");
                //PlaneCentre = Nothing : A = Nothing : B = Nothing : C = Nothing : D = Nothing
                this.PlaneSpaceNon();
                //Если прямые скрещиваются
            }
            else
            {
                Microsoft.VisualBasic.MsgBoxResult msgRes = new Microsoft.VisualBasic.MsgBoxResult();
                msgRes = Interaction.MsgBox("Заданные прямые скрещиваются." + Constants.vbCrLf + "Для построения плоскости необходимо указать одну из заданных прямых." + Constants.vbCrLf + "При этом указанная прямая будет принадлежать задаваемой плоскости," + Constants.vbCrLf + "а другая прямоая будет параллельна этой плоскости." + Constants.vbCrLf + "Если первая прямая     - нажмите «Ok»" + Constants.vbCrLf + "Если вторая            - нажмите «No»" + Constants.vbCrLf + "Не задавать плоскость  - нажмите «Cancel»", MsgBoxStyle.YesNoCancel, "Конструктор задания плоскости по двум прямым");
                //PlaneCentre = Nothing : A = Nothing : B = Nothing : C = Nothing : D = Nothing
                if (msgRes == Microsoft.VisualBasic.MsgBoxResult.Yes)
                {
                    this.ParallelePlaneTo2LineFromPoint(Line1.Point_0, Line1, Line2);
                }
                else if (msgRes == MsgBoxResult.No)
                {
                    this.ParallelePlaneTo2LineFromPoint(Line2.Point_0, Line1, Line2);
                }
                else if (msgRes == MsgBoxResult.Cancel)
                {
                    this.PlaneSpaceNon();
                }
            }
            //Коррекция коэффициентов плоскости решением системы линейных уравнений
            //!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!
        }

        public PlaneSpace(GeomObjects.Lines.Line3D Line1, GeomObjects.Lines.Line3D Line2, GeomObjects.Lines.Line3D Line3)
        {
            //Конструктор задания плоскости тремя прямыми
            GeomObjects.Lines.Line3D LinesVal = new GeomObjects.Lines.Line3D();
            //Переменная для работы с прямой
            //Переменная для работы с расчетом прямой

            dynamic BasePoint1 = default(GeomObjects.Points.Point3D);
            dynamic BasePoint2 = default(GeomObjects.Points.Point3D);
            GeomObjects.Points.Point3D BasePoint3 = new GeomObjects.Points.Point3D();
            //Контроль взаимного положения прямых + контроль корректности задания прямых
            //Если любые из заданных прямых скрещиваются
            if (LinePositionControl.LineToLineCrossing(Line1, Line2) == true | LinePositionControl.LineToLineCrossing(Line1, Line3) == true | LinePositionControl.LineToLineCrossing(Line2, Line3) == true)
            {
                Interaction.MsgBox("Не удается задать плоскость по трем прямым." + Constants.vbCrLf + "Заданные прямые скрещиваются.", MsgBoxStyle.Critical, "Конструктор задания плоскости по трем прямым");
                //PlaneCentre = Nothing : A = Nothing : B = Nothing : C = Nothing : D = Nothing
                this.PlaneSpaceNon();
                return;
                //Если все заданные прямые совпадают
            }
            else if (LinePositionControl.LinesIsLines(Line1, Line2) == true & LinePositionControl.LinesIsLines(Line2, Line2) == true)
            {
                Interaction.MsgBox("Не удается задать плоскость по трем прямым." + Constants.vbCrLf + "Все заданные прямые совпадают.", MsgBoxStyle.Critical, "Конструктор задания плоскости по трем прямым");
                //PlaneCentre = Nothing : A = Nothing : B = Nothing : C = Nothing : D = Nothing
                this.PlaneSpaceNon();
                return;
                //Если любые из заданных прямых параллельны друг другу
            }
            else if (LinePositionControl.LineToLineParallel(Line1, Line2) == true | LinePositionControl.LineToLineParallel(Line1, Line3) == true | LinePositionControl.LineToLineParallel(Line2, Line3) == true)
            {
                //Если 1-я и 2-я параллельны 3-й и совпадают друг с другом
                if (LinePositionControl.LinesIsLines(Line1, Line2) == true)
                {
                    this.PlaneSpaceCreation(Line1, Line3);
                    //Если 1-я и 3-я параллельны 2-й и совпадают друг с другом или если 2-я и 3-я параллельны 1-й и совпадают друг с другом
                }
                else
                {
                    this.PlaneSpaceCreation(Line1, Line2);
                }
            }
            else
            {
                BasePoint1 = LinesCalculator.LinesIntersectPoint(Line1, Line2);
                BasePoint2 = LinesCalculator.LinesIntersectPoint(Line1, Line3);
                BasePoint3 = LinesCalculator.LinesIntersectPoint(Line2, Line3);
                this.PlaneSpaceCreation(BasePoint1, BasePoint2, BasePoint3);
                //Коррекция коэффициентов плоскости решением системы линейных уравнений
                //!!!!!!!!!!!!!!!!!!!!!!!!!
                //!!!!!!!!!!!!!!!!!!!!!!!!!
            }
        }

        protected void PlaneSpaceNon()
        {
            //Конструктор устанавливает значение "Неизвестно" параметрам класса PlaneSpace
            //Используется для отработки ошибок
            PlaneCentre = null;
            //A = 1 / 0;
            //B = 1 / 0;???????????????
            //C = 1 / 0;
            //D = 1 / 0;
        }

        public GeomObjects.Points.Point3D GetPointOfPlane(double lx, double ly, PlaneSpace Plane)
        {
            //Свойство, возвращающее координаты 3D точки на 3D плоскости по параметрам lx и ly (координаты x и y)
            return (new GeomObjects.Points.Point3D(Plane.PlaneCentre.X + lx, Plane.PlaneCentre.Y + ly, (Plane.A * (Plane.PlaneCentre.X + lx) + Plane.B * (Plane.PlaneCentre.Y + ly) + Plane.D) / -Plane.C));
        }

        //=================================
        //Public Overloads ReadOnly Property GetPointOfPlane(????) As BaseGeometryYVP.GeomObjects.Points.Point3D
        //Свойство, возвращающее 3D координаты точки, лежащей в 3D плоскости
        //    Get
        //Dim t As Double
        //        t = (X - Point_0.x) / kx
        //        Return (New BaseGeometryYVP.GeomObjects.Points.Point3D(Point_0.x + kx * t, Point_0.y + ky * t, Point_0.z + kz * t))
        //    End Get
        //End Property
        //=================================

        //Public Overloads ReadOnly Property GetLineOfPlane(?????) As BaseGeometryYVP.GeomObjects.Lines.Line3D
        //    'Свойство, возвращающее координаты прямую, принадлежащую плоскости
        //    Get
        //        'Return '(New BaseGeometryYVP.GeomObjects.Lines.Line3D(A, B, C, D))
        //    End Get
        //End Property

        public PlaneSpace GetPlane
        {
            //Свойство, возвращающее коэффициенты и начальную точку плоскости по заданным значениям
            get { return (new PlaneSpace(A, B, C, D)); }
        }

        //public PlaneSpace GetPlane
        //{
        //    //Свойство, возвращающее коэффициенты и начальную точку плоскости по заданным значениям
        //    get { return (new PlaneSpace(A, B, C, D, PlaneCentre)); }
        //}

        //==========================================================================================

        public void NewPlaneCentre(PlaneSpace Plane, GeomObjects.Points.Point3D NewPlaneCentre)
        {
            //Конструктор задания новой начальной точки плоскости
            //Проверка принадлежности заданной точки заданной плоскости + контроль корректности задания плоскости
            if (this.PointOfPlanePosition(NewPlaneCentre, Plane) == 0)
            {
                PlaneCentre.X = NewPlaneCentre.X;
                PlaneCentre.Y = NewPlaneCentre.Y;
                PlaneCentre.Z = NewPlaneCentre.Z;

            }
            else
            {
                Interaction.MsgBox("Заданная точка не принадлежит заданной плоскости." + Constants.vbCrLf + "Проверьте исходные данные.", MsgBoxStyle.Exclamation, "Конструктор задания новой начальной точки плоскости");
                PlaneCentre = null;
                //Пока что
                //Перенести плоскость в новую точку-центр 
            }
        }

        public void NewPlaneCentre(PlaneSpace Plane, double NewPlaneCentre_X, double NewPlaneCentre_Y, double NewPlaneCentre_Z)
        {
            //Конструктор задания новой начальной точки плоскости
            dynamic NewPoint = new GeomObjects.Points.Point3D();
            //Новая начальная точка плоскости
            //Контроль корректности задания плоскости
            if (this.PlanFalse(Plane) == true)
            {
                Interaction.MsgBox("Плоскость задана не корректно." + Constants.vbCrLf, MsgBoxStyle.Critical, "Конструктор задания новой начальной точки плоскости");
                PlaneCentre = null;
                return;
            }
            NewPoint.X = NewPlaneCentre_X;
            NewPoint.Y = NewPlaneCentre_Y;
            NewPoint.Z = NewPlaneCentre_Z;
            //Проверка принадлежности заданной точки заданной плоскости
            if (this.PointOfPlanePosition(NewPoint, Plane) == 0)
            {
                PlaneCentre.X = NewPoint.X;
                PlaneCentre.Y = NewPoint.Y;
                PlaneCentre.Z = NewPoint.Z;
            }
            else
            {
                Interaction.MsgBox("Заданная точка не принадлежит заданной плоскости." + Constants.vbCrLf + "Проверьте исходные данные.", MsgBoxStyle.Exclamation, "Конструктор задания новой начальной точки плоскости");
                PlaneCentre = null;
                //Пока что
                //Перенести плоскость в новую точку-центр 

            }
        }

        public void NewPlaneCentre(PlaneSpace Plane, double[] NewPlaneCentre)
        {
            //Конструктор задания новой начальной точки плоскости
            dynamic NewPoint = new GeomObjects.Points.Point3D();
            //Новая начальная точка плоскости
            //Контроль корректности задания плоскости
            if (this.PlanFalse(Plane) == true)
            {
                Interaction.MsgBox("Плоскость задана не корректно." + Constants.vbCrLf, MsgBoxStyle.Critical, "Конструктор задания новой начальной точки плоскости");
                NewPoint = null;
                return;
            }
            //Обработка размера массива 
            if (NewPlaneCentre.GetUpperBound(0) != 2)
            {
                Interaction.MsgBox("Новая точка задана более или менее, чем тремя координатами." + Constants.vbCrLf + "Правильно задайте новую точку.", MsgBoxStyle.Critical, "Конструктор задания новой начальной точки плоскости");
                NewPoint = null;
                return;
            }
            NewPoint.X = NewPlaneCentre[0];
            NewPoint.Y = NewPlaneCentre[1];
            NewPoint.Z = NewPlaneCentre[2];
            //Проверка принадлежности заданной точки заданной плоскости
            if (this.PointOfPlanePosition(NewPoint, Plane) == 0)
            {
                PlaneCentre.X = NewPoint.X;
                PlaneCentre.Y = NewPoint.Y;
                PlaneCentre.Z = NewPoint.Z;
            }
            else
            {
                Interaction.MsgBox("Заданная точка не принадлежит заданной плоскости." + Constants.vbCrLf + "Проверьте исходные данные.", MsgBoxStyle.Critical, "Конструктор задания новой начальной точки плоскости");
                NewPoint = null;
                //Пока что
                //Перенести плоскость в новую точку-центр 

            }
        }

        public void PlaneSpaceCreation(GeomObjects.Points.Point3D Point1, GeomObjects.Points.Point3D Point2, GeomObjects.Points.Point3D Point3)
        {
            //Конструктор создания плоскости по трем точкам
            PlaneSpace PlaneSpaceNew = new PlaneSpace(Point1, Point2, Point3);
            this.PlaneCentre = PlaneSpaceNew.PlaneCentre;
            //Начальная точка плоскости
            //Коэффициенты уравнения общего вида плоскости
            this.A = PlaneSpaceNew.A;
            this.B = PlaneSpaceNew.B;
            this.C = PlaneSpaceNew.C;
            this.D = PlaneSpaceNew.D;
        }

        public void PlaneSpaceCreation(GeomObjects.Lines.Line3D Line1, GeomObjects.Lines.Line3D Line2)
        {
            //Конструктор задания плоскости двумя прямыми
            PlaneSpace PlaneSpaceNew = new PlaneSpace(Line1, Line2);
            this.PlaneCentre = PlaneSpaceNew.PlaneCentre;
            //Начальная точка плоскости
            //Коэффициенты уравнения общего вида плоскости
            this.A = PlaneSpaceNew.A;
            this.B = PlaneSpaceNew.B;
            this.C = PlaneSpaceNew.C;
            this.D = PlaneSpaceNew.D;
        }

        public void PlaneSpaceCreation(GeomObjects.Lines.Line3D Line, GeomObjects.Points.Point3D Point)
        {
            //Конструктор задания плоскости точкой и прямой
            PlaneSpace PlaneSpaceNew = new PlaneSpace(Line, Point);
            this.PlaneCentre = PlaneSpaceNew.PlaneCentre;
            //Начальная точка плоскости
            //Коэффициенты уравнения общего вида плоскости
            this.A = PlaneSpaceNew.A;
            this.B = PlaneSpaceNew.B;
            this.C = PlaneSpaceNew.C;
            this.D = PlaneSpaceNew.D;
        }

        public void PlaneSpaceCreation(GeomObjects.Lines.Line3D Line1, GeomObjects.Lines.Line3D Line2, GeomObjects.Lines.Line3D Line3)
        {
            //Конструктор задания плоскости тремя прямыми
            PlaneSpace PlaneSpaceNew = new PlaneSpace(Line1, Line2, Line3);
            this.PlaneCentre = PlaneSpaceNew.PlaneCentre;
            //Начальная точка плоскости
            //Коэффициенты уравнения общего вида плоскости
            this.A = PlaneSpaceNew.A;
            this.B = PlaneSpaceNew.B;
            this.C = PlaneSpaceNew.C;
            this.D = PlaneSpaceNew.D;
        }

        //Public Overloads Sub PlaneSpaceCreation(ByVal Lines() As Double)
        //Конструктор задания плоскости n-м количеством пересекающихся прямых
        //Проверить, чтобы прямые не пересекались в одной точке (проверить циклом) и не совпадали

        //End Sub

        public GeomObjects.Lines.Line3D NormalVectorOfPlane(PlaneSpace Plane)
        {
            //Функция возвращает вектор заданной плоскости
            //Контроль корректности задания плоскости
            if (this.PlanFalse(Plane) == true)
            {
                Interaction.MsgBox("Плоскость задана не корректно." + Constants.vbCrLf, MsgBoxStyle.Critical, "Расчет вектора заданной плоскости");
                //Err().Raise(1000, null, "Расчет вектора заданной плоскости", null, null);??
                return null;
            }
            //Расчет
            dynamic FrameCentre3D = default(GeomObjects.Points.Point3D);
            GeomObjects.Points.Point3D NormalVectorEndPt = new GeomObjects.Points.Point3D();
            GeomObjects.Lines.Line3D NormalVector = new GeomObjects.Lines.Line3D();
            FrameCentre3D.X = 0;
            FrameCentre3D.Y = 0;
            FrameCentre3D.Z = 0;
            NormalVectorEndPt.X = Plane.A;
            NormalVectorEndPt.Y = Plane.B;
            NormalVectorEndPt.Z = Plane.C;
            NormalVector.LineBy2Points(FrameCentre3D, NormalVectorEndPt);
            return NormalVector;
        }

        public void ParallelePlaneToPlaneFromPoint(GeomObjects.Points.Point3D Point, PlaneSpace Plane)
        {
            //Конструктор создания новой плоскости, проходящей через заданную точку параллельно заданной плоскости
            //Контроль корректности задания плоскости
            if (this.PlanFalse(Plane) == true)
            {
                Interaction.MsgBox("Плоскость задана не корректно." + Constants.vbCrLf, MsgBoxStyle.Critical, "Задание новой плоскости, проходящей через заданную точку параллельно заданной плоскости");
                //Err().Raise(1000, null, "Задание новой плоскости, проходящей через заданную точку параллельно заданной плоскости", null, null);
                return;
            }
            //Расчет
            this.A = Plane.A;
            this.B = Plane.B;
            this.C = Plane.C;
            //Задание постоянных коэффициентов новой плоскости
            this.D = A * (-Point.X) + B * (-Point.Y) + C * (-Point.Z);
            //Расчет свободного коэффициента новой плоскости
            this.PlaneCentre.X = this.A;
            this.PlaneCentre.Y = this.B;
            this.PlaneCentre.Z = this.C;
            //Начало новой плоскости
        }

        public void ParallelePlaneTo2LineFromPoint(GeomObjects.Points.Point3D Point, GeomObjects.Lines.Line3D Line1, GeomObjects.Lines.Line3D Line2)
        {
            //Конструктор создания новой плоскости, проходящей через заданную точку параллельно двум заданным прямым
            //Контроль корректности задания плоскости
            GeomObjects.Lines.Line3D LineVar = new GeomObjects.Lines.Line3D();
            MatrixEvalution MrxVar = new MatrixEvalution();
            //If LineVar.LineFalse(Line1) = True Or LineVar.LineFalse(Line2) = True Then '+ корректность задания прямых
            //    MsgBox("Прямые заданы не корректно." & vbCrLf & _
            //           MsgBoxStyle.Critical, "Задание новой плоскости, параллельной заданным прямым и проходящей через заданную точку")
            //    Err.Raise(1000, Nothing, "Задание новой плоскости, параллельной заданным прямым и проходящей через заданную точку", Nothing, Nothing)
            //    Exit Sub
            //End If
            //Расчет
            //Point = Line1.Point_0'Для проверки
            double[,] Deti = new double[2, 2];
            double[,] Detj = new double[2, 2];
            double[,] Detk = new double[2, 2];
            Deti.SetValue(Line1.ky, 0, 0);
            Deti.SetValue(Line1.kz, 0, 1);
            Deti.SetValue(Line2.ky, 1, 0);
            Deti.SetValue(Line2.kz, 1, 1);
            //---------------------
            Detj.SetValue(Line1.kx, 0, 0);
            Detj.SetValue(Line1.kz, 0, 1);
            Detj.SetValue(Line2.kx, 1, 0);
            Detj.SetValue(Line2.kz, 1, 1);
            //---------------------
            Detk.SetValue(Line1.kx, 0, 0);
            Detk.SetValue(Line1.ky, 0, 1);
            Detk.SetValue(Line2.kx, 1, 0);
            Detk.SetValue(Line2.ky, 1, 1);
            //---------------------
            this.A = MrxVar.detMrx2x2(Deti);
            this.B = -MrxVar.detMrx2x2(Detj);
            this.C = MrxVar.detMrx2x2(Detk);
            this.D = this.A * (-Point.X) + this.B * (-Point.Y) + this.C * (-Point.Z);
            //Расчет свободного коэффициента новой плоскости
            this.PlaneCentre.X = A;
            this.PlaneCentre.Y = B;
            this.PlaneCentre.Z = C;
            //Контроль точности рассчетов
            //Dim ControlLine1, ControlLine2, ControlPoint As Double
            //ControlPoint = MyClass.A * Point.x + MyClass.B * Point.y + MyClass.C * Point.z + MyClass.D
            //ControlLine1 = MyClass.A * Line1.Point_0.x + MyClass.B * Line1.Point_0.y + MyClass.C * Line1.Point_0.z + MyClass.D
            //ControlLine2 = MyClass.A * Line2.Point_0.x + MyClass.B * Line2.Point_0.y + MyClass.C * Line2.Point_0.z + MyClass.D
            PlaneSpace PlaneVar = new PlaneSpace(this.A, this.B, this.C, this.D, this.PlaneCentre);
            bool BoolLine1 = false;
            bool BoolLine2 = false;
            BoolLine1 = PlaneVar.LineOfPlan(Line1, PlaneVar);
            //Line2.kx = Line2.kz
            BoolLine2 = PlaneVar.LineOfPlan(Line2, PlaneVar);
            if (BoolLine1 == false | BoolLine2 == false)
            {
                //Corr:
                //Коррекция коэффициентов плоскости решением системы линейных уравнений
                //    Dim CoeffCorection As New EquationsSysCalc
                //    Dim CoeffEq(2, 3) As Double
                //    Dim CoeffSolution(2) As Double
                //    CoeffEq.SetValue(MyClass.A * Line1.kx, 0, 0) : CoeffEq.SetValue(MyClass.B * Line1.ky, 0, 1) : CoeffEq.SetValue(MyClass.C * Line1.kz, 0, 2) : CoeffEq.SetValue(0, 0, 3)
                //    CoeffEq.SetValue(MyClass.A * Line2.kx, 1, 0) : CoeffEq.SetValue(MyClass.B * Line2.ky, 1, 1) : CoeffEq.SetValue(MyClass.C * Line2.kz, 1, 2) : CoeffEq.SetValue(0, 1, 3)
                //    CoeffEq.SetValue(MyClass.A * (-Point.x), 2, 0) : CoeffEq.SetValue(MyClass.B * (-Point.y), 2, 1) : CoeffEq.SetValue(MyClass.C * (-Point.z), 2, 2) : CoeffEq.SetValue(-MyClass.D, 2, 3)
                //    CoeffSolution = CoeffCorection.KramerEquationsSolution(CoeffEq)
                //    MyClass.A = MyClass.A * CoeffSolution.GetValue(0) : MyClass.B = MyClass.B * CoeffSolution.GetValue(1) : MyClass.C = MyClass.C * CoeffSolution.GetValue(2)
                //    MyClass.PlaneCentre.x = MyClass.A : MyClass.PlaneCentre.y = MyClass.B : MyClass.PlaneCentre.z = MyClass.C
                //    'Коррекция коэффициента D плоскости
                //    Dim PlanToPointErr As Double
                //    Dim PlaneVar1 As New PlaneSpace(MyClass.A, MyClass.B, MyClass.C, MyClass.D, MyClass.PlaneCentre)
                //    PlanToPointErr = MyClass.A * Point.x + MyClass.B * Point.y + MyClass.C * Point.z + MyClass.D 'Должно равняться нулю
                //    If Math.Abs(PlanToPointErr) > MyClass.SolveErrorPl Then
                //        If MyClass.D > 0 And PlanToPointErr < 0 Or MyClass.D < 0 And PlanToPointErr > 0 Then
                //            MyClass.D = MyClass.D + PlanToPointErr
                //        Else
                //            MyClass.D = MyClass.D - PlanToPointErr
                //        End If
                //    Else
                //    End If
                //End If
                //'Решением по методу Гаусса
                //Dim CoeffCorection As New EquationsSysCalc
                //Dim CoeffEq(2, 2) As Double
                //Dim SLU_B(2) As Double 'Вектор свободных коэффициентов
                //Dim CoeffSolution(2) As Double
                //SLU_B.SetValue(0, 0) : SLU_B.SetValue(0, 1) : SLU_B.SetValue(0, 2) ' : SLU_B.SetValue(0, 3)
                //'-------------------------------------
                //CoeffEq.SetValue(MyClass.A * Line1.kx, 0, 0) : CoeffEq.SetValue(MyClass.B * Line1.ky, 0, 1) : CoeffEq.SetValue(MyClass.C * Line1.kz, 0, 2) ': CoeffEq.SetValue(0, 0, 3)
                //CoeffEq.SetValue(MyClass.A * Line2.kx, 1, 0) : CoeffEq.SetValue(MyClass.B * Line2.ky, 1, 1) : CoeffEq.SetValue(MyClass.C * Line2.kz, 1, 2) ' : CoeffEq.SetValue(0, 1, 3)
                //CoeffEq.SetValue(MyClass.A * (Line1.Point_0.x), 2, 0) : CoeffEq.SetValue(MyClass.B * (Line1.Point_0.y), 2, 1) : CoeffEq.SetValue(MyClass.C * (Line1.Point_0.z), 2, 2) ' : CoeffEq.SetValue(MyClass.D, 2, 3)
                //'CoeffEq.SetValue(MyClass.A * (-Point.x), 3, 0) : CoeffEq.SetValue(MyClass.B * (-Point.y), 3, 1) : CoeffEq.SetValue(MyClass.C * (-Point.z), 3, 2) ': CoeffEq.SetValue(-MyClass.D, 3, 3)

                //'CoeffEq.SetValue(Line1.kx, 0, 0) : CoeffEq.SetValue(Line1.ky, 0, 1) : CoeffEq.SetValue(Line1.kz, 0, 2) : CoeffEq.SetValue(0, 0, 3)
                //'CoeffEq.SetValue(Line2.kx, 1, 0) : CoeffEq.SetValue(Line2.ky, 1, 1) : CoeffEq.SetValue(Line2.kz, 1, 2) : CoeffEq.SetValue(0, 1, 3)
                //'CoeffEq.SetValue((Line1.Point_0.x), 2, 0) : CoeffEq.SetValue((Line1.Point_0.y), 2, 1) : CoeffEq.SetValue((Line1.Point_0.z), 2, 2) : CoeffEq.SetValue(0, 2, 3)
                //'CoeffEq.SetValue((Line2.Point_0.x), 3, 0) : CoeffEq.SetValue((Line2.Point_0.y), 3, 1) : CoeffEq.SetValue((Line2.Point_0.z), 3, 2) : CoeffEq.SetValue(0, 3, 3)
                //'CoeffEq.SetValue((-Point.x), 3, 0) : CoeffEq.SetValue((-Point.y), 3, 1) : CoeffEq.SetValue((-Point.z), 3, 2) : CoeffEq.SetValue(-1, 3, 3)

                //'MyClass.D = MyClass.A * (-Point.x) + MyClass.B * (-Point.y) + MyClass.C * (-Point.z) 'Расчет свободного коэффициента новой плоскости



                //CoeffSolution = CoeffCorection.SLU_GaussSolve(CoeffEq, SLU_B, MyClass.SolveErrorPl)



                //MyClass.A = MyClass.A * CoeffSolution.GetValue(0) : MyClass.B = MyClass.B * CoeffSolution.GetValue(1) : MyClass.C = MyClass.C * CoeffSolution.GetValue(2)
                //MyClass.PlaneCentre.x = MyClass.A : MyClass.PlaneCentre.y = MyClass.B : MyClass.PlaneCentre.z = MyClass.C
                //'    'Коррекция коэффициента D плоскости
                //    Dim PlanToPointErr As Double
                //    Dim PlaneVar1 As New PlaneSpace(MyClass.A, MyClass.B, MyClass.C, MyClass.D, MyClass.PlaneCentre)
                //    PlanToPointErr = MyClass.A * Point.x + MyClass.B * Point.y + MyClass.C * Point.z + MyClass.D 'Должно равняться нулю
                //    If Math.Abs(PlanToPointErr) > MyClass.SolveErrorPl Then
                //        If MyClass.D > 0 And PlanToPointErr < 0 Or MyClass.D < 0 And PlanToPointErr > 0 Then
                //            MyClass.D = MyClass.D + PlanToPointErr
                //        Else
                //            MyClass.D = MyClass.D - PlanToPointErr
                //        End If
                //    Else
                //    End If
            }



            //Контроль инцидентности прямых и плоскости + возврат на коррекцию (если не инцидентны)
            //BoolLine1 = PlaneVar.LineOfPlan(Line1, PlaneVar1)
            //BoolLine2 = PlaneVar.LineOfPlan(Line2, PlaneVar1)
            //Dim i As Integer
            //If BoolLine2 = False Then
            //    i = i + 1
            //    GoTo Corr
            //Else
            //    Stop
            //End If
        }

        public void PerpendicularePlaneTo2PlanesFromPoint(GeomObjects.Points.Point3D Point, PlaneSpace Plane1, PlaneSpace Plane2)
        {
            //Конструктор создания плоскости, проходящей через заданную точку, перпендикулярно двум заданным плоскостям
            //Контроль корректности задания плоскости
            if (this.PlanFalse(Plane1) == true | this.PlanFalse(Plane2) == true)
            {
                Interaction.MsgBox("Одна или обе плоскости заданы не корректно." + Constants.vbCrLf, MsgBoxStyle.Critical, "Задание новой плоскости, проходящей через заданную точку перпендикулярно заданной плоскости");
                //Err().Raise(1000, null, "Задание новой плоскости, проходящей через заданную точку перпендикулярно заданной плоскости", null, null);
                return;
            }
            //Контроль взаимного положения двух заданных плоскостей
            //Если заданные плоскости параллельны или совпадают
            if (this.PlanToPlanParallele(Plane1, Plane2) == true)
            {
                Interaction.MsgBox("Не удается создать плоскость, проходящую через заданную точку, перпендикулярно двум заданным плоскостям" + Constants.vbCrLf + "Заданные плоскости параллельны друг другу.", MsgBoxStyle.Critical, "Создание плоскости, проходящей через заданную точку перпендикулярно двум заданным плоскостям");
                this.PlaneSpaceNon();
                System.Diagnostics.Debugger.Break();
                return;
            }
            else
            {
                //Расчет
                double[,] Ak = new double[2, 2];
                double[,] Bk = new double[2, 2];
                double[,] Ck = new double[2, 2];
                //Определители для вычисления значений постоянных коэффициентов
                MatrixEvalution MrxVar = new MatrixEvalution();
                //Переменная для работы с классом матриц
                Ak.SetValue(Plane1.B, 0, 0);
                Ak.SetValue(Plane1.C, 0, 1);
                Ak.SetValue(Plane2.B, 1, 0);
                Ak.SetValue(Plane2.C, 1, 1);
                //_________
                Bk.SetValue(Plane1.A, 0, 0);
                Bk.SetValue(Plane1.C, 0, 1);
                Bk.SetValue(Plane2.A, 1, 0);
                Bk.SetValue(Plane2.C, 1, 1);
                //_________
                Ck.SetValue(Plane1.A, 0, 0);
                Ck.SetValue(Plane1.B, 0, 1);
                Ck.SetValue(Plane2.A, 1, 0);
                Ck.SetValue(Plane2.B, 1, 1);
                this.A = MrxVar.detMrx2x2(Ak);
                this.B = -MrxVar.detMrx2x2(Bk);
                this.C = MrxVar.detMrx2x2(Ck);
                //вычисление значений постоянных коэффициентов
                this.D = A * (-Point.X) + B * (-Point.Y) + C * (-Point.Z);
                //Расчет свободного коэффициента новой плоскости
                this.PlaneCentre.X = this.A;
                this.PlaneCentre.Y = this.B;
                this.PlaneCentre.Z = this.C;
                //Начало новой плоскости
            }
            //Коррекция коэффициентов плоскости решением системы линейных уравнений
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }

        public GeomObjects.Points.Point3D ProectionPointOnPlane(GeomObjects.Points.Point3D Point, PlaneSpace Plane)
        {
            //Функция возвращает координаты проекции 3D точки на заданную 3D плоскость
            GeomObjects.Lines.Line3D PerpendicularPtToPlane = new GeomObjects.Lines.Line3D();
            //Переменная перпендикуляра, опущенного из заданной точки на заданную плоскость
            GeomObjects.Points.Point3D ProectionPoint = new GeomObjects.Points.Point3D();
            //Проекция 3D точки на заданную 3D плоскость
            //Контроль инцидентности заданных точки и плоскости + контроль корректности задания прямой и плоскости
            //Если точка принадлежит плоскости
            if (this.PointOfPlanePosition(Point, Plane) == 0)
            {
                return Point;
            }
            else
            {
                PerpendicularPtToPlane = this.PerpendicularPointToPlane(Point, Plane);
                ProectionPoint = this.IntersectionPoint_LineAndPlan(PerpendicularPtToPlane, Plane);
                return ProectionPoint;
            }
        }

        //'Public Function ProectionLineOnPlane(ByVal Line As BaseGeometryYVP.GeomObjects.Lines.Line3D, ByVal Plane As BaseGeometryYVP.GeomObjects.PlaneSpace) As BaseGeometryYVP.GeomObjects.Lines.Line3D
        //'    'Функция возвращает прямую, как проекцию прямой на заданную плоскость
        //'    Dim ProectionLine As New BaseGeometryYVP.GeomObjects.Lines.Line3D
        //'    Dim PlaneLine, NormVectPlane, PlaneVar As New PlaneSpace
        //'    Dim EguationSys1(,), EguationSys2(,), EguationSys3(,) As Double
        //'    Dim Apr, Bpr, Cpr As Double
        //'    Dim MrxVar1, MrxVar2, MrxVar3 As New MatrixEvalution.MatrixEvalution ' Переменые для работы с классом MatrixCalc
        //'    ReDim EguationSys1(1, 1) : ReDim EguationSys2(1, 1) : ReDim EguationSys3(1, 1)
        //'    'Контроль инцидентности заданных прямой и плоскости + контроль корректности задания прямой и плоскости
        //'    If MyClass.LineOfPlan(Line, Plane) = True Then 'Если прямая инцидентна плоскости
        //'        Return Line
        //'        Exit Function
        //'    End If
        //'    'Контроль перпендикулярности заданных прямой и плоскости
        //'    If MyClass.LineToPlanePerpendiculare(Line, Plane) = True Then 'Если прямая перпендикулярна плоскости
        //'        'Dim ProectionPoint As New BaseGeometryYVP.GeomObjects.Points.Point3D
        //'        'ProectionPoint = MyClass.IntersectionPoint_LineAndPlan(Line, Plane)
        //'        'Return ProectionPoint
        //'        MsgBox("Заданная прямая перпендикулярна заданной плоскости." & vbCrLf & _
        //'               "Для нахождения проекции такой прямой используйте расчет точки пересечения с плоскостью," & vbCrLf & _
        //'               "либо обработайте условие перпендикулярности прямой и плоскости.", MsgBoxStyle.Critical, "Построение проекции прямой на плоскость")
        //'        Return Nothing
        //'        Exit Function
        //'    End If
        //'    'Заполнение матриц-определителей для решения системы уравнений
        //'    'Для нахождения коэффициента для X
        //'    EguationSys1.SetValue(Line.ky, 0, 0) : EguationSys1.SetValue(Line.kz, 0, 1)
        //'    EguationSys1.SetValue(Plane.B, 1, 0) : EguationSys1.SetValue(Plane.C, 1, 1)
        //'    'Для нахождения коэффициента для Y
        //'    'EguationSys2.SetValue(Line.kx, 0, 0) : EguationSys2.SetValue(Line.kz, 0, 1)
        //'    'EguationSys2.SetValue(Plane.A, 1, 0) : EguationSys2.SetValue(Plane.C, 1, 1)
        //'    'По книге меняются столбцы, т.к. коэффициент при y в уравнение подставляется со знаком минус
        //'    EguationSys2.SetValue(Line.kx, 0, 1) : EguationSys2.SetValue(Line.kz, 0, 0)
        //'    EguationSys2.SetValue(Plane.A, 1, 1) : EguationSys2.SetValue(Plane.C, 1, 0)
        //'    'Для нахождения коэффициента для Z
        //'    EguationSys3.SetValue(Line.kx, 0, 0) : EguationSys3.SetValue(Line.ky, 0, 1)
        //'    EguationSys3.SetValue(Plane.A, 1, 0) : EguationSys3.SetValue(Plane.B, 1, 1)
        //'    'Решение определителей
        //'    Apr = MrxVar1.detMrx2x2(EguationSys1)
        //'    Bpr = MrxVar2.detMrx2x2(EguationSys2)
        //'    Cpr = MrxVar3.detMrx2x2(EguationSys3)
        //'    'Запись полученных коэффициентов для плоскости, проходящей через заданную прямую перпендикулярно заданной плоскости
        //'    PlaneLine.A = Apr : PlaneLine.B = Bpr : PlaneLine.C = Cpr
        //'    PlaneLine.D = PlaneLine.A * (-Line.Point_0.x) + PlaneLine.B * (-Line.Point_0.y) + PlaneLine.C * (-Line.Point_0.z) 'Расчет свободного коэффициента новой плоскости
        //'    'Расчет центра плоскости
        //'    PlaneLine.PlaneCentre.x = PlaneLine.A : PlaneLine.PlaneCentre.y = PlaneLine.B : PlaneLine.PlaneCentre.z = PlaneLine.C
        //'    'Расчет прямой как линии пересечения двух плоскостей
        //'    ''ProectionLine.LineByTwoPlans(Plane, PlaneLine)
        //'    Return ProectionLine
        //'End Function

        public GeomObjects.Lines.Line3D PerpendicularPointToPlane(GeomObjects.Points.Point3D Point, PlaneSpace Plane)
        {
            //Функция задает перпендикулярную прямую из заданной точки на заданную плоскость
            dynamic NormalVector = default(GeomObjects.Lines.Line3D);
            GeomObjects.Lines.Line3D PerpendicularLine = new GeomObjects.Lines.Line3D();
            //Переменные нормального вектора к заданной плоскости и перпендикуляра из заданной точки к плоскости
            dynamic FrameCentre3D = default(GeomObjects.Points.Point3D);
            GeomObjects.Points.Point3D NormalVectorEndPt = new GeomObjects.Points.Point3D();
            // Переменные начальной и конечной точки нормального вектора к плоскости, опущенного из начала системы координат
            //Контроль инцидентности заданных точки и плоскости
            //Если точка принадлежит плоскости + контроль корректности задания плоскости
            if (this.PointOfPlanePosition(Point, Plane) == 0)
            {
                Interaction.MsgBox("Заданные точка и плоскость инцидентны друг другу." + Constants.vbCrLf + "Проверьте исходные данные.", MsgBoxStyle.Exclamation, "Расчет перпендикулярной прямой из заданной точки на заданную плоскость");
                PerpendicularLine = null;
                return PerpendicularLine;
            }
            else
            {
                //FrameCentre3D.x = 0 : FrameCentre3D.y = 0 : FrameCentre3D.z = 0
                //NormalVectorEndPt.x = Plane.A : NormalVectorEndPt.y = Plane.B : NormalVectorEndPt.z = Plane.C
                //NormalVector.LineBy2Points(FrameCentre3D, NormalVectorEndPt)
                //PerpendicularLine.ParallelPointToLine(NormalVector, Point) 'Работает (II способ. Авторский. Проверен.)
                PerpendicularLine.Point_0 = Point;
                //I способ (по книге)
                PerpendicularLine.kx = Plane.A;
                PerpendicularLine.ky = Plane.B;
                PerpendicularLine.kz = Plane.C;
                return PerpendicularLine;
            }
        }

        public double? DistPlaneToZeroPointAbs(PlaneSpace Plane)
        {
            //Функция возвращает значение расстояния от 3D плоскости до начала пространственной (мировой) системы координат
            //Обработка деления на ноль + контроль корректности задания плоскости
            if (this.PlanFalse(Plane) == true)
            {
                Interaction.MsgBox("Плоскость задана не корректно." + Constants.vbCrLf + "Правильно задайте плоскость.", MsgBoxStyle.Critical, "Расчет расстояния от 3D плоскости до начала пространственной (мировой) системы координат");
                return null;
            }
            return Math.Abs(Plane.D / Math.Sqrt(Math.Pow(Plane.A, 2) + Math.Pow(Plane.B, 2) + Math.Pow(Plane.C, 2)));
        }

        public double? DistPlaneToZeroPoint(PlaneSpace Plane)
        {
            //Функция возвращает значение расстояния от 3D плоскости до начала пространственной (мировой) системы координат
            //Обработка деления на ноль + контроль корректности задания плоскости
            if (this.PlanFalse(Plane) == true)
            {
                Interaction.MsgBox("Плоскость задана не корректно." + Constants.vbCrLf + "Правильно задайте плоскость.", MsgBoxStyle.Critical, "Расчет расстояния от 3D плоскости до начала пространственной (мировой) системы координат");
                return null;
            }
            return Plane.D / Math.Sqrt(Math.Pow(Plane.A, 2) + Math.Pow(Plane.B, 2) + Math.Pow(Plane.C, 2));
        }

        public double? DistantionPointToPlanAbs(GeomObjects.Points.Point3D Point, PlaneSpace Plane)
        {
            //Функция возвращает значение расстояния от 3D точки до 3D плоскости
            double DistPtPlan = 0;
            //Величина расстояния
            //Контроль инцидентности заданных точки и плоскости
            //Если точка принадлежит плоскости + обработка деления на ноль + контроль корректности задания плоскости
            if (this.PointOfPlanePosition(Point, Plane) == 0)
            {
                return null;
            }
            DistPtPlan = Math.Abs(Plane.A * Point.X + Plane.B * Point.Y + Plane.C * Point.Z + Plane.D) / Math.Sqrt(Math.Pow(Plane.A, 2) + Math.Pow(Plane.B, 2) + Math.Pow(Plane.C, 2));
            return DistPtPlan;
        }

        public double? DistantionPointToPlan(GeomObjects.Points.Point3D Point, PlaneSpace Plane)
        {
            //Функция возвращает абсолютное значение расстояния от 3D точки до 3D плоскости
            double DistPtPlan = 0;
            //Величина расстояния
            //Dim a, b As Double
            //Если точка принадлежит плоскости + обработка деления на ноль + контроль корректности задания плоскости
            if (this.PointOfPlanePosition(Point, Plane) == 0)
            {
                return null;
            }
            DistPtPlan = (Plane.A * Point.X + Plane.B * Point.Y + Plane.C * Point.Z + Plane.D) / Math.Sqrt(Math.Pow(Plane.A, 2) + Math.Pow(Plane.B, 2) + Math.Pow(Plane.C, 2));
            //a = Plane.A * Point.x + Plane.B * Point.y + Plane.C * Point.z + Plane.D
            //b = Math.Sqrt(Plane.A ^ 2 + Plane.B ^ 2 + Plane.C ^ 2)
            return DistPtPlan;
        }

        public double DistantionLineToPlan(GeomObjects.Lines.Line3D Line, PlaneSpace Plane)
        {
            //Функция возвращает абсолютное значение расстояния от 3D прямой до 3D плоскости
            double DistLineToPlan = 0;
            //Расстояние от точки, приннадлежащей прямой до заданной плоскости
            dynamic LinePt = default(GeomObjects.Points.Point3D);
            dynamic ProectionPtToPlan = default(GeomObjects.Points.Point3D);
            GeomObjects.Points.Point3D PointVar = new GeomObjects.Points.Point3D();
            //Точка на прямой и ее проекция на заданную плоскость
            GeomObjects.Points.PointCalculator PointCalculator_Var = new GeomObjects.Points.PointCalculator();
            //Точка на прямой и ее проекция на заданную плоскость

            //Dim Perpendiculare As New BaseGeometryYVP.GeomObjects.Lines.Line3D 'Перпендикуляр из заданной прямой на плоскость 
            //Если прямая пересекается или совпадает с заданной плоскостью
            if (this.IntersectionLineAndPlan(Line, Plane) == true | this.LineOfPlan(Line, Plane) == true)
            {
                //+контроль корректности задания прямой и плоскости
                return 0;
            }
            else
            {
                LinePt = Line.GetPoint(10);
                ProectionPtToPlan = this.ProectionPointOnPlane(LinePt, Plane);
                DistLineToPlan = PointCalculator_Var.PointDistantion(LinePt, ProectionPtToPlan);
                //Расчет расстояния между точкой на прямой и ее проекции на заданную плоскость
                return DistLineToPlan;
            }
        }

        public double? DistantionPlanToPlanAbs(PlaneSpace Plane1, PlaneSpace Plane2)
        {
            //Функция возвращает абсолютное значение расстояния от 3D плоскости до 3D плоскости
            double? DistPlanToPlan = 0;
            double? DistPlanToPlan1 = 0;
            double? DistPlanToPlan2 = 0;
            //Величина расстояния
            //FrameZeroPoint - начало системы координат 3D базиса
            //PointPlane1 - точка пересечения нормального вектора 1-й плоскости со 1-й плоскостью 
            //PointPlane2 - точка пересечения нормального вектора 1-й плоскости со 2-й плоскостью 
            dynamic FrameZeroPoint = default(GeomObjects.Points.Point3D);
            dynamic PointPlane1 = default(GeomObjects.Points.Point3D);
            dynamic PointPlane2 = default(GeomObjects.Points.Point3D);
            GeomObjects.Points.Point3D PointVar = new GeomObjects.Points.Point3D();
            //+ контроль корректности задания плоскостей
            if (this.PlanToPlanParallele(Plane1, Plane2) == true)
            {
                //Первый способ
                //1.Задаем из начала системы координат базиса прямую перпендикулярную первой и второй плоскостям
                //2.Находим точки пересечения этой прямой с обеими плоскостями
                //3.Определяем расстояние между найденными точками пересечения
                //'PerpendicularPointToPlane(FrameZeroPoint, Plane1) - прямая, инидентная нормальному вектору первой плоскости 
                //PointPlane1 = IntersectionPoint_LineAndPlan(PerpendicularPointToPlane(FrameZeroPoint, Plane1), Plane1)
                //PointPlane2 = IntersectionPoint_LineAndPlan(PerpendicularPointToPlane(FrameZeroPoint, Plane1), Plane2)
                //DistPlantoPlan = PointVar.PointDistantion(PointPlane1, PointPlane2)
                //Второй способ
                DistPlanToPlan1 = this.DistPlaneToZeroPoint(Plane1);
                //Расстояние от начала системы координат 3D базиса до 1-й плоскости
                DistPlanToPlan2 = this.DistPlaneToZeroPoint(Plane2);
                //Расстояние от начала системы координат 3D базиса до 2-й плоскости
                DistPlanToPlan = Math.Abs((double)DistPlanToPlan1 - (double)DistPlanToPlan2);
                //Расчет расстояния между плоскостями
                return DistPlanToPlan;
            }
            else
            {
                Interaction.MsgBox("Не удается рассчитать растояние между заданными плоскостями." + Constants.vbCrLf + "Заданные плоскости пересекаются.", MsgBoxStyle.Critical, "Функция определения расстояния между двумя плоскостями");
                return null;
            }
        }

        public double? DistantionPlanToPlan(PlaneSpace Plane1, PlaneSpace Plane2)
        {
            //Функция возвращает значение расстояния от 3D плоскости до 3D плоскости
            double? DistPlanToPlan = 0;
            double? DistPlanToPlan1 = 0;
            double? DistPlanToPlan2 = 0;
            //Величина расстояния
            //FrameZeroPoint - начало системы координат 3D базиса
            //PointPlane1 - точка пересечения нормального вектора 1-й плоскости со 1-й плоскостью 
            //PointPlane2 - точка пересечения нормального вектора 1-й плоскости со 2-й плоскостью 
            dynamic FrameZeroPoint = default(GeomObjects.Points.Point3D);
            dynamic PointPlane1 = default(GeomObjects.Points.Point3D);
            dynamic PointPlane2 = default(GeomObjects.Points.Point3D);
            GeomObjects.Points.Point3D PointVar = new GeomObjects.Points.Point3D();
            //+ контроль корректности задания плоскостей
            if (this.PlanToPlanParallele(Plane1, Plane2) == true)
            {
                //Первый способ
                //1.Задаем из начала системы координат базиса прямую перпендикулярную первой и второй плоскостям
                //2.Находим точки пересечения этой прямой с обеими плоскостями
                //3.Определяем расстояние между найденными точками пересечения
                //'PerpendicularPointToPlane(FrameZeroPoint, Plane1) - прямая, инидентная нормальному вектору первой плоскости 
                //PointPlane1 = IntersectionPoint_LineAndPlan(PerpendicularPointToPlane(FrameZeroPoint, Plane1), Plane1)
                //PointPlane2 = IntersectionPoint_LineAndPlan(PerpendicularPointToPlane(FrameZeroPoint, Plane1), Plane2)
                //DistPlantoPlan = PointVar.PointDistantion(PointPlane1, PointPlane2)
                //Второй способ
                DistPlanToPlan1 = this.DistPlaneToZeroPoint(Plane1);
                //Расстояние от начала системы координат 3D базиса до 1-й плоскости
                DistPlanToPlan2 = this.DistPlaneToZeroPoint(Plane2);
                //Расстояние от начала системы координат 3D базиса до 2-й плоскости
                DistPlanToPlan = DistPlanToPlan1 - DistPlanToPlan2;
                //Расчет расстояния между плоскостями
                return DistPlanToPlan;
            }
            else
            {
                Interaction.MsgBox("Не удается рассчитать растояние между заданными плоскостями." + Constants.vbCrLf + "Заданные плоскости пересекаются.", MsgBoxStyle.Critical, "Функция определения расстояния между двумя плоскостями");
                return null;
            }
        }

        public int? PointOfPlanePosition(GeomObjects.Points.Point3D Point, PlaneSpace Plane)
        {
            //Функция возвращает значение "1", если точка расположена  в той стороне, куда указывает нормальный вектор (A,B,C)(s > 0).
            //Возвращаяет "-1", если точка на противаположной стороне (s < 0), а возвращаяет "0" в случае, если точка принадлежит плоскости (s = 0)
            double S = 0;
            GeomObjects.Points.Point3D PtVar = new GeomObjects.Points.Point3D();
            GeomObjects.Points.PointsPositionControl PointControl_Val = new GeomObjects.Points.PointsPositionControl();
            //Переменная для работы с контролем точек

            //Контроль корректности задания плоскости
            if (this.PlanFalse(Plane) == true)
            {
                //MsgBox("Плоскость задана не корректно." & vbCrLf & _
                //       MsgBoxStyle.Exclamation, "Функция определения положения 3D точки отностительно плоскости")
                return null;
            }
            //Контроль совпадения заданной и базовой точки
            if (PointControl_Val.PointsIsPoints(Point, Plane.PlaneCentre) == true)
            {
                return 0;
            }
            else
            {
                S = Plane.A * Point.X + Plane.B * Point.Y + Plane.C * Point.Z + Plane.D;
                //If S > 0 Then
                //    Return 1
                //ElseIf S < 0 Then
                //    Return -1
                //Else
                //    Return 0
                //End If
                if (S > 0.0001)
                {
                    return 1;
                }
                else if (S < -0.0001)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool LineOfPlan(GeomObjects.Lines.Line3D Line, PlaneSpace Plane)
        {
            //Функция возвращает "TRUE", если заданная 3D прямая лежит в заданной плоскости
            double s = 0;
            double g = 0;
            GeomObjects.Lines.Line3D LineVar = new GeomObjects.Lines.Line3D();
            // '' ''Контроль корректности задания прямой и плоскости
            //' ''If MyClass.PlanFalse(Plane) = True Or LinesControl_Val.LineFals(Line) = True Then
            //' ''    MsgBox("Не удается определить положение прямой и плоскости." & vbCrLf & _
            //' ''           "Прямая или плоскость заданны не корректно.", MsgBoxStyle.Critical, "Функция определения инцидентности прямой и плоскости")
            //' ''    Return Nothing
            //' ''    Exit Function
            //' ''End If
            //Расчет
            s = Plane.A * Line.kx + Plane.B * Line.ky + Plane.C * Line.kz;
            //Прямая либо параллельна либо инцидентна плоскости
            g = Plane.A * Line.Point_0.X + Plane.B * Line.Point_0.Y + Plane.C * Line.Point_0.Z + Plane.D;
            //Точка прямой принадлежит плоскости
            //If s=0 And g= 0 Then
            if (Math.Abs(s) <= this.SolveErrorPl & Math.Abs(g) <= this.SolveErrorPl)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool? PlanToPlanPerpendiculare(PlaneSpace Plane1, PlaneSpace Plane2)
        {
            //Функция возвращает значение "TRUE", если две плоскости перпендикулярны
            //Контроль корректности задания прямой и плоскости
            if (this.PlanFalse(Plane1) == true | this.PlanFalse(Plane2) == true)
            {
                Interaction.MsgBox("Одна или обе плоскости заданы не корректно." + Constants.vbCrLf + "Правильно задайте плоскости.", MsgBoxStyle.Critical, "Функция определения перпендикулярности двух плоскостей");
                return null;
            }
            else
            {
                //If Plane1.A * Plane2.A + Plane1.B * Plane2.B + Plane1.C * Plane2.C = 0 Then
                if (Math.Abs(Plane1.A * Plane2.A + Plane1.B * Plane2.B + Plane1.C * Plane2.C) <= this.SolveErrorPl)
                {
                    return true;
                }
                else
                {
                    goto AnglePlans;
                }
            }
        AnglePlans:
            PlaneSpace PlaneVar = new PlaneSpace();
            double? PlansAngle = 0;
            PlansAngle = PlaneVar.AnglePlanToPlan(Plane1, Plane2);
            //Если погрешность угла не превышает заданной величины
            if (Math.Abs((double)PlansAngle) - 90 <= this.SolveErrorPl)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool? PlanToPlanParallele(PlaneSpace Plane1, PlaneSpace Plane2)
        {
            //Функция возвращает значение "TRUE", если две плоскости параллельны
            //If Plane1.A / Plane2.A = Plane1.B / Plane2.B And Plane1.A / Plane2.A = Plane1.C / Plane2.C  And Plane1.B / Plane2.B = Plane1.C / Plane2.C  Then
            //    Return True
            //Else
            //    Return False
            //End If
            //Контроль корректности задания прямой и плоскости
            if (this.PlanFalse(Plane1) == true | this.PlanFalse(Plane2) == true)
            {
                Interaction.MsgBox("Одна или обе плоскости заданы не корректно." + Constants.vbCrLf + "Правильно задайте плоскости.", MsgBoxStyle.Critical, "Контроль параллельности двух плоскостей");
                return null;
            }
            else
            {
                //If Plane1.A * Plane2.B = Plane1.B * Plane2.A And Plane1.B * Plane2.C = Plane2.B * Plane1.C And Plane1.A * Plane2.C = Plane2.A * Plane1.C Then
                if (Math.Abs(Plane1.A * Plane2.B - Plane1.B * Plane2.A) <=
                    this.SolveErrorPl & Math.Abs(Plane1.B * Plane2.C - Plane2.B * Plane1.C) <=
                    this.SolveErrorPl & Math.Abs(Plane1.A * Plane2.C - Plane2.A * Plane1.C) <=
                    this.SolveErrorPl)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public double? AnglePlanToPlan(PlaneSpace Plane1, PlaneSpace Plane2)
        {
            //Функция возвращает значения угла между двумя пересекающимися 3D плоскостями
            double AngleLines = 0;
            double CosAngle1 = 0;
            double CosAngle2 = 0;
            double CosAngle3 = 0;
            double a = 0;
            double b = 0;
            //Контроль корректности задания плоскостей
            if (this.PlanFalse(Plane1) == true | this.PlanFalse(Plane2) == true)
            {
                Interaction.MsgBox("Одна или обе плоскости заданы не корректно." + Constants.vbCrLf + "Правильно задайте плоскости.", MsgBoxStyle.Critical, "Расчет угла между двумя пересекающимися 3D плоскостями");
                return null;
            }
            //Контроль параллельности и перпендикулярности плоскостей
            if (Plane1.A * Plane2.A + Plane1.B * Plane2.B + Plane1.C * Plane2.C == 0)
            {
                //If MyClass.PlanToPlanPerpendiculare(Plane1, Plane2) = True Then
                AngleLines = 90;
                return AngleLines;
            }
            else if (Plane1.A * Plane2.B == Plane1.B * Plane2.A & Plane1.B * Plane2.C == Plane2.B * Plane1.C & Plane1.A * Plane2.C == Plane2.A * Plane1.C)
            {
                //ElseIf MyClass.PlanToPlanParallele(Plane1, Plane2) = True Then
                //Обработать направление 
                AngleLines = 0;
                return AngleLines;
            }
            else
            {
                CosAngle1 = (Plane1.A * Plane2.A) + (Plane1.B * Plane2.B) + (Plane1.C * Plane2.C);
                a = Math.Sqrt(Math.Pow(Plane1.A, 2) + Math.Pow(Plane1.B, 2) + Math.Pow(Plane1.C, 2));
                b = Math.Sqrt(Math.Pow(Plane2.A, 2) + Math.Pow(Plane2.B, 2) + Math.Pow(Plane2.C, 2));
                CosAngle2 = CosAngle1 / (a * b);
                //Проверить расчеты нижеприведенные
                CosAngle3 = CosAngle2;
                if (CosAngle3 > 1)
                {
                    CosAngle3 = 2 - CosAngle3;
                    AngleLines = Math.Acos(CosAngle3) * 180 / Math.PI;
                    return AngleLines;
                }
                else
                {
                    AngleLines = Math.Acos(CosAngle3) * 180 / Math.PI;
                    return AngleLines;
                }
            }
            //Rad := Grad * Pi / 180; - перевод градусов (Grad) в радианы (Rad) 
            //Grad := Rad * 180 / Pi; - обратный перевод 
        }

        public double AngleLineToPlan(GeomObjects.Lines.Line3D Line, PlaneSpace Plane)
        {
            //Функция возвращает значение угла между пересекающимися 3D прямой и 3D плоскостью
            double AngleLinePlan = 0;
            double SinAngle1 = 0;
            double SinAngle2 = 0;
            double g = 0;
            double a = 0;
            double b = 0;
            GeomObjects.Lines.Line3D LineVar = new GeomObjects.Lines.Line3D();
            // '' ''Контроль корректности задания прямой и плоскости
            //' ''If MyClass.PlanFalse(Plane) = True Or LineVar.LineFalse(Line) = True Then
            //' ''    MsgBox("Прямая или плоскость или оба элемента заданы не корректно." & vbCrLf & _
            //' ''           "Правильно задайте прямую и плоскость.", MsgBoxStyle.Critical, "Расчет значения угла между пересекающимися 3D прямой и плоскостью")
            //' ''    Return Nothing
            //' ''    Exit Function
            //' ''End If
            //Контроль инцидентности заданных прямой и плоскости
            SinAngle1 = Plane.A * Line.kx + Plane.B * Line.ky + Plane.C * Line.kz;
            //Прямая либо параллельна либо инцидентна плоскости
            g = Plane.A * Line.Point_0.X + Plane.B * Line.Point_0.Y + Plane.C * Line.Point_0.Z + Plane.D;
            //Точка прямой принадлежит плоскости
            //Если точка принадлежит плоскости
            if (SinAngle1 == 0 & g == 0)
            {
                //If MyClass.LineOfPlan(Line, Plane) = True Then 'Если точка принадлежит плоскости
                return 0;
            }
            //Прямая параллельна плоскости
            if (SinAngle1 == 0)
            {
                AngleLinePlan = 0;
                return AngleLinePlan;
                //Прямая перпендикулярна плоскости
            }
            else if (Plane.A * Line.ky == Plane.B * Line.kx & Plane.B * Line.kz == Plane.C * Line.ky & Plane.A * Line.kz == Plane.C * Line.kx)
            {
                //Уравнения получены из соотношения - Plane.A / Line.kx = Plane.B / Line.ky Or Plane.B / Line.ky = Plane.C / Line.kx
                //Обработать направление 
                AngleLinePlan = 90;
                return AngleLinePlan;
            }
            else
            {
                a = Math.Sqrt(Math.Pow(Plane.A, 2) + Math.Pow(Plane.B, 2) + Math.Pow(Plane.C, 2));
                b = Math.Sqrt(Math.Pow(Line.kx, 2) + Math.Pow(Line.ky, 2) + Math.Pow(Line.kz, 2));
                SinAngle2 = Math.Abs(SinAngle1) / (a * b);
                AngleLinePlan = Math.Asin(SinAngle2) * 180 / Math.PI;
                return AngleLinePlan;
            }
            //Rad := Grad * Pi / 180; - перевод градусов (Grad) в радианы (Rad) 
            //Grad := Rad * 180 / Pi; - обратный перевод 
        }

        public GeomObjects.Points.Point3D IntersectionPoint_LineAndPlan(GeomObjects.Lines.Line3D Line, PlaneSpace Plane)
        {
            //Функция расчета общей точки прямой и плоскости
            double s = 0;
            double g = 0;
            double t = 0;
            GeomObjects.Points.Point3D IntersectPoint = new GeomObjects.Points.Point3D();
            GeomObjects.Lines.Line3D LineVar = new GeomObjects.Lines.Line3D();
            // '' ''Контроль корректности задания прямой и плоскости
            //' ''If MyClass.PlanFalse(Plane) = True Or LineVar.LineFalse(Line) = True Then
            //' ''    MsgBox("Прямая или плоскость или оба элемента заданы не корректно." & vbCrLf & _
            //' ''           "Правильно задайте прямую и плоскость.", MsgBoxStyle.Critical, "Функция общей точки прямой и плоскости")
            //' ''    IntersectPoint = Nothing
            //' ''    Return IntersectPoint
            //' ''    Exit Function
            //' ''End If
            //Расчет
            g = Plane.A * Line.Point_0.X + Plane.B * Line.Point_0.Y + Plane.C * Line.Point_0.Z + Plane.D;
            s = Plane.A * Line.kx + Plane.B * Line.ky + Plane.C * Line.kz;
            if (this.LineToPlanParallele(Line, Plane) == true)
            {
                //If s = 0 And g <> 0 Then
                Interaction.MsgBox("Прямая не имеет общих точек с плоскостью." + Constants.vbCrLf + "Прямая параллельна плоскости.", MsgBoxStyle.Exclamation, "Конструктор расчета общей точки линии и плоскости");
                IntersectPoint = null;
                return IntersectPoint;
            }
            else if (this.LineOfPlan(Line, Plane) == true)
            {
                //ElseIf s = 0 And g = 0 Then
                Interaction.MsgBox("Прямая лежит в плоскости.", MsgBoxStyle.Exclamation, "Конструктор расчета общей точки линии и плоскости");
                IntersectPoint = Line.GetPoint(1);
                return IntersectPoint;
            }
            else if (s != 0)
            {
                t = -g / s;
                return (new GeomObjects.Points.Point3D(Line.Point_0.X + Line.kx * t, Line.Point_0.Y + Line.ky * t, Line.Point_0.Z + Line.kz * t));
            }
            else
            {
                Interaction.MsgBox("Не удается рассчитать общую точку линии и плоскости." + Constants.vbCrLf + "Проверьте исходные данные.", MsgBoxStyle.Exclamation, "Конструктор расчета общей точки линии и плоскости");
                IntersectPoint = null;
                return IntersectPoint;
            }
        }

        public GeomObjects.Points.Point3D PointIntersectionOf3Plans(PlaneSpace Plane1, PlaneSpace Plane2, PlaneSpace Plane3)
        {
            //Функция расчета точки пересечения трех плоскостей
            double[,] MrxEq = new double[3, 4];
            double[,] MrxDetEq = new double[3, 3];
            //Матрица коэффициентов и матрица определителя
            MatrixEvalution MrxVar = new MatrixEvalution();
            //Переменная для расчета определителя и ранга матриц
            EquationsSysCalc.EqSysCalculation VarSolution = new EquationsSysCalc.EqSysCalculation();
            //Переменная для расчета определителя и ранга матриц
            int i = 0;
            int j = 0;
            //Переменные цикла
            GeomObjects.Points.Point3D PointIntersect = new GeomObjects.Points.Point3D();
            //Точка пересечения плоскостей
            GeomObjects.Lines.Line3D LineVar = new GeomObjects.Lines.Line3D();
            //Контроль правильности задания плоскостей
            if (this.PlanFalse(Plane1) == true | this.PlanFalse(Plane2) == true | this.PlanFalse(Plane3) == true)
            {
                Interaction.MsgBox("Некоторые или все плоскости заданы не корректно." + Constants.vbCrLf + "Правильно задайте плоскости.", MsgBoxStyle.Critical, "Расчет точки пересечения трех плоскостей");
                PointIntersect.X = 0 / 1;
                PointIntersect.Y = 0 / 1;
                PointIntersect.Z = 0 / 1;
                return PointIntersect;
            }
            //Заполнение матрицы коэффициентов системы уравнений
            MrxEq.SetValue(Plane1.A, 0, 0);
            MrxEq.SetValue(Plane1.B, 0, 1);
            MrxEq.SetValue(Plane1.C, 0, 2);
            MrxEq.SetValue(Plane1.D, 0, 3);
            MrxEq.SetValue(Plane2.A, 1, 0);
            MrxEq.SetValue(Plane2.B, 1, 1);
            MrxEq.SetValue(Plane2.C, 1, 2);
            MrxEq.SetValue(Plane2.D, 1, 3);
            MrxEq.SetValue(Plane3.A, 2, 0);
            MrxEq.SetValue(Plane3.B, 2, 1);
            MrxEq.SetValue(Plane3.C, 2, 2);
            MrxEq.SetValue(Plane3.D, 2, 3);
            //Заполнение матрицы определителя коэффициентов системы уравнений
            for (i = 0; i <= MrxEq.GetUpperBound(0); i++)
            {
                for (j = 0; j <= MrxEq.GetUpperBound(1) - 1; j++)
                {
                    MrxDetEq.SetValue(MrxEq.GetValue(i, j), i, j);
                }
            }
            //Проверка значения определителя 
            if (MrxVar.detMrx3x3(MrxDetEq) == 0)
            {
                if (MrxVar.RangMrxMxN(MrxEq) == 3)
                {
                    //Система не совместна
                    Interaction.MsgBox("Точки, принадлежащей трем заданным плоскостям не существует" + Constants.vbCrLf + "", MsgBoxStyle.Exclamation, "Расчет точки пересечения трех плоскостей");
                    PointIntersect = null;
                    return PointIntersect;
                }
                else if (MrxVar.RangMrxMxN(MrxEq) == 2 & MrxVar.RangMrxMxN(MrxDetEq) == 2)
                {
                    //Одно из уравнений есть линейная комбинация двух остальных
                    Interaction.MsgBox("Три заданные плоскости проходят через одну прямую" + Constants.vbCrLf + "", MsgBoxStyle.Exclamation, "Расчет точки пересечения трех плоскостей");
                    PointIntersect = null;
                    return PointIntersect;
                }
                else if (MrxVar.RangMrxMxN(MrxEq) == 2 & MrxVar.RangMrxMxN(MrxDetEq) == 1)
                {
                    //Система не совместна
                    Interaction.MsgBox("Три заданные плоскости параллельны между собой" + Constants.vbCrLf + "", MsgBoxStyle.Exclamation, "Расчет точки пересечения трех плоскостей");
                    PointIntersect = null;
                    return PointIntersect;
                }
                else if (MrxVar.RangMrxMxN(MrxEq) == 1 & MrxVar.RangMrxMxN(MrxDetEq) == 1)
                {
                    //Три уравнения системы определяют одну плоскость
                    Interaction.MsgBox("Уравнения трех заданных плоскостей определяют одну плоскость" + Constants.vbCrLf + "", MsgBoxStyle.Exclamation, "Расчет точки пересечения трех плоскостей");
                    PointIntersect = null;
                    return PointIntersect;
                }
                else
                {
                    Interaction.MsgBox("Такого не должно быть. ФУНКЦИЯ PointIntersectionOf3Plans В КЛАССЕ PlaneSpace" + Constants.vbCrLf + "", MsgBoxStyle.Exclamation, "Расчет точки пересечения трех плоскостей");
                    PointIntersect = null;
                    return PointIntersect;
                }
            }
            else
            {
                //Расчет точки пересечения плоскостей по формуле Крамера (система имеет единственное решение)
                PointIntersect.X = (double)VarSolution.KramerEquationsSolution(MrxEq).GetValue(0);
                PointIntersect.Y = (double)VarSolution.KramerEquationsSolution(MrxEq).GetValue(1);
                PointIntersect.Z = (double)VarSolution.KramerEquationsSolution(MrxEq).GetValue(2);
                return PointIntersect;
            }
        }

        public double? DirectingCos(double Coordinate, double CoordinateX, double CoordinateY, double CoordinateZ)
        {
            //Функция возвращает значение направляющего косинуса по заданной координате и вектору, заданному тремя координатами
            //Обработка деления на ноль
            if (CoordinateX == 0 & CoordinateY == 0 & CoordinateZ == 0)
            {
                Interaction.MsgBox("Все координаты заданного вектора равны нулю." + Constants.vbCrLf + "Правильно задайте вектор.", MsgBoxStyle.Critical, "Расчет значения направляющего косинуса по заданной координате и вектору, заданному тремя координатами");
                return null;
            }
            return Coordinate / Math.Sqrt(Math.Pow(CoordinateX, 2) + Math.Pow(CoordinateY, 2) + Math.Pow(CoordinateZ, 2));
        }

        public double? DirectingCos(double Coordinate, double[] VectorsEndPoints)
        {
            //Функция возвращает значение направляющего косинуса по заданной координате и вектору, заданному массивом координат
            //Обработка размера массива 
            if (VectorsEndPoints.GetUpperBound(0) != 2)
            {
                Interaction.MsgBox("Вектор задан более или менее, чем тремя координатами." + Constants.vbCrLf + "Правильно задайте вектор.", MsgBoxStyle.Critical, "Расчет значения направляющего косинуса по заданной координате и вектору, заданному массивом координат");
                return null;
            }
            //Обработка деления на ноль
            if ((double)VectorsEndPoints.GetValue(0) == 0 & (double)VectorsEndPoints.GetValue(1) == 0 & (double)VectorsEndPoints.GetValue(2) == 0)
            {
                Interaction.MsgBox("Все координаты заданного вектора равны нулю." + Constants.vbCrLf + "Правильно задайте вектор.", MsgBoxStyle.Exclamation, "Расчет значения направляющего косинуса по заданной координате и вектору, заданному массивом координат");
                return null;
            }
            return Coordinate / Math.Sqrt(Math.Pow((double)VectorsEndPoints.GetValue(0), 2) + Math.Pow((double)VectorsEndPoints.GetValue(1), 2) + Math.Pow((double)VectorsEndPoints.GetValue(2), 2));
        }

        public double? DirectingCos(int CoordinateIndex, GeomObjects.Points.Point3D VectorForwardPoint, GeomObjects.Points.Point3D VectorEndPoint)
        {
            //Функция возвращает значение направляющего косинуса по заданной координате и вектору, заданному двумя точками
            //Обработка деления на ноль
            if (VectorEndPoint.X == VectorForwardPoint.X & VectorEndPoint.Y == VectorForwardPoint.Y & VectorEndPoint.Z == VectorForwardPoint.Z)
            {
                Interaction.MsgBox("Модуль заданного вектора равен нулю." + Constants.vbCrLf + "Правильно задайте начальную и конечную точки вектора.", MsgBoxStyle.Critical, "Расчет значения направляющего косинуса по заданной координате и вектору, заданному двумя точками");
                return null;
            }
            //Обработка ошибки при задании индекса координаты
            if (CoordinateIndex == 1)
            {
                return (VectorEndPoint.X - VectorForwardPoint.X) / Math.Sqrt(Math.Pow((VectorEndPoint.X - VectorForwardPoint.X), 2) + Math.Pow((VectorEndPoint.Y - VectorForwardPoint.Y), 2) + Math.Pow((VectorEndPoint.Z - VectorForwardPoint.Z), 2));
            }
            else if (CoordinateIndex == 2)
            {
                return (VectorEndPoint.Y - VectorForwardPoint.Y) / Math.Sqrt(Math.Pow((VectorEndPoint.X - VectorForwardPoint.X), 2) + Math.Pow((VectorEndPoint.Y - VectorForwardPoint.Y), 2) + Math.Pow((VectorEndPoint.Z - VectorForwardPoint.Z), 2));
            }
            else if (CoordinateIndex == 3)
            {
                return (VectorEndPoint.Z - VectorForwardPoint.Z) / Math.Sqrt(Math.Pow((VectorEndPoint.X - VectorForwardPoint.X), 2) + Math.Pow((VectorEndPoint.Y - VectorForwardPoint.Y), 2) + Math.Pow((VectorEndPoint.Z - VectorForwardPoint.Z), 2));
            }
            else
            {
                Interaction.MsgBox("Индекс координаты вектора задан не верно." + Constants.vbCrLf + "Правильно задайте индекс координаты вектора: 1-x; 2-y; 3-z.", MsgBoxStyle.Exclamation, "Расчет значения направляющего косинуса по заданной координате и вектору, заданному двумя точками");
                return null;
            }
        }

        public double? DirectingCos(double Coordinate, GeomObjects.Points.Point3D VectorEndPoint)
        {
            //Функция возвращает значение направляющего косинуса по заданной координате и заданному вектору
            //Обработка деления на ноль
            if (VectorEndPoint.X == 0 & VectorEndPoint.Y == 0 & VectorEndPoint.Z == 0)
            {
                Interaction.MsgBox("Все координаты конечной точки заданного вектора не должны равняться нулю." + Constants.vbCrLf + "Правильно задайте вектор.", MsgBoxStyle.Critical, "Расчет значения направляющего косинуса по заданной координате и заданному вектору");
                return null;
            }
            return Coordinate / Math.Sqrt(Math.Pow(VectorEndPoint.X, 2) + Math.Pow(VectorEndPoint.Y, 2) + Math.Pow(VectorEndPoint.Z, 2));
        }

        public bool IntersectionLineAndPlan(GeomObjects.Lines.Line3D Line, PlaneSpace Plane)
        {
            //Функция возвращает "TRUE" если заданная 3D прямая пересекается с заданной плоскостью
            double s = 0;
            double g = 0;
            GeomObjects.Lines.Line3D LineVar = new GeomObjects.Lines.Line3D();
            //' ''If MyClass.PlanFalse(Plane) = True Or LineVar.LineFalse(Line) = True Then
            //' ''    MsgBox("Прямая или плоскость или оба элемента заданы не корректно." & vbCrLf & _
            //' ''           "Правильно задайте прямую и плоскость.", MsgBoxStyle.Critical, "Контроль существования пересечения 3D прямой с плоскостью")
            //' ''    Return Nothing
            //' ''    Exit Function
            //' ''End If
            s = Plane.A * Line.kx + Plane.B * Line.ky + Plane.C * Line.kz;
            g = Plane.A * Line.Point_0.X + Plane.B * Line.Point_0.Y + Plane.C * Line.Point_0.Z + Plane.D;
            //If s = 0 And g <> 0 Then
            if (Math.Abs(s) <= this.SolveErrorPl & (g < -this.SolveErrorPl | g > this.SolveErrorPl))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool LineToPlanParallele(GeomObjects.Lines.Line3D Line, PlaneSpace Plane)
        {
            //Функция возвращает "TRUE" если заданная 3D прямая параллельна заданной плоскости
            double s = 0;
            GeomObjects.Lines.Line3D LineVar = new GeomObjects.Lines.Line3D();
            //' ''If MyClass.PlanFalse(Plane) = True Or LineVar.LineFalse(Line) = True Then
            //' ''    MsgBox("Прямая или плоскость или оба элемента заданы не корректно." & vbCrLf & _
            //' ''           "Правильно задайте прямую и плоскость.", MsgBoxStyle.Critical, "Контроль параллельности 3D прямой с плоскостью")
            //' ''    Return Nothing
            //' ''    Exit Function
            //' ''End If
            s = Plane.A * Line.kx + Plane.B * Line.ky + Plane.C * Line.kz;
            //If s <> 0 Then
            //    Return False
            if (Math.Abs(s) <= this.SolveErrorPl)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LineToPlanePerpendiculare(GeomObjects.Lines.Line3D Line, PlaneSpace Plane)
        {
            //Функция возвращает "TRUE" если заданная 3D прямая перпендикулярна заданной плоскости
            GeomObjects.Lines.Line3D LineVar = new GeomObjects.Lines.Line3D();
            //' ''If MyClass.PlanFalse(Plane) = True Or LineVar.LineFalse(Line) = True Then
            //' ''    MsgBox("Прямая или плоскость или оба элемента заданы не корректно." & vbCrLf & _
            //' ''           "Правильно задайте прямую и плоскость.", MsgBoxStyle.Critical, "Контроль перпендикулярности 3D прямой с плоскостью")
            //' ''    Return Nothing
            //' ''    Exit Function
            //' ''End If
            //If Plane.A * Line.ky = Plane.B * Line.kx And _
            //   Plane.A * Line.kz = Plane.C * Line.kx And _
            //   Plane.B * Line.kz = Plane.C * Line.ky Then
            //    Return True
            if (Math.Abs(Plane.A * Line.ky - Plane.B * Line.kx) >= this.SolveErrorPl & Math.Abs(Plane.A * Line.kz - Plane.C * Line.kx) >=
                this.SolveErrorPl & Math.Abs(Plane.B * Line.kz - Plane.C * Line.ky) >= this.SolveErrorPl)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PlanFalse(PlaneSpace Plane)
        {
            //Функция возвращает "TRUE" если 3D плоскость задана не корректно
            if (Plane.A == 0 & Plane.B == 0 & Plane.C == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //========================= Расчет квадранта плоскости, в котором находится точка или ее проекция ===============================
        public int NumQuarterPlaneByPoint(GeomObjects.Points.Point3D Point, GeomObjects.Lines.Line3D Axis1_X, GeomObjects.Lines.Line3D Axis2_Y, Int16 DirectionAxis1_X, Int16 DirectionAxis2_Y)
        {
            //Функция возвращает номер квадранта плоскости, заданной первой и второй (X и Y) осями, в котором находится заданная точка или ее проекция.
            //1 если точка находится в первом квадранте, 2 - во втором, 3 - в третьем, 4 - в четвертом, 0 - в точке пересечения осей
            //12 - на оси 1 (X) сверху от оси 2 (Y), 23 - на оси 2 (Y) слева от оси 1 (X)
            //34 - на оси 1 (X) снизу от оси 2 (Y), 14 - на оси 2 (Y) справа от оси 1 (X)
            //Направления осей (DirectionAxisi_N): 1 - ось базиса направлена вправо, 2 - влево, 3 - вверх, 4 - вниз,

            GeomObjects.Lines.Line3D LineVar = new GeomObjects.Lines.Line3D();
            //Переменная для работы с контролем прямой

            //=======================================================================
            //Контроль корректности задания осей
            //Контроль пересечения осей
            if (LinePositionControl.LineToLineIntersect(Axis1_X, Axis2_Y) == false)
            {
                Interaction.MsgBox("Заданные оси плоскости не пересекаются", MsgBoxStyle.Critical, "Расчет номера квадранта плоскости, заданной двумя осями, в котором находится заданная точка или ее проекция");

                //===========!!!!!!!!!!!!!!Обработать (ВЕРНУТЬ) ошибку !!!!!!!!!!!!!==================

                return -100;
            }
            //Контроль перпендикулярности осей
            if (LinePositionControl.LineToLinePerpendiculare(Axis1_X, Axis2_Y) == false)
            {
                Interaction.MsgBox("Заданные оси плоскости не перпендикулярны друг другу", MsgBoxStyle.Critical, "Расчет номера квадранта плоскости, заданной двумя осями, в котором находится заданная точка или ее проекция");

                //===========!!!!!!!!!!!!!!Обработать (ВЕРНУТЬ) ошибку !!!!!!!!!!!!!==================

                return -100;
            }

            //Контроль корректности задания направления осей
            if (DirectionAxis1_X == DirectionAxis2_Y | DirectionAxis1_X == 1 & DirectionAxis2_Y == 2 | DirectionAxis1_X == 2 & DirectionAxis2_Y == 1 | DirectionAxis1_X == 3 & DirectionAxis2_Y == 4 | DirectionAxis1_X == 4 & DirectionAxis2_Y == 3)
            {
                Interaction.MsgBox("Направления заданных осей плоскости совпадают или не задают плоскость", MsgBoxStyle.Critical, "Расчет номера квадранта плоскости, заданной двумя осями, в котором находится заданная точка или ее проекция");

                //===========!!!!!!!!!!!!!!Обработать (ВЕРНУТЬ) ошибку !!!!!!!!!!!!!==================

                return -100;
            }
            //=======================================================================
            //Контроль принадлежности заданной точки первой оси
            dynamic LinePtToAxis1 = default(GeomObjects.Lines.Line3D);
            GeomObjects.Lines.Line3D LineVarX = new GeomObjects.Lines.Line3D();
            GeomObjects.Points.Point3D ProePointToAxis1 = new GeomObjects.Points.Point3D();
            if (LinePositionControl.PointOfLine(Point, Axis1_X) == false)
            {
                //Построение проекции заданной точки на первую (X) ось
                LinePtToAxis1.PerpendicularPointToLine(Axis1_X, Point);
                //перпендикуляр из заданной точки на первую (X) ось
                ProePointToAxis1 = LinesCalculator.LinesIntersectPoint(Axis1_X, LinePtToAxis1);
                //Проекция заданной точки на первую (X) ось
            }
            else
            {
                ProePointToAxis1 = Point;
            }
            //Контроль принадлежности заданной точки второй оси
            dynamic LinePtToAxis2 = default(GeomObjects.Lines.Line3D);
            GeomObjects.Lines.Line3D LineVarY = new GeomObjects.Lines.Line3D();
            GeomObjects.Points.Point3D ProePointToAxis2 = new GeomObjects.Points.Point3D();
            if (LinePositionControl.PointOfLine(Point, Axis2_Y) == false)
            {
                //Построение проекции заданной точки на вторую (Y) ось
                LinePtToAxis2.PerpendicularPointToLine(Axis2_Y, Point);
                //Перпендикуляр из заданной точки на вторую (Y) ось
                ProePointToAxis2 = LinesCalculator.LinesIntersectPoint(Axis2_Y, LinePtToAxis2);
                //Проекция заданной точки на вторую (Y) ось
            }
            else
            {
                ProePointToAxis2 = Point;
            }
            //=======================================================================
            //Расчет положения найденных проекций заданной точки относительно точки пересечения осей (по параметрам t1 и t2 для обоих осей) 
            //Перенос базовых точек осей в точку пересечения осей
            dynamic NewAxis1 = default(GeomObjects.Lines.Line3D);
            dynamic NewAxis2 = default(GeomObjects.Lines.Line3D);
            GeomObjects.Lines.Line3D LineVarNew = new GeomObjects.Lines.Line3D();

            NewAxis1.ParallelPointToLine(Axis1_X, LinesCalculator.LinesIntersectPoint(Axis1_X, Axis2_Y));
            NewAxis2.ParallelPointToLine(Axis2_Y, LinesCalculator.LinesIntersectPoint(Axis1_X, Axis2_Y));
            //Расчет параметров t1 и t2 для обоих осей по положению проекций заданной точки на каждую ось
            double t1 = 0;
            double t2 = 0;
            t1 = LineVarNew.GetLine_t(ProePointToAxis1, NewAxis1);
            t2 = LineVarNew.GetLine_t(ProePointToAxis2, NewAxis2);
            //Контроль задания направляения осей
            //X вправо, Y вверх
            if (DirectionAxis1_X == 1 & DirectionAxis2_Y == 3)
            {
                goto CalcCase1;
                //X вправо, Y вниз
            }
            else if (DirectionAxis1_X == 1 & DirectionAxis2_Y == 4)
            {
                goto CalcCase2;
                //X влево, Y вверх
            }
            else if (DirectionAxis1_X == 2 & DirectionAxis2_Y == 3)
            {
                goto CalcCase3;
                //X влево, Y вниз
            }
            else if (DirectionAxis1_X == 2 & DirectionAxis2_Y == 4)
            {
                goto CalcCase4;
                //X вверх, Y вправо
            }
            else if (DirectionAxis1_X == 3 & DirectionAxis2_Y == 1)
            {
                goto CalcCase5;
                //X вверх, Y влево
            }
            else if (DirectionAxis1_X == 3 & DirectionAxis2_Y == 2)
            {
                goto CalcCase6;
                //X вниз, Y вправо
            }
            else if (DirectionAxis1_X == 4 & DirectionAxis2_Y == 1)
            {
                goto CalcCase7;
                //X вниз, Y влево
            }
            else if (DirectionAxis1_X == 4 & DirectionAxis2_Y == 2)
            {
                goto CalcCase8;
            }
            else
            {
                Interaction.MsgBox("Ошибка расчета квадранта плоскости, в котором находится проекция заданной точки." + Constants.vbCrLf + "Не корректно заданы направления осей плоскости.", MsgBoxStyle.Critical, "Расчет номера квадранта плоскости, заданной двумя осями, в котором находится заданная точка или ее проекция");

                //!!!!!!!!!!!!!!!!! ВЕРНУТЬ ОШИБКУ !!!!!!!!!!!!!!!!!!!!
                return -100;
                //!!!!!!!!!!!!!!!!! ВЕРНУТЬ ОШИБКУ !!!!!!!!!!!!!!!!!!!!
            }
        CalcCase1:
            //Расчет квадранта
            if (t1 > 0 & t2 > 0)
            {
                return 1;
                //Первый квадрант
            }
            else if (t1 < 0 & t2 > 0)
            {
                return 2;
                //Второй квадрант
            }
            else if (t1 < 0 & t2 < 0)
            {
                return 3;
                //Третий квадрант
            }
            else if (t1 > 0 & t2 < 0)
            {
                return 4;
                //Четвертый квадрант
            }
            else if (t1 == 0 & t2 == 0)
            {
                return 0;
                //Точка пересечения осей
            }
            else if (t1 == 0 & t2 > 0)
            {
                return 12;
                //Ось 2 (Y) сверху от оси 1 (X)
            }
            else if (t1 == 0 & t2 < 0)
            {
                return 34;
                //Ось 2 (Y) снизу от оси 1 (X)
            }
            else if (t1 > 0 & t2 == 0)
            {
                return 14;
                //Ось 1 (X) справа от оси 2 (Y)
            }
            else if (t1 < 0 & t2 == 0)
            {
                return 23;
                //Ось 1 (X) слева от оси 2 (Y)
            }
            else
            {
                Interaction.MsgBox("Ошибка расчета квадранта плоскости, в котором находится проекция заданной точки." + Constants.vbCrLf + "Не удается рассчитать числовые множители (t) для осей, задающих плоскость базиса.", MsgBoxStyle.Critical, "Расчет номера квадранта плоскости, заданной двумя осями, в котором находится заданная точка или ее проекция");

                //!!!!!!!!!!!!!!!!! ВЕРНУТЬ ОШИБКУ !!!!!!!!!!!!!!!!!!!!
                return -100;
                //!!!!!!!!!!!!!!!!! ВЕРНУТЬ ОШИБКУ !!!!!!!!!!!!!!!!!!!!

            }
        CalcCase2:
            //Расчет квадранта
            if (t1 > 0 & t2 > 0)
            {
                return 4;
                //Четвертый квадрант
            }
            else if (t1 < 0 & t2 > 0)
            {
                return 3;
                //Третий квадрант
            }
            else if (t1 < 0 & t2 < 0)
            {
                return 2;
                //Второй квадрант
            }
            else if (t1 > 0 & t2 < 0)
            {
                return 1;
                //Первый квадрант
            }
            else if (t1 == 0 & t2 == 0)
            {
                return 0;
                //Точка пересечения осей
            }
            else if (t1 == 0 & t2 > 0)
            {
                return 34;
                //Ось 2 (Y) снизу от оси 1 (X)
            }
            else if (t1 == 0 & t2 < 0)
            {
                return 12;
                //Ось 2 (Y) сверху от оси 1 (X)
            }
            else if (t1 > 0 & t2 == 0)
            {
                return 14;
                //Ось 1 (X) справа от оси 2 (Y)
            }
            else if (t1 < 0 & t2 == 0)
            {
                return 23;
                //Ось 1 (X) слева от оси 2 (Y)
            }
            else
            {
                Interaction.MsgBox("Ошибка расчета квадранта плоскости, в котором находится проекция заданной точки." + Constants.vbCrLf + "Не удается рассчитать числовые множители (t) для осей, задающих плоскость базиса.", MsgBoxStyle.Critical, "Расчет номера квадранта плоскости, заданной двумя осями, в котором находится заданная точка или ее проекция");

                //!!!!!!!!!!!!!!!!! ВЕРНУТЬ ОШИБКУ !!!!!!!!!!!!!!!!!!!!
                return -100;
                //!!!!!!!!!!!!!!!!! ВЕРНУТЬ ОШИБКУ !!!!!!!!!!!!!!!!!!!!

            }
        CalcCase3:
            //Расчет квадранта
            if (t1 > 0 & t2 > 0)
            {
                return 2;
                //Второй квадрант
            }
            else if (t1 < 0 & t2 > 0)
            {
                return 1;
                //Первый квадрант
            }
            else if (t1 < 0 & t2 < 0)
            {
                return 4;
                //Четвертый квадрант
            }
            else if (t1 > 0 & t2 < 0)
            {
                return 3;
                //Третий квадрант
            }
            else if (t1 == 0 & t2 == 0)
            {
                return 0;
                //Точка пересечения осей
            }
            else if (t1 == 0 & t2 > 0)
            {
                return 12;
                //Ось 2 (Y) сверху от оси 1 (X)
            }
            else if (t1 == 0 & t2 < 0)
            {
                return 34;
                //Ось 2 (Y) снизу от оси 1 (X)
            }
            else if (t1 > 0 & t2 == 0)
            {
                return 23;
                //Ось 1 (X) слева от оси 2 (Y)
            }
            else if (t1 < 0 & t2 == 0)
            {
                return 14;
                //Ось 1 (X) справа от оси 2 (Y)
            }
            else
            {
                Interaction.MsgBox("Ошибка расчета квадранта плоскости, в котором находится проекция заданной точки." + Constants.vbCrLf + "Не удается рассчитать числовые множители (t) для осей, задающих плоскость базиса.", MsgBoxStyle.Critical, "Расчет номера квадранта плоскости, заданной двумя осями, в котором находится заданная точка или ее проекция");

                //!!!!!!!!!!!!!!!!! ВЕРНУТЬ ОШИБКУ !!!!!!!!!!!!!!!!!!!!
                return -100;
                //!!!!!!!!!!!!!!!!! ВЕРНУТЬ ОШИБКУ !!!!!!!!!!!!!!!!!!!!

            }
        CalcCase4:
            //Расчет квадранта
            if (t1 > 0 & t2 > 0)
            {
                return 3;
                //Третий квадрант
            }
            else if (t1 < 0 & t2 > 0)
            {
                return 4;
                //Четвертый квадрант
            }
            else if (t1 < 0 & t2 < 0)
            {
                return 1;
                //Первый квадрант
            }
            else if (t1 > 0 & t2 < 0)
            {
                return 2;
                //Второй квадрант
            }
            else if (t1 == 0 & t2 == 0)
            {
                return 0;
                //Точка пересечения осей
            }
            else if (t1 == 0 & t2 > 0)
            {
                return 34;
                //Ось 2 (Y) снизу от оси 1 (X)
            }
            else if (t1 == 0 & t2 < 0)
            {
                return 12;
                //Ось 2 (Y) сверху от оси 1 (X)
            }
            else if (t1 > 0 & t2 == 0)
            {
                return 23;
                //Ось 1 (X) слева от оси 2 (Y)
            }
            else if (t1 < 0 & t2 == 0)
            {
                return 14;
                //Ось 1 (X) справа от оси 2 (Y)
            }
            else
            {
                Interaction.MsgBox("Ошибка расчета квадранта плоскости, в котором находится проекция заданной точки." + Constants.vbCrLf + "Не удается рассчитать числовые множители (t) для осей, задающих плоскость базиса.", MsgBoxStyle.Critical, "Расчет номера квадранта плоскости, заданной двумя осями, в котором находится заданная точка или ее проекция");

                //!!!!!!!!!!!!!!!!! ВЕРНУТЬ ОШИБКУ !!!!!!!!!!!!!!!!!!!!
                return -100;
                //!!!!!!!!!!!!!!!!! ВЕРНУТЬ ОШИБКУ !!!!!!!!!!!!!!!!!!!!

            }
        CalcCase5:
            //Расчет квадранта
            if (t1 > 0 & t2 > 0)
            {
                return 1;
                //Первый квадрант
            }
            else if (t1 < 0 & t2 > 0)
            {
                return 4;
                //Четвертый квадрант
            }
            else if (t1 < 0 & t2 < 0)
            {
                return 3;
                //Третий квадрант
            }
            else if (t1 > 0 & t2 < 0)
            {
                return 2;
                //Второй квадрант
            }
            else if (t1 == 0 & t2 == 0)
            {
                return 0;
                //Точка пересечения осей
            }
            else if (t1 == 0 & t2 > 0)
            {
                return 14;
                //Ось 2 (Y) справа от оси 1 (X)
            }
            else if (t1 == 0 & t2 < 0)
            {
                return 23;
                //Ось 2 (Y) слева от оси 1 (X)
            }
            else if (t1 > 0 & t2 == 0)
            {
                return 12;
                //Ось 1 (X) сверху от оси 2 (Y)
            }
            else if (t1 < 0 & t2 == 0)
            {
                return 34;
                //Ось 1 (X) снизу от оси 2 (Y)
            }
            else
            {
                Interaction.MsgBox("Ошибка расчета квадранта плоскости, в котором находится проекция заданной точки." + Constants.vbCrLf + "Не удается рассчитать числовые множители (t) для осей, задающих плоскость базиса.", MsgBoxStyle.Critical, "Расчет номера квадранта плоскости, заданной двумя осями, в котором находится заданная точка или ее проекция");

                //!!!!!!!!!!!!!!!!! ВЕРНУТЬ ОШИБКУ !!!!!!!!!!!!!!!!!!!!
                return -100;
                //!!!!!!!!!!!!!!!!! ВЕРНУТЬ ОШИБКУ !!!!!!!!!!!!!!!!!!!!

            }
        CalcCase6:
            //Расчет квадранта
            if (t1 > 0 & t2 > 0)
            {
                return 2;
                //Второй квадрант
            }
            else if (t1 < 0 & t2 > 0)
            {
                return 3;
                //Третий квадрант
            }
            else if (t1 < 0 & t2 < 0)
            {
                return 4;
                //Четвертый квадрант
            }
            else if (t1 > 0 & t2 < 0)
            {
                return 1;
                //Первый квадрант
            }
            else if (t1 == 0 & t2 == 0)
            {
                return 0;
                //Точка пересечения осей
            }
            else if (t1 == 0 & t2 > 0)
            {
                return 23;
                //Ось 2 (Y) слева от оси 1 (X)
            }
            else if (t1 == 0 & t2 < 0)
            {
                return 14;
                //Ось 2 (Y) справа от оси 1 (X)
            }
            else if (t1 > 0 & t2 == 0)
            {
                return 12;
                //Ось 1 (X) сверху от оси 2 (Y)
            }
            else if (t1 < 0 & t2 == 0)
            {
                return 34;
                //Ось 1 (X) снизу от оси 2 (Y)
            }
            else
            {
                Interaction.MsgBox("Ошибка расчета квадранта плоскости, в котором находится проекция заданной точки." + Constants.vbCrLf + "Не удается рассчитать числовые множители (t) для осей, задающих плоскость базиса.", MsgBoxStyle.Critical, "Расчет номера квадранта плоскости, заданной двумя осями, в котором находится заданная точка или ее проекция");

                //!!!!!!!!!!!!!!!!! ВЕРНУТЬ ОШИБКУ !!!!!!!!!!!!!!!!!!!!
                return -100;
                //!!!!!!!!!!!!!!!!! ВЕРНУТЬ ОШИБКУ !!!!!!!!!!!!!!!!!!!!

            }
        CalcCase7:
            //Расчет квадранта
            if (t1 > 0 & t2 > 0)
            {
                return 4;
                //Четвертый квадрант
            }
            else if (t1 < 0 & t2 > 0)
            {
                return 1;
                //Первый квадрант
            }
            else if (t1 < 0 & t2 < 0)
            {
                return 2;
                //Второй квадрант
            }
            else if (t1 > 0 & t2 < 0)
            {
                return 3;
                //Третий квадрант
            }
            else if (t1 == 0 & t2 == 0)
            {
                return 0;
                //Точка пересечения осей
            }
            else if (t1 == 0 & t2 > 0)
            {
                return 14;
                //Ось 2 (Y) справа от оси 1 (X)
            }
            else if (t1 == 0 & t2 < 0)
            {
                return 23;
                //Ось 2 (Y) слева от оси 1 (X)
            }
            else if (t1 > 0 & t2 == 0)
            {
                return 34;
                //Ось 1 (X) снизу от оси 2 (Y)
            }
            else if (t1 < 0 & t2 == 0)
            {
                return 12;
                //Ось 1 (X) сверху от оси 2 (Y)
            }
            else
            {
                Interaction.MsgBox("Ошибка расчета квадранта плоскости, в котором находится проекция заданной точки." + Constants.vbCrLf + "Не удается рассчитать числовые множители (t) для осей, задающих плоскость базиса.", MsgBoxStyle.Critical, "Расчет номера квадранта плоскости, заданной двумя осями, в котором находится заданная точка или ее проекция");

                //!!!!!!!!!!!!!!!!! ВЕРНУТЬ ОШИБКУ !!!!!!!!!!!!!!!!!!!!
                return -100;
                //!!!!!!!!!!!!!!!!! ВЕРНУТЬ ОШИБКУ !!!!!!!!!!!!!!!!!!!!

            }
        CalcCase8:
            //Расчет квадранта
            if (t1 > 0 & t2 > 0)
            {
                return 3;
                //Третий квадрант
            }
            else if (t1 < 0 & t2 > 0)
            {
                return 2;
                //Второй квадрант
            }
            else if (t1 < 0 & t2 < 0)
            {
                return 1;
                //Первый квадрант
            }
            else if (t1 > 0 & t2 < 0)
            {
                return 4;
                //Четвертый квадрант
            }
            else if (t1 == 0 & t2 == 0)
            {
                return 0;
                //Точка пересечения осей
            }
            else if (t1 == 0 & t2 > 0)
            {
                return 23;
                //Ось 2 (Y) слева от оси 1 (X)
            }
            else if (t1 == 0 & t2 < 0)
            {
                return 14;
                //Ось 2 (Y) справа от оси 1 (X)
            }
            else if (t1 > 0 & t2 == 0)
            {
                return 34;
                //Ось 1 (X) снизу от оси 2 (Y)
            }
            else if (t1 < 0 & t2 == 0)
            {
                return 12;
                //Ось 1 (X) сверху от оси 2 (Y)
            }
            else
            {
                Interaction.MsgBox("Ошибка расчета квадранта плоскости, в котором находится проекция заданной точки." + Constants.vbCrLf + "Не удается рассчитать числовые множители (t) для осей, задающих плоскость базиса.", MsgBoxStyle.Critical, "Расчет номера квадранта плоскости, заданной двумя осями, в котором находится заданная точка или ее проекция");

                //!!!!!!!!!!!!!!!!! ВЕРНУТЬ ОШИБКУ !!!!!!!!!!!!!!!!!!!!
                return -100;
                //!!!!!!!!!!!!!!!!! ВЕРНУТЬ ОШИБКУ !!!!!!!!!!!!!!!!!!!!

            }
        }

        //'Private Sub LineByTwoPlans(ByVal Plane1 As BaseGeometryYVP.GeomObjects.PlaneSpace, ByVal Plane2 As BaseGeometryYVP.GeomObjects.PlaneSpace)
        //'    'Конструктор возвращает значения коэффициентов 3D прямой, заданной двумя плоскостями
        //'    Dim LineVar As New BaseGeometryYVP.GeomObjects.Lines.Line3D
        //'    Dim Line3DNew As New Line3D(Plane1, Plane2) '+Контроль корректности задания плоскостей

        //'    kx = Line3DNew.kx : ky = Line3DNew.ky : kz = Line3DNew.kz
        //'    Point_0.x = Line3DNew.Point_0.x : Point_0.y = Line3DNew.Point_0.y : Point_0.z = Line3DNew.Point_0.z
        //'End Sub



    }

    //================================================================================================
    //================================================================================================

    //Public Sub Plane3DRotateAlong(ByVal Plane As PlaneSpace, ByVal Angle As Double)
    //    'Конструктор поворота плоскости на заданный угол

    //End Sub

    //Public Sub Plane3DRotateAgainst(ByVal Plane As PlaneSpace, ByVal Angle As Double)
    //    'Конструктор поворота плоскости на заданный угол

    //End Sub

    //Public Overloads Sub RotatePlaneToLine(ByVal Plane As PlaneSpace, ByVal Line As BaseGeometryYVP.GeomObjects.Lines.Line3D)
    //    'Конструктор поворота плоскости до совпадения с заданной прямой

    //End Sub

    //Public Overloads Sub RotatePlaneToPlane(ByVal BasePlane As PlaneSpace, ByVal RotatePlane As PlaneSpace)
    //    'Конструктор поворота плоскости до совпадения с заданной плоскостью
    //    'Если нужен????? По сути конструктор расчета улгла между 2-мя плоскостями
    //End Sub
}
