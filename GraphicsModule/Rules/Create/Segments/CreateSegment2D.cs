using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Create.Segments
{
    public class CreateSegment2D : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Blueprint blueprint)
        {
            var obj = Create(pt, blueprint);
            if (obj == null)
                return;
            blueprint.Storage.AddToCollection(obj);
            blueprint.Update();
        }

        public Segment2D Create(Point pt, Blueprint blueprint)
        {
            var ptOfPlane = new Point2D(pt);
            var tempObjects = blueprint.Storage.TempObjects;
            if (tempObjects.Count == 0)
            {
                ptOfPlane.Name =GraphicsControl.NamesGenerator.Generate();
                tempObjects.Add(ptOfPlane);
                blueprint.Storage.DrawLastAddedToTempObjects(blueprint);
            }
            else
            {
                if (ptOfPlane.IsCoincides((Point2D) tempObjects.First()))
                {
                    return null;
                }
                var source = new Segment2D((Point2D)tempObjects.First(), ptOfPlane);
                source.SetName(tempObjects[0].Name);
                tempObjects.Clear();
                return source;
            }
            return null;
        }
    }
}
