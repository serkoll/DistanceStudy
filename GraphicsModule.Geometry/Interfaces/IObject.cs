using System.Drawing;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Interfaces
{
    public interface IObject
    {
        void Draw(DrawS st, System.Drawing.Point frameCenter, Graphics graphics);
        bool IsSelected(System.Drawing.Point mousecoords, float ptR, System.Drawing.Point frameCenter, double distance);
    }
}
