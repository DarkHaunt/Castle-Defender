using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;
using System;


namespace Game.Common.Scene
{
    public class SceneLoader
    {
        private const float RequiredTimeToExecuteTransition = 1f;

        private readonly SceneTransitionHandler _transitionHandler;
        
        private CancellationTokenSource _cancellationTokenSource;


        public SceneLoader(SceneTransitionHandler transitionHandler)
        {
            _transitionHandler = transitionHandler;
            _cancellationTokenSource = new CancellationTokenSource();
            
            Application.quitting += _cancellationTokenSource.Cancel;
        }
        
        public async void LoadSceneWithTransition(string sceneKey, LoadSceneMode loadMode = LoadSceneMode.Single)
        {
            await _transitionHandler.PlayFadeInAnimation();

            var loadSceneProcess = LoadSceneAsync(sceneKey, loadMode);

            var longTimeSceneLoadingImitationTask = Task.Delay(TimeSpan.FromSeconds(RequiredTimeToExecuteTransition),
                _cancellationTokenSource.Token);

            await Task.WhenAll(longTimeSceneLoadingImitationTask, loadSceneProcess);

            await _transitionHandler.PlayFadeOutAnimation();
        }

        private async Task LoadSceneAsync(string sceneKey, LoadSceneMode loadMode)
        {
            var loadSceneProcess = SceneManager.LoadSceneAsync(sceneKey, loadMode);

            while (!loadSceneProcess.isDone && !_cancellationTokenSource.IsCancellationRequested)
                await Task.Yield();
        }
    }
}