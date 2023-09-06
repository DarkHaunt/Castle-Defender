namespace Game.Level.Common.Damage
{
    public interface IHealthParamsProvider
    {
        float MaxHealth { get; }
        float CurrentHealth { get; }
    }
}