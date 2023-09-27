namespace Game.Level.Enemies.BehaviorTree
{
    public class Move : Node
    {
        private readonly EnemyBehaviorTree _tree;
        private readonly IEnemyBehaviorHandler _enemyBehaviorHandler;

        
        public Move(IEnemyBehaviorHandler enemyBehaviorHandler, EnemyBehaviorTree tree)
        {
            _enemyBehaviorHandler = enemyBehaviorHandler;
            _tree = tree;
        }
        
        
        public override ProcessState Process(float timeStep)
        {
            var target = _tree.GetTarget();
            
            _enemyBehaviorHandler.Move(target, timeStep);

            return ProcessState.Running;
        }
    }
}