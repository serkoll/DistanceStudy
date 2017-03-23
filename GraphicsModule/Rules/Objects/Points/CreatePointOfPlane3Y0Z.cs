using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Objects.Points
{
    /// <summary>
    /// Создание проекции точки на плоскость X0Z
    /// </summary>
    public class CreatePointOfPlane3Y0Z : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas can, DrawS settings, Storage strg)
        {
            var source = Create(pt, frameCenter, can, settings, strg);
            if (source == null) return;
            strg.AddToCollection(source);
            strg.DrawLastAddedToObjects(settings, frameCenter, can.Graphics);
        }
        public PointOfPlane3Y0Z Create(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
        {
            if (!PointOfPlane3Y0Z.IsCreatable(pt, frameCenter)) return null;
            var source = new PointOfPlane3Y0Z(pt, frameCenter);
            source.SetName(GraphicsControl.NmGenerator.Generate());
            return source;
        }
    }
}
