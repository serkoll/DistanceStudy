using System;
using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Objects.Points
{
    /// <summary>
    /// Генерация 3D точки
    /// </summary>
    public class GeneratePoint3D : ICreate
    {
        private Point3D _source;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas canvas, DrawS settings, Storage storage)
        {
            new SelectPointOfPlane().Execute(pt, storage, canvas);
            if (storage.SelectedObjects.Count > 1)
            {
                if (ReferenceEquals(storage.SelectedObjects[0].GetType(), storage.SelectedObjects[1].GetType()))
                {
                    storage.SelectedObjects.Remove(storage.SelectedObjects[0]);
                    canvas.Update(storage);
                    return;
                }
                if ((_source = Point3D.Create(storage.SelectedObjects)) != null)
                {
                    storage.Objects.Remove(storage.SelectedObjects[0]);
                    storage.Objects.Remove(storage.SelectedObjects[1]);
                    _source.SetName(GraphicsControl.NmGenerator.Generate());
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
