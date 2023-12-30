using System;


namespace Project.Scripts.Configs.Level
{
    [Serializable]
    public class SerializedLevelConfig : ILevelConfig
    {
        public string SerializedLevelPrefabPath;
        public int SerializedCountToKillEnemies;
        public int SerializedStartCountOfCrystals;
        public float SerializedEnemiesSpawnWaveTime;
        public string[] SerializedEnemiesPrefabsPatches;

        public string LevelPrefabPath => SerializedLevelPrefabPath;
        public int CountToKillEnemies => SerializedCountToKillEnemies;
        public int StartCountOfCrystals => SerializedStartCountOfCrystals;
        public float EnemiesSpawnWaveTime => SerializedEnemiesSpawnWaveTime;
        public string[] EnemiesPrefabsPatches => SerializedEnemiesPrefabsPatches;


        public SerializedLevelConfig(ILevelConfig levelConfig)
        {
            SerializedLevelPrefabPath = levelConfig.LevelPrefabPath;
            SerializedCountToKillEnemies = levelConfig.CountToKillEnemies;
            SerializedEnemiesSpawnWaveTime = levelConfig.EnemiesSpawnWaveTime;
            SerializedStartCountOfCrystals = levelConfig.StartCountOfCrystals;
            SerializedEnemiesPrefabsPatches = levelConfig.EnemiesPrefabsPatches;
        }
    }
}