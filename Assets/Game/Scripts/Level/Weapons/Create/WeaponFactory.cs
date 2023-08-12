﻿using UnityEngine;


namespace Game.Level.Weapons.Create
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
            return Object.Instantiate(prefab, position, Quaternion.identity, _createdWeaponsParentObject);
        }
    }
}