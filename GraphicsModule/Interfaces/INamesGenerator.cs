using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Interfaces;

namespace GraphicsModule.Interfaces
{
    public interface INamesGenerator
    {
        Name Generate(IObject obj);
    }
}
