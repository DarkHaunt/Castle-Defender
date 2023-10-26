using Game.Common.Interfaces;
using Game.Level.Enemies;
using System;


namespace Game.Level.Weapons
{
    public interface IWeaponBehaviorHandler : ICoroutineRunner
    {
        void Attack(IEnemy target, Action onComplete);
        void Reload();
    }
}