using Project.Scripts.Level.Boot.Installers;
using Project.Scripts.Level.Castles;
using Project.Scripts.Level.Debugging;
using Project.Scripts.Level.Weapons;
using Project.Scripts.Level.Weapons.View;
using Project.Scripts.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace Project.Scripts.Level.Boot
{
    public class LevelLifeScope : LifetimeScope
    {
        [Header("--- Debug ---")]
        [SerializeField] private DebugService _debugService;

        [Header("--- Parent Objects---")]
        [SerializeField] private Transform _weaponParent;
        [SerializeField] private Transform _levelParent;
        [SerializeField] private Transform _enemyParent;

        [Header("--- Views ---")]
        [SerializeField] private GameOverUIService _gameOverUIService;
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

            new EnemySystemInstaller(_enemyParent)
                .Install(builder);

            new LevelSystemInstaller(_debugService, _levelParent)
                .Install(builder);
            
            new UIInstaller(_gameOverUIService)
                .Install(builder);
        }
    }
}