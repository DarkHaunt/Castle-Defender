using Game.Level.StateMachine.States;
using System.Collections.Generic;
using VContainer.Unity;
using System;
using Game.Level.StateMachine.States.Factories;


namespace Game.Level.StateMachine
{
    public class LevelStateMachine : IStateSwitcher, IStartable
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _currentState;


        public LevelStateMachine(LevelStartStateFactory levelStartSateFactory, LevelEndStateFactory levelEndStateFactory)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(LevelStartState)] = levelStartSateFactory.CreateState(this),
                [typeof(LevelEndState)] = levelEndStateFactory.CreateState(),
            };
        }


        void IStartable.Start()
            => SwitchToState<LevelStartState>();

        public void SwitchToState<TState>() where TState : IState
        {
            _currentState?.Exit();

            _currentState = _states[typeof(TState)];
            
            _currentState!.Enter();
        }
    }
}