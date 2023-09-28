using Game.Level.Enemies.BehaviorTree.Common;
using Game.Level.Enemies.BehaviorTree.Common.Nodes;
using Game.Level.Enemies.BehaviorTree.SharedBehavior;
using UnityEngine;


namespace Game.Level.Enemies.BehaviorTree.MeleeSimple
{
    public class SimpleEnemyBehaviorTree : EnemyBehaviorTree
    {
        private readonly EnemyBehaviorData _enemyBehaviorData;
        private readonly Transform _enemyTransform;
        private readonly IEnemy _enemy;


        public SimpleEnemyBehaviorTree(IEnemy enemy, Transform enemyTransform, EnemyBehaviorData enemyBehaviorData)
        {
            _enemyBehaviorData = enemyBehaviorData;
            _enemyTransform = enemyTransform;
            _enemy = enemy;
        }


        public override void Construct()
        {
            var searchForTargetNode = new SearchForTarget(this, _enemyTransform, _enemyBehaviorData.SearchDirection);
            var moveNode = new Move(_enemy, this);
            
            var attackSequence = CreateAttackSequence();

            _root = new Selector(searchForTargetNode, attackSequence, moveNode);
        }

        private Sequence CreateAttackSequence()
        {
            var attackNode = new Attack(this, _enemy, _enemyBehaviorData.AttackCooldown);

            var checkForAttackRangeNode =
                new CheckForAttackRange(this, _enemyTransform, _enemyBehaviorData.AttackRadius);

            return new Sequence(checkForAttackRangeNode, attackNode);
        }
    }
}