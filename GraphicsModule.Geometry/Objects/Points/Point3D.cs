using System.Collections.ObjectModel;
using System.Drawing;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Points
{
    /// <summary>Класс для расчета параметров 3D точки</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class Point3D : IObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public PointOfPlane1X0Y PointOfPlane1X0Y { get; set; }
        /// <summary>Получает или задает координаты проекции 3D точки на плоскость X0Z пространственной системы координат</summary>
        /// <remarks></remarks>
        public PointOfPlane2X0Z PointOfPlane2X0Z { get; set; }
        /// <summary>Получает или задает координаты проекции 3D точки на плоскость Y0Z пространственной системы координат</summary>
        /// <remarks></remarks>
        public PointOfPlane3Y0Z PointOfPlane3Y0Z { get; set; }
        /// <summary>Инициализация нового экземпляра 3D точки</summary>
        /// <remarks>Исходные координаты точки: X=0; Y=0; Z=0</remarks>
        public Point3D()
        {
            Z = 0;
            InitializePointsOfPlane();
        }
        /// <summary>Инициализирует новый экземпляр 3D точки с указанными координатами</summary>
        /// <remarks></remarks>
        public Point3D(double X, double Y, double Z) { new Point2D(X, Y); this.Z = Z; InitializePointsOfPlane(); }//Конструктор, устанавливающий пользовательские значения координат 3D точки
        /// <summary>Инициализирует новый экземпляр 3D точки</summary>
        /// <remarks></remarks>
        public Point3D(Point3D pt) { new Point2D(pt.X, pt.Y); Z = pt.Z; InitializePointsOfPlane(); }//Конструктор, устанавливающий пользовательские значения координат 3D точки
        /// <summary>Преобразует 2D точку в 3D точку путем добавления третьей координаты</summary>
        /// <remarks></remarks>
        public Point3D(Point2D pt, double z) { new Point2D(pt.X, pt.Y); Z = z; InitializePointsOfPlane(); }//Конструктор преобразования двумерной точки в трехмерную, с установкой заданного значения третьей координаты (Z)
        public Point3D(PointOfPlane1X0Y pt1, PointOfPlane2X0Z pt2) { X = pt1.X; Y = pt1.Y; Z = pt2.Z; InitializePointsOfPlane(); }
        public Point3D(PointOfPlane1X0Y pt1, PointOfPlane3Y0Z pt3) { X = pt1.X; Y = pt1.Y; Z = pt3.Z; InitializePointsOfPlane(); }
        public Point3D(PointOfPlane2X0Z pt2, PointOfPlane3Y0Z pt3) { X = pt2.X; Y = pt3.Y; Z = pt2.Z; InitializePointsOfPlane(); }
        public Point3D(PointOfPlane1X0Y pt1, PointOfPlane2X0Z pt2, PointOfPlane3Y0Z pt3)
        {
            if (pt1 != null & pt2 != null & pt3 == null) new Point3D(pt1, pt2);
            else if (pt1 != null & pt2 == null & pt3 != null) new Point3D(pt1, pt3);
            else if (pt1 == null & pt2 != null & pt3 != null) new Point3D(pt2, pt3);
            else if (pt1 != null & pt2 != null & pt3 != null)
            {
                X = pt1.X;
                Y = pt3.Y;
                Z = pt2.Z;
                InitializePointsOfPlane();
            }
        }
        public static Point3D Create(Collection<IObject> lst)
        {
            if (lst[0].GetType() == typeof(PointOfPlane1X0Y))
            {
                return lst[1].GetType() == typeof(PointOfPlane2X0Z) ?
                    CreateByPointOfPlane1and2((PointOfPlane1X0Y)lst[0], (PointOfPlane2X0Z)lst[1]) :
                    CreateByPointOfPlane1and3((PointOfPlane1X0Y)lst[0], (PointOfPlane3Y0Z)lst[1]);
            }
            if (lst[0].GetType() == typeof(PointOfPlane2X0Z))
            {
                return lst[1].GetType() == typeof(PointOfPlane1X0Y) ?
                    CreateByPointOfPlane1and2((PointOfPlane1X0Y)lst[1], (PointOfPlane2X0Z)lst[0]) :
                    CreateByPointOfPlane2and3((PointOfPlane2X0Z)lst[0], (PointOfPlane3Y0Z)lst[1]);
            }
            return lst[1].GetType() == typeof(PointOfPlane1X0Y) ? 
                CreateByPointOfPlane1and3((PointOfPlane1X0Y)lst[1], (PointOfPlane3Y0Z)lst[0]) : 
                CreateByPointOfPlane2and3((PointOfPlane2X0Z)lst[1], (PointOfPlane3Y0Z)lst[0]);
        }
        private static Point3D CreateByPointOfPlane1and2(PointOfPlane1X0Y pt1, PointOfPlane2X0Z pt2)
        {
            return pt1.X == pt2.X ? new Point3D(pt1, pt2) : null;
        }
        private static Point3D CreateByPointOfPlane1and3(PointOfPlane1X0Y pt1, PointOfPlane3Y0Z pt3)
        {
            return pt1.Y == pt3.Y ? new Point3D(pt1, pt3) : null;
        }
        private static Point3D CreateByPointOfPlane2and3(PointOfPlane2X0Z pt2, PointOfPlane3Y0Z pt3)
        {
            return pt2.Z == pt3.Z ? new Point3D(pt2, pt3) : null;
        }
        public void InitializePointsOfPlane()
        {
            PointOfPlane1X0Y = new PointOfPlane1X0Y(X, Y);
            PointOfPlane2X0Z = new PointOfPlane2X0Z(X, Z);
            PointOfPlane3Y0Z = new PointOfPlane3Y0Z(Y, Z);
        }
        /// <summary>Передвигает ранее заданную 3D точку
        /// (изменяет коодинаты на указанные величины по осям в 3D)
        /// </summary>
        /// <remarks>Point3D.X += dx; Point3D.Y += dy; Point3D.Z += dz</remarks>
        public void PointMove(double dx, double dy, double dz) { X += dx; Y += dy; Z += dz; }//Конструктор перемещения на указанные величины по осям в 3D 
        public void Draw(Pen pen, float ptR, System.Drawing.Point frameCenter, Graphics graphics)
        {
            PointOfPlane1X0Y.Draw(pen, ptR, frameCenter, graphics);
            PointOfPlane2X0Z.Draw(pen, ptR, frameCenter, graphics);
            PointOfPlane3Y0Z.Draw(pen, ptR, frameCenter, graphics);
        }
        public void Draw(DrawS st, System.Drawing.Point frameCenter, Graphics g)
        {
            Draw(st.PenPoints, st.RadiusPoints, frameCenter, g);
            DrawLinkLine(st.LinkLineSettings.PenLinkLineX0YtoX, st.LinkLineSettings.PenLinkLineX0YtoY, st.LinkLineSettings.PenLinkLineX0ZtoX, st.LinkLineSettings.PenLinkLineX0ZtoZ,
                         st.LinkLineSettings.PenLinkLineY0ZtoZ, st.LinkLineSettings.PenLinkLineY0ZtoY, frameCenter, ref g);
        }
        public void DrawLinkLine(Pen penLinkLineToX, Pen penLinkLinetoY, Pen penLinkLineX0ZtoX, Pen penLinkLineX0ZtoZ, Pen penLinkLineY0ZtoZ, Pen penLinkLineY0ZtoY, System.Drawing.Point frameCenter, ref Graphics graphics)
        {
            //Отрисовка линий связи
            //Горизонтальная, фронтальная и профильная проекция имеют нулевые значения координат
            //2. Контроль равенства нулю координат двух проекций точки
            if (PointOfPlane1X0Y.X == 0 & PointOfPlane1X0Y.Y == 0 & PointOfPlane2X0Z.X == 0 & PointOfPlane2X0Z.Z == 0)//Горизонтальная и фронтальная проекции имеют нулевые значения координат
            {
                PointOfPlane3Y0Z.DrawLinkLine(penLinkLineY0ZtoZ, penLinkLineY0ZtoY, true, true, true, true, true, frameCenter, graphics);//Отрисовка линий связи Профильной проекции без ограничений
            }
            else if (PointOfPlane1X0Y.X == 0 & PointOfPlane1X0Y.Y == 0 & PointOfPlane3Y0Z.Y == 0 & PointOfPlane3Y0Z.Z == 0)//Горизонтальная и профильная проекции имеют нулевые значения координат
            {
                PointOfPlane2X0Z.DrawLinkLine(penLinkLineX0ZtoX, penLinkLineX0ZtoZ, true, true, true, true, frameCenter, graphics); //Отрисовка линий связи Фронтальной проекции без ограничений
            }
            else if (PointOfPlane2X0Z.X == 0 & PointOfPlane2X0Z.Z == 0 & PointOfPlane3Y0Z.Y == 0 & PointOfPlane3Y0Z.Z == 0)//Фронтальная и профильная проекции имеют нулевые значения координат
            {
                PointOfPlane1X0Y.DrawLinkLine(penLinkLineToX, penLinkLinetoY, true, true, true, true, true, frameCenter, graphics);//Отрисовка линий связи Горизонтальной проекции без ограничений
            }
            //3. Контроль равенства нулю координат одной проекции точки
            else if (PointOfPlane1X0Y.X == 0 & PointOfPlane1X0Y.Y == 0)//Горизонтальная проекция имеет нулевые значения координат
            {
                PointOfPlane2X0Z.DrawLinkLine(penLinkLineX0ZtoX, penLinkLineX0ZtoZ, true, true, true, false, frameCenter, graphics); //Отрисовка линий связи Фронтальной проекции с ограничениями (не отображается связь от Z до правой границы Pi3)
                PointOfPlane3Y0Z.DrawLinkLine(penLinkLineY0ZtoZ, penLinkLineY0ZtoY, true, true, true, false, true, frameCenter, graphics);//Отрисовка линий связи Профильной проекции с ограничениями (не отображается связь от Z до левой границы Pi2)
            }
            else if (PointOfPlane2X0Z.X == 0 & PointOfPlane2X0Z.Z == 0)//Фронтальная проекция имеет нулевые значения координат
            {
                //Отрисовка линий связи Горизонтальной проекции без ограничений (не отображается связь от Y до верхней границы Pi3)
                PointOfPlane1X0Y.DrawLinkLine(penLinkLineToX, penLinkLinetoY, true, true, true, false, true, frameCenter, graphics);
                //Отрисовка линий связи Профильной проекции с ограничениями (не отображается связь от Y до левой границы Pi1 и дуга (для дуги устраняется повторная отрисовка))
                PointOfPlane3Y0Z.DrawLinkLine(penLinkLineY0ZtoZ, penLinkLineY0ZtoY, true, true, false, true, false, frameCenter, graphics);
            }
            else if (PointOfPlane3Y0Z.Y == 0 & PointOfPlane3Y0Z.Z == 0)//Профильная проекция имеет нулевые значения координат
            {
                //Отрисовка линий связи Горизонтальной проекции без ограничений (не отображается связь от X до верхней границы Pi2)
                PointOfPlane1X0Y.DrawLinkLine(penLinkLineToX, penLinkLinetoY, true, true, false, true, true, frameCenter, graphics);
                //Отрисовка линий связи Фронтальной проекции с ограничениями (не отображается связь от X до нижней границы Pi1)
                PointOfPlane2X0Z.DrawLinkLine(penLinkLineX0ZtoX, penLinkLineX0ZtoZ, true, true, false, false, frameCenter, graphics);
            }
            else
            //4. Все проекции не имеют нулевые значения координат
            {
                PointOfPlane1X0Y.DrawLinkLine(penLinkLineToX, penLinkLinetoY, true, true, false, false, true, frameCenter, graphics);  //Отрисовка линий связи Горизонтальной проекции без ограничений (не отображаются связи от осей до границ плоскотсей проекций)
                PointOfPlane2X0Z.DrawLinkLine(penLinkLineX0ZtoX, penLinkLineX0ZtoZ, true, true, false, false, frameCenter, graphics); //Отрисовка линий связи Фронтальной проекции с ограничениями (не отображаются связи от осей до границ плоскотсей проекций)
                PointOfPlane3Y0Z.DrawLinkLine(penLinkLineY0ZtoZ, penLinkLineY0ZtoY, true, true, false, false, false, frameCenter, graphics); //Отрисовка линий связи Профильной проекции с ограничениями (не отображаются связи от осей до границ плоскотсей проекций и дуга (для дуги устраняется повторная отрисовка))
            }
        }
        public bool IsSelected(System.Drawing.Point mscoords, float ptR, System.Drawing.Point frameCenter, double distance)
        {
            var dst = Calculate.Distance(mscoords, ptR, frameCenter, this);
            return dst[0] < distance || dst[1] < distance || dst[2] < distance;
        }
    }
}

