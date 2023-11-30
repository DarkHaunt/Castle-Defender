using Spine.Unity;
using Spine;


namespace Project.Scripts.Level.Enemies.Animation
{
    public class AnimationModel
    {
        private readonly SkeletonAnimation _animation;
        private readonly AnimationData _animations;
        
        private TrackEntry _lastTrack;
        

        public AnimationModel(SkeletonAnimation animation, AnimationData animations)
        {
            _animation = animation;
            _animations = animations;
        }


        public void PlayWalkAnimation()
            => PlayTrack(_animations.WalkAnimName, true); 
        
        public void PlayIdleAnimation()
            => PlayTrack(_animations.IdleAnimName, true);        
        
        public void PlayAttackAnimation()
            => PlayTrack(_animations.AttackAnimName);        
        
        public void PlayDeathAnimation()
            => PlayTrack(_animations.DeathAnimName);

        private void PlayTrack(string animName, bool isLooped = false, int tackIndex = 0)
        {
            if (IsShouldNotSwitchAnimation(animName))
                return;
            
            _lastTrack = _animation.state.SetAnimation(tackIndex, animName, isLooped);
        }

        private bool IsShouldNotSwitchAnimation(string animName)
            => _lastTrack != null && _lastTrack.Animation.Name == animName && !_lastTrack.IsComplete;
    }
}