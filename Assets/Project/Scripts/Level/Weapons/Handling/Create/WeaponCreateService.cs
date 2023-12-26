using Project.Scripts.Level.Weapons.Handling.WeaponPoints.MVP;
using Project.Scripts.Level.Weapons.Handling.WeaponPoints;


namespace Project.Scripts.Level.Weapons.Handling.Create
{
    public class WeaponCreateService
    {
        private readonly WeaponPointsContainer _weaponPointsContainer;
        private readonly WeaponChoseService _weaponChoseService;
        private readonly WeaponFactory _weaponFactory;


        public WeaponCreateService(WeaponFactory weaponFactory, WeaponPointsContainer weaponPointsContainer,
            WeaponChoseService weaponChoseService)
        {
            _weaponPointsContainer = weaponPointsContainer;
            _weaponChoseService = weaponChoseService;
            _weaponFactory = weaponFactory;
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
            var newWeapon = _weaponFactory.CreateWeapon(_weaponChoseService.ChosenWeapon, weaponHandlePoint.Position);

            _weaponPointsContainer.RegisterPointAsOccupied(weaponHandlePoint);
            weaponHandlePoint.RegisterWeapon(newWeapon);
            
            DisableCreationFor(weaponHandlePoint);
        }
    }
}