using System.Threading.Tasks;
using System.Threading;
using UnityEngine;
using VContainer;


namespace Game.Common.Scene
{
    public class SceneTransitionHandler : MonoBehaviour
    {
        private const string FadeOutClipID = "FadeOut";
        private const string FadeInClipID = "FadeIn";

        private Animator _animator;
        private CancellationTokenSource _transitionCancellationSource;


        private bool TaskWasCancelled
        {
            get
            {
                var wasCancelled = _transitionCancellationSource.IsCancellationRequested;

                if (wasCancelled)
                {
                    _transitionCancellationSource.Dispose();
                    _transitionCancellationSource = new CancellationTokenSource();
                }

                return wasCancelled;
            }
        }

        
        [Inject]
        private void Construct()
        {
            _animator = gameObject.AddComponent<Animator>();
            _transitionCancellationSource = new CancellationTokenSource();
            
            Application.quitting += _transitionCancellationSource.Cancel;

            gameObject.SetActive(false);
        }

        public async Task PlayFadeInAnimation()
            => await PlayAnimationClip(FadeInClipID);

        public async Task PlayFadeOutAnimation()
            => await PlayAnimationClip(FadeOutClipID);

        private async Task PlayAnimationClip(string trigger)
        {
            if (TaskWasCancelled)
                await Task.FromCanceled(_transitionCancellationSource.Token);
            
            if (IsAnimationPlaying())
            {
                Debug.LogError($"Animation component in {gameObject.name} is playing clip, so you can't play another until clip will end");
                await Task.FromCanceled(CancellationToken.None);
            }
            
            _animator.SetTrigger(trigger);

            gameObject.SetActive(true);

            await WaitUntilPlayingEnds();

            gameObject.SetActive(false);
        }

        private bool IsAnimationPlaying()
            => _animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f;

        private async Task WaitUntilPlayingEnds()
        {
            while (!TaskWasCancelled && IsAnimationPlaying())
                await Task.Yield();
        }
    }
}
