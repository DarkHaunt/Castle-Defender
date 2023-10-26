namespace Game.Configs.Level
{
    public interface ILevelConfig
    {
        string LevelPrefabPath { get; }
        float EnemiesSpawnWaveTime { get; }
        string[] EnemiesPrefabsPatches { get; }
    }
}