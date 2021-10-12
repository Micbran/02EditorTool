using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public interface ITypedSerializationSurrogate : ISerializationSurrogate
{
    public Type GetBaseType();
}
