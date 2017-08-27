using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Create.Points
{
    /// <summary>
    /// Создание 2Д точки
    /// </summary>
    public class CreatePoint2D : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Blueprint blueprint)
        {
            blueprint.Storage.AddToCollection(Create(pt));
            blueprint.Storage.DrawLastAddedToObjects(blueprint);
        }

        public Point2D Create(Point pt)
        {
            return new Point2D(pt)
            {
                Name = GraphicsControl.NamesGenerator.Generate()
            };
        }
    }
}
