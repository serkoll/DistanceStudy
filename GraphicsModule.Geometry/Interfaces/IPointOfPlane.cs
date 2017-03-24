using System.Drawing;

namespace GraphicsModule.Geometry.Interfaces
{
    public interface IPointOfPlane : IObject
    {
        void Draw(Pen pen, float poitRaduis, Point frameCenter, Graphics graphics);
    }
}
