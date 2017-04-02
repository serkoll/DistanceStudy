using System.Drawing;
using System.Runtime.InteropServices;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Interfaces;

namespace GraphicsModule.Geometry.Objects.Points
{
    /// <summary>
    /// 2D точка
    /// </summary>
    public class Point2D : IObject
    {
        /// <summary>
        /// Получает или задает координату X точки
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Получает или задает координату Y точки
        /// </summary>
        public double Y { get; set; }
        private Name _name;
        /// <summary>
        /// Имя точки
        /// </summary>
        public Name Name
        {
            get { return _name; }
            set { _name = new Name(value); }
        }
        /// <summary>Инициализирует новый экземпляр 2D точки с указанными координатами</summary>
        /// <remarks></remarks>
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
            Name = new Name();
        }
        /// <summary>
        /// Создает экземпляр 2D точки
        /// </summary>
        /// <param name="pt">Точка</param>
        public Point2D(Point pt)
        {
            X = pt.X; Y = pt.Y; Name = new Name();
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
        /// <param name="settings">Параметры отрисовки графических объектов</param>
        /// <param name="framecenter">Центр системы координат</param>
        /// <param name="g">Целевой Graphics</param>
        public void Draw(DrawSettings settings, Point framecenter, Graphics g)
        {
            g.DrawPie(settings.PenPoints, (float)X - settings.RadiusPoints, (float)Y - settings.RadiusPoints, settings.RadiusPoints * 2, settings.RadiusPoints * 2, 0, 360);
            if (Name.IsDraw)
                g.DrawString(Name.Value, settings.TextFont, settings.TextBrush, (float)X + Name.Dx, (float)Y + Name.Dy);
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
        public Name GetName()
        {
            return Name;
        }
        public void SetName(Name name)
        {
            Name = new Name(name);
        }
    }
}
