using Game.Level.Services.Castles;
using Game.Level.Services.Enemies;
using Game.Level.Services.Weapons;
using Game.Common.Physics;


namespace Game.Level.StateMachine.States.Factories
{
    public class StartLevelStateFactory
    {
        private readonly IWeaponHandleService _weaponHandleService;
        private readonly LevelCollisionsService _collisionsService;
        private readonly CastleHandleService _castleHandleService;
        private readonly EnemyHandleService _enemyHandleService;
        private readonly EnemySpawnService _enemySpawnService;


        public StartLevelStateFactory(CastleHandleService castleHandleService, IWeaponHandleService weaponHandleService, 
            LevelCollisionsService collisionsService, EnemySpawnService enemySpawnService, EnemyHandleService enemyHandleService)
        {
            _weaponHandleService = weaponHandleService;
            _castleHandleService = castleHandleService;
            _enemyHandleService = enemyHandleService;
            _enemySpawnService = enemySpawnService;
            _collisionsService = collisionsService;
        }
        
        
        public StartLevelState CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher, _castleHandleService, _collisionsService, _weaponHandleService, _enemyHandleService, _enemySpawnService);
    }
}