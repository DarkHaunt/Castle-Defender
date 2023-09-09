using Game.Level.Services.Castles;
using Game.Level.Factories.Level;
using Game.Level.Configs;
using UnityEngine;


namespace Game.Level.StateMachine.States
{
    public class DataLoadingState : IState
    {
        private readonly ILevelConfigProvider _levelConfigProvider;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly ICastleService _castleService;
        private readonly ILevelFactory _levelFactory;


        public DataLoadingState(IStateSwitcher stateSwitcher, ILevelFactory levelFactory, 
            ICastleService castleService, ILevelConfigProvider levelConfigProvider)
        {
            _levelConfigProvider = levelConfigProvider;
            _castleService = castleService;
            _stateSwitcher = stateSwitcher;
            _levelFactory = levelFactory;
        }


        public void Enter()
        {
            Debug.Log($"<color=yellow>Load Data</color>");

            var levelConfigs = _levelConfigProvider.GetLevelConfig();
            
            Debug.Log($"<color=yellow>Loaded configs {levelConfigs.LevelPrefabPath} " +
                      $"| {levelConfigs.EnemiesPrefabsPatches}</color>");
            
            var level = _levelFactory.CreateLevel(levelConfigs.LevelPrefabPath);

            Debug.Log($"<color=white>Created level = {level.name}</color>");
            
            _castleService.Init(level.Castle);
            
            SwitchToStartLevelState();
        }

        public void Exit() {}

        private void SwitchToStartLevelState()
            => _stateSwitcher.SwitchToState<StartLevelState>();
    }
}