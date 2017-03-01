using System;
using Microsoft.VisualBasic;

namespace GraphicsModule.Geometry.EquationsSysEvalution
{
    /// <summary>Класс функций решения систем уравнений</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2014</remarks>
    public class EqSysCalculation
    {
        public double[] KramerEquationsSolution(double[,] matrixEquationsKoeff)
        {
            //Функция возвращает решение трех уравнений первой степени с тремя неизвестными по методу Крамера
            //Уравнения вида: ax+by+cz+d=0
            var mrxDetEq = new double[3, 3];
            //Матрица определителя 
            var mrxDetX = new double[3, 3];
            var mrxDetY = new double[3, 3];
            var mrxDetZ = new double[3, 3];
            //Матрицы коэффициентов неизвестных
            MatrixEvalution.MatrixEvalution mrxVar = new MatrixEvalution.MatrixEvalution();
            //Переменная для расчета определителя и ранга матриц
            var mrxSolution = new double[3];
            int i;
            int j;
            //Переменные цикла
            //Контроль размерности заданной матрицы
            if (matrixEquationsKoeff.GetUpperBound(0) != 2 | matrixEquationsKoeff.GetUpperBound(1) != 3)
            {
                //Система не удовлетворяет условиям решения
                Interaction.MsgBox("Исходные данные не удовлетворяют условиям решения" + Constants.vbCrLf + "Правильно задайте матрицу исходных данных", MsgBoxStyle.Exclamation, "Функция решения системы из трех уравнений по методу Крамера");

                //=======!!!!!!!!!!!! Вернуть ошибку !!!!!!!!!!!!!==================

                return null;
                //Вернуть ошибку!!!!!
            }
            //Заполнение матрицы определителя коэффициентов системы уравнений
            for (i = 0; i <= mrxDetEq.GetUpperBound(0); i++)
            {
                for (j = 0; j <= mrxDetEq.GetUpperBound(1); j++)
                {
                    mrxDetEq.SetValue(matrixEquationsKoeff.GetValue(i, j), i, j);
                }
            }
            if (Math.Abs(mrxVar.detMrx3x3(mrxDetEq)) < 0.0001)
            {
                Interaction.MsgBox("Определитель матрицы коэффициентов системы заданных уравнений равен нулю." + Constants.vbCrLf + "Система заданных уравнений не имеет одного определенного решения.", MsgBoxStyle.Exclamation, "Функция решения системы из трех уравнений по методу Крамера");

                //=======!!!!!!!!!!!! Вернуть ошибку !!!!!!!!!!!!!==================

                //MrxSolution.SetValue(1 / 0, 0);???
                //MrxSolution.SetValue(1 / 0, 1);???
                //MrxSolution.SetValue(1 / 0, 2);???
                return mrxSolution;
                //Вернуть ошибку!!!!!
            }
            //Заполнение матрицы коэффициентов неизвестного X
            //Заполнение 1-го столбца
            for (i = 0; i <= mrxDetX.GetUpperBound(0); i++)
            {
                mrxDetX.SetValue(-(double)matrixEquationsKoeff.GetValue(i, 3), i, 0);
            }
            //Заполнение остальных столбцов
            for (i = 0; i <= mrxDetX.GetUpperBound(0); i++)
            {
                for (j = 1; j <= mrxDetX.GetUpperBound(1); j++)
                {
                    mrxDetX.SetValue(matrixEquationsKoeff.GetValue(i, j), i, j);
                }
            }
            //Заполнение матрицы коэффициентов неизвестного Y
            //Заполнение 1-го столбца
            for (i = 0; i <= mrxDetY.GetUpperBound(0); i++)
            {
                mrxDetY.SetValue(matrixEquationsKoeff.GetValue(i, 0), i, 0);
            }
            //Заполнение 2-го столбца
            for (i = 0; i <= mrxDetY.GetUpperBound(0); i++)
            {
                mrxDetY.SetValue(-(double)matrixEquationsKoeff.GetValue(i, 3), i, 1);
            }
            //Заполнение 3-го столбца
            for (i = 0; i <= mrxDetY.GetUpperBound(0); i++)
            {
                mrxDetY.SetValue(matrixEquationsKoeff.GetValue(i, 2), i, 2);
            }
            //Заполнение матрицы коэффициентов неизвестного Z
            //Заполнение первых двух столбцов
            for (i = 0; i <= mrxDetZ.GetUpperBound(0); i++)
            {
                for (j = 0; j <= mrxDetZ.GetUpperBound(1) - 1; j++)
                {
                    mrxDetZ.SetValue(matrixEquationsKoeff.GetValue(i, j), i, j);
                }
            }
            //Заполнение 3-го столбца
            for (i = 0; i <= mrxDetZ.GetUpperBound(0); i++)
            {
                mrxDetZ.SetValue(-(double)matrixEquationsKoeff.GetValue(i, 3), i, 2);
            }
            //Расчет неизвестных X, Y, Z
            mrxSolution.SetValue(mrxVar.detMrx3x3(mrxDetX) / mrxVar.detMrx3x3(mrxDetEq), 0);
            mrxSolution.SetValue(mrxVar.detMrx3x3(mrxDetY) / mrxVar.detMrx3x3(mrxDetEq), 1);
            mrxSolution.SetValue(mrxVar.detMrx3x3(mrxDetZ) / mrxVar.detMrx3x3(mrxDetEq), 2);
            return mrxSolution;
        }

        //Public Overloads Function KramerEquationsSolution(ByVal MatrixEquationsKoeff(,) As Double, ByVal MatrixFreeKoeff() As Double) As Double()
        //    'Функция возвращает решение трех уравнений первой степени с тремя неизвестными по методу Крамера
        //End Function

        //Public Overloads Function KramerEquationsSolution(ByVal Equations1 As Double, ByVal Equations2 As Double, ByVal Equations3 As Double) As Double()
        //    'Функция возвращает решение трех уравнений первой степени с тремя неизвестными по методу Крамера
        //End Function

        public double[] SLU_GaussSolve(double[,] aMatrix, double[] bVector, double errorSluSolve)
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
            SluGaussSolve sluMatr = new SluGaussSolve(aMatrix, bVector, errorSluSolve);
            //Экземпляр класса SluGaussSolve
            //Матрица-столбец выходных данных (неизвестных Xi)
            var sysSolve = sluMatr.XVector;
            Array.Resize(ref sysSolve, sysSolve.GetUpperBound(0));
            return sysSolve;
        }

        public double[] SLU_GaussSolve(double[,] aMatrix, double[] bVector)
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
            var sluMatr = new SluGaussSolve(aMatrix, bVector);
            //Экземпляр класса SluGaussSolve
            //Матрица-столбец выходных данных (неизвестных Xi)
            var sysSolve = sluMatr.XVector;
            Array.Resize(ref sysSolve, sysSolve.GetUpperBound(0));
            return sysSolve;
        }

    }
}