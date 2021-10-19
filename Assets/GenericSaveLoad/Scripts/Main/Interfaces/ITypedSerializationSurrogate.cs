namespace SaveLoadSystem
{
    using System;
    using System.Runtime.Serialization;

    public interface ITypedSerializationSurrogate : ISerializationSurrogate
    {
        public Type GetBaseType();
    }
}
