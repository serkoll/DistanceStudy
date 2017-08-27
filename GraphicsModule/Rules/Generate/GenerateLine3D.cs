using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Generate
{
    public class GenerateLine3D : ICreate
    {
        private Line3D _source;

        public void AddToStorageAndDraw(Point pt, Blueprint blueprint)
        {
            new SelectLineOfPlane().Execute(pt, blueprint);
            var selected = blueprint.Storage.SelectedObjects;
            if (selected.Count > 1)
            {
                if (ReferenceEquals(selected[0].GetType(), selected[1].GetType()))
                {
                    selected.Remove(selected[0]);
                    blueprint.Update();
                    return;
                }
                if ((_source = ObjectsCreator.Line3D().Create(selected.Cast<ILineOfPlane>().ToList())) != null)
                {
                    _source.SpecifyBoundaryPoints(blueprint.CoordinateSystemCenterPoint, blueprint.PlaneX0Y, blueprint.PlaneX0Z, blueprint.PlaneY0Z);
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
