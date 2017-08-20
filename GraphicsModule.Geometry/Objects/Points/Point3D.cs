using System;
using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;

namespace GraphicsModule.Geometry.Objects.Points
{
    public class Point3D : Point2D, IObject3D
    {
        private Name _name;

        #region Constructors

        public Point3D(double x, double y, double z) : base(x, y)
        {
            Z = z;
            _name = new Name();
            InitializePointsOfPlane();
        }

        public Point3D(Point2D pt, double z) : base(pt.X, pt.Y)
        {
            Z = z;
            _name = new Name();
            InitializePointsOfPlane();
        }
        public Point3D(PointOfPlane1X0Y pt1, PointOfPlane2X0Z pt2) : base(pt1.X, pt1.Y)
        {
            Z = pt2.Z;
            _name = new Name();
            InitializePointsOfPlane();
        }
        public Point3D(PointOfPlane1X0Y pt1, PointOfPlane3Y0Z pt3) : base(pt1.X, pt1.Y)
        {
            Z = pt3.Z;
            _name = new Name();
            InitializePointsOfPlane();
        }
        public Point3D(PointOfPlane2X0Z pt2, PointOfPlane3Y0Z pt3) : base(pt2.X, pt3.Y)
        {
            Z = pt2.Z;
            _name = new Name();
            InitializePointsOfPlane();
        }

        public Point3D(PointOfPlane1X0Y pt1, PointOfPlane2X0Z pt2, PointOfPlane3Y0Z pt3) : base(pt1.X, pt3.Y)
        {
            Z = pt2.Z;
            _name = new Name();
            InitializePointsOfPlane();
        }

        private void InitializePointsOfPlane()
        {
            PointOfPlane1X0Y = new PointOfPlane1X0Y(X, Y);
            PointOfPlane2X0Z = new PointOfPlane2X0Z(X, Z);
            PointOfPlane3Y0Z = new PointOfPlane3Y0Z(Y, Z);
        }

        #endregion

        public override void Draw(Blueprint blueprint)
        {
            var graphics = blueprint.Graphics;
            var settings = blueprint.Settings.Drawing;
            var linkLineSettings = settings.LinkLinesSettings;
            if (linkLineSettings.Enabled)
            {
                DrawLinkLine(linkLineSettings.PenLinkLineX0YtoX, linkLineSettings.PenLinkLineX0YtoY, linkLineSettings.PenLinkLineX0ZtoZ, blueprint.CoordinateSystemCenterPoint, graphics);
            }

            Draw(settings.PenPoints, settings.RadiusPoints, blueprint.CoordinateSystemCenterPoint, graphics);
            DrawName(settings, settings.RadiusPoints, blueprint.CoordinateSystemCenterPoint, graphics);
        }

        private void Draw(Pen pen, float ptR, Point coordinateSystemCenter, Graphics graphics)
        {
            PointOfPlane1X0Y.Draw(pen, ptR, coordinateSystemCenter, graphics);
            PointOfPlane2X0Z.Draw(pen, ptR, coordinateSystemCenter, graphics);
            PointOfPlane3Y0Z.Draw(pen, ptR, coordinateSystemCenter, graphics);
        }

        private void DrawName(DrawSettings st, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            PointOfPlane1X0Y.DrawName(st, poitRaduis, frameCenter, graphics);
            PointOfPlane2X0Z.DrawName(st, poitRaduis, frameCenter, graphics);
            PointOfPlane3Y0Z.DrawName(st, poitRaduis, frameCenter, graphics);
        }

        #region LinkLines

        public void DrawLinkLine(LinkLinesSettings settings, Point coordinateSystemCenter, Graphics graphics)
        {
            DrawLinkLine(settings.PenLinkLineX0YtoX, settings.PenLinkLineX0YtoY, settings.PenLinkLineX0ZtoZ, coordinateSystemCenter, graphics);
        }

        private void DrawLinkLine(Pen penLinkLineToX, Pen penLinkLineToY, Pen penLinkLineToZ, Point coordinateSystemCenter, Graphics graphics)
        {
            DrawLinkLineToX(penLinkLineToX, coordinateSystemCenter, graphics);
            DrawLinkLineToY(penLinkLineToY, coordinateSystemCenter, graphics);
            DrawLinkLineToZ(penLinkLineToZ, coordinateSystemCenter, graphics);
        }

        private void DrawLinkLineToX(Pen penLinkLineToX, Point coordinateSystemCenter, Graphics graphics)
        {
            var ptX0Y = PointOfPlane1X0Y.ToGlobalCoordinates(coordinateSystemCenter);
            var ptX0Z = PointOfPlane2X0Z.ToGlobalCoordinates(coordinateSystemCenter);
            graphics.DrawLine(penLinkLineToX, ptX0Y, ptX0Z);
        }

        private void DrawLinkLineToY(Pen penLinkLineToY, Point coordinateSystemCenter, Graphics graphics)
        {
            var ptX0Y = PointOfPlane1X0Y.ToGlobalCoordinates(coordinateSystemCenter);
            var ptY0Z = PointOfPlane3Y0Z.ToGlobalCoordinates(coordinateSystemCenter);

            var ptOnYPi1 = new Point(coordinateSystemCenter.X, ptX0Y.Y);
            graphics.DrawLine(penLinkLineToY, ptX0Y, ptOnYPi1);

            var y = Convert.ToInt32(Y);
            if (y != 0)
            {
                var ptForArc = new Point(coordinateSystemCenter.X - y, coordinateSystemCenter.Y - y);
                graphics.DrawArc(penLinkLineToY, ptForArc.X, ptForArc.Y, y * 2, y * 2, 0, 90);
            }
            var ptOnYPi3 = new Point(coordinateSystemCenter.X + y, coordinateSystemCenter.Y);
            graphics.DrawLine(penLinkLineToY, ptOnYPi3, ptY0Z);
        }

        private void DrawLinkLineToZ(Pen penLinkLineToZ, Point coordinateSystemCenter, Graphics graphics)
        {
            var ptX0Z = PointOfPlane2X0Z.ToGlobalCoordinates(coordinateSystemCenter);
            var ptY0Z = PointOfPlane3Y0Z.ToGlobalCoordinates(coordinateSystemCenter);
            graphics.DrawLine(penLinkLineToZ, ptX0Z, ptY0Z);
        }

        #endregion

        public override bool IsSelected(Point mscoords, Point coordinateSystemCenter, double distance)
        {
            var dst = this.DistanceToPoint(mscoords, coordinateSystemCenter);
            return dst.Any(x => x < distance);
        }

        public double Z { get; }

        public new Name Name
        {
            get
            {
                return _name;
            }
            set
            {
                PointOfPlane1X0Y.Name = value;
                PointOfPlane2X0Z.Name = value;
                PointOfPlane3Y0Z.Name = value;
                _name = value;
            }
        }
        public PointOfPlane1X0Y PointOfPlane1X0Y { get; private set; }

        public PointOfPlane2X0Z PointOfPlane2X0Z { get; private set; }

        public PointOfPlane3Y0Z PointOfPlane3Y0Z { get; private set; }
    }
}

