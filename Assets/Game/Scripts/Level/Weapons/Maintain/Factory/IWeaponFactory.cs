using UnityEngine;


namespace Game.Level.Weapons.Maintain.Factory
{
    public interface IWeaponFactory
    {
        Weapon CreateWeapon(Weapon prefab, Vector2 position);
    }
}