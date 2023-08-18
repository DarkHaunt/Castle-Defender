using Game.Extra;
using Game.Level.Weapons.Maintain.Services;


namespace Game.Level.Weapons.Maintain.Binders
{
    public class WeaponCreateBinder
    {
        public readonly ReactiveProperty<bool> CreateEnabled = new();
        public readonly ReactiveProperty<bool> DeleteEnabled = new();
        public readonly ReactiveProperty<bool> UpdateEnabled = new();

        private readonly WeaponDeletionService _weaponDeletionService;
        private readonly WeaponCreateService _weaponCreateService;


        public WeaponCreateBinder(WeaponCreateService weaponCreateService, WeaponDeletionService weaponDeletionService)
        {
            _weaponDeletionService = weaponDeletionService;
            _weaponCreateService = weaponCreateService;
        }


        public void EnableCreation()
        {
            _weaponCreateService.StartHandleCreationOf();

            CreateEnabled.Value = true;
        }

        public void DisableCreation()
        {
            _weaponCreateService.EndHandleCurrentCreation();
            
            CreateEnabled.Value = false;
        }

        public void EnableDeletion()
        {
            _weaponDeletionService.StartHandleDeletion();

            DeleteEnabled.Value = true;
        }

        public void DisableDeletion()
        {
            _weaponDeletionService.EndHandleDeletion();
            
            DeleteEnabled.Value = false;
        }
    }
}