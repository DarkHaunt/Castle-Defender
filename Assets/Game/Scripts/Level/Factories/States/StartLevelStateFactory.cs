using Game.Level.Common.Physics;
using Game.Level.Services.Castles;
using Game.Level.Services.Enemies;
using Game.Level.Services.Weapons;
using Game.Level.StateMachine;
using Game.Level.StateMachine.States;


namespace Game.Level.Factories.States
{
    public class StartLevelStateFactory
    {
        private readonly IWeaponHandleService _weaponHandleService;
        private readonly LevelCollisionsService _collisionsService;
        private readonly CastleModel _castleModel;
        private readonly EnemyHandleService _enemyHandleService;
        private readonly EnemySpawnService _enemySpawnService;


        public StartLevelStateFactory(CastleModel castleModel, IWeaponHandleService weaponHandleService, 
            LevelCollisionsService collisionsService, EnemySpawnService enemySpawnService, EnemyHandleService enemyHandleService)
        {
            _weaponHandleService = weaponHandleService;
            _castleModel = castleModel;
            _enemyHandleService = enemyHandleService;
            _enemySpawnService = enemySpawnService;
            _collisionsService = collisionsService;
        }
        
        
        public StartLevelState CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher, _castleModel, _collisionsService, _weaponHandleService, _enemyHandleService, _enemySpawnService);
    }
}