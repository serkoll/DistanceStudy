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

    /// <summary>Класс для контроля корректности задания и расчета параметров 2D и 3D прямых</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2014</remarks>
    public static class LinesControl
    {

        public static Enum Line_Error;
        /// <summary>
        /// Функция контроля корректности задания 2D прямой
        /// </summary>
        /// <param name="Line_kx">Первый коэффициент канонического уравнения прямой</param>
        /// <param name="Line_ky">Второй коэффициент канонического уравнения прямой</param>
        /// <returns>Возвращает "TRUE", если заданная 2D прямая задана корректно</returns>
        /// <remarks></remarks>
        public static bool LineTrue(double Line_kx, double Line_ky)
        {
            var errObj = new ErrObject();
            //Функция возвращает "TRUE" если заданная 2D прямая задана корректно
            //Dim BasePointAny As New BaseGeometryYVP.GeomObjects.Points.Point2D
            if (Line_kx == 0 & Line_ky == 0)
            {
                //Or MyClass.PointOfLine(Line.Point_0, Line) = False???????????????
                //Контроль корректности задания прямой + Контроль принадлежности заданной базовой точки заданной прямой
                //BasePointAny = Line.GetPoint(0.7) 'Определение некоторой точки на прямой. Точка будет взята в качестве базовой для данной прямой
                //If (Point.X - Line.Point_0.x) * Line.ky = (Point.Y - Line.Point_0.y) * Line.kx Then
                //    Return True
                //Else
                //    Return False
                //End If
                Line_Error = LineError.KxKyKz_Zero;
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Функция контроля корректности задания 2D прямой
        /// </summary>
        /// <param name="Line_kx">Первый коэффициент канонического уравнения прямой</param>
        /// <param name="Line_ky">Второй коэффициент канонического уравнения прямой</param>
        /// <returns>Возвращает "TRUE", если заданная 2D прямая задана корректно</returns>
        /// <remarks></remarks>
        public static bool LineTrue(double Line_kx, double Line_ky, double Line_kz)
        {
            //Функция возвращает "TRUE" если заданная 2D прямая задана корректно
            //Dim BasePointAny As New BaseGeometryYVP.GeomObjects.Points.Point2D
            if (LineTrue(Line_kx, Line_ky) == false & Line_kz == 0)
            {
                //Or MyClass.PointOfLine(Line.Point_0, Line) = False???????????????
                //Контроль корректности задания прямой + Контроль принадлежности заданной базовой точки заданной прямой
                //BasePointAny = Line.GetPoint(0.7) 'Определение некоторой точки на прямой. Точка будет взята в качестве базовой для данной прямой
                //If (Point.X - Line.Point_0.x) * Line.ky = (Point.Y - Line.Point_0.y) * Line.kx Then
                //    Return True
                //Else
                //    Return False
                //End If
                Line_Error = LineError.KxKyKz_Zero;
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Функция контроля корректности задания 2D прямой
        /// </summary>
        /// <param name="Line">Заданная прямая</param>
        /// <returns>Возвращает "TRUE", если заданная 2D прямая задана корректно</returns>
        /// <remarks></remarks>
        public static bool LineTrue(Line2D Line)
        {
            //Функция возвращает "TRUE" если заданная 2D прямая задана корректно
            //Dim BasePointAny As New BaseGeometryYVP.GeomObjects.Points.Point2D
            if (LineTrue(Line.kx, Line.ky) == false)
            {
                //Or MyClass.PointOfLine(Line.Point_0, Line) = False???????????????
                //Контроль корректности задания прямой + Контроль принадлежности заданной базовой точки заданной прямой
                //BasePointAny = Line.GetPoint(0.7) 'Определение некоторой точки на прямой. Точка будет взята в качестве базовой для данной прямой
                //If (Point.X - Line.Point_0.x) * Line.ky = (Point.Y - Line.Point_0.y) * Line.kx Then
                //    Return True
                //Else
                //    Return False
                //End If
                Line_Error = LineError.KxKyKz_Zero;
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Функция контроля корректности задания 3D прямой
        /// </summary>
        /// <param name="Line">Заданная прямая</param>
        /// <returns>Возвращает "TRUE", если заданная 3D прямая задана корректно</returns>
        /// <remarks></remarks>
        public static bool LineTrue(Line3D Line)
        {
            //Функция возвращает "TRUE", если заданная 3D прямая задана корректно
            if (LineTrue(Line.kx, Line.ky, Line.kz) == false)
            {
                //Or MyClass.PointOfLine(Line.Point_0, Line) = False?????????????
                //Контроль принадлежности заданной базовой точки заданной прямой
                //BasePointAny = Line.GetPoint(0.7) 'Определение некоторой точки на прямой. Точка будет взята в качестве базовой для данной прямой
                //If (Point.X - Line.Point_0.x) * Line.ky = (Point.Y - Line.Point_0.y) * Line.kx Then
                //    Return True
                //Else
                //    Return False
                //End If
                Line_Error = LineError.KxKyKz_Zero;
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
