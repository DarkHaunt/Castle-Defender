using System.Threading.Tasks;
using System.Threading;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;


namespace Game.Common.Scene
{
    public class SceneTransitionHandler : MonoBehaviour
    {
        private const float FadeInTime = 1f;
        private const float FadeOutTime = 0.5f;

        [SerializeField] private Image _image;
        
        private CancellationTokenSource _cancellationToken;


        private void Awake()
            => _cancellationToken = new CancellationTokenSource();

        public async Task PlayFadeInAnimation()
            => await PlayAnimationClip(_image.DOFade(1f, FadeInTime));

        public async Task PlayFadeOutAnimation()
            => await PlayAnimationClip(_image.DOFade(0f, FadeOutTime));

        public void CancelTransition()
            => _cancellationToken?.Cancel();

        private async Task PlayAnimationClip(Tween animationTween)
        {
            if (_cancellationToken.IsCancellationRequested)
            {
                UpdateCancellationSource();
                
                await Task.FromCanceled(_cancellationToken.Token);
            }

            await animationTween.AsyncWaitForCompletion();
        }

        private void UpdateCancellationSource()
        {
            _cancellationToken?.Dispose();
            _cancellationToken = new CancellationTokenSource();
        }
    }
}