using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Generate
{
    public class GenerateLine3D : ICreate
    {
        private Line3D _source;

        public void AddToStorageAndDraw(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings settings, Storage storage)
        {
            new SelectLineOfPlane().Execute(pt, storage, blueprint);
            if (storage.SelectedObjects.Count > 1)
            {
                if (ReferenceEquals(storage.SelectedObjects[0].GetType(), storage.SelectedObjects[1].GetType()))
                {
                    storage.SelectedObjects.Remove(storage.SelectedObjects[0]);
                    blueprint.Update(storage);
                    return;
                }
                if ((_source = Line3D.Create(storage.SelectedObjects)) != null)
                {
                    _source.SpecifyBoundaryPoints(frameCenter, blueprint.PlaneX0Y, blueprint.PlaneX0Z, blueprint.PlaneY0Z);
                    storage.Objects.Remove(storage.SelectedObjects[0]);
                    storage.Objects.Remove(storage.SelectedObjects[1]);
                    storage.SelectedObjects.Clear();
                    blueprint.Update(storage);
                    storage.AddToCollection(_source);
                    _source = null;
                    storage.DrawLastAddedToObjects(blueprint);
                }
                else
                {
                    storage.SelectedObjects.RemoveAt(storage.SelectedObjects.Count - 1);
                    blueprint.Update(storage);
                }
            }
            else
            {
                blueprint.Update(storage);
            }
        }
    }
}
