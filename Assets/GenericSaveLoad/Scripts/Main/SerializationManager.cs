namespace SaveLoadSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using UnityEngine;

    public class SerializationManager
    {
        private static string SaveFolder = null;
        private static string SaveExtension = null;
        private static string DefaultSaveName = null;
        private static string PathString
        {
            get
            {
                return $"{Application.persistentDataPath}/{SaveFolder}";
            }
        }

        private static List<ITypedSerializationSurrogate> Handlers = new List<ITypedSerializationSurrogate>();

        [RuntimeInitializeOnLoadMethod]
        private static void LoadPreferences()
        {
            SaveLoadPreferences prefs = Resources.Load<SaveLoadPreferences>(Constants.SAVE_LOAD_PREFERENCES_FILENAME);
            SaveFolder = prefs.saveFolder;
            SaveExtension = prefs.saveExtension;
            DefaultSaveName = prefs.defaultSaveName;

            Handlers.AddRange(GetITypedSerializationSurrogateChildren());
        }

        public static bool Save(object saveData, string saveName = null)
        {
            if (saveName == null)
            {
                saveName = DefaultSaveName;
            }

            if (!Directory.Exists(PathString))
            {
                Directory.CreateDirectory(PathString);
            }
            string savePath = $"{PathString}/{saveName}.{SaveExtension}";

            BinaryFormatter formatter = GetBinaryFormatter();
            FileStream file = null;
            try
            {
                file = File.Create(savePath);
                formatter.Serialize(file, saveData);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error encountered trying to save file to '{savePath}'.");
                Debug.LogError($"Error Message: {e.Message}");
                return false;
            }
            finally
            {
                file?.Close();
            }

            return true;
        }

        public static object Load(string fileName = null)
        {
            if (fileName == null)
            {
                fileName = DefaultSaveName;
            }
            string filePath = $"{PathString}/{fileName}.{SaveExtension}";
            if (!File.Exists(filePath))
            {
                Debug.LogError($"{filePath} does not exist!");
                return null;
            }

            BinaryFormatter formatter = GetBinaryFormatter();

            FileStream file = null;

            try
            {
                file = File.Open(filePath, FileMode.Open);
                object save = formatter.Deserialize(file);
                return save;
            }
            catch (Exception e)
            {
                Debug.LogError($"Error encountered trying to load file from '{filePath}'.");
                Debug.LogError($"Error Message: {e.Message}");
                return null;
            }
            finally
            {
                file?.Close();
            }
        }

        private static BinaryFormatter GetBinaryFormatter()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            SurrogateSelector selector = new SurrogateSelector();

            foreach (ITypedSerializationSurrogate surrogate in Handlers)
            {
                selector.AddSurrogate(surrogate.GetBaseType(), new StreamingContext(StreamingContextStates.All), surrogate);
            }

            formatter.SurrogateSelector = selector;

            return formatter;
        }

        public static List<ITypedSerializationSurrogate> GetITypedSerializationSurrogateChildren()
        {
            List<ITypedSerializationSurrogate> finalList = new List<ITypedSerializationSurrogate>();
            Type surrogateType = typeof(ITypedSerializationSurrogate);
            List<Type> childrenTypes = surrogateType.Assembly.GetTypes()
                .Where(type => type != surrogateType && surrogateType.IsAssignableFrom(type)).ToList();
            foreach (Type type in childrenTypes)
            {
                finalList.Add(Activator.CreateInstance(type) as ITypedSerializationSurrogate);
            }
            return finalList;
        }
    }
}
