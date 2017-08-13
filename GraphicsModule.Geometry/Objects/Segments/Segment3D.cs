using System;
using System.Drawing;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Segments
{
    public class Segment3D : IObject
    {
        #region Constructors

        public Segment3D(SegmentOfPlane1X0Y linePi1, SegmentOfPlane2X0Z linePi2)
        {
            if (Math.Abs(linePi1.Point0.X - linePi2.Point0.X) < Constants.Tolerance &&
                Math.Abs(linePi1.Point1.X - linePi2.Point1.X) < Constants.Tolerance)
            {
                Point0 = new Point3D(linePi1.Point0, linePi2.Point0);
                Point1 = new Point3D(linePi1.Point1, linePi2.Point1);
            }
            else if (Math.Abs(linePi1.Point0.X - linePi2.Point1.X) < Constants.Tolerance &&
                     Math.Abs(linePi1.Point1.X - linePi2.Point0.X) < Constants.Tolerance)
            {
                Point0 = new Point3D(linePi1.Point1.ToPoint2D(), linePi2.Point0.Z);
                Point1 = new Point3D(linePi1.Point0.ToPoint2D(), linePi2.Point1.Z);
            }
            InitializeSegmentsOfPlane();
        }
        public Segment3D(SegmentOfPlane1X0Y linePi1, SegmentOfPlane3Y0Z linePi3)
        {
            if (Math.Abs(linePi1.Point0.Y - linePi3.Point0.Y) < Constants.Tolerance &&
                Math.Abs(linePi1.Point1.Y - linePi3.Point1.Y) < Constants.Tolerance)
            {
                Point0 = new Point3D(linePi1.Point0, linePi3.Point0);
                Point1 = new Point3D(linePi1.Point1, linePi3.Point1);
            }
            else if (Math.Abs(linePi1.Point0.Y - linePi3.Point1.Y) < Constants.Tolerance &&
                     Math.Abs(linePi1.Point1.Y - linePi3.Point0.Y) < Constants.Tolerance)
            {
                Point0 = new Point3D(linePi1.Point0.ToPoint2D(), linePi3.Point1.Z);
                Point1 = new Point3D(linePi1.Point1.ToPoint2D(), linePi3.Point0.Z);
            }
            InitializeSegmentsOfPlane();
        }
        public Segment3D(SegmentOfPlane2X0Z linePi2, SegmentOfPlane3Y0Z linePi3)
        {
            if (Math.Abs(linePi2.Point0.Z - linePi3.Point0.Z) < Constants.Tolerance &&
               Math.Abs(linePi2.Point1.Z - linePi3.Point1.Z) < Constants.Tolerance)
            {
                Point0 = new Point3D(linePi2.Point0, linePi3.Point0);
                Point1 = new Point3D(linePi2.Point1, linePi3.Point1);
            }
            else if (Math.Abs(linePi2.Point1.Z - linePi3.Point0.Z) < Constants.Tolerance &&
                    Math.Abs(linePi2.Point0.Z - linePi3.Point1.Z) < Constants.Tolerance)
            {
                Point0 = new Point3D(linePi2.Point0.X, linePi3.Point1.Y, linePi2.Point0.Z);
                Point1 = new Point3D(linePi2.Point1.X, linePi3.Point0.Y, linePi2.Point1.Z);
            }
            InitializeSegmentsOfPlane();
        }

        #endregion

        /// <summary>
        /// TODO: локализовать ошибку 
        /// </summary>
        private void InitializeSegmentsOfPlane()
        {
            if (Point0 == null || Point1 == null)
                throw new ArgumentNullException("Null reference");

            SegmentOfPlane1X0Y = new SegmentOfPlane1X0Y(Point0.PointOfPlane1X0Y, Point1.PointOfPlane1X0Y);
            SegmentOfPlane2X0Z = new SegmentOfPlane2X0Z(Point0.PointOfPlane2X0Z, Point1.PointOfPlane2X0Z);
            SegmentOfPlane3Y0Z = new SegmentOfPlane3Y0Z(Point0.PointOfPlane3Y0Z, Point1.PointOfPlane3Y0Z);
        }

        public void Draw(Blueprint blueprint)
        {
            SegmentOfPlane1X0Y.DrawSegmentOnly(blueprint);
            SegmentOfPlane2X0Z.DrawSegmentOnly(blueprint);
            SegmentOfPlane3Y0Z.DrawSegmentOnly(blueprint);

            var settings = blueprint.Settings.Drawing.LinkLinesSettings;
            if (settings.Enabled)
            {
                Point0.DrawLinkLine(settings, blueprint.CoordinateSystemCenterPoint, blueprint.Graphics);
                Point1.DrawLinkLine(settings, blueprint.CoordinateSystemCenterPoint, blueprint.Graphics);
            }

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

        public Name Name { get; set; }
    }
}
