using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Analyze;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Objects.Lines
{
    /// <summary>
    /// Создание проекции линии на плоскость X0Y
    /// </summary>
    public class CreateLineOfPlane1X0Y : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas can, DrawS settings, Storage strg)
        {
            var obj = Create(pt, frameCenter, can, settings, strg);
            if (obj == null) return;
            strg.AddToCollection(obj);
            can.Update(strg);
        }
        public LineOfPlane1X0Y Create(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
        {
            if (!PointOfPlane1X0Y.IsCreatable(pt, frameCenter)) return null;
            var ptOfPlane = new PointOfPlane1X0Y(pt, frameCenter);
            if (strg.TempObjects.Count == 0)
            {
                ptOfPlane.SetName(GraphicsControl.NmGenerator.Generate());
                strg.TempObjects.Add(ptOfPlane);
                strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                return null;
            }
            if (Analyze.PointPos.Coincidence((PointOfPlane1X0Y)strg.TempObjects.First(), new PointOfPlane1X0Y(pt, frameCenter))) return null;
            var source = new LineOfPlane1X0Y((PointOfPlane1X0Y)strg.TempObjects.First(), new PointOfPlane1X0Y(pt, frameCenter), frameCenter, can.PlaneX0Y);
            source.SetName(strg.TempObjects.First().GetName());
            strg.TempObjects.Clear();
            return source;
        }
    }
}
