using Game.Level.StateMachine.States;


namespace Game.Level.Weapons.StateMachine.States
{
    public interface IWeaponState : IState
    {
        void Tick();
    }
}