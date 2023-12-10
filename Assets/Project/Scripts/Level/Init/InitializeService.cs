using Project.Scripts.Level.Common.Prefab;
using Project.Scripts.Configs.Level;
using Project.Scripts.Configs.Game;
using Project.Scripts.Level.Enemies;
using Project.Scripts.Level.Weapons;
using Project.Scripts.Configs;
using UnityEngine;
using System;


namespace Project.Scripts.Level.Init
{
    public class InitializeService
    {
        public event Action OnInitializeDataReady;

        private readonly ConfigsProvider _configsProvider;
        private readonly WeaponProvider _weaponProvider;
        private readonly LevelFactory _levelFactory;

        private LevelInitializeData _levelInitializeData;


        public InitializeService(ConfigsProvider configsProvider, LevelFactory levelFactory, WeaponProvider weaponProvider)
        {
            _configsProvider = configsProvider;
            _weaponProvider = weaponProvider;
            _levelFactory = levelFactory;
        }


        public LevelInitializeData GetInitializeData()
            => _levelInitializeData;

        public void LoadInitializeData()
        {
            var playerProgressData = _configsProvider.PlayerConfig;
            var levelConfig = _configsProvider.LevelConfig;
            
            _levelInitializeData = new LevelInitializeData
            {
                Level = LoadLevel(levelConfig),
                Enemies = LoadEnemies(levelConfig),
                CountEnemiesToKill = levelConfig.CountToKillEnemies,
                AvailableWeapons = LoadAvailableWeapons(playerProgressData),
                
                CastleHealth = playerProgressData.CastleHealth,
                EnemiesWaveSpawnTime = levelConfig.EnemiesSpawnWaveTime,
            };
            
            OnInitializeDataReady?.Invoke();
        }

        private Weapon[] LoadAvailableWeapons(IPlayerConfig playerConfig)
        {
            var weapons = new Weapon[playerConfig.AvailableWeapons.Length];

            for (int i = 0; i < weapons.Length; i++)
            {
                var type = playerConfig.AvailableWeapons[i];
                weapons[i] = _weaponProvider.GetWeaponPrefab(type);
            }

            return weapons;
        }

        private Enemy[] LoadEnemies(ILevelConfig levelConfig)
        {
            var enemies = new Enemy[levelConfig.EnemiesPrefabsPatches.Length];

            for (int i = 0; i < enemies.Length; i++)
            {
                var path = levelConfig.EnemiesPrefabsPatches[i];
                enemies[i] = Resources.Load<Enemy>(path);
            }

            return enemies;
        }

        private LevelComponentsContainer LoadLevel(ILevelConfig levelConfig)
            => _levelFactory.CreateLevel(levelConfig.LevelPrefabPath);
    }
}