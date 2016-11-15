using System.Collections.ObjectModel;
using System.Drawing;
using GraphicsModule.Geometry.Objects.Point;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Segment
{
    /// <summary>Класс для задания и расчета параметров 3D прямой</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class Segment3D : IObject
    {
        public Point3D Point0 { get; set; }
        public Point3D Point1 { get; set; }
        public SegmentOfPlane1X0Y SegmentOfPlane1X0Y { get; set; }
        public SegmentOfPlane2X0Z SegmentOfPlane2X0Z { get; set; }
        public SegmentOfPlane3Y0Z SegmentOfPlane3Y0Z { get; set; }
        public double kx { get; set; }
        public double ky { get; set; }
        public double kz { get; set; }

        //====================================================================================================
        //================== Свойства задания и извлечения параметров 3D линии ==================================

        /// <summary>
        /// Получает 3D точки, инцидентной инцидентной ранее заданной 3D прямой по параметру t
        /// </summary>
        /// <param name="t">Параметр, определяющий удаление новой точки от базовой точки прямой</param>
        /// <value></value>
        /// <returns></returns>
        /// <remarks>Расчетные формулы координат новой точки: X = Point_0.X + kx * t; Y = Point_0.Y + ky * t; Z = Point_0.Z + kz * t.</remarks>
        public Point3D GetPoint(double t)
        {
            //Свойство, возвращающее координаты 3D точки на 3D прямой по параметру t 
            return (new Point3D(Point0.X + kx * t, Point0.Y + ky * t, Point0.Z + kz * t));
        }
        /// <summary>Инициализация нового экземпляра 2D прямой</summary>
        /// <remarks>Исходные координаты базовой точки прямой равны нулю.
        /// Исходные коэффициенты канонического уравнения прямой: kx=1; ky=0; kz=0.
        /// </remarks>
        public Segment3D()
        {
            Point0 = new Point3D(0, 0, 0);
            kx = 1;
            ky = 0;
            kz = 0;
            Point1.X = kx + Point0.X;
            Point1.Y = ky + Point0.Y;
            Point1.Z = kz + Point0.Z;
        }
        public static Segment3D Create(Collection<IObject> lst)
        {
            if (lst[0].GetType().Name == "SegmentOfPlane1X0Y")
            {
                if (lst[1].GetType().Name == "SegmentOfPlane2X0Z")
                    return new Segment3D((SegmentOfPlane1X0Y)lst[0], (SegmentOfPlane2X0Z)lst[1]);
                else
                    return new Segment3D((SegmentOfPlane1X0Y)lst[0], (SegmentOfPlane3Y0Z)lst[1]);
            }
            else if (lst[0].GetType().Name == "SegmentOfPlane2X0Z")
            {
                if (lst[1].GetType().Name == "SegmentOfPlane1X0Y")
                    return new Segment3D((SegmentOfPlane1X0Y)lst[1], (SegmentOfPlane2X0Z)lst[0]);
                else
                    return new Segment3D((SegmentOfPlane2X0Z)lst[0], (SegmentOfPlane3Y0Z)lst[1]);
            }
            else if (lst[1].GetType().Name == "SegmentOfPlane1X0Y")
                return new Segment3D((SegmentOfPlane1X0Y)lst[1], (SegmentOfPlane3Y0Z)lst[0]);
            else
                return new Segment3D((SegmentOfPlane2X0Z)lst[1], (SegmentOfPlane3Y0Z)lst[0]);
        }
        /// <summary> Задает 3D точку, заданную двумя (горизонтальной и фронтальной) проекциями</summary>
        /// <remarks> При неправильном заднии проекций возвращает "Nothing" </remarks>
        /// <param name="pointPi1"> Горизонтальная проекция 3D точки</param>
        /// <param name="pointPi2"> Фронтальная проекция 3D точки</param>
        public Segment3D(SegmentOfPlane1X0Y linePi1, SegmentOfPlane2X0Z linePi2)
        {
            Point0 = new Point3D();
            Point1 = new Point3D();
            if (linePi1.Point0.X == linePi2.Point0.X &&
                linePi1.Point1.X == linePi2.Point1.X)
            {
                Point0.X = linePi1.Point0.X;
                Point0.Y = linePi1.Point0.Y;
                Point0.Z = linePi2.Point0.Z;
                Point1.X = linePi1.Point1.X;
                Point1.Y = linePi1.Point1.Y;
                Point1.Z = linePi2.Point1.Z;
                SegmentOfPlane1X0Y = linePi1;
                SegmentOfPlane2X0Z = linePi2;
                SegmentOfPlane3Y0Z = new SegmentOfPlane3Y0Z(new PointOfPlane3Y0Z(linePi1.Point0.Y, linePi2.Point0.Z), new PointOfPlane3Y0Z(linePi1.Point1.Y, linePi2.Point1.Z));
                Point0.InitializePointsOfPlane();
                Point1.InitializePointsOfPlane();
            }
            else if (linePi1.Point0.X == linePi2.Point1.X &&
                     linePi1.Point1.X == linePi2.Point0.X)
            {
                Point0.X = linePi1.Point1.X;
                Point0.Y = linePi1.Point1.Y;
                Point0.Z = linePi2.Point0.Z;
                Point1.X = linePi1.Point0.X;
                Point1.Y = linePi1.Point0.Y;
                Point1.Z = linePi2.Point1.Z;
                Point0.InitializePointsOfPlane();
                Point1.InitializePointsOfPlane();
                SegmentOfPlane1X0Y = linePi1;
                SegmentOfPlane2X0Z = linePi2;
                SegmentOfPlane3Y0Z = new SegmentOfPlane3Y0Z(new PointOfPlane3Y0Z(linePi1.Point1.Y, linePi2.Point0.Z), new PointOfPlane3Y0Z(linePi1.Point0.Y, linePi2.Point1.Z));
            }
        }
        /// <summary> Задает 3D точку, заданную двумя (горизонтальной и профильной) проекциями</summary>
        /// <remarks> При неправильном заднии проекций возвращает "Nothing" </remarks>
        /// <param name="pointPi1"> Горизонтальная проекция 3D точки</param>
        /// <param name="linePi3"> Профильная проекция 3D точки</param>
        public Segment3D(SegmentOfPlane1X0Y linePi1, SegmentOfPlane3Y0Z linePi3)
        {
            Point0 = new Point3D();
            Point1 = new Point3D();
            if (linePi1.Point0.Y == linePi3.Point0.Y &&
                linePi1.Point1.Y == linePi3.Point1.Y)
            {
                Point0.X = linePi1.Point0.X;
                Point0.Y = linePi1.Point0.Y;
                Point0.Z = linePi3.Point0.Z;
                Point1.X = linePi1.Point1.X;
                Point1.Y = linePi1.Point1.Y;
                Point1.Z = linePi3.Point1.Z;
                Point0.InitializePointsOfPlane();
                Point1.InitializePointsOfPlane();
                SegmentOfPlane1X0Y = linePi1;
                SegmentOfPlane2X0Z = new SegmentOfPlane2X0Z(new PointOfPlane2X0Z(linePi1.Point0.X, linePi3.Point0.Z), new PointOfPlane2X0Z(linePi1.Point1.X, linePi3.Point1.Z));
                SegmentOfPlane3Y0Z = linePi3;
            }
            else if (linePi1.Point0.Y == linePi3.Point1.Y &&
                     linePi1.Point1.Y == linePi3.Point0.Y)
            {
                Point0.X = linePi1.Point0.X;
                Point0.Y = linePi1.Point0.Y;
                Point0.Z = linePi3.Point1.Z;
                Point1.X = linePi1.Point1.X;
                Point1.Y = linePi1.Point1.Y;
                Point1.Z = linePi3.Point0.Z;
                Point0.InitializePointsOfPlane();
                Point1.InitializePointsOfPlane();
                SegmentOfPlane1X0Y = linePi1;
                SegmentOfPlane2X0Z = new SegmentOfPlane2X0Z(new PointOfPlane2X0Z(linePi1.Point0.X, linePi3.Point1.Z), new PointOfPlane2X0Z(linePi1.Point1.X, linePi3.Point0.Z));
                SegmentOfPlane3Y0Z = linePi3;
            }
        }
        /// <summary> Задает 3D точку, заданную двумя (фронтальной и профильной) проекциями</summary>
        /// <remarks> При неправильном заднии проекций возвращает "Nothing" </remarks>
        /// <param name="pointPi2"> Фронтальня проекция 3D точки</param>
        /// <param name="pointPi3"> Профильная проекция 3D точки</param>
        public Segment3D(SegmentOfPlane2X0Z linePi2, SegmentOfPlane3Y0Z linePi3)
        {
            Point0 = new Point3D();
            Point1 = new Point3D();
            if (linePi2.Point0.Z == linePi3.Point0.Z &&
               linePi2.Point1.Z == linePi3.Point1.Z)
            {
                Point0.X = linePi2.Point0.X;
                Point0.Y = linePi3.Point0.Y;
                Point0.Z = linePi2.Point0.Z;
                Point1.X = linePi2.Point1.X;
                Point1.Y = linePi3.Point1.Y;
                Point1.Z = linePi2.Point1.Z;
                Point0.InitializePointsOfPlane();
                Point1.InitializePointsOfPlane();
                SegmentOfPlane1X0Y = new SegmentOfPlane1X0Y(new PointOfPlane1X0Y(linePi2.Point0.X, linePi3.Point0.Y), new PointOfPlane1X0Y(linePi2.Point1.X, linePi3.Point1.Y));
                SegmentOfPlane2X0Z = linePi2;
                SegmentOfPlane3Y0Z = linePi3;
            }
            else if (linePi2.Point1.Z == linePi3.Point0.Z &&
                    linePi2.Point0.Z == linePi3.Point1.Z)
            {
                Point0.X = linePi2.Point0.X;
                Point0.Y = linePi3.Point1.Y;
                Point0.Z = linePi2.Point0.Z;
                Point1.X = linePi2.Point1.X;
                Point1.Y = linePi3.Point0.Y;
                Point1.Z = linePi2.Point1.Z;
                Point0.InitializePointsOfPlane();
                Point1.InitializePointsOfPlane();
                SegmentOfPlane1X0Y = new SegmentOfPlane1X0Y(new PointOfPlane1X0Y(linePi2.Point0.X, linePi3.Point1.Y), new PointOfPlane1X0Y(linePi2.Point1.X, linePi3.Point0.Y));
                SegmentOfPlane2X0Z = linePi2;
                SegmentOfPlane3Y0Z = linePi3;
            }
        }
        public void Draw(DrawS st, System.Drawing.Point frameCenter, Graphics g)
        {
            SegmentOfPlane1X0Y.DrawSegmentOnly(st, frameCenter, g);
            SegmentOfPlane2X0Z.DrawSegmentOnly(st, frameCenter, g);
            SegmentOfPlane3Y0Z.DrawSegmentOnly(st, frameCenter, g);
            if (st.LinkLineSettings.IsDraw)
            {
                DrawLinkLine(st.LinkLineSettings.LinkLineX0YToX, st.LinkLineSettings.LinkLineX0YToY, st.LinkLineSettings.LinkLineX0ZToX, st.LinkLineSettings.LinkLineX0ZToZ,
                             st.LinkLineSettings.LinkLineY0ZToZ, st.LinkLineSettings.LinkLineY0ZToY, frameCenter, ref g);
            }

        }
        public void DrawLinkLine(Pen penLinkLineX0YToX, Pen penLinkLineX0YToY, Pen penLinkLineX0ZToX, Pen penLinkLineX0ZToZ, Pen penLinkLineY0ZToZ, Pen penLinkLineY0ZToY, System.Drawing.Point frameCenter, ref Graphics graphics)
        {
            Point0.DrawLinkLine(penLinkLineX0YToX, penLinkLineX0YToY, penLinkLineX0ZToX, penLinkLineX0ZToZ,
                         penLinkLineY0ZToZ, penLinkLineY0ZToY, frameCenter, ref graphics);
            Point1.DrawLinkLine(penLinkLineX0YToX, penLinkLineX0YToY, penLinkLineX0ZToX, penLinkLineX0ZToZ,
                          penLinkLineY0ZToZ, penLinkLineY0ZToY, frameCenter, ref graphics);
        }
        public bool IsSelected(System.Drawing.Point mscoords, float ptR, System.Drawing.Point frameCenter, double distance)
        {
            if (SegmentOfPlane1X0Y.IsSelected(mscoords, ptR, frameCenter, distance) ||
                SegmentOfPlane2X0Z.IsSelected(mscoords, ptR, frameCenter, distance) ||
                SegmentOfPlane3Y0Z.IsSelected(mscoords, ptR, frameCenter, distance))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
