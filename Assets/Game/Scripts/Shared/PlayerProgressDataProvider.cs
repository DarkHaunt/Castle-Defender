using Game.Level.Configs;
using Game.Common.Save;


namespace Game.Shared
{
    public class PlayerProgressDataProvider : IPlayerProgressDataProvider
    {
        public IPlayerProgressData GetPlayerProgressData()
            => JsonSerializer.LoadFile<SerializedPlayerProgressData>(StaticDataContainer.UserConsumedProgressDataPath);
    }
}