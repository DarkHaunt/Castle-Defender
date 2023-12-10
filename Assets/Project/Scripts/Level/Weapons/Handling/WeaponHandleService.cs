using Project.Scripts.Level.Weapons.Handling.Create;
using Project.Scripts.Level.Weapons.Handling.Delete;
using System;


namespace Project.Scripts.Level.Weapons.Handling
{
    public class WeaponHandleService
    {
        public event Action OnEnabled;
        public event Action OnDisabled;

        private readonly WeaponDeletionService _weaponDeletionService;
        private readonly WeaponCreateService _weaponCreateService;


        public WeaponHandleService(WeaponCreateService weaponCreateService, WeaponDeletionService weaponDeletionService)
        {
            _weaponDeletionService = weaponDeletionService;
            _weaponCreateService = weaponCreateService;
        }


        public void Enable()
            => OnEnabled?.Invoke();

        public void Disable()
            => OnDisabled?.Invoke();

        public void StartHandleCreate()
            => _weaponCreateService.StartHandleCreate();

        public void StartHandleDelete()
            => _weaponDeletionService.StartHandleDelete();

        
        public void EndHandleCreate()
            => _weaponCreateService.EndHandleCreate();

        public void EndHandleDelete()
            => _weaponDeletionService.EndHandleDelete();
    }
}