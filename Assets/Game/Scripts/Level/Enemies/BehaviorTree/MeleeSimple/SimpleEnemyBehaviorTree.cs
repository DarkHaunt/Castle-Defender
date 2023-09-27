using Game.Level.Enemies.BehaviorTree.SharedBehavior;
using UnityEngine;


namespace Game.Level.Enemies.BehaviorTree
{
    public class SimpleEnemyBehaviorTree : EnemyBehaviorTree
    {
        private readonly EnemyBehaviorData _enemyBehaviorData;
        private readonly Transform _enemyTransform;
        private readonly IEnemyBehaviorHandler _enemyBehaviorHandler;


        public SimpleEnemyBehaviorTree(IEnemyBehaviorHandler enemyBehaviorHandler, Transform enemyTransform, EnemyBehaviorData enemyBehaviorData)
        {
            _enemyBehaviorData = enemyBehaviorData;
            _enemyTransform = enemyTransform;
            _enemyBehaviorHandler = enemyBehaviorHandler;
        }


        public override void Construct()
        {
            var searchForTargetNode = new SearchForTarget(this, _enemyTransform, _enemyBehaviorData.SearchDirection);
            var moveNode = new Move(_enemyBehaviorHandler, this);
            
            var attackSequence = CreateAttackSequence();

            _root = new Selector(searchForTargetNode, attackSequence, moveNode);
        }

        private Sequence CreateAttackSequence()
        {
            var attackNode = new Attack(this, _enemyBehaviorHandler, _enemyBehaviorData.AttackCooldown);

            var checkForAttackRangeNode =
                new CheckForAttackRange(this, _enemyTransform, _enemyBehaviorData.AttackRadius);

            return new Sequence(checkForAttackRangeNode, attackNode);
        }
    }
}