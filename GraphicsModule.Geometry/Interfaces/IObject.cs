using System.Drawing;
using GraphicsModule.Configuration;

namespace GraphicsModule.Geometry.Interfaces
{
    public interface IObject
    {
        Name Name { get; set; }

        void Draw(DrawSettings settings, Point coordinateSystemCenter, Graphics graphics);

        bool IsSelected(Point mousecoords, float ptR, Point coordinateSystemCenter, double distance);
    }
}
