using Game.Level.Services.Castles;
using Game.Level.Services.Enemies;
using Game.Level.Services.Weapons;


namespace Game.Level.StateMachine.States.Factories
{
    public class StartLevelStateFactory
    {
        private readonly IWeaponHandleService _weaponHandleService;
        private readonly ICastleHandleService _castleHandleService;
        private readonly EnemySpawnService _enemySpawnService;

        
        public StartLevelStateFactory(ICastleHandleService castleHandleService, IWeaponHandleService weaponHandleService, 
            EnemySpawnService enemySpawnService)
        {
            _weaponHandleService = weaponHandleService;
            _castleHandleService = castleHandleService;
            _enemySpawnService = enemySpawnService;
        }
        
        
        public StartLevelState CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher, _castleHandleService, _weaponHandleService, _enemySpawnService);
    }
}