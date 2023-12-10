

using Project.Scripts.Global;


namespace Project.Scripts.Configs.Game
{
    public interface IPlayerConfig
    {
        int Crystals { get; }
        float CastleHealth { get; }
        WeaponType[] AvailableWeapons { get; }
    }
}