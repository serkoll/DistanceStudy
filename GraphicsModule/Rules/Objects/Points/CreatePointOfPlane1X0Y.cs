using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Objects.Points
{
    /// <summary>
    /// Создание проекции точки на плоскость X0Y
    /// </summary>
    public class CreatePointOfPlane1X0Y : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas can, DrawS settings, Storage strg)
        {
            var source = Create(pt, frameCenter, can, settings, strg);
            if (source == null) return;
            strg.AddToCollection(source);
            strg.DrawLastAddedToObjects(settings, frameCenter, can.Graphics);
        }
        public PointOfPlane1X0Y Create(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
        {
            if (!PointOfPlane1X0Y.IsCreatable(pt, frameCenter)) return null;
            var source = new PointOfPlane1X0Y(pt, frameCenter);
            source.SetName(GraphicsControl.NmGenerator.Generate());
            return source;
        }
    }
}
