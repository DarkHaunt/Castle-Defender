using Project.Scripts.Level.Enemies;
using Project.Scripts.Level.Weapons.EnemiesDetection;
using Project.Scripts.Level.Weapons.StateMachine;
using Project.Scripts.Level.Weapons.StateMachine.States;
using System;
using UnityEngine;


namespace Project.Scripts.Level.Weapons
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