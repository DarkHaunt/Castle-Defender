using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;
using VContainer;
using System;


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

            Debug.Log($"<color=white>CONSTRUCT</color>");
            
            _instance = this;
        }


        public static async void LoadSceneWithTransition(string sceneKey, LoadSceneMode loadMode = LoadSceneMode.Single)
        {
            await _instance._transitionHandler.PlayFadeInAnimation();

            var loadSceneProcess = LoadSceneAsync(sceneKey, loadMode);

            var longTimeSceneLoadingImitationTask = Task.Delay(TimeSpan.FromSeconds(RequiredTimeToExecuteTransition),
                _instance._cancellationTokenSource.Token);

            await Task.WhenAny(longTimeSceneLoadingImitationTask, loadSceneProcess);

            await _instance._transitionHandler.PlayFadeOutAnimation();
        }

        private static async Task LoadSceneAsync(string sceneKey, LoadSceneMode loadMode)
        {
            var loadSceneProcess = SceneManager.LoadSceneAsync(sceneKey, loadMode);

            while (!loadSceneProcess.isDone && !_instance._cancellationTokenSource.IsCancellationRequested)
                await Task.Yield();
        }
    }
}