namespace Game.Level.Configs
{
    public interface ILevelConfig
    {
        string LevelPrefabPath { get; }
        string[] EnemiesPrefabsPatches { get; }
    }
}