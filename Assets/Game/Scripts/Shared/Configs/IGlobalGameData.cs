using System.Collections.Generic;


namespace Game.Level.Configs
{
    public interface IGlobalGameData
    {
        float CastleHealth { get; }
        string[] AvailableWeapons { get; }
    }
}