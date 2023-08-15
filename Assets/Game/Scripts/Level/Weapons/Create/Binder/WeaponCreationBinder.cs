using Game.Extra;
using Game.Level.Weapons.Create.Service;


namespace Game.Level.Weapons.Create.Binder
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
            _weaponCreationService.StartHandleCreationOf(weaponPrefab);

            CreationEnabled.Value = true;
        }

        public void DisableCreation()
        {
            _weaponCreationService.EndHandleCurrentCreation();
            
            CreationEnabled.Value = false;
        }
    }
}