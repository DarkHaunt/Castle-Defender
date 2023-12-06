using Project.Scripts.Level.Enemies.BehaviorTree.Common.Nodes;
using Project.Scripts.Level.Enemies.Animation;
using Project.Scripts.Common.Time;
using UnityEngine;


namespace Project.Scripts.Level.Enemies.BehaviorTree.SharedBehavior
{
    public class Idle : Node
    {
        private readonly AnimationModel _animationModel;

        private readonly Timer _cooldownTimer;


        public Idle(AnimationModel animationModel, Timer cooldownTimer)
        {
            _animationModel = animationModel;
            _cooldownTimer = cooldownTimer;
        }

        public override ProcessState Process(float timeStep)
        {
            if (_cooldownTimer.IsRunning)
            {
                Debug.Log($"<color=white>Log pidar</color>");
                _animationModel.PlayIdleAnimation();
                return UpdateStateFor(ProcessState.Running);
            }

            return UpdateStateFor(ProcessState.Success);
        }
    }
}