using Game.Level.Weapons.HandlePoints;
using Game.Level.Factories.Weapons;
using Game.Level.Services.Weapons;
using System.Collections.Generic;
using Game.Level.Views.Weapons;
using Game.Level.Weapons;
using Game.Level.Binders;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Game.Level.Bootstrappers
{
    public class WeaponSystemBootstrapper : LifetimeScope
    {
        [Header("--- Weapon Views ---")]
        [SerializeField] private Weapon _creationPrefab;
        [SerializeField] private Transform _weaponParent;
        [SerializeField] private WeaponSystemView _weaponSystemView;
        [SerializeField] private List<WeaponHandlePoint> _weaponPlacePoints;
        
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterWeaponsContainer(builder);
            
            RegisterWeaponDeleteService(builder);
            RegisterWeaponUpdateService(builder);
            RegisterWeaponCreationService(builder);

            RegisterWeaponSystemView(builder);
            RegisterWeaponSystemBinder(builder);
            RegisterWeaponHandleService(builder);
        }

        private void RegisterWeaponsContainer(IContainerBuilder builder)
        {
            builder
                .Register<WeaponPointsContainer>(Lifetime.Singleton)
                .WithParameter(_weaponPlacePoints)
                .As<IWeaponPointsContainer>();
        }

        private static void RegisterWeaponDeleteService(IContainerBuilder builder)
        {
            builder.Register<WeaponDeletionService>(Lifetime.Singleton);
        }

        private static void RegisterWeaponUpdateService(IContainerBuilder builder)
        {
            builder.Register<WeaponUpdateService>(Lifetime.Singleton);
        }

        private void RegisterWeaponCreationService(IContainerBuilder builder)
        {
            builder
                .Register<WeaponCreateService>(Lifetime.Singleton)
                .WithParameter(_creationPrefab);

            builder
                .Register<WeaponFactory>(Lifetime.Singleton)
                .WithParameter(_weaponParent)
                .As<IWeaponFactory>();
        }

        private void RegisterWeaponSystemView(IContainerBuilder builder)
        {
            builder.RegisterComponent(_weaponSystemView);
        }

        private void RegisterWeaponSystemBinder(IContainerBuilder builder)
        {
            builder.Register<WeaponSystemBinder>(Lifetime.Singleton);
        }

        private void RegisterWeaponHandleService(IContainerBuilder builder)
        {
            builder
                .Register<WeaponHandleService>(Lifetime.Singleton)
                .As<IWeaponHandleService>();
        }
    }
}