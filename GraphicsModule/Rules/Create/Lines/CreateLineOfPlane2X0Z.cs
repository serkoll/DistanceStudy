using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Create.Lines
{
    /// <summary>
    /// Создание проекции линии на плоскость X0Y
    /// </summary>
    public class CreateLineOfPlane2X0Z : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Drawing drawing, DrawSettings settings, Storage storage)
        {
            var obj = Create(pt, frameCenter, drawing, settings, storage);
            if (obj == null) return;
            storage.AddToCollection(obj);
            drawing.Update(storage);
        }
        public LineOfPlane2X0Z Create(Point pt, Point frameCenter, Drawing can, DrawSettings setting, Storage strg)
        {
            if (!PointOfPlane2X0Z.IsCreatable(pt, frameCenter)) return null;
            var ptOfPlane = new PointOfPlane2X0Z(pt, frameCenter);
            if (strg.TempObjects.Count == 0)
            {
                ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
                strg.TempObjects.Add(ptOfPlane);
                strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                return null;
            }

            if (ptOfPlane.IsCoincides((PointOfPlane2X0Z) strg.TempObjects.First()))
            {
                return null;
            }
            var source = new LineOfPlane2X0Z((PointOfPlane2X0Z)strg.TempObjects.First(), new PointOfPlane2X0Z(pt, frameCenter), frameCenter);
            source.Name = strg.TempObjects.First().Name;
            strg.TempObjects.Clear();
            return source;
        }
    }
}
