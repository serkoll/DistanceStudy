using System;
using System.Collections.Generic;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Structures;

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

        public LineOfPlane1X0Y(Line3D line)
        {
            Point0 = new PointOfPlane1X0Y(line.Point0.X, line.Point0.Y);
            Point1 = new PointOfPlane1X0Y(line.Point1.X, line.Point1.Y);
            Kx = Point1.X - Point0.X;
            Ky = Point1.Y - Point0.Y;
            EndingPoints = null;
            Name = new Name();
        }

        public void Draw(Blueprint blueprint)
        {
            if (EndingPoints == null || !EndingPoints.IsInitialized)
            {
                EndingPoints = new LineEndingPoints(this.ToGlobalCoordinates(blueprint.CoordinateSystemCenterPoint), blueprint.PlaneX0Y);
            }

            blueprint.Graphics.DrawLine(blueprint.Settings.Drawing.PenLineOfPlane1X0Y, EndingPoints.Point0.ToPoint(), EndingPoints.Point1.ToPoint());

            Point0.Draw(blueprint);
            Point1.Draw(blueprint);
        }

        [Obsolete]
        public void DrawLineOnly(Blueprint blueprint)
        {
            if (EndingPoints == null || !EndingPoints.IsInitialized)
            {
                EndingPoints = new LineEndingPoints(this.ToLine2D(), blueprint.PlaneX0Y);
            }

            blueprint.Graphics.DrawLine(blueprint.Settings.Drawing.PenLineOfPlane1X0Y, EndingPoints.Point0.ToPoint(), EndingPoints.Point1.ToPoint());

            Point0.DrawPointsOnly(blueprint);
            Point1.DrawPointsOnly(blueprint);
            
        }

        public bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            var ln = this.ToGlobalCoordinates(coordinateSystemCenter);
            return ln.IsIncidentalToPoint(mscoords, 35 * distance);
        }

        public PointOfPlane1X0Y Point0 { get; }

        public PointOfPlane1X0Y Point1 { get; }

        public double Kx { get; }

        public double Ky { get; }

        public Name Name { get; set; }
        
        /// <summary>
        /// For internal use
        /// </summary>
        public LineEndingPoints EndingPoints { get; private set; }
    }
}