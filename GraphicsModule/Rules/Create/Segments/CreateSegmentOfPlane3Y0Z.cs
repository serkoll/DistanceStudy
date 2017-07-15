using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Analyze;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Create.Segments
{
    public class CreateSegmentOfPlane3Y0Z : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas canvas, DrawSettings settings, Storage storage)
        {
            var obj = Create(pt, frameCenter, canvas, settings, storage);
            if (obj == null) return;
            storage.AddToCollection(obj);
            canvas.Update(storage);
        }
        public SegmentOfPlane3Y0Z Create(Point pt, Point frameCenter, Canvas can, DrawSettings setting, Storage strg)
        {
            if (!PointOfPlane3Y0Z.IsCreatable(pt, frameCenter)) return null;
            var ptOfPlane = new PointOfPlane3Y0Z(pt, frameCenter);
            if (strg.TempObjects.Count == 0)
            {
                ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
                strg.TempObjects.Add(ptOfPlane);
                strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                return null;
            }
            if (Analyze.PointsPosition.Coincidence((PointOfPlane3Y0Z)strg.TempObjects[0],
                new PointOfPlane3Y0Z(pt, frameCenter))) return null;
            var source = new SegmentOfPlane3Y0Z((PointOfPlane3Y0Z)strg.TempObjects[0],
                new PointOfPlane3Y0Z(pt, frameCenter));
            source.Name = strg.TempObjects[0].Name;
            strg.TempObjects.Clear();
            return source;
        }
    }
}
