using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects;
using GraphicsModule.Geometry.Objects.Segments;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Generate
{
    public class GenerateSegment3D : ICreate
    {
        private Segment3D _source;
        public void AddToStorageAndDraw(Point pt, Blueprint blueprint)
        {
            new SelectSegmentOfPlane().Execute(pt, blueprint);
            var selected = blueprint.Storage.SelectedObjects;
            if (selected.Count > 1)
            {
                if (ReferenceEquals(selected[0].GetType(), selected[1].GetType()))
                {
                    selected.Remove(selected[0]);
                    blueprint.Update();
                    return;
                }
                if ((_source = ObjectsCreator.Segment3D().Create(selected.Cast<ISegmentOfPlane>().ToList())) != null)
                {
                    var objects = blueprint.Storage.Objects;
                    objects.Remove(selected[0]);
                    objects.Remove(selected[1]);
                    selected.Clear();
                    blueprint.Update();
                    blueprint.Storage.AddToCollection(_source);
                    _source = null;
                    blueprint.Storage.DrawLastAddedToObjects(blueprint);
                }
                else
                {
                    selected.RemoveAt(selected.Count - 1);
                    blueprint.Update();
                }
            }
            else
            {
                blueprint.Update();
            }
        }
    }
}
