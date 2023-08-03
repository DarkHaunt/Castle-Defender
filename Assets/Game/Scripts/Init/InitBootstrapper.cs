using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace Game.Init
{
    public class InitBootstrapper : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log($"<color=white>Project context</color>");
        
            base.Configure(builder);
        }
    }
}