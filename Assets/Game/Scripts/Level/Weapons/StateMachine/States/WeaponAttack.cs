using Game.Level.Weapons.EnemiesDetect;
using Game.Level.Enemies;


namespace Game.Level.Weapons.StateMachine.States
{
    public class WeaponAttack : IWeaponState
    {
        private readonly IWeaponBehaviorHandler _weaponBehaviorHandler;
        private readonly IWeaponStateSwitcher _weaponStateSwitcher;
        private readonly WeaponTargetHolder _targetHolder;


        public WeaponAttack(IWeaponStateSwitcher weaponStateSwitcher, IWeaponBehaviorHandler weaponBehaviorHandler,
            WeaponTargetHolder targetHolder)
        {
            _weaponBehaviorHandler = weaponBehaviorHandler;
            _weaponStateSwitcher = weaponStateSwitcher;
            _targetHolder = targetHolder;
        }


        public void Enter()
        {
            if (_targetHolder.TryToGetEnemyTarget(out IEnemy enemy))
                _weaponBehaviorHandler.Attack(enemy, SwitchToReload);
        }

        private void SwitchToReload()
            => _weaponStateSwitcher.SwitchToState<WeaponReload>();

        public void Exit() {}
        public void Tick() {}
    }
}