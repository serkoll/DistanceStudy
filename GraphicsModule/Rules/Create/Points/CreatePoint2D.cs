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
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings settings, Storage storage)
        {
            storage.AddToCollection(Create(pt, frameCenter, blueprint, settings, storage));
            storage.DrawLastAddedToObjects(blueprint);
        }
        public Point2D Create(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings setting, Storage strg)
        {
            return new Point2D(pt)
            {
                Name = GraphicsControl.NamesGenerator.Generate()
            };
        }
    }
}
