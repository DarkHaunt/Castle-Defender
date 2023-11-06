using System.Collections.Generic;
using Project.Scripts.Menu.UI;
using Game.Common.Scene;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Project.Scripts.Menu.Bootstrapping
{
    public class MenuLifeScope : LifetimeScope
    {
        [Header("--- View ---")]
        [SerializeField] private List<LevelButton> _levelButtons;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<LevelSelectService>(Lifetime.Scoped);
            builder.Register<SceneLoader>(Lifetime.Scoped);
            builder.RegisterInstance(_levelButtons);
        }
    }
}