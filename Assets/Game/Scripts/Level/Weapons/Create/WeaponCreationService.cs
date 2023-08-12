using System.Collections.Generic;
using UnityEngine;


namespace Game.Level.Weapons.Create
{
    public class WeaponCreationService
    {
        private readonly ISet<WeaponPlacePoint> _weaponPlacePoints;
        private readonly WeaponFactory _weaponFactory;

        private Weapon _targetPrefab;

        
        public WeaponCreationService(WeaponFactory weaponFactory, IEnumerable<WeaponPlacePoint> placePoints)
        {
            _weaponPlacePoints = new HashSet<WeaponPlacePoint>(placePoints);
            
            _weaponFactory = weaponFactory;
        }
        
        
        public void Enable(Weapon weaponPrefab)
        {
            _targetPrefab = weaponPrefab;
            
            foreach (var weaponPlacePoint in _weaponPlacePoints)
            {
                weaponPlacePoint.RegisterCreateButtonClick(CreateWeapon);
                weaponPlacePoint.EnableCreateUI();

                Debug.Log($"<color=white>Enable Creation</color>");
            }
        }
				
        public void Disable()
        {
            _targetPrefab = null;
            
            foreach (var weaponPlacePoint in _weaponPlacePoints)
            {
                weaponPlacePoint.UnregisterCreateButtonClick(CreateWeapon);
                weaponPlacePoint.DisableCreateUI();
            }
        }

        private void CreateWeapon()
        {
            Debug.Log($"<color=red>Weapon Created</color>");

            _weaponFactory.CreateWeapon(_targetPrefab, );
        }
    }
}