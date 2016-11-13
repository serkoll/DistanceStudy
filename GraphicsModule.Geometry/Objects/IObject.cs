using System.Drawing;
using GraphicsModule.Geometry.Settings;
using GraphicsModule.Geometry.Settingss;

namespace GraphicsModule.Geometry.Objects
{
    public interface IObject
    {
        void Draw(DrawS st, System.Drawing.Point frameCenter, Graphics graphics);
        bool IsSelected(System.Drawing.Point mousecoords, float ptR, System.Drawing.Point frameCenter, double distance);
    }
}
