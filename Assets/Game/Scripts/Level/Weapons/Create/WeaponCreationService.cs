using System.Collections.Generic;
using UnityEngine;


namespace Game.Level.Weapons.Create
{
    public class WeaponCreationService
    {
        private readonly ISet<WeaponPlacePoint> _weaponPlacePoints;


        public WeaponCreationService(IEnumerable<WeaponPlacePoint> placePoints)
        {
            _weaponPlacePoints = new HashSet<WeaponPlacePoint>(placePoints);
        }
        
        
        public void Enable() 
        {
            foreach (var weaponPlacePoint in _weaponPlacePoints)
            {
                weaponPlacePoint.RegisterCreateButtonClick(CreateWeapon);
                weaponPlacePoint.EnableCreateUI();

                Debug.Log($"<color=white>Enable Creation</color>");
            }
        }
				
        public void Disable() 
        {
            foreach (var weaponPlacePoint in _weaponPlacePoints)
            {
                weaponPlacePoint.UnregisterCreateButtonClick(CreateWeapon);
                weaponPlacePoint.DisableCreateUI();
            }
        }

        private void CreateWeapon()
        {
            Debug.Log($"<color=red>Weapon Created</color>");
        }
    }
}