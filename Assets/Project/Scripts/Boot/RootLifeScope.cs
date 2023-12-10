using Project.Scripts.Common.Coroutines;
using Project.Scripts.Common.Scene;
using Project.Scripts.Configs;
using Project.Scripts.Consume;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Project.Scripts.Boot
{
    public class RootLifeScope : LifetimeScope
    {
        [SerializeField] private SceneTransitionHandler _transitionHandler;
        [SerializeField] private CoroutineRunner _coroutineRunner;
        
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterCoinsHandleService(builder);
            RegisterSceneLoaderSystem(builder);
            RegisterCoroutineRunner(builder);
            RegisterConfigProvider(builder);
        }

        private void RegisterCoinsHandleService(IContainerBuilder builder)
        {
            builder.Register<CoinsHandleService>(Lifetime.Singleton);
        }

        private void RegisterConfigProvider(IContainerBuilder builder)
        {
            builder.Register<ConfigsProvider>(Lifetime.Singleton);
        }

        private void RegisterCoroutineRunner(IContainerBuilder builder)
        {
            builder
                .RegisterComponentInNewPrefab(_coroutineRunner, Lifetime.Singleton)
                .DontDestroyOnLoad()
                .As<ICoroutineRunner>();
        }

        private void RegisterSceneLoaderSystem(IContainerBuilder builder)
        {
            builder
                .Register<SceneLoader>(Lifetime.Singleton);

            builder
                .RegisterComponentInNewPrefab(_transitionHandler, Lifetime.Singleton)
                .DontDestroyOnLoad();
        }
    }
}