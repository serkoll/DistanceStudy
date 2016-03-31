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

namespace GeomObjects.Lines
{
    /// <summary>
    /// Класс действий с параметрами 2D и 3D линий
    /// </summary>
    /// Copyright © Polozkov V. Yury, 2014
    /// <remarks>Copyright © Polozkov V. Yury, 2014</remarks>
    public static class LinesCalculator
    {
        //Переменная для действий с 2D прямыми
        //private GeomObjects.Lines.Line2D LineCalcVar2D = new GeomObjects.Lines.Line2D();
        //Переменная для действий с 3D прямыми
        //private GeomObjects.Lines.Line3D LineCalcVar3D = new GeomObjects.Lines.Line3D();
        //Переменная для действий с контролем положения прямых
        //private GeomObjects.Lines.LinePositionControl LinePositionControlVar = new GeomObjects.Lines.LinePositionControl();
        //Переменная для работы с расчетом прямых
        // private GeomObjects.Lines.LinesControl LinesControlVar = new GeomObjects.Lines.LinesControl();

        //-------------------- Расчет расстояния между двумя 2D прямыми ---------------------

        /// <summary>
        /// Функция расчета расстояния между двумя 2D прямыми
        /// </summary>
        /// <param name="Line1">Первая 2D прямая</param>
        /// <param name="Line2">Вторая 2D прямая</param>
        /// <returns>Возвращает значение расстояния между двумя параллельными 2D прямыми</returns>
        /// <remarks>!!! Не реализована !!!</remarks>
        public static double DistantionLineToLine(Line2D Line1, Line2D Line2)
        {

            return 0;
        }

        //-------------------- Расчет расстояния между двумя 3D прямыми ---------------------

