using System.Collections.Generic;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Lines
{
    public class LineOfPlane3Y0Z : ILineOfPlane
    {
        public LineOfPlane3Y0Z(PointOfPlane3Y0Z pt0, PointOfPlane3Y0Z pt1)
        {
            Point0 = pt0;
            Point1 = pt1;
            Ky = pt1.Y - pt0.Y;
            Kz = pt1.Z - pt0.Z;
            Name = new Name();
        }

        public LineOfPlane3Y0Z(PointOfPlane3Y0Z pt0, PointOfPlane3Y0Z pt1, Point coordinateSystemCenter)
        {
            Point0 = pt0;
            Point1 = pt1;
            Ky = pt1.Y - pt0.Y;
            Kz = pt1.Z - pt0.Z;
            EndingPoints = this.CalculateEndingPointsOnFrame(coordinateSystemCenter);
            Name = new Name();
        }
        
        public LineOfPlane3Y0Z(Line3D line)
        {
            Point0 = new PointOfPlane3Y0Z(line.Point0.Y, line.Point0.Z);
            Point1 = new PointOfPlane3Y0Z(line.Point1.Y, line.Point1.Z);
            Ky = Point1.Y - Point0.Y;
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

            graphics.DrawLine(settings.PenLineOfPlane3Y0Z, EndingPoints[0], EndingPoints[1]);

            Point0.Draw(settings, coordinateSystemCenter, graphics);
            Point1.Draw(settings, coordinateSystemCenter, graphics);
        }

        public void DrawLineOnly(DrawSettings settings, Point coordinateSystemCenter, Graphics graphics)
        {
            if (EndingPoints == null)
            {
                EndingPoints = this.CalculateEndingPointsOnFrame(coordinateSystemCenter);
            }

            graphics.DrawLine(settings.PenLineOfPlane3Y0Z, EndingPoints[0], EndingPoints[1]);

            Point0.DrawPointsOnly(settings, coordinateSystemCenter, graphics);
            Point1.DrawPointsOnly(settings, coordinateSystemCenter, graphics);
        }

        public bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            var ln = this.ToGlobalCoordinatesLine2D(coordinateSystemCenter);
            return ln.IsIncidentalToPoint(mscoords, 35 * distance);
        }

        public PointOfPlane3Y0Z Point0 { get; }

        public PointOfPlane3Y0Z Point1 { get; }

        public double Ky { get; }

        public double Kz { get; }

        public Name Name { get; set; }

        public IList<PointF> EndingPoints { get; set; }
    }
}
