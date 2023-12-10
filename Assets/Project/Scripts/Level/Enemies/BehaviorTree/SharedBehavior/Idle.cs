using Project.Scripts.Common.Infrastructure;
using Project.Scripts.Level.Enemies.BehaviorTree.Common.Nodes;
using Project.Scripts.Level.Enemies.Animation;


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
            _cooldownTimer.Update(timeStep);
            
            if (_cooldownTimer.IsRunning)
            {
                _animationModel.PlayIdleAnimation();
                return UpdateStateFor(ProcessState.Running);
            }

            return UpdateStateFor(ProcessState.Success);
        }
    }
}