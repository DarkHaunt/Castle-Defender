using Game.Level.Enemies;


namespace Game.Level.Weapons.EnemiesDetect
{
    public class WeaponTargetHolder
    {
        private IEnemyBehaviorHandler _target;


        public void SetEnemyTarget(IEnemyBehaviorHandler enemyBehaviorHandler)
        {
            _target = enemyBehaviorHandler;
            
            _target.OnDeath += SetEmptyTarget;
        }

        public bool TryToGetEnemyTarget(out IEnemyBehaviorHandler enemyBehaviorHandler)
        {
            enemyBehaviorHandler = _target;

            return enemyBehaviorHandler != null;
        }

        private void SetEmptyTarget(IEnemyBehaviorHandler target)
        {
            target.OnDeath -= SetEmptyTarget;
            
            _target = null;
        }
    }
}