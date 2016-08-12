using System;
using Microsoft.VisualBasic;

namespace GeometryObjects
{
    /// <summary>
    /// Класс анализа расположения 2D и 3D прямых
    /// </summary>
    /// Copyright © Polozkov V. Yury, 2014
    /// <remarks>Copyright © Polozkov V. Yury, 2014</remarks>
    public static class LinePositionControl
    {

        //Переменная для работы с 2D прямыми
        //private GeomObjects.Lines.Line2D LineCalcVar2D = new GeomObjects.Lines.Line2D();
        //Переменная для работы с 3D прямыми
        //private GeomObjects.Lines.Line3D LineCalcVar3D = new GeomObjects.Lines.Line3D();
        //Переменная для работы с расчетом прямых
        //private GeomObjects.Lines.LinesCalculator LinesCalculatorVar = new GeomObjects.Lines.LinesCalculator();
        //Переменная для работы с расчетом прямых
        //private GeomObjects.Lines.LinesControl LinesControlsVar = new GeomObjects.Lines.LinesControl();

        //Переменная для работы с библиотекой классо
        //==================================================================================
        //==================== Расчет взаимоотношений точки и прямой =======================
        //==================================================================================

        //-------------------- Контроль инцидентности 2D точки и 2D прямой -----------------

        /// <summary>
        /// Контроль инцидентности (принадлежности) 2D точки и 2D прямой
        /// </summary>
        /// <param name="Point">Заданная 2D точка</param>
        /// <param name="Line">Заданная 2D прямая</param>
        /// <returns>Возвращает значение "TRUE", если 2D точка инцидентна 2D прямой</returns>
        /// <remarks>Погрешность расчетов равна погрешности задания линии</remarks>
        public static bool? PointOfLine(Point2D Point, Line2D Line)
        {
            //Функция возвращает значение "TRUE", если точка принадлежит 2D прямой
            //Dim LineErr As New LineErrors
            //Контроль корректности задания прямой
            if (LinesControl.LineTrue(Line) == false)
            {
                Interaction.MsgBox("Ошибка задания прямой линии." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль инцидентности 3D точки и 3D прямой");
                return null;
            }
            if (Math.Abs((Point.X - Line.Point_0.X) * Line.ky - (Point.Y - Line.Point_0.Y) * Line.kx) < Line.SolveError)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Контроль инцидентности (принадлежности) 2D точки и 2D прямой
        /// </summary>
        /// <param name="Point">Заданная 2D точка</param>
        /// <param name="Line">Заданная 2D прямая</param>
        /// <param name="SolveError">Заданная погрешность расчета</param>
        /// <returns>Возвращает значение "TRUE", если 2D точка инцидентна 2D прямой</returns>
        /// <remarks>Нулевая погрешность расчетов не всегда обеспечивает получение решения</remarks>
        public static bool? PointOfLine(Point2D Point, Line2D Line, double SolveError)
        {
            //Функция возвращает значение "TRUE", если точка принадлежит 2D прямой
            //Dim LineErr As New LineErrors
            //Контроль корректности задания прямой
            if (LinesControl.LineTrue(Line) == false)
            {
                Interaction.MsgBox("Ошибка задания прямой линии." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль инцидентности 3D точки и 3D прямой");
                return null;
            }
            if (Math.Abs((Point.X - Line.Point_0.X) * Line.ky - (Point.Y - Line.Point_0.Y) * Line.kx) < SolveError)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //-------------------- Контроль инцидентности 3D точки и 3D прямой -----------------

        /// <summary>
        /// Контроль инцидентности (принадлежности) 3D точки и 3D прямой
        /// </summary>
        /// <param name="Point">Заданная 3D точка</param>
        /// <param name="Line">Заданная 3D прямая</param>
        /// <returns>Возвращает значение "TRUE", если 3D точка инцидентна 3D прямой</returns>
        /// <remarks>Погрешность расчетов равна погрешности задания линии</remarks>
        public static bool? PointOfLine(Point3D Point, Line3D Line)
        {
            //Функция возвращает значение "TRUE" если точка принадлежит 3D прямой
            //Dim LineErr As New LineErrors  'Переменная для контроля корректности задания прямой
            //Контроль корректности задания прямой
            if (LinesControl.LineTrue(Line) == false)
            {
                Interaction.MsgBox("Ошибка задания прямой линии." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль инцидентности 3D точки и 3D прямой");
                return null;
            }
            //Расчет
            if (Math.Abs((Point.X - Line.Point_0.X) * Line.ky - (Point.Y - Line.Point_0.Y) * Line.kx) < Line.SolveError & Math.Abs((Point.X - Line.Point_0.X) * Line.kz - (Point.Z - Line.Point_0.Z) * Line.kx) < Line.SolveError & Math.Abs((Point.Y - Line.Point_0.Y) * Line.kz - (Point.Z - Line.Point_0.Z) * Line.ky) < Line.SolveError)
            {
                //If Format((Point.x - Line.Point_0.x) * Line.ky, "##########.#####") = Format((Point.y - Line.Point_0.y) * Line.kx, "##########.#####") And _
                //   Format((Point.x - Line.Point_0.x) * Line.kz, "##########.#####") = Format((Point.z - Line.Point_0.z) * Line.kx, "##########.#####") And _
                //    Format((Point.y - Line.Point_0.y) * Line.kz, "##########.#####") = Format((Point.z - Line.Point_0.z) * Line.ky, "##########.#####") Then
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Контроль инцидентности (принадлежности) 3D точки и 3D прямой
        /// </summary>
        /// <param name="Point">Заданная 3D точка</param>
        /// <param name="Line">Заданная 3D прямая</param>
        /// <param name="SolveError">Заданная погрешность расчета</param>
        /// <returns>Возвращает значение "TRUE", если 3D точка инцидентна 3D прямой</returns>
        /// <remarks>Нулевая погрешность расчетов не всегда обеспечивает получение решения</remarks>
        public static bool? PointOfLine(Point3D Point, Line3D Line, double SolveError)
        {
            //Dim LineErr As New LineErrors  'Переменная для контроля корректности задания прямой
            //Контроль корректности задания прямой
            if (LinesControl.LineTrue(Line) == false)
            {
                Interaction.MsgBox("Ошибка задания прямой линии." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль инцидентности 3D точки и 3D прямой");
                return null;
            }
            //Расчет
            if (Math.Abs((Point.X - Line.Point_0.X) * Line.ky - (Point.Y - Line.Point_0.Y) * Line.kx) < SolveError & Math.Abs((Point.X - Line.Point_0.X) * Line.kz - (Point.Z - Line.Point_0.Z) * Line.kx) < SolveError & Math.Abs((Point.Y - Line.Point_0.Y) * Line.kz - (Point.Z - Line.Point_0.Z) * Line.ky) < SolveError)
            {
                //If Format((Point.x - Line.Point_0.x) * Line.ky, "##########.#####") = Format((Point.y - Line.Point_0.y) * Line.kx, "##########.#####") And _
                //   Format((Point.x - Line.Point_0.x) * Line.kz, "##########.#####") = Format((Point.z - Line.Point_0.z) * Line.kx, "##########.#####") And _
                //    Format((Point.y - Line.Point_0.y) * Line.kz, "##########.#####") = Format((Point.z - Line.Point_0.z) * Line.ky, "##########.#####") Then
                return true;
            }
            else
            {
                return false;
            }
        }

        //==================================================================================
        //==================== Расчет взаимоотношений прямых ===============================
        //==================================================================================

        //==================================================================================
        //==================== Расчет совпадения двух прямых ===============================
        //==================================================================================
        //-------------------- Контроль совпадения двух 2D прямых ----------------------------

        /// <summary>
        /// Контроль совпадения двух 2D прямых
        /// </summary>
        /// <param name="Line1">Первая 2D прямая</param>
        /// <param name="Line2">Вторая 2D прямая</param>
        /// <returns>Возвращает значение "TRUE" если две 2D прямые совпадают</returns>
        /// <remarks>Погрешность расчетов равна погрешности задания первой прямой</remarks>
        public static bool? LinesIsLines(Line2D Line1, Line2D Line2)
        {
            //Функция возвращает значение "TRUE" если две 2D прямые совпадают
            Point2D PointLine1_2 = new Point2D();
            Line2D LineVar = new Line2D();
            //: Dim LineErr As New LineErrors
            //Контроль корректности задания прямых
            if (LinesControl.LineTrue(Line1) == false | LinesControl.LineTrue(Line2) == false)
            {
                Interaction.MsgBox("Ошибка задания прямых линий." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль совпадения двух 2D прямых");
                return null;
            }
            //Расчет
            PointLine1_2 = Line1.GetPoint1(10);
            //Задание второй точки на первой прямой
            //Проверка принадлежности двух точек, заданных на первой прямой ко второй прямой
            if (PointOfLine(Line1.Point_0, Line2) == true & PointOfLine(PointLine1_2, Line2) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //-------------------- Контроль совпадения двух 3D прямых ----------------------------

        /// <summary>
        /// Контроль совпадения двух 3D прямых
        /// </summary>
        /// <param name="Line1">Первая 3D прямая</param>
        /// <param name="Line2">Вторая 3D прямая</param>
        /// <returns>Возвращает значение "TRUE" если две 3D прямые совпадают</returns>
        /// <remarks>Погрешность расчетов равна погрешности задания первой прямой</remarks>
        public static bool? LinesIsLines(Line3D Line1, Line3D Line2)
        {
            //Функция возвращает значение "TRUE", если две прямые совпадают
            Point3D PointLine1_2 = new Point3D();
            //Dim LineVar As New Line3D
            //Dim LineErr As New LineErrors  'Контроль корректности задания прямой
            bool? Var1 = false;
            bool? Var2 = false;
            //Контроль корректности задания прямых
            if (LinesControl.LineTrue(Line1) == false | LinesControl.LineTrue(Line2) == false)
            {
                Interaction.MsgBox("Ошибка задания прямых линий." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль совпадения двух 3D прямых");
                return null;
            }
            //Расчет
            PointLine1_2 = Line1.GetPoint(1);
            //Задание второй точки на первой прямой
            //Проверка принадлежности двух точек, заданных на первой прямой ко второй прямой
            Var1 = PointOfLine(Line1.Point_0, Line2);
            Var2 = PointOfLine(PointLine1_2, Line2);
            if (Var1 == true & Var2 == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool? LinesIsLines(LineOfPlan1X0Y line1, LineOfPlan1X0Y line2)
        {
            return LinesIsLines(line1.CnvLine2D(line1), line2.CnvLine2D(line2));
        }
        public static bool? LinesIsLines(LineOfPlan2X0Z line1, LineOfPlan2X0Z line2)
        {
            return LinesIsLines(line1.CnvLine2D(line1), line2.CnvLine2D(line2));
        }
        public static bool? LinesIsLines(LineOfPlan3Y0Z line1, LineOfPlan3Y0Z line2)
        {
            return LinesIsLines(line1.CnvLine2D(line1), line2.CnvLine2D(line2));
        }
        /// <summary>
        /// Контроль совпадения 3D прямых, заданных массивом
        /// </summary>
        /// <param name="Lines">Массив заданных 3D прямых</param>
        /// <returns>Возвращает значение "TRUE", если совпадают все прямые, заданные в массиве.</returns>
        /// <remarks>!!! Не реализована !!!</remarks>
        public static bool LinesIsLines(Line3D[] Lines)
        {
            //Функция возвращает значение "TRUE", если совпадают все прямые, заданные в массиве 
            //Dim Var As Boolean
            //Обработка деления на ноль
            //Реализовать циклом
            //Реализовать в 2D и 3D классах
            //+ Реализовать совпадение точек в 2D и 3D классах и плоскостей

            return true;
        }

        //==================================================================================
        //==================== Расчет параллельности двух прямых ========================
        //==================================================================================
        //-------------------- Контроль параллельности двух 2D прямых ---------------------
        /// <summary>
        /// Контроль параллельности двух 2D прямых 
        /// </summary>
        /// <param name="Line1">Первая 2D прямая</param>
        /// <param name="Line2">Вторая 2D прямая</param>
        /// <returns>Возвращает значение "TRUE", если две 2D прямые параллельны</returns>
        /// <remarks>!!! Не реализована !!!</remarks>
        public static bool LineToLineParallel(Line2D Line1, Line2D Line2)
        {
            //Функция возвращает значение "TRUE", если две 2D прямые параллельны

            //Контроль корректности задания прямых
            if (LineToLineIntersect(Line1, Line2) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
            //Формулу параллельности двух 2D прямых
            //???????????
        }

        //-------------------- Контроль параллельности двух 3D прямых ---------------------

        //' '' ''' <summary>
        //' '' ''' Контроль параллельности двух 3D прямых 
        //' '' ''' </summary>
        //' '' ''' <param name="Line1">Первая 3D прямая</param>
        //' '' ''' <param name="Line2">Вторая 3D прямая</param>
        //' '' ''' <returns>Возвращает значение "TRUE", если две 3D прямые параллельны</returns>
        //' '' ''' <remarks>Погрешность расчетов равна погрешности задания первой 3D прямой</remarks>
        //' ''Public Overloads Function LineToLineParallel(ByVal Line1 As Line3D, ByVal Line2 As Line3D) As Boolean
        //' ''    'Функция возвращает значение "TRUE", если две 3D прямые взаимно параллельны
        //' ''    'Расчет ведется по углу между заданными прямыми и заданной точности 
        //' ''    If LineCalcVar3D.TwoLinesOfPlane(Line1, Line2) = False Then 'Контроль инцидентности заданных прямых одной плоскости + Контроль корректности задания прямых
        //' ''        'If MyClass.TwoLinesOfPlane(Line1, Line2, ErrorSolve) = True Then 'Контроль инцидентности заданных прямых одной плоскости + Контроль корректности задания прямых 
        //' ''        MsgBox("Заданные прямые не лежат в одной плоскости.", _
        //' ''                MsgBoxStyle.Critical, "Контроль параллельности двух 3D прямых на основе расчета угла между ними")
        //' ''        Return Nothing
        //' ''        Exit Function
        //' ''    End If
        //' ''    'Dim AngleLine1Line2 As Double
        //' ''    'AngleLine1Line2 = MyClass.LinesAngle(Line1, Line2)
        //' ''    If Math.Abs(MyClass.LinesAngle(Line1, Line2)) - 0 <= Line1.ErrorSolve Or Math.Abs(MyClass.LinesAngle(Line1, Line2)) - 180 <= Line1.ErrorSolve Then
        //' ''        Return True
        //' ''    Else
        //' ''        Return False
        //' ''    End If
        //' ''End Function

        /// <summary>
        /// Контроль параллельности двух 3D прямых на основе расчета угла между прямыми
        /// </summary>
        /// <param name="Line1">Первая 3D прямая</param>
        /// <param name="Line2">Вторая 3D прямая</param>
        /// <param name="ErrorSolve">Заданная погрешность расчета</param>
        /// <returns>Возвращает значение "TRUE", если две 3D прямые параллельны (угол меду прямыми равен "0" или "180")</returns>
        /// <remarks>Позволяет устанавливать погрешность расчетов</remarks>
        public static bool? LineToLineParallel(Line3D Line1, Line3D Line2, double ErrorSolve)
        {
            //Функция возвращает значение "TRUE", если две 3D прямые взаимно параллельны
            //Расчет ведется по углу между заданными прямыми и заданной точности 
            //Контроль инцидентности заданных прямых одной плоскости + Контроль корректности задания прямых
            if (TwoLinesOfPlane(Line1, Line2) == false)
            {
                //If MyClass.TwoLinesOfPlane(Line1, Line2, ErrorSolve) = True Then 'Контроль инцидентности заданных прямых одной плоскости + Контроль корректности задания прямых 
                Interaction.MsgBox("Заданные прямые не лежат в одной плоскости.", MsgBoxStyle.Critical, "Контроль параллельности двух 3D прямых на основе расчета угла между ними");
                return null;
            }
            //Dim AngleLine1Line2 As Double
            //AngleLine1Line2 = MyClass.LinesAngle(Line1, Line2)
            if (Math.Abs(LinesCalculator.LinesAngle(Line1, Line2)) - 0 <= ErrorSolve | Math.Abs(LinesCalculator.LinesAngle(Line1, Line2)) - 180 <= ErrorSolve)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Контроль параллельности двух 3D прямых на основе расчета коэффициентов уравнений заданных прямых
        /// </summary>
        /// <param name="Line1">Первая 3D прямая</param>
        /// <param name="Line2">Вторая 3D прямая</param>
        /// <returns>Возвращает значение "TRUE", если две 3D прямые параллельны</returns>
        /// <remarks></remarks>
        public static bool LineToLineParallel(Line3D Line1, Line3D Line2)
        {
            //Функция возвращает значение "TRUE", если две 3D прямые взаимно параллельны
            //Dim m1, m2, n1, n2, p1, p2 As Double
            if (TwoLinesOfPlane(Line1, Line2) == true)
            {
                if (Line2.kx == 0 | Line2.ky == 0 | Line2.kz == 0)
                {
                    if (Line1.kx == 0 | Line1.ky == 0 | Line1.kz == 0)
                    {
                        goto CalcZeroPlane;
                    }
                    else
                    {
                        if (Line2.kx / Line1.kx == Line2.ky / Line1.ky & Line2.kx / Line1.kx == Line2.kz / Line1.kz & Line2.ky / Line1.ky == Line2.kz / Line1.kz)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if (Line1.kx / Line2.kx == Line1.ky / Line2.ky & Line1.kx / Line2.kx == Line1.kz / Line2.kz & Line1.ky / Line2.ky == Line1.kz / Line2.kz)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            CalcZeroPlane:
                if (Line2.kx == 0 & Line2.ky == 0)
                {
                    if (Line1.kx != 0 | Line1.ky != 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else if (Line2.kx == 0 & Line2.kz == 0)
                {
                    if (Line1.kx != 0 | Line1.kz != 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else if (Line2.ky == 0 & Line2.kz == 0)
                {
                    if (Line1.ky != 0 | Line1.kz != 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    goto CalcZeroOsi;
                }
            CalcZeroOsi:
                if (Line2.kx == 0)
                {
                    if (Line1.kx != 0)
                    {
                        return false;
                    }
                    else
                    {
                        if (Line1.ky / Line2.ky == Line1.kz / Line2.kz)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else if (Line2.ky == 0)
                {
                    if (Line1.ky != 0)
                    {
                        return false;
                    }
                    else
                    {
                        if (Line1.kx / Line2.kx == Line1.kz / Line2.kz)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else if (Line2.kz == 0)
                {
                    if (Line1.kz != 0)
                    {
                        return false;
                    }
                    else
                    {
                        if (Line1.kx / Line2.kx == Line1.ky / Line2.ky)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        //==================================================================================
        //==================== Контроль пересечения двух прямых ==============================
        //==================================================================================
        //-------------------- Контроль пересечения двух 2D прямых ---------------------------

        /// <summary>
        /// Контроль пересечения двух 2D прямых 
        /// </summary>
        /// <param name="Line1">Первая 2D прямая</param>
        /// <param name="Line2">Вторая 2D прямая</param>
        /// <returns>Возвращает значение "TRUE", если две 2D прямые пересекаются</returns>
        /// <remarks>!!! Не реализована !!!</remarks>
        public static bool? LineToLineIntersect(Line2D Line1, Line2D Line2)
        {
            //Функция возвращает значение "TRUE", если две 2D прямые пересекаются
            //Dim LineErr As New LineErrors
            //Контроль корректности задания прямых
            if (LinesControl.LineTrue(Line1) == false | LinesControl.LineTrue(Line2) == false)
            {
                Interaction.MsgBox("Ошибка задания прямых линий." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль пересесечения двух 2D прямых");
                return null;
            }
            //Формулу пересечния двух 2D прямых
            //???????????
            return null;
        }

        //-------------------- Контроль пересечения двух 3D прямых ---------------------

        /// <summary>
        /// Контроль пересечения двух 3D прямых 
        /// </summary>
        /// <param name="Line1">Первая 3D прямая</param>
        /// <param name="Line2">Вторая 3D прямая</param>
        /// <returns>Возвращает значение "TRUE", если две 3D прямые пересекаются</returns>
        /// <remarks>!!! В реализации функции необходимо использовать алгоритм для расчета на основе коэффициентов прямых (пока не реализовано) !!!</remarks>
        public static bool LineToLineIntersect(Line3D Line1, Line3D Line2)
        {
            //Функция возвращает значение "TRUE" если две 3D прямые пересекаются
            //+ Контроль корректности задания прямой
            if (TwoLinesOfPlane(Line1, Line2) == true)
            {
                if (LineToLineParallel(Line1, Line2) == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
            //Для расчета с использованием коээфициентов прямых, но надо обработать "деление на ноль"
            //If Line1.kx / Line2.kx <> Line1.ky / Line2.ky And Line1.kx / Line2.kx <> Line1.kz / Line2.kz And Line1.ky / Line2.ky <> Line1.kz / Line2.kz Then
            //    Return True
            //Else
            //    Return False
            //End If
        }

        //======================================================================================================
        //==================== Расчет перпендикулярности двух прямых ===========================================
        //======================================================================================================

        //-------------------- Расчет перпендикулярности двух 2D прямых ---------------------


        //-------------------- Расчет перпендикулярности двух 3D прямых ---------------------

        /// <summary>
        /// Контроль перпендикулярности двух 3D прямых
        /// </summary>
        /// <param name="Line1">Первая 3D прямая</param>
        /// <param name="Line2">вторая 3D прямая</param>
        /// <returns>Возвращает значение "TRUE", если две 3D прямые перпендикулярны друг другу</returns>
        /// <remarks>Расчет производится по коэффициентам уравнений прямых.
        /// Погрешность расчета равна погрешности задания первой прямой</remarks>
        public static bool? LineToLinePerpendiculare(Line3D Line1, Line3D Line2)
        {
            //Функция возвращает значение "TRUE" если две 3D прямые перпендикулярны друг другу
            //Контроль корректности задания прямой
            //Dim LineErr As New LineErrors  'Контроль корректности задания прямой
            double Var = 0;
            if (LinesControl.LineTrue(Line1) == false | LinesControl.LineTrue(Line2) == false)
            {
                Interaction.MsgBox("Ошибка задания прямых линий." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль перпендикулярности 3D прямых");
                return null;
            }
            //Расчет
            Var = Line1.kx * Line2.kx + Line1.ky * Line2.ky + Line1.kz * Line2.kz;
            //Условие перпендикулярности прямых
            if (Math.Abs(Var) < Line1.SolveError)
            {
                //If Var = 0 Then
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Контроль перпендикулярности двух 3D прямых
        /// </summary>
        /// <param name="Line1">Первая 3D прямая</param>
        /// <param name="Line2">вторая 3D прямая</param>
        /// <param name="ErrorSolve">Погрешность расчетов</param>
        /// <returns>Возвращает значение "TRUE", если две 3D прямые перпендикулярны друг другу</returns>
        /// <remarks>Расчет производится по коэффициентам уравнений прямых.
        /// Позволяет задавать погрешность расчетов</remarks>
        public static bool? LineToLinePerpendiculare(Line3D Line1, Line3D Line2, double ErrorSolve)
        {
            //Функция возвращает значение "TRUE" если две 3D прямые перпендикулярны друг другу
            //Контроль корректности задания прямой
            //Dim LineErr As New LineErrors  'Контроль корректности задания прямой
            double Var = 0;
            if (LinesControl.LineTrue(Line1) == false | LinesControl.LineTrue(Line2) == false)
            {
                Interaction.MsgBox("Ошибка задания прямых линий." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль перпендикулярности 3D прямых");
                return null;
            }
            //Расчет
            Var = Line1.kx * Line2.kx + Line1.ky * Line2.ky + Line1.kz * Line2.kz;
            //Условие перпендикулярности прямых
            if (Math.Abs(Var) < ErrorSolve)
            {
                //If Var = 0 Then
                return true;
            }
            else
            {
                return false;
            }
        }

        //======================================================================================================
        //==================== Расчет скрещиваемости двух (только 3D) прямых ===================================
        //======================================================================================================

        /// <summary>
        /// Контроль скрещиваемости двух 3D прямых
        /// </summary>
        /// <param name="Line1">Первая 3D прямая</param>
        /// <param name="Line2">Вторая 3D прямая</param>
        /// <returns>Возвращает значение "TRUE", если две 3D прямые скрещиваются</returns>
        /// <remarks></remarks>
        public static bool LineToLineCrossing(Line3D Line1, Line3D Line2)
        {
            //Функция возвращает значение "TRUE", если две 3D прямые скрещиваются
            if (TwoLinesOfPlane(Line1, Line2) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //===================================================================================================
        //==================== Расчет направления двух прямых ===============================================
        //===================================================================================================

        /// <summary>
        /// Контроль направления двух заданных 3D прямых
        /// </summary>
        /// <param name="Line1">Первая 3D прямая</param>
        /// <param name="Line2">Вторая 3D прямая</param>
        /// <returns>Возвращает значение "TRUE", если направления заданных прямых совпадают</returns>
        /// <remarks></remarks>
        public static bool? DirectionLine1ToLine2(Line3D Line1, Line3D Line2)
        {
            //Функция возвращает значение "TRUE", если направления заданных прямых совпадают
            dynamic PointLine1 = default(Point3D);
            Point3D PointLine2 = new Point3D();
            dynamic NewLine1 = default(Line3D);
            Line3D LineVarNew = new Line3D();
            //Контроль совпадения и корректности задания прямых
            if (LinesIsLines(Line1, Line2) == false)
            {
                Interaction.MsgBox("Ошибка задания прямых линий." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль определения направления двух 3D прямых");
                return null;
            }
            //Перенос базовой точки второй прямой в базовую точку первой прямой
            NewLine1.ParallelPointToLine(Line2, Line1.Point_0);
            //Задание точки на первой прямой (t - положительное)
            PointLine2 = Line1.GetPoint(10);
            //Расчет параметра t2 второй прямой
            double t2 = 0;
            t2 = LineVarNew.GetLine_t(PointLine2, NewLine1);
            //Контроль значения t
            if (t2 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //==================================================================================
        //==================== Расчет взаимоотношений прямых и плоскостей ==================
        //==================================================================================

        //==================================================================================
        //==================== Контроль инцидентности двух прямых одной плоскости ==========
        //==================================================================================

        // ''' <summary>
        // ''' Контроль инцидентности двух заданных 3D прямых одной плоскости
        // ''' </summary>
        // ''' <param name="Line1">Первая </param>
        // ''' <param name="Line2">вторая заданная 3D прямая</param>
        // ''' <returns>Возвращает значение "TRUE", если две 3D прямые лежат в одной плоскости</returns>
        // ''' <remarks>Точность расчета равна точности задания первой заданной прямой</remarks>
        //Public Function TwoLinesOfPlane(ByVal Line1 As Line3D, ByVal Line2 As Line3D) As Boolean
        //    'Функция возвращает значение "TRUE" если две 3D прямые находятся в одной плоскости
        //    'II способ. Проверен.
        //    Dim d, d1, d2, d3 As Double
        //    'Контроль корректности задания прямых
        //    If MyClass.LineFalse(Line1) = True Or MyClass.LineFalse(Line2) = True Then
        //        MsgBox("Ошибка задания прямых линий." & vbCrLf & _
        //               "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль инцидентности двух 3D прямых одной плоскости")
        //        Return Nothing
        //        Exit Function
        //    End If
        //    'Расчет
        //    d1 = (Line2.Point_0.x - Line1.Point_0.x) * (Line1.ky * Line2.kz - Line2.ky * Line1.kz)
        //    d2 = Line1.kx * (Line2.ky * (Line2.Point_0.z - Line1.Point_0.z) - (Line2.Point_0.y - Line1.Point_0.y) * Line2.kz)
        //    d3 = Line2.kx * ((Line2.Point_0.y - Line1.Point_0.y) * Line1.kz - Line1.ky * (Line2.Point_0.z - Line1.Point_0.z))
        //    d = d1 + d2 + d3
        //    If d = 0 Or Math.Abs(d) < 0.001 Then
        //        Return True
        //    Else
        //        Return False
        //    End If
        //End Function

        /// <summary>
        /// Контроль инцидентности двух заданных 3D прямых одной плоскости
        /// </summary>
        /// <param name="Line1">Первая </param>
        /// <param name="Line2">вторая заданная 3D прямая</param>
        /// <returns>Возвращает значение "TRUE", если две 3D прямые лежат в одной плоскости</returns>
        /// <remarks>Точность расчета равна точности задания первой заданной прямой</remarks>
        public static bool? TwoLinesOfPlane(Line3D Line1, Line3D Line2)
        {
            //Функция возвращает значение "TRUE", если две 3D прямые лежат в одной плоскости
            //I способ. Проверен.
            //Dim LineErr As New LineErrors  'Контроль корректности задания прямой
            //Контроль корректности задания прямых
            if (LinesControl.LineTrue(Line1) == false | LinesControl.LineTrue(Line2) == false)
            {
                Interaction.MsgBox("Ошибка задания прямой линии." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль инцидентности двух 3D прямых одной плоскости");
                return null;
            }
            //Расчет
            double LinesDx = 0;
            double LinesDy = 0;
            double LinesDz = 0;
            double Det = 0;
            double[,] DetLines = new double[3, 3];
            MatrixEvalution MrxVar = new MatrixEvalution();
            LinesDx = Line2.Point_0.X - Line1.Point_0.X;
            LinesDy = Line2.Point_0.Y - Line1.Point_0.Y;
            LinesDz = Line2.Point_0.Z - Line1.Point_0.Z;
            DetLines.SetValue(LinesDx, 0, 0);
            DetLines.SetValue(LinesDy, 0, 1);
            DetLines.SetValue(LinesDz, 0, 2);
            DetLines.SetValue(Line1.kx, 1, 0);
            DetLines.SetValue(Line1.ky, 1, 1);
            DetLines.SetValue(Line1.kz, 1, 2);
            DetLines.SetValue(Line2.kx, 2, 0);
            DetLines.SetValue(Line2.ky, 2, 1);
            DetLines.SetValue(Line2.kz, 2, 2);
            Det = MrxVar.detMrx3x3(DetLines);
            //Может возникнуть ошибка, обусловленная точностью расчета
            if (Math.Abs(Det) <= Line1.SolveError)
            {
                //If Det = 0 Then 
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Контроль инцидентности двух заданных 3D прямых одной плоскости
        /// </summary>
        /// <param name="Line1">Первая </param>
        /// <param name="Line2">вторая заданная 3D прямая</param>
        /// <param name="ErrorSolve">Заданная точность расчета</param>
        /// <returns>Возвращает значение "TRUE", если две 3D прямые лежат в одной плоскости</returns>
        /// <remarks>Позволяет задавать точность расчета</remarks>
        public static bool? TwoLinesOfPlane(Line3D Line1, Line3D Line2, double ErrorSolve)
        {
            //Функция возвращает значение "TRUE", если две 3D прямые лежат в одной плоскости
            //I способ. Проверен.
            //Dim LineErr As New LineErrors  'Контроль корректности задания прямой
            //Контроль корректности задания прямых
            if (LinesControl.LineTrue(Line1) == false | LinesControl.LineTrue(Line2) == false)
            {
                Interaction.MsgBox("Ошибка задания прямой линии." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль инцидентности двух 3D прямых одной плоскости");
                return null;
            }
            //Расчет
            double LinesDx = 0;
            double LinesDy = 0;
            double LinesDz = 0;
            double Det = 0;
            double[,] DetLines = new double[3, 3];
            MatrixEvalution MrxVar = new MatrixEvalution();
            LinesDx = Line2.Point_0.X - Line1.Point_0.X;
            LinesDy = Line2.Point_0.Y - Line1.Point_0.Y;
            LinesDz = Line2.Point_0.Z - Line1.Point_0.Z;
            DetLines.SetValue(LinesDx, 0, 0);
            DetLines.SetValue(LinesDy, 0, 1);
            DetLines.SetValue(LinesDz, 0, 2);
            DetLines.SetValue(Line1.kx, 1, 0);
            DetLines.SetValue(Line1.ky, 1, 1);
            DetLines.SetValue(Line1.kz, 1, 2);
            DetLines.SetValue(Line2.kx, 2, 0);
            DetLines.SetValue(Line2.ky, 2, 1);
            DetLines.SetValue(Line2.kz, 2, 2);
            Det = MrxVar.detMrx3x3(DetLines);
            //Может возникнуть ошибка, обусловленная точностью расчета
            if (Math.Abs(Det) <= ErrorSolve)
            {
                //If Det = 0 Then 
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Контроль принадлежности заданной 3D прямой плоскости базовой системы координат
        /// </summary>
        /// <param name="Line">Заданная 3D прямая</param>
        /// <returns>Возвращает значение "TRUE", если 3D прямая лежит в плоскости базовой системы координат</returns>
        /// <remarks>Точность расчета равна точности задания прямой.
        /// !!! Правильность расчета НЕ ПРОВЕРЕНА !!!</remarks>
        public static bool? LineOfFramePlane(Line3D Line)
        {
            //Функция возвращает значение "TRUE", если 3D прямая лежит в плоскости базовой системы координат
            //Dim LineErr As New LineErrors  'Переменная для контроля корректности задания прямой
            //Контроль корректности задания прямой
            if (LinesControl.LineTrue(Line) == false)
            {
                Interaction.MsgBox("Ошибка задания прямой линии." + Constants.vbCrLf + "Проверьте правильность исходных данных.", MsgBoxStyle.Critical, "Контроль инцидентности 3D прямой и базовой плоскости");
                return null;
            }
            //Расчет'????????????????????????
            if (Math.Abs(Line.Point_0.X) < Line.SolveError & Math.Abs(Line.kx) < Line.SolveError | Math.Abs(Line.Point_0.Y) < Line.SolveError & Math.Abs(Line.ky) < Line.SolveError | Math.Abs(Line.Point_0.Z) < Line.SolveError & Math.Abs(Line.kz) < Line.SolveError)
            {
                Interaction.MsgBox("Проверьте верность данного расчета." + Constants.vbCrLf + "?????????? Неправильно! ????????????", MsgBoxStyle.Critical, "Контроль инцидентности 3D прямой и базовой плоскости");
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Контроль инцидентности заданной 3D прямой и заданной плоскости
        /// </summary>
        /// <param name="Line">Заданная 3D прямая</param>
        /// <param name="Plane">Заданная плоскость</param>
        /// <returns>Возвращает "TRUE", если заданная 3D прямая инцидентна заданной плоскости</returns>
        /// <remarks>Точность расчета равна точности задания прямой.
        /// Контроль осуществляется на основе расчета коэффициентов уравнений прямой и плоскости</remarks>
        public static bool? LineOfPlan(Line3D Line, GeometryObjects.PlaneSpace Plane)
        {
            //Функция возвращает "TRUE", если заданная 3D прямая лежит в заданной плоскости
            double s = 0;
            double g = 0;
            //Dim LineVar As New BaseGeometryYVP.GeomObjects.Line3D
            //Dim PlaneVar As New BaseGeometryYVP.GeomObjects.Plans.PlaneSpace
            //Dim LineErr As New LineErrors
            //Контроль корректности задания прямой и плоскости
            if (Plane.PlanFalse(Plane) == true | LinesControl.LineTrue(Line) == false)
            {
                Interaction.MsgBox("Не удается определить положение прямой и плоскости." + Constants.vbCrLf + "Прямая или плоскость заданны не корректно.", MsgBoxStyle.Critical, "Функция определения инцидентности прямой и плоскости");
                return null;
            }
            //Расчет
            s = Plane.A * Line.kx + Plane.B * Line.ky + Plane.C * Line.kz;
            //Прямая либо параллельна либо инцидентна плоскости
            g = Plane.A * Line.Point_0.X + Plane.B * Line.Point_0.Y + Plane.C * Line.Point_0.Z + Plane.D;
            //Точка прямой принадлежит плоскости
            //If s=0 And g= 0 Then
            if (Math.Abs(s) <= Line.SolveError & Math.Abs(g) <= Line.SolveError)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Контроль инцидентности заданной 3D прямой и заданной плоскости
        /// </summary>
        /// <param name="Line">Заданная 3D прямая</param>
        /// <param name="Plane">Заданная плоскость</param>
        /// <returns>Возвращает "TRUE", если заданная 3D прямая инцидентна заданной плоскости</returns>
        /// <remarks>Позволяет задавать точность расчета.
        /// Контроль осуществляется на основе расчета коэффициентов уравнений прямой и плоскости</remarks>
        public static bool? LineOfPlan(Line3D Line, GeometryObjects.PlaneSpace Plane, double SolveError)
        {
            //Функция возвращает "TRUE", если заданная 3D прямая лежит в заданной плоскости
            double s = 0;
            double g = 0;
            //Dim LineVar As New BaseGeometryYVP.GeomObjects.Line3D
            //Dim PlaneVar As New BaseGeometryYVP.GeomObjects.Plans.PlaneSpace
            //Dim LineErr As New LineErrors
            //Контроль корректности задания прямой и плоскости
            if (Plane.PlanFalse(Plane) == true | LinesControl.LineTrue(Line) == false)
            {
                Interaction.MsgBox("Не удается определить положение прямой и плоскости." + Constants.vbCrLf + "Прямая или плоскость заданны не корректно.", MsgBoxStyle.Critical, "Функция определения инцидентности прямой и плоскости");
                return null;
            }
            //Расчет
            s = Plane.A * Line.kx + Plane.B * Line.ky + Plane.C * Line.kz;
            //Прямая либо параллельна, либо инцидентна плоскости
            g = Plane.A * Line.Point_0.X + Plane.B * Line.Point_0.Y + Plane.C * Line.Point_0.Z + Plane.D;
            //Точка прямой принадлежит плоскости
            //If s=0 And g= 0 Then
            if (Math.Abs(s) <= SolveError & Math.Abs(g) <= SolveError)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //==================================================================================
        //==================== Контроль перпендикулярности прямой и одной плоскости ========
        //==================================================================================

        /// <summary>
        /// Контроль перпендикулярности заданной 3D прямой и заданной плоскости
        /// </summary>
        /// <param name="Line">Заданная 3D прямая</param>
        /// <param name="Plane">Заданная плоскость</param>
        /// <returns>Возвращает "TRUE", если заданная 3D прямая перпендикулярна заданной плоскости</returns>
        /// <remarks>Точность расчета равна точности задания прямой.
        /// Контроль осуществляется на основе расчета коэффициентов уравнений прямой и плоскости</remarks>
        public static bool? LineToPlanePerpendiculare(Line3D Line, GeometryObjects.PlaneSpace Plane)
        {
            //Функция возвращает "TRUE", если заданная 3D прямая перпендикулярна заданной плоскости
            //Dim LineVar As New BaseGeometryYVP.GeomObjects.Line3D
            //Dim PlaneVar As New BaseGeometryYVP.GeomObjects.Plans.PlaneSpace
            //Dim LineErr As New LineErrors
            if (Plane.PlanFalse(Plane) == true | LinesControl.LineTrue(Line) == false)
            {
                Interaction.MsgBox("Прямая или плоскость или оба элемента заданы не корректно." + Constants.vbCrLf + "Правильно задайте прямую и плоскость.", MsgBoxStyle.Critical, "Контроль перпендикулярности 3D прямой с плоскостью");
                return null;
            }
            //If Plane.A * Line.ky = Plane.B * Line.kx And _
            //   Plane.A * Line.kz = Plane.C * Line.kx And _
            //   Plane.B * Line.kz = Plane.C * Line.ky Then
            //    Return True
            if (Math.Abs(Plane.A * Line.ky - Plane.B * Line.kx) >= Line.SolveError & Math.Abs(Plane.A * Line.kz - Plane.C * Line.kx) >= Line.SolveError & Math.Abs(Plane.B * Line.kz - Plane.C * Line.ky) >= Line.SolveError)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Контроль инцидентности заданной 3D прямой и заданной плоскости
        /// </summary>
        /// <param name="Line">Заданная 3D прямая</param>
        /// <param name="Plane">Заданная плоскость</param>
        /// <returns>Возвращает "TRUE", если заданная 3D прямая инцидентна заданной плоскости</returns>
        /// <remarks>Позволяет задавать точность расчета.
        /// Контроль осуществляется на основе расчета коэффициентов уравнений прямой и плоскости</remarks>
        public static bool? LineToPlanePerpendiculare(Line3D Line, GeometryObjects.PlaneSpace Plane, double SolveError)
        {
            //Функция возвращает "TRUE", если заданная 3D прямая перпендикулярна заданной плоскости
            //Dim LineVar As New BaseGeometryYVP.GeomObjects.Line3D
            //Dim PlaneVar As New BaseGeometryYVP.GeomObjects.Plans.PlaneSpace
            //Dim LineErr As New LineErrors
            if (Plane.PlanFalse(Plane) == true | LinesControl.LineTrue(Line) == false)
            {
                Interaction.MsgBox("Прямая или плоскость или оба элемента заданы не корректно." + Constants.vbCrLf + "Правильно задайте прямую и плоскость.", MsgBoxStyle.Critical, "Контроль перпендикулярности 3D прямой с плоскостью");
                return null;
            }
            //If Plane.A * Line.ky = Plane.B * Line.kx And _
            //   Plane.A * Line.kz = Plane.C * Line.kx And _
            //   Plane.B * Line.kz = Plane.C * Line.ky Then
            //    Return True
            if (Math.Abs(Plane.A * Line.ky - Plane.B * Line.kx) >= SolveError & Math.Abs(Plane.A * Line.kz - Plane.C * Line.kx) >= SolveError & Math.Abs(Plane.B * Line.kz - Plane.C * Line.ky) >= SolveError)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
