using System;


namespace Game.Level.Configs
{
    [Serializable]
    public class SerializedLevelConfig
    {
        public string LevelPrefabPath;
        public string[] EnemiesPrefabsPatches;


        public SerializedLevelConfig(LevelConfig levelConfig)
        {
            LevelPrefabPath = levelConfig.LevelPrefabPath;
            EnemiesPrefabsPatches = levelConfig.EnemiesPrefabsPatches;
        }
    }
}