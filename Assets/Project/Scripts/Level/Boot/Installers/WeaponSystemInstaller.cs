using Project.Scripts.Level.Weapons.HandlePoints;
using Project.Scripts.Level.Weapons.Creation;
using Project.Scripts.Level.Weapons.Handling;
using Project.Scripts.Level.Weapons.View;
using Project.Scripts.Level.Weapons;
using Project.Scripts.Configs.Game;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Project.Scripts.Level.Boot.Installers
{
    public class WeaponSystemInstaller : IInstaller
    {
        private readonly Weapon _creationPrefab;
        private readonly Transform _weaponParent;
        private readonly WeaponSystemView _weaponSystemView;

        
        public WeaponSystemInstaller(Weapon prefab, Transform weaponParent, 
            WeaponSystemView weaponSystemView)
        {
            _weaponSystemView = weaponSystemView;
            _weaponParent = weaponParent;
            _creationPrefab = prefab;
        }
        
        
        public void Install(IContainerBuilder builder)
        {
            RegisterWeaponProvider(builder);
            
            RegisterWeaponDeleteService(builder);
            RegisterWeaponUpdateService(builder);
            RegisterWeaponCreationService(builder);

            RegisterWeaponSystemView(builder);
            RegisterWeaponSystemBinder(builder);
            RegisterWeaponHandleService(builder);
        }

        private void RegisterWeaponProvider(IContainerBuilder builder)
        {
            builder.Register<WeaponProvider>(Lifetime.Scoped);
        }

        private void RegisterWeaponCreationService(IContainerBuilder builder)
        {
            builder
                .Register<WeaponCreateService>(Lifetime.Scoped)
                .WithParameter(_creationPrefab);
            
            builder.Register<WeaponPointsContainer>(Lifetime.Scoped);

            builder
                .Register<WeaponFactory>(Lifetime.Scoped)
                .WithParameter(_weaponParent);
        }

        private void RegisterWeaponUpdateService(IContainerBuilder builder)
        {
            builder.Register<WeaponUpdateService>(Lifetime.Scoped);
        }

        private void RegisterWeaponDeleteService(IContainerBuilder builder)
        {
            builder.Register<WeaponDeletionService>(Lifetime.Scoped);
        }

        private void RegisterWeaponSystemView(IContainerBuilder builder)
        {
            builder.RegisterComponent(_weaponSystemView);
        }

        private void RegisterWeaponSystemBinder(IContainerBuilder builder)
        {
            builder.Register<WeaponSystemBinder>(Lifetime.Scoped);
        }

        private void RegisterWeaponHandleService(IContainerBuilder builder)
        {
            builder.Register<WeaponHandleService>(Lifetime.Scoped);
        }
    }
}