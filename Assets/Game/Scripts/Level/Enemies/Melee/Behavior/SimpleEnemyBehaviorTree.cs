using Game.Level.Enemies.BehaviorTree.SharedBehavior;
using Game.Level.Enemies.BehaviorTree.Common.Nodes;
using Game.Level.Enemies.BehaviorTree.Common;


namespace Game.Level.Enemies.Melee.Behavior
{
    public class SimpleEnemyBehaviorTree : EnemyBehaviorTree
    {
        private readonly EnemyBehaviorData _enemyBehaviorData;
        private readonly IEnemy _enemy;


        public SimpleEnemyBehaviorTree(IEnemy enemy, EnemyBehaviorData enemyBehaviorData)
        {
            _enemyBehaviorData = enemyBehaviorData;
            _enemy = enemy;
        }


        public override void Construct()
        {
            var searchForTargetNode = new SearchForTarget(this, _enemy, _enemyBehaviorData.SearchDirection);
            var moveNode = new Move(_enemy, this);
            
            _root = new Selector(searchForTargetNode, CreateAttackSequence(), moveNode);
        }

        private Sequence CreateAttackSequence()
        {
            var attackNode = new Attack(this, _enemy, _enemyBehaviorData.AttackCooldown);

            var checkForAttackRangeNode =
                new CheckForAttackRange(this, _enemy, _enemyBehaviorData.AttackRadius);

            return new Sequence(checkForAttackRangeNode, attackNode);
        }
    }
}