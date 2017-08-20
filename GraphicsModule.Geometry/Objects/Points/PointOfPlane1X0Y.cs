using System;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;

namespace GraphicsModule.Geometry.Objects.Points
{
    public class PointOfPlane1X0Y : IPointOfPlane, IObjectOfPlane1X0Y
    {
        public PointOfPlane1X0Y()
        {
            X = 0;
            Y = 0;
            Name = new Name();
        }

        public PointOfPlane1X0Y(double x, double y)
        {
            X = x;
            Y = y;
            Name = new Name();
        }

        public PointOfPlane1X0Y(double x, double y, Name name)
        {
            X = x;
            Y = y;
            Name = name;
        }

        public PointOfPlane1X0Y(Point pt, Point center)
        {
            X = -(pt.X - center.X);
            Y = pt.Y - center.Y;
            Name = new Name();
        }

        public PointOfPlane1X0Y(Point pt, Point center, Name name)
        {
            X = -(pt.X - center.X);
            Y = pt.Y - center.Y;
            Name = name;
        }

        public static bool IsCreatable(Point pt, Point frameCenter)
        {
            return (pt.X - frameCenter.X) <= 0 && (pt.Y - frameCenter.Y) >= 0;
        }

        public void Draw(Pen pen, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            var ptForDraw = this.ToGlobalCoordinates(frameCenter);
            graphics.DrawPie(pen, ptForDraw.X - poitRaduis, ptForDraw.Y - poitRaduis, poitRaduis * 2, poitRaduis * 2, 0, 360);
        }

        public void Draw(Blueprint blueprint)
        {
            var settings = blueprint.Settings.Drawing;
            var graphics = blueprint.Graphics;
            var linkLineSettings = settings.LinkLinesSettings;
            if (linkLineSettings.Enabled)
            {
                DrawLinkLine(linkLineSettings.PenLinkLineX0YtoX, linkLineSettings.PenLinkLineX0YtoY, blueprint.CoordinateSystemCenterPoint, graphics);
            }

            Draw(settings.PenPoints, settings.RadiusPoints, blueprint.CoordinateSystemCenterPoint, graphics);

            DrawName(settings, settings.RadiusPoints, blueprint.CoordinateSystemCenterPoint, graphics);
        }
    
        public void DrawName(DrawSettings st, float poitRaduis, Point frameCenter, Graphics graphics)
        {
            var ptForDraw = this.ToGlobalCoordinates(frameCenter);
            graphics.DrawString(Name.Value + "'", st.TextFont, st.TextBrush, ptForDraw.X + Name.Dx, ptForDraw.Y + Name.Dy);
        }

        public void DrawPointsOnly(Blueprint blueprint)
        {
            Draw(blueprint.Settings.Drawing.PenPoints, blueprint.Settings.Drawing.RadiusPoints, blueprint.CoordinateSystemCenterPoint, blueprint.Graphics);
            DrawName(blueprint.Settings.Drawing, blueprint.Settings.Drawing.RadiusPoints, blueprint.CoordinateSystemCenterPoint, blueprint.Graphics);
        }

        #region LinkLines

        public void DrawLinkLine(Pen penLinkLineToX, Pen penLinkLineToY, Point coordinateSystemCenter, Graphics graphics)
        {
            DrawLinkLineToX(penLinkLineToX, coordinateSystemCenter, graphics);
            DrawLinkLineToY(penLinkLineToY, coordinateSystemCenter, graphics);
        }

        private void DrawLinkLineToX(Pen penLinkLineToX, Point coordinateSystemCenter, Graphics graphics)
        {
            var pt = this.ToGlobalCoordinates(coordinateSystemCenter);
            graphics.DrawLine(penLinkLineToX, pt, new Point(pt.X, 0));
        }

        private void DrawLinkLineToY(Pen penLinkLineToY, Point coordinateSystemCenter, Graphics graphics)
        {
            var pt = this.ToGlobalCoordinates(coordinateSystemCenter);
            var ptOnYPi1 = new Point(coordinateSystemCenter.X, pt.Y);
            graphics.DrawLine(penLinkLineToY, pt, ptOnYPi1);

            var y = Convert.ToInt32(Y);
            if (y != 0)
            {
                var ptForArc = new Point(coordinateSystemCenter.X - y, coordinateSystemCenter.Y - y);
                graphics.DrawArc(penLinkLineToY, ptForArc.X, ptForArc.Y, y * 2, y * 2, 0, 90);
            }

            var ptOnYPi3 = new Point(coordinateSystemCenter.X + Convert.ToInt32(Y), coordinateSystemCenter.Y);
            graphics.DrawLine(penLinkLineToY, ptOnYPi3, new Point(ptOnYPi3.X, 0));
        }

        #endregion

        public bool IsSelected(Point mscoords, Point coordinateSystemCenter, double distance)
        {
            return this.DistanceToPoint(mscoords, coordinateSystemCenter) < distance;
        }

        public double X { get; }

        public double Y { get; }

        public Name Name { get; set; }
    }
}
