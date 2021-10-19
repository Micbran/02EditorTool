namespace SaveLoadSystem
{
    using System;
    using System.Runtime.Serialization;
    using UnityEngine;

    public class QuaternionSerializationSurrogate : ITypedSerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            Quaternion quaternion = (Quaternion)obj;
            info.AddValue("x", quaternion.x);
            info.AddValue("y", quaternion.y);
            info.AddValue("z", quaternion.z);
            info.AddValue("w", quaternion.w);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            Quaternion quaternion = (Quaternion)obj;
            quaternion.x = (float)info.GetValue("x", typeof(float));
            quaternion.y = (float)info.GetValue("y", typeof(float));
            quaternion.z = (float)info.GetValue("z", typeof(float));
            quaternion.w = (float)info.GetValue("w", typeof(float));
            obj = quaternion;
            return obj;
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }

        public Type GetBaseType()
        {
            return typeof(Quaternion);
        }
    }
}
