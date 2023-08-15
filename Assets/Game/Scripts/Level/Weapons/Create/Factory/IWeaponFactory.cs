using UnityEngine;


namespace Game.Level.Weapons.Create.Factory
{
    public interface IWeaponFactory
    {
        Weapon CreateWeapon(Weapon prefab, Vector2 position);
    }
}