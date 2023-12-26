using Project.Scripts.Level.Weapons.View;
using Project.Scripts.Configs.Game;
using System.Collections.Generic;
using System.Linq;


namespace Project.Scripts.Level.Weapons.Handling.Create
{
    public class WeaponChoseService
    {
        private readonly IEnumerable<WeaponPickButton> _weaponPickButtons;

        public Weapon ChosenWeapon { get; private set; }


        public WeaponChoseService(IEnumerable<WeaponPickButton> weaponPickButtons)
        {
            _weaponPickButtons = weaponPickButtons;
        }

        public void Init(IPlayerConfig playerConfig)
        {
            var availableWeapons = playerConfig.AvailableWeapons;
            var unlockedWeapons = _weaponPickButtons.Where(x => availableWeapons.Contains(x.Type));

            foreach (var weaponPickButton in unlockedWeapons)
                weaponPickButton.Unlock();

            ChosenWeapon = unlockedWeapons.FirstOrDefault().Prefab;
        }
        
        public void Enable() 
        {
            foreach (var weaponPickButton in _weaponPickButtons)
                weaponPickButton.OnChosenPrefab += ChoseWeaponPrefab;
        }
				
        public void Disable() 
        {
            foreach (var weaponPickButton in _weaponPickButtons)
                weaponPickButton.OnChosenPrefab -= ChoseWeaponPrefab;
        }

        private void ChoseWeaponPrefab(Weapon newChosenWeapon)
            => ChosenWeapon = newChosenWeapon;
    }
}