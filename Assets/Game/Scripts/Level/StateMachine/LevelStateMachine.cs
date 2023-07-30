using Game.Level.StateMachine.StatesFactory;
using Game.Level.StateMachine.States;
using System.Collections.Generic;
using VContainer.Unity;


namespace Game.Level.StateMachine
{
    public class LevelStateMachine : IStateSwitcher, IStartable, IInitializable
    {
        private readonly IStateFactory _stateFactory;
        
        private Dictionary<State, IState> _states;
        private IState _currentState;


        public LevelStateMachine(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        
        public void SwitchToState(State state)
        {
            _currentState?.Exit();

            _currentState = _states[state];

            _currentState!.Enter();
        }
        
        void IInitializable.Initialize()
        {
            _states = new Dictionary<State, IState>
            {
                [State.LevelStart] = _stateFactory.CreateState(State.LevelStart),
                [State.LevelEnd] = _stateFactory.CreateState(State.LevelEnd),
            };
        }
        
        void IStartable.Start()
            => SwitchToState(State.LevelStart);
    }
}