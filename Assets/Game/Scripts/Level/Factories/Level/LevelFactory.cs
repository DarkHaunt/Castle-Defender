using Game.Level.Common;
using UnityEngine;


namespace Game.Level.Factories.Level
{
    public class LevelFactory : ILevelFactory
    {
        public LevelComponentsContainer CreateLevel(string prefabPath)
        {
            var prefab = Resources.Load<LevelComponentsContainer>(prefabPath);

            return Object.Instantiate(prefab);
        }
    }
}