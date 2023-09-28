using Game.Level.Weapons.EnemiesDetect;


namespace Game.Level.Weapons.StateMachine.States
{
    public class WeaponAttack : IWeaponState
    {
        private readonly WeaponTargetHolder _targetHolder;

        public WeaponAttack(WeaponTargetHolder targetHolder)
        {
            _targetHolder = targetHolder;
        }
        
        
        public void Enter()
        {
           // if(_targetHolder.TryToGetEnemyTarget(out IEne))
        }

        public void Exit()
        {
        }

        public void Tick()
        {
        }
    }
}