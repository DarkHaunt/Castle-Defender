using Project.Scripts.Level.Common.Crystals;
using Project.Scripts.Level.Weapons.View;
using System.Collections.Generic;
using Project.Scripts.Global;
using System.Linq;


namespace Project.Scripts.Level.Weapons.Handling.Create
{
    public class WeaponChoseService
    {
        private readonly List<WeaponPickButton> _weaponPickButtons;
        private readonly CrystalHandleService _crystalHandleService;

        public Weapon ChosenWeapon { get; private set; }


        public WeaponChoseService(List<WeaponPickButton> weaponPickButtons, CrystalHandleService crystalHandleService)
        {
            _crystalHandleService = crystalHandleService;
            _weaponPickButtons = weaponPickButtons;
        }

        public void Init(WeaponType[] availableWeapons)
        {
            var unlockedButtons = _weaponPickButtons.Where(button => availableWeapons.Contains(button.Config.WeaponType));

            foreach (var weaponPickButton in unlockedButtons)
            {
                weaponPickButton.Construct(_crystalHandleService);
                weaponPickButton.Unlock();
            }

            ChosenWeapon = unlockedButtons.FirstOrDefault().Config.Prefab;
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