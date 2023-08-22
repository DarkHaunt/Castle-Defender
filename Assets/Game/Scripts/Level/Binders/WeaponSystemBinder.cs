using Game.Level.Services.Weapons;
using Game.Extra;
using System;


namespace Game.Level.Binders
{
    public class WeaponSystemBinder
    {
        public event Action OnSystemEnabled;
        public event Action OnSystemDisabled;
        
        public readonly ReactiveProperty<bool> CreateOptionSelected = new();
        public readonly ReactiveProperty<bool> DeleteOptionSelected = new();
        public readonly ReactiveProperty<bool> UpdateOptionSelected = new();

        private readonly IWeaponHandleService _weaponHandleService;


        public WeaponSystemBinder(IWeaponHandleService weaponHandleService)
        {
            _weaponHandleService = weaponHandleService;

            _weaponHandleService.OnEnabled += HandleSystemEnabled;
            _weaponHandleService.OnDisabled += HandleSystemDisabled;
        }

        private void HandleSystemDisabled()
        {
            OnSystemDisabled?.Invoke();
        }

        private void HandleSystemEnabled()
        {
            OnSystemEnabled?.Invoke();
        }

        public void CreateEnable()
        {
            _weaponHandleService.StartHandleCreate();

            CreateOptionSelected.Value = true;
        }

        public void CreateDisable()
        {
            _weaponHandleService.EndHandleCreate();

            CreateOptionSelected.Value = false;
        }

        public void DeleteEnable()
        {
            _weaponHandleService.StartHandleDelete();

            DeleteOptionSelected.Value = true;
        }

        public void DeleteDisable()
        {
            _weaponHandleService.EndHandleDelete();

            DeleteOptionSelected.Value = false;
        }

        public void UpdateEnable()
        {
            _weaponHandleService.StartHandleUpdate();

            UpdateOptionSelected.Value = true;
        }

        public void UpdateDisable()
        {
            _weaponHandleService.EndHandleUpdate();

            UpdateOptionSelected.Value = false;
        }
    }
}