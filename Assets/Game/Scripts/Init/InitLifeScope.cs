using Game.Common.Interfaces;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Game.Init
{
    public class InitLifeScope : LifetimeScope
    {
        [SerializeField] private CoroutineRunner _coroutineRunner;
        
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder
                .RegisterComponentInNewPrefab(_coroutineRunner, Lifetime.Singleton)
                .As<ICoroutineRunner>();
        }
    }
}