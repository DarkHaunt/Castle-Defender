using Game.Level.StateMachine.States;
using VContainer;
using System;


namespace Game.Level.StateMachine.StatesFactory
{
    public class StateFactory : IStateFactory
    {
        private readonly IObjectResolver _resolver;
        
        
        public StateFactory(IObjectResolver resolver)
        {
            _resolver = resolver;
        }


        public IState CreateState(State state)
        {
            return state switch
            {
                State.LevelStart => _resolver.Resolve<LevelStart>(),
                State.LevelEnd => _resolver.Resolve<LevelEnd>(),
                
                _ => throw new ArgumentOutOfRangeException($"State of type {state} does not exist with script")
            };
        }
    }
}