using Project.Scripts.Level.Enemies.BehaviorTree.Common;
using Project.Scripts.Level.Enemies.Melee.Behavior;
using Project.Scripts.Level.Enemies.Animation;
using Project.Scripts.Level.Common.Damage;
using System.Threading.Tasks;
using Spine.Unity;
using UnityEngine;


namespace Project.Scripts.Level.Enemies.Melee
{
    public class SimpleMelee : Enemy
    {
        [SerializeField] private float _meleeAttackDamage;

        [Header("--- Animations ---")]
        [SerializeField] private SkeletonAnimation _animation;
        [SerializeField] private SkeletonDataAsset _skeleton;
        [SerializeField, SpineAnimation(dataField: nameof(_skeleton))] private string _idleAnim;
        [SerializeField, SpineAnimation(dataField: nameof(_skeleton))] private string _walkAnim;
        [SerializeField, SpineAnimation(dataField: nameof(_skeleton))] private string _attackAnim;
        [SerializeField, SpineAnimation(dataField: nameof(_skeleton))] private string _deathAnim;


        protected override EnemyBehaviorTree CreateBehaviorTree(EnemyBehaviorData behaviorData)
        {
            var animationData = new AnimationData(_idleAnim, _walkAnim, _attackAnim, _deathAnim);
            var animationModel = new AnimationModel(_animation, animationData);

            return new SimpleEnemyBehaviorTree(this, animationModel, behaviorData);
        }

        public override void Move(Vector2 position, float timeDelta)
        {
            var targetDirection = (position - (Vector2)transform.position).normalized;
            var moveStep = targetDirection * _speed * timeDelta;
            
            _rigidbody.MovePosition(_rigidbody.position + moveStep);
        }

        public override void Attack(IAttackTarget attackTarget)
        {
            _rigidbody.velocity = Vector2.zero;
            attackTarget.GetDamage(_meleeAttackDamage);
        }

        protected override Task DieLogic()
        {
            gameObject.SetActive(false);

            return Task.CompletedTask;
        }
    }
}