using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Generate
{
    public class GenerateLine3D : ICreate
    {
        private Line3D _source;

        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas canvas, DrawSettings settings, Storage storage)
        {
            new SelectLineOfPlane().Execute(pt, storage, canvas);
            if (storage.SelectedObjects.Count > 1)
            {
                if (ReferenceEquals(storage.SelectedObjects[0].GetType(), storage.SelectedObjects[1].GetType()))
                {
                    storage.SelectedObjects.Remove(storage.SelectedObjects[0]);
                    canvas.Update(storage);
                    return;
                }
                if ((_source = Line3D.Create(storage.SelectedObjects)) != null)
                {
                    _source.SpecifyBoundaryPoints(frameCenter, canvas.PlaneX0Y, canvas.PlaneX0Z, canvas.PlaneY0Z);
                    storage.Objects.Remove(storage.SelectedObjects[0]);
                    storage.Objects.Remove(storage.SelectedObjects[1]);
                    storage.SelectedObjects.Clear();
                    canvas.Update(storage);
                    storage.AddToCollection(_source);
                    _source = null;
                    storage.DrawLastAddedToObjects(settings, frameCenter, canvas.Graphics);
                }
                else
                {
                    storage.SelectedObjects.RemoveAt(storage.SelectedObjects.Count - 1);
                    canvas.Update(storage);
                }
            }
            else
            {
                canvas.Update(storage);
            }
        }
    }
}
