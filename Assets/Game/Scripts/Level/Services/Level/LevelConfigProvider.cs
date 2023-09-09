using Game.Common.Save;
 

namespace Game.Level.Configs
{
    public class LevelConfigProvider : ILevelConfigProvider
    {
        public SerializedLevelConfig GetLevelConfig()
            => JsonSerializer.LoadFile<SerializedLevelConfig>(StaticDataContainer.LevelConfigsPrefsKey);
    }
}