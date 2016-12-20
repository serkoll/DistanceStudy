using System.Drawing;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Points
{
    /// <summary>
    /// 2D точка
    /// </summary>
    public class Point2D: IObject
    {
        /// <summary>
        /// Получает или задает координату X точки
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Получает или задает координату Y точки
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// Имя точки
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Инициализирует новый экземпляр 2D точки
        /// </summary>
        public Point2D()
        {
            X = 0;
            Y = 0;
        }
        /// <summary>Инициализирует новый экземпляр 2D точки с указанными координатами</summary>
        /// <remarks></remarks>
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
            Name = "";
        }
        /// <summary>
        /// Инициализирует новый экземпляр 2D точки с указанными координатами и именем
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="name">Имя точки</param>
        public Point2D(double x, double y, string name)
        {
            X = x;
            Y = y;
            Name = name;
        }
        /// <summary>
        /// Копирует  экземпляр 2D точки
        /// </summary>
        /// <param name="pt">2D точка</param>
        public Point2D(Point2D pt)
        {
            X = pt.X; Y = pt.Y;
        }
        /// <summary>
        /// Создает экземпляр 2D точки
        /// </summary>
        /// <param name="pt">Точка</param>
        public Point2D(Point pt)
        {
            X = pt.X; Y = pt.Y;
        }
        /// <summary>
        /// Передвигает ранее заданную 2D точку (изменяет коодинаты на указанные величины по осям в 2D)
        /// </summary>
        /// <param name="dx">Смещение по dx</param>
        /// <param name="dy">Спещение по dy</param>
        public void PointMove(double dx, double dy) { X += dx; Y += dy; }
        /// <summary>
        /// Отрисовывает 2D точку
        /// </summary>
        /// <param name="st">Параметры отрисовки графических объектов</param>
        /// <param name="framecenter">Центр системы координат</param>
        /// <param name="g">Целевой Graphics</param>
        public void Draw(DrawS st, Point framecenter, Graphics g)
        {
            g.DrawPie(st.PenPoints, (float)X - st.RadiusPoints, (float)Y - st.RadiusPoints, st.RadiusPoints * 2, st.RadiusPoints * 2, 0, 360);
            g.DrawString(Name, st.TextFont, st.TextBrush, (float)X, (float)Y);
        }
        /// <summary>
        /// Проверяет на выбор курсором
        /// </summary>
        /// <param name="mscoords">Координаты курсора</param>
        /// <param name="ptR">Радиус точки</param>
        /// <param name="frameCenter">Центр системы координат</param>
        /// <param name="distance">Минимальное расстояние до курсора</param>
        /// <returns>True - выбран, false - нет</returns>
        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            return Calculate.Distance(mscoords, this) < distance;
        }
    }
}
