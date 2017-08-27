using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects;
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
        public void AddToStorageAndDraw(Point pt, Blueprint blueprint)
        {
            new SelectPointOfPlane().Execute(pt, blueprint);
            var selected = blueprint.Storage.SelectedObjects;
            if (selected.Count > 1)
            {
                if (ReferenceEquals(selected[0].GetType(), selected[1].GetType()))
                {
                    selected.Remove(selected[0]);
                    blueprint.Update();
                    return;
                }
                if ((_source = ObjectsCreator.Point3D().Create(selected.Cast<IPointOfPlane>().ToList())) != null)
                {
                    var objects = blueprint.Storage.Objects;
                    objects.Remove(selected[0]);
                    objects.Remove(selected[1]);
                    _source.Name = GraphicsControl.NamesGenerator.Generate();
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
