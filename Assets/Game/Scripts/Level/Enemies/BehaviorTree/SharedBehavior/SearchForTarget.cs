using Game.Common.Physics;
using Game.Extensions;
using UnityEngine;


namespace Game.Level.Enemies.BehaviorTree.SharedBehavior
{
    using static LevelLayersProvider;


    public class SearchForTarget : Node
    {
        private const float RefreshCooldown = 0.5f;
        private const int MaxDetectTargets = 1;
        private const float MaxDistance = 100f;

        private readonly RaycastHit2D[] _nonAllocRaycastTargets;
        private readonly Transform _enemyTransform;
        private readonly Vector2 _searchDirection;
        private readonly EnemyBehaviorTree _tree;

        private float _passedTime;


        public SearchForTarget(EnemyBehaviorTree tree, Transform enemyTransform, Vector2 searchDirection)
        {
            _nonAllocRaycastTargets = new RaycastHit2D[MaxDetectTargets];
            _searchDirection = searchDirection;
            _enemyTransform = enemyTransform;
            _tree = tree;

            _passedTime = RefreshCooldown;
        }

        public override ProcessState Process(float timeStep)
        {
            _passedTime += timeStep;

            if (_passedTime < RefreshCooldown)
                return ProcessState.Failure;

            _passedTime = 0f;

            var targetsCount =
                Physics2D.RaycastNonAlloc(_enemyTransform.position, _searchDirection, _nonAllocRaycastTargets,
                    MaxDistance, LayerMaskExtensions.GetMaskFromLayer(PlayerLayer));

            if (targetsCount < MaxDetectTargets)
                return UpdateStateFor(ProcessState.Failure);

            var transformOfTarget = _nonAllocRaycastTargets.PickRandom().transform;

            if (transformOfTarget.TryGetComponent(out IAttackTarget target))
            {
                _tree.SetTarget(target);

                return UpdateStateFor(ProcessState.Success);
            }

            return UpdateStateFor(ProcessState.Failure);
        }
    }
}