using Game.Level.Weapons;
using UnityEngine;


namespace Game.Level.Factories.Weapons
{
    public interface IWeaponFactory
    {
        Weapon CreateWeapon(Weapon prefab, Vector2 position);
    }
}