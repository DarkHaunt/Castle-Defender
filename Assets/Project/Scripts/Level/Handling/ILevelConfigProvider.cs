

using Game.Configs.Level;


namespace Game.Level.Services.Level
{
    public interface ILevelConfigProvider
    {
        ILevelConfig GetLevelConfig();
    }
}