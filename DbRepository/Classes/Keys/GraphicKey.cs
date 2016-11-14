using System;

namespace DbRepository.Classes.Keys
{
    public class GraphicKey : IEquatable<GraphicKey>
    {
        public Guid Guid { get; set; }
        public string TypeName { get; set; }
        public bool Equals(GraphicKey other)
        {
            return (other.Guid.Equals(Guid));
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
