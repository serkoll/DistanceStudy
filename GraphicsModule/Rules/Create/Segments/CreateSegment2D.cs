using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Analyze;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Create.Segments
{
    public class CreateSegment2D : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Drawing drawing, DrawSettings settings, Storage storage)
        {
            var obj = Create(pt, frameCenter, drawing, settings, storage);
            if (obj == null)
                return;
            storage.AddToCollection(obj);
            drawing.Update(storage);
        }
        public Segment2D Create(Point pt, Point frameCenter, Drawing can, DrawSettings settings, Storage strg)
        {
            var ptOfPlane = new Point2D(pt);
            if (strg.TempObjects.Count == 0)
            {
                ptOfPlane.Name =GraphicsControl.NamesGenerator.Generate();
                strg.TempObjects.Add(ptOfPlane);
                strg.DrawLastAddedToTempObjects(settings, frameCenter, can.Graphics);
            }
            else
            {
                if (ptOfPlane.IsCoincides((Point2D) strg.TempObjects.First()))
                {
                    return null;
                }
                var source = new Segment2D((Point2D)strg.TempObjects.First(), ptOfPlane);
                source.SetName(strg.TempObjects[0].Name);
                strg.TempObjects.Clear();
                return source;
            }
            return null;
        }
    }
}
