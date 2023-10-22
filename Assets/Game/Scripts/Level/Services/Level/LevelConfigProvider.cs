using Game.Common.Save;
 

namespace Game.Level.Configs
{
    public class LevelConfigProvider : ILevelConfigProvider
    {
        private ILevelConfig _levelConfig;
        
        
        public ILevelConfig GetLevelConfig()
            => _levelConfig ??= JsonSerializer.LoadFile<SerializedLevelConfig>(StaticDataContainer.LevelConfigsPath);
    }
}