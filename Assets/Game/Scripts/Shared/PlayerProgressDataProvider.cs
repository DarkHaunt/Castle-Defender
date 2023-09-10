using Game.Level.Configs;
using Game.Common.Save;


namespace Game.Shared
{
    public class PlayerProgressDataProvider : IPlayerProgressDataProvider
    {
        private IPlayerProgressData _playerProgressData;
        
        public IPlayerProgressData GetPlayerProgressData()
            => _playerProgressData ??= JsonSerializer.LoadFile<SerializedPlayerProgressData>(StaticDataContainer.UserConsumedProgressDataPath);
    }
}