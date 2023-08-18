using Game.Level.Weapons.Maintain.Factory;


namespace Game.Level.Weapons.Maintain.Services
{
    public class WeaponCreateService
    {
        private readonly IWeaponPointsContainer _weaponPointsContainer;
        private readonly IWeaponFactory _weaponFactory;
        private readonly Weapon _prefab;


        public WeaponCreateService(IWeaponFactory weaponFactory, IWeaponPointsContainer weaponPointsContainer, Weapon prefab)
        {
            _weaponPointsContainer = weaponPointsContainer;
            _weaponFactory = weaponFactory;
            _prefab = prefab;
        }
        
        
        public void StartHandleCreationOf()
        {
            foreach (var weaponPlacePoint in _weaponPointsContainer.EmptyPoints)
                EnableCreationFor(weaponPlacePoint);
        }

        public void EndHandleCurrentCreation()
        {
            foreach (var weaponPlacePoint in _weaponPointsContainer.EmptyPoints)
                DisableCreationFor(weaponPlacePoint);
        }

        private void CreateWeapon(WeaponHandlePoint weaponHandlePoint)
        {
            var newWeapon = _weaponFactory.CreateWeapon(_prefab, weaponHandlePoint.Position);
            
            _weaponPointsContainer.RegisterPointAsOccupied(weaponHandlePoint);
            weaponHandlePoint.RegisterWeapon(newWeapon);

            DisableCreationFor(weaponHandlePoint);
        }

        private void EnableCreationFor(WeaponHandlePoint weaponPlacePoint)
        {
            weaponPlacePoint.OnCreateButtonPressed += CreateWeapon;
            weaponPlacePoint.EnableCreateView();
        }

        private void DisableCreationFor(WeaponHandlePoint weaponPlacePoint)
        {
            weaponPlacePoint.OnCreateButtonPressed -= CreateWeapon;
            weaponPlacePoint.DisableCreateView();
        }
    }
}