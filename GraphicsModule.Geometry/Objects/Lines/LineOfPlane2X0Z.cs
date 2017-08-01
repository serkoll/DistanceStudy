using System.Collections.Generic;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Structures;

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
        public LineOfPlane2X0Z(PointOfPlane2X0Z pt0, PointOfPlane2X0Z pt1, Rectangle frame)
        {
            Point0 = pt0;
            Point1 = pt1;
            Kx = pt1.X - pt0.X;
            Kz = pt1.Z - pt0.Z;
            EndingPoints = new LineEndingPoints(this.ToLine2D(), frame);
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
        public void Draw(Blueprint blueprint)
        {
            if (EndingPoints == null || !EndingPoints.IsInitialized)
            {
                EndingPoints = new LineEndingPoints(this.ToLine2D(), blueprint.PlaneX0Z);
            }

            blueprint.Graphics.DrawLine(blueprint.Settings.Drawing.PenLineOfPlane2X0Z, EndingPoints.Point0.ToPoint(), EndingPoints.Point1.ToPoint());

            Point0.Draw(blueprint);
            Point1.Draw(blueprint);
            
        }
        public void DrawLineOnly(Blueprint blueprint)
        {
            if (EndingPoints == null || !EndingPoints.IsInitialized)
            {
                EndingPoints = new LineEndingPoints(this.ToLine2D(), blueprint.PlaneX0Z);
            }

            blueprint.Graphics.DrawLine(blueprint.Settings.Drawing.PenLineOfPlane2X0Z, EndingPoints.Point0.ToPoint(), EndingPoints.Point1.ToPoint());

            Point0.DrawPointsOnly(blueprint);
            Point1.DrawPointsOnly(blueprint);
        }

        public bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            var ln = this.ToGlobalCoordinates(coordinateSystemCenter);
            return ln.IsIncidentalToPoint(mscoords, 35 * distance);
        }

        public PointOfPlane2X0Z Point0 { get; }

        public PointOfPlane2X0Z Point1 { get; }

        public double Kx { get; }

        public double Kz { get; }

        public Name Name { get; set; }

        public LineEndingPoints EndingPoints { get; private set; }
    }
}