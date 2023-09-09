using Game.Level.Common;
using UnityEngine;


namespace Game.Level.Factories.Level
{
    public class LevelFactory : ILevelFactory
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