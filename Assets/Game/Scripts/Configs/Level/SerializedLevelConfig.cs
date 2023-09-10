using System;


namespace Game.Level.Configs
{
    [Serializable]
    public class SerializedLevelConfig : ILevelConfig
    {
        public string SerializedLevelPrefabPath;
        public string[] SerializedEnemiesPrefabsPatches;

        public string LevelPrefabPath => SerializedLevelPrefabPath;
        public string[] EnemiesPrefabsPatches => SerializedEnemiesPrefabsPatches;

        
        public SerializedLevelConfig(ILevelConfig levelConfig)
        {
            SerializedLevelPrefabPath = levelConfig.LevelPrefabPath;
            SerializedEnemiesPrefabsPatches = levelConfig.EnemiesPrefabsPatches;
        }
    }
}