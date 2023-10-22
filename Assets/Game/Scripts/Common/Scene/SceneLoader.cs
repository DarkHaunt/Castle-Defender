using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;


namespace Game.Common.Scene
{
    public class SceneLoader : MonoBehaviour
    {
        private static SceneLoader _instance;

        private const float RequiredTimeToExecuteTransition = 1f;

        private CancellationTokenSource _cancellationTokenSource;
        private SceneTransitionHandler _transitionHandler;


        [Inject]
        private void Construct(SceneTransitionHandler transitionHandler)
        {
            _transitionHandler = transitionHandler;
            _cancellationTokenSource = new CancellationTokenSource();
            
            Application.quitting += _cancellationTokenSource.Cancel;
        }


        public static async Task LoadSceneWithTransition(string sceneKey, LoadSceneMode loadMode = LoadSceneMode.Single)
        {
            await _instance._transitionHandler.PlayFadeOutAnimation();

            var loadSceneProcess = LoadSceneAsync(sceneKey, loadMode);

            var longTimeSceneLoadingImitationTask = Task.Delay(TimeSpan.FromSeconds(RequiredTimeToExecuteTransition),
                _instance._cancellationTokenSource.Token);

            var animationTask = _instance._transitionHandler.PlayLoadingAnimation(longTimeSceneLoadingImitationTask);

            var loadingAnimationTask = Task.WhenAny(longTimeSceneLoadingImitationTask, animationTask);

            await Task.WhenAll(loadingAnimationTask, loadSceneProcess);

            await _instance._transitionHandler.PlayFadeInAnimation();
        }

        private static async Task LoadSceneAsync(string sceneKey, LoadSceneMode loadMode)
        {
            var loadSceneProcess = SceneManager.LoadSceneAsync(sceneKey, loadMode);

            while (!loadSceneProcess.isDone && !_instance._cancellationTokenSource.IsCancellationRequested)
                await Task.Yield();
        }
    }
}