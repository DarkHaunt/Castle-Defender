using Project.Scripts.Common.StateMachine;
using Project.Scripts.Level.Castles;
using Project.Scripts.Level.Common.Physics;
using Project.Scripts.Level.Enemies.Creation;
using Project.Scripts.Level.Enemies.Handling;
using Project.Scripts.Level.Weapons.Handling;


namespace Project.Scripts.Level.StateMachine.States.StartLevel
{
    public class StartLevelStateFactory
    {
        private readonly WeaponHandleService _weaponHandleService;
        private readonly LevelCollisionsService _collisionsService;
        private readonly EnemyHandleService _enemyHandleService;
        private readonly EnemySpawnService _enemySpawnService;
        private readonly CastleModel _castleModel;


        public StartLevelStateFactory(CastleModel castleModel, WeaponHandleService weaponHandleService, 
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