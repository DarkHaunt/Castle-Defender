using Project.Scripts.Configs.Level;
using UnityEngine;


namespace Project.Scripts.Level.Common.Prefab
{
    public class LevelProvider
    {
        private readonly Transform _parent;

        public LevelProvider(Transform parent)
            => _parent = parent;

        public LevelComponentsContainer LoadLevel(ILevelConfig levelConfig)
        {
            var prefab = Resources.Load<LevelComponentsContainer>(levelConfig.LevelPrefabPath);

            return Object.Instantiate(prefab, _parent);
        }
    }
}