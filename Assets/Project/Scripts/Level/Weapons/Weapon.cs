using Game.Level.Weapons.StateMachine.States;
using Game.Level.Weapons.StateMachine;
using Game.Level.Enemies;
using Game.Level.Weapons.EnemiesDetection;
using UnityEngine;
using System;


namespace Game.Level.Weapons
{
    public abstract class Weapon : MonoBehaviour, IWeaponBehaviorHandler
    {
        [SerializeField] private EnemiesDetector _enemiesDetector;

        [Header("--- Weapon Behavior ---")]
        [SerializeField] protected float _damage;
        [SerializeField] private WeaponBehaviorData _weaponBehaviorData;

        private WeaponStateMachine _weaponStateMachine;
        
        
        public void Init()
        {
            _enemiesDetector.Init(_weaponBehaviorData.AttackRadius);

            var weaponTargetHolder = new WeaponTargetHolder();
            _weaponStateMachine = new WeaponStateMachine(this, weaponTargetHolder, _weaponBehaviorData, _enemiesDetector);
        }

        public void Enable()
        {
            _enemiesDetector.Enable();
            _weaponStateMachine.SwitchToState<WeaponSearchForTarget>();
        }
				
        public void Disable() 
            => _enemiesDetector.Disable();

        public abstract void Attack(IEnemy target, Action onComplete);
        public abstract void Reload();
    }
}