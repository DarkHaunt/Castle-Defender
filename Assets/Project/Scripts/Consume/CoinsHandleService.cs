using Project.Scripts.Configs.Game;
using Project.Scripts.Configs;
using System;


namespace Project.Scripts.Consume
{
    public class CoinsHandleService
    {
        public event Action<int> OnCoinsUpdated; 
        
        private readonly ConfigsProvider _configsProvider;
        
        private int _playerCoinsCount;


        public CoinsHandleService(ConfigsProvider configsProvider)
        {
            _configsProvider = configsProvider;
        }
        
        
        public void Init()
        {
            _playerCoinsCount = _configsProvider.PlayerConfig.Coins;
            OnCoinsUpdated?.Invoke(_playerCoinsCount);
        }

        public void TryToConsume(int price, Action onSuccess = null, Action onFail = null)
        {
            if (_playerCoinsCount < price)
                onFail?.Invoke();
            else
            {
                _playerCoinsCount -= price;
                onSuccess?.Invoke();
            }

            UpdateConfig();
        }

        public void AddCoins(int coins)
        {
            _playerCoinsCount += coins;

            UpdateConfig();
        }

        private void UpdateConfig()
        {
            OnCoinsUpdated?.Invoke(_playerCoinsCount);
            
            var newConfig = new SerializedPlayerConfig(_configsProvider.PlayerConfig)
            {
                coinsSerialized = _playerCoinsCount
            };

            _configsProvider.UpdatePlayerConfig(newConfig);
        }
    }
}