using System.Collections.Generic;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Lines
{
    public class LineOfPlane1X0Y : ILineOfPlane
    {
        public LineOfPlane1X0Y(PointOfPlane1X0Y pt0, PointOfPlane1X0Y pt1)
        {
            Point0 = pt0;
            Point1 = pt1;
            Kx = pt1.X - pt0.X;
            Ky = pt1.Y - pt0.Y;
            EndingPoints = null;
            Name = new Name();
        }
        public LineOfPlane1X0Y(PointOfPlane1X0Y pt0, PointOfPlane1X0Y pt1, Point coordinateSystemCenter)
        {
            Point0 = pt0;
            Point1 = pt1;
            Kx = pt1.X - pt0.X;
            Ky = pt1.Y - pt0.Y;
            EndingPoints = this.CalculateEndingPointsOnFrame(coordinateSystemCenter);
            Name = new Name();
        }

        public LineOfPlane1X0Y(Line3D line)
        {
            Point0 = new PointOfPlane1X0Y(line.Point0.X, line.Point0.Y);
            Point1 = new PointOfPlane1X0Y(line.Point1.X, line.Point1.Y);
            Kx = Point1.X - Point0.X;
            Ky = Point1.Y - Point0.Y;
            EndingPoints = null;
            Name = new Name();
        }

        public void Draw(DrawSettings settings, Point coordinateSystemCenter, Graphics graphics)
        {
            if (EndingPoints == null)
            {
                EndingPoints = this.CalculateEndingPointsOnFrame(coordinateSystemCenter);
            }

            graphics.DrawLine(settings.PenLineOfPlane1X0Y, EndingPoints[0], EndingPoints[1]);

            Point0.Draw(settings, coordinateSystemCenter, graphics);
            Point1.Draw(settings, coordinateSystemCenter, graphics);
        }

        public void DrawLineOnly(DrawSettings settings, Point coordinateSystemCenter, Graphics graphics)
        {
            if (EndingPoints == null)
            {
                EndingPoints = this.CalculateEndingPointsOnFrame(coordinateSystemCenter);
            }

            graphics.DrawLine(settings.PenLineOfPlane1X0Y, EndingPoints[0], EndingPoints[1]);

            Point0.DrawPointsOnly(settings, coordinateSystemCenter, graphics);
            Point1.DrawPointsOnly(settings, coordinateSystemCenter, graphics);
            
        }

        public bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            var ln = this.ToGlobalCoordinatesLine2D(coordinateSystemCenter);
            return ln.IsIncidentalToPoint(mscoords, 35 * distance);
        }

        public PointOfPlane1X0Y Point0 { get; }

        public PointOfPlane1X0Y Point1 { get; }

        public double Kx { get; }

        public double Ky { get; }

        public Name Name { get; set; }
    
        public IList<PointF> EndingPoints { get; set; }
    }
}