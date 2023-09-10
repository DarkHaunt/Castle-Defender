using Game.Level.Views.Castles;
using Game.Level.Views.Weapons;
using Game.Level.Weapons;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Game.Level.Bootstrapping
{
    public class LevelLifeScope : LifetimeScope
    {
        [Header("--- Main ---")]
        [SerializeField] private LevelBootstrapper _bootstrapper;

        [Header("--- Parent Objects---")]
        [SerializeField] private Transform _levelParent;
        [SerializeField] private Transform _weaponParent;
        
        [Header("--- Views ---")]
        [SerializeField] private WeaponSystemView _weaponSystemView;
        [SerializeField] private CastleView _castleView;
        
        [Header("--- TEMP ---")]
        [SerializeField] private Weapon _creationPrefab;


        protected override void Configure(IContainerBuilder builder)
        {
            new WeaponSystemInstaller(_creationPrefab, _weaponParent, _weaponSystemView)
                .Install(builder);

            new CastleSystemInstaller(_castleView)
                .Install(builder);

            new EnemySystemInstaller()
                .Install(builder);

            new LevelSystemInstaller(_bootstrapper, _levelParent)
                .Install(builder);
        }
    }
}