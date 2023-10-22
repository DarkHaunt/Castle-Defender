using Game.Configs.Game;
using Game.Configs.Level;
using Game.Level.Common;
using Game.Level.Enemies;
using Game.Level.Factories.Level;
using Game.Level.Weapons;
using Game.Shared;
using System;
using UnityEngine;


namespace Game.Level.Services.Level
{
    public class InitializeDataProvider : IInitializeDataProvider
    {
        public event Action OnInitializeDataReady;
        
        private readonly IPlayerProgressDataProvider _playerProgressDataProvider;
        private readonly ILevelConfigProvider _levelConfigProvider;
        private readonly ILevelFactory _levelFactory;

        private LevelInitializeData _levelInitializeData;


        public InitializeDataProvider(ILevelFactory levelFactory, ILevelConfigProvider levelConfigProvider, IPlayerProgressDataProvider playerProgressDataProvider)
        {
            _playerProgressDataProvider = playerProgressDataProvider;
            _levelConfigProvider = levelConfigProvider;
            _levelFactory = levelFactory;
        }


        public void LoadInitializeData()
        {
            var playerProgressData = _playerProgressDataProvider.GetPlayerProgressData();
            var levelConfig = _levelConfigProvider.GetLevelConfig();
            
            _levelInitializeData = new LevelInitializeData
            {
                Level = LoadLevel(levelConfig),
                Enemies = LoadEnemies(levelConfig),
                AvailableWeapons = LoadAvailableWeapons(playerProgressData),
                
                CastleHealth = playerProgressData.CastleHealth,
                EnemiesWaveSpawnTime = levelConfig.EnemiesSpawnWaveTime,
            };
            
            OnInitializeDataReady?.Invoke();
        }

        public LevelInitializeData GetInitializeData()
            => _levelInitializeData;

        private Weapon[] LoadAvailableWeapons(IPlayerProgressData playerProgressData)
        {
            var weapons = new Weapon[playerProgressData.AvailableWeapons.Length];

            for (int i = 0; i < weapons.Length; i++)
            {
                var path = playerProgressData.AvailableWeapons[i];
                weapons[i] = Resources.Load<Weapon>(path);
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