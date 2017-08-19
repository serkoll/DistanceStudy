using System;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;

namespace GraphicsModule.Geometry.Objects.Points
{
    public class PointOfPlane3Y0Z : IPointOfPlane, IObjectOfPlane3Y0Z
    {
        public PointOfPlane3Y0Z()
        {
            Y = 0;
            Z = 0;
            Name = new Name();
        }

        public PointOfPlane3Y0Z(double y, double z)
        {
            Y = y;
            Z = z;
            Name = new Name();
        }

        public PointOfPlane3Y0Z(Point pt, Point center)
        {
            Y = pt.X - center.X;
            Z = -(pt.Y - center.Y);
            Name = new Name();
        }

        public static bool IsCreatable(Point pt, Point frameCenter)
        {
            return (pt.X - frameCenter.X) >= 0 && (pt.Y - frameCenter.Y) <= 0;
        }

        public void Draw(Pen pen, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            var ptForDraw = this.ToGlobalCoordinates(frameCenter);
            graphics.DrawPie(pen, ptForDraw.X - poitRaduis, ptForDraw.Y - poitRaduis, poitRaduis * 2, poitRaduis * 2, 0, 360);
        }

        public void Draw(Blueprint blueprint)
        {
            var graphics = blueprint.Graphics;
            var settings = blueprint.Settings.Drawing;
            var linkLineSettings = settings.LinkLinesSettings;
            if (linkLineSettings.Enabled)
            {
                DrawLinkLine(linkLineSettings.PenLinkLineX0ZtoZ, linkLineSettings.PenLinkLineY0ZtoY, blueprint.CoordinateSystemCenterPoint, graphics);
            }

            Draw(settings.PenPoints, settings.RadiusPoints, blueprint.CoordinateSystemCenterPoint, graphics);

            DrawName(settings, settings.RadiusPoints, blueprint.CoordinateSystemCenterPoint, graphics);
        }

        [Obsolete("Поменять название")]
        public void DrawPointsOnly(Blueprint blueprint)
        {
            var settings = blueprint.Settings.Drawing;
            Draw(settings.PenPoints, settings.RadiusPoints, blueprint.CoordinateSystemCenterPoint, blueprint.Graphics);
            DrawName(settings, settings.RadiusPoints, blueprint.CoordinateSystemCenterPoint, blueprint.Graphics);
        }

        public void DrawName(DrawSettings st, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            var ptForDraw = this.ToGlobalCoordinates(frameCenter);
            graphics.DrawString(Name.Value + "'''", st.TextFont, st.TextBrush, ptForDraw.X + Name.Dx, ptForDraw.Y + Name.Dy);
        }

        #region LinkLines

        public void DrawLinkLine(Pen penLinkLineToZ, Pen penLinkLineToY, Point coordinateSystemCenter, Graphics graphics)
        {
            DrawLinkLineToZ(penLinkLineToZ, coordinateSystemCenter, graphics);
            DrawLinkLineToY(penLinkLineToY, coordinateSystemCenter, graphics);
        }

        private void DrawLinkLineToZ(Pen penLinkLineToZ, Point coordinateSystemCenter, Graphics graphics)
        {
            var pt = this.ToGlobalCoordinates(coordinateSystemCenter);
            graphics.DrawLine(penLinkLineToZ, pt, new Point(0, pt.Y));
        }

        private void DrawLinkLineToY(Pen penLinkLineToY, Point coordinateSystemCenter, Graphics graphics)
        {
            var pt = this.ToGlobalCoordinates(coordinateSystemCenter);
            var ptOnYPi3 = new Point(pt.X, coordinateSystemCenter.Y);
            graphics.DrawLine(penLinkLineToY, pt, ptOnYPi3);

            var y = Convert.ToInt32(Y);
            if (y != 0)
            {
                var ptForArc = new Point(coordinateSystemCenter.X - y, coordinateSystemCenter.Y - y);
                graphics.DrawArc(penLinkLineToY, ptForArc.X, ptForArc.Y, y * 2, y * 2, 0, 90);
            }

            var ptOnYPi1 = new Point(coordinateSystemCenter.X, coordinateSystemCenter.Y + Convert.ToInt32(Y));
            graphics.DrawLine(penLinkLineToY, ptOnYPi1, new Point(0, ptOnYPi1.Y));
        }

        #endregion

        public bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            return this.DistanceToPoint(mscoords, coordinateSystemCenter) < distance;
        }

        public double Y { get; }

        public double Z { get; }

        public Name Name { get; set; }
        
    }
}
