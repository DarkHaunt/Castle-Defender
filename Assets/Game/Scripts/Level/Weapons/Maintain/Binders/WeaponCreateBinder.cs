using Game.Level.Weapons.Maintain.Services;
using Game.Extra;


namespace Game.Level.Weapons.Maintain.Binders
{
    public class WeaponCreateBinder
    {
        public readonly ReactiveProperty<bool> CreateEnabled = new();
        public readonly ReactiveProperty<bool> DeleteEnabled = new();
        public readonly ReactiveProperty<bool> UpdateEnabled = new();

        private readonly WeaponDeletionService _weaponDeletionService;
        private readonly WeaponUpdateService _weaponUpdateService;
        private readonly WeaponCreateService _weaponCreateService;


        public WeaponCreateBinder(WeaponCreateService weaponCreateService, WeaponDeletionService weaponDeletionService,
            WeaponUpdateService weaponUpdateService)
        {
            _weaponDeletionService = weaponDeletionService;
            _weaponCreateService = weaponCreateService;
            _weaponUpdateService = weaponUpdateService;
        }


        public void CreateEnable()
        {
            _weaponCreateService.StartHandleCreate();

            CreateEnabled.Value = true;
        }

        public void CreateDisable()
        {
            _weaponCreateService.EndHandleCreate();

            CreateEnabled.Value = false;
        }

        public void DeleteEnable()
        {
            _weaponDeletionService.StartHandleDelete();

            DeleteEnabled.Value = true;
        }

        public void DeleteDisable()
        {
            _weaponDeletionService.EndHandleDelete();

            DeleteEnabled.Value = false;
        }

        public void UpdateEnable()
        {
            _weaponUpdateService.StartHandleUpdate();

            UpdateEnabled.Value = true;
        }

        public void UpdateDisable()
        {
            _weaponUpdateService.EndHandleUpdate();

            UpdateEnabled.Value = false;
        }
    }
}