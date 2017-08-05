using GraphicsModule.Geometry.Structures;

namespace GraphicsModule.Geometry.Interfaces
{
    public interface ILine : IObject
    {
        /// <summary>
        /// Конечные точки прямой в рамках указанной области
        /// </summary>
        LineEndingPoints EndingPoints { get; }
    }
}
