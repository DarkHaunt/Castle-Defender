using Project.Scripts.Level.Boot.Installers;
using Project.Scripts.Level.Weapons.View;
using Project.Scripts.Level.Debugging;
using Project.Scripts.Level.Castles;
using Project.Scripts.Consume;
using Project.Scripts.Level.Common.Crystals;
using Project.Scripts.UI;
using VContainer.Unity;
using UnityEngine;
using VContainer;


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
        [SerializeField] private GameOverView _gameOverView;
        [SerializeField] private WeaponSystemView _weaponSystemView;
        [SerializeField] private CrystalHandleView _crystalHandleView;
        [SerializeField] private CastleView _castleView;

       
        protected override void Configure(IContainerBuilder builder)
        {
            new WeaponSystemInstaller(_weaponSystemView, _weaponParent)
                .Install(builder);

            new CastleSystemInstaller(_castleView)
                .Install(builder);

            new EnemySystemInstaller(_enemyParent)
                .Install(builder);

            new LevelSystemInstaller(_debugService, _levelParent)
                .Install(builder);
            
            new UIInstaller(_gameOverView, _crystalHandleView)
                .Install(builder);
        }
    }
}