using Game.Level.Enemies;
using System;


namespace Game.Level.Weapons
{
    public interface IWeaponBehaviorHandler
    {
        void Attack(IEnemy target, Action onComplete);
        void Reload();
    }
}