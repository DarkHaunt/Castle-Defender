using UnityEngine;


namespace Project.Scripts.Level.Weapons.Creation
{
    public class WeaponFactory
    {
        private readonly Transform _createdWeaponsParentObject;

        
        public WeaponFactory(Transform createdWeaponsParentObject)
        {
            _createdWeaponsParentObject = createdWeaponsParentObject;
        }
        
        
        public Weapon CreateWeapon(Weapon prefab, Vector2 position)
        {
            var weapon = Object.Instantiate(prefab, position, Quaternion.identity, _createdWeaponsParentObject);
            weapon.Init();
            
            return weapon;
        }
    }
}