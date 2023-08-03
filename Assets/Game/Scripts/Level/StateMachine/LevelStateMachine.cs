using Game.Level.StateMachine.StatesFactory;
using Game.Level.StateMachine.States;
using System.Collections.Generic;
using VContainer.Unity;
using System;


namespace Game.Level.StateMachine
{
    public class LevelStateMachine : IStateSwitcher, IStartable, ITickable
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _currentState;


        public LevelStateMachine(LevelStartStateFactory levelStartSateFactory, LevelEndStateFactory levelEndStateFactory)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(LevelStart)] = levelStartSateFactory.CreateState(this),
                [typeof(LevelEnd)] = levelEndStateFactory.CreateState(),
            };
        }


        void IStartable.Start()
            => SwitchToState<LevelStart>();

        void ITickable.Tick()
            => _currentState?.Tick();

        public void SwitchToState<TState>() where TState : IState
        {
            _currentState?.Exit();

            _currentState = _states[typeof(TState)];
            
            _currentState!.Enter();
        }
    }
}