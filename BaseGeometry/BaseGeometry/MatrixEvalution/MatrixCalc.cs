using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace GeomObjects
{
    /// <summary>
    ///  Класс для вычислений с матрицами и действий с элементами матриц
    /// </summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2014</remarks>
    public class MatrixEvalution
    {

        public MatrixEvalution()
        {
        }

        /// <summary>
        ///  Возвращает матрицу, полученную в результате сложения двух заданных матриц
        /// </summary>
        /// <param name="Mrx1">Первая заданная матрица</param>
        /// <param name="Mrx2">Вторая заданная матрица</param>
        /// <returns>Возвращает двумерную матрицу As Double</returns>
        /// <remarks></remarks>
        public double[,] MrxSum(double[,] Mrx1, double[,] Mrx2)
        {
            //Сложение матриц
            byte i = 0;
            byte j = 0;
            double[,] R = new double[Information.UBound(Mrx1, 1) + 1, Information.UBound(Mrx1, 2) + 1];
            for (i = 0; i <= Information.UBound(Mrx1, 1); i++)
            {
                for (j = 0; j <= Information.UBound(Mrx1, 2); j++)
                {
                    R[i, j] = Mrx1[i, j] + Mrx2[i, j];
                }
            }
            return R;
        }

        /// <summary>
        ///  Возвращает матрицу, полученную в результате вычитания двух заданных матриц
        /// </summary>
        /// <param name="Mrx1">Первая заданная матрица</param>
        /// <param name="Mrx2">Вторая заданная матрица</param>
        /// <returns>Возвращает двумерную матрицу As Double</returns>
        /// <remarks></remarks>
        public double[,] MrxDiff(double[,] Mrx1, double[,] Mrx2)
        {
            //Вычитание матриц
            byte i = 0;
            byte j = 0;
            double[,] R = new double[Information.UBound(Mrx1, 1) + 1, Information.UBound(Mrx1, 2) + 1];
            for (i = 0; i <= Information.UBound(Mrx1, 1); i++)
            {
                for (j = 0; j <= Information.UBound(Mrx1, 2); j++)
                {
                    R[i, j] = Mrx1[i, j] - Mrx2[i, j];
                }
            }
            return R;
        }

        /// <summary>
        /// Возвращает матрицу, полученную в результате перемножения двух заданных матриц
        /// </summary>
        /// <param name="Mrx1">Первая заданная матрица</param>
        /// <param name="Mrx2">Вторая заданная матрица</param>
        /// <returns>Возвращает двумерную матрицу As Double</returns>
        /// <remarks></remarks>
        public double[,] MrxMult(double[,] Mrx1, double[,] Mrx2)
        {
            //Умножение матриц
            byte i = 0;
            byte j = 0;
            byte k = 0;
            double[,] R = new double[Information.UBound(Mrx1, 1) + 1, Information.UBound(Mrx1, 2) + 1];
            for (k = 0; k <= Information.UBound(Mrx2, 2); k++)
            {
                for (i = 0; i <= Information.UBound(Mrx1, 1); i++)
                {
                    R[i, k] = 0;
                    for (j = 0; j <= Information.UBound(Mrx1, 2); j++)
                    {
                        R[i, k] = R[i, k] + Mrx1[i, j] * Mrx2[j, k];
                    }
                }
            }
            return R;
        }

        /// <summary>
        /// Возвращает матрицу, умноженную на заданное число
        /// </summary>
        /// <param name="Mrx1">Заданная матрица</param>
        /// <param name="K">Заданное число</param>
        /// <returns>Возвращает двумерную матрицу As Double</returns>
        /// <remarks></remarks>
        public double[,] MrxMultK(double[,] Mrx1, double K)
        {
            //Умножение матриц на число
            byte i = 0;
            byte j = 0;
            double[,] R = new double[Information.UBound(Mrx1, 1) + 1, Information.UBound(Mrx1, 2) + 1];
            for (i = 0; i <= Information.UBound(Mrx1, 1); i++)
            {
                for (j = 0; j <= Information.UBound(Mrx1, 2); j++)
                {
                    R[i, j] = Mrx1[i, j] * K;
                }
            }
            return R;
        }

        /// <summary>
        /// Возвращаяет значение определеителя матрицы 3x3
        /// </summary>
        /// <param name="Mrx">Заданная матрица</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public double detMrx3x3(double[,] Mrx)
        {
            //Вычисление определителя матрицы 3x3
            //Функция возвращаяет значение определеителя матрицы 3x3
            double i = 0;
            double j = 0;
            double k = 0;
            double DetMrx = 0;
            //Dim c1, c2, c3 As Double'Переменные для контроля
            if (Mrx.GetUpperBound(0) != 2 | Mrx.GetUpperBound(1) != 2)
            {
                Interaction.MsgBox("Размер задаваемого массива (матрицы) должен быть 2x2" + Constants.vbCrLf + "т.к. отсчет размера начинается с нулевых индексов строки и столбца", MsgBoxStyle.Exclamation, "Функция вычисления определителя матрицы 3x3");
                goto CalcEnd;
            }
            else
            {
                i = (double)Mrx.GetValue(1, 1) * (double)Mrx.GetValue(2, 2) - (double)Mrx.GetValue(1, 2) * (double)Mrx.GetValue(2, 1);
                j = (double)Mrx.GetValue(1, 2) * (double)Mrx.GetValue(2, 0) - (double)Mrx.GetValue(1, 0) * (double)Mrx.GetValue(2, 2);
                k = (double)Mrx.GetValue(1, 0) * (double)Mrx.GetValue(2, 1) - (double)Mrx.GetValue(1, 1) * (double)Mrx.GetValue(2, 0);
                DetMrx = (double)Mrx.GetValue(0, 0) * i + (double)Mrx.GetValue(0, 1) * j + (double)Mrx.GetValue(0, 2) * k;
                //c1 = Mrx.GetValue(1, 1) * Mrx.GetValue(2, 2) - Mrx.GetValue(1, 2) * Mrx.GetValue(2, 1)
                //c1 = Mrx.GetValue(2, 0)
                return DetMrx;
            }
        CalcEnd: return 0;
        }

        /// <summary>
        /// Возвращаяет значение определеителя матрицы 2x2
        /// </summary>
        /// <param name="Mrx">Заданная матрица</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public double detMrx2x2(double[,] Mrx)
        {
            //Вычисление определителя матрицы 2x2
            //Функция возвращаяет значение определеителя матрицы 2x2
            double DetMrx = 0;
            if (Mrx.GetUpperBound(0) != 1 | Mrx.GetUpperBound(1) != 1)
            {
                Interaction.MsgBox("Размер заданного массива (матрицы) должен быть 1x1" + Constants.vbCrLf + "т.к. отсчет размера начинается с нулевых индексов строки и столбца", MsgBoxStyle.Exclamation, "Функция вычисления определеителя матрицы 2x2");
                DetMrx = -1;
                return DetMrx;
            }
            else
            {
                DetMrx = (double)Mrx.GetValue(0, 0) * (double)Mrx.GetValue(1, 1) - (double)Mrx.GetValue(0, 1) * (double)Mrx.GetValue(1, 0);
                return DetMrx;
            }
        }

        /// <summary>
        /// Возвращает значение ранга матрицы 3x3
        /// </summary>
        /// <param name="Mrx">Заданная матрица</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public double RangMrx3x3(double[,] Mrx)
        {
            //Вычисление ранга матрицы 3x3
            //Функция возвращает значение ранга матрицы 3x3
            double RangMrx = 0;
            //Значение ранга матрицы
            double DetMrx = 0;
            //Значение определителя третьей степени
            double[,] Mrx2x2 = new double[2, 2];
            //Матрица для вычисления определителей второй степени
            double Det2 = 0;
            //Значение определителей второй степени
            int i = 0;
            int j = 0;
            //Переменные цикла
            bool Var = true;
            //Переменные для расчета нулевого ранга

            if (Mrx.GetUpperBound(0) != 2 | Mrx.GetUpperBound(1) != 2)
            {
                Interaction.MsgBox("Размер заданного массива (матрицы) должен быть 2x2," + Constants.vbCrLf + "т.к. отсчет размера начинается с нулевых индексов строки и столбца", MsgBoxStyle.Exclamation, "Функция вычисления ранга матрицы 3x3");
                RangMrx = -1;
                goto CalcEnd;
            }
            else
            {
                goto Calc;
            }
        Calc:
            //Определение нулевого ранга
            i = 0;
            j = 0;
            while (i <= Mrx.GetUpperBound(0))
            {
                while (j <= Mrx.GetUpperBound(1))
                {
                    if ((double)Mrx.GetValue(i, j) != 0)
                    {
                        Var = false;
                        goto Calc3Rang;
                    }
                    j += 1;
                }
                i += 1;
            }
            if (Var == true)
            {
                RangMrx = 0;
                goto CalcEnd;
            }
        Calc3Rang:
            //Определение третьего ранга
            DetMrx = this.detMrx3x3(Mrx);
            if (DetMrx != 0)
            {
                RangMrx = 3;
                goto CalcEnd;
            }
            else
            {
                goto Calc1_2Rang;
            }
        Calc1_2Rang:
            //Определение первого и второго рангов
            Mrx2x2.SetValue(Mrx.GetValue(0, 0), 0, 0);
            Mrx2x2.SetValue(Mrx.GetValue(0, 1), 0, 1);
            Mrx2x2.SetValue(Mrx.GetValue(1, 0), 1, 0);
            Mrx2x2.SetValue(Mrx.GetValue(1, 1), 1, 1);
            Det2 = this.detMrx2x2(Mrx2x2);
            if (Det2 != 0)
            {
                RangMrx = 2;
                goto CalcEnd;
            }
            else
            {
                Mrx2x2.SetValue(Mrx.GetValue(1, 0), 0, 0);
                Mrx2x2.SetValue(Mrx.GetValue(1, 1), 0, 1);
                Mrx2x2.SetValue(Mrx.GetValue(2, 0), 1, 0);
                Mrx2x2.SetValue(Mrx.GetValue(2, 1), 1, 1);
                Det2 = this.detMrx2x2(Mrx2x2);
                if (Det2 != 0)
                {
                    RangMrx = 2;
                    goto CalcEnd;
                }
                else
                {
                    Mrx2x2.SetValue(Mrx.GetValue(0, 0), 0, 0);
                    Mrx2x2.SetValue(Mrx.GetValue(0, 1), 0, 1);
                    Mrx2x2.SetValue(Mrx.GetValue(2, 0), 1, 0);
                    Mrx2x2.SetValue(Mrx.GetValue(2, 1), 1, 1);
                    Det2 = this.detMrx2x2(Mrx2x2);
                    if (Det2 != 0)
                    {
                        RangMrx = 2;
                        goto CalcEnd;
                    }
                    else
                    {
                        RangMrx = 1;
                        goto CalcEnd;
                    }
                }
            }
        CalcEnd:
            return RangMrx;
        }

        /// <summary>
        /// Возвращает значение ранга матрицы 2x1
        /// </summary>
        /// <param name="Mrx">Заданная матрица</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public double RangMrx2x2(double[,] Mrx)
        {
            //Вычисление ранга матрицы 2x2
            //Функция возвращает значение ранга матрицы 2x1
            double RangMrx = 0;
            //Значение ранга матрицы
            double DetMrx = 0;
            //Значение определителя второй степени
            double[,] Mrx1x1 = new double[2, 2];
            //Матрица для вычисления определителей второй степени
            int i = 0;
            int j = 0;
            //Переменные цикла
            bool Var = true;
            //Переменные для расчета нулевого ранга

            if (Mrx.GetUpperBound(0) != 1 | Mrx.GetUpperBound(1) != 1)
            {
                Interaction.MsgBox("Размер задаваемого массива (матрицы) должен быть 1x1" + Constants.vbCrLf + "т.к. отсчет размера начинается с нулевых индексов строки и столбца", MsgBoxStyle.Exclamation, "Функция вычисления ранга матрицы 2x2");
                goto CalcEnd;
            }
            else
            {
                goto Calc;
            }
        Calc:
            //Определение нулевого ранга
            i = 0;
            j = 0;
            while (i <= Mrx.GetUpperBound(0))
            {
                while (j <= Mrx.GetUpperBound(1))
                {
                    if ((double)Mrx.GetValue(i, j) != 0)
                    {
                        Var = false;
                        goto Calc2Rang;                    }
                    j += 1;
                }
                i += 1;
            }
            if (Var == true)
            {
                RangMrx = 0;
                goto CalcEnd;
            }
        Calc2Rang:
            //Определение второго ранга
            DetMrx = this.detMrx2x2(Mrx);
            if (DetMrx != 0)
            {
                RangMrx = 2;
                goto CalcEnd;
            }
            else
            {
                RangMrx = 1;
                goto CalcEnd;
            }
        CalcEnd: return RangMrx;
        }

        /// <summary>
        /// Возвращает значение ранга матрицы 3x4
        /// </summary>
        /// <param name="Mrx">Заданная матрица</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public double RangMrx3x4(double[,] Mrx)
        {
            //Вычисление ранга матрицы 3x4
            //Функция возвращает значение ранга матрицы 3x4
            double RangMrx = 0;
            //Значение ранга матрицы
            double DetMrx = 0;
            //Значение определителя третьей степени
            double[,] Mrx2x2 = new double[2, 2];
            //Матрица для вычисления определителей второй степени
            double[,] Mrx3x3 = new double[3, 3];
            //Матрица для вычисления определителей третьей степени
            double Det2 = 0;
            //Значение определителей второй степени
            int i = 0;
            int j = 0;
            //Переменные цикла
            bool Var = true;
            //Переменные для расчета нулевого ранга

            if (Mrx.GetUpperBound(0) != 2 | Mrx.GetUpperBound(1) != 3)
            {
                Interaction.MsgBox("Размер задаваемого массива (матрицы) должен быть 2x3" + Constants.vbCrLf + "т.к. отсчет размера начинается с нулевых индексов строки и столбца", MsgBoxStyle.Exclamation, "Функция вычисления ранга матрицы 3x4");
                goto CalcEnd;
            }
            else
            {
                goto Calc;
            }
        Calc:
            //Определение нулевого ранга
            i = 0;
            j = 0;
            while (i <= Mrx.GetUpperBound(0))
            {
                while (j <= Mrx.GetUpperBound(1))
                {
                    if ((double)Mrx.GetValue(i, j) != 0)
                    {
                        Var = false;
                        goto Calc4Rang;
                    }
                    j += 1;
                }
                i += 1;
            }
            if (Var == true)
            {
                RangMrx = 0;
                goto CalcEnd;
            }
        Calc4Rang:
            //Определение четвертого ранга
            DetMrx = this.detMrx3x3(Mrx);
            if (DetMrx != 0)
            {
                RangMrx = 3;
                goto CalcEnd;
            }
            else
            {
                goto Calc3Rang;
            }

            //Определение первого и второго рангов
            Mrx3x3.SetValue(Mrx.GetValue(0, 0), 0, 0);
            Mrx3x3.SetValue(Mrx.GetValue(0, 1), 0, 1);
            Mrx3x3.SetValue(Mrx.GetValue(1, 0), 1, 0);
            Mrx3x3.SetValue(Mrx.GetValue(1, 1), 1, 1);
            DetMrx = this.detMrx3x3(Mrx2x2);
            if (DetMrx != 0)
            {
                RangMrx = 2;
                goto CalcEnd;
            }
            else
            {
                Mrx2x2.SetValue(Mrx.GetValue(1, 0), 0, 0);
                Mrx2x2.SetValue(Mrx.GetValue(1, 1), 0, 1);
                Mrx2x2.SetValue(Mrx.GetValue(2, 0), 1, 0);
                Mrx2x2.SetValue(Mrx.GetValue(2, 1), 1, 1);
                DetMrx = this.detMrx3x3(Mrx2x2);
                if (DetMrx != 0)
                {
                    RangMrx = 2;
                    goto CalcEnd;
                }
                else
                {
                    Mrx2x2.SetValue(Mrx.GetValue(0, 0), 0, 0);
                    Mrx2x2.SetValue(Mrx.GetValue(0, 1), 0, 1);
                    Mrx2x2.SetValue(Mrx.GetValue(2, 0), 1, 0);
                    Mrx2x2.SetValue(Mrx.GetValue(2, 1), 1, 1);
                    DetMrx = this.detMrx3x3(Mrx2x2);
                    if (DetMrx != 0)
                    {
                        RangMrx = 2;
                        goto CalcEnd;
                    }
                    else
                    {
                        RangMrx = 1;
                        goto CalcEnd;
                    }
                }
            }
        Calc3Rang:
        Calc1_2Rang:
            //Определение первого и второго рангов
            Mrx2x2.SetValue(Mrx.GetValue(0, 0), 0, 0);
            Mrx2x2.SetValue(Mrx.GetValue(0, 1), 0, 1);
            Mrx2x2.SetValue(Mrx.GetValue(1, 0), 1, 0);
            Mrx2x2.SetValue(Mrx.GetValue(1, 1), 1, 1);
            Det2 = this.detMrx2x2(Mrx2x2);
            if (Det2 != 0)
            {
                RangMrx = 2;
                goto CalcEnd;
            }
            else
            {
                Mrx2x2.SetValue(Mrx.GetValue(1, 0), 0, 0);
                Mrx2x2.SetValue(Mrx.GetValue(1, 1), 0, 1);
                Mrx2x2.SetValue(Mrx.GetValue(2, 0), 1, 0);
                Mrx2x2.SetValue(Mrx.GetValue(2, 1), 1, 1);
                Det2 = this.detMrx2x2(Mrx2x2);
                if (Det2 != 0)
                {
                    RangMrx = 2;
                    goto CalcEnd;
                }
                else
                {
                    Mrx2x2.SetValue(Mrx.GetValue(0, 0), 0, 0);
                    Mrx2x2.SetValue(Mrx.GetValue(0, 1), 0, 1);
                    Mrx2x2.SetValue(Mrx.GetValue(2, 0), 1, 0);
                    Mrx2x2.SetValue(Mrx.GetValue(2, 1), 1, 1);
                    Det2 = this.detMrx2x2(Mrx2x2);
                    if (Det2 != 0)
                    {
                        RangMrx = 2;
                        goto CalcEnd;
                    }
                    else
                    {
                        RangMrx = 1;
                        goto CalcEnd;
                    }
                }
            }
        CalcEnd:
            return RangMrx;
        }

        /// <summary>
        /// Возвращает значение ранга матрицы MxN
        /// </summary>
        /// <param name="Mrxix">Заданная матрица</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public double RangMrxMxN(double[,] Mrxix)
        {
            //Вычисление ранга матрицы mxn
            //Функция возвращает значение ранга матрицы MxN
            //Проверено ошибок не обнаружено
            double RangMrx = 0;
            //Значение ранга матрицы
            double[,] MrxTrans = null;
            double[,] MrxTransInt = null;
            double MultK1 = 0;
            double MultK2 = 0;
            double ak = 0;
            bool Var = true;
            //Переменная для расчета нулевого ранга
            bool VarInt = false;
            //Переменная для определения целочиленных элементов матрицы
            bool VarCh = false;
            //Переменная для определения целочиленных частных
            int i = 0;
            int j = 0;
            int i2 = 0;
            int j2 = 0;
            int i3 = 0;
            int ich = 0;
            int jch = 0;
            int ich1 = 0;
            //Переменные циклов
            int i_0 = 0;
            //Переменная цикла для определения нуля в начале i-й строки
            int j_0 = 0;
            //Переменная цикла для определения нуля в начале i-й строки

            int MrxUpperBound0 = 0;
            int MrxUpperBound1 = 0;
            MrxTrans = new double[Mrxix.GetUpperBound(0) + 1, Mrxix.GetUpperBound(1) + 1];
            MrxTransInt = new double[MrxTrans.GetUpperBound(0) + 1, MrxTrans.GetUpperBound(1) + 1];
            MrxTrans = (double[,])Mrxix.Clone();
            MrxTransInt = (double[,])MrxTrans.Clone();
        CalcZeroRang:
            //Определение нулевого ранга
            if (this.MrxZero(Mrxix) == true)
            {
                RangMrx = 0;
                goto CalcEnd;
            }
        CalcMrxInteger:
            //Контроль существования целочисленных элементов в матрице
            //Dim a As Double
            //Dim b As Double
            i = 0;
            j = 0;
            while (i <= MrxTrans.GetUpperBound(0))
            {
                while (j <= MrxTrans.GetUpperBound(1))
                {
                    //a = MrxTrans.GetValue(i, j)
                    //b = Math.Round(MrxTrans.GetValue(i, j))
                    // If MrxTrans(i, j) = CInt(MrxTrans(i, j)) Then
                    if ((double)MrxTrans.GetValue(i, j) == Math.Round((double)MrxTrans.GetValue(i, j)))
                    {
                        //Round (arg)'Возвращает ближайшее целое к числу "arg"
                        VarInt = true;
                    }
                    else
                    {
                        VarInt = false;
                        //GoTo CalcZero_ij
                        break; // TODO: might not be correct. Was : Exit Do
                    }
                    j += 1;
                }
                i += 1;
            }
        CalcMoveZeroCollsRows:
            //Перестановка нулевых строк и столбцов
            MrxTransInt = (double[,])this.MrxMoveCollsZero(MrxTrans);
            MrxTrans = (double[,])MrxTransInt.Clone();
            MrxTransInt = (double[,])this.MrxMoveRowsZero(MrxTrans);
            MrxTrans = (double[,])MrxTransInt.Clone();
        CalcZero_ij:
            //1-я проверка значения (нулевого) первого элемента i-й строки матрицы (до вычислений)
            //i_0 = 0 : j_0 = 0
            if ((double)MrxTrans.GetValue(i_0, j_0) != 0)
            {
                goto RangStep1;
            }
            else
            {
                MrxTransInt = (double[,])this.MrxMoveUnit(MrxTrans, i_0, j_0);
                MrxTrans = (double[,])MrxTransInt.Clone();
            }
        RangStep1:
            //Задание исходных границ циклов по строкам
            i2 = i_0 + 1;
            //Граница по строкам
            i = i2;
            while (i <= MrxTrans.GetUpperBound(0))
            {
                if (this.MrxRowZero(MrxTrans, i) == true | i == MrxTrans.GetUpperBound(0))
                {
                    MrxUpperBound0 = i;
                    break; // TODO: might not be correct. Was : Exit Do
                }
                i += 1;
            }
            //Граница по столбцам
            j = j_0;
            while (j <= MrxTrans.GetUpperBound(1))
            {
                if (this.MrxCollZero(MrxTrans, j) == true | j == MrxTrans.GetUpperBound(1))
                {
                    MrxUpperBound1 = j;
                    break; // TODO: might not be correct. Was : Exit Do
                }
                j += 1;
            }
        CalcInteger_ij:
            //Проверка значения первого элемента i-й строки матрицы чтобы получалось целочисленное частное
            if ((double)MrxTrans.GetValue(i_0, j_0) == 0)
            {
                goto CalcZero_ij;
            }
            else
            {
                ak = (double)MrxTrans.GetValue(i_0, j_0);
                if ((double)MrxTrans.GetValue(i_0 + 1, j_0) / (double)MrxTrans.GetValue(i_0, j_0) == Math.Round((double)MrxTrans.GetValue(i_0 + 1, j_0) / (double)MrxTrans.GetValue(i_0, j_0)))
                {
                    goto RangStep2;
                }
            }
            //Перестановка строк и столбцов для целочисленного частного
            jch = j_0;
            //Перебор столбцов 
            while (jch <= MrxUpperBound1)
            {
                //Перебор строк 
                ich = i_0;
                while (ich <= MrxUpperBound0)
                {
                    ich1 = ich + 1;
                    while (ich1 <= MrxUpperBound0)
                    {
                        if ((double)MrxTrans.GetValue(ich, jch) == 0)
                        {
                            if ((double)MrxTrans.GetValue(ich, jch) / (double)MrxTrans.GetValue(ich1, jch) == Math.Round((double)MrxTrans.GetValue(ich, jch) / (double)MrxTrans.GetValue(ich1, jch)))
                            {
                                //If MrxTrans.GetValue(ich1, jch) = 0 Then
                                //    GoTo StepIch
                                //End If
                                MrxTransInt = (double[,])this.MrxReplaceRows(MrxTrans, i_0, ich1);
                                //Перестановка строк 
                                MrxTransInt = (double[,])this.MrxReplaceRows(MrxTrans, i_0 + 1, ich);
                                //Перестановка строк 
                                MrxTransInt = (double[,])this.MrxReplaceColls(MrxTransInt, j_0, jch);
                                //Перестановка столбцов 
                                MrxTrans = (double[,])MrxTransInt.Clone();
                                goto RangStep2;
                            }
                        }
                        else
                        {
                            if ((double)MrxTrans.GetValue(ich1, jch) / (double)MrxTrans.GetValue(ich, jch) == Math.Round((double)MrxTrans.GetValue(ich1, jch) / (double)MrxTrans.GetValue(ich, jch)))
                            {
                                MrxTransInt = (double[,])this.MrxReplaceRows(MrxTrans, i_0, ich);
                                //Перестановка строк 
                                MrxTransInt = (double[,])this.MrxReplaceRows(MrxTrans, i_0 + 1, ich1);
                                //Перестановка строк 
                                MrxTransInt = (double[,])this.MrxReplaceColls(MrxTransInt, j_0, jch);
                                //Перестановка столбцов 
                                MrxTrans = (double[,])MrxTransInt.Clone();
                                goto RangStep2;
                            }
                            else
                            {
                                if ((double)MrxTrans.GetValue(ich, jch) / (double)MrxTrans.GetValue(ich1, jch) == Math.Round((double)MrxTrans.GetValue(ich, jch) / (double)MrxTrans.GetValue(ich1, jch)))
                                {
                                    //If MrxTrans.GetValue(ich1, jch) = 0 Then
                                    //    GoTo StepIch
                                    //End If
                                    MrxTransInt = (double[,])this.MrxReplaceRows(MrxTrans, i_0, ich1);
                                    //Перестановка строк 
                                    MrxTransInt = (double[,])this.MrxReplaceRows(MrxTrans, i_0 + 1, ich);
                                    //Перестановка строк 
                                    MrxTransInt = (double[,])this.MrxReplaceColls(MrxTransInt, j_0, jch);
                                    //Перестановка столбцов 
                                    MrxTrans = (double[,])MrxTransInt.Clone();
                                    goto RangStep2;
                                }
                            }
                        }
                    StepIch1:
                        ich1 += 1;
                    }
                StepIch:
                    ich += 1;
                }
            StepJch:
                jch += 1;
            }
        RangStep2:
            //Ко второй строке прибавляем первую, умноженную на число (-a21/a11)
            //Процесс продолжаем до тех пор, пока не получим нуль на первом месте в последней строке
            //Расчет числа (-a21/a11)
            while (i2 <= MrxUpperBound0)
            {
                MultK1 = -(double)MrxTrans.GetValue(i2, j_0) / (double)MrxTrans.GetValue(i_0, j_0);
                j2 = j_0;
                while (j2 <= MrxUpperBound1)
                {
                    //j_01=
                    MultK2 = (double)MrxTrans.GetValue(i_0, j2) * MultK1;
                    ak = (double)MrxTrans.GetValue(i2, j2) + MultK2;
                    MrxTrans.SetValue(ak, i2, j2);
                    j2 += 1;
                }
                i2 += 1;
            }
        CalcMoveZeroCollsRows2:
            //2-я перестановка нулевых строк и столбцов (после выполнения расчетов)
            MrxTransInt = (double[,])this.MrxMoveCollsZero(MrxTrans);
            MrxTrans = (double[,])MrxTransInt.Clone();
            MrxTransInt = (double[,])this.MrxMoveRowsZero(MrxTrans);
            MrxTrans = (double[,])MrxTransInt.Clone();
        RangStepIII:
            //Если все строки, начиная со второй, в полученной матрице нулевые, то ее ранг равен 1,
            //так как есть минор первого порядка, отличный от нуля a11. В противном случае перестановкой строк и столбцов матрицы с номерами,
            //большими единицы, добиваемся, чтобы второй элемент второй строки был отличен от нуля
            i3 = i_0 + 1;
            Var = true;
            while (i3 <= MrxUpperBound0)
            {
                if (this.MrxRowZero(MrxTrans, i3) == false)
                {
                    Var = false;
                    break; // TODO: might not be correct. Was : Exit Do
                }
                i3 += 1;
            }
            if (Var == true)
            {
                RangMrx = i_0 + 1;
                goto CalcEnd;
            }
            else
            {
                i_0 = i_0 + 1;
                j_0 = j_0 + 1;
                if (i_0 == MrxUpperBound0 | j_0 == MrxUpperBound0)
                {
                    RangMrx = MrxUpperBound0 + 1;
                    goto CalcEnd;
                }
                else
                {
                    goto CalcZero_ij;
                }
            }
        CalcEnd:
            return RangMrx;
        }

        private object MrxMoveUnit(double[,] Mrxix, int NumRow, int NumColl)
        {
            //Функция возвращает матрицу с переставленным заданным элементом
            bool VarMrxZero = false;
            //Переменная для определения пустой матрицы
            int i = 0;
            int j = 0;
            //Переменные циклов
            int a = 0;
            double[,] MrxTrans = null;
            double[,] MrxTransInt = null;
            //Вспомогательные матрицы
            MrxTrans = new double[Mrxix.GetUpperBound(0) + 1, Mrxix.GetUpperBound(1) + 1];
            //Установка размерности MrxTrans(,)
            MrxTransInt = new double[MrxTrans.GetUpperBound(0) + 1, MrxTrans.GetUpperBound(1) + 1];
            //Установка размерности MrxTransInt(,)
            MrxTrans = (double[,])Mrxix.Clone();
            MrxTransInt = (double[,])MrxTrans.Clone();
        Calc_Step2:

            //        'Проверка равенства заданного элемента нулю
            //Calc_Step1:
            //        If Mrxix.GetValue(NumRow, NumColl) <> 0 Then
            //            MsgBox("Заданный элемент матрицы не равен нулю" & vbCrLf & _
            //                   "", MsgBoxStyle.Exclamation, "Функция установки не нулевого элемента")
            //            Return Mrxix
            //            Exit Function
            //        End If
            //Определение существования не нулевых элементов
            VarMrxZero = this.MrxZero(MrxTrans);
            //Матрица пустая
            if (VarMrxZero == true)
            {
                Interaction.MsgBox("Матрица не содержит элементов, отличных от нуля" + Constants.vbCrLf + "", MsgBoxStyle.Exclamation, "Функция перестановки элемента");
                goto CalcEnd;
            }
        Calc_Step3:
            //Перестановка нулевых строк
            MrxTransInt = (double[,])this.MrxMoveRowsZero(MrxTrans);
            //Перестановка нулевых столбцов
            MrxTransInt = (double[,])this.MrxMoveCollsZero(MrxTransInt);
            MrxTrans = (double[,])MrxTransInt.Clone();
        Calc_Step3a:

            //Проверка изменений после перестановки нулевых строк и столбцов
            if ((double)MrxTrans.GetValue(NumRow, NumColl) == 0 | MrxTrans.GetValue(NumRow, NumColl) == Mrxix.GetValue(NumRow, NumColl))
            {
                goto Calc_Step4a;
            }
            else
            {
                goto CalcEnd;
            }
        Calc_Step4:
        Calc_Step4a:
            //Поиск требуемого (или не нулевого) элемента в матрице. Область поиска ограничивается координатами заданного элемента (начало)и либо нулевой строкой и столбцом либо верхними границами матрицы (конец)
            //Задание матрицы, размер которой равен размеру области поиска
            //Поиск не нулевого элемента по столбцу
            i = NumRow;
            while (i <= MrxTrans.GetUpperBound(0))
            {
                if (this.MrxRowZero(MrxTrans, i) == true)
                {
                    Interaction.MsgBox("Не удалось найти элемент, значение которого не равно нулю и отличается от величины заданного элемента" + Constants.vbCrLf + "", MsgBoxStyle.Exclamation, "Функция перестановки элемента");
                    goto CalcEnd;
                }
                else
                {
                    goto Calc_Step4б;
                }
            }
        RowZero_i:
            i += 1;
            Interaction.MsgBox("Не удалось найти элемент, значение которого не равно нулю и отличается от величины заданного элемента" + Constants.vbCrLf + "", MsgBoxStyle.Exclamation, "Функция перестановки элемента");
            goto CalcEnd;
        Calc_Step4б:

            //Поиск не нулевого элемента по строке
            j = NumColl;
            while (j <= MrxTrans.GetUpperBound(1))
            {
                a = MrxTrans.GetUpperBound(1);
                if (this.MrxCollZero(MrxTrans, j) == true)
                {
                    goto RowZero_i;
                }
                else
                {
                    if ((double)MrxTrans.GetValue(i, j) == 0 | MrxTrans.GetValue(i, j) == MrxTrans.GetValue(NumRow, NumColl))
                    {
                        goto CollZero_j;
                    }
                    else
                    {
                        MrxTransInt = (double[,])this.MrxReplaceColls(MrxTrans, j, NumColl);
                        //Замена элементов по строке
                        MrxTransInt = (double[,])this.MrxReplaceRows(MrxTransInt, i, NumRow);
                        //Замена элементов по столбцу
                        MrxTrans = (double[,])MrxTransInt.Clone();
                        goto CalcEnd;
                    }
                }
            CollZero_j:
                j += 1;
            }
            goto RowZero_i;
        CalcEnd:
            return MrxTrans;
        }

        private object MrxMoveRowsZero(double[,] Mrxix)
        {
            //Функция возвращает матрицу с переставленными вниз нулевыми строками
            bool VarMrxZero = false;
            //Переменная для определения пустой матрицы
            bool VarRowZero = false;
            //Переменная для определения нулевых строк 
            int i = 0;
            int i1 = 0;
            //Переменные циклов
            double[,] MrxTrans = null;
            double[,] MrxTransInt = null;
            //Вспомогательные матрицы
            MrxTrans = new double[Mrxix.GetUpperBound(0) + 1, Mrxix.GetUpperBound(1) + 1];
            //Установка размерности MrxTrans(,)
            MrxTransInt = new double[MrxTrans.GetUpperBound(0) + 1, MrxTrans.GetUpperBound(1) + 1];
            //Установка размерности MrxTransInt(,)
            MrxTrans = (double[,])Mrxix.Clone();
            MrxTransInt = (double[,])MrxTrans.Clone();
        Calc_Step1:
            //Определение существования не нулевых элементов
            VarMrxZero = this.MrxZero(MrxTrans);
            //Матрица пустая
            if (VarMrxZero == true)
            {
                return MrxTrans;
            }
        Calc_Step2:
            //Определение существования нулевых строк 
            i = MrxTrans.GetLowerBound(0);
            while (i <= MrxTrans.GetUpperBound(0))
            {
                VarRowZero = this.MrxRowZero(MrxTrans, i);
                //Строка содержит только нулевые элементы 
                if (VarRowZero == true)
                {
                    goto Calc_Step3;
                }
            }
        RowI:
            i += 1;
            MrxTrans = (double[,])MrxTransInt.Clone();
            return MrxTrans;
        Calc_Step3:
            //Перестановка нулевых и не нулевых строк 
            i1 = i + 1;
            while (i1 <= MrxTrans.GetUpperBound(0))
            {
                VarRowZero = this.MrxRowZero(MrxTrans, i1);
                //Строка содержит не нулевые элементы 
                if (VarRowZero == false)
                {
                    MrxTransInt = (double[,])this.MrxReplaceRows(MrxTrans, i1, i);
                    //Перестановка строк
                    goto RowI;
                }
                i1 += 1;
            }
            MrxTrans = (double[,])MrxTransInt.Clone();
            return MrxTrans;
        }

        private object MrxMoveCollsZero(double[,] Mrxix)
        {
            //Функция возвращает матрицу с переставленными вправо нулевыми столбцами
            double[,] MrxTrans = null;
            double[,] MrxTransInt = null;
            //Вспомогательные матрицы
            bool VarMrxZero = false;
            //Переменная для определения пустой матрицы
            bool VarСolZero = false;
            //Переменная для определения нулевых столбцов 
            int j = 0;
            int j1 = 0;
            //Переменные циклов
            MrxTrans = new double[Mrxix.GetUpperBound(0) + 1, Mrxix.GetUpperBound(1) + 1];
            //Установка размерности MrxTrans(,)
            MrxTransInt = new double[MrxTrans.GetUpperBound(0) + 1, MrxTrans.GetUpperBound(1) + 1];
            //Установка размерности MrxTransInt(,)
            MrxTrans = (double[,])Mrxix.Clone();
            MrxTransInt = (double[,])MrxTrans.Clone();
        Calc_Step1:
            //Определение существования не нулевых элементов
            VarMrxZero = this.MrxZero(MrxTrans);
            //Матрица пустая
            if (VarMrxZero == true)
            {
                return MrxTrans;
            }
        Calc_Step2:
            //Определение существования нулевых столбцов 
            j = MrxTrans.GetLowerBound(1);
            while (j <= MrxTrans.GetUpperBound(1))
            {
                VarСolZero = this.MrxCollZero(MrxTrans, j);
                //Столбец содержит только нулевые элементы 
                if (VarСolZero == true)
                {
                    goto Calc_Step3;
                }
            }
        Rowj:
            j += 1;
            MrxTrans = (double[,])MrxTransInt.Clone();
            return MrxTrans;
        Calc_Step3:
            //Перестановка нулевых и не нулевых столбцов 
            j1 = j + 1;
            while (j1 <= MrxTrans.GetUpperBound(1))
            {
                VarСolZero = this.MrxCollZero(MrxTrans, j1);
                //Столбец содержит не нулевые элементы 
                if (VarСolZero == false)
                {
                    MrxTransInt = (double[,])this.MrxReplaceColls(MrxTrans, j1, j);
                    //Перестановка столбцов
                    goto Rowj;
                }
                j1 += 1;
            }
            MrxTrans = (double[,])MrxTransInt.Clone();
            return MrxTrans;
        }

        /// <summary>
        /// Возвращает список номеров нулевых строк заданной матрицы
        /// </summary>
        /// <param name="Mrxix">Заданная матрица</param>
        /// <returns>Возвращает список в виде одномерного массива As Integer</returns>
        /// <remarks></remarks>
        public object MrxRowsZero(double[,] Mrxix)
        {
            //Функция возвращает список номеров нулевых строк
            int i = 0;
            int j = 0;
            //Переменная номера строки
            int i1 = 0;
            int ji = 0;
            bool VarRow = false;
            int[] MrxNumbers = null;
            //Матрица номеров нулевых строк
            MrxNumbers = new int[i1 + 1];
            //Поиск нулевой строки
            i = Mrxix.GetLowerBound(0);
            while (i <= Mrxix.GetUpperBound(0))
            {
                VarRow = false;
                //False - строка не нулевая
                j = Mrxix.GetLowerBound(1);
                while (j <= Mrxix.GetUpperBound(1))
                {
                    if ((double)Mrxix.GetValue(i, j) == 0)
                    {
                        VarRow = true;
                    }
                    else
                    {
                        goto RowI;
                    }
                    j += 1;
                }
                if (VarRow == true)
                {
                    ji = 1;
                    Array.Resize(ref MrxNumbers, i1 + 1);
                    MrxNumbers.SetValue(i, i1);
                    i1 += 1;
                }
            RowI:
                i += 1;
            }

            if (ji == 0)
            {
                Interaction.MsgBox("В матрице нет нулевых строк", MsgBoxStyle.Exclamation, "Функция поиска номеров нулевых строк");
                return -1;
            }
            else
            {
                return MrxNumbers;
            }
        }

        /// <summary>
        /// Возвращает список номеров нулевых столбцов заданной матрицы
        /// </summary>
        /// <param name="Mrxix">Заданная матрица</param>
        /// <returns>Возвращает список в виде одномерного массива As Integer</returns>
        /// <remarks></remarks>
        public object MrxCollsZero(double[,] Mrxix)
        {
            //Функция возвращает список номеров нулевых столбцов
            int i = 0;
            int j = 0;
            //Переменная номера столбцов
            int i1 = 0;
            int ji = 0;
            bool VarColl = false;
            int[] MrxNumbers = null;
            //Матрица номеров нулевых столбцов
            MrxNumbers = new int[i1 + 1];
            //Поиск нулевого столбца
            j = Mrxix.GetLowerBound(1);
            while (j <= Mrxix.GetUpperBound(1))
            {
                VarColl = false;
                //False - строка не нулевая
                i = Mrxix.GetLowerBound(0);
                while (i <= Mrxix.GetUpperBound(0))
                {
                    if ((double)Mrxix.GetValue(i, j) == 0)
                    {
                        VarColl = true;
                    }
                    else
                    {
                        goto RowI;
                    }
                    i += 1;
                }
                if (VarColl == true)
                {
                    ji = 1;
                    Array.Resize(ref MrxNumbers, i1 + 1);
                    MrxNumbers.SetValue(j, i1);
                    i1 += 1;
                }
            RowI:
                j += 1;
            }

            if (ji == 0)
            {
                Interaction.MsgBox("В матрице нет нулевых столбцов", MsgBoxStyle.Exclamation, "Функция поиска номеров нулевых столбцов");
                return -1;
            }
            else
            {
                return MrxNumbers;
            }
        }

        /// <summary>
        /// Возвращает TRUE, если все элементы заданной строки заданной матрицы равны нулю
        /// </summary>
        /// <param name="Mrxix">Заданная матрица</param>
        /// <param name="NumRow">Индекс проверяемой строки</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool MrxRowZero(double[,] Mrxix, int NumRow)
        {
            //Функция возвращает TRUE, если все элементы строки равны нулю
            int j = 0;
            //Переменная номеров столбцов
            bool VarRow = false;
            //Контроль соответсвия номера заданной строки и размера матрицы по строкам
            if (NumRow > Mrxix.GetUpperBound(0))
            {
                Interaction.MsgBox("Номер заданной строки превышает количество строк в заданной матрице.", MsgBoxStyle.Critical, "Функция определения нулевых строк в матрице");
            }
            //Поиск нулевой строки
            j = Mrxix.GetLowerBound(1);
            while (j <= Mrxix.GetUpperBound(1))
            {
                if ((double)Mrxix.GetValue(NumRow, j) == 0)
                {
                    VarRow = true;
                }
                else
                {
                    VarRow = false;
                    goto CalcEndCalc;
                }
                j += 1;
            }
        CalcEndCalc:
            if (VarRow == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Возвращает TRUE, если все элементы заданного столбца заданной матрицы равны нулю
        /// </summary>
        /// <param name="Mrxix">Заданная матрица</param>
        /// <param name="NumColl">Индекс проверяемого столбца</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool MrxCollZero(double[,] Mrxix, int NumColl)
        {
            //Функция возвращает TRUE, если все элементы столбца равны нулю
            int i = 0;
            //Переменная номеров строк
            bool VarColl = false;
            //Контроль соответсвия номера заданного столюца и размера матрицы по столюцам
            if (NumColl > Mrxix.GetUpperBound(1))
            {
                Interaction.MsgBox("Номер заданного столюца превышает количество столбцов в заданной матрице.", MsgBoxStyle.Critical, "Функция определения нулевых столбцов в матрице");
            }
            //Поиск нулевой строки
            i = Mrxix.GetLowerBound(0);
            while (i <= Mrxix.GetUpperBound(0))
            {
                if ((double)Mrxix.GetValue(i, NumColl) == 0)
                {
                    VarColl = true;
                }
                else
                {
                    VarColl = false;
                    goto CalcEndCalc;
                }
                i += 1;
            }
        CalcEndCalc:
            if (VarColl == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Возвращает матрицу с переставленными строками
        /// </summary>
        /// <param name="Mrxix">Заданная матрица</param>
        /// <param name="NumRow1">Индекс заданной первой строки для перестановки</param>
        /// <param name="NumRow2">Индекс заданной второй строки для перестановки</param>
        /// <returns>Возвращает двумерную матрицу As Double</returns>
        /// <remarks>Меняет местами первую и вторую заданные строки</remarks>
        public object MrxReplaceRows(double[,] Mrxix, int NumRow1, int NumRow2)
        {
            //Функция возвращает матрицу с переставленными строками
            int j = 0;
            //Переменная номера столбца
            double[,] MrxTrans = null;
            //Матрица преобразований
            //Если номера строк совпадают
            if (NumRow1 == NumRow2)
            {
                return Mrxix;
            }
            MrxTrans = (double[,])Mrxix.Clone();
            //Проверка равентсва заданных строк
            if (this.MrxRow1IsRow2(Mrxix, NumRow1, NumRow2) == true)
            {
                return MrxTrans;
            }
            else
            {
                j = MrxTrans.GetLowerBound(1);
                while (j <= MrxTrans.GetUpperBound(1))
                {
                    MrxTrans.SetValue(Mrxix.GetValue(NumRow2, j), NumRow1, j);
                    MrxTrans.SetValue(Mrxix.GetValue(NumRow1, j), NumRow2, j);
                    j = j + 1;
                }
                return MrxTrans;
            }
        }

        /// <summary>
        /// Возвращает матрицу с переставленными столбцами
        /// </summary>
        /// <param name="Mrxix">Заданная матрица</param>
        /// <param name="NumColl_1">Индекс заданного первого столбца для перестановки</param>
        /// <param name="NumColl_2">Индекс заданного второго столбца для перестановки</param>
        /// <returns>Возвращает двумерную матрицу As Double</returns>
        /// <remarks>Меняет местами первый и второй заданные столбцы</remarks>
        public object MrxReplaceColls(double[,] Mrxix, int NumColl_1, int NumColl_2)
        {
            //Функция возвращает матрицу с переставленными столбцами
            int i = 0;
            //Переменная номера строки
            double[,] MrxTrans = null;
            //Матрица преобразований
            //Если номера столбцов совпадают
            if (NumColl_1 == NumColl_2)
            {
                return Mrxix;
            }
            MrxTrans = (double[,])Mrxix.Clone();
            //Проверка равентсва заданных строк
            if (this.MrxColl1IsColl2(Mrxix, NumColl_1, NumColl_2) == true)
            {
                return MrxTrans;
            }
            else
            {
                i = MrxTrans.GetLowerBound(0);
                while (i <= MrxTrans.GetUpperBound(0))
                {
                    MrxTrans.SetValue(Mrxix.GetValue(i, NumColl_2), i, NumColl_1);
                    MrxTrans.SetValue(Mrxix.GetValue(i, NumColl_1), i, NumColl_2);
                    i = i + 1;
                }
                return MrxTrans;
            }
        }

        /// <summary>
        /// Возвращает TRUE, если все элементы матрицы равны нулю
        /// </summary>
        /// <param name="Mrxix">Заданная матрица</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool MrxZero(double[,] Mrxix)
        {
            //Функция возвращает TRUE, если все элементы матрицы равны нулю
            int i = 0;
            int j = 0;
            //Переменные счетчиков
            bool Var = true;
            //Переменная для расчета
            i = 0;
            j = 0;
            while (i <= Mrxix.GetUpperBound(0))
            {
                while (j <= Mrxix.GetUpperBound(1))
                {
                    if ((double)Mrxix.GetValue(i, j) != 0)
                    {
                        Var = false;
                        return Var;
                    }
                    j += 1;
                }
                i += 1;
            }
            return Var;
        }

        /// <summary>
        /// Возвращает TRUE, если в заданной матрице все соответвующие элементы двух строк взаимно равны
        /// </summary>
        /// <param name="Mrxix">Заданная матрица</param>
        /// <param name="NumRow1">Индекс первой сравниваемой сроки</param>
        /// <param name="NumRow2">Индекс второй сравниваемой сроки</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool MrxRow1IsRow2(double[,] Mrxix, int NumRow1, int NumRow2)
        {
            //Функция возвращает TRUE, если все соответвующие элементы двух строк взаимно равны 
            int j = 0;
            //Переменная номеров столбцов
            bool VarRow = false;
            if (NumRow1 == NumRow2)
            {
                return true;
            }
            j = Mrxix.GetLowerBound(1);
            while (j <= Mrxix.GetUpperBound(1))
            {
                if (Mrxix.GetValue(NumRow1, j) == Mrxix.GetValue(NumRow2, j))
                {
                    VarRow = true;
                }
                else
                {
                    VarRow = false;
                    goto CalcEnd;
                }
                j += 1;
            }
        CalcEnd:
            if (VarRow == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Возвращает TRUE, если в заданной матрице все соответвующие элементы двух столбцов взаимно равны 
        /// </summary>
        /// <param name="Mrxix">Заданная матрица</param>
        /// <param name="NumColl1">Индекс первого сравниваемого столбца</param>
        /// <param name="NumColl2">Индекс второго сравниваемого столбца</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool MrxColl1IsColl2(double[,] Mrxix, int NumColl1, int NumColl2)
        {
            //Функция возвращает TRUE, если все соответвующие элементы двух столбцов взаимно равны 
            int i = 0;
            //Переменная номеров строк
            bool VarColl = false;
            if (NumColl1 == NumColl2)
            {
                return true;
            }
            i = Mrxix.GetLowerBound(1);
            while (i <= Mrxix.GetUpperBound(1))
            {
                if (Mrxix.GetValue(i, NumColl1) == Mrxix.GetValue(i, NumColl2))
                {
                    VarColl = true;
                }
                else
                {
                    VarColl = false;
                    goto CalcEnd;
                }
                i += 1;
            }
        CalcEnd:
            if (VarColl == true)
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
