

using Project.Scripts.Global;


namespace Project.Scripts.Configs.Game
{
    public interface IPlayerConfig
    {
        int Coins { get; }
        float CastleHealth { get; }
        WeaponType[] AvailableWeapons { get; }
    }
}