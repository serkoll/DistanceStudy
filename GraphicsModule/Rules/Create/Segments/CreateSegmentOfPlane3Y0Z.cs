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
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings settings, Storage storage)
        {
            var obj = Create(pt, frameCenter, blueprint, settings, storage);
            if (obj == null)
            {
                return;
            }
            storage.AddToCollection(obj);
            blueprint.Update(storage);
        }
        public SegmentOfPlane3Y0Z Create(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings setting, Storage strg)
        {
            if (!PointOfPlane3Y0Z.IsCreatable(pt, frameCenter))
            {
                return null;
            }
            var ptOfPlane = new PointOfPlane3Y0Z(pt, frameCenter);
            if (strg.TempObjects.Count == 0)
            {
                ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
                strg.TempObjects.Add(ptOfPlane);
                strg.DrawLastAddedToTempObjects(blueprint);
                return null;
            }
            ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
            if (ptOfPlane.IsCoincides((PointOfPlane3Y0Z)strg.TempObjects.First()))
            {
                return null;
            }
            var source = new SegmentOfPlane3Y0Z((PointOfPlane3Y0Z) strg.TempObjects.First(), ptOfPlane) {Name = strg.TempObjects[0].Name};
            strg.TempObjects.Clear();
            return source;
        }
    }
}
