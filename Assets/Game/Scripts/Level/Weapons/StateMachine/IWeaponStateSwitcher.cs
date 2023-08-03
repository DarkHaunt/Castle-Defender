using Game.Level.Weapons.StateMachine.States;


namespace Game.Level.Weapons.StateMachine
{
    public interface IWeaponStateSwitcher
    {
        void SwitchToState<TState>() where TState : IWeaponState;
    }
}