namespace SaveLoadSystem
{
    using System.Collections.Generic;
    using System.IO;
    using UnityEngine;

    public class SaveLoadPreferences : ScriptableObject
    {
        public string saveFolder;
        public string saveExtension;
        public string defaultSaveName;
        public List<ITypedSerializationSurrogate> serilizationHandlers;

        public string VerifySaveFolder(string newSaveFolder)
        {
            int errorLocation = newSaveFolder.IndexOfAny(Path.GetInvalidFileNameChars());
            if (newSaveFolder.Length <= 0)
            {
                return "Folder name cannot be empty.";
            }
            if (errorLocation == -1)
            {
                return null;
            }
            else
            {
                return $"Folder cannot contain characters {string.Join(", ", Constants.READABLE_FILE_INVALID)}";
            }
        }

        public string VerifySaveExtension(string newSaveExtension)
        {
            int errorLocation = newSaveExtension.IndexOfAny(Path.GetInvalidFileNameChars());
            if (errorLocation == -1)
            {
                return null;
            }
            else
            {
                return $"Extension cannot contain characters {string.Join(", ", Constants.READABLE_FILE_INVALID)}";
            }
        }

        public string VerifyDefaultSaveName(string newDefaultSaveName)
        {
            int errorLocation = newDefaultSaveName.IndexOfAny(Path.GetInvalidFileNameChars());
            if (newDefaultSaveName.Length <= 0)
            {
                return "Default save name cannot be empty.";
            }
            if (errorLocation == -1)
            {
                return null;
            }
            else
            {
                return $"Default save name cannot contain characters {string.Join(", ", Constants.READABLE_FILE_INVALID)}";
            }
        }

        public override string ToString()
        {
            return $"Save Folder: {this.saveFolder} :: Save Extension {this.saveExtension} :: Default Save Name {this.defaultSaveName}" +
                   $"\nSerialization Handlers: {string.Join(", ", this.serilizationHandlers)}";
        }
    }
}
