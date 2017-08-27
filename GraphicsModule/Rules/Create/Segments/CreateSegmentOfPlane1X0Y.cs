using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Create.Segments
{
    public class CreateSegmentOfPlane1X0Y : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Blueprint blueprint)
        {
            var obj = Create(pt, blueprint);
            if (obj == null)
                return;

            blueprint.Storage.AddToCollection(obj);
            blueprint.Update();
        }

        public SegmentOfPlane1X0Y Create(Point pt, Blueprint blueprint)
        {
            return Create(pt, blueprint.CoordinateSystemCenterPoint, blueprint);
        }

        private SegmentOfPlane1X0Y Create(Point pt, Point frameCenter, Blueprint blueprint)
        {
            if (!PointOfPlane1X0Y.IsCreatable(pt, frameCenter))
            {
                return null;
            }

            var ptOfPlane = new PointOfPlane1X0Y(pt, frameCenter);
            var tempObjects = blueprint.Storage.TempObjects;
            if (tempObjects.Count == 0)
            {
                ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
                tempObjects.Add(ptOfPlane);
                blueprint.Storage.DrawLastAddedToTempObjects(blueprint);
                return null;
            }

            if (ptOfPlane.IsCoincides((PointOfPlane1X0Y) tempObjects.First()))
            {
                return null;
            }
            ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
            var source = new SegmentOfPlane1X0Y((PointOfPlane1X0Y) tempObjects.First(), ptOfPlane);
            tempObjects.Clear();
            return source;
        }
    }
}
