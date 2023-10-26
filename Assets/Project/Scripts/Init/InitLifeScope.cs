using Game.Common.Scene;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Game.Init
{
    public class InitLifeScope : LifetimeScope
    {
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private SceneTransitionHandler _sceneTransitionHandler;
        
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder
                .RegisterComponentInNewPrefab(_sceneLoader, Lifetime.Singleton)
                .DontDestroyOnLoad();

            builder
                .RegisterComponentInNewPrefab(_sceneTransitionHandler, Lifetime.Singleton)
                .DontDestroyOnLoad();

            Debug.Log($"<color=white>{builder.Exists(typeof(SceneTransitionHandler))}</color>");
        }
    }
}