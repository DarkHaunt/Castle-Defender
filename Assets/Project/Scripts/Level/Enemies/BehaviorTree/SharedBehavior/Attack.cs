using Project.Scripts.Level.Enemies.BehaviorTree.Common.Nodes;
using Project.Scripts.Level.Enemies.BehaviorTree.Common;
using Project.Scripts.Level.Enemies.Animation;
using Project.Scripts.Common.Time;
using UnityEngine;


namespace Project.Scripts.Level.Enemies.BehaviorTree.SharedBehavior
{
    public class Attack : Node
    {
        private readonly AnimationModel _animationModel;
        private readonly EnemyBehaviorTree _tree;
        
        private readonly Timer _cooldownTimer;
        private readonly Timer _attackTimer;
        private readonly IEnemy _enemy;


        public Attack(EnemyBehaviorTree tree, IEnemy enemy, AnimationModel animationModel, Timer cooldownTimer)
        {
            _animationModel = animationModel;
            _cooldownTimer = cooldownTimer;
            
            _enemy = enemy;
            _tree = tree;

            _attackTimer = new Timer();
        }


        public override ProcessState Process(float timeStep)
        {
            _cooldownTimer.Update(timeStep);
            _attackTimer.Update(timeStep);
            
            if(_cooldownTimer.IsRunning)
                return UpdateStateFor(ProcessState.Failure);
            
            if(_attackTimer.IsRunning)
                return UpdateStateFor(ProcessState.Running);

            Debug.Log($"<color=white>Log</color>");
            
            var attackTime = _animationModel.PlayAttackAnimation();
            _attackTimer.Launch(attackTime);

            var attackTarget = _tree.GetTarget();
            _enemy.Attack(attackTarget);

            _cooldownTimer.Relaunch();

            return UpdateStateFor(ProcessState.Success);
        }
    }
}