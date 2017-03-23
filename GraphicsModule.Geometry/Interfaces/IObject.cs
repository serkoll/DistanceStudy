using System.Drawing;
using GraphicsModule.Configuration;

namespace GraphicsModule.Geometry.Interfaces
{
    public interface IObject
    {
        void Draw(DrawS st, Point frameCenter, Graphics graphics);
        bool IsSelected(Point mousecoords, float ptR, Point frameCenter, double distance);
        Name GetName();
        void SetName(Name name);
    }
}
