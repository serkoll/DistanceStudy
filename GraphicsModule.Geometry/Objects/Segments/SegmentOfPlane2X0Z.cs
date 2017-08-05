using System.Drawing;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Segments
{
    public class SegmentOfPlane2X0Z : ISegmentOfPlane
    {
        public SegmentOfPlane2X0Z(PointOfPlane2X0Z pt0, PointOfPlane2X0Z pt1)
        {
            Point0 = pt0;
            Point1 = pt1;
            Kx = pt1.X - pt0.X;
            Kz = pt1.Z - pt0.Z;
            Name = new Name();
        }

        public SegmentOfPlane2X0Z(Segment3D segment)
        {
            Point0 = new PointOfPlane2X0Z(segment.Point0.X, segment.Point0.Z);
            Point1 = new PointOfPlane2X0Z(segment.Point1.X, segment.Point1.Z);
        }

        public void Draw(Blueprint blueprint)
        {
            var pt0 = Point0.ToGlobalCoordinates(blueprint.CoordinateSystemCenterPoint);
            var pt1 = Point1.ToGlobalCoordinates(blueprint.CoordinateSystemCenterPoint);

            blueprint.Graphics.DrawLine(blueprint.Settings.Drawing.PenLineOfPlane2X0Z, pt0, pt1);
            Point0.Draw(blueprint);
            Point1.Draw(blueprint);
        } 

        public void DrawSegmentOnly(Blueprint blueprint)
        {
            var pt0 = Point0.ToGlobalCoordinates(blueprint.CoordinateSystemCenterPoint);
            var pt1 = Point1.ToGlobalCoordinates(blueprint.CoordinateSystemCenterPoint);

            blueprint.Graphics.DrawLine(blueprint.Settings.Drawing.PenLineOfPlane2X0Z, pt0, pt1);
            Point0.Draw(blueprint);
            Point1.Draw(blueprint);
        }

        public bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            var sg = this.ToGlobalCoordinates(coordinateSystemCenter);
            return sg.IsIncidentalToPoint(mscoords, 35 * distance);
        }

        public PointOfPlane2X0Z Point0 { get; }

        public PointOfPlane2X0Z Point1 { get; }

        public double Kx { get; set; }

        public double Kz { get; set; }

        public Name Name { get; set; }
    }
}