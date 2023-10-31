using Game.Common.Interfaces;
using Game.Common.Scene;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Game.Init
{
    public class RootLifeScope : LifetimeScope
    {
        [SerializeField] private SceneTransitionHandler _transitionHandler;
        [SerializeField] private CoroutineRunner _coroutineRunner;
        
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder
                .Register<SceneLoader>(Lifetime.Singleton);

            builder
                .RegisterComponentInNewPrefab(_transitionHandler, Lifetime.Singleton)
                .DontDestroyOnLoad();
            
            builder
                .RegisterComponentInNewPrefab(_coroutineRunner, Lifetime.Singleton)
                .DontDestroyOnLoad()
                .As<ICoroutineRunner>();
        }
    }
}