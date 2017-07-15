using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Analyze;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Create.Segments
{
    public class CreateSegmentOfPlane1X0Y : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Drawing drawing, DrawSettings settings, Storage storage)
        {
            var obj = Create(pt, frameCenter, drawing, settings, storage);
            if (obj == null) return;
            storage.AddToCollection(obj);
            drawing.Update(storage);
        }
        public SegmentOfPlane1X0Y Create(Point pt, Point frameCenter, Drawing can, DrawSettings setting, Storage strg)
        {
            if (!PointOfPlane1X0Y.IsCreatable(pt, frameCenter)) return null;
            var ptOfPlane = new PointOfPlane1X0Y(pt, frameCenter);
            if (strg.TempObjects.Count == 0)
            {
                ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
                strg.TempObjects.Add(ptOfPlane);
                strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                return null;
            }
            if (Analyze.PointsPosition.Coincidence((PointOfPlane1X0Y)strg.TempObjects[0],
                new PointOfPlane1X0Y(pt, frameCenter))) return null;
            var source = new SegmentOfPlane1X0Y((PointOfPlane1X0Y)strg.TempObjects[0],
                new PointOfPlane1X0Y(pt, frameCenter));
            source.Name = strg.TempObjects[0].Name;
            strg.TempObjects.Clear();
            return source;
        }
    }
}
