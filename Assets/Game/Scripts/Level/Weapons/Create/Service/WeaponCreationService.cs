using System.Collections.Generic;
using Game.Level.Weapons.Create.Factory;
using Game.Level.Weapons.Maintain;
using UnityEngine;


namespace Game.Level.Weapons.Create.Service
{
    public class WeaponCreationService
    {
        private readonly ISet<WeaponCreatePoint> _weaponPlacePoints;
        private readonly IWeaponsContainer _weaponsContainer;
        private readonly IWeaponFactory _weaponFactory;

        private Weapon _targetPrefab;

        
        public WeaponCreationService(IWeaponFactory weaponFactory, IWeaponsContainer weaponsContainer,
            IEnumerable<WeaponCreatePoint> placePoints)
        {
            _weaponPlacePoints = new HashSet<WeaponCreatePoint>(placePoints);
            _weaponsContainer = weaponsContainer;
            _weaponFactory = weaponFactory;
        }
        
        
        public void StartHandleCreationOf(Weapon weaponPrefab)
        {
            _targetPrefab = weaponPrefab;
            
            foreach (var weaponPlacePoint in _weaponPlacePoints)
            {
                weaponPlacePoint.OnCreateButtonPressed += CreateWeapon;
                weaponPlacePoint.EnableCreateUI();
            }
        }
				
        public void EndHandleCurrentCreation()
        {
            _targetPrefab = null;
            
            foreach (var weaponPlacePoint in _weaponPlacePoints)
            {
                weaponPlacePoint.OnCreateButtonPressed -= CreateWeapon;
                weaponPlacePoint.DisableCreateUI();
            }
        }

        private void CreateWeapon(Vector3 position)
        {
            var newWeapon = _weaponFactory.CreateWeapon(_targetPrefab, position);
            
            _weaponsContainer.RegisterWeapon(newWeapon);
        }
    }
}