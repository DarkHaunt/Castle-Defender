﻿using Game.Level.StateMachine.States;
using Game.Level.Services.Debugging;
using Game.Level.StateMachine;
using Game.Common.Interfaces;
using Game.Common.Scene;
using UnityEngine;
using VContainer;


namespace Game.Level.Bootstrapping
{
    public class LevelBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private ForcibleLevelConfigSetter _configSetter;
        [SerializeField] private ForcibleGameDataSetter _gameDataSetter;
        
        private IStateSwitcher _stateSwitcher;

        
        [Inject]
        private void Construct(IStateSwitcher stateSwitcher, SceneLoader sceneLoader)
        {
            _stateSwitcher = stateSwitcher;
            
            sceneLoader.LoadSceneWithTransition(Scenes.MainMenu);
        }

        private void Awake()
        {
            _configSetter.ForceSetCachedConfig();
            _gameDataSetter.ForceSetCachedPlayerProgressData();
            
            _stateSwitcher.SwitchToState<LoadingLevelDataState>();
        }
    }
}