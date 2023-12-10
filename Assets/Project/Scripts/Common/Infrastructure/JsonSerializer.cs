using System;
using System.IO;
using UnityEngine;


namespace Project.Scripts.Common.Infrastructure
{
    public static class JsonSerializer
    {
        public static void SaveToPrefs<T>(string prefsKey, T objectToSave)
        {
            string json = JsonUtility.ToJson(objectToSave, true);
            PlayerPrefs.SetString(prefsKey, json);
        }

        public static void SaveToFile<T>(string fullPath, T objectToSave)
        {
            if (objectToSave == null)
                return;
            
            var adjustedPath = GetAdjustedFilePathToJsonOnDataPath(fullPath);
            
            string path = adjustedPath.Substring(0, adjustedPath.LastIndexOf(Path.AltDirectorySeparatorChar));

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string json = JsonUtility.ToJson(objectToSave, true);
            File.WriteAllText(adjustedPath, json);
        }

        public static T LoadPrefs<T>(string prefsKey)
        {
            if (PlayerPrefs.HasKey(prefsKey))
            {
                string dataAsJson = PlayerPrefs.GetString(prefsKey);

                return JsonUtility.FromJson<T>(dataAsJson);
            }

            return CreateEmptyInstance<T>();
        }

        public static T LoadFile<T>(string fullPath)
        {
            var adjustedPath = GetAdjustedFilePathToJsonOnDataPath(fullPath);

            if (File.Exists(adjustedPath))
            {
                string dataAsJson = File.ReadAllText(adjustedPath);

                return JsonUtility.FromJson<T>(dataAsJson);
            }

            return CreateEmptyInstance<T>();
        }
        
        private static string GetAdjustedFilePathToJsonOnDataPath(string filePath)
        {
            var jsonEndedPath = filePath.Contains(".json") ? filePath : filePath + ".json";

            return Path.Combine(Application.persistentDataPath, jsonEndedPath);
        }

        private static T CreateEmptyInstance<T>()
        {
            var obj = Activator.CreateInstance<T>();

            return obj;
        }
    }
}