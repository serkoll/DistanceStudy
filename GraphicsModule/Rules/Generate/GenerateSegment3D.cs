using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Objects.Segments;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Generate
{
    public class GenerateSegment3D : ICreate
    {
        private Segment3D _source;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Drawing drawing, DrawSettings settings, Storage storage)
        {
            new SelectSegmentOfPlane().Execute(pt, storage, drawing);
            if (storage.SelectedObjects.Count > 1)
            {
                if (ReferenceEquals(storage.SelectedObjects[0].GetType(), storage.SelectedObjects[1].GetType()))
                {
                    storage.SelectedObjects.Remove(storage.SelectedObjects[0]);
                    drawing.Update(storage);
                    return;
                }
                if ((_source = Segment3D.Create(storage.SelectedObjects)) != null)
                {
                    storage.Objects.Remove(storage.SelectedObjects[0]);
                    storage.Objects.Remove(storage.SelectedObjects[1]);
                    storage.SelectedObjects.Clear();
                    drawing.Update(storage);
                    storage.AddToCollection(_source);
                    _source = null;
                    storage.DrawLastAddedToObjects(settings, frameCenter, drawing.Graphics);
                }
                else
                {
                    storage.SelectedObjects.RemoveAt(storage.SelectedObjects.Count - 1);
                    drawing.Update(storage);
                }
            }
            else
            {
                drawing.Update(storage);
            }
        }
    }
}
