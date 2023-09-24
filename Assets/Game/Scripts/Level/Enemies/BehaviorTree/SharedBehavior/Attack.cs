namespace Game.Level.Enemies.BehaviorTree.SharedBehavior
{
    public class Attack : Node
    {
        private readonly EnemyBehaviorTree _tree;
        private readonly float _cooldown;
        private readonly IEnemy _enemy;

        private float _passedTime;

        
        public Attack(EnemyBehaviorTree tree, IEnemy enemy, float cooldown)
        {
            _cooldown = cooldown;
            _enemy = enemy;
            _tree = tree;
        }

        
        public override ProcessState Process(float timeStep)
        {
            _passedTime += timeStep;

            if (_passedTime > _cooldown)
            {
                var attackTarget = _tree.GetTarget();

                _enemy.Attack(attackTarget);
                _passedTime = 0f;

                return UpdateStateFor(ProcessState.Running);
            }

            return UpdateStateFor(ProcessState.Failure);
        }
    }
}