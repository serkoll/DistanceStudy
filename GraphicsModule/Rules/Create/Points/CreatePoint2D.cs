using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Create.Points
{
    /// <summary>
    /// Создание 2Д точки
    /// </summary>
    public class CreatePoint2D : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Drawing drawing, DrawSettings settings, Storage storage)
        {
            storage.AddToCollection(Create(pt, frameCenter, drawing, settings, storage));
            storage.DrawLastAddedToObjects(settings, frameCenter, drawing.Graphics);
        }
        public Point2D Create(Point pt, Point frameCenter, Drawing can, DrawSettings setting, Storage strg)
        {
            return new Point2D(pt)
            {
                Name = GraphicsControl.NamesGenerator.Generate()
            };
        }
    }
}
