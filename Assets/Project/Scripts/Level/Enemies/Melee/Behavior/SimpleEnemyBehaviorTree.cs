﻿using Project.Scripts.Level.Enemies.BehaviorTree.SharedBehavior;
using Project.Scripts.Level.Enemies.BehaviorTree.Common.Nodes;
using Project.Scripts.Level.Enemies.BehaviorTree.Common;
using Project.Scripts.Level.Enemies.Animation;


namespace Project.Scripts.Level.Enemies.Melee.Behavior
{
    public class SimpleEnemyBehaviorTree : EnemyBehaviorTree
    {
        private readonly EnemyBehaviorData _enemyBehaviorData;
        private readonly AnimationModel _animationModel;
        private readonly IEnemy _enemy;


        public SimpleEnemyBehaviorTree(IEnemy enemy, AnimationModel animationModel, EnemyBehaviorData enemyBehaviorData)
        {
            _enemyBehaviorData = enemyBehaviorData;
            _animationModel = animationModel;
            _enemy = enemy;
        }


        public override void Construct()
        {
            var searchForTargetNode = new SearchForTarget(this, _enemy, _enemyBehaviorData.SearchDirection);
            var moveNode = new Move(_enemy, _animationModel, this);
            
            _root = new Selector(searchForTargetNode, CreateAttackSequence(), moveNode);
        }

        private Sequence CreateAttackSequence()
        {
            var attackNode = new Attack(this, _enemy, _animationModel, _enemyBehaviorData.AttackCooldown);

            var checkForAttackRangeNode =
                new CheckForAttackRange(this, _enemy, _enemyBehaviorData.AttackRadius);

            return new Sequence(checkForAttackRangeNode, attackNode);
        }
    }
}