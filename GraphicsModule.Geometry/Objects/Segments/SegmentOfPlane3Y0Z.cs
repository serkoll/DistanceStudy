using System.Drawing;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Segments
{
    public class SegmentOfPlane3Y0Z : ISegmentOfPlane
    {
        public SegmentOfPlane3Y0Z(PointOfPlane3Y0Z pt0, PointOfPlane3Y0Z pt1)
        {
            Point0 = pt0;
            Point1 = pt1;
            Ky = pt1.Y - pt0.Y;
            Kz = pt1.Z - pt0.Z;
            Name = new Name();
        }

        public SegmentOfPlane3Y0Z(Segment3D segment)
        {
            Point0 = new PointOfPlane3Y0Z(segment.Point0.Y, segment.Point0.Z);
            Point1 = new PointOfPlane3Y0Z(segment.Point1.Y, segment.Point1.Z);
        }

        public void Draw(Blueprint blueprint)
        {
            var pt0 = Point0.ToGlobalCoordinates(blueprint.CoordinateSystemCenterPoint);
            var pt1 = Point1.ToGlobalCoordinates(blueprint.CoordinateSystemCenterPoint);

            blueprint.Graphics.DrawLine(blueprint.Settings.Drawing.PenLineOfPlane3Y0Z, pt0, pt1);
            Point0.Draw(blueprint);
            Point1.Draw(blueprint);
        }

        public void DrawSegmentOnly(Blueprint blueprint)
        {
            var pt0 = Point0.ToGlobalCoordinates(blueprint.CoordinateSystemCenterPoint);
            var pt1 = Point1.ToGlobalCoordinates(blueprint.CoordinateSystemCenterPoint);

            blueprint.Graphics.DrawLine(blueprint.Settings.Drawing.PenLineOfPlane3Y0Z, pt0, pt1);
            Point0.DrawPointsOnly(blueprint);
            Point1.DrawPointsOnly(blueprint);
        }

        public bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            var sg = this.ToGlobalCoordinates(coordinateSystemCenter);
            return sg.IsIncidentalToPoint(mscoords, 35 * distance);
        }

        public PointOfPlane3Y0Z Point0 { get; }

        public PointOfPlane3Y0Z Point1 { get; }

        public Name Name { get; set; }

        public double Ky { get; }

        public double Kz { get; }
    }
}
