using Game.Level.Weapons.Create.Factory;
using Game.Level.Weapons.Maintain;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Level.Weapons.Create.Service
{
    public class WeaponCreateService
    {
        private readonly ISet<WeaponCreatePoint> _weaponPlacePoints;
        private readonly IWeaponsContainer _weaponsContainer;
        private readonly IWeaponFactory _weaponFactory;
        private readonly Weapon _prefab;


        public WeaponCreateService(IWeaponFactory weaponFactory, IWeaponsContainer weaponsContainer,
            IEnumerable<WeaponCreatePoint> placePoints, Weapon prefab)
        {
            _weaponPlacePoints = new HashSet<WeaponCreatePoint>(placePoints);
            _weaponsContainer = weaponsContainer;
            _weaponFactory = weaponFactory;
            _prefab = prefab;
        }
        
        
        public void StartHandleCreationOf()
        {
            foreach (var weaponPlacePoint in _weaponPlacePoints)
            {
                weaponPlacePoint.OnCreateButtonPressed += CreateWeapon;
                weaponPlacePoint.EnableCreateUI();
            }
        }
				
        public void EndHandleCurrentCreation()
        {
            foreach (var weaponPlacePoint in _weaponPlacePoints)
            {
                weaponPlacePoint.OnCreateButtonPressed -= CreateWeapon;
                weaponPlacePoint.DisableCreateUI();
            }
        }

        private void CreateWeapon(WeaponCreatePoint point)
        {
            var newWeapon = _weaponFactory.CreateWeapon(_prefab, point.transform.position);
            
            _weaponsContainer.RegisterWeapon(newWeapon);

            point.DisableCreateUI();
            _weaponPlacePoints.Remove(point);
        }
    }
}