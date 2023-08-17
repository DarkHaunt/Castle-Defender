using Game.Level.Weapons.Create.Factory;
using Game.Level.Weapons.Create.Service;
using Game.Level.Weapons.Create.Binder;
using Game.Level.Weapons.Create.View;
using Game.Level.Weapons.Maintain;
using System.Collections.Generic;
using Game.Level.Weapons.Delete;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Game.Level.Weapons.Core
{
    public class WeaponSystemBootstrapper : LifetimeScope
    {
        [Header("--- Weapon Views ---")]
        [SerializeField] private Weapon _creationPrefab;
        [SerializeField] private Transform _weaponParent;
        [SerializeField] private WeaponCreationView _weaponCreationView;
        [SerializeField] private List<WeaponCreatePoint> _weaponPlacePoints;
        
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterWeaponsContainer(builder);
            
            RegisterWeaponDeleteService(builder);
            RegisterWeaponCreationService(builder);
            
            RegisterWeaponSystemView(builder);
            RegisterWeaponSystemBinder(builder);
        }
        
        private static void RegisterWeaponDeleteService(IContainerBuilder builder)
        {
            builder.Register<WeaponDeletionService>(Lifetime.Singleton);
        }

        private void RegisterWeaponsContainer(IContainerBuilder builder)
        {
            builder
                .Register<WeaponsContainer>(Lifetime.Singleton)
                .As<IWeaponsContainer>();
        }
        
        private void RegisterWeaponCreationService(IContainerBuilder builder)
        {
            builder
                .Register<WeaponCreateService>(Lifetime.Singleton)
                .WithParameter<IEnumerable<WeaponCreatePoint>>(_weaponPlacePoints)
                .WithParameter(_creationPrefab);

            builder
                .Register<WeaponFactory>(Lifetime.Singleton)
                .WithParameter(_weaponParent)
                .As<IWeaponFactory>();
        }

        private void RegisterWeaponSystemView(IContainerBuilder builder)
        {
            builder.RegisterComponent(_weaponCreationView);
        }

        private void RegisterWeaponSystemBinder(IContainerBuilder builder)
        {
            builder.Register<WeaponCreateBinder>(Lifetime.Singleton);
        }
    }
}