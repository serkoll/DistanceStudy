using System;
using Microsoft.VisualBasic;


namespace GeometryObjects
{
    /// <summary>Класс функций решения систем уравнений</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2014</remarks>
    public class EqSysCalculation
    {
        public double[] KramerEquationsSolution(double[,] MatrixEquationsKoeff)
        {
            //Функция возвращает решение трех уравнений первой степени с тремя неизвестными по методу Крамера
            //Уравнения вида: ax+by+cz+d=0
            double[,] MrxDetEq = new double[3, 3];
            //Матрица определителя 
            double[,] MrxDetX = new double[3, 3];
            double[,] MrxDetY = new double[3, 3];
            double[,] MrxDetZ = new double[3, 3];
            //Матрицы коэффициентов неизвестных
            MatrixEvalution MrxVar = new MatrixEvalution();
            //Переменная для расчета определителя и ранга матриц
            double[] MrxSolution = new double[3];
            int i = 0;
            int j = 0;
            //Переменные цикла
            //Контроль размерности заданной матрицы
            if (MatrixEquationsKoeff.GetUpperBound(0) != 2 | MatrixEquationsKoeff.GetUpperBound(1) != 3)
            {
                //Система не удовлетворяет условиям решения
                Interaction.MsgBox("Исходные данные не удовлетворяют условиям решения" + Constants.vbCrLf + "Правильно задайте матрицу исходных данных", MsgBoxStyle.Exclamation, "Функция решения системы из трех уравнений по методу Крамера");

                //=======!!!!!!!!!!!! Вернуть ошибку !!!!!!!!!!!!!==================

                return null;
                //Вернуть ошибку!!!!!
            }
            //Заполнение матрицы определителя коэффициентов системы уравнений
            for (i = 0; i <= MrxDetEq.GetUpperBound(0); i++)
            {
                for (j = 0; j <= MrxDetEq.GetUpperBound(1); j++)
                {
                    MrxDetEq.SetValue(MatrixEquationsKoeff.GetValue(i, j), i, j);
                }
            }
            if (MrxVar.detMrx3x3(MrxDetEq) == 0)
            {
                Interaction.MsgBox("Определитель матрицы коэффициентов системы заданных уравнений равен нулю." + Constants.vbCrLf + "Система заданных уравнений не имеет одного определенного решения.", MsgBoxStyle.Exclamation, "Функция решения системы из трех уравнений по методу Крамера");

                //=======!!!!!!!!!!!! Вернуть ошибку !!!!!!!!!!!!!==================

                //MrxSolution.SetValue(1 / 0, 0);???
                //MrxSolution.SetValue(1 / 0, 1);???
                //MrxSolution.SetValue(1 / 0, 2);???
                return MrxSolution;
                //Вернуть ошибку!!!!!
            }
            //Заполнение матрицы коэффициентов неизвестного X
            //Заполнение 1-го столбца
            for (i = 0; i <= MrxDetX.GetUpperBound(0); i++)
            {
                MrxDetX.SetValue(-(double)MatrixEquationsKoeff.GetValue(i, 3), i, 0);
            }
            //Заполнение остальных столбцов
            for (i = 0; i <= MrxDetX.GetUpperBound(0); i++)
            {
                for (j = 1; j <= MrxDetX.GetUpperBound(1); j++)
                {
                    MrxDetX.SetValue(MatrixEquationsKoeff.GetValue(i, j), i, j);
                }
            }
            //Заполнение матрицы коэффициентов неизвестного Y
            //Заполнение 1-го столбца
            for (i = 0; i <= MrxDetY.GetUpperBound(0); i++)
            {
                MrxDetY.SetValue(MatrixEquationsKoeff.GetValue(i, 0), i, 0);
            }
            //Заполнение 2-го столбца
            for (i = 0; i <= MrxDetY.GetUpperBound(0); i++)
            {
                MrxDetY.SetValue(-(double)MatrixEquationsKoeff.GetValue(i, 3), i, 1);
            }
            //Заполнение 3-го столбца
            for (i = 0; i <= MrxDetY.GetUpperBound(0); i++)
            {
                MrxDetY.SetValue(MatrixEquationsKoeff.GetValue(i, 2), i, 2);
            }
            //Заполнение матрицы коэффициентов неизвестного Z
            //Заполнение первых двух столбцов
            for (i = 0; i <= MrxDetZ.GetUpperBound(0); i++)
            {
                for (j = 0; j <= MrxDetZ.GetUpperBound(1) - 1; j++)
                {
                    MrxDetZ.SetValue(MatrixEquationsKoeff.GetValue(i, j), i, j);
                }
            }
            //Заполнение 3-го столбца
            for (i = 0; i <= MrxDetZ.GetUpperBound(0); i++)
            {
                MrxDetZ.SetValue(-(double)MatrixEquationsKoeff.GetValue(i, 3), i, 2);
            }
            //Расчет неизвестных X, Y, Z
            MrxSolution.SetValue(MrxVar.detMrx3x3(MrxDetX) / MrxVar.detMrx3x3(MrxDetEq), 0);
            MrxSolution.SetValue(MrxVar.detMrx3x3(MrxDetY) / MrxVar.detMrx3x3(MrxDetEq), 1);
            MrxSolution.SetValue(MrxVar.detMrx3x3(MrxDetZ) / MrxVar.detMrx3x3(MrxDetEq), 2);
            return MrxSolution;
        }

        //Public Overloads Function KramerEquationsSolution(ByVal MatrixEquationsKoeff(,) As Double, ByVal MatrixFreeKoeff() As Double) As Double()
        //    'Функция возвращает решение трех уравнений первой степени с тремя неизвестными по методу Крамера
        //End Function

        //Public Overloads Function KramerEquationsSolution(ByVal Equations1 As Double, ByVal Equations2 As Double, ByVal Equations3 As Double) As Double()
        //    'Функция возвращает решение трех уравнений первой степени с тремя неизвестными по методу Крамера
        //End Function

        public double[] SLU_GaussSolve(double[,] a_matrix, double[] b_vector, double ErrorSluSolve)
        {
            //Функция решения системы линейных уравнений по методу Гаусса
            //a_matrix - матрица коэффициентов при неизвестных
            //b_vector - матрица-столбец свободных коэффициентов
            //Уравнения вида:
            //a11x1 + a12x2 + a13x3 + ... a1NxN = b1 
            //a21x1 + a22x2 + a23x3 + ... a2NxN = b2 
            //a31x1 + a32x2 + a33x3 + ... a3NxN = b3 
            //... 
            //aN1x1 + aN2x2 + aN3x3 + ... aNNxN = bN 
            SluGaussSolve SLU_Matr = new SluGaussSolve(a_matrix, b_vector, ErrorSluSolve);
            //Экземпляр класса SluGaussSolve
            double[] SysSolve = null;
            //Матрица-столбец выходных данных (неизвестных Xi)
            SysSolve = new double[SLU_Matr.XVector.GetUpperBound(0) + 1];
            SysSolve = SLU_Matr.XVector;
            Array.Resize(ref SysSolve, SysSolve.GetUpperBound(0));
            return SysSolve;
        }

        public double[] SLU_GaussSolve(double[,] a_matrix, double[] b_vector)
        {
            //Функция решения системы линейных уравнений по методу Гаусса
            //a_matrix - матрица коэффициентов при неизвестных
            //b_vector - матрица-столбец свободных коэффициентов
            //Уравнения вида:
            //a11x1 + a12x2 + a13x3 + ... a1NxN = b1 
            //a21x1 + a22x2 + a23x3 + ... a2NxN = b2 
            //a31x1 + a32x2 + a33x3 + ... a3NxN = b3 
            //... 
            //aN1x1 + aN2x2 + aN3x3 + ... aNNxN = bN 
            SluGaussSolve SLU_Matr = new SluGaussSolve(a_matrix, b_vector);
            //Экземпляр класса SluGaussSolve
            double[] SysSolve = null;
            //Матрица-столбец выходных данных (неизвестных Xi)
            SysSolve = new double[SLU_Matr.XVector.GetUpperBound(0) + 1];
            SysSolve = SLU_Matr.XVector;
            Array.Resize(ref SysSolve, SysSolve.GetUpperBound(0));
            return SysSolve;
        }

    }
}