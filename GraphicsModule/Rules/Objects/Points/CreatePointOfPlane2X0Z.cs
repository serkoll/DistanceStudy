using System.Drawing;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;
using GraphicsModule.Settings;

namespace GraphicsModule.Rules.Objects.Points
{
    /// <summary>
    /// Создание проекции точки на плоскость X0Z
    /// </summary>
    public class CreatePointOfPlane2X0Z : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            var source = Create(pt, frameCenter, can, setting, strg);
            if (source == null) return;
            strg.AddToCollection(source);
            strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
        }
        public PointOfPlane2X0Z Create(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            if (!PointOfPlane2X0Z.Creatable(pt, frameCenter)) return null;
            var source = new PointOfPlane2X0Z(pt, frameCenter);
            source.SetName(GraphicsControl.NmGenerator.Generate());
            return source;
        }
    }
}
