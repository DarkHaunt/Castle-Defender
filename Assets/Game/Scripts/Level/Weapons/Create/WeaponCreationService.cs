using System.Collections.Generic;
using UnityEngine;


namespace Game.Level.Weapons.Create
{
    public class WeaponCreationService
    {
        private readonly ISet<WeaponCreatePoint> _weaponPlacePoints;
        private readonly WeaponFactory _weaponFactory;

        private Weapon _targetPrefab;

        
        public WeaponCreationService(WeaponFactory weaponFactory, IEnumerable<WeaponCreatePoint> placePoints)
        {
            _weaponPlacePoints = new HashSet<WeaponCreatePoint>(placePoints);
            
            _weaponFactory = weaponFactory;
        }
        
        
        public void Enable(Weapon weaponPrefab)
        {
            _targetPrefab = weaponPrefab;
            
            foreach (var weaponPlacePoint in _weaponPlacePoints)
            {
                weaponPlacePoint.OnCreateButtonPressed += CreateWeapon;
                weaponPlacePoint.EnableCreateUI();

                Debug.Log($"<color=white>Enable Creation</color>");
            }
        }
				
        public void Disable()
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
            Debug.Log($"<color=red>Weapon Created</color>");

            _weaponFactory.CreateWeapon(_targetPrefab, position);
        }
    }
}