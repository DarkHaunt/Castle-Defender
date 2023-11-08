using UnityEngine;


namespace Project.Scripts.Level.Weapons.Creation
{
    public interface IWeaponFactory
    {
        Weapon CreateWeapon(Weapon prefab, Vector2 position);
    }
}