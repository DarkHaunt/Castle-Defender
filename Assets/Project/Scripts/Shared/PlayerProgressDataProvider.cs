using Game.Common.Save;
using Game.Configs.Game;
using Game.Static;


namespace Game.Shared
{
    public class PlayerProgressDataProvider : IPlayerProgressDataProvider
    {
        private IPlayerProgressData _playerProgressData;
        
        public IPlayerProgressData GetPlayerProgressData()
            => _playerProgressData ??= JsonSerializer.LoadFile<SerializedPlayerProgressData>(StaticDataContainer.UserConsumedProgressDataPath);
    }
}