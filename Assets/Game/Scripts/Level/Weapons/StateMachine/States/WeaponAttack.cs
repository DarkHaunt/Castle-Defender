using Game.Level.Weapons.EnemiesDetect;
using Game.Level.StateMachine.States;
using Game.Level.StateMachine;
using Game.Level.Enemies;


namespace Game.Level.Weapons.StateMachine.States
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