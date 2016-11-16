using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicsModule.Cursors
{
    /// <summary>
    /// Класс, содержащий инструменты работы с курсором при отрисовке графических объектов
    /// </summary>
    class CursorOnGridMove
    {
        /// <summary>
        /// Определяет, включена ли привязка к сетке
        /// </summary>
        public static bool ToGridFixation = false;
        /// <summary>
        /// Точка, соответствующая предыдущему положению курсора
        /// </summary>
        private Point oldPosition = new Point();
        /// <summary>
        /// Точка, соответствующая текущему положению курсора
        /// </summary>
        private Point newPosition; 
        /// <summary>
        /// Передвигает курсор в заданном Canvas, привязывая его к узлам заданной сетки
        /// </summary>
        /// <param name="can">Полотно</param>
        public void CursorPointToGridMove(Canvas can)
        {
            CursorPointToGridMove(can.pb, can.Grid.Center, can.Grid.Setting.StepOfWidth, can.Grid.Setting.StepOfHeight);
        }
        /// <summary>
        /// Передвигает курсор в заданном PictureBox, привязывая его к узлам заданной сетки
        /// </summary>
        /// <param name="pb">PictureBox, в котором осуществляется перемещение курсора</param>
        /// <param name="gridCenter">Центр сетки</param>
        /// <param name="gStepHeight">Шаг сетки по Y</param>
        /// <param name="gStepWidth">Шаг сетки по X</param>
        public void CursorPointToGridMove(PictureBox pb, Point gridCenter, int gStepWidth, int gStepHeight)
        {
            if (!ToGridFixation) return;
            // Пересчет координат курсора относительно узловых точек сетки
            int dX = Cursor.Position.X - pb.PointToClient(Cursor.Position).X; //Разность значений координат X в системе координат основной формы и в системе координат PictureBox1 (определяет положение PictureBox1 в системе координат основной формы)
            int dY = Cursor.Position.Y - pb.PointToClient(Cursor.Position).Y; //Разность значений координат Y в системе координат основной формы и в системе координат PictureBox1 (определяет положение PictureBox1 в системе координат основной формы)
            if (oldPosition.X == 0 && oldPosition.Y == 0) // Установка стартовых значений
            {
                var curPosOnGird = new Point();
                int DistanceX, DistanceY;

                // 1. Перевод координат точки курсора из системы координат PictureBox-а в систему координат СЕТКИ
                curPosOnGird.X = pb.PointToClient(Cursor.Position).X - gridCenter.X;
                curPosOnGird.Y = pb.PointToClient(Cursor.Position).Y - gridCenter.Y;

                // 2. Пересчет координат с учетом шага сетки
                // 2.1. Расчет расстояния от центра сетки до заданной точки
                DistanceX = (int)Math.Round((double)(curPosOnGird.X / gStepWidth), 0);
                DistanceY = (int)Math.Round((double)(curPosOnGird.Y / gStepHeight), 0);

                // 2.2. Расчет координат точки, округленных до значений, кратных заданному шагу
                curPosOnGird.X = DistanceX * gStepWidth;
                curPosOnGird.Y = DistanceY * gStepHeight;

                // 3. Перевод координат точки (заданных в системе координат сетки) обратно в систему координат PictureBox
                curPosOnGird.X = curPosOnGird.X + gridCenter.X;
                curPosOnGird.Y = curPosOnGird.Y + gridCenter.Y;

                // 4. Смещение положения курсора в точку с округленными координатами
                Cursor.Position = new Point((int)Math.Truncate((double)(curPosOnGird.X + dX)), (int)Math.Truncate((double)(curPosOnGird.Y + dY)));
                // 5. Запись текущего положения курсора
                oldPosition.X = Cursor.Position.X;
                oldPosition.Y = Cursor.Position.Y;
                return;
            }

            newPosition = Cursor.Position;

            if (oldPosition.X > newPosition.X) // Движение курсора влево
            {
                Cursor.Position = new Point(oldPosition.X - gStepWidth, oldPosition.Y);
                oldPosition.X -= gStepWidth;
            }
            else if (oldPosition.X < newPosition.X) // Движение курсора вправо
            {
                Cursor.Position = new Point(oldPosition.X + gStepWidth, oldPosition.Y);
                oldPosition.X += gStepWidth;
            }
            if (oldPosition.Y > newPosition.Y) // Движение курсора вниз
            {
                Cursor.Position = new Point(oldPosition.X, oldPosition.Y - gStepHeight);
                oldPosition.Y -= gStepHeight;
            }
            else if (oldPosition.Y < newPosition.Y) // Движение курсора вверх
            {
                Cursor.Position = new Point(oldPosition.X, oldPosition.Y + gStepHeight);
                oldPosition.Y += gStepHeight;
            }
        }
    }
}
