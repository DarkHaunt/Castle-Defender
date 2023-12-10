using Project.Scripts.Configs.Game;
using System;


namespace Project.Scripts.Consume
{
    public class ConsumeService
    {
        private int _playerCrystalsCount;


        public void Init(IPlayerConfig playerConfig)
            => _playerCrystalsCount = playerConfig.Crystals;

        public void TryToConsume(int price, Action onSuccess = null, Action onFail = null)
        {
            if (_playerCrystalsCount < price)
                onFail?.Invoke();
            else
            {
                _playerCrystalsCount -= price;
                onSuccess?.Invoke();
            }

            UpdateConfig();
        }

        private void UpdateConfig()
        {
            
        }
    }
}