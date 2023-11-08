using Game.Common.Interfaces;
using Project.Scripts.Level.Enemies;
using System;


namespace Project.Scripts.Level.Weapons
{
    public interface IWeaponBehaviorHandler : ICoroutineRunner
    {
        void Attack(IEnemy target, Action onComplete);
        void Reload();
    }
}