using System.Collections.Generic;
using VContainer.Unity;
using UnityEngine;
using Interfaces;
using VContainer;


namespace Game.Level
{
    public class LevelBootstrapper : LifetimeScope
    {
        [SerializeField] private List<Transform> _weaponsPoints;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log($"<color=white>Configure</color>");

            builder
                .Register<Castle>(Lifetime.Singleton)
                .WithParameter(_weaponsPoints as IList<Transform>)
                .As<ICastle>();

            builder.RegisterEntryPoint<CastleService>();
        }
    }
}