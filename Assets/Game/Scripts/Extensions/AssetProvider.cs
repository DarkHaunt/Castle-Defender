using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Game.Extensions
{
    public class AssetProvider
    {  
        private readonly Dictionary<string, Object> _cachedObjects = new();  
        private readonly Dictionary<string, List<Object>> _cachedListOfObjects = new();  
  
        public T Get<T>(string path) where T : Object  
        {  
            if (_cachedObjects.TryGetValue(path, out var prefab))  
                return prefab as T;  
		  
            Object loadedPrefab = Resources.Load<T>(path);  
            
            _cachedObjects[path] = loadedPrefab;
            
            return (T) loadedPrefab;  
        }  
	  
        public List<T> GetAll<T>(string path) where T : Object  
        {  
            if (_cachedListOfObjects.TryGetValue(path, out var prefabList))  
                return prefabList as List<T>;  
             
            var loadedObjects = Resources.LoadAll<T>(path).ToList();  
            
            _cachedListOfObjects[path] = new List<Object>(loadedObjects);
            
            return loadedObjects;  
        }
    }
}