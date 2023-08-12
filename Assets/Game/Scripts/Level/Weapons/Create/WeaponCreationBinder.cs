using System;
using Game.Extra;
using UnityEngine;


namespace Game.Level.Weapons.Create
{
    public class WeaponCreationBinder
    {
        public readonly ReactiveProperty<bool> CreationEnabled = new();

        private readonly WeaponCreationService _weaponCreationService;


        public WeaponCreationBinder(WeaponCreationService weaponCreationService)
        {
            _weaponCreationService = weaponCreationService;
        }


        public void Enable() {}
        // => _weaponCreationService.OnWeaponCreated += HandleWeaponCreation;

        public void Disable() {}
        //=> _weaponCreationService.OnWeaponCreated -= HandleWeaponCreation;

        public void EnableCreation()
        {
            Debug.Log($"<color=white>EnableCreation</color>");
            
            _weaponCreationService.Enable();

            CreationEnabled.Value = true;
        }

        public void DisableCreation()
        {
            Debug.Log($"<color=white>DisableCreation</color>");
            
            _weaponCreationService.Disable();
            
            CreationEnabled.Value = false;
        }
    }
}