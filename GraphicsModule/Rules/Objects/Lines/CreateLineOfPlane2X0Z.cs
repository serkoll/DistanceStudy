using System.Drawing;
using System.Linq;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Analyze;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;
using GraphicsModule.Settings;

namespace GraphicsModule.Rules.Objects.Lines
{
    /// <summary>
    /// Создание проекции линии на плоскость X0Y
    /// </summary>
    public class CreateLineOfPlane2X0Z : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS settings, Storage strg)
        {
            var obj = Create(pt, frameCenter, can, settings, strg);
            if (obj == null) return;
            strg.AddToCollection(obj);
            can.Update(strg);
        }
        public LineOfPlane2X0Z Create(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            if (!PointOfPlane2X0Z.Creatable(pt, frameCenter)) return null;
            var ptOfPlane = new PointOfPlane2X0Z(pt, frameCenter);
            if (strg.TempObjects.Count == 0)
            {
                ptOfPlane.SetName(GraphicsControl.NmGenerator.Generate());
                strg.TempObjects.Add(ptOfPlane);
                strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                return null;
            }
            if (Analyze.PointPos.Coincidence((PointOfPlane2X0Z)strg.TempObjects.First(), new PointOfPlane2X0Z(pt, frameCenter))) return null;
            var source = new LineOfPlane2X0Z((PointOfPlane2X0Z)strg.TempObjects.First(), new PointOfPlane2X0Z(pt, frameCenter), frameCenter, can.PlaneX0Z);
            source.SetName(strg.TempObjects.First().GetName());
            strg.TempObjects.Clear();
            return source;
        }
    }
}
