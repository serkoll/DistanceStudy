using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Objects.Points
{
    /// <summary>
    /// Создание 2Д точки
    /// </summary>
    public class CreatePoint2D : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas canvas, DrawSettings settings, Storage storage)
        {
            storage.AddToCollection(Create(pt, frameCenter, canvas, settings, storage));
            storage.DrawLastAddedToObjects(settings, frameCenter, canvas.Graphics);
        }
        public Point2D Create(Point pt, Point frameCenter, Canvas can, DrawSettings setting, Storage strg)
        {
            var source = new Point2D(pt);
            source.SetName(GraphicsControl.NamesGenerator.Generate());
            return source;
        }
    }
}
