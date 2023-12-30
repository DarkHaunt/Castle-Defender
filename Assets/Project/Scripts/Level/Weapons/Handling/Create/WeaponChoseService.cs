using Project.Scripts.Level.Weapons.View;
using System.Collections.Generic;
using Project.Scripts.Global;
using System.Linq;


namespace Project.Scripts.Level.Weapons.Handling.Create
{
    public class WeaponChoseService
    {
        private readonly List<WeaponPickButton> _weaponPickButtons;

        public Weapon ChosenWeapon { get; private set; }


        public WeaponChoseService(List<WeaponPickButton> weaponPickButtons)
        {
            _weaponPickButtons = weaponPickButtons;
        }

        public void Init(WeaponType[] availableWeapons)
        {
            var unlockedButtons = _weaponPickButtons.Where(button => availableWeapons.Contains(button.Type));

            foreach (var weaponPickButton in unlockedButtons)
                weaponPickButton.Unlock();

            ChosenWeapon = unlockedButtons.FirstOrDefault().Prefab;
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