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
    /// Создание проекции линии на плоскость X0Y
    /// </summary>
    public class CreateSegmentOfPlane1X0Y : ICreate
    {
        private SegmentOfPlane1X0Y _source;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            if (PointOfPlane1X0Y.Creatable(pt, frameCenter))
            {
                var ptOfPlane = new PointOfPlane1X0Y(pt, frameCenter);
                if (strg.TempObjects.Count == 0)
                {
                    ptOfPlane.SetName(GraphicsControl.NmGenerator.Generate());
                    strg.TempObjects.Add(ptOfPlane);
                    strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                }
                else
                {
                    if (Analyze.PointPos.Coincidence((PointOfPlane1X0Y)strg.TempObjects[0],
                        new PointOfPlane1X0Y(pt, frameCenter))) return;
                    _source = new SegmentOfPlane1X0Y((PointOfPlane1X0Y)strg.TempObjects[0], new PointOfPlane1X0Y(pt, frameCenter));
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
