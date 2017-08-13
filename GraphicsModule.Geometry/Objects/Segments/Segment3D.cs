using System.Collections.Generic;
using System.Drawing;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Segments
{
    //TODO: NAMES REFACTOR
    public class Segment3D : IObject
    {
        private Name _name;
        public static Segment3D Create(IList<IObject> lst)
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
            if (linePi1.Point0.X == linePi2.Point0.X &&
                linePi1.Point1.X == linePi2.Point1.X)
            {
                Point0 = new Point3D(linePi1.Point0, linePi2.Point0);
                Point1 = new Point3D(linePi1.Point1, linePi2.Point1);
                SegmentOfPlane1X0Y = linePi1;
                SegmentOfPlane2X0Z = linePi2;
                SegmentOfPlane3Y0Z = new SegmentOfPlane3Y0Z(new PointOfPlane3Y0Z(linePi1.Point0.Y, linePi2.Point0.Z), new PointOfPlane3Y0Z(linePi1.Point1.Y, linePi2.Point1.Z));
            }
            else if (linePi1.Point0.X == linePi2.Point1.X &&
                     linePi1.Point1.X == linePi2.Point0.X)
            {
                Point0 = new Point3D(linePi1.Point1.ToPoint2D(), linePi2.Point0.Z);
                Point1 = new Point3D(linePi1.Point0.ToPoint2D(), linePi2.Point1.Z);
                SegmentOfPlane1X0Y = linePi1;
                SegmentOfPlane2X0Z = linePi2;
                SegmentOfPlane3Y0Z = new SegmentOfPlane3Y0Z(new PointOfPlane3Y0Z(linePi1.Point1.Y, linePi2.Point0.Z), new PointOfPlane3Y0Z(linePi1.Point0.Y, linePi2.Point1.Z));
            }
        }
        public Segment3D(SegmentOfPlane1X0Y linePi1, SegmentOfPlane3Y0Z linePi3)
        {
            if (linePi1.Point0.Y == linePi3.Point0.Y &&
                linePi1.Point1.Y == linePi3.Point1.Y)
            {
                Point0 = new Point3D(linePi1.Point0, linePi3.Point0);
                Point1 = new Point3D(linePi1.Point1, linePi3.Point1);
                SegmentOfPlane1X0Y = linePi1;
                SegmentOfPlane2X0Z = new SegmentOfPlane2X0Z(new PointOfPlane2X0Z(linePi1.Point0.X, linePi3.Point0.Z), new PointOfPlane2X0Z(linePi1.Point1.X, linePi3.Point1.Z));
                SegmentOfPlane3Y0Z = linePi3;
            }
            else if (linePi1.Point0.Y == linePi3.Point1.Y &&
                     linePi1.Point1.Y == linePi3.Point0.Y)
            {
                Point0 = new Point3D(linePi1.Point0.ToPoint2D(), linePi3.Point1.Z);
                Point1 = new Point3D(linePi1.Point1.ToPoint2D(), linePi3.Point0.Z);
                SegmentOfPlane1X0Y = linePi1;
                SegmentOfPlane2X0Z = new SegmentOfPlane2X0Z(new PointOfPlane2X0Z(linePi1.Point0.X, linePi3.Point1.Z), new PointOfPlane2X0Z(linePi1.Point1.X, linePi3.Point0.Z));
                SegmentOfPlane3Y0Z = linePi3;
            }
        }
        public Segment3D(SegmentOfPlane2X0Z linePi2, SegmentOfPlane3Y0Z linePi3)
        {
            if (linePi2.Point0.Z == linePi3.Point0.Z &&
               linePi2.Point1.Z == linePi3.Point1.Z)
            {
                Point0 = new Point3D(linePi2.Point0, linePi3.Point0);
                Point1 = new Point3D(linePi2.Point1, linePi3.Point1);
                SegmentOfPlane1X0Y = new SegmentOfPlane1X0Y(new PointOfPlane1X0Y(linePi2.Point0.X, linePi3.Point0.Y), new PointOfPlane1X0Y(linePi2.Point1.X, linePi3.Point1.Y));
                SegmentOfPlane2X0Z = linePi2;
                SegmentOfPlane3Y0Z = linePi3;
            }
            else if (linePi2.Point1.Z == linePi3.Point0.Z &&
                    linePi2.Point0.Z == linePi3.Point1.Z)
            {
                Point0 = new Point3D(linePi2.Point0.X, linePi3.Point1.Y, linePi2.Point0.Z);
                Point1 = new Point3D(linePi2.Point1.X, linePi3.Point0.Y, linePi2.Point1.Z);
                SegmentOfPlane1X0Y = new SegmentOfPlane1X0Y(new PointOfPlane1X0Y(linePi2.Point0.X, linePi3.Point1.Y), new PointOfPlane1X0Y(linePi2.Point1.X, linePi3.Point0.Y));
                SegmentOfPlane2X0Z = linePi2;
                SegmentOfPlane3Y0Z = linePi3;
            }
        }
        public void Draw(Blueprint blueprint)
        {
            SegmentOfPlane1X0Y.DrawSegmentOnly(blueprint);
            SegmentOfPlane2X0Z.DrawSegmentOnly(blueprint);
            SegmentOfPlane3Y0Z.DrawSegmentOnly(blueprint);
            var settings = blueprint.Settings.Drawing;
            if (settings.LinkLinesSettings.Enabled)
            {
                DrawLinkLine(settings.LinkLinesSettings.PenLinkLineX0YtoX, settings.LinkLinesSettings.PenLinkLineX0YtoY, settings.LinkLinesSettings.PenLinkLineX0ZtoX, settings.LinkLinesSettings.PenLinkLineX0ZtoZ,
                             settings.LinkLinesSettings.PenLinkLineY0ZtoZ, settings.LinkLinesSettings.PenLinkLineY0ZtoY, blueprint.CoordinateSystemCenterPoint, blueprint.Graphics);
            }

        }
        public void DrawLinkLine(Pen penLinkLineX0YtoX, Pen penLinkLineX0YtoY, Pen penLinkLineX0ZtoX, Pen penLinkLineX0ZtoZ, Pen penLinkLineY0ZtoZ, Pen penLinkLineY0ZtoY, Point frameCenter, Graphics graphics)
        {
            Point0.DrawLinkLine(penLinkLineX0YtoX, penLinkLineX0YtoY, penLinkLineX0ZtoX, penLinkLineX0ZtoZ,
                         penLinkLineY0ZtoZ, penLinkLineY0ZtoY, frameCenter, ref graphics);
            Point1.DrawLinkLine(penLinkLineX0YtoX, penLinkLineX0YtoY, penLinkLineX0ZtoX, penLinkLineX0ZtoZ,
                          penLinkLineY0ZtoZ, penLinkLineY0ZtoY, frameCenter, ref graphics);
        }
        public bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            return SegmentOfPlane1X0Y.IsSelected(mscoords, ptR, coordinateSystemCenter, distance) ||
                   SegmentOfPlane2X0Z.IsSelected(mscoords, ptR, coordinateSystemCenter, distance) ||
                   SegmentOfPlane3Y0Z.IsSelected(mscoords, ptR, coordinateSystemCenter, distance);
        }
        public Point3D Point0 { get; private set; }

        public Point3D Point1 { get; private set; }

        public SegmentOfPlane1X0Y SegmentOfPlane1X0Y { get; private set; }

        public SegmentOfPlane2X0Z SegmentOfPlane2X0Z { get; private set; }

        public SegmentOfPlane3Y0Z SegmentOfPlane3Y0Z { get; private set; }

        public double Kx { get; private set; }

        public double Ky { get; private set; }

        public double Kz { get; private set; }

        public Name Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                Point0.Name = _name;
                Point1.Name = _name;
                SegmentOfPlane1X0Y.Name = _name;
                SegmentOfPlane2X0Z.Name = _name;
                SegmentOfPlane3Y0Z.Name = _name;
            }
        }

    }
}
