using System.Drawing;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Analyze;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;
using GraphicsModule.Interfaces;
using GraphicsModule.Settings;


namespace GraphicsModule.Rules.Objects.Segments
{
    public class CreateSegmentOfPlane3Y0Z : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS settings, Storage strg)
        {
            var obj = Create(pt, frameCenter, can, settings, strg);
            if (obj == null) return;
            strg.AddToCollection(obj);
            can.Update(strg);
        }
        public SegmentOfPlane3Y0Z Create(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            if (!PointOfPlane3Y0Z.Creatable(pt, frameCenter)) return null;
            var ptOfPlane = new PointOfPlane3Y0Z(pt, frameCenter);
            if (strg.TempObjects.Count == 0)
            {
                ptOfPlane.SetName(GraphicsControl.NmGenerator.Generate());
                strg.TempObjects.Add(ptOfPlane);
                strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                return null;
            }
            if (Analyze.PointPos.Coincidence((PointOfPlane3Y0Z)strg.TempObjects[0],
                new PointOfPlane3Y0Z(pt, frameCenter))) return null;
            var source = new SegmentOfPlane3Y0Z((PointOfPlane3Y0Z)strg.TempObjects[0],
                new PointOfPlane3Y0Z(pt, frameCenter));
            source.SetName(strg.TempObjects[0].GetName());
            strg.TempObjects.Clear();
            return source;
        }
    }
}