        /// <summary>
        /// Функция расчета расстояния между двумя 3D прямыми
        /// </summary>
        /// <param name="Line1">Первая 3D прямая</param>
        /// <param name="Line2">Вторая 3D прямая</param>
        /// <returns>Возвращает значение расстояния между двумя параллельными 3D прямыми</returns>
        /// <remarks></remarks>
        public static double? DistantionLineToLine(Line3D Line1, Line3D Line2)
        {
            //Функция, возвращающая величину расстояния между двумя 3D прямыми
            Line3D Line3 = new Line3D();
            Line3D Line4 = new Line3D();
            GeomObjects.Points.Point3D Point1Line3_0 = new GeomObjects.Points.Point3D();
            GeomObjects.Points.Point3D Point2Line3_0 = new GeomObjects.Points.Point3D();
            GeomObjects.Points.Point3D DistPoint3D = new GeomObjects.Points.Point3D();
            double? DistLin;
            double Agl = new double();
            //Проверяем нахождение линий в одной плоскости
            if (LinePositionControl.TwoLinesOfPlane(Line1, Line2) == true)
            {
                //Прямые пересекаются
                if (LinePositionControl.LineToLineIntersect(Line1, Line2) == true)
                {
                    return 0;
                }
                else
                {
                    //Прямые параллельны
                    if (LinePositionControl.LineToLineParallel(Line1, Line2) == true)
                    {
                        DistLin = DistantionPointToLine(Line1.Point_0, Line2);
                        return DistLin;
                    }
                    else
                    {
                        Interaction.MsgBox("Ошибка построения прямой линии." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Расчет расстояния между двумя 3D прямыми");
                        return null;
                    }
                }
                //Если MyClass.TwoLineInPlane(Line1, Line2) = False, то прямые скрещиваются.
            }
            else
            {
                //Тогда переходим к следующему расчету:
                //n - направляющий вектор прямой, задаваемый уравнением n=i*kx+j*ky+k*kz
                double i = 0;
                double j = 0;
                double k = 0;
                double n_kx = 0;
                double n_ky = 0;
                double n_kz = 0;
                i = Line2.Point_0.X - Line1.Point_0.X;
                j = Line2.Point_0.Y - Line1.Point_0.Y;
                k = Line2.Point_0.Z - Line1.Point_0.Z;
                //-----------------------
                n_kx = Line1.ky * Line2.kz - Line2.ky * Line1.kz;
                n_ky = Line2.kx * Line1.kz - Line1.kx * Line2.kz;
                n_kz = Line1.kx * Line2.ky - Line2.kx * Line1.ky;
                //Обработка деления на ноль
                if (Math.Sqrt(Math.Pow(n_kx, 2) + Math.Pow(n_ky, 2) + Math.Pow(n_kz, 2)) == 0)
                {
                    Interaction.MsgBox("Ошибка задания исходных прямых линий." + Constants.vbCrLf, MsgBoxStyle.Critical, "Расчет расстояния между двумя 3D прямыми");
                    return null;
                }
                else
                {
                    DistLin = (Math.Abs(i * n_kx + j * n_ky + k * n_kz)) / Math.Sqrt(Math.Pow(n_kx, 2) + Math.Pow(n_ky, 2) + Math.Pow(n_kz, 2));
                    return DistLin;
                }
            }
        }

        //==================================================================================
        //==================== Расчет пересечения двух прямых ==============================
        //==================================================================================
        //-------------------- Расчет пересечения двух 2D прямых ---------------------------

        /// <summary>
        /// Рассчитывает значения координат точки пересечения двух 2D прямых, заданных коэффициентами канонического уравнения
        /// </summary>
        /// <param name="a1">Первый коэффициент канонического уравнения первой прямой</param>
        /// <param name="b1">Второй коэффициент канонического уравнения первой прямой</param>
        /// <param name="a2">Первый коэффициент канонического уравнения второй прямой</param>
        /// <param name="b2">Второй коэффициент канонического уравнения второй прямой</param>
        /// <returns>Возвращает 2D точку пересечения двух 2D прямых</returns>
        /// <remarks>При всех коэффициентов каждой из заданных прямых возвращает сообщение об ошибке.
        ///  Контролирует параллельность и совпадение прямых (не проверено).
        /// </remarks>
        public static Point2D LinesIntersectPoint(double a1, double b1, double a2, double b2)
        {
            //Функция возвращает значения координат точки пересечения двух 2D прямых
            double x = 0;
            double y = 0;
            //Обработка деления на ноль
            if (a1 == 0 & b1 == 0 | a2 == 0 & b2 == 0)
            {
                Interaction.MsgBox("Ошибка задания прямых линий." + Constants.vbCrLf + "Проверьте значения коэффициентов, задающих прямые линии.", MsgBoxStyle.Critical, "Расчет точки пересечения двух 2D прямых");
                return null;
            }
            else if (a1 == 0 & a2 == 0 | b1 == 0 & b2 == 0)
            {
                Interaction.MsgBox("Отсутствует точка пересечения 2D прямых." + Constants.vbCrLf + "Заданные прямые параллельны.", MsgBoxStyle.Critical, "Расчет точки пересечения 2D прямых");
                return null;
                //===============  Когда совпадают  ======================
                //Так ли?????
            }
            else if (a1 * b2 - a2 * b1 == 0)
            {
                Interaction.MsgBox("Отсутствует точка пересечения 2D прямых." + Constants.vbCrLf + "Заданные прямые параллельны или совпадают.", MsgBoxStyle.Critical, "Расчет точки пересечения 2D прямых");
                return null;
            }
            else
            {
                x = (b1 - b2) / (a1 * b2 - a2 * b1);
                y = (a2 - a1) / (a1 * b2 - a2 * b1);
                return new GeomObjects.Points.Point2D(x, y);
            }
        }

        /// <summary>
        ///  Рассчитывает значения координат точки пересечения двух заданных 2D прямых
        /// </summary>
        /// <param name="Line1">Первая 2D прямая</param>
        /// <param name="Line2">Вторая 2D прямая</param>
        /// <returns>Возвращает 2D точку пересечения двух 2D прямых</returns>
        /// <remarks>Контролирует параллельность и совпадение прямых.
        ///  При параллельности или совпадении прямых возвращает сообщение об ошибке.
        /// </remarks>
        public static Point2D LinesIntersectPoint(Line2D Line1, Line2D Line2)
        {
            //Функция возвращает значения координат точки пересечения двух 2D прямых
            //Dim P2_Line1, P2_Line2 As New BaseGeometryYVP.GeomObjects.Points.Point2D
            double U_Line1 = 0;
            // U_Line2
            GeomObjects.Points.Point2D IntersectPoint = new GeomObjects.Points.Point2D();
            double Numerator = 0;
            double Denominator = 0;
            //Числитель, знаменатель
            //Контроль совпадения заданных прямых
            if (LinePositionControl.LinesIsLines(Line1, Line2) == true)
            {
                Interaction.MsgBox("Отсутствует точка пересечения 2D прямых." + Constants.vbCrLf + "Заданные прямые совпадают.", MsgBoxStyle.Exclamation, "Расчет точки пересечения 2D прямых");
                //IntersectPoint = Line1.Point_0
                //Return IntersectPoint
                IntersectPoint = null;
                return IntersectPoint;
            }
            //Расчет
            Numerator = (Line2.kx) * (Line1.Point_0.Y - Line2.Point_0.Y) - (Line2.ky) * (Line1.Point_0.X - Line2.Point_0.X);
            Denominator = (Line2.ky) * (Line1.kx) - (Line2.kx) * (Line1.ky);
            //U_Line2 = (line1.kx) * (line1.Point_0.y - line2.Point_0.y) - (line1.ky) * (line1.Point_0.x - line2.Point_0.x) / _
            //          (line2.ky) * (line1.kx) - (line2.kx) * (line1.ky)
            if (Denominator == 0)
            {
                Interaction.MsgBox("Отсутствует точка пересечения 2D прямых." + Constants.vbCrLf + "Заданные прямые параллельны.", MsgBoxStyle.Exclamation, "Расчет точки пересечения 2D прямых");
                IntersectPoint = null;
                return IntersectPoint;
            }
            else if (Numerator == 0 & Denominator == 0)
            {
                Interaction.MsgBox("Отсутствует точка пересечения 2D прямых." + Constants.vbCrLf + "Заданные прямые совпадают.", MsgBoxStyle.Exclamation, "Расчет точки пересечения 2D прямых");
                IntersectPoint = null;
                return IntersectPoint;
                //Если нужно найти пересечение отрезков, то нужно лишь проверить, лежат ли ua(U_Line1) и ub(U_Line2) на промежутке [0,1]. Если какая-нибудь из этих двух переменных 0 <= ui <= 1,
                //то соответствующий отрезок содержит точку пересечения. Если обе переменные приняли значения из [0,1], то точка пересечения прямых лежит внутри обоих отрезков. 
                //Для двух отрезков при достаточной разреженности объектов можно сначала проверять принципиальную возможность пересечения, сравнивая координаты концов. 
            }
            else
            {
                //Расчет точки пересечения
                U_Line1 = Numerator / Denominator;
                IntersectPoint.X = Line1.Point_0.X + U_Line1 * Line1.kx;
                IntersectPoint.Y = Line1.Point_0.Y + U_Line1 * Line1.ky;
                return IntersectPoint;
            }
            //U_Line1 = (P2_Line2.x - line2.Point_0.x) * (line1.Point_0.y - line2.Point_0.y) - (P2_Line2.y - line2.Point_0.y) * (line1.Point_0.x - line2.Point_0.x) / _
            //  (P2_Line2.y - line2.Point_0.y) * (P2_Line1.x - line1.Point_0.x) - (P2_Line2.x - line2.Point_0.x) * (P2_Line1.y - line1.Point_0.y)
            //U_Line2 = (P2_Line1.x - line1.Point_0.x) * (line1.Point_0.y - line2.Point_0.y) - (P2_Line1.y - line1.Point_0.y) * (line1.Point_0.x - line2.Point_0.x) / _
            //          (P2_Line2.y - line2.Point_0.y) * (P2_Line1.x - line1.Point_0.x) - (P2_Line2.x - line2.Point_0.x) * (P2_Line1.y - line1.Point_0.y)
        }

        //-------------------- Расчет точки пересечения двух 3D прямых ---------------------

        /// <summary>
        /// Расчет значений координат точки пересечения двух 3D прямых на основе коэффициентов уравнения прямых
        /// </summary>
        /// <param name="a1">Первый коэффициент уравнения первой 3D прямой</param>
        /// <param name="b1">Второй коэффициент уравнения первой 3D прямой</param>
        /// <param name="c1">Третий коэффициент уравнения первой 3D прямой</param>
        /// <param name="a2">Первый коэффициент уравнения второй 3D прямой</param>
        /// <param name="b2">Второй коэффициент уравнения второй 3D прямой</param>
        /// <param name="c2">Третий коэффициент уравнения второй 3D прямой</param>
        /// <returns>Возвращает точку пересечения двух 3D прямых</returns>
        /// <remarks>!!! Не реализована !!!</remarks>
        public static Point3D LinesIntersectPoint(double a1, double b1, double c1, double a2, double b2, double c2)
        {
            //Функция возвращает значения координат точки пересечения двух 3D прямых
            double x = 0;
            double y = 0;
            double z = 0;
            //Обработка деления на ноль
            //Контроль параллельности и совпадения прямых
            x = (b1 - b2) / (a1 * b2 - a2 * b1);
            y = (a2 - a1) / (a1 * b2 - a2 * b1);
            //__________??????? z (c) Ввести формулу для 3D_______________________
            z = (c2 - c1) / (a1 * b2 - a2 * b1);
            //MyBase.LineIntersect(a1, b1, a2, b2)
            //Return New Point3D(x, y, z)
            return null;
            //Пока не реализована
        }

        /// <summary>
        ///  Рассчитывает значения координат точки пересечения двух заданных 3D прямых
        /// </summary>
        /// <param name="Line1">Первая 3D прямая</param>
        /// <param name="Line2">Вторая 3D прямая</param>
        /// <returns>Возвращает 3D точку пересечения двух 3D прямых</returns>
        /// <remarks>Расчет осуществляется на основе операций с коэффициентами уравнений заданных прямых
        /// Контролирует параллельность и совпадение прямых.
        ///  При параллельности или совпадении прямых возвращает сообщение об ошибке.
        /// </remarks>
        public static Point3D LinesIntersectPoint(Line3D Line1, Line3D Line2)
        {
            //Функция возвращает значения координат точки пересечения двух 3D прямых
            Points.Point3D IntersectPoint = new Points.Point3D();
            Points.PointsPositionControl PointVar = new Points.PointsPositionControl();
            GeomObjects.Points.Point2D IntersectPoint2D = new GeomObjects.Points.Point2D();
            dynamic Lin1New = default(Line3D);
            Line3D Lin2New = new Line3D();
            dynamic Lin1New_2D = default(Line2D);
            Line2D Lin2New_2D = new Line2D();
            double Denominator = 0;
            //Знаменатель
            //Контроль прямых на пересечение + Контроль корректности задания прямой
            if (LinePositionControl.LineToLineIntersect(Line1, Line2) == false)
            {
                Interaction.MsgBox("Ошибка определения точки пересечения 3D прямых." + Constants.vbCrLf + "Заданные прямые не пересекаются.", MsgBoxStyle.Critical, "Расчет точки пересечения 3D прямых");
                IntersectPoint = null;
                return IntersectPoint;
            }
            //Контроль совпадения заданных прямых
            if (LinePositionControl.LinesIsLines(Line1, Line2) == true)
            {
                Interaction.MsgBox("Заданные прямые совпадают" + Constants.vbCrLf, MsgBoxStyle.Exclamation, "Расчет точки пересечения 3D прямых");
                //IntersectPoint = Line1.Point_0
                //Return IntersectPoint
                IntersectPoint = null;
                return IntersectPoint;
            }
            //Контроль совпадения опорных точек линий
            if (PointVar.PointsIsPoints(Line1.Point_0, Line2.Point_0) == true)
            {
                IntersectPoint = Line1.Point_0;
                return IntersectPoint;
            }
            //Расчет
            Denominator = -Line1.kz * Line2.ky + Line2.kz * Line1.ky;
            //Обработка деления на ноль
            if (Denominator == 0)
            {
                Lin1New = Line1;
                Lin2New = Line2;
                //Перемена номеров прямых
                Line1 = Lin2New;
                Line2 = Lin1New;
                //Не нужное преобразование!!!!!
                Denominator = -Line1.kz * Line2.ky + Line2.kz * Line1.ky;
                if (Denominator == 0)
                {
                    //Прямые лежат в плоскости XY
                    if (Line1.kz == 0 & Line2.kz == 0)
                    {
                        Lin1New_2D.kx = Line1.kx;
                        Lin1New_2D.ky = Line1.ky;
                        Lin1New_2D.Point_0.X = Line1.Point_0.X;
                        Lin1New_2D.Point_0.Y = Line1.Point_0.Y;
                        Lin2New_2D.kx = Line2.kx;
                        Lin2New_2D.ky = Line2.ky;
                        Lin2New_2D.Point_0.X = Line2.Point_0.X;
                        Lin2New_2D.Point_0.Y = Line2.Point_0.Y;
                        IntersectPoint2D = LinesIntersectPoint(Lin1New_2D, Lin2New_2D);
                        IntersectPoint.X = IntersectPoint2D.X;
                        IntersectPoint.Y = IntersectPoint2D.Y;
                        IntersectPoint.Z = 0;
                        return IntersectPoint;
                        //Прямые лежат в плоскости XZ
                    }
                    else if (Line2.ky == 0 & Line1.ky == 0)
                    {
                        Lin1New_2D.kx = Line1.kx;
                        Lin1New_2D.ky = Line1.kz;
                        Lin1New_2D.Point_0.X = Line1.Point_0.X;
                        Lin1New_2D.Point_0.Y = Line1.Point_0.Z;
                        Lin2New_2D.kx = Line2.kx;
                        Lin2New_2D.ky = Line2.kz;
                        Lin2New_2D.Point_0.X = Line2.Point_0.X;
                        Lin2New_2D.Point_0.Y = Line2.Point_0.Z;
                        IntersectPoint2D = LinesIntersectPoint(Lin1New_2D, Lin2New_2D);
                        IntersectPoint.X = IntersectPoint2D.X;
                        IntersectPoint.Z = IntersectPoint2D.Y;
                        IntersectPoint.Y = 0;
                        return IntersectPoint;
                        //Прямая 1 лежит на оси OX
                    }
                    else if (Line1.ky == 0 & Line1.kz == 0)
                    {
                        double Linet1 = 0;
                        double Linet2 = 0;
                        if (Line2.ky != 0)
                        {
                            Linet2 = (Line1.Point_0.Y - Line2.Point_0.Y) / Line2.ky;
                            Linet1 = (Line2.Point_0.X + Line2.kx * Linet2 - Line1.Point_0.X) / Line1.kx;
                        }
                        else if (Line2.kz != 0)
                        {
                            Linet2 = (Line1.Point_0.Z - Line2.Point_0.Z) / Line2.kz;
                            Linet1 = (Line2.Point_0.X + Line2.kx * Linet2 - Line1.Point_0.X) / Line1.kx;
                        }
                        else
                        {
                            Interaction.MsgBox("Ошибка определения точки пересечения 3D прямых." + Constants.vbCrLf + "Заданные прямые совпадают или параллельны между собой.", MsgBoxStyle.Critical, "Расчет точки пересечения 3D прямых");
                            //IntersectPoint.X = 1 / 0;
                            //IntersectPoint.Y = 1 / 0;
                            //IntersectPoint.Z = 1 / 0;
                            return IntersectPoint;
                        }
                        IntersectPoint.X = Line1.Point_0.X + Line1.kx * Linet1;
                        IntersectPoint.Y = Line1.Point_0.Y;
                        IntersectPoint.Y = Line1.Point_0.Z;
                        return IntersectPoint;
                        //Прямая 2 лежит на оси OX
                    }
                    else if (Line2.ky == 0 & Line2.kz == 0)
                    {
                        double Linet1 = 0;
                        double Linet2 = 0;
                        if (Line1.ky != 0)
                        {
                            Linet1 = (Line2.Point_0.Y - Line1.Point_0.Y) / Line1.ky;
                            Linet2 = (Line1.Point_0.X + Line1.kx * Linet1 - Line2.Point_0.X) / Line2.kx;
                        }
                        else if (Line1.kz != 0)
                        {
                            Linet1 = (Line2.Point_0.Z - Line1.Point_0.Z) / Line1.kz;
                            Linet2 = (Line1.Point_0.X + Line1.kx * Linet1 - Line2.Point_0.X) / Line2.kx;
                            //Такого не может быть, т.к. равенство нулю Line1.ky и Line1.kz отслеживалось на шаг раньше
                        }
                        else
                        {
                            Interaction.MsgBox("Ошибка определения точки пересечения 3D прямых." + Constants.vbCrLf + "Заданные прямые совпадают или параллельны между собой.", MsgBoxStyle.Critical, "Расчет точки пересечения 3D прямых");
                            //IntersectPoint.X = 1 / 0;
                            //IntersectPoint.Y = 1 / 0;
                            //IntersectPoint.Z = 1 / 0;
                            return IntersectPoint;
                        }
                        IntersectPoint.X = Line2.Point_0.X + Line2.kx * Linet2;
                        IntersectPoint.Y = Line2.Point_0.Y;
                        IntersectPoint.Y = Line2.Point_0.Z;
                        return IntersectPoint;
                    }
                    else
                    {
                        Interaction.MsgBox("Токого не должно быть" + Constants.vbCrLf, MsgBoxStyle.Exclamation, "Расчет точки пересечения 3D прямых");
                        //????????????????????
                        //IntersectPoint.X = 1 / 0;
                        //IntersectPoint.Y = 1 / 0;
                        //IntersectPoint.Z = 1 / 0;
                        return IntersectPoint;
                    }
                }
                else
                {
                    goto Calc;
                }
            }
            else
            {
                goto Calc;
            }
        Calc:
            //Расчет 3D точки пересечения двух 3D прямых
            IntersectPoint.X = (Line1.kx * Line2.ky * Line1.Point_0.Z + Line1.kx * Line2.kz * Line2.Point_0.Y - Line1.kx * Line2.ky * Line2.Point_0.Z - Line1.kx * Line1.Point_0.Y * Line2.kz - Line1.Point_0.X * Line1.kz * Line2.ky + Line1.ky * Line1.Point_0.X * Line2.kz) / Denominator;
            IntersectPoint.Y = (-Line2.ky * Line1.kz * Line1.Point_0.Y + Line2.ky * Line1.ky * Line1.Point_0.Z + Line1.ky * Line2.kz * Line2.Point_0.Y - Line1.ky * Line2.ky * Line2.Point_0.Z) / Denominator;
            IntersectPoint.Z = (Line1.kz * Line2.kz * Line2.Point_0.Y - Line1.kz * Line2.ky * Line2.Point_0.Z - Line1.kz * Line1.Point_0.Y * Line2.kz + Line1.ky * Line2.kz * Line1.Point_0.Z) / Denominator;
            return IntersectPoint;
        }

        //-------------------- Расчет значения угла между двумя пересекающимися 2D прямыми ---------------------

        /// <summary>
        /// Функция расчета значения угла между двумя пересекающимися 2D прямыми
        /// </summary>
        /// <param name="Line1">Первая 2D прямая</param>
        /// <param name="Line2">Вторая 2D прямая</param>
        /// <returns>Возвращает значение угла между двумя пересекающимися 2D прямыми</returns>
        /// <remarks>Значение угла измеряется в градусах</remarks>
        public static double LinesAngle(Line2D Line1, Line2D Line2)
        {
            //Функция возвращает значение угла между двумя пересекающимися 2D прямыми
            double AngleLines = 0;
            double CosAngle = 0;
            //Контроль совпадения заданных прямых
            if (LinePositionControl.LinesIsLines(Line1, Line2) == true)
            {
                //MsgBox("Заданные прямые совпадают" & vbCrLf, MsgBoxStyle.Exclamation, "Расчет значения угла между двумя пересекающимися 2D прямыми")
                return 0;
            }
            CosAngle = ((Line1.kx * Line2.kx) + (Line1.ky * Line2.ky));
            CosAngle = CosAngle / Math.Sqrt(Math.Pow(Line1.kx, 2) + Math.Pow(Line1.ky, 2));
            CosAngle = CosAngle / Math.Sqrt(Math.Pow(Line2.kx, 2) + Math.Pow(Line2.ky, 2));
            if (CosAngle > 1)
            {
                CosAngle = 2 - CosAngle;
                AngleLines = Math.Acos(CosAngle) * 180 / Math.PI;
                return AngleLines;
            }
            else
            {
                AngleLines = Math.Acos(CosAngle) * 180 / Math.PI;
                return AngleLines;
            }
            //_______________Второй способ с использованием угловых коэффициентов прямых 2d (Решает правильно)_______________
            //k1 = Line1.ky / Line1.kx
            //k2 = Line2.ky / Line2.kx

            //tgAngle = (k2 - k1) / (1 + k2 * k1)
            //Angle = Math.Atan(tgAngle)
            //Angle = (Math.Atan2((k2 - k1), (1 + k2 * k1))) * 180 / Math.PI '(tgAngle) * 180 / Math.PI
            //Return Angle 'Math.Atan(tgAngle) '* 180 / Math.PI

            //Rad := Grad * Pi / 180; - перевод градусов (Grad) в радианы (Rad) 
            //Grad := Rad * 180 / Pi; - обратный перевод 
        }

        //-------------------- Расчет значения угла между двумя пересекающимися 3D прямыми ---------------------

        /// <summary>
        /// Функция расчета значения угла между двумя пересекающимися 3D прямыми
        /// </summary>
        /// <param name="Line1">Первая 3D прямая</param>
        /// <param name="Line2">Вторая 3D прямая</param>
        /// <returns>Возвращает значение угла между двумя пересекающимися 3D прямыми</returns>
        /// <remarks>Значение угла измеряется в градусах</remarks>
        public static double LinesAngle(Line3D Line1, Line3D Line2)
        {
            //Функция возвращает значения угла между двумя пересекающимися 3D прямыми
            double AngleLines = 0;
            double CosAngle1 = 0;
            double CosAngle2 = 0;
            double CosAngle3 = 0;
            double a = 0;
            double b = 0;
            //_______________Первый способ (Решает правильно если прямые не принадлежат плоскости)_______________
            //Обработать ошибку принадлежности плоскости

            //Контроль совпадения заданных прямых + Контроль корректности задания прямых
            if (LinePositionControl.LinesIsLines(Line1, Line2) == true)
            {
                //MsgBox("Заданные прямые совпадают" & vbCrLf, MsgBoxStyle.Exclamation, "Расчет угла между двумя пересекающимися 3D прямыми")
                return 0;
            }
            //Расчет угла
            CosAngle1 = (Line1.kx * Line2.kx) + (Line1.ky * Line2.ky) + (Line1.kz * Line2.kz);
            a = Math.Sqrt(Math.Pow(Line1.kx, 2) + Math.Pow(Line1.ky, 2) + Math.Pow(Line1.kz, 2));
            b = Math.Sqrt(Math.Pow(Line2.kx, 2) + Math.Pow(Line2.ky, 2) + Math.Pow(Line2.kz, 2));
            CosAngle2 = CosAngle1 / (a * b);
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
            //Rad := Grad * Pi / 180; - перевод градусов (Grad) в радианы (Rad) 
            //Grad := Rad * 180 / Pi; - обратный перевод 
        }

        //==================================================================================
        //==================== Расчет взаимоотношений точки и прямой =======================
        //==================================================================================

        //-------------------- Расчет расстояния от 2D точки до 2D прямой -----------------

        /// <summary>
        /// Функция расчета расстояния от заданной 2D точки до заданной 2D прямой
        /// </summary>
        /// <param name="Point">Заданная 2D точка</param>
        /// <param name="Line">Заданная 2D прямая</param>
        /// <returns>Возвращает значение расстояния от заданной 2D точки до заданной 2D прямой</returns>
        /// <remarks></remarks>
        public static double DistantionPointToLine(GeomObjects.Points.Point2D Point, Line2D Line)
        {
            //Функция возвращает величину расстояния от заданной 2D точки до 2D прямой
            double DistPtLn = 0;
            //Рассчитывается по треугольнику
            double l_12 = 0;
            double l_23 = 0;
            double l_13 = 0;
            double Perimetr = 0;
            double S = 0;
            GeomObjects.Points.Point2D LinePt2 = new GeomObjects.Points.Point2D();
            //Вторая точка линии
            Points.PointCalculator L = new Points.PointCalculator();
            //===== Контроль инцидентности заданных точки и линии + обработка деления на ноль=====
            if (LinePositionControl.PointOfLine(Point, Line) == true)
            {
                return 0;
            }
            //Расчет длины сторон треугольника
            LinePt2.X = Line.kx + Line.Point_0.X;
            LinePt2.Y = Line.ky + Line.Point_0.Y;
            l_12 = L.PointDistantion(Line.Point_0, LinePt2);
            l_13 = L.PointDistantion(Line.Point_0, Point);
            l_23 = L.PointDistantion(LinePt2, Point);
            Perimetr = (l_12 + l_13 + l_23) / 2;
            S = Math.Sqrt(Perimetr * (Perimetr - l_12) * (Perimetr - l_13) * (Perimetr - l_23));
            //Площадь треугольника
            DistPtLn = S * 2 / l_12;
            //Расстояние как высота треугольника
            return DistPtLn;
        }

        //-------------------- Расчет расстояния от 3D точки до 3D прямой -----------------

        /// <summary>
        /// Функция расчета расстояния от заданной 3D точки до заданной 3D прямой
        /// </summary>
        /// <param name="Point">Заданная 3D точка</param>
        /// <param name="Line">Заданная 3D прямая</param>
        /// <returns>Возвращает значения расстояния от заданной 3D точки до заданной 3D прямой</returns>
        /// <remarks></remarks>
        public static double? DistantionPointToLine(Points.Point3D Point, Line3D Line)
        {
            //Функция возвращает величину расстояния от заданной 3D точки до 3D прямой
            double DistPtLn = 0;
            //Рассчитывается по треугольнику
            double l_12 = 0;
            double l_23 = 0;
            double l_13 = 0;
            double Perimetr = 0;
            double S = 0;
            Points.Point3D LinePt2 = new Points.Point3D();
            //Вторая точка линии
            Points.PointCalculator L = new Points.PointCalculator();
            //Dim LineErr As New LineErrors  'Контроль корректности задания прямой
            //Контроль корректности задания прямой
            if (LinesControl.LineTrue(Line) == false)
            {
                Interaction.MsgBox("Ошибка задания прямой линии." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Расчет расстояния от заданной 3D точки до 3D прямой");
                return null;
            }
            //Расчет
            LinePt2.X = Line.kx + Line.Point_0.X;
            LinePt2.Y = Line.ky + Line.Point_0.Y;
            LinePt2.Z = Line.kz + Line.Point_0.Z;
            //Рассчитываем длины сторон треугольника
            l_12 = L.PointDistantion(Line.Point_0, LinePt2);
            l_13 = L.PointDistantion(Line.Point_0, Point);
            l_23 = L.PointDistantion(LinePt2, Point);
            Perimetr = (l_12 + l_13 + l_23) / 2;
            S = Math.Sqrt(Perimetr * (Perimetr - l_12) * (Perimetr - l_13) * (Perimetr - l_23));
            //Площадь треугольника
            DistPtLn = S * 2 / l_12;
            //Расстояние как высота треугольника
            return DistPtLn;
        }



    }
}