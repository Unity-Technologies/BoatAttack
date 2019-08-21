using System;

namespace Unity.Entities
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class RegisterGenericComponentTypeAttribute : Attribute
    {
        public Type ConcreteType;

        public RegisterGenericComponentTypeAttribute(Type type)
        {
            ConcreteType = type;
        }
    }
}