using System.Drawing;

namespace GraphicsModule.Geometry.Interfaces
{
    public interface IObject : IDraw
    {
        Name Name { get; set; }

        bool IsSelected(Point mousecoords, Point coordinateSystemCenter, double distance);
    }
}
