using UnityEngine;
using SaveLoadSystem;
using System;
using System.Runtime.Serialization;

public class Vector2SerializationSurrogate : ITypedSerializationSurrogate
{
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    {
        Vector2 v2 = (Vector2)obj;
        info.AddValue("x", v2.x);
        info.AddValue("y", v2.y);
    }

    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
    {
        Vector2 v2 = (Vector2)obj;
        v2.x = (float)info.GetValue("x", typeof(float));
        v2.y = (float)info.GetValue("y", typeof(float));
        obj = v2;
        return obj;
    }

    public override string ToString()
    {
        return this.GetType().Name;
    }

    public Type GetBaseType()
    {
        return typeof(Vector2);
    }
}
