namespace Game.Level.Configs
{
    public interface ILevelConfig
    {
        string LevelPrefabPath { get; }
        float EnemiesSpawnWaveTime { get; }
        string[] EnemiesPrefabsPatches { get; }
    }
}