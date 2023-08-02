using Game.Level.StateMachine.StatesFactory;
using Game.Level.StateMachine.States;
using System.Collections.Generic;
using VContainer.Unity;


namespace Game.Level.StateMachine
{
    public class LevelStateMachine : IStateSwitcher, IStartable, ITickable
    {
        private readonly Dictionary<State, IState> _states;
        private IState _currentState;


        public LevelStateMachine(LevelStartStateFactory levelStartSateFactory, LevelEndStateFactory levelEndState)
        {
            _states = new Dictionary<State, IState>
            {
                [State.LevelStart] = levelStartSateFactory.CreateState(this),
                [State.LevelEnd] = levelEndState.CreateState(),
            };
        }


        public void SwitchToState(State state)
        {
            _currentState?.Exit();

            _currentState = _states[state];

            _currentState!.Enter();
        }

        void IStartable.Start()
            => SwitchToState(State.LevelStart);

        void ITickable.Tick()
            => _currentState?.Tick();
    }
}