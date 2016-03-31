using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GeomObjects
{
    /// <summary>
    ///  Класс операций с элементами массива размерностью (N, M), где N - количество строк, M - количество столбцов
    ///  Расширяет класс ArrayNxM_Operation для работы с массивами As Double(,)
    /// </summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2014</remarks>
    public class ArrayNxM_Double : ArrayNxM_Integer
    {


        private ArrayControl ArrayControl_VarDbl = new ArrayControl();
        public ArrayNxM_Double()
        {
        }

        /// <summary>
        ///  Возвращает массив с переставленным заданным элементом
        /// </summary>
        /// <param name="ArrayNxM_Source" >Заданный массив</param>
        /// <param name="NumCol">Номер строки</param>
        /// <param name="NumRow">Номер столбца</param>
        /// <remarks> </remarks>
        public double[,] MoveUnit(double[,] ArrayNxM_Source, int NumRow, int NumCol)
        {
            bool VarMrxZero = false;
            //Переменная для определения пустой матрицы
            int i = 0;
            int j = 0;
            //Переменные циклов
            int a = 0;
            double[,] MrxTrans = null;
            double[,] MrxTransInt = null;
            //Вспомогательные матрицы
            MrxTrans = new double[ArrayNxM_Source.GetUpperBound(0) + 1, ArrayNxM_Source.GetUpperBound(1) + 1];
            //Установка размерности MrxTrans(,)
            MrxTransInt = new double[MrxTrans.GetUpperBound(0) + 1, MrxTrans.GetUpperBound(1) + 1];
            //Установка размерности MrxTransInt(,)
            MrxTrans = (double[,])ArrayNxM_Source.Clone();
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
            VarMrxZero = this.ArrayNxM_Zero(MrxTrans);
            //Матрица пустая
            if (VarMrxZero == true)
            {
                //MsgBox("Массив не содержит элементов, отличных от нуля" & vbCrLf & _
                //      "", MsgBoxStyle.Exclamation, "Функция перестановки элемента в массиве")
                goto CalcEnd;
            }
        Calc_Step3:
            //Перестановка нулевых строк
            MrxTransInt = this.MoveToDown_ZeroRows(MrxTrans);
            //Перестановка нулевых столбцов
            MrxTransInt = this.MoveToRight_ZeroCols(MrxTransInt);
            MrxTrans = (double[,])MrxTransInt.Clone();
        Calc_Step3a:

            //Проверка изменений после перестановки нулевых строк и столбцов
            if ((double)MrxTrans.GetValue(NumRow, NumCol) == 0 | MrxTrans.GetValue(NumRow, NumCol) == ArrayNxM_Source.GetValue(NumRow, NumCol))
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
                if (this.ZeroRow(MrxTrans, i) == true)
                {
                    //MsgBox("Не удалось найти элемент, значение которого не равно нулю и отличается от величины заданного элемента" & vbCrLf & _
                    //       "", MsgBoxStyle.Exclamation, "Функция перестановки элемента в массиве")
                    goto CalcEnd;
                }
                else
                {
                    goto Calc_Step4б;
                }
            }
        RowZero_i:
            i += 1;
            //MsgBox("Не удалось найти элемент, значение которого не равно нулю и отличается от величины заданного элемента" & vbCrLf & _
            //       "", MsgBoxStyle.Exclamation, "Функция перестановки элемента в массиве")
            goto CalcEnd;
        Calc_Step4б:
            //Поиск не нулевого элемента по строке
            j = NumCol;
            while (j <= MrxTrans.GetUpperBound(1))
            {
                a = MrxTrans.GetUpperBound(1);
                if (this.ZeroCol(MrxTrans, j) == true)
                {
                    goto RowZero_i;
                }
                else
                {
                    if ((double)MrxTrans.GetValue(i, j) == 0 | MrxTrans.GetValue(i, j) == MrxTrans.GetValue(NumRow, NumCol))
                    {
                        goto CollZero_j;
                    }
                    else
                    {
                        MrxTransInt = this.ReplaceCols(MrxTrans, j, NumCol);
                        //Замена элементов по строке
                        MrxTransInt = this.ReplaceRows(MrxTransInt, i, NumCol);
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

        /// <summary>
        /// Возвращает массив с переставленными вниз нулевыми строками
        /// </summary>
        /// <param name="ArrayNxM_Source" >Заданный массив</param>
        public double[,] MoveToDown_ZeroRows(double[,] ArrayNxM_Source)
        {
            bool? VarMrxZero = false;
            //Переменная для определения пустой матрицы
            bool? VarRowZero = false;
            //Переменная для определения нулевых строк 
            int i = 0;
            int i1 = 0;
            //Переменные циклов
            double[,] MrxTrans = null;
            double[,] MrxTransInt = null;
            //Вспомогательные матрицы
            MrxTrans = new double[ArrayNxM_Source.GetUpperBound(0) + 1, ArrayNxM_Source.GetUpperBound(1) + 1];
            //Установка размерности MrxTrans(,)
            MrxTransInt = new double[MrxTrans.GetUpperBound(0) + 1, MrxTrans.GetUpperBound(1) + 1];
            //Установка размерности MrxTransInt(,)
            MrxTrans = (double[,])ArrayNxM_Source.Clone();
            MrxTransInt = (double[,])MrxTrans.Clone();
        Calc_Step1:
            //Определение существования не нулевых элементов
            VarMrxZero = this.ArrayNxM_Zero(MrxTrans);
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
                VarRowZero = this.ZeroRow(MrxTrans, i);
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
                VarRowZero = this.ZeroRow(MrxTrans, i1);
                //Строка содержит не нулевые элементы 
                if (VarRowZero == false)
                {
                    MrxTransInt = this.ReplaceRows(MrxTrans, i1, i);
                    //Перестановка строк
                    goto RowI;
                }
                i1 += 1;
            }
            MrxTrans = (double[,])MrxTransInt.Clone();
            return MrxTrans;
        }

        /// <summary>
        /// Возвращает массив с переставленными вправо нулевыми столбцами
        /// </summary> 
        /// <param name="ArrayNxM_Source" >Заданный массив</param>
        public double[,] MoveToRight_ZeroCols(double[,] ArrayNxM_Source)
        {
            double[,] MrxTrans = null;
            double[,] MrxTransInt = null;
            //Вспомогательные матрицы
            bool? VarMrxZero = false;
            //Переменная для определения пустой матрицы
            bool? VarСolZero = false;
            //Переменная для определения нулевых столбцов 
            int j = 0;
            int j1 = 0;
            //Переменные циклов
            MrxTrans = new double[ArrayNxM_Source.GetUpperBound(0) + 1, ArrayNxM_Source.GetUpperBound(1) + 1];
            //Установка размерности MrxTrans(,)
            MrxTransInt = new double[MrxTrans.GetUpperBound(0) + 1, MrxTrans.GetUpperBound(1) + 1];
            //Установка размерности MrxTransInt(,)
            MrxTrans = (double[,])ArrayNxM_Source.Clone();
            MrxTransInt = (double[,])MrxTrans.Clone();
        Calc_Step1:
            //Определение существования не нулевых элементов
            VarMrxZero = this.ArrayNxM_Zero(MrxTrans);
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
                VarСolZero = this.ZeroCol(MrxTrans, j);
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
                VarСolZero = this.ZeroCol(MrxTrans, j1);
                //Столбец содержит не нулевые элементы 
                if (VarСolZero == false)
                {
                    MrxTransInt = this.ReplaceCols(MrxTrans, j1, j);
                    //Перестановка столбцов
                    goto Rowj;
                }
                j1 += 1;
            }
            MrxTrans = (double[,])MrxTransInt.Clone();
            return MrxTrans;
        }

        /// <summary>
        /// Возвращает список номеров нулевых строк заданного массива
        /// </summary>
        /// <param name="ArrayNxM_Source">Заданный массив</param>
        /// <remarks>Возвращает в списке -1, если нулевые строки в массиве отсутсвуют</remarks>
        public int[] IndexList_ZeroRows(double[,] ArrayNxM_Source)
        {
            int i = 0;
            int j = 0;
            //Переменная номера строки
            dynamic i1 = 0;
            int ji = 0;
            bool VarRow = false;
            int[] MrxNumbers = null;
            //Матрица номеров нулевых строк
            MrxNumbers = new int[i1 + 1];
            //Поиск нулевой строки
            i = ArrayNxM_Source.GetLowerBound(0);
            while (i <= ArrayNxM_Source.GetUpperBound(0))
            {
                VarRow = false;
                //False - строка не нулевая
                j = ArrayNxM_Source.GetLowerBound(1);
                while (j <= ArrayNxM_Source.GetUpperBound(1))
                {
                    if ((double)ArrayNxM_Source.GetValue(i, j) == 0)
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
                //MsgBox("В массиве нет нулевых строк", _
                //MsgBoxStyle.Exclamation, "Функция поиска номеров нулевых строк")
                MrxNumbers = new int[1];
                MrxNumbers.SetValue(-1, 0);
                return MrxNumbers;
            }
            else
            {
                return MrxNumbers;
            }
        }

        /// <summary>
        /// Возвращает список номеров нулевых столбцов заданного массива
        /// </summary>
        /// <param name="ArrayNxM_Source">Заданный массив</param>
        /// <remarks>Возвращает в списке -1, если нулевые строки в массиве отсутсвуют</remarks>
        public int[] IndexList_ZeroCols(double[,] ArrayNxM_Source)
        {
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
            j = ArrayNxM_Source.GetLowerBound(1);
            while (j <= ArrayNxM_Source.GetUpperBound(1))
            {
                VarColl = false;
                //False - строка не нулевая
                i = ArrayNxM_Source.GetLowerBound(0);
                while (i <= ArrayNxM_Source.GetUpperBound(0))
                {
                    if ((double)ArrayNxM_Source.GetValue(i, j) == 0)
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
                //MsgBox("В массиве нет нулевых столбцов", _
                //MsgBoxStyle.Exclamation, "Функция поиска номеров нулевых столбцов")
                MrxNumbers = new int[1];
                MrxNumbers.SetValue(-1, 0);
                return MrxNumbers;
            }
            else
            {
                return MrxNumbers;
            }
        }

        /// <summary>
        /// Возвращает TRUE, если все элементы заданной строки равны нулю
        /// </summary>
        /// <param name="ArrayNxM_Source">Заданный массив</param>
        /// <remarks>Возвращает Nothing, если номер заданной строки превышает количество строк в заданном массиве</remarks>
        public bool? ZeroRow(double[,] ArrayNxM_Source, int NumRow)
        {
            int j = 0;
            //Переменная номеров столбцов
            bool VarRow = false;
            //Контроль соответсвия номера заданной строки и размера матрицы по строкам
            if (NumRow > ArrayNxM_Source.GetUpperBound(0))
            {
                //MsgBox("Номер заданной строки превышает количество строк в заданном массиве.", _
                //MsgBoxStyle.Critical, "Функция определения нулевых строк в массиве")
                return null;
            }
            //Поиск нулевой строки
            j = ArrayNxM_Source.GetLowerBound(1);
            while (j <= ArrayNxM_Source.GetUpperBound(1))
            {
                if ((double)ArrayNxM_Source.GetValue(NumRow, j) == 0)
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
        /// Возвращает TRUE, если все элементы столбца равны нулю
        /// </summary>
        /// <param name="ArrayNxM_Source">Заданный массив</param>
        /// <remarks>Возвращает Nothing, если номер заданного столбца превышает количество столбцов в заданном массиве</remarks>
        public bool? ZeroCol(double[,] ArrayNxM_Source, int NumCol)
        {
            int i = 0;
            //Переменная номеров строк
            bool VarColl = false;
            //Контроль соответсвия номера заданного столюца и размера матрицы по столюцам
            if (NumCol > ArrayNxM_Source.GetUpperBound(1))
            {
                //MsgBox("Номер заданного столбца превышает количество столбцов в заданном массиве.", _
                //MsgBoxStyle.Critical, "Функция определения нулевых столбцов в массиве")
                return null;
            }
            //Поиск нулевой строки
            i = ArrayNxM_Source.GetLowerBound(0);
            while (i <= ArrayNxM_Source.GetUpperBound(0))
            {
                if ((double)ArrayNxM_Source.GetValue(i, NumCol) == 0)
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
        /// Возвращает массив с переставленными строками
        /// </summary>
        /// <param name="ArrayNxM_Source">Заданный массив</param>
        public double[,] ReplaceRows(double[,] ArrayNxM_Source, int NumRow1, int NumRow2)
        {
            int j = 0;
            //Переменная номера столбца
            double[,] MrxTrans = null;
            //Матрица преобразований
            //Если номера строк совпадают
            if (NumRow1 == NumRow2)
            {
                return ArrayNxM_Source;
            }
            MrxTrans = (double[,])ArrayNxM_Source.Clone();
            //Проверка равентсва заданных строк
            if (this.Row1IsRow2(ArrayNxM_Source, NumRow1, NumRow2) == true)
            {
                return MrxTrans;
            }
            else
            {
                j = MrxTrans.GetLowerBound(1);
                while (j <= MrxTrans.GetUpperBound(1))
                {
                    MrxTrans.SetValue(ArrayNxM_Source.GetValue(NumRow2, j), NumRow1, j);
                    MrxTrans.SetValue(ArrayNxM_Source.GetValue(NumRow1, j), NumRow2, j);
                    j = j + 1;
                }
                return MrxTrans;
            }
        }

        /// <summary>
        /// Возвращает массив с переставленными столбцами
        /// </summary>
        /// <param name="ArrayNxM_Source">Заданный массив</param>
        public double[,] ReplaceCols(double[,] ArrayNxM_Source, int NumCol_1, int NumCol_2)
        {
            int i = 0;
            //Переменная номера строки
            double[,] MrxTrans = null;
            //Матрица преобразований
            //Если номера столбцов совпадают
            if (NumCol_1 == NumCol_2)
            {
                return ArrayNxM_Source;
            }
            MrxTrans = (double[,])ArrayNxM_Source.Clone();
            //Проверка равентсва заданных строк
            if (this.Col1IsCol2(ArrayNxM_Source, NumCol_1, NumCol_2) == true)
            {
                return MrxTrans;
            }
            else
            {
                i = MrxTrans.GetLowerBound(0);
                while (i <= MrxTrans.GetUpperBound(0))
                {
                    MrxTrans.SetValue(ArrayNxM_Source.GetValue(i, NumCol_2), i, NumCol_1);
                    MrxTrans.SetValue(ArrayNxM_Source.GetValue(i, NumCol_1), i, NumCol_2);
                    i = i + 1;
                }
                return MrxTrans;

            }
        }

        /// <summary>
        /// Возвращает TRUE, если все элементы масссива равны нулю
        /// </summary>
        /// <param name="ArrayNxM_Source">Заданный массив</param>
        public bool ArrayNxM_Zero(double[,] ArrayNxM_Source)
        {
            int i = 0;
            int j = 0;
            //Переменные счетчиков
            bool Var = true;
            //Переменная для расчета
            i = 0;
            j = 0;
            while (i <= ArrayNxM_Source.GetUpperBound(0))
            {
                j = 0;
                while (j <= ArrayNxM_Source.GetUpperBound(1))
                {
                    if ((double)ArrayNxM_Source.GetValue(i, j) != 0)
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
        /// Возвращает TRUE, если все соответвующие элементы двух строк заданного массива взаимно равны
        /// </summary>
        /// <param name="ArrayNxM_Source">Заданный массив</param>
        public bool Row1IsRow2(double[,] ArrayNxM_Source, int NumRow1, int NumRow2)
        {
            int j = 0;
            //Переменная номеров столбцов
            bool VarRow = false;
            if (NumRow1 == NumRow2)
            {
                return true;
            }
            j = ArrayNxM_Source.GetLowerBound(1);
            while (j <= ArrayNxM_Source.GetUpperBound(1))
            {
                if (ArrayNxM_Source.GetValue(NumRow1, j) == ArrayNxM_Source.GetValue(NumRow2, j))
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
        /// Возвращает TRUE, если все соответвующие элементы двух столбцов заданного массива взаимно равны
        /// </summary>
        /// <param name="ArrayNxM_Source">Заданный массив</param>
        public bool Col1IsCol2(double[,] ArrayNxM_Source, int NumCol1, int NumCol2)
        {
            int i = 0;
            //Переменная номеров строк
            bool VarColl = false;
            if (NumCol1 == NumCol2)
            {
                return true;
            }
            i = ArrayNxM_Source.GetLowerBound(1);
            while (i <= ArrayNxM_Source.GetUpperBound(1))
            {
                if (ArrayNxM_Source.GetValue(i, NumCol1) == ArrayNxM_Source.GetValue(i, NumCol2))
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

        //================================================================================================================================

        /// <summary>
        /// Возвращает одномерный массив содержимого заданного столбца, начиная с заданной строки
        /// </summary>
        /// <param name="SourceArray">Заданный массив</param>
        /// <param name="NumСol">Номер столбца</param>
        /// <param name="RowStart">Номер строки, задающей начало записи данных</param>
        public ArrayList Cut_ColAsList(int NumСol, int RowStart, double[,] SourceArray)
        {
            //Контроль значений заданных индексов
            if (ArrayControl_VarDbl.Control_IndexRowAndCol(RowStart, NumСol, SourceArray) == false)
            {
                return null;
            }
            ArrayList NameGrp = new ArrayList();
            //NameGrp.Add(Nothing)
            for (int i = RowStart; i <= SourceArray.GetUpperBound(0); i++)
            {
                NameGrp.Add(Convert.ToString(SourceArray.GetValue(i, NumСol)));
                //Запись в выходной массив ячеек 1-го столбца
            }
            return NameGrp;
        }

        /// <summary>
        /// Возвращает одномерный массив содержимого заданного столбца, ограниченного номерами заданных строк
        /// </summary>
        /// <param name="SourceArray">Заданный массив</param>
        /// <param name="NumСol">Номер столбца</param>
        /// <param name="RowStart">Номер строки, задающей начало записи данных</param>
        /// <param name="RowEnd">Номер строки, задающей конец записи данных</param>
        public ArrayList Cut_ColAsList(int NumСol, int RowStart, int RowEnd, double[,] SourceArray)
        {
            //Контроль значений заданных индексов
            if (ArrayControl_VarDbl.Control_ColAndIndexRow(RowStart, RowEnd, NumСol, SourceArray) == false)
            {
                return null;
            }
            ArrayList NameGrp = new ArrayList();
            //NameGrp.Add(Nothing)
            for (int i = RowStart; i <= RowEnd; i++)
            {
                NameGrp.Add(Convert.ToString(SourceArray.GetValue(i, NumСol)));
                //Запись в выходной массив ячеек 1-го столбца
            }
            return NameGrp;
        }

        /// <summary>
        /// Возвращает массив содержимого заданной строки, начиная с заданного столбца
        /// </summary>
        /// <param name="SourceArray">Заданный массив</param>
        /// <param name="NumRow">Номер строки</param>
        /// <param name="ColStart">Номер столбца, задающего начало записи данных</param>
        public ArrayList Cut_RowAsList(int NumRow, int ColStart, double[,] SourceArray)
        {
            //Контроль значений заданных индексов
            if (ArrayControl_VarDbl.Control_IndexRowAndCol(NumRow, ColStart, SourceArray) == false)
            {
                return null;
            }
            ArrayList NameGrp = new ArrayList();
            //NameGrp.Add(Nothing)
            for (int j = ColStart; j <= SourceArray.GetUpperBound(1); j++)
            {
                NameGrp.Add(Convert.ToString(SourceArray.GetValue(NumRow, j)));
                //Запись в выходной массив ячеек 1-го столбца
            }
            return NameGrp;
        }

        /// <summary>
        /// Возвращает массив содержимого заданной строки, ограниченной номерами заданных столбцов
        /// </summary>
        /// <param name="SourceArray">Заданный массив</param>
        /// <param name="NumRow">Номер строки</param>
        /// <param name="ColStart">Номер столбца, задающего начало записи данных</param>
        /// <param name="ColEnd">Номер столбца, задающего конец записи данных</param>
        public ArrayList Cut_RowAsList(int NumRow, int ColStart, int ColEnd, double[,] SourceArray)
        {
            //Контроль значений заданных индексов
            if (ArrayControl_VarDbl.Control_RowAndIndexCol(NumRow, ColStart, ColEnd, SourceArray) == false)
            {
                return null;
            }
            ArrayList NameGrp = new ArrayList();
            //NameGrp.Add(Nothing)
            for (int j = ColStart; j <= ColEnd; j++)
            {
                NameGrp.Add(Convert.ToString(SourceArray.GetValue(NumRow, j)));
                //Запись в выходной массив ячеек 1-го столбца
            }
            return NameGrp;
        }

        /// <summary>
        /// Возвращает массив содержимого заданного столбца, начиная с заданной строки
        /// </summary>
        /// <param name="SourceArray">Заданный массив</param>
        /// <param name="NumCol">Номер столбца</param>
        /// <param name="RowStart">Номер строки, задающей начало записи данных</param>
        public double[] Cut_Col(int NumCol, int RowStart, double[,] SourceArray)
        {
            //Контроль значений заданных индексов
            if (ArrayControl_VarDbl.Control_IndexRowAndCol(RowStart, NumCol, SourceArray) == false)
            {
                return null;
            }
            double[] ColArray = null;
            int j = 0;
            for (int i = RowStart; i <= SourceArray.GetUpperBound(0); i++)
            {
                Array.Resize(ref ColArray, j + 1);
                ColArray.SetValue(SourceArray.GetValue(i, NumCol), j);
                //Запись в выходной массив значения текущей ячейки
                j = j + 1;
            }
            return ColArray;
        }

        /// <summary>
        /// Возвращает массив содержимого заданного столбца, ограниченного номерами заданных строк
        /// </summary>
        /// <param name="SourceArray">Заданный массив</param>
        /// <param name="NumCol">Номер столбца</param>
        /// <param name="RowStart">Номер строки, задающей начало записи данных</param>
        public double[] Cut_Col(int NumCol, int RowStart, int RowEnd, double[,] SourceArray)
        {
            //Контроль значений заданных индексов
            if (ArrayControl_VarDbl.Control_ColAndIndexRow(RowStart, RowEnd, NumCol, SourceArray) == false)
            {
                return null;
            }
            double[] ColArray = null;
            int j = 0;
            for (int i = RowStart; i <= RowEnd; i++)
            {
                Array.Resize(ref ColArray, j + 1);
                ColArray.SetValue(SourceArray.GetValue(i, NumCol), j);
                //Запись в выходной массив значения текущей ячейки
                j = j + 1;
            }
            return ColArray;
        }

        /// <summary>
        /// Возвращает массив содержимого заданной строки, начиная с заданного столбца
        /// </summary>
        /// <param name="SourceArray">Заданный массив</param>
        /// <param name="NumRow">Номер строки</param>
        /// <param name="ColStart">Номер столбца, задающего начало записи данных</param>
        public double[] Cut_Row(int NumRow, int ColStart, double[,] SourceArray)
        {
            //Контроль значений заданных индексов
            if (ArrayControl_VarDbl.Control_IndexRowAndCol(NumRow, ColStart, SourceArray) == false)
            {
                return null;
            }
            double[] RowArray = null;
            int i = 0;
            for (int j = ColStart; j <= SourceArray.GetUpperBound(1); j++)
            {
                Array.Resize(ref RowArray, i + 1);
                RowArray.SetValue(SourceArray.GetValue(NumRow, j), i);
                //Запись в выходной массив значения текущей ячейки
                i = i + 1;
            }
            return RowArray;
        }

        /// <summary>
        /// Возвращает часть содержимого заданного массива, ограниченного заданными номерами строк и столбцов и размерностью заданного массива
        /// </summary>
        /// <param name="SourceArray">Заданный массив</param>
        /// <param name="RowStart">Номер начальной строки области вырезания</param>
        /// <param name="ColStart">Номер начального столбца области вырезания</param>
        public double[,] Cut_PartArray(int RowStart, int ColStart, double[,] SourceArray)
        {
            //Контроль значений заданных индексов
            if (ArrayControl_VarDbl.Control_IndexRowAndCol(RowStart, ColStart, SourceArray) == false)
            {
                return null;
            }
            //Контроль существования заданных массивов
            //Массив не существует
            if (SourceArray == null)
            {
                return null;
            }
            else
            {
                double[,] ArrayOut = new double[SourceArray.GetUpperBound(0) + 1, SourceArray.GetUpperBound(1) + 1];
                //Запись значений в выходной массив
                for (int i = RowStart; i <= SourceArray.GetUpperBound(0); i++)
                {
                    for (int j = ColStart; j <= SourceArray.GetUpperBound(1); j++)
                    {
                        ArrayOut.SetValue(SourceArray.GetValue(i, j), i, j);
                        //Запись в выходной массив значения текущей ячейки
                    }
                }
                return ArrayOut;
            }
        }

        /// <summary>
        /// Возвращает часть содержимого заданного массива, ограниченного заданными номерами строк и столбцов
        /// </summary>
        /// <param name="SourceArray">Заданный массив</param>
        /// <param name="RowStart">Номер начальной строки области вырезания</param>
        /// <param name="RowEnd">Номер конечной строки области вырезания</param>
        /// <param name="ColStart">Номер начального столбца области вырезания</param>
        /// <param name="ColEnd">Номер конечного столбца области вырезания</param>
        public double[,] Cut_PartArray(int RowStart, int RowEnd, int ColStart, int ColEnd, double[,] SourceArray)
        {
            //Контроль значений заданных индексов
            if (ArrayControl_VarDbl.Control_IndexRowAndCol(RowStart, RowEnd, ColStart, ColEnd, SourceArray) == false)
            {
                return null;
            }
            double[,] PartArray = new double[RowEnd + 1, ColEnd + 1];
            for (int i = RowStart; i <= RowEnd; i++)
            {
                for (int j = ColStart; j <= ColEnd; j++)
                {
                    PartArray.SetValue(SourceArray.GetValue(i, j), i, j);
                    //Запись в выходной массив значения текущей ячейки
                }
            }
            return PartArray;
        }

        /// <summary>
        /// Обнуляет содержимое заданного массива кроме части, ограниченноой заданными номерами строк и столбцов
        /// </summary>
        /// <param name="SourceArray">Заданный массив</param>
        /// <param name="RowStart">Номер начальной строки не обнуляемой области</param>
        /// <param name="RowEnd">Номер конечной строки не обнуляемой области</param>
        /// <param name="ColStart">Номер начального столбца не обнуляемой области</param>
        /// <param name="ColEnd">Номер конечного столбца не обнуляемой области</param>
        /// <remarks>Возвращаемый массив имеет размерность заданного массива</remarks>
        public double[,] ClearArrayAroundPart(int RowStart, int RowEnd, int ColStart, int ColEnd, double[,] SourceArray)
        {
            //Контроль значений заданных индексов
            if (ArrayControl_VarDbl.Control_IndexRowAndCol(RowStart, RowEnd, ColStart, ColEnd, SourceArray) == false)
            {
                return null;
            }
            //Контроль существования заданных массивов
            //Массив не существует
            if (SourceArray == null)
            {
                return null;
            }
            else
            {
                double[,] ArrayOut = new double[SourceArray.GetUpperBound(0) + 1, SourceArray.GetUpperBound(1) + 1];
                //Запись значений в выходной массив
                for (int i = RowStart; i <= RowEnd; i++)
                {
                    for (int j = ColStart; j <= ColEnd; j++)
                    {
                        ArrayOut.SetValue(SourceArray.GetValue(i, j), i, j);
                        //Запись в выходной массив значения текущей ячейки
                    }
                }
                return ArrayOut;
            }
        }

        /// <summary>
        /// Возвращает массив (DestinationArray), в который копируется часть содержимого заданного массива (SourceArray), ограниченного заданными номерами строк и столбцов
        /// </summary>
        /// <param name="SourceArray">Заданный массив</param>
        /// <param name="RowStart">Номер начальной строки копируемой области</param>
        /// <param name="RowEnd">Номер конечной строки копируемой области</param>
        /// <param name="ColStart">Номер начального столбца копируемой области</param>
        /// <param name="ColEnd">Номер конечного столбца копируемой области</param>
        /// <remarks>Вставляет содержимое в интервал, определяемый заданными номерами строк и столбцов</remarks>
        public double[,] PartArrayToArrayCopy(int RowStart, int RowEnd, int ColStart, int ColEnd, double[,] SourceArray, double[,] DestinationArray)
        {
            //Контроль значений заданных индексов
            if (ArrayControl_VarDbl.Control_IndexRowAndCol(RowStart, RowEnd, ColStart, ColEnd, SourceArray) == false)
            {
                return null;
            }
            //Контроль существования заданных массивов
            //Оба массива не существуют
            if (SourceArray == null & DestinationArray == null)
            {
                return null;
                //Не существует массив, в который будут записываться значения
            }
            else if (SourceArray != null & DestinationArray == null)
            {
                DestinationArray = (double[,])SourceArray.Clone();
                return DestinationArray;
                //Не существует массив данных для записи
            }
            else if (SourceArray == null & DestinationArray != null)
            {
                return DestinationArray;
                //Возвращает массив без изменений
                //Существуют оба массива
            }
            else
            {
                //Контроль превышения размерности (по строкам и столбцам) SourceArray к размерности DestinationArray
                double[,] DestArrayVar = null;
                if (SourceArray.GetUpperBound(0) > DestinationArray.GetUpperBound(0) & SourceArray.GetUpperBound(1) > DestinationArray.GetUpperBound(1))
                {
                    DestArrayVar = (double[,])DestinationArray.Clone();
                    //Копия выходного массива
                    DestinationArray = new double[SourceArray.GetUpperBound(0) + 1, SourceArray.GetUpperBound(1) + 1];
                }
                else if (SourceArray.GetUpperBound(0) > DestinationArray.GetUpperBound(0) & SourceArray.GetUpperBound(1) <= DestinationArray.GetUpperBound(1))
                {
                    DestArrayVar = (double[,])DestinationArray.Clone();
                    //Копия выходного массива
                    DestinationArray = new double[SourceArray.GetUpperBound(0) + 1, DestArrayVar.GetUpperBound(1) + 1];
                }
                else if (SourceArray.GetUpperBound(0) <= DestinationArray.GetUpperBound(0) & SourceArray.GetUpperBound(1) > DestinationArray.GetUpperBound(1))
                {
                    DestArrayVar = (double[,])DestinationArray.Clone();
                    //Копия выходного массива
                    DestinationArray = new double[DestArrayVar.GetUpperBound(0) + 1, SourceArray.GetUpperBound(1) + 1];
                }
                else
                {
                    goto DataCopy;
                }
                //Запись исходных значений DestinationArray
                for (int i = 0; i <= DestArrayVar.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= DestArrayVar.GetUpperBound(1); j++)
                    {
                        DestinationArray.SetValue(DestArrayVar.GetValue(i, j), i, j);
                    }
                }
            DataCopy:
                //Запись значений в выходной массив
                for (int i = RowStart; i <= RowEnd; i++)
                {
                    for (int j = ColStart; j <= ColEnd; j++)
                    {
                        DestinationArray.SetValue(SourceArray.GetValue(i, j), i, j);
                        //Запись в выходной массив значения текущей ячейки
                    }
                }
                return DestinationArray;
            }
        }

        /// <summary>
        /// Возвращает массив (DestinationArray), в который копируется часть содержимого заданного массива (SourceArray), ограниченного заданными номерами строк и столбцов
        /// </summary>
        /// <param name="SourceArray">Заданный массив</param>
        /// <param name="RowStart">Номер начальной строки копируемой области</param>
        /// <param name="ColStart">Номер начального столбца копируемой области</param>
        /// <remarks>Вставляет содержимое в интервал, определяемый заданными номерами строк и столбцов</remarks>
        public double[,] PartArrayToArrayCopy(int RowStart, int ColStart, double[,] SourceArray, double[,] DestinationArray)
        {
            //Контроль значений заданных индексов
            if (ArrayControl_VarDbl.Control_IndexRowAndCol(RowStart, ColStart, SourceArray) == false)
            {
                return null;
            }
            //Контроль существования заданных массивов
            //Оба массива не существуют
            if (SourceArray == null & DestinationArray == null)
            {
                return null;
                //Не существует массив, в который будут записываться значения
            }
            else if (SourceArray != null & DestinationArray == null)
            {
                DestinationArray = (double[,])SourceArray.Clone();
                return DestinationArray;
                //Не существует массив данных для записи
            }
            else if (SourceArray == null & DestinationArray != null)
            {
                return DestinationArray;
                //Возвращает массив без изменений
                //Существуют оба массива
            }
            else
            {
                //Контроль превышения размерности (по строкам и столбцам) SourceArray к размерности DestinationArray
                double[,] DestArrayVar = null;
                if (SourceArray.GetUpperBound(0) > DestinationArray.GetUpperBound(0) & SourceArray.GetUpperBound(1) > DestinationArray.GetUpperBound(1))
                {
                    DestArrayVar = (double[,])DestinationArray.Clone();
                    //Копия выходного массива
                    DestinationArray = new double[SourceArray.GetUpperBound(0) + 1, SourceArray.GetUpperBound(1) + 1];
                }
                else if (SourceArray.GetUpperBound(0) > DestinationArray.GetUpperBound(0) & SourceArray.GetUpperBound(1) <= DestinationArray.GetUpperBound(1))
                {
                    DestArrayVar = (double[,])DestinationArray.Clone();
                    //Копия выходного массива
                    DestinationArray = new double[SourceArray.GetUpperBound(0) + 1, DestArrayVar.GetUpperBound(1) + 1];
                }
                else if (SourceArray.GetUpperBound(0) <= DestinationArray.GetUpperBound(0) & SourceArray.GetUpperBound(1) > DestinationArray.GetUpperBound(1))
                {
                    DestArrayVar = (double[,])DestinationArray.Clone();
                    //Копия выходного массива
                    DestinationArray = new double[DestArrayVar.GetUpperBound(0) + 1, SourceArray.GetUpperBound(1) + 1];
                }
                else
                {
                    goto DataCopy;
                }
                //Запись исходных значений DestinationArray
                for (int i = 0; i <= DestArrayVar.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= DestArrayVar.GetUpperBound(1); j++)
                    {
                        DestinationArray.SetValue(DestArrayVar.GetValue(i, j), i, j);
                    }
                }
            DataCopy:
                //Запись значений в выходной массив
                for (int i = RowStart; i <= SourceArray.GetUpperBound(0); i++)
                {
                    for (int j = ColStart; j <= SourceArray.GetUpperBound(1); j++)
                    {
                        DestinationArray.SetValue(SourceArray.GetValue(i, j), i, j);
                        //Запись в выходной массив значения текущей ячейки
                    }
                }
                return DestinationArray;
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Возвращает двумерный массив, содержащий в первой колонке номера ячеек ArrayList, во второй - значения ячеек ArrayList
        /// </summary>
        /// <param name="SourceArrayList">Заданный массив</param>
        public double[,] CnvArrayListToArray2D(ArrayList SourceArrayList)
        {
            //Возвращает двумерный массив, содержащий в первой колонке номера ячеек ArrayList, во второй - значения ячеек ArrayList
            double[,] Array2D_Out = new double[SourceArrayList.Count, 2];
            //Array2D_Out.SetValue(0, 0, 0)
            for (int i = 0; i <= Array2D_Out.GetUpperBound(0); i++)
            {
                Array2D_Out.SetValue(i, i, 0);
                //Запись в выходной массив номеров
                Array2D_Out.SetValue(SourceArrayList[i], i, 1);
                //Запись в выходной массив ячеек 1-го столбца
            }
            return Array2D_Out;
        }

        /// <summary>
        /// Возвращает "True", если в заданной строке (NumRow), начиная с заданного столбца (ColStart) имеется заданное значение (Value)
        /// </summary>
        /// <param name="SourceArray">Заданный массив</param>
        /// <param name="Value">Проверяемое значение</param>
        /// <param name="NumRow">Номер контролируемой строки</param>
        /// <param name="ColStart">Номер столбца, задающего начало контролируемой области</param>
        /// <remarks>Вставляет содержимое в интервал, определяемый заданными номерами строк и столбцов</remarks>
        public bool? Control_RowValue(object Value, int NumRow, int ColStart, double[,] SourceArray)
        {
            //Контроль значений заданных индексов
            if (ArrayControl_VarDbl.Control_IndexRowAndCol(NumRow, ColStart, SourceArray) == false)
            {
                return null;
            }
            for (int j = ColStart; j <= SourceArray.GetUpperBound(1); j++)
            {
                //контроль существания нуля в текущей ячейке
                if (SourceArray.GetValue(ColStart, j) == Value)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Возвращает номера строк двумерного массива, в которых нет заданного значения, начиная с заданной строки и заданного столбца
        /// </summary>
        /// <param name="SourceArray">Заданный массив</param>
        /// <param name="Value">Проверяемое значение</param>
        /// <param name="NumRow">Номер контролируемой строки</param>
        /// <param name="ColStart">Номер столбца, задающего начало контролируемой области</param>
        /// <remarks>Вставляет содержимое в интервал, определяемый заданными номерами строк и столбцов</remarks>
        public int[] IndexRowsOfNonValue(object Value, int NumRow, int ColStart, double[,] SourceArray)
        {
            //Возвращает номера строк двумерного массива, в которых нет заданного значения, начиная с заданной строки и заданного столбца
            //Если таких строк нет - возвращает Nothing
            int[] IndexRows = null;
            int ii = 0;
            for (int i = NumRow; i <= SourceArray.GetUpperBound(0); i++)
            {
                if (this.Control_RowValue(Value, i, ColStart, SourceArray) == false)
                {
                    Array.Resize(ref IndexRows, ii + 1);
                    IndexRows.SetValue(i, ii);
                    ii = ii + 1;
                }
            }
            return IndexRows;
        }

        //==============================================================================================================================================================
        //------------------------------------------------- Вставка и замена столбцов в заданный массив (As Double) -----------------------------------------------------

        /// <summary>
        /// Возвращает двумерный массив, увеличенный на один столбец, место вставки которого задано индексом
        /// </summary>
        /// <param name="IndexAddColl">Индекс вставляемого столбца (последующие сдвигаютсяя на одну позицию)</param>
        /// <param name="SourceArray">Заданный массив для добавления столбца</param>
        /// <returns>Возвращает двумерный массив As Double</returns>
        /// <remarks>
        /// Значения ячеек вставляемого столбца равны нулю.
        /// Содержимое заданного массива в возвращаемом масссиве сохраняется.
        /// Индекс заданного столбца соответсвует нумерации столбцов массива, т.е. начинается с нуля.
        /// При значении индекса заданного столбца, превышающем более, чем на один количество столбцов заданного массива, возвращается исходный массив.
        /// При отрицательном значении индекса вставляемого столбца возвращается исходный массив.
        /// </remarks>
        public double[,] Array_CollAdd(int IndexAddColl, double[,] SourceArray)
        {
            double[,] ArrayVar = new double[SourceArray.GetUpperBound(0) + 1, SourceArray.GetUpperBound(1) + 2];
            //Выходной массив, размерностью больше на один столбец заданного массива
            int i = 0;
            int j = 0;
            //Контроль значения индекса заданного столбца
            //Значение индекса столбца более, чем на одну позицию размера заданного массива
            if (IndexAddColl > SourceArray.GetUpperBound(1) + 1)
            {
                //IndexColl = SourceArray.GetUpperBound(1) + 1 'Приведение индекса к значению больше только на одну позицию размера заданного массива
                return SourceArray;
                //При значении индекса заданного столбца, превышающем количество столбцов заданного массива, возвращается исходный массив
                //(можно сделать удаление из заданного массива столбца, соответствующего по модулю заданному отрицательному индексу)
            }
            else if (IndexAddColl < 0)
            {
                //IndexColl = 0
                return SourceArray;
                //При отрицательном значении места вставки возвращает исходный массив
            }
            //Вставка нового столбца, имеющего индекс, равный нулю
            if (IndexAddColl == 0)
            {
                for (i = 0; i <= SourceArray.GetUpperBound(0); i++)
                {
                    //Копирование значений заданного массива до вставляемого столбца
                    for (j = 0; j <= SourceArray.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArray.GetValue(i, j), i, j + 1);
                    }
                }
            }
            else
            {
                for (i = 0; i <= SourceArray.GetUpperBound(0); i++)
                {
                    //Копирование значений заданного массива до вставляемого столбца
                    for (j = 0; j <= IndexAddColl - 1; j++)
                    {
                        ArrayVar.SetValue(SourceArray.GetValue(i, j), i, j);
                    }
                }
                for (i = 0; i <= SourceArray.GetUpperBound(0); i++)
                {
                    //Копирование значений заданного массива после вставляемого столбца
                    for (j = IndexAddColl; j <= SourceArray.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArray.GetValue(i, j), i, j + 1);
                    }
                }
            }
            return ArrayVar;
        }

        /// <summary>
        /// Возвращает двумерный массив, увеличенный на несколько столбцов, начальное место вставки которых задано индексом
        /// </summary>
        /// <param name="CountColls">Количество вставляемых столбцов</param>
        /// <param name="SourceArray">Заданный массив для добавления столбцов</param>
        /// <param name="IndexForAddFirstColl">Индекс, указывающий место вставки первого столбца</param>
        /// <returns>Возвращает двумерный массив As Double</returns>
        /// <remarks>
        /// Значения ячеек вставляемых столбцов равны нулю.
        /// Содержимое заданного массива в возвращаемом масссиве сохраняется.
        /// Индекс заданного столбца соответсвует нумерации столбцов массива, т.е. начинается с нуля.
        /// При отрицательном значении индекса, указывающего место вставки первого столбца, возвращается исходный массив.
        /// При значении индекса, указывающего место вставки первого столбца, превышающем более, чем на один количество столбцов заданного массива, возвращается исходный массив.
        /// При отрицательном значении количества вставляемых столбцов возвращается исходный массив.
        /// </remarks>
        public double[,] Array_CollAdd(int CountColls, double[,] SourceArray, int IndexForAddFirstColl)
        {
            double[,] ArrayVar = new double[SourceArray.GetUpperBound(0) + 1, SourceArray.GetUpperBound(1) + CountColls + 1];
            //Выходной массив, размерностью больше заданного массива на заданное количество вставляемых столбцов
            int i = 0;
            int j = 0;
            //Контроль значения индекса заданного столбца
            //Значение индекса столбца более, чем на одну позицию размера заданного массива
            if (IndexForAddFirstColl > SourceArray.GetUpperBound(1) + 1)
            {
                //IndexColl = SourceArray.GetUpperBound(1) + 1 'Приведение индекса к значению больше размера заданного массива на заданное количество столбцов
                return SourceArray;
                //При значении индекса вставки столбца, превышающем количество столбцов заданного массива, возвращается исходный массив
                //При отрицательном значении места вставки первого столбца возвращает исходный массив
            }
            else if (IndexForAddFirstColl < 0)
            {
                //IndexColl = 0
                return SourceArray;
            }
            //Контроль задания количества вставляемых столбцов (можно сделать удаление из заданного массива столбцов, количество которых соответсвует заданному отрицательному числу)
            if (CountColls < 0)
            {
                return SourceArray;
            }
            //Вставка нового столбца, имеющего индекс, равный нулю
            if (IndexForAddFirstColl == 0)
            {
                for (i = 0; i <= SourceArray.GetUpperBound(0); i++)
                {
                    //Копирование значений заданного массива после вставляемых столбцов
                    for (j = 0; j <= SourceArray.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArray.GetValue(i, j), i, j + CountColls);
                    }
                }
            }
            else
            {
                for (i = 0; i <= SourceArray.GetUpperBound(0); i++)
                {
                    //Копирование значений заданного массива до вставляемых столбцов
                    for (j = 0; j <= IndexForAddFirstColl - 1; j++)
                    {
                        ArrayVar.SetValue(SourceArray.GetValue(i, j), i, j);
                    }
                }
                for (i = 0; i <= SourceArray.GetUpperBound(0); i++)
                {
                    //Копирование значений заданного массива после вставляемых столбцов
                    for (j = IndexForAddFirstColl; j <= SourceArray.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArray.GetValue(i, j), i, j + CountColls);
                    }
                }
            }
            return ArrayVar;
        }

        /// <summary>
        /// Возвращает двумерный массив, увеличенный на один столбец, место вставки которого задано индексом
        /// </summary>
        /// <param name="AddArray">Добавляемый массив - столбец</param>
        /// <param name="SourceArrayForAdd">Заданный массив для добавления столбца</param>
        /// <param name="IndexForCollAdd">Индекс, определяющий место вставки заданного массива - столбца</param>
        /// <returns>Возвращает двумерный массив As Double</returns>
        /// <remarks>
        /// Содержимое заданного массива в возвращаемом масссиве сохраняется.
        /// Индекс заданного столбца соответсвует нумерации столбцов массива, т.е. начинается с нуля.
        /// При отрицательном значении индекса, указывающего место вставки столбца, возвращается исходный массив.
        /// При значении индекса, указывающего место вставки столбца, превышающем более, чем на один количество столбцов заданного массива для добавления столбца, возвращается исходный массив
        /// При значении добавляемого массива - столбца, равном "Nothing" возвращается исходный массив.
        /// </remarks>
        public double[,] Array_CollAdd(double[] AddArray, double[,] SourceArrayForAdd, int IndexForCollAdd)
        {
            double[,] ArrayVar = new double[SourceArrayForAdd.GetUpperBound(0) + 1, SourceArrayForAdd.GetUpperBound(1) + 2];
            //Выходной массив, размерностью больше на один столбец заданного массива
            int i = 0;
            int j = 0;
            //Контроль значения индекса заданного столбца
            //Значение индекса столбца более, чем на одну позицию размера заданного массива
            if (IndexForCollAdd > SourceArrayForAdd.GetUpperBound(1) + 1)
            {
                //CollIndexForAdd = SourceArrayForAdd.GetUpperBound(1) + 1 'Приведение индекса к значению больше только на одну позицию размера заданного массива
                return SourceArrayForAdd;
                //При значении индекса вставки столбца, превышающем количество столбцов заданного массива, возвращается исходный массив
                //(можно сделать удаление из заданного массива столбца, соответствующего по модулю заданному отрицательному индексу)
            }
            else if (IndexForCollAdd < 0)
            {
                //CollIndexForAdd = 0
                return SourceArrayForAdd;
                //При отрицательном значении места вставки столбца возвращает исходный массив
            }
            //Контроль существования и размеров вставляемого массива
            //Вставляемый массив не существует
            if (AddArray == null)
            {
                return SourceArrayForAdd;
                //Размер по строкам вставляемого массива больше размера массива для вставки
            }
            else if (AddArray.GetUpperBound(0) > ArrayVar.GetUpperBound(0))
            {
                ArrayVar = new double[AddArray.GetUpperBound(0) + 1, SourceArrayForAdd.GetUpperBound(1) + 2];
            }
            //Вставка нового столбца, имеющего индекс, равный нулю
            if (IndexForCollAdd == 0)
            {
                for (i = 0; i <= SourceArrayForAdd.GetUpperBound(0); i++)
                {
                    for (j = 0; j <= SourceArrayForAdd.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArrayForAdd.GetValue(i, j), i, j + 1);
                        //Копирование значений заданного массива после вставляемого столбца
                    }
                }
                for (i = 0; i <= AddArray.GetUpperBound(0); i++)
                {
                    ArrayVar.SetValue(AddArray.GetValue(i), i, 0);
                    //Копирование значений вставляемого массива в ячейки нулевого столбца
                }
            }
            else
            {
                for (i = 0; i <= SourceArrayForAdd.GetUpperBound(0); i++)
                {
                    for (j = 0; j <= IndexForCollAdd - 1; j++)
                    {
                        ArrayVar.SetValue(SourceArrayForAdd.GetValue(i, j), i, j);
                        //Копирование значений заданного массива до вставляемого столбца
                    }
                }
                for (i = 0; i <= AddArray.GetUpperBound(0); i++)
                {
                    ArrayVar.SetValue(AddArray.GetValue(i), i, IndexForCollAdd);
                    //Копирование значений вставляемого массива в ячейки нулевого столбца
                }
                for (i = 0; i <= SourceArrayForAdd.GetUpperBound(0); i++)
                {
                    for (j = IndexForCollAdd; j <= SourceArrayForAdd.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArrayForAdd.GetValue(i, j), i, j + 1);
                        //Копирование значений заданного массива после вставляемого столбца
                    }
                }
            }
            return ArrayVar;
        }

        /// <summary>
        /// Возвращает двумерный массив, увеличенный на несколько столбцов (заданных массивом), место вставки которых задано индексом
        /// </summary>
        /// <param name="AddArray">Добавляемый массив</param>
        /// <param name="SourceArrayForAdd">Заданный массив для добавления столбцов</param>
        /// <param name="IndexForAddFirstColl">Индекс, определяющий место вставки первого столбца добавляемого массива</param>
        /// <returns>Возвращает двумерный массив As Double</returns>
        /// <remarks>
        /// Значения ячеек вставляемого столбца равны нулю.
        /// Содержимое заданного массива в возвращаемом масссиве сохраняется.
        /// Индекс заданного столбца соответсвует нумерации столбцов массива, т.е. начинается с нуля.
        /// При отрицательном значении индекса, указывающего место вставки первого столбца, возвращается исходный массив.
        /// При значении индекса, указывающего место вставки первого столбца, превышающем более, чем на один количество столбцов заданного массива для добавления столбцов, возвращается исходный массив
        /// При значении добавляемого массива, равном "Nothing" возвращается исходный массив.
        /// </remarks>
        public double[,] Array_CollAdd(double[,] AddArray, double[,] SourceArrayForAdd, int IndexForAddFirstColl)
        {
            double[,] ArrayVar = null;
            //Выходной массив
            int i = 0;
            int j = 0;
            //Контроль значения индекса заданного столбца
            //Значение индекса столбца более, чем на одну позицию размера заданного массива
            if (IndexForAddFirstColl > SourceArrayForAdd.GetUpperBound(1) + 1)
            {
                //CollIndexForAdd = SourceArrayForAdd.GetUpperBound(1) + 1 'Приведение индекса к значению больше только на одну позицию размера заданного массива
                return SourceArrayForAdd;
                //При значении индекса вставки столбца, превышающем количество столбцов заданного массива для вставки столбцов, возвращается исходный массив
                //(можно сделать удаление из заданного массива столбца, соответствующего по модулю заданному отрицательному индексу)
            }
            else if (IndexForAddFirstColl < 0)
            {
                //CollIndexForAdd = 0
                return SourceArrayForAdd;
                //При отрицательном значении места вставки первого столбца возвращает исходный массив
            }
            //Контроль существования и размеров вставляемого массива
            //Вставляемый массив не существует
            if (AddArray == null)
            {
                return SourceArrayForAdd;
                //Размер по строкам вставляемого массива больше размера массива для вставки
            }
            else if (AddArray.GetUpperBound(0) > SourceArrayForAdd.GetUpperBound(0))
            {
                ArrayVar = new double[AddArray.GetUpperBound(0) + 1, SourceArrayForAdd.GetUpperBound(1) + AddArray.GetUpperBound(1) + 2];
            }
            else
            {
                ArrayVar = new double[SourceArrayForAdd.GetUpperBound(0) + 1, SourceArrayForAdd.GetUpperBound(1) + AddArray.GetUpperBound(1) + 2];
                //Задание выходного массива, размерностью больше на вставляемоее количество столбцов заданного массива
            }
            //Вставка новых столбцов, начиная с индекса, равного нулю
            if (IndexForAddFirstColl == 0)
            {
                //Копирование столбцов вставляемого массива в столбцы заданного массива, начиная с нулевого столбца
                for (i = 0; i <= AddArray.GetUpperBound(0); i++)
                {
                    for (j = 0; j <= AddArray.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(AddArray.GetValue(i, j), i, j);
                    }
                }
                //Копирование столбцов заданного массива после вставленных столбцов
                for (i = 0; i <= SourceArrayForAdd.GetUpperBound(0); i++)
                {
                    for (j = 0; j <= SourceArrayForAdd.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArrayForAdd.GetValue(i, j), i, j + AddArray.GetUpperBound(1) + 1);
                    }
                }
            }
            else
            {
                //Копирование значений заданного массива до вставляемого столбца
                for (i = 0; i <= SourceArrayForAdd.GetUpperBound(0); i++)
                {
                    for (j = 0; j <= IndexForAddFirstColl - 1; j++)
                    {
                        ArrayVar.SetValue(SourceArrayForAdd.GetValue(i, j), i, j);
                    }
                }
                //Копирование значений вставляемого массива в ячейки нулевого столбца
                for (i = 0; i <= AddArray.GetUpperBound(0); i++)
                {
                    for (j = 0; j <= AddArray.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(AddArray.GetValue(i, j), i, j + (IndexForAddFirstColl));
                    }
                }
                //Копирование значений заданного массива после вставляемого столбца
                for (i = 0; i <= SourceArrayForAdd.GetUpperBound(0); i++)
                {
                    for (j = IndexForAddFirstColl; j <= SourceArrayForAdd.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArrayForAdd.GetValue(i, j), i, j + AddArray.GetUpperBound(1) + 1);
                    }
                }
            }
            return ArrayVar;
        }

        /// <summary>
        /// Возвращает двумерный массив, в котором заменен один столбец, заданный индексом
        /// </summary>
        /// <param name="СhangeArray">Массив - столбец для замены столбца</param>
        /// <param name="SourceArrayForСhange">Заданный массив, в котором заменяется столбец </param>
        /// <param name="IndexOfChangeColl">Индекс, определяющий заменяемый столбец заданного массива</param>
        /// <returns>Возвращает двумерный массив As Double</returns>
        /// <remarks>
        /// Индекс заданного столбца соответсвует нумерации столбцов массива, т.е. начинается с нуля.
        /// При отрицательном значении индекса, указывающего заменяемый столбец, возвращается исходный массив.
        /// При значении индекса, указывающего заменяемый столбец, превышающем количество столбцов заданного массива для замены столбца, возвращается исходный массив
        /// При значении заменяемого массива - столбца, равном "Nothing" возвращается исходный массив.
        /// </remarks>
        public double[,] Array_CollСhange(double[] СhangeArray, double[,] SourceArrayForСhange, int IndexOfChangeColl)
        {
            int i = 0;
            int j = 0;
            //Контроль значения индекса заданного столбца
            //Значение индекса столбца более, чем на одну позицию размера заданного массива
            if (IndexOfChangeColl > SourceArrayForСhange.GetUpperBound(1))
            {
                //CollIndexForAdd = SourceArrayForAdd.GetUpperBound(1) + 1 'Приведение индекса к значению больше только на одну позицию размера заданного массива
                return SourceArrayForСhange;
                //При значении индекса замены столбца, превышающем количество столбцов заданного массива, возвращается исходный массив
                //(можно сделать удаление из заданного массива столбца, соответствующего по модулю заданному отрицательному индексу)
            }
            else if (IndexOfChangeColl < 0)
            {
                //CollIndexForAdd = 0
                return SourceArrayForСhange;
                //При отрицательном значении места замены столбца возвращает исходный массив
            }
            //Контроль существования и размеров вставляемого массива
            //Вставляемый массив не существует
            if (СhangeArray == null)
            {
                return SourceArrayForСhange;
                //Размер по строкам заменяемого массива больше размера массива для замены столбца
            }
            else if (СhangeArray.GetUpperBound(0) > SourceArrayForСhange.GetUpperBound(0))
            {
                return SourceArrayForСhange;
            }
            //3. Замена значений указанного столбца заданного массива значениями нового массива
            for (i = 0; i <= СhangeArray.GetUpperBound(0); i++)
            {
                SourceArrayForСhange.SetValue(СhangeArray.GetValue(i), i, IndexOfChangeColl);
            }
            return SourceArrayForСhange;
        }

        /// <summary>
        /// Возвращает двумерный массив, в котором заменено несколько столбцов (заданных массивом)
        /// </summary>
        /// <param name="СhangeArray">Массив, содержащий столбцы для замены</param>
        /// <param name="SourceArrayForСhange">Заданный массив для замены столбцов</param>
        /// <param name="IndexFirstChangeColl">Индекс, определяющий первый заменяемый столбец заданного массива</param>
        /// <returns>Возвращает двумерный массив As Double</returns>
        /// <remarks>
        /// Индекс заданного столбца соответсвует нумерации столбцов массива, т.е. начинается с нуля.
        /// При отрицательном значении индекса, указывающего первый заменяемый столбец, возвращается исходный массив.
        /// При значении индекса, указывающего первый заменяемый столбец, превышающем количество столбцов заданного массива для замены столбцов, возвращается исходный массив
        /// При значении количества столбцов массива с новыми столбцами превышающем количество столбцов заданного массива для изменения возвращается исходный массив.
        /// При невозможности заменить все столбцы массива, содержащего столбцы для замены, возвращается исходный массив.
        /// При значении добавляемого массива, равном "Nothing" возвращается исходный массив.
        /// </remarks>
        public double[,] Array_CollСhange(double[,] СhangeArray, double[,] SourceArrayForСhange, int IndexFirstChangeColl)
        {
            int i = 0;
            int j = 0;
            //Контроль значения индекса заданного столбца
            //Значение индекса столбца более, чем на одну позицию размера заданного массива
            if (IndexFirstChangeColl > SourceArrayForСhange.GetUpperBound(1))
            {
                //CollIndexForAdd = SourceArrayForСhange.GetUpperBound(1) + 1 'Приведение индекса к значению больше только на одну позицию размера заданного массива
                return SourceArrayForСhange;
                //При значении индекса замены столбца, превышающем количество столбцов заданного массива, возвращается исходный массив
                //(можно сделать удаление из заданного массива столбца, соответствующего по модулю заданному отрицательному индексу)
            }
            else if (IndexFirstChangeColl < 0)
            {
                //CollIndexForAdd = 0
                return SourceArrayForСhange;
                //При отрицательном значении места замены столбца возвращает исходный массив
            }
            //Контроль существования и размеров вставляемого массива
            //Вставляемый массив не существует
            if (СhangeArray == null)
            {
                return SourceArrayForСhange;
                //Размер по строкам заменяемого массива больше размера массива для замены столбца
            }
            else if (СhangeArray.GetUpperBound(0) > SourceArrayForСhange.GetUpperBound(0))
            {
                return SourceArrayForСhange;
                //Количество столбцов массива с новыми столбцами превышает количество столбцов заданного массива для изменения
            }
            else if (СhangeArray.GetUpperBound(1) > SourceArrayForСhange.GetUpperBound(1))
            {
                return SourceArrayForСhange;
                //Количество столбцов массива с новыми столбцами меньше количества столбцов заданного массива для изменения,
            }
            else if (IndexFirstChangeColl + СhangeArray.GetUpperBound(1) > SourceArrayForСhange.GetUpperBound(1))
            {
                //но индекс замены первого столбца не позволяет выполнить замену всех столбцов массива СhangeArray
                return SourceArrayForСhange;
            }
            //3. Замена значений указанного столбца заданного массива значениями нового массива
            for (i = 0; i <= СhangeArray.GetUpperBound(0); i++)
            {
                for (j = 0; j <= СhangeArray.GetUpperBound(1); j++)
                {
                    SourceArrayForСhange.SetValue(СhangeArray.GetValue(i, j), i, j + IndexFirstChangeColl);
                    //
                }
            }
            return SourceArrayForСhange;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------
        //==============================================================================================================================================================
        //------------------------------------------------- Вставка и замена строк в заданный массив (As Double) -------------------------------------------------------

        /// <summary>
        /// Возвращает двумерный массив, увеличенный на одну строку, место вставки которого задано индексом
        /// </summary>
        /// <param name="IndexAddRow">Индекс вставляемого строки (последующие сдвигаютсяя на одну позицию вниз)</param>
        /// <param name="SourceArray">Заданный массив для добавления строки</param>
        /// <returns>Возвращает двумерный массив As Double</returns>
        /// <remarks>
        /// Значения ячеек вставляемой строки равны нулю.
        /// Содержимое заданной массива в возвращаемом масссиве сохраняется.
        /// Индекс заданной строки соответсвует нумерации строк массива, т.е. начинается с нуля.
        /// При значении индекса заданной строки, превышающем более, чем на одну количество строк заданного массива, возвращается исходный массив.
        /// При отрицательном значении индекса вставляемой строки возвращается исходный массив.
        /// </remarks>
        public double[,] Array_RowAdd(int IndexAddRow, double[,] SourceArray)
        {
            double[,] ArrayVar = new double[SourceArray.GetUpperBound(0) + 2, SourceArray.GetUpperBound(1) + 1];
            //Выходной массив, размерностью больше на одну строку заданного массива
            int i = 0;
            int j = 0;
            //Контроль значения индекса заданной строки
            //Значение индекса строки более, чем на одну позицию размера заданного массива
            if (IndexAddRow > SourceArray.GetUpperBound(0) + 1)
            {
                //IndexAddRow = SourceArray.GetUpperBound(0) + 1 'Приведение индекса к значению больше только на одну позицию размера заданного массива
                return SourceArray;
                //При значении индекса заданной строки, превышающем количество строк заданного массива, возвращается исходный массив
                //(можно сделать удаление из заданного массива строк, соответствующего по модулю заданному отрицательному индексу)
            }
            else if (IndexAddRow < 0)
            {
                //IndexAddRow = 0
                return SourceArray;
                //При отрицательном значении места вставки возвращает исходный массив
            }
            //Вставка новой строки, имеющей индекс, равный нулю
            if (IndexAddRow == 0)
            {
                //Копирование значений заданного массива до вставляемой строки
                for (i = 0; i <= SourceArray.GetUpperBound(0); i++)
                {
                    for (j = 0; j <= SourceArray.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArray.GetValue(i, j), i + 1, j);
                    }
                }
            }
            else
            {
                //Копирование значений заданного массива до вставляемой строки
                for (i = 0; i <= IndexAddRow - 1; i++)
                {
                    for (j = 0; j <= SourceArray.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArray.GetValue(i, j), i, j);
                    }
                }
                //Копирование значений заданного массива после вставляемой строки
                for (i = IndexAddRow; i <= SourceArray.GetUpperBound(0); i++)
                {
                    for (j = 0; j <= SourceArray.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArray.GetValue(i, j), i + 1, j);
                    }
                }
            }
            return ArrayVar;
        }

        /// <summary>
        /// Возвращает двумерный массив, увеличенный на несколько строк, начальное место вставки которых задано индексом
        /// </summary>
        /// <param name="CountRows">Количество вставляемых строк (последующие сдвигаются вниз)</param>
        /// <param name="SourceArray">Заданный массив для добавления строк</param>
        /// <param name="IndexForAddFirstRow">Индекс, указывающий место вставки первой строки</param>
        /// <returns>Возвращает двумерный массив As Double</returns>
        /// <remarks>
        /// Значения ячеек вставляемых строк равны нулю.
        /// Содержимое заданного массива в возвращаемом масссиве сохраняется.
        /// Индекс заданной строки соответсвует нумерации строк массива, т.е. начинается с нуля.
        /// При отрицательном значении индекса, указывающего место вставки первой строки, возвращается исходный массив.
        /// При значении индекса, указывающего место вставки первой строки, превышающем более, чем на одну количество строк заданного массива, возвращается исходный массив.
        /// При отрицательном значении количества вставляемых строк возвращается исходный массив.
        /// </remarks>
        public double[,] Array_RowAdd(int CountRows, double[,] SourceArray, int IndexForAddFirstRow)
        {
            double[,] ArrayVar = new double[SourceArray.GetUpperBound(0) + CountRows + 1, SourceArray.GetUpperBound(1) + 1];
            //Выходной массив, размерностью больше заданного массива на заданное количество вставляемых строк
            int i = 0;
            int j = 0;
            //Контроль значения индекса заданной строки
            //Значение индекса строки более, чем на одну позицию размера заданного массива
            if (IndexForAddFirstRow > SourceArray.GetUpperBound(0) + 1)
            {
                //IndexForAddFirstRow = SourceArray.GetUpperBound(0) + 1 'Приведение индекса к значению больше размера заданного массива на заданное количество строк
                return SourceArray;
                //При значении индекса вставки строки, превышающем количество строк заданного массива, возвращается исходный массив
                //При отрицательном значении места вставки первой строки возвращает исходный массив
            }
            else if (IndexForAddFirstRow < 0)
            {
                //IndexForAddFirstRow = 0
                return SourceArray;
            }
            //Контроль задания количества вставляемых строк (можно сделать удаление из заданного массива строк, количество которых соответсвует заданному отрицательному числу)
            if (CountRows < 0)
            {
                return SourceArray;
            }
            //Вставка новой строки, имеющей индекс, равный нулю
            if (IndexForAddFirstRow == 0)
            {
                //Копирование значений заданного массива после вставляемых строк
                for (i = 0; i <= SourceArray.GetUpperBound(0); i++)
                {
                    for (j = 0; j <= SourceArray.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArray.GetValue(i, j), i + CountRows, j);
                    }
                }
            }
            else
            {
                //Копирование значений заданного массива до вставляемых строк
                for (i = 0; i <= IndexForAddFirstRow - 1; i++)
                {
                    for (j = 0; j <= SourceArray.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArray.GetValue(i, j), i, j);
                    }
                }
                //Копирование значений заданного массива после вставляемых строк
                for (i = IndexForAddFirstRow; i <= SourceArray.GetUpperBound(0); i++)
                {
                    for (j = 0; j <= SourceArray.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArray.GetValue(i, j), i + CountRows, j);
                    }
                }
            }
            return ArrayVar;
        }

        /// <summary>
        /// Возвращает двумерный массив, увеличенный на одну строку, место вставки которой задано индексом
        /// </summary>
        /// <param name="AddArray">Добавляемый массив - строка</param>
        /// <param name="SourceArrayForAdd">Заданный массив для добавления строки</param>
        /// <param name="IndexForRowAdd">Индекс, определяющий место вставки заданного массива - строки</param>
        /// <returns>Возвращает двумерный массив As Double</returns>
        /// <remarks>
        /// Содержимое заданного массива в возвращаемом масссиве сохраняется.
        /// Индекс заданной строки соответсвует нумерации строк массива, т.е. начинается с нуля.
        /// При отрицательном значении индекса, указывающего место вставки строки, возвращается исходный массив.
        /// При значении индекса, указывающего место вставки строки, превышающем более, чем на одну количество строк заданного массива для добавления строки, возвращается исходный массив
        /// При значении добавляемого массива - строки, равном "Nothing" возвращается исходный массив.
        /// </remarks>
        public double[,] Array_RowAdd(double[] AddArray, double[,] SourceArrayForAdd, int IndexForRowAdd)
        {
            double[,] ArrayVar = new double[SourceArrayForAdd.GetUpperBound(0) + 2, SourceArrayForAdd.GetUpperBound(1) + 1];
            //Выходной массив, размерностью больше на одну строку заданного массива
            int i = 0;
            int j = 0;
            //Контроль значения индекса заданноq строки
            //Значение индекса строки более, чем на одну позицию размера заданного массива
            if (IndexForRowAdd > SourceArrayForAdd.GetUpperBound(0) + 1)
            {
                //IndexForRowAdd = SourceArrayForAdd.GetUpperBound(0) + 1 'Приведение индекса к значению больше только на одну позицию размера заданного массива
                return SourceArrayForAdd;
                //При значении индекса вставки строки, превышающем количество строк заданного массива, возвращается исходный массив
                //(можно сделать удаление из заданного массива строки, соответствующеq по модулю заданному отрицательному индексу)
            }
            else if (IndexForRowAdd < 0)
            {
                //IndexForRowAdd = 0
                return SourceArrayForAdd;
                //При отрицательном значении места вставки строки возвращает исходный массив
            }
            //Контроль существования и размеров вставляемого массива
            //Вставляемый массив не существует
            if (AddArray == null)
            {
                return SourceArrayForAdd;
                //Размер по столбцам вставляемого массива больше размера массива для вставки
            }
            else if (AddArray.GetUpperBound(0) > ArrayVar.GetUpperBound(1))
            {
                ArrayVar = new double[SourceArrayForAdd.GetUpperBound(0) + 2, AddArray.GetUpperBound(0) + 1];
            }
            //Вставка новой строки, имеющей индекс, равный нулю
            if (IndexForRowAdd == 0)
            {
                for (i = 0; i <= SourceArrayForAdd.GetUpperBound(0); i++)
                {
                    for (j = 0; j <= SourceArrayForAdd.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArrayForAdd.GetValue(i, j), i + 1, j);
                        //Копирование значений заданного массива после вставляемой строки
                    }
                }
                for (j = 0; j <= AddArray.GetUpperBound(0); j++)
                {
                    ArrayVar.SetValue(AddArray.GetValue(j), 0, j);
                    //Копирование значений вставляемого массива в ячейки нулевой строки
                }
            }
            else
            {
                for (i = 0; i <= IndexForRowAdd - 1; i++)
                {
                    for (j = 0; j <= SourceArrayForAdd.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArrayForAdd.GetValue(i, j), i, j);
                        //Копирование значений заданного массива до вставляемой строки
                    }
                }
                for (j = 0; j <= AddArray.GetUpperBound(0); j++)
                {
                    ArrayVar.SetValue(AddArray.GetValue(j), IndexForRowAdd, j);
                    //Копирование значений вставляемого массива в ячейки нулевой строки
                }
                for (i = IndexForRowAdd; i <= SourceArrayForAdd.GetUpperBound(0); i++)
                {
                    for (j = 0; j <= SourceArrayForAdd.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArrayForAdd.GetValue(i, j), i + 1, j);
                        //Копирование значений заданного массива после вставляемой строки
                    }
                }
            }
            return ArrayVar;
        }

        /// <summary>
        /// Возвращает двумерный массив, увеличенный на несколько строк (заданных массивом), место вставки которых задано индексом
        /// </summary>
        /// <param name="AddArray">Добавляемый массив</param>
        /// <param name="SourceArrayForAdd">Заданный массив для добавления строк</param>
        /// <param name="IndexForAddFirstRow">Индекс, определяющий место вставки первой строки добавляемого массива</param>
        /// <returns>Возвращает двумерный массив As Double</returns>
        /// <remarks>
        /// Содержимое заданного массива в возвращаемом масссиве сохраняется.
        /// Индекс заданной строки соответсвует нумерации строк массива, т.е. начинается с нуля.
        /// При отрицательном значении индекса, указывающего место вставки первой строки, возвращается исходный массив.
        /// При значении индекса, указывающего место вставки первой строки, превышающем более, чем на одну количество строк заданного массива для добавления строк, возвращается исходный массив
        /// При значении добавляемого массива, равном "Nothing" возвращается исходный массив.
        /// </remarks>
        public double[,] Array_RowAdd(double[,] AddArray, double[,] SourceArrayForAdd, int IndexForAddFirstRow)
        {
            double[,] ArrayVar = null;
            //Выходной массив
            int i = 0;
            int j = 0;
            //Контроль значения индекса заданной строки
            //Значение индекса строки более, чем на одну позицию размера заданного массива
            if (IndexForAddFirstRow > SourceArrayForAdd.GetUpperBound(0) + 1)
            {
                //IndexForAddFirstRow = SourceArrayForAdd.GetUpperBound(0) + 1 'Приведение индекса к значению больше только на одну позицию размера заданного массива
                return SourceArrayForAdd;
                //При значении индекса вставки строки, превышающем количество строк заданного массива для вставки строк, возвращается исходный массив
                //(можно сделать удаление из заданного массива строк, соответствующего по модулю заданному отрицательному индексу)
            }
            else if (IndexForAddFirstRow < 0)
            {
                //IndexForAddFirstRow = 0
                return SourceArrayForAdd;
                //При отрицательном значении места вставки первой строки возвращает исходный массив
            }
            //Контроль существования и размеров вставляемого массива
            //Вставляемый массив не существует
            if (AddArray == null)
            {
                return SourceArrayForAdd;
                //Размер по столбцам вставляемого массива больше размера массива для вставки
            }
            else if (AddArray.GetUpperBound(1) > SourceArrayForAdd.GetUpperBound(1))
            {
                ArrayVar = new double[SourceArrayForAdd.GetUpperBound(0) + AddArray.GetUpperBound(0) + 2, AddArray.GetUpperBound(1) + 1];
            }
            else
            {
                ArrayVar = new double[SourceArrayForAdd.GetUpperBound(0) + AddArray.GetUpperBound(0) + 2, SourceArrayForAdd.GetUpperBound(1) + 1];
                //Задание выходного массива, размерностью больше на вставляемоее количество строк заданного массива
            }
            //Вставка новых строк, начиная с индекса, равного нулю
            if (IndexForAddFirstRow == 0)
            {
                //Копирование строк вставляемого массива в строки заданного массива, начиная с нулевой строки
                for (i = 0; i <= AddArray.GetUpperBound(0); i++)
                {
                    for (j = 0; j <= AddArray.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(AddArray.GetValue(i, j), i, j);
                    }
                }
                //Копирование строк заданного массива после вставленных строк
                for (i = 0; i <= SourceArrayForAdd.GetUpperBound(0); i++)
                {
                    for (j = 0; j <= SourceArrayForAdd.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArrayForAdd.GetValue(i, j), i + AddArray.GetUpperBound(0) + 1, j);
                    }
                }
            }
            else
            {
                //Копирование значений заданного массива до вставляемой строки
                for (i = 0; i <= IndexForAddFirstRow - 1; i++)
                {
                    for (j = 0; j <= SourceArrayForAdd.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArrayForAdd.GetValue(i, j), i, j);
                    }
                }
                //Копирование значений вставляемого массива в ячейки нулевой строки
                for (i = 0; i <= AddArray.GetUpperBound(0); i++)
                {
                    for (j = 0; j <= AddArray.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(AddArray.GetValue(i, j), i + IndexForAddFirstRow, j);
                    }
                }
                //Копирование значений заданного массива после вставляемой строки
                for (i = IndexForAddFirstRow; i <= SourceArrayForAdd.GetUpperBound(0); i++)
                {
                    for (j = 0; j <= SourceArrayForAdd.GetUpperBound(1); j++)
                    {
                        ArrayVar.SetValue(SourceArrayForAdd.GetValue(i, j), i + AddArray.GetUpperBound(0) + 1, j);
                    }
                }
            }
            return ArrayVar;
        }

        /// <summary>
        /// Возвращает двумерный массив, в котором заменена одна строка, заданный индексом
        /// </summary>
        /// <param name="СhangeArray">Массив значений заменяемой строки</param>
        /// <param name="SourceArrayForAdd">Заданный массив, в котором заменяется строка </param>
        /// <param name="IndexOfChangeRow">Индекс, определяющий заменяемую строку заданного массива</param>
        /// <returns>Возвращает двумерный массив As Double</returns>
        /// <remarks>
        /// Индекс заданной строки соответсвует нумерации строк массива, т.е. начинается с нуля.
        /// При отрицательном значении индекса, указывающего заменяемую строку, возвращается исходный массив.
        /// При значении индекса, указывающего заменяемую строку, превышающем количество строк заданного массива для замены строк, возвращается исходный массив
        /// При значении заменяемого массива значений заменяемой строки, равном "Nothing" возвращается исходный массив.
        /// </remarks>
        public double[,] Array_RowСhange(double[] СhangeArray, double[,] SourceArrayForAdd, int IndexOfChangeRow)
        {
            int i = 0;
            int j = 0;
            //Контроль значения индекса заданной строки
            //Значение индекса строки более, чем на одну позицию размера заданного массива
            if (IndexOfChangeRow > SourceArrayForAdd.GetUpperBound(0))
            {
                //IndexOfChangeRow = SourceArrayForAdd.GetUpperBound(0) + 1 'Приведение индекса к значению больше только на одну позицию размера заданного массива
                return SourceArrayForAdd;
                //При значении индекса замены строки, превышающем количество строки заданного массива, возвращается исходный массив
                //(можно сделать удаление из заданного массива строки, соответствующего по модулю заданному отрицательному индексу)
            }
            else if (IndexOfChangeRow < 0)
            {
                //IndexOfChangeRow = 0
                return SourceArrayForAdd;
                //При отрицательном значении места замены строки возвращает исходный массив
            }
            //Контроль существования и размеров вставляемого массива
            //Вставляемый массив не существует
            if (СhangeArray == null)
            {
                return SourceArrayForAdd;
                //Размер по столбцам заменяемого массива больше размера массива для замены строки
            }
            else if (СhangeArray.GetUpperBound(0) > SourceArrayForAdd.GetUpperBound(1))
            {
                return SourceArrayForAdd;
            }
            //3. Замена значений указанной строки заданного массива значениями нового массива
            for (j = 0; j <= СhangeArray.GetUpperBound(0); j++)
            {
                SourceArrayForAdd.SetValue(СhangeArray.GetValue(j), IndexOfChangeRow, j);
            }
            return SourceArrayForAdd;
        }

        /// <summary>
        /// Возвращает двумерный массив, в котором заменено несколько строк (заданных массивом)
        /// </summary>
        /// <param name="СhangeArray">Массив, содержащий строки для замены</param>
        /// <param name="SourceArrayForAdd">Заданный массив для замены строк</param>
        /// <param name="IndexFirstChangeRow">Индекс, определяющий первую заменяемую строку заданного массива</param>
        /// <returns>Возвращает двумерный массив As Double</returns>
        /// <remarks>
        /// Индекс заданной строки соответсвует нумерации строк массива, т.е. начинается с нуля.
        /// При отрицательном значении индекса, указывающего первую заменяемую строку, возвращается исходный массив.
        /// При значении индекса, указывающего первую заменяемую строку, превышающем количество строк заданного массива для замены строк, возвращается исходный массив
        /// При значении количества строк массива с новыми строками превышающем количество строк заданного массива для изменения возвращается исходный массив.
        /// При невозможности заменить все строки массива, содержащего строки для замены, возвращается исходный массив.
        /// При значении добавляемого массива, равном "Nothing" возвращается исходный массив.
        /// </remarks>
        public double[,] Array_RowСhange(double[,] СhangeArray, double[,] SourceArrayForAdd, int IndexFirstChangeRow)
        {
            double[,] functionReturnValue = null;
            int i = 0;
            int j = 0;
            //Контроль значения индекса заданной строки
            //Значение индекса строки более, чем на одну позицию размера заданного массива
            if (IndexFirstChangeRow > SourceArrayForAdd.GetUpperBound(0))
            {
                //IndexFirstChangeRow = SourceArrayForAdd.GetUpperBound(0) + 1 'Приведение индекса к значению больше только на одну позицию размера заданного массива
                return SourceArrayForAdd;
                //При значении индекса замены строки, превышающем количество строк заданного массива, возвращается исходный массив
                //(можно сделать удаление из заданного массива строк, соответствующего по модулю заданному отрицательному индексу)
            }
            else if (IndexFirstChangeRow < 0)
            {
                //IndexFirstChangeRow = 0
                return SourceArrayForAdd;
                //При отрицательном значении места замены строки возвращается исходный массив
            }
            //Контроль существования и размеров вставляемого массива
            //Вставляемый массив не существует
            if (СhangeArray == null)
            {
                return SourceArrayForAdd;
                //Размер по строкам заменяемого массива больше размера массива для замены строк
            }
            else if (СhangeArray.GetUpperBound(0) > SourceArrayForAdd.GetUpperBound(0))
            {
                return SourceArrayForAdd;
                //Количество столбцов массива с новыми строками превышает количество столбцов заданного массива для изменения
            }
            else if (СhangeArray.GetUpperBound(1) > SourceArrayForAdd.GetUpperBound(1))
            {
                return SourceArrayForAdd;
                //Количество строк массива с новыми строками меньше количества строк заданного массива для изменения,
            }
            else if (IndexFirstChangeRow + СhangeArray.GetUpperBound(0) > SourceArrayForAdd.GetUpperBound(0))
            {
                //но индекс замены первой строки не позволяет выполнить замену всех строк массива СhangeArray
                return SourceArrayForAdd;
            }
            //3. Замена значений указанной строки заданного массива значениями нового массива
            for (i = 0; i <= СhangeArray.GetUpperBound(0); i++)
            {
                for (j = 0; j <= СhangeArray.GetUpperBound(1); j++)
                {
                    SourceArrayForAdd.SetValue(СhangeArray.GetValue(i, j), i + IndexFirstChangeRow, j);
                    //
                }
            }
            return SourceArrayForAdd;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

    }

}
