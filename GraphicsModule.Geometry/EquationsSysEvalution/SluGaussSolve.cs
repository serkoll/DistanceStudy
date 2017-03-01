using System;
using Microsoft.VisualBasic;

namespace GraphicsModule.Geometry.EquationsSysEvalution
{
    /// <summary>
    /// Класс, содержащий функции и порядок решения системы линейных уравнений методом Гаусса
    /// </summary>
    /// <remarks></remarks>
    internal class SluGaussSolve : EqSysCalculation
    {
        private double[,] initial_a_matrix;
        //матрица A
        private double[,] a_matrix;
        //вектор неизвестных x
        private double[] x_vector;
        private double[] initial_b_vector;
        //вектор b
        private double[] b_vector;
        //вектор невязки U
        private double[] u_vector;
        //порядок точности для сравнения вещественных чисел 
        private double eps;
        //размерность задачи
        private int size;

        internal SluGaussSolve(double[,] aMatrix, double[] b_vector)
            : this(aMatrix, b_vector, 0.0001)
        {
        }

        internal SluGaussSolve(double[,] a_matrix, double[] b_vector, double eps)
        {
            if (a_matrix == null | b_vector == null)
            {
                throw new ArgumentNullException("Один из параметров не задан.");
            }
            int b_length = b_vector.Length;
            int a_length = a_matrix.Length;
            if ((!(a_length == b_length * b_length)))
            {
                throw new ArgumentException("Количество строк и столбцов в матрице A должно совпадать с количеством элементров в векторе B.");
            }
            initial_a_matrix = a_matrix;
            //запоминаем исходную матрицу
            this.a_matrix = (double[,])a_matrix.Clone();
            //с её копией будем производить вычисления
            initial_b_vector = b_vector;
            //запоминаем исходный вектор
            this.b_vector = (double[])b_vector.Clone();
            //с его копией будем производить вычисления
            x_vector = new double[b_length + 1];
            u_vector = new double[b_length + 1];
            size = b_length;
            //
            this.eps = eps;
            //
            GaussSolve();
        }

        internal double[] XVector
        {
            get { return x_vector; }
        }

        internal double[] UVector
        {
            get { return u_vector; }
        }

        //Инициализация массива индексов столбцов
        private int[] InitIndex()
        {
            int[] index = new int[size + 1];
            for (int i = 0; i <= size - 1; i++)
            {
                index[i] = i;
            }
            return index;
        }

        //Поиск главного элемента в матрице
        private double FindR(int row, int[] index)
        {
            int max_index = row;
            double max = a_matrix[row, index[max_index]];
            double max_abs = Math.Abs(max);
            int cur_index = 0;
            for (cur_index = row + 1; cur_index <= size - 1; cur_index++)
            {
                double cur = a_matrix[row, index[cur_index]];
                double cur_abs = Math.Abs(cur);
                if (cur_abs > max_abs)
                {
                    max_index = cur_index;
                    max = cur;
                    max_abs = cur_abs;
                }
            }
            if (max_abs < eps)
            {
                if (Math.Abs(b_vector[row]) > eps)
                {
                    Interaction.MsgBox("Система уравнений несовместна.");
                }
                else
                {
                    Interaction.MsgBox("Система уравнений имеет множество решений.");
                }
            }
            // меняем местами индексы столбцов
            int temp = index[row];
            index[row] = index[max_index];
            index[max_index] = temp;
            return max;
        }

        // Нахождение решения СЛУ методом Гаусса
        private void GaussSolve()
        {
            int[] index = InitIndex();
            GaussForwardStroke(index);
            GaussBackwardStroke(index);
            GaussDiscrepancy();
        }

        //Прямой ход метода Гаусса
        private void GaussForwardStroke(int[] index)
        {
            //перемещаемся по каждой строке сверху вниз
            for (int i = 0; i <= size - 1; i++)
            {
                // 1) выбор главного элемента
                double r = FindR(i, index);
                // 2) преобразование текущей строки матрицы A
                for (int j = 0; j <= size - 1; j++)
                {
                    a_matrix[i, j] /= r;
                }
                // 3) преобразование i-го элемента вектора b
                b_vector[i] /= r;

                // 4) Вычитание текущей строки из всех нижерасположенных строк
                for (int k = i + 1; k <= size - 1; k++)
                {
                    double p = a_matrix[k, index[i]];
                    for (int j = i; j <= size - 1; j++)
                    {
                        a_matrix[k, index[j]] -= a_matrix[i, index[j]] * p;
                    }
                    b_vector[k] -= b_vector[i] * p;
                    a_matrix[k, index[i]] = 0.0;
                }
            }
        }

        // Обратный ход метода Гаусса
        private void GaussBackwardStroke(int[] index)
        {
            //перемещаемся по каждой строке снизу вверх
            for (int i = size - 1; i >= 0; i += -1)
            {
                // 1) задаётся начальное значение элемента x
                double x_i = b_vector[i];

                // 2) корректировка этого значения
                for (int j = i + 1; j <= size - 1; j++)
                {
                    x_i -= x_vector[index[j]] * a_matrix[i, index[j]];
                }
                x_vector[index[i]] = x_i;
            }
        }

        // Вычисление невязки решения
        // U = b - x * A
        // x - решение уравнения, полученное методом Гаусса
        private void GaussDiscrepancy()
        {
            int i = 0;
            for (i = 0; i <= size - 1; i++)
            {
                double actual_b_i = 0.0;
                // результат перемножения i-строки 
                // исходной матрицы на вектор x
                for (int j = 0; j <= size - 1; j++)
                {
                    actual_b_i += initial_a_matrix[i, j] * x_vector[j];
                }
                // i-й элемент вектора невязки
                u_vector[i] = initial_b_vector[i] - actual_b_i;
            }
        }
    }
    //SluGaussSolve
}

