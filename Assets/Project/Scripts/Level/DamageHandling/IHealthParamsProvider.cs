namespace Game.Level.Health
{
    public interface IHealthParamsProvider
    {
        float MaxHealth { get; }
        float CurrentHealth { get; }
    }
}