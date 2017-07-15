using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Analyze;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Create.Lines
{
    public class CreateLine2D : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Drawing drawing, DrawSettings settings, Storage storage)
        {
            var obj = Create(pt, frameCenter, drawing, settings, storage);
            if (obj == null)
            {
                return;
            }
            storage.AddToCollection(obj);
            drawing.Update(storage);
        }
        public Line2D Create(Point pt, Point frameCenter, Drawing can, DrawSettings settings, Storage strg)
        {
            var ptOfPlane = new Point2D(pt);

            if (strg.TempObjects.Count == 0)
            {
                ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
                strg.TempObjects.Add(ptOfPlane);
                strg.DrawLastAddedToTempObjects(settings, frameCenter, can.Graphics);
            }
            else
            {
                if (ptOfPlane.IsCoincides((Point2D)strg.TempObjects.First()))
                {
                    return null;
                }
                var source = new Line2D((Point2D)strg.TempObjects.First(), ptOfPlane, can.PictureBox);
                source.Name = strg.TempObjects.First().Name;
                strg.TempObjects.Clear();
                return source;
            }

            return null;
        }
    }
}