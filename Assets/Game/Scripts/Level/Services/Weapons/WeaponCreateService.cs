using Game.Level.Weapons.HandlePoints;
using Game.Level.Factories.Weapons;
using Game.Level.Weapons;
using Game.Level.Weapons.HandlePoints.MVP;


namespace Game.Level.Services.Weapons
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
        
        
        public void StartHandleCreate()
        {
            foreach (var weaponPlacePoint in _weaponPointsContainer.EmptyPoints)
                EnableCreationFor(weaponPlacePoint);
        }

        public void EndHandleCreate()
        {
            foreach (var weaponPlacePoint in _weaponPointsContainer.EmptyPoints)
                DisableCreationFor(weaponPlacePoint);
        }

        private void CreateWeapon(WeaponPointPresenter weaponHandlePoint)
        {
            var newWeapon = _weaponFactory.CreateWeapon(_prefab, weaponHandlePoint.Position);
            
            _weaponPointsContainer.RegisterPointAsOccupied(weaponHandlePoint);
            weaponHandlePoint.RegisterWeapon(newWeapon);

            DisableCreationFor(weaponHandlePoint);
        }

        private void EnableCreationFor(WeaponPointPresenter weaponPlacePoint)
        {
            weaponPlacePoint.OnCreateWeapon += CreateWeapon;
            weaponPlacePoint.EnableCreateView(true);
        }

        private void DisableCreationFor(WeaponPointPresenter weaponPlacePoint)
        {
            weaponPlacePoint.OnCreateWeapon -= CreateWeapon;
            weaponPlacePoint.EnableCreateView(false);
        }
    }
}