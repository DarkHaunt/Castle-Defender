using Project.Scripts.Level.Weapons.HandlePoints.MVP;
using Project.Scripts.Level.Weapons.HandlePoints;
using Project.Scripts.Level.Weapons.Creation;


namespace Project.Scripts.Level.Weapons.Handling
{
    public class WeaponCreateService
    {
        private readonly WeaponPointsContainer _weaponPointsContainer;
        private readonly WeaponFactory _weaponFactory;
        private readonly Weapon _prefab;


        public WeaponCreateService(WeaponFactory weaponFactory, WeaponPointsContainer weaponPointsContainer,
            Weapon prefab)
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

        private void EnableCreationFor(WeaponPointModel weaponPlacePoint)
        {
            weaponPlacePoint.EnableRegister(true);
            weaponPlacePoint.OnSelected += CreateWeapon;
        }

        private void DisableCreationFor(WeaponPointModel weaponPlacePoint)
        {
            weaponPlacePoint.EnableRegister(false);
            weaponPlacePoint.OnSelected -= CreateWeapon;
        }

        private void CreateWeapon(WeaponPointModel weaponHandlePoint)
        {
            var newWeapon = _weaponFactory.CreateWeapon(_prefab, weaponHandlePoint.Position);

            _weaponPointsContainer.RegisterPointAsOccupied(weaponHandlePoint);
            weaponHandlePoint.RegisterWeapon(newWeapon);
            
            DisableCreationFor(weaponHandlePoint);
        }
    }
}