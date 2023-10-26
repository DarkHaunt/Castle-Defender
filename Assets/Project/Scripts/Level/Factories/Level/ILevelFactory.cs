using Game.Level.Common;


namespace Game.Level.Factories.Level
{
    public interface ILevelFactory
    {
        LevelComponentsContainer CreateLevel(string prefabPath);
    }
}