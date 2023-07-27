using System.Collections.Generic;
using Game.Level.Weapon;
using VContainer.Unity;
using UnityEngine;
using Interfaces;
using VContainer;


namespace Game.Level
{
    public class LevelBootstrapper : LifetimeScope
    {
        [SerializeField] private List<WeaponPlacePoint> _weaponsPoints;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log($"<color=white>Configure</color>");

            builder
                .Register<Castle>(Lifetime.Singleton)
                .WithParameter(_weaponsPoints as IList<WeaponPlacePoint>)
                .As<ICastle>();

            builder.RegisterEntryPoint<CastleService>();
        }
    }
}