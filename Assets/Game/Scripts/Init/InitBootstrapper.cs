using VContainer.Unity;
using UnityEngine;
using VContainer;


public class InitBootstrapper : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        Debug.Log($"<color=white>Project context</color>");
        
        base.Configure(builder);
    }
}