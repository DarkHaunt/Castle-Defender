﻿using Game.Level.Weapons.HandlePoints.MVP;
using Game.Level.Weapons.HandlePoints;
using Game.Level.Factories.Weapons;
using Game.Level.Weapons;


namespace Game.Level.Services.Weapons
{
    public class WeaponCreateService
    {
        private readonly IWeaponPointsContainer _weaponPointsContainer;
        private readonly IWeaponFactory _weaponFactory;
        private readonly Weapon _prefab;


        public WeaponCreateService(IWeaponFactory weaponFactory, IWeaponPointsContainer weaponPointsContainer,
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