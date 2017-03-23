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
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas can, DrawS settings, Storage strg)
        {
            strg.AddToCollection(Create(pt, frameCenter, can, settings, strg));
            strg.DrawLastAddedToObjects(settings, frameCenter, can.Graphics);
        }
        public Point2D Create(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
        {
            var source = new Point2D(pt);
            source.SetName(GraphicsControl.NmGenerator.Generate());
            return source;
        }
    }
}
