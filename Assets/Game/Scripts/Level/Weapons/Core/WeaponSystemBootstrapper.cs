using Game.Level.Weapons.Create.Factory;
using Game.Level.Weapons.Create.Service;
using Game.Level.Weapons.Create.Binder;
using Game.Level.Weapons.Create.View;
using Game.Level.Weapons.Maintain;
using System.Collections.Generic;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Game.Level.Weapons.Core
{
    public class WeaponSystemBootstrapper : LifetimeScope
    {
        [Header("--- Weapon Views ---")]
        [SerializeField] private Transform _weaponParent;
        [SerializeField] private WeaponCreationView _weaponCreationView;
        [SerializeField] private List<WeaponCreatePoint> _weaponPlacePoints;
        
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterWeaponsContainer(builder);

            RegisterWeaponCreationSystem(builder);
        }

        private void RegisterWeaponsContainer(IContainerBuilder builder)
        {
            builder
                .Register<WeaponsContainer>(Lifetime.Singleton)
                .As<IWeaponsContainer>();
        }
        
        private void RegisterWeaponCreationSystem(IContainerBuilder builder)
        {
            builder
                .Register<WeaponCreationService>(Lifetime.Singleton)
                .WithParameter<IEnumerable<WeaponCreatePoint>>(_weaponPlacePoints);

            builder
                .Register<WeaponFactory>(Lifetime.Singleton)
                .WithParameter(_weaponParent)
                .As<IWeaponFactory>();
            
            builder.Register<WeaponCreationBinder>(Lifetime.Singleton);
            builder.RegisterComponent(_weaponCreationView);
        }
    }
}