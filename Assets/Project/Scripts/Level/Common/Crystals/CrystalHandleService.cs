using System;

namespace Project.Scripts.Level.Common.Crystals
{
    public class CrystalHandleService
    {
        public event Action<int> OnCrystalUpdated; 
        
        private int _crystalCount;

        
        public void Init(int startCrystalCount)
        {
            _crystalCount = startCrystalCount;
            
            UpdateCoins();
        }

        public void TryToConsume(int price, Action onSuccess = null, Action onFail = null)
        {
            if (_crystalCount < price)
                onFail?.Invoke();
            else
            {
                _crystalCount -= price;
                onSuccess?.Invoke();
            }

            UpdateCoins();
        }

        public void AddCrystals(int coins)
        {
            _crystalCount += coins;

            UpdateCoins();
        }

        private void UpdateCoins()
            => OnCrystalUpdated?.Invoke(_crystalCount);
    }
}