using System.Drawing;

namespace GraphicsModule.Geometry.Objects.Points
{
    public interface IPointOfPlane
    {
        void Draw(Pen pen, float poitRaduis, System.Drawing.Point frameCenter, Graphics graphics);
    }
}
