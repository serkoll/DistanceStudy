using System.Drawing;
using GraphicsModule.Configuration;

namespace GraphicsModule.Geometry.Interfaces
{
    public interface IObject
    {
        Name Name { get; set; }
        void Draw(DrawSettings st, Point frameCenter, Graphics graphics);
        //TODO: параметры
        bool IsSelected(Point mousecoords, float ptR, Point frameCenter, double distance);
        //Name GetName();
        //void SetName(Name name);
    }
}
