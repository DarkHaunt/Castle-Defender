using Project.Scripts.Common.StateMachine;
using Project.Scripts.Level.Enemies;
using Project.Scripts.Level.Weapons.EnemiesDetection;


namespace Project.Scripts.Level.Weapons.StateMachine.States
{
    public class WeaponAttack : IState
    {
        private readonly IWeaponBehaviorHandler _weaponBehaviorHandler;
        private readonly WeaponTargetHolder _targetHolder;
        private readonly IStateSwitcher _stateSwitcher;


        public WeaponAttack(IStateSwitcher stateSwitcher, IWeaponBehaviorHandler weaponBehaviorHandler,
            WeaponTargetHolder targetHolder)
        {
            _weaponBehaviorHandler = weaponBehaviorHandler;
            _stateSwitcher = stateSwitcher;
            _targetHolder = targetHolder;
        }


        public void Enter() 
        {
            if (_targetHolder.TryToGetEnemyTarget(out IEnemy enemy))
                _weaponBehaviorHandler.Attack(enemy, SwitchToReload);
        }

        private void SwitchToReload()
            => _stateSwitcher.SwitchToState<WeaponReload>();        

        public void Exit() {}
    }
}