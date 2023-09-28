using Game.Level.Weapons.StateMachine.States;
using Game.Level.Weapons.EnemiesDetect;
using Game.Level.Weapons.StateMachine;
using UnityEngine;


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

        public abstract void Attack();
        public abstract void Reload();
    }
}