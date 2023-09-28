using Game.Level.Enemies.BehaviorTree.Common;
using Game.Level.Enemies.BehaviorTree.Common.Nodes;
using UnityEngine;


namespace Game.Level.Enemies.BehaviorTree.SharedBehavior
{
    public class CheckForAttackRange : Node
    {
        private readonly EnemyBehaviorTree _tree;
        private readonly float _attackRange;
        private readonly Transform _enemy;


        public CheckForAttackRange(EnemyBehaviorTree tree, Transform enemy, float attackRange)
        {
            _attackRange = attackRange;
            _enemy = enemy;
            _tree = tree;
        }


        public override ProcessState Process(float timeStep)
        {
            var target = _tree.GetTarget();

            if (target == null || !IsOnAttackDistance(target))
                return UpdateStateFor(ProcessState.Failure);

            return UpdateStateFor(ProcessState.Success);
        }

        private bool IsOnAttackDistance(IAttackTarget target)
            => Vector2.Distance(target.Position, _enemy.position) < _attackRange;
    }
}