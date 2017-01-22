using GraphicsModule.Geometry.Objects;
using System;
using GraphicsModule.Geometry.Interfaces;

namespace DbRepository.Classes.Keys
{
    public class GraphicKey : IEquatable<GraphicKey>
    {
        public Guid Guid { get; set; }
        public IObject GraphicObject { get; set; }
        public bool Equals(GraphicKey other)
        {
            if (other != null)
                return (other.Guid.Equals(Guid));
            return false;
        }
        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as GraphicKey);
        }
    }
}
