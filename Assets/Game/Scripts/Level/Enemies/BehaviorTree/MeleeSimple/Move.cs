namespace Game.Level.Enemies.BehaviorTree
{
    public class Move : Node
    {
        private readonly EnemyBehaviorTree _tree;
        private readonly IEnemy _enemy;

        
        public Move(IEnemy enemy, EnemyBehaviorTree tree)
        {
            _enemy = enemy;
            _tree = tree;
        }
        
        
        public override ProcessState Process(float timeStep)
        {
            var target = _tree.GetTarget();
            
            _enemy.Move(target, timeStep);

            return ProcessState.Running;
        }
    }
}