using Project.Scripts.Common.Infrastructure;
using System;


namespace Project.Scripts.Level.Weapons.Handling
{
    public class WeaponSystemBinder
    {
        public event Action OnSystemEnabled;
        public event Action OnSystemDisabled;
        
        public readonly ReactiveProperty<bool> CreateOptionSelected = new();
        public readonly ReactiveProperty<bool> DeleteOptionSelected = new();

        private readonly WeaponHandleService _weaponHandleService;


        public WeaponSystemBinder(WeaponHandleService weaponHandleService)
        {
            _weaponHandleService = weaponHandleService;

            _weaponHandleService.OnEnabled += () => OnSystemEnabled?.Invoke();
            _weaponHandleService.OnDisabled += () => OnSystemDisabled?.Invoke();;
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
    }
}