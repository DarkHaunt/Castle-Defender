using Game.Common.Save;
using Game.Configs.Level;
using Game.Static;


namespace Game.Level.Services.Level
{
    public class LevelConfigProvider : ILevelConfigProvider
    {
        private ILevelConfig _levelConfig;
        
        
        public ILevelConfig GetLevelConfig()
            => _levelConfig ??= JsonSerializer.LoadFile<SerializedLevelConfig>(StaticDataContainer.LevelConfigsPath);
    }
}