using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Segments
{
    public class SegmentOfPlane1X0Y : ISegmentOfPlane
    {
        public SegmentOfPlane1X0Y(PointOfPlane1X0Y pt0, PointOfPlane1X0Y pt1)
        {
            Point0 = pt0;
            Point1 = pt1;
            Kx = pt1.X - pt0.X;
            Ky = pt1.Y - pt0.Y;
            Name = new Name();
        }

        public SegmentOfPlane1X0Y(Segment3D segment)
        {
            Point0 = new PointOfPlane1X0Y(segment.Point0.X, segment.Point0.Y);
            Point1 = new PointOfPlane1X0Y(segment.Point1.X, segment.Point1.Y);
        }

        public void Draw(Blueprint blueprint)
        {
            var pt0 = Point0.ToGlobalCoordinates(blueprint.CoordinateSystemCenterPoint);
            var pt1 = Point1.ToGlobalCoordinates(blueprint.CoordinateSystemCenterPoint);

            blueprint.Graphics.DrawLine(blueprint.Settings.Drawing.PenLineOfPlane1X0Y, pt0, pt1);
            Point0.Draw(blueprint);
            Point1.Draw(blueprint);
        }

        public void DrawSegmentOnly(Blueprint blueprint)
        {
            var pt0 = Point0.ToGlobalCoordinates(blueprint.CoordinateSystemCenterPoint);
            var pt1 = Point1.ToGlobalCoordinates(blueprint.CoordinateSystemCenterPoint);

            blueprint.Graphics.DrawLine(blueprint.Settings.Drawing.PenLineOfPlane1X0Y, pt0, pt1);
            Point0.DrawPointsOnly(blueprint);
            Point1.DrawPointsOnly(blueprint);
        }

        public bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            var sg = this.ToGlobalCoordinates(coordinateSystemCenter);
            return sg.IsIncidentalToPoint(mscoords, 35 * distance);
        }

        public PointOfPlane1X0Y Point0 { get; }

        public PointOfPlane1X0Y Point1 { get; }

        public double Kx { get; }

        public double Ky { get; }

        public Name Name { get; set; }
    }
}