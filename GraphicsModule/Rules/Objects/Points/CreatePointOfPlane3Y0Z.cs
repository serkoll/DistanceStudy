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
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas canvas, DrawSettings settings, Storage storage)
        {
            var source = Create(pt, frameCenter, canvas, settings, storage);
            if (source == null) return;
            storage.AddToCollection(source);
            storage.DrawLastAddedToObjects(settings, frameCenter, canvas.Graphics);
        }
        public PointOfPlane3Y0Z Create(Point pt, Point frameCenter, Canvas can, DrawSettings setting, Storage strg)
        {
            if (!PointOfPlane3Y0Z.IsCreatable(pt, frameCenter)) return null;
            var source = new PointOfPlane3Y0Z(pt, frameCenter);
            source.SetName(GraphicsControl.NamesGenerator.Generate());
            return source;
        }
    }
}
