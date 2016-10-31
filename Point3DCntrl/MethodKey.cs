using System;
using System.Linq;

namespace Point3DCntrl
{
    public class MethodKey : IEquatable<MethodKey>
    {
        public Guid Id { get; }
        public string MethodName { get; set; }

        public MethodKey()
        {
            Id = Guid.NewGuid();
        }
        public bool Equals(MethodKey other)
        {
            if (Id.Equals(other.Id))
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return (int)Math.Pow(Id.ToByteArray().FirstOrDefault(), 2);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MethodKey);
        }
    }
}
