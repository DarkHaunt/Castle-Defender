using System;


namespace Game.Level.Configs
{
    [Serializable]
    public class SerializedLevelConfig : ILevelConfig
    {
        public string SerializedLevelPrefabPath;
        public float SerializedEnemiesSpawnWaveTime;
        public string[] SerializedEnemiesPrefabsPatches;

        public string LevelPrefabPath => SerializedLevelPrefabPath;
        public float EnemiesSpawnWaveTime => SerializedEnemiesSpawnWaveTime;
        public string[] EnemiesPrefabsPatches => SerializedEnemiesPrefabsPatches;


        public SerializedLevelConfig(ILevelConfig levelConfig)
        {
            SerializedLevelPrefabPath = levelConfig.LevelPrefabPath;
            SerializedEnemiesSpawnWaveTime = levelConfig.EnemiesSpawnWaveTime;
            SerializedEnemiesPrefabsPatches = levelConfig.EnemiesPrefabsPatches;
        }
    }
}