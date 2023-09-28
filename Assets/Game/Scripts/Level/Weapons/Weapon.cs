using Game.Level.Weapons.StateMachine.States;
using Game.Level.Weapons.EnemiesDetect;
using Game.Level.Weapons.StateMachine;
using Game.Level.Enemies;
using UnityEngine;
using System;


namespace Game.Level.Weapons
{
    public abstract class Weapon : MonoBehaviour, IWeaponBehaviorHandler
    {
        [SerializeField] private EnemiesDetector _enemiesDetector;
        [SerializeField] private float _attackRadius;

        private WeaponStateMachine _weaponStateMachine;
        
        
        public void Init()
        {
            _enemiesDetector.Init(_attackRadius);
            
            _weaponStateMachine = new WeaponStateMachine();
            _weaponStateMachine.SwitchToState<WeaponSearchForTarget>();
        }

        public abstract void Attack(IEnemy target, Action onComplete);
        public abstract void Reload();
    }
}