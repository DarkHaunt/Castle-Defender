using DG.Tweening;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


namespace Project.Scripts.Common.Scene
{
    public class SceneTransitionHandler : MonoBehaviour
    {
        private const float FadeInTime = 0.7f;
        private const float FadeOutTime = 0.35f;

        [SerializeField] private Image _image;
        
        private CancellationTokenSource _cancellationToken;


        private void Awake()
            => UpdateCancellationSource();

        public async Task PlayFadeInAnimation()
        {
            _image.raycastTarget = true;
            
            await PlayAnimationClip(_image.DOFade(1f, FadeInTime));
        }

        public async Task PlayFadeOutAnimation()
        {
            _image.raycastTarget = false;
            
            await PlayAnimationClip(_image.DOFade(0f, FadeOutTime));
        }

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