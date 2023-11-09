using Project.Scripts.Common.StateMachine;
using Project.Scripts.Level.StateMachine.States.LoadingLevelData;
using Project.Scripts.Level.StateMachine.States.StartLevel;
using Project.Scripts.Level.StateMachine.States.InitLevel;
using Project.Scripts.Level.StateMachine.States.EndLevel;
using System.Collections.Generic;
using System;
using VContainer.Unity;


namespace Project.Scripts.Level.StateMachine
{
    public class LevelStateMachine : IStateSwitcher, IStartable
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _currentState;


        public LevelStateMachine(LoadingLevelDataStateFactory loadingLevelDataStateFactory, InitLevelStateFactory initLevelStateFactory,
            StartLevelStateFactory startLevelSateFactory, EndLevelStateFactory endLevelStateFactory)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(LoadingLevelDataState)] = loadingLevelDataStateFactory.CreateState(this),
                [typeof(InitLevelState)] = initLevelStateFactory.CreateState(this),
                [typeof(StartLevelState)] = startLevelSateFactory.CreateState(this),
                [typeof(EndLevelState)] = endLevelStateFactory.CreateState(),
            };
        }

        public void SwitchToState<TState>() where TState : IState
        {
            _currentState?.Exit();

            _currentState = _states[typeof(TState)];
            
            _currentState!.Enter();
        }

        void IStartable.Start()
            => SwitchToState<LoadingLevelDataState>();
    }
}