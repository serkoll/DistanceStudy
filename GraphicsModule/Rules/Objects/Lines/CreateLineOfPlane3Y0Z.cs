using System.Drawing;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Analyze;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;
using GraphicsModule.Settings;

namespace GraphicsModule.Rules.Objects
{
    /// <summary>
    /// Создание проекции линии на плоскость X0Y
    /// </summary>
    public class CreateLineOfPlane3Y0Z : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS settings, Storage strg)
        {
            var obj = Create(pt, frameCenter, can, settings, strg);
            if (obj == null) return;
            strg.AddToCollection(obj);
            can.Update(strg);
        }
        public LineOfPlane3Y0Z Create(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            if (PointOfPlane3Y0Z.Creatable(pt, frameCenter))
            {
                var ptOfPlane = new PointOfPlane3Y0Z(pt, frameCenter);
                if (strg.TempObjects.Count == 0)
                {
                    ptOfPlane.SetName(GraphicsControl.NmGenerator.Generate());
                    strg.TempObjects.Add(ptOfPlane);
                    strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                    return null;
                }
                else
                {
                    if (Analyze.PointPos.Coincidence((PointOfPlane3Y0Z)strg.TempObjects[0],
                        new PointOfPlane3Y0Z(pt, frameCenter))) return null;
                    var _source = new LineOfPlane3Y0Z((PointOfPlane3Y0Z)strg.TempObjects[0],
                        new PointOfPlane3Y0Z(pt, frameCenter),
                        frameCenter, can.PlaneX0Y);
                    _source.SetName(strg.TempObjects[0].GetName());
                    strg.TempObjects.Clear();
                    return _source;
                }
            }
            else
                return null;
        }
    }
}
