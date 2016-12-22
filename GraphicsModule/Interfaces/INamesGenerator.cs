using GraphicsModule.Geometry.Interfaces;

namespace GraphicsModule.Interfaces
{
    public interface INamesGenerator
    {
        string Generate(IObject obj);
    }
}
