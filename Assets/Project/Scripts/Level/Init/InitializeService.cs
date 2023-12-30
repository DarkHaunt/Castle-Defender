using Project.Scripts.Level.Weapons.Handling.Create;
using Project.Scripts.Level.Common.Prefab;
using Project.Scripts.Configs;
using System;


namespace Project.Scripts.Level.Init
{
    public class InitializeService
    {
        public event Action OnInitializeDataReady;

        private readonly WeaponChoseService _weaponChoseService;
        
        private readonly ConfigsProvider _configsProvider;
        private readonly WeaponProvider _weaponProvider;
        private readonly EnemyProvider _enemyProvider;
        private readonly LevelProvider _levelProvider;

        private LevelInitializeData _levelInitializeData;


        public InitializeService(WeaponChoseService weaponChoseService, ConfigsProvider configsProvider, 
            LevelProvider levelProvider, WeaponProvider weaponProvider, EnemyProvider enemyProvider)
        {
            _weaponChoseService = weaponChoseService;
            
            _configsProvider = configsProvider;
            _weaponProvider = weaponProvider;
            _enemyProvider = enemyProvider;
            _levelProvider = levelProvider;
        }


        public LevelInitializeData GetInitializeData()
            => _levelInitializeData;

        public void LoadInitializeData()
        {
            var playerConfig = _configsProvider.PlayerConfig;
            var levelConfig = _configsProvider.LevelConfig;
            
            _levelInitializeData = new LevelInitializeData
            {
                Level = _levelProvider.LoadLevel(levelConfig),
                Enemies = _enemyProvider.LoadEnemies(levelConfig),
                StartCountOfCrystals = levelConfig.StartCountOfCrystals,
                AvailableWeapons = _weaponProvider.LoadWeapons(playerConfig),
                
                CastleHealth = playerConfig.CastleHealth,
                CountEnemiesToKill = levelConfig.CountToKillEnemies,
                EnemiesWaveSpawnTime = levelConfig.EnemiesSpawnWaveTime,
            };
            
            _weaponChoseService.Init(playerConfig.AvailableWeapons);
            
            OnInitializeDataReady?.Invoke();
        }
    }
}