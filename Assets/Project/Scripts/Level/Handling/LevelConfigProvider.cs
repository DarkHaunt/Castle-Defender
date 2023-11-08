using Game.Common.Save;
using Game.Configs.Level;
using Game.Static;


namespace Project.Scripts.Level.Handling
{
    public class LevelConfigProvider
    {
        private ILevelConfig _levelConfig;
        
        
        public ILevelConfig GetLevelConfig()
            => _levelConfig ??= JsonSerializer.LoadFile<SerializedLevelConfig>(StaticDataContainer.LevelConfigsPath);
    }
}