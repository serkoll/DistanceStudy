using System.Collections.Generic;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Lines
{
    public class LineOfPlane2X0Z : ILineOfPlane
    {
        public LineOfPlane2X0Z(PointOfPlane2X0Z pt0, PointOfPlane2X0Z pt1)
        {
            Point0 = pt0;
            Point1 = pt1;
            Kx = pt1.X - pt0.X;
            Kz = pt1.Z - pt0.Z;
            EndingPoints = null;
            Name = new Name();
        }
        public LineOfPlane2X0Z(PointOfPlane2X0Z pt0, PointOfPlane2X0Z pt1, Point coordinateSystemCenter)
        {
            Point0 = pt0;
            Point1 = pt1;
            Kx = pt1.X - pt0.X;
            Kz = pt1.Z - pt0.Z;
            EndingPoints = this.CalculateEndingPointsOnFrame(coordinateSystemCenter);
            Name = new Name();
        }
        public LineOfPlane2X0Z(Line3D line)
        {
            Point0 = new PointOfPlane2X0Z(line.Point0.X, line.Point0.Z);
            Point1 = new PointOfPlane2X0Z(line.Point1.X, line.Point1.Z);
            Kx = Point1.X - Point0.X;
            Kz = Point1.Z - Point0.Z;
            EndingPoints = null;
            Name = new Name();
        }
        public void Draw(DrawSettings settings, Point coordinateSystemCenter, Graphics graphics)
        {
            if (EndingPoints == null)
            {
                EndingPoints = this.CalculateEndingPointsOnFrame(coordinateSystemCenter);
            }

            graphics.DrawLine(settings.PenLineOfPlane2X0Z, EndingPoints[0], EndingPoints[1]);

            Point0.Draw(settings, coordinateSystemCenter, graphics);
            Point1.Draw(settings, coordinateSystemCenter, graphics);
            
        }
        public void DrawLineOnly(DrawSettings settings, Point coordinateSystemCenter, Graphics graphics)
        {
            if (EndingPoints == null)
            {
                EndingPoints = this.CalculateEndingPointsOnFrame(coordinateSystemCenter);
            }

            graphics.DrawLine(settings.PenLineOfPlane2X0Z, EndingPoints[0], EndingPoints[1]);

            Point0.DrawPointsOnly(settings, coordinateSystemCenter, graphics);
            Point1.DrawPointsOnly(settings, coordinateSystemCenter, graphics);
        }

        public bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            var ln = this.ToGlobalCoordinatesLine2D(coordinateSystemCenter);
            return ln.IsIncidentalToPoint(mscoords, 35 * distance);
        }

        public PointOfPlane2X0Z Point0 { get; }

        public PointOfPlane2X0Z Point1 { get; }

        public double Kx { get; }

        public double Kz { get; }

        public Name Name { get; set; }

        public IList<PointF> EndingPoints { get; set; }
    }
}