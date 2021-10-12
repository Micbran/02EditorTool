using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class SaveLoadPreferences : ScriptableObject
{
    public string saveFolder;
    public string saveExtension;
    public string defaultSaveName;

    public List<ITypedSerializationSurrogate> serilizationHandlers;

    public string VerifySaveFolder(string newSaveFolder)
    {
        return null;
    }

    public string VerifySaveExtension(string newSaveExtension)
    {
        return null;
    }

    public string VerifyDefaultSaveName(string newDefaultSaveName)
    {
        return null;
    }

    public override string ToString()
    {
        return $"Save Folder: {this.saveFolder} :: Save Extension {this.saveExtension} :: Default Save Name {this.defaultSaveName}" +
               $"\nSerialization Handlers: {string.Join(", ", this.serilizationHandlers)}";
    }
}
