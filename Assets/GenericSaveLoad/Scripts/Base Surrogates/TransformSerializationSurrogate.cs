using System;
using System.Runtime.Serialization;
using UnityEngine;

public class TransformSerializationSurrogate : ITypedSerializationSurrogate
{
    public Type GetBaseType()
    {
        return typeof(Transform);
    }

    public override string ToString()
    {
        return this.GetType().Name;
    }

    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    {
        Transform t = (Transform)obj;
        info.AddValue("xPos", t.position.x);
        info.AddValue("yPos", t.position.y);
        info.AddValue("zPos", t.position.z);

        info.AddValue("xScale", t.localScale.x);
        info.AddValue("yScale", t.localScale.y);
        info.AddValue("zScale", t.localScale.z);

        info.AddValue("xRot", t.rotation.x);
        info.AddValue("yRot", t.rotation.y);
        info.AddValue("zRot", t.rotation.z);
        info.AddValue("wRot", t.rotation.w);
    }

    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
    {
        Transform t = (Transform)obj;
        float tX = (float)info.GetValue("xPos", typeof(float));
        float tY = (float)info.GetValue("yPos", typeof(float));
        float tZ = (float)info.GetValue("zPos", typeof(float));

        float tSX = (float)info.GetValue("xScale", typeof(float));
        float tSY = (float)info.GetValue("yScale", typeof(float));
        float tSZ = (float)info.GetValue("zScale", typeof(float));

        float tRX = (float)info.GetValue("xRot", typeof(float));
        float tRY = (float)info.GetValue("yRot", typeof(float));
        float tRZ = (float)info.GetValue("zRot", typeof(float));
        float tRW = (float)info.GetValue("wRot", typeof(float));

        t.position = new Vector3(tX, tY, tZ);
        t.localScale = new Vector3(tSX, tSY, tSZ);
        t.rotation = new Quaternion(tRX, tRY, tRZ, tRW);

        obj = t;
        return obj;
    }
}
