using Project.Scripts.Level.Common.Crystals;
using Project.Scripts.Configs.Game.Weapons;
using Project.Scripts.Level.Weapons.View;
using System.Collections.Generic;
using Project.Scripts.Global;
using System.Linq;


namespace Project.Scripts.Level.Weapons.Handling.Create
{
    public class WeaponChoseService
    {
        private readonly CrystalHandleService _crystalHandleService;
        private readonly List<WeaponPickButton> _weaponPickButtons;

        public WeaponCreateConfig ChosenWeapon { get; private set; }


        public WeaponChoseService(List<WeaponPickButton> weaponPickButtons, CrystalHandleService crystalHandleService)
        {
            _crystalHandleService = crystalHandleService;
            _weaponPickButtons = weaponPickButtons;
        }

        public void Init(WeaponType[] availableWeapons)
        {
            var unlockedButtons = _weaponPickButtons.Where(button => availableWeapons.Contains(button.Config.WeaponType));

            foreach (var weaponPickButton in unlockedButtons)
                weaponPickButton.Unlock();

            ChosenWeapon = unlockedButtons.FirstOrDefault().Config;
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

        private void ChoseWeaponPrefab(WeaponCreateConfig newChosenWeapon)
            => ChosenWeapon = newChosenWeapon;
    }
}