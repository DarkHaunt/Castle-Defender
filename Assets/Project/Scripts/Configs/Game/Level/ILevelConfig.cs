namespace Project.Scripts.Configs.Level
{
    public interface ILevelConfig
    {
        string LevelPrefabPath { get; }
        
        int CountToKillEnemies { get; }
        int StartCountOfCrystals { get; }
        float EnemiesSpawnWaveTime { get; }
        string[] EnemiesPrefabsPatches { get; }
    }
}