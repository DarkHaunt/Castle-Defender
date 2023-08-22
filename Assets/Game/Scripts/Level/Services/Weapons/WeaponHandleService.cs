using System;


namespace Game.Level.Services.Weapons
{
    public class WeaponHandleService : IWeaponHandleService
    {
        public event Action OnEnabled;
        public event Action OnDisabled;

        private readonly WeaponDeletionService _weaponDeletionService;
        private readonly WeaponCreateService _weaponCreateService;
        private readonly WeaponUpdateService _weaponUpdateService;


        public WeaponHandleService(WeaponCreateService weaponCreateService, WeaponDeletionService weaponDeletionService,
            WeaponUpdateService weaponUpdateService)
        {
            _weaponDeletionService = weaponDeletionService;
            _weaponCreateService = weaponCreateService;
            _weaponUpdateService = weaponUpdateService;
        }
        
        
        public void Enable()
            => OnEnabled?.Invoke();

        public void Disable()
            => OnDisabled?.Invoke();
        
        
        public void StartHandleCreate()
            => _weaponCreateService.StartHandleCreate();

        public void StartHandleUpdate()
            => _weaponUpdateService.StartHandleUpdate();

        public void StartHandleDelete()
            => _weaponDeletionService.StartHandleDelete();

        
        public void EndHandleCreate()
            => _weaponCreateService.EndHandleCreate();

        public void EndHandleUpdate()
            => _weaponUpdateService.EndHandleUpdate();

        public void EndHandleDelete()
            => _weaponDeletionService.EndHandleDelete();
    }
}