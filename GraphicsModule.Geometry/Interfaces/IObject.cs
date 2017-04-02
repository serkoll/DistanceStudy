using System.Drawing;
using GraphicsModule.Configuration;

namespace GraphicsModule.Geometry.Interfaces
{
    public interface IObject
    {
        void Draw(DrawSettings settings, Point frameCenter, Graphics graphics);
        bool IsSelected(Point mousecoords, float ptR, Point frameCenter, double distance);
        Name Name { get; set; }
        Name GetName();
        void SetName(Name name);
    }
}
