using Game.Level.Common.Lifecycle;
using System;


namespace Game.Level.Configs
{
    public interface ILevelConfigProvider : IEnableable
    {
        event Action<LevelConfig> OnLevelConfigsReady;
    }
}