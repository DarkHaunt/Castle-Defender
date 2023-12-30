using Project.Scripts.Level.Weapons.Handling.WeaponPoints.MVP;
using Project.Scripts.Level.Weapons.Handling.WeaponPoints;
using Project.Scripts.Level.Common.Crystals;


namespace Project.Scripts.Level.Weapons.Handling.Create
{
    public class WeaponCreateService
    {
        private readonly WeaponPointsContainer _weaponPointsContainer;
        private readonly CrystalHandleService _crystalHandleService;
        private readonly WeaponChoseService _weaponChoseService;
        private readonly WeaponFactory _weaponFactory;


        public WeaponCreateService(WeaponFactory weaponFactory, WeaponPointsContainer weaponPointsContainer,
            WeaponChoseService weaponChoseService, CrystalHandleService crystalHandleService)
        {
            _weaponPointsContainer = weaponPointsContainer;
            _crystalHandleService = crystalHandleService;
            _weaponChoseService = weaponChoseService;
            _weaponFactory = weaponFactory;
        }


        public void StartHandleCreate()
        {
            _weaponChoseService.Enable();
            
            foreach (var weaponPlacePoint in _weaponPointsContainer.EmptyPoints)
                EnableCreationFor(weaponPlacePoint);
        }

        public void EndHandleCreate()
        {
            _weaponChoseService.Disable();
            
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
            var weaponCreateConfig = _weaponChoseService.ChosenWeapon;
            
            _crystalHandleService.TryToConsume(weaponCreateConfig.Price, onSuccess: () =>
            {
                var newWeapon = _weaponFactory.CreateWeapon(weaponCreateConfig.Prefab, weaponHandlePoint.Position);

                _weaponPointsContainer.RegisterPointAsOccupied(weaponHandlePoint);
                weaponHandlePoint.RegisterWeapon(newWeapon);

                DisableCreationFor(weaponHandlePoint);
            });
        }
    }
}