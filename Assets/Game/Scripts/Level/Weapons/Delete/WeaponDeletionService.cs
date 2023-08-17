using Game.Level.Weapons.Maintain;
using UnityEngine;


namespace Game.Level.Weapons.Delete
{
    public class WeaponDeletionService
    {
        private readonly IWeaponsContainer _weaponsContainer;
        

        public WeaponDeletionService(IWeaponsContainer weaponsContainer)
        {
            _weaponsContainer = weaponsContainer;
        }
        
        
        public void StartHandleDeletion() 
        {
            foreach (var registeredWeapon in _weaponsContainer.GetAllRegisteredWeapons())
            {
                registeredWeapon.OnDeleteButtonPressed += DeleteWeapon;
                registeredWeapon.EnableDeleteUI();
            }
        }
				
        public void EndHandleDeletion() 
        {
            foreach (var registeredWeapon in _weaponsContainer.GetAllRegisteredWeapons())
            {
                registeredWeapon.OnDeleteButtonPressed -= DeleteWeapon;
                registeredWeapon.DisableDeleteUI();
            }
        }
        
        private void DeleteWeapon(Weapon weapon)
        {
            _weaponsContainer.UnregisterWeapon(weapon);
            weapon.DisableDeleteUI();
            
            Object.Destroy(weapon.gameObject);
        }
    }
}