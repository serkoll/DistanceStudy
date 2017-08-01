using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Create.Points
{
    /// <summary>
    /// Создание проекции точки на плоскость X0Y
    /// </summary>
    public class CreatePointOfPlane1X0Y : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings settings, Storage storage)
        {
            var source = Create(pt, frameCenter, blueprint, settings, storage);
            if (source == null)
            {
                return;
            }
            storage.AddToCollection(source);
            storage.DrawLastAddedToObjects(blueprint);
        }
        public PointOfPlane1X0Y Create(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings setting, Storage strg)
        {
            return PointOfPlane1X0Y.IsCreatable(pt, frameCenter)
                ? new PointOfPlane1X0Y(pt, frameCenter) { Name = GraphicsControl.NamesGenerator.Generate() }
                : null;
        }
    }
}
