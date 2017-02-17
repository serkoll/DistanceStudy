using System.Drawing;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Analyze;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;
using GraphicsModule.Interfaces;
using GraphicsModule.Settings;


namespace GraphicsModule.Rules.Objects.Segments
{
    /// <summary>
    /// Создание проекции линии на плоскость Y0Z
    /// </summary>
    public class CreateSegmentOfPlane3Y0Z : ICreate
    {
        private SegmentOfPlane3Y0Z _source;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            if (PointOfPlane3Y0Z.Creatable(pt, frameCenter))
            {
                var ptOfPlane = new PointOfPlane3Y0Z(pt, frameCenter);
                if (strg.TempObjects.Count == 0)
                {
                    ptOfPlane.SetName(GraphicsControl.NmGenerator.Generate());
                    strg.TempObjects.Add(ptOfPlane);
                    strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                }
                else
                {
                    if (Analyze.PointPos.Coincidence((PointOfPlane3Y0Z)strg.TempObjects[0], new PointOfPlane3Y0Z(pt, frameCenter))) return;
                    _source = new SegmentOfPlane3Y0Z((PointOfPlane3Y0Z)strg.TempObjects[0], new PointOfPlane3Y0Z(pt, frameCenter));
                    _source.SetName(strg.TempObjects[0].GetName());
                    strg.AddToCollection(_source);
                    _source = null;
                    strg.TempObjects.Clear();
                    can.Update(strg);
                    strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
                }
            }
        }
    }
}
