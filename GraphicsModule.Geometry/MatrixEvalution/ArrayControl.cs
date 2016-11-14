
namespace GraphicsModule.Geometry.MatrixEvalution
{
    /// <summary>
    ///  Класс контроля массивов и данных для обработки массивов
    /// </summary>
    /// <remarks>Copyright © Polozkov V. Yury 2014</remarks>
    internal class ArrayControl
    {

        internal ArrayControl()
        {
        }

        //================================================================================================================================
        //----------------------------------------------------------------- Массив As Integer ---------------------------------------------
        //================================================================================================================================

        internal bool Control_IndexRow(int NumRow, int[,] SourceArray)
        {
            if (NumRow > SourceArray.GetUpperBound(0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal bool Control_IndexCol(int NumCol, int[,] SourceArray)
        {
            if (NumCol > SourceArray.GetUpperBound(1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal bool Control_IndexRowAndCol(int NumRow, int NumCol, int[,] SourceArray)
        {
            if (NumRow > SourceArray.GetUpperBound(0) | NumCol > SourceArray.GetUpperBound(1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal bool Control_IndexRowAndCol(int RowStart, int RowEnd, int ColStart, int ColEnd, int[,] SourceArray)
        {
            if (RowStart > SourceArray.GetUpperBound(0) | RowEnd > SourceArray.GetUpperBound(0) | ColStart > SourceArray.GetUpperBound(1) | ColEnd > SourceArray.GetUpperBound(1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal bool Control_ColAndIndexRow(int RowStart, int RowEnd, int NumCol, int[,] SourceArray)
        {
            if (RowStart > SourceArray.GetUpperBound(0) | RowEnd > SourceArray.GetUpperBound(0) | NumCol > SourceArray.GetUpperBound(1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal bool Control_RowAndIndexCol(int NumRow, int ColStart, int ColEnd, int[,] SourceArray)
        {
            if (NumRow > SourceArray.GetUpperBound(0) | ColStart > SourceArray.GetUpperBound(1) | ColEnd > SourceArray.GetUpperBound(1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //-----------------------------------------------------------------------------------------------

        internal bool Control_IndexRow(int NumRow, object[,] SourceArray)
        {
            if (NumRow > SourceArray.GetUpperBound(0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal bool Control_IndexCol(int NumCol, object[,] SourceArray)
        {
            if (NumCol > SourceArray.GetUpperBound(1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal bool Control_IndexRowAndCol(int NumRow, int NumCol, object[,] SourceArray)
        {
            if (NumRow > SourceArray.GetUpperBound(0) | NumCol > SourceArray.GetUpperBound(1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal bool Control_IndexRowAndCol(int RowStart, int RowEnd, int ColStart, int ColEnd, object[,] SourceArray)
        {
            if (RowStart > SourceArray.GetUpperBound(0) | RowEnd > SourceArray.GetUpperBound(0) | ColStart > SourceArray.GetUpperBound(1) | ColEnd > SourceArray.GetUpperBound(1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal bool Control_ColAndIndexRow(int RowStart, int RowEnd, int NumCol, object[,] SourceArray)
        {
            if (RowStart > SourceArray.GetUpperBound(0) | RowEnd > SourceArray.GetUpperBound(0) | NumCol > SourceArray.GetUpperBound(1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal bool Control_RowAndIndexCol(int NumRow, int ColStart, int ColEnd, object[,] SourceArray)
        {
            if (NumRow > SourceArray.GetUpperBound(0) | ColStart > SourceArray.GetUpperBound(1) | ColEnd > SourceArray.GetUpperBound(1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //================================================================================================================================
        //----------------------------------------------------------------- Массив As Double ---------------------------------------------
        //================================================================================================================================

        internal bool Control_IndexRow(int NumRow, double[,] SourceArray)
        {
            if (NumRow > SourceArray.GetUpperBound(0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal bool Control_IndexCol(int NumCol, double[,] SourceArray)
        {
            if (NumCol > SourceArray.GetUpperBound(1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal bool Control_IndexRowAndCol(int NumRow, int NumCol, double[,] SourceArray)
        {
            if (NumRow > SourceArray.GetUpperBound(0) | NumCol > SourceArray.GetUpperBound(1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal bool Control_IndexRowAndCol(int RowStart, int RowEnd, int ColStart, int ColEnd, double[,] SourceArray)
        {
            if (RowStart > SourceArray.GetUpperBound(0) | RowEnd > SourceArray.GetUpperBound(0) | ColStart > SourceArray.GetUpperBound(1) | ColEnd > SourceArray.GetUpperBound(1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal bool Control_ColAndIndexRow(int RowStart, int RowEnd, int NumCol, double[,] SourceArray)
        {
            if (RowStart > SourceArray.GetUpperBound(0) | RowEnd > SourceArray.GetUpperBound(0) | NumCol > SourceArray.GetUpperBound(1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal bool Control_RowAndIndexCol(int NumRow, int ColStart, int ColEnd, double[,] SourceArray)
        {
            if (NumRow > SourceArray.GetUpperBound(0) | ColStart > SourceArray.GetUpperBound(1) | ColEnd > SourceArray.GetUpperBound(1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
