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
        private double[,] _initialAMatrix;
        //матрица A
        private double[,] _aMatrix;
        //вектор неизвестных x
        private double[] _xVector;
        private double[] _initialBVector;
        //вектор b
        private double[] _bVector;
        //вектор невязки U
        private double[] _uVector;
        //порядок точности для сравнения вещественных чисел 
        private double _eps;
        //размерность задачи
        private int _size;

        internal SluGaussSolve(double[,] aMatrix, double[] bVector)
            : this(aMatrix, bVector, 0.0001)
        {
        }

        internal SluGaussSolve(double[,] aMatrix, double[] bVector, double eps)
        {
            if (aMatrix == null | bVector == null)
            {
                throw new ArgumentNullException("Один из параметров не задан.");
            }
            var bLength = bVector.Length;
            var aLength = aMatrix.Length;
            if (aLength != bLength * bLength)
            {
                throw new ArgumentException("Количество строк и столбцов в матрице A должно совпадать с количеством элементров в векторе B.");
            }
            _initialAMatrix = aMatrix;
            //запоминаем исходную матрицу
            _aMatrix = (double[,])aMatrix.Clone();
            //с её копией будем производить вычисления
            _initialBVector = bVector;
            //запоминаем исходный вектор
            _bVector = (double[])bVector.Clone();
            //с его копией будем производить вычисления
            _xVector = new double[bLength + 1];
            _uVector = new double[bLength + 1];
            _size = bLength;
            //
            _eps = eps;
            //
            GaussSolve();
        }

        internal double[] XVector => _xVector;

        internal double[] UVector => _uVector;

        //Инициализация массива индексов столбцов
        private int[] InitIndex()
        {
            var index = new int[_size + 1];
            for (int i = 0; i <= _size - 1; i++)
            {
                index[i] = i;
            }
            return index;
        }

        //Поиск главного элемента в матрице
        private double FindR(int row, int[] index)
        {
            var maxIndex = row;
            var max = _aMatrix[row, index[maxIndex]];
            var maxAbs = Math.Abs(max);
            for (var curIndex = row + 1; curIndex <= _size - 1; curIndex++)
            {
                var cur = _aMatrix[row, index[curIndex]];
                var curAbs = Math.Abs(cur);
                if (!(curAbs > maxAbs)) continue;
                maxIndex = curIndex;
                max = cur;
                maxAbs = curAbs;
            }
            if (maxAbs < _eps)
            {
                Interaction.MsgBox(Math.Abs(_bVector[row]) > _eps
                    ? "Система уравнений несовместна."
                    : "Система уравнений имеет множество решений.");
            }
            // меняем местами индексы столбцов
            var temp = index[row];
            index[row] = index[maxIndex];
            index[maxIndex] = temp;
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
            for (int i = 0; i <= _size - 1; i++)
            {
                // 1) выбор главного элемента
                double r = FindR(i, index);
                // 2) преобразование текущей строки матрицы A
                for (int j = 0; j <= _size - 1; j++)
                {
                    _aMatrix[i, j] /= r;
                }
                // 3) преобразование i-го элемента вектора b
                _bVector[i] /= r;

                // 4) Вычитание текущей строки из всех нижерасположенных строк
                for (int k = i + 1; k <= _size - 1; k++)
                {
                    double p = _aMatrix[k, index[i]];
                    for (int j = i; j <= _size - 1; j++)
                    {
                        _aMatrix[k, index[j]] -= _aMatrix[i, index[j]] * p;
                    }
                    _bVector[k] -= _bVector[i] * p;
                    _aMatrix[k, index[i]] = 0.0;
                }
            }
        }

        // Обратный ход метода Гаусса
        private void GaussBackwardStroke(int[] index)
        {
            //перемещаемся по каждой строке снизу вверх
            for (int i = _size - 1; i >= 0; i += -1)
            {
                // 1) задаётся начальное значение элемента x
                double xI = _bVector[i];

                // 2) корректировка этого значения
                for (int j = i + 1; j <= _size - 1; j++)
                {
                    xI -= _xVector[index[j]] * _aMatrix[i, index[j]];
                }
                _xVector[index[i]] = xI;
            }
        }

        // Вычисление невязки решения
        // U = b - x * A
        // x - решение уравнения, полученное методом Гаусса
        private void GaussDiscrepancy()
        {
            for (int i = 0; i <= _size - 1; i++)
            {
                double actualBI = 0.0;
                // результат перемножения i-строки 
                // исходной матрицы на вектор x
                for (int j = 0; j <= _size - 1; j++)
                {
                    actualBI += _initialAMatrix[i, j] * _xVector[j];
                }
                // i-й элемент вектора невязки
                _uVector[i] = _initialBVector[i] - actualBI;
            }
        }
    }
    //SluGaussSolve
}

