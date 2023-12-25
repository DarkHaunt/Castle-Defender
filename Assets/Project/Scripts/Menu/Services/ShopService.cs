using Project.Scripts.Configs.Consume;
using Project.Scripts.Configs.Game;
using System.Collections.Generic;
using Project.Scripts.Configs;
using Project.Scripts.Consume;
using Project.Scripts.Menu.UI;
using Project.Scripts.Global;
using System.Linq;
using UnityEngine;
using VContainer;

namespace Project.Scripts.Menu.Services
{
    public class ShopService : MonoBehaviour
    {
        [SerializeField] private List<WeaponShopButton> _buttons ;
        
        private ConfigsProvider _configsProvider;

        
        [Inject]
        public void Construct(CoinsHandleService coinsHandleService, ConfigsProvider configsProvider)
        {
            _configsProvider = configsProvider;
            
            foreach (var button in _buttons)
                button.Construct(coinsHandleService);
        }

        public void Enable()
        {
            foreach (var button in _buttons)
                button.OnSuccessConsumed += UpdatePlayerConfigWithWeapon;
            
            _configsProvider.LoadConfigs();
            UnlockSavedWeapons();
        }

        public void Disable()
        {
            _configsProvider.SaveConfigs();
            
            foreach (var button in _buttons)
                button.OnSuccessConsumed -= UpdatePlayerConfigWithWeapon;
        }

        private void UpdatePlayerConfigWithWeapon(WeaponConfig weapon)
        {
            var config = _configsProvider.PlayerConfig;

            if (!config.AvailableWeapons.Contains(weapon.Type))
            {
                var newConfig = new SerializedPlayerConfig(config)
                {
                    availableWeaponSerialized = new List<WeaponType>(config.AvailableWeapons) { weapon.Type }.ToArray()
                };

                _configsProvider.UpdatePlayerConfig(newConfig);
            }
        }

        private void UnlockSavedWeapons()
        {
            var availableWeapons = _configsProvider.PlayerConfig.AvailableWeapons;
            var buttonsToUnlock = _buttons.Where(weaponButton => availableWeapons.Contains(weaponButton.Type));

            foreach (var button in buttonsToUnlock)
                button.Unlock();
        }
    }
}