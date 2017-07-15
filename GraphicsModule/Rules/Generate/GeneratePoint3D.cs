using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Generate
{
    /// <summary>
    /// Генерация 3D точки
    /// </summary>
    public class GeneratePoint3D : ICreate
    {
        private Point3D _source;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Drawing drawing, DrawSettings settings, Storage storage)
        {
            new SelectPointOfPlane().Execute(pt, storage, drawing);
            if (storage.SelectedObjects.Count > 1)
            {
                if (ReferenceEquals(storage.SelectedObjects[0].GetType(), storage.SelectedObjects[1].GetType()))
                {
                    storage.SelectedObjects.Remove(storage.SelectedObjects[0]);
                    drawing.Update(storage);
                    return;
                }
                if ((_source = Point3D.Create(storage.SelectedObjects)) != null)
                {
                    storage.Objects.Remove(storage.SelectedObjects[0]);
                    storage.Objects.Remove(storage.SelectedObjects[1]);
                    _source.Name = GraphicsControl.NamesGenerator.Generate();
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
