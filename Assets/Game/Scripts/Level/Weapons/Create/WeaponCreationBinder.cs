using Game.Extra;


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


        public void EnableCreation(Weapon weaponPrefab)
        {
            _weaponCreationService.Enable(weaponPrefab);

            CreationEnabled.Value = true;
        }

        public void DisableCreation()
        {
            _weaponCreationService.Disable();
            
            CreationEnabled.Value = false;
        }
    }
}