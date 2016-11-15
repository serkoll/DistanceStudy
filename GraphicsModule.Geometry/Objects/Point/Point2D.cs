using System.Drawing;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Point
{
    //<summary>Класс для расчета параметров 2D точки</summary>
    //<remarks>Copyright © Polozkov V. Yury 2015</remarks>
    public class Point2D: IObject
    {
        //====================================================================================================
        //================== Методы ввода-вывода (расчета) параметров точки по заданным условиям ==================

        /// <summary>Инициализирует новый экземпляр 2D точки</summary>
        /// <remarks>Исходные координаты точки: X=0; Y=0</remarks>
        public Point2D()
        {
            X = 0; Y = 0;
        }//Конструктор, устанавливающий исходные значения координат 2D точки

        /// <summary>Инициализирует новый экземпляр 2D точки с указанными координатами</summary>
        /// <remarks></remarks>
        public Point2D(double X, double Y)
        {
            this.X = X; this.Y = Y;
        }
        /// <summary>Инициализирует новый экземпляр 2D точки</summary>
        /// <remarks></remarks>
        public Point2D(Point2D pt)
        {
            X = pt.X; Y = pt.Y;
        }
        public Point2D(System.Drawing.Point pt)
        {
            X = pt.X; Y = pt.Y;
        }
        //Конструктор, устанавливающий пользовательские значения координат 2D точки

        /// <summary>Получает или задает координату X точки</summary>
        /// <remarks></remarks>
        public double X { get; set; }

        /// <summary>Получает или задает координату Y точки</summary>
        /// <remarks></remarks>
        public double Y { get; set; }
        /// <summary>Передвигает ранее заданную 2D точку (изменяет коодинаты на указанные величины по осям в 2D)</summary>
        /// <remarks>Point3D.X += dx; Point3D.Y += dy</remarks>
        public void PointMove(double dx, double dy) { X += dx; Y += dy; }//Конструктор перемещения на указанные величины по осям //MyClass.Ptcls.X += dx : MyClass.Ptcls.Y += dy

        //-------------------- Задание  значений координат точки путем конвертирования текста и контроль соответсвия значению "Nothing" -----------------------
        public void Draw(DrawS st, System.Drawing.Point framecenter, Graphics g)
        {
            g.DrawPie(st.PenPoints, (float)X - st.RadiusPoints, (float)Y - st.RadiusPoints, st.RadiusPoints * 2, st.RadiusPoints * 2, 0, 360);
        }
        public bool IsSelected(System.Drawing.Point mscoords, float ptR, System.Drawing.Point frameCenter, double distance)
        {
            if (Calculate.Distance(mscoords, this) < distance)
                return true;
            else
                return false;
        }
    }
}
