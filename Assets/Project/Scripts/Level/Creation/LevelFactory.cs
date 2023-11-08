using Project.Scripts.Level.Common;
using UnityEngine;


namespace Project.Scripts.Level.Creation
{
    public class LevelFactory
    {
        private readonly Transform _parent;

        public LevelFactory(Transform parent)
        {
            _parent = parent;
        }
        
        public LevelComponentsContainer CreateLevel(string prefabPath)
        {
            var prefab = Resources.Load<LevelComponentsContainer>(prefabPath);

            return Object.Instantiate(prefab, _parent);
        }
    }
}