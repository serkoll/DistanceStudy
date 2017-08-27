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
    public class CreateSegmentOfPlane3Y0Z : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Blueprint blueprint)
        {
            var obj = Create(pt, blueprint);
            if (obj == null)
                return;

            blueprint.Storage.AddToCollection(obj);
            blueprint.Update();
        }

        public SegmentOfPlane3Y0Z Create(Point pt, Blueprint blueprint)
        {
            return Create(pt, blueprint.CoordinateSystemCenterPoint, blueprint);
        }

        private SegmentOfPlane3Y0Z Create(Point pt, Point frameCenter, Blueprint blueprint)
        {
            if (!PointOfPlane3Y0Z.IsCreatable(pt, frameCenter))
                return null;

            var tempObjects = blueprint.Storage.TempObjects;
            var ptOfPlane = new PointOfPlane3Y0Z(pt, frameCenter);
            if (tempObjects.Count == 0)
            {
                ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
                tempObjects.Add(ptOfPlane);
                blueprint.Storage.DrawLastAddedToTempObjects();
                return null;
            }

            ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
            if (ptOfPlane.IsCoincides((PointOfPlane3Y0Z)tempObjects.First()))
                return null;

            var source = new SegmentOfPlane3Y0Z((PointOfPlane3Y0Z) tempObjects.First(), ptOfPlane) {Name = tempObjects[0].Name};
            tempObjects.Clear();
            return source;
        }
    }
}
