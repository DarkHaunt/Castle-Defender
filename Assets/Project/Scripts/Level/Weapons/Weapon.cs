using Game.Level.Weapons.StateMachine.States;
using Game.Level.Weapons.EnemiesDetection;
using Game.Level.Weapons.StateMachine;
using Game.Level.Enemies;
using UnityEngine;
using System;


namespace Game.Level.Weapons
{
    public abstract class Weapon : MonoBehaviour, IWeaponBehaviorHandler
    {
        [SerializeField] private EnemiesDetector _enemiesDetector;

        [Header("--- Weapon Behavior ---")]
        [SerializeField] protected float _damage;
        [SerializeField] private float _attackRadius;
        [SerializeField] private float _reloadTime;
        
        private WeaponStateMachine _weaponStateMachine;
        
        
        public void Init()
        {
            _enemiesDetector.Init(_attackRadius);

            var weaponTargetHolder = new WeaponTargetHolder();
            _weaponStateMachine = new WeaponStateMachine(this, weaponTargetHolder, _enemiesDetector, _reloadTime);
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