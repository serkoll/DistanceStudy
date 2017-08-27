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
        public void AddToStorageAndDraw(Point pt, Blueprint blueprint)
        {
            var source = Create(pt, blueprint);
            if (source == null)
                return;

            blueprint.Storage.AddToCollection(source);
            blueprint.Storage.DrawLastAddedToObjects(blueprint);
        }

        public PointOfPlane1X0Y Create(Point pt, Blueprint blueprint)
        {
            return PointOfPlane1X0Y.IsCreatable(pt, blueprint.CoordinateSystemCenterPoint)
                ? new PointOfPlane1X0Y(pt, blueprint.CoordinateSystemCenterPoint) { Name = GraphicsControl.NamesGenerator.Generate() }
                : null;
        }
    }
}
