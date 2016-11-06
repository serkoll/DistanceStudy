using System;

namespace DbRepository.Context
{
    public partial class Task_MethodRef : IEquatable<Task_MethodRef>
    {
        public bool Equals(Task_MethodRef other)
        {
            return Id.Equals(other?.Id);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Task_MethodRef);
        }
    }
}
