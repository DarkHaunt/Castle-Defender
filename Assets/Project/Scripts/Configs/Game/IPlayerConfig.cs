

using Project.Scripts.Global;


namespace Project.Scripts.Configs.Game
{
    public interface IPlayerConfig
    {
        float CastleHealth { get; }
        WeaponType[] AvailableWeapons { get; }
    }
}