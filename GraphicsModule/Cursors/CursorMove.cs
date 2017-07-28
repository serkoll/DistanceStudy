using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicsModule.Cursors
{
    /// <summary>
    /// Класс, содержащий инструменты работы с курсором при отрисовке графических объектов
    /// </summary>
    internal class CursorOnGridMove
    {
        /// <summary>
        /// Определяет, включена ли привязка к сетке
        /// </summary>
        public static bool ToGridFixation = false;
        /// <summary>
        /// Точка, соответствующая предыдущему положению курсора
        /// </summary>
        private Point _oldPosition;
        /// <summary>
        /// Точка, соответствующая текущему положению курсора
        /// </summary>
        private Point _newPosition; 
        /// <summary>
        /// Передвигает курсор в заданном Blueprint, привязывая его к узлам заданной сетки
        /// </summary>
        /// <param name="blueprint">Полотно</param>
        public void CursorPointToGridMove(Blueprint blueprint)
        {
            CursorPointToGridMove(blueprint.PictureBox, blueprint.CenterSystemPoint, blueprint.Background.Grid.StepOnWidth, blueprint.Background.Grid.StepOnHeight);
        }

        //TODO: переписать логику
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
            var dX = Cursor.Position.X - pb.PointToClient(Cursor.Position).X; //Разность значений координат X в системе координат основной формы и в системе координат PictureBox1 (определяет положение PictureBox1 в системе координат основной формы)
            var dY = Cursor.Position.Y - pb.PointToClient(Cursor.Position).Y; //Разность значений координат Y в системе координат основной формы и в системе координат PictureBox1 (определяет положение PictureBox1 в системе координат основной формы)
            if (_oldPosition.X == 0 && _oldPosition.Y == 0) // Установка стартовых значений
            {
                var curPosOnGird = new Point
                {
                    X = pb.PointToClient(Cursor.Position).X - gridCenter.X,
                    Y = pb.PointToClient(Cursor.Position).Y - gridCenter.Y
                };

                // 1. Перевод координат точки курсора из системы координат PictureBox-а в систему координат СЕТКИ

                // 2. Пересчет координат с учетом шага сетки
                // 2.1. Расчет расстояния от центра сетки до заданной точки
                var distanceX = (int)Math.Round((double)(curPosOnGird.X / gStepWidth), 0);
                var distanceY = (int)Math.Round((double)(curPosOnGird.Y / gStepHeight), 0);

                // 2.2. Расчет координат точки, округленных до значений, кратных заданному шагу
                curPosOnGird.X = distanceX * gStepWidth;
                curPosOnGird.Y = distanceY * gStepHeight;

                // 3. Перевод координат точки (заданных в системе координат сетки) обратно в систему координат PictureBox
                curPosOnGird.X = curPosOnGird.X + gridCenter.X;
                curPosOnGird.Y = curPosOnGird.Y + gridCenter.Y;

                // 4. Смещение положения курсора в точку с округленными координатами
                Cursor.Position = new Point((int)Math.Truncate((double)(curPosOnGird.X + dX)), (int)Math.Truncate((double)(curPosOnGird.Y + dY)));
                // 5. Запись текущего положения курсора
                _oldPosition.X = Cursor.Position.X;
                _oldPosition.Y = Cursor.Position.Y;
                return;
            }

            _newPosition = Cursor.Position;

            if (_oldPosition.X > _newPosition.X) // Движение курсора влево
            {
                Cursor.Position = new Point(_oldPosition.X - gStepWidth, _oldPosition.Y);
                _oldPosition.X -= gStepWidth;
            }
            else if (_oldPosition.X < _newPosition.X) // Движение курсора вправо
            {
                Cursor.Position = new Point(_oldPosition.X + gStepWidth, _oldPosition.Y);
                _oldPosition.X += gStepWidth;
            }
            if (_oldPosition.Y > _newPosition.Y) // Движение курсора вниз
            {
                Cursor.Position = new Point(_oldPosition.X, _oldPosition.Y - gStepHeight);
                _oldPosition.Y -= gStepHeight;
            }
            else if (_oldPosition.Y < _newPosition.Y) // Движение курсора вверх
            {
                Cursor.Position = new Point(_oldPosition.X, _oldPosition.Y + gStepHeight);
                _oldPosition.Y += gStepHeight;
            }
        }
    }
}
