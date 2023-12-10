using Project.Scripts.Level.Enemies.BehaviorTree.Common.Nodes;
using Project.Scripts.Level.Enemies.BehaviorTree.Common;
using Project.Scripts.Level.Enemies.Animation;


namespace Project.Scripts.Level.Enemies.Melee.Behavior
{
    public class Move : Node
    {
        private readonly AnimationModel _animationModel;
        private readonly EnemyBehaviorTree _tree;
        private readonly IEnemy _enemy;


        public Move(IEnemy enemy, AnimationModel animationModel, EnemyBehaviorTree tree)
        {
            _animationModel = animationModel;
            _enemy = enemy;
            _tree = tree;
        }
        
        
        public override ProcessState Process(float timeStep)
        {
            var target = _tree.GetTarget();
            
            _animationModel.PlayWalkAnimation();
            _enemy.Move(target, timeStep);

            return ProcessState.Running;
        }
    }
}