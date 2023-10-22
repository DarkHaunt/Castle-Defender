using Game.Level.Enemies;


namespace Game.Level.Weapons.EnemiesDetection
{
    public class WeaponTargetHolder
    {
        private IEnemy _target;


        public void SetEnemyTarget(IEnemy targetBehaviorHandler)
        {
            _target = targetBehaviorHandler;
            
            _target.OnDeath += SetEmptyTarget;
        }

        public bool TryToGetEnemyTarget(out IEnemy targetBehaviorHandler)
        {
            targetBehaviorHandler = _target;

            return targetBehaviorHandler != null;
        }

        private void SetEmptyTarget(IEnemy target)
        {
            target.OnDeath -= SetEmptyTarget;
            
            _target = null;
        }
    }
}