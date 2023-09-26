using Game.Common.Time;


namespace Game.Level.Enemies.BehaviorTree.SharedBehavior
{
    public class Attack : Node
    {
        private readonly EnemyBehaviorTree _tree;
        private readonly Timer _cooldownTimer;
        private readonly float _cooldown;
        private readonly IEnemy _enemy;


        public Attack(EnemyBehaviorTree tree, IEnemy enemy, float cooldown)
        {
            _cooldown = cooldown;
            _enemy = enemy;
            _tree = tree;

            _cooldownTimer = new Timer(cooldown);
        }


        public override ProcessState Process(float timeStep)
        {
            _cooldownTimer.Update(timeStep);

            if (_cooldownTimer.IsRunning)
                return UpdateStateFor(ProcessState.Running);

            _cooldownTimer.Launch(_cooldown);
            
            var attackTarget = _tree.GetTarget();
            _enemy.Attack(attackTarget);

            return UpdateStateFor(ProcessState.Success);
        }
    }
}