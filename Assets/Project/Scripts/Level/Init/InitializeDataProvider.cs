using Project.Scripts.Common.Infrastructure;
using Project.Scripts.Configs.Game;
using Project.Scripts.Configs.Level;
using Project.Scripts.Global;
using Project.Scripts.Level.Common.Prefab;
using Project.Scripts.Level.Enemies;
using Project.Scripts.Level.Weapons;
using System;
using UnityEngine;


namespace Project.Scripts.Level.Init
{
    public class InitializeDataProvider
    {
        public event Action OnInitializeDataReady;
        
        private readonly WeaponProvider _weaponProvider;
        private readonly LevelFactory _levelFactory;

        private LevelInitializeData _levelInitializeData;


        public InitializeDataProvider(LevelFactory levelFactory, WeaponProvider weaponProvider)
        {
            _weaponProvider = weaponProvider;
            _levelFactory = levelFactory;
        }


        public LevelInitializeData GetInitializeData()
            => _levelInitializeData;

        public void LoadInitializeData()
        {
            var playerProgressData = LoadPlayerConfig();
            var levelConfig = LoadLevelConfig();
            
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
        
        private ILevelConfig LoadLevelConfig()
            => JsonSerializer.LoadFile<SerializedLevelConfig>(InfrastructureKeys.LevelConfigsPath);   
        
        private IPlayerConfig LoadPlayerConfig()
            => JsonSerializer.LoadFile<SerializedPlayerConfig>(InfrastructureKeys.PlayerConfigPath);

        private LevelComponentsContainer LoadLevel(ILevelConfig levelConfig)
            => _levelFactory.CreateLevel(levelConfig.LevelPrefabPath);
    }
}