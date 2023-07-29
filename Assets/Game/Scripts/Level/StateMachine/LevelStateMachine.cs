using Game.Level.StateMachine.StatesFactory;
using Game.Level.StateMachine.States;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;


namespace Game.Level.StateMachine
{
    public class LevelStateMachine : IStateSwitcher, IStartable
    {
        private readonly Dictionary<State, IState> _states;
        private IState _currentState;


        public LevelStateMachine(IStateFactory stateFactory)
        {
            _states = new Dictionary<State, IState>
            {
                [State.LevelStart] = stateFactory.CreateState(State.LevelStart),
                [State.LevelEnd] = stateFactory.CreateState(State.LevelEnd),
            };
        }
        

        public void SwitchToState(State state)
        {
            _currentState?.Exit();

            _currentState = _states[state];

            _currentState!.Enter();
        }
        
        void IStartable.Start()
        {
            Debug.Log($"<color=white>STart System</color>");
            
            SwitchToState(State.LevelStart);
        }
    }
}