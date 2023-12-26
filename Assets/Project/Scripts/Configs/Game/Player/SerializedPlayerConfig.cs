using Project.Scripts.Global;
using System;


namespace Project.Scripts.Configs.Game
{
    [Serializable]
    public class SerializedPlayerConfig : IPlayerConfig
    {
        public int coinsSerialized;
        public float castleHealthSerialized;
        public WeaponType[] availableWeaponSerialized;

        public int Coins => coinsSerialized;
        public float CastleHealth => castleHealthSerialized;
        public WeaponType[] AvailableWeapons => availableWeaponSerialized;


        public SerializedPlayerConfig(IPlayerConfig gameData)
        {
            coinsSerialized = gameData.Coins;
            castleHealthSerialized = gameData.CastleHealth;
            availableWeaponSerialized = gameData.AvailableWeapons;
        }

        public SerializedPlayerConfig()
        {
            coinsSerialized = int.MinValue;
            castleHealthSerialized = float.NaN;
            availableWeaponSerialized = InfrastructureKeys.DefaultAvaliableWeapons;
        }
    }
}