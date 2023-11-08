using Game.Configs.Game;
using Game.Configs.Level;
using Game.Shared;
using Project.Scripts.Level.Common;
using Project.Scripts.Level.Creation;
using Project.Scripts.Level.Enemies;
using Project.Scripts.Level.Weapons;
using System;
using UnityEngine;


namespace Project.Scripts.Level.Handling
{
    public class InitializeDataProvider
    {
        public event Action OnInitializeDataReady;
        
        private readonly IPlayerProgressDataProvider _playerProgressDataProvider;
        private readonly LevelConfigProvider _levelConfigProvider;
        private readonly LevelFactory _levelFactory;

        private LevelInitializeData _levelInitializeData;


        public InitializeDataProvider(LevelFactory levelFactory, LevelConfigProvider levelConfigProvider, IPlayerProgressDataProvider playerProgressDataProvider)
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