using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace DrawG
{
    /// <summary>
    /// Класс, содежращий данные о текущем состоянии курсора
    /// </summary>
    class Cursor_Draw
    {
        public static CursorTools CursorTools_Var = new CursorTools();

        public static Bitmap GridCursor;

        public static Color CursorColor = Color.Black; // Цвет курсора

        public static bool CursorToGridFixation = false;

        public static int PictureBox_Height = 0;
        public static int PictureBox_Width = 0;

        public static int GridStep_HeightOld = 0;
        public static int GridStep_WidthOld = 0;

        /// <summary>
        /// Перемещает курсор, привязывая его к узлам сетки
        /// </summary>
        /// <param name="PictureBox_Source">PictureBox, в которм осуществляется перемещение курсора </param>
        public static void CursorPointToGridMove(PictureBox PictureBox_Source)
        {
            // 1. Контроль включения привязки к сетке
            if(CursorToGridFixation) {}
            else
            {
                CursorTools_Var.CursorPosition_Old = new Point();
                return;
            }
            // 2. Контроль изменения размеров PictureBox (для устранения (погрешности) приращения координат)
            if((PictureBox_Height==0) && (PictureBox_Width==0)) // Контроль изменения размеров PictureBox
            {
                PictureBox_Height = PictureBox_Source.Height;
                PictureBox_Width = PictureBox_Source.Width;
                CursorTools_Var.CursorPosition_Old = new Point();
            }
            else if ((PictureBox_Height != PictureBox_Source.Height) && (PictureBox_Width != PictureBox_Source.Width) )
            {
                PictureBox_Height = PictureBox_Source.Height;
                PictureBox_Width = PictureBox_Source.Width;
                CursorTools_Var.CursorPosition_Old = new Point();
            }
            // 3. Контроль изменения параметров сетки (для устранения (погрешности) приращения координат)
            if ((GridStep_HeightOld == ControlDraw.GridDraw_Var.GridStepOfHeight) && (GridStep_WidthOld == ControlDraw.GridDraw_Var.GridStepOfWidth)) { }// Контроль изменения параметров сетки
            else
            {
                GridStep_HeightOld = ControlDraw.GridDraw_Var.GridStepOfHeight;
                GridStep_WidthOld = ControlDraw.GridDraw_Var.GridStepOfWidth;
                CursorTools_Var.CursorPosition_Old = new Point();
            }
            // 4. Расчет привязки положения точки курсора к узлам сетки
            CursorTools_Var.CursorPointToGridMove(PictureBox_Source, ControlDraw.GridDraw_Var.GridCenter, ControlDraw.GridDraw_Var.GridStepOfHeight, ControlDraw.GridDraw_Var.GridStepOfWidth);
        }
    }
    
    /// <summary>
    /// Класс, содержащий инструменты работы с курсором при отрисовке графических объектов
    /// </summary>
    class CursorTools
    {
        public Point CursorPosition_Old = new Point(); // Точка, соответствующая предыдущему положению курсора
        public Point CursorPosition_New = new Point(); // Точка, соответствующая новому положению курсора

        /// <summary>
        /// Создает картинку курсора
        /// </summary>
        /// <param name="Graphics_Source">Заданная поверхность рисования</param>
        public void CursorGraphics_Create(Graphics Graphics_Source)
        {
            Bitmap Bitmap_Var = new Bitmap(15, 15, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics_Source = Graphics.FromImage(Bitmap_Var);
            Graphics_Source.DrawLine(new Pen(Brushes.Chocolate), -15, 0, 15, 0); // Горизонтальная линия крестика
            Graphics_Source.DrawLine(new Pen(Brushes.Chocolate), 0, -15, 0, 15); // Вертикальна линия крестика
        }
        /// <summary>
        /// Задает курсор в виде крестика
        /// </summary>
        /// <param name="CursorPoint">Точка, задающая текущие координаты курсора </param>
        /// <param name="Cursor_Color">Цвет курсора</param>
        /// <param name="Graphics_Source">Заданная поверхность рисования </param>
        public static void CursorCreate(int CursorWidth, int CursorHeight, Color Cursor_Color)
        {
            Bitmap CursorBitmap = new Bitmap(CursorWidth, CursorHeight, PixelFormat.Format24bppRgb);
            CursorBitmap.MakeTransparent();
            Graphics CursorGraphics = Graphics.FromImage(CursorBitmap);
            CursorGraphics.DrawLine(new Pen(Cursor_Color), 0, 0, CursorWidth, CursorHeight);
            CursorGraphics.DrawLine(new Pen(Cursor_Color), CursorWidth, 0, 0, CursorHeight);
            Cursor_Draw.GridCursor = (Bitmap)CursorBitmap.Clone();
            CursorBitmap.Dispose();
        }
        /// <summary>
        /// Передвигает курсор в заданном PictureBox, привязывая его к узлам заданной сетки
        /// </summary>
        /// <param name="PictureBox_Source">PictureBox, в котором осуществляется перемещение курсора</param>
        /// <param name="GridCentre_Source">Центр сетки</param>
        /// <param name="GridStep_Height">Шаг сетки по Y</param>
        /// <param name="GridStep_Width">Шаг сетки по X</param>
        public void CursorPointToGridMove(PictureBox PictureBox_Source, Point GridCentre_Source, int GridStep_Height, int GridStep_Width)
        {
            // Пересчет координат курсора относительно узловых точек сетки
            int dX = Cursor.Position.X - PictureBox_Source.PointToClient(Cursor.Position).X; //Разность значений координат X в системе координат основной формы и в системе координат PictureBox1 (определяет положение PictureBox1 в системе координат основной формы)
            int dY = Cursor.Position.Y - PictureBox_Source.PointToClient(Cursor.Position).Y; //Разность значений координат Y в системе координат основной формы и в системе координат PictureBox1 (определяет положение PictureBox1 в системе координат основной формы)
            Graphics Graphics_Source = PictureBox_Source.CreateGraphics();

            if(CursorPosition_Old.X==0 && CursorPosition_Old.Y==0) // Установка стартовых значений
            {
                Point CursorPoint_ToGrid = new Point();
                int DistanceX, DistanceY;

                // 1. Перевод координат точки курсора из системы координат PictureBox-а в систему координат СЕТКИ
                CursorPoint_ToGrid.X = PictureBox_Source.PointToClient(Cursor.Position).X - GridCentre_Source.X;
                CursorPoint_ToGrid.Y = PictureBox_Source.PointToClient(Cursor.Position).Y - GridCentre_Source.Y;

                // 2. Пересчет координат с учетом шага сетки
                // 2.1. Расчет расстояния от центра сетки до заданной точки
                DistanceX = (int)Math.Round((double)(CursorPoint_ToGrid.X / GridStep_Width), 0);
                DistanceY = (int)Math.Round((double)(CursorPoint_ToGrid.Y / GridStep_Height), 0);

                // 2.2. Расчет координат точки, округленных до значений, кратных заданному шагу
                CursorPoint_ToGrid.X = DistanceX * GridStep_Width;
                CursorPoint_ToGrid.Y = DistanceY * GridStep_Height;

                // 3. Перевод координат точки (заданных в системе координат сетки) обратно в систему координат PictureBox
                CursorPoint_ToGrid.X = CursorPoint_ToGrid.X + GridCentre_Source.X;
                CursorPoint_ToGrid.Y = CursorPoint_ToGrid.Y + GridCentre_Source.Y;

                // 4. Смещение положения курсора в точку с округленными координатами
                Cursor.Position = new Point( (int)Math.Truncate((double)(CursorPoint_ToGrid.X + dX)), (int)Math.Truncate((double)(CursorPoint_ToGrid.Y + dY)) );
                // 5. Запись текущего положения курсора
                CursorPosition_Old.X = Cursor.Position.X;
                CursorPosition_Old.Y = Cursor.Position.Y;
                return;
            }

            CursorPosition_New = Cursor.Position;
      
            if(CursorPosition_Old.X > CursorPosition_New.X) // Движение курсора влево
            {
                Cursor.Position = new Point(CursorPosition_Old.X - GridStep_Width, CursorPosition_Old.Y);
                CursorPosition_Old.X -= GridStep_Width;
            }
            else if(CursorPosition_Old.X < CursorPosition_New.X) // Движение курсора вправо
            {
                Cursor.Position = new Point(CursorPosition_Old.X + GridStep_Width, CursorPosition_Old.Y);
                CursorPosition_Old.X += GridStep_Width;
            }
            if (CursorPosition_Old.Y > CursorPosition_New.Y) // Движение курсора вниз
            {
                Cursor.Position = new Point(CursorPosition_Old.X, CursorPosition_Old.Y - GridStep_Height);
                CursorPosition_Old.Y -= GridStep_Height;
            }
            else if (CursorPosition_Old.Y < CursorPosition_New.Y) // Движение курсора вверх
            {
                Cursor.Position = new Point(CursorPosition_Old.X, CursorPosition_Old.Y + GridStep_Height);
                CursorPosition_Old.Y += GridStep_Height;
            }
        }
    }
}
