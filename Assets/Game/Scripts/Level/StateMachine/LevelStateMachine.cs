using Game.Level.Factories.States;
using Game.Level.StateMachine.States;
using System.Collections.Generic;
using System;


namespace Game.Level.StateMachine
{
    public class LevelStateMachine : IStateSwitcher
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
    }
}