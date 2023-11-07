using Game.Level.StateMachine.States;
using Game.Level.Services.Castles;
using Game.Level.Services.Enemies;
using Game.Level.Services.Weapons;
using Game.Level.Common.Physics;
using Game.Level.StateMachine;


namespace Game.Level.Factories.States
{
    public class StartLevelStateFactory
    {
        private readonly IWeaponHandleService _weaponHandleService;
        private readonly LevelCollisionsService _collisionsService;
        private readonly EnemyHandleService _enemyHandleService;
        private readonly EnemySpawnService _enemySpawnService;
        private readonly CastleModel _castleModel;


        public StartLevelStateFactory(CastleModel castleModel, IWeaponHandleService weaponHandleService, 
            LevelCollisionsService collisionsService, EnemySpawnService enemySpawnService, EnemyHandleService enemyHandleService)
        {
            _weaponHandleService = weaponHandleService;
            _enemyHandleService = enemyHandleService;
            _enemySpawnService = enemySpawnService;
            _collisionsService = collisionsService;
            _castleModel = castleModel;
        }
        
        
        public StartLevelState CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher, _castleModel, _collisionsService, _weaponHandleService, _enemyHandleService, _enemySpawnService);
    }
}