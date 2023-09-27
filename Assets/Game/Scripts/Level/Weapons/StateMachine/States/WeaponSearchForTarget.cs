using Game.Level.Weapons.EnemiesDetect;
using Game.Extensions;


namespace Game.Level.Weapons.StateMachine.States
{
    public class WeaponSearchForTarget : IWeaponState
    {
        private readonly IWeaponStateSwitcher _weaponStateSwitcher;
        private readonly WeaponTargetHolder _weaponTargetHolder;
        private readonly EnemiesDetector _enemiesDetector;


        public WeaponSearchForTarget(IWeaponStateSwitcher weaponStateSwitcher, WeaponTargetHolder weaponTargetHolder,
            EnemiesDetector enemiesDetector)
        {
            _weaponStateSwitcher = weaponStateSwitcher;
            _weaponTargetHolder = weaponTargetHolder;
            _enemiesDetector = enemiesDetector;
        }


        public void Enter()
            => _enemiesDetector.OnEnemyDetected += ChoseEnemyTarget;

        public void Exit()
            => _enemiesDetector.OnEnemyDetected -= ChoseEnemyTarget;

        public void Tick() {}

        private void ChoseEnemyTarget()
        {
            var enemy = _enemiesDetector.GetDetectedEnemies().PickRandom();
            
            _weaponTargetHolder.SetEnemyTarget(enemy);
            
            _weaponStateSwitcher.SwitchToState<WeaponAttack>();
        }
    }
}