using UnityEngine;


namespace Project.Scripts.Level.Weapons.Handling.Create
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