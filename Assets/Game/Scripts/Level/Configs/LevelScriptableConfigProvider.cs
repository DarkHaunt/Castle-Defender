using System;


namespace Game.Level.Configs
{
    public class LevelScriptableConfigProvider : ILevelConfigProvider
    {
        public event Action<LevelConfig> OnLevelConfigsReady;
        

        public void Enable()
        {
            
        }

        public void Disable()
        {
            
        }
    }
}