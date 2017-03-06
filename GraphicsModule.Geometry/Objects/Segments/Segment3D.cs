using System;
using System.Collections.ObjectModel;
using System.Drawing;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Segments
{
    /// <summary>Класс для задания и расчета параметров 3D прямой</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class Segment3D : IObject
    {
        public Point3D Point0 { get; set; }
        public Point3D Point1 { get; set; }
        public Name Name { get; set; }
        public SegmentOfPlane1X0Y SegmentOfPlane1X0Y { get; set; }
        public SegmentOfPlane2X0Z SegmentOfPlane2X0Z { get; set; }
        public SegmentOfPlane3Y0Z SegmentOfPlane3Y0Z { get; set; }
        public double Kx { get; set; }
        public double Ky { get; set; }
        public double Kz { get; set; }
        public static Segment3D Create(Collection<IObject> lst)
        {
            if (lst[0].GetType() == typeof(SegmentOfPlane1X0Y))
            {
                return lst[1].GetType() == typeof(SegmentOfPlane2X0Z) ? 
                    new Segment3D((SegmentOfPlane1X0Y)lst[0], (SegmentOfPlane2X0Z)lst[1]) : 
                    new Segment3D((SegmentOfPlane1X0Y)lst[0], (SegmentOfPlane3Y0Z)lst[1]);
            }
            if (lst[0].GetType() == typeof(SegmentOfPlane2X0Z))
            {
                return lst[1].GetType() == typeof(SegmentOfPlane1X0Y) ? 
                    new Segment3D((SegmentOfPlane1X0Y)lst[1], (SegmentOfPlane2X0Z)lst[0]) : 
                    new Segment3D((SegmentOfPlane2X0Z)lst[0], (SegmentOfPlane3Y0Z)lst[1]);
            }
            return lst[1].GetType() == typeof(SegmentOfPlane1X0Y) ? 
                new Segment3D((SegmentOfPlane1X0Y)lst[1], (SegmentOfPlane3Y0Z)lst[0]) : 
                new Segment3D((SegmentOfPlane2X0Z)lst[1], (SegmentOfPlane3Y0Z)lst[0]);
        }
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
        public void Draw(DrawS st, Point frameCenter, Graphics g)
        {
            SegmentOfPlane1X0Y.DrawSegmentOnly(st, frameCenter, g);
            SegmentOfPlane2X0Z.DrawSegmentOnly(st, frameCenter, g);
            SegmentOfPlane3Y0Z.DrawSegmentOnly(st, frameCenter, g);
            if (st.LinkLineSettings.IsDraw)
            {
                DrawLinkLine(st.LinkLineSettings.PenLinkLineX0YtoX, st.LinkLineSettings.PenLinkLineX0YtoY, st.LinkLineSettings.PenLinkLineX0ZtoX, st.LinkLineSettings.PenLinkLineX0ZtoZ,
                             st.LinkLineSettings.PenLinkLineY0ZtoZ, st.LinkLineSettings.PenLinkLineY0ZtoY, frameCenter, ref g);
            }

        }
        public void DrawLinkLine(Pen penLinkLineX0YtoX, Pen penLinkLineX0YtoY, Pen penLinkLineX0ZtoX, Pen penLinkLineX0ZtoZ, Pen penLinkLineY0ZtoZ, Pen penLinkLineY0ZtoY, Point frameCenter, ref Graphics graphics)
        {
            Point0.DrawLinkLine(penLinkLineX0YtoX, penLinkLineX0YtoY, penLinkLineX0ZtoX, penLinkLineX0ZtoZ,
                         penLinkLineY0ZtoZ, penLinkLineY0ZtoY, frameCenter, ref graphics);
            Point1.DrawLinkLine(penLinkLineX0YtoX, penLinkLineX0YtoY, penLinkLineX0ZtoX, penLinkLineX0ZtoZ,
                          penLinkLineY0ZtoZ, penLinkLineY0ZtoY, frameCenter, ref graphics);
        }
        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            return SegmentOfPlane1X0Y.IsSelected(mscoords, ptR, frameCenter, distance) ||
                   SegmentOfPlane2X0Z.IsSelected(mscoords, ptR, frameCenter, distance) ||
                   SegmentOfPlane3Y0Z.IsSelected(mscoords, ptR, frameCenter, distance);
        }
        public Name GetName()
        {
            return Name;
        }
        public void SetName(Name name)
        {
            Name = new Name(name);
            Name.Value = Name.Value.Remove(Name.Value.IndexOf("'", StringComparison.Ordinal));
            Point0.Name = Name;
            Point1.Name = Name;
            SegmentOfPlane1X0Y.Name = Name;
            SegmentOfPlane2X0Z.Name = Name;
            SegmentOfPlane3Y0Z.Name = Name;
        }
    }
}
