using System.Collections.Generic;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Structures;

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
        public LineOfPlane3Y0Z(Line3D line)
        {
            Point0 = new PointOfPlane3Y0Z(line.Point0.Y, line.Point0.Z);
            Point1 = new PointOfPlane3Y0Z(line.Point1.Y, line.Point1.Z);
            Ky = Point1.Y - Point0.Y;
            Kz = Point1.Z - Point0.Z;
            EndingPoints = null;
            Name = new Name();
        }

        public void Draw(Blueprint blueprint)
        {
            if (EndingPoints == null || !EndingPoints.IsInitialized)
            {
                EndingPoints = new LineEndingPoints(this.ToGlobalCoordinates(blueprint.CoordinateSystemCenterPoint), blueprint.PlaneY0Z);
            }

            blueprint.Graphics.DrawLine(blueprint.Settings.Drawing.PenLineOfPlane3Y0Z, EndingPoints.Point0.ToPoint(), EndingPoints.Point1.ToPoint());

            Point0.Draw(blueprint);
            Point1.Draw(blueprint);
        }

        public void DrawLineOnly(Blueprint blueprint)
        {
            if (EndingPoints == null || !EndingPoints.IsInitialized)
            {
                EndingPoints = new LineEndingPoints(this.ToLine2D(), blueprint.PlaneX0Z);
            }

            blueprint.Graphics.DrawLine(blueprint.Settings.Drawing.PenLineOfPlane3Y0Z, EndingPoints.Point0.ToPoint(), EndingPoints.Point1.ToPoint());

            Point0.DrawPointsOnly(blueprint);
            Point1.DrawPointsOnly(blueprint);
        }

        public bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            var ln = this.ToGlobalCoordinates(coordinateSystemCenter);
            return ln.IsIncidentalToPoint(mscoords, 35 * distance);
        }

        public PointOfPlane3Y0Z Point0 { get; }

        public PointOfPlane3Y0Z Point1 { get; }

        public double Ky { get; }

        public double Kz { get; }

        public Name Name { get; set; }

        public LineEndingPoints EndingPoints{ get; private set; }
    }
}
