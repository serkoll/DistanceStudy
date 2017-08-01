using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Create.Lines
{
    public class CreateLine2D : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings settings, Storage storage)
        {
            var obj = Create(pt, frameCenter, blueprint, settings, storage);
            if (obj == null)
            {
                return;
            }
            storage.AddToCollection(obj);
            blueprint.Update(storage);
        }
        public Line2D Create(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings settings, Storage strg)
        {
            var ptOfPlane = new Point2D(pt);

            if (strg.TempObjects.Count == 0)
            {
                ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
                strg.TempObjects.Add(ptOfPlane);
                strg.DrawLastAddedToTempObjects(blueprint);
            }
            else
            {
                if (ptOfPlane.IsCoincides((Point2D)strg.TempObjects.First()))
                {
                    return null;
                }
                //TODO: другой конструктор
                var source = new Line2D((Point2D)strg.TempObjects.First(), ptOfPlane, blueprint.PictureBox.ClientRectangle);
                source.Name = strg.TempObjects.First().Name;
                strg.TempObjects.Clear();
                return source;
            }

            return null;
        }
    }
}