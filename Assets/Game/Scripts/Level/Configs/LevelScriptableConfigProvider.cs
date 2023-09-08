using System;


namespace Game.Level.Configs
{
    public class LevelScriptableConfigProvider : ILevelConfigProvider
    {
        private readonly LevelConfig _levelConfig;

        public event Action OnLevelConfigsReady;


        public LevelScriptableConfigProvider(LevelConfig levelConfig)
        {
            _levelConfig = levelConfig;
        }


        public void RequestLevelConfig()
            => OnLevelConfigsReady?.Invoke();

        public LevelConfig GetLevelConfig()
            => _levelConfig;
    }
}