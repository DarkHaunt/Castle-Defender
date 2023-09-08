using Game.Level.Common.Lifecycle;
using System;


namespace Game.Level.Configs
{
    public interface ILevelConfigProvider
    {
        event Action OnLevelConfigsReady;


        void RequestLevelConfig();
        LevelConfig GetLevelConfig();
    }
}