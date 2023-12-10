using Project.Scripts.Global;
using System;


namespace Project.Scripts.Configs.Game
{
    [Serializable]
    public class SerializedPlayerConfig : IPlayerConfig
    {
        public int CrystalsSerialized;
        public float CastleHealthSerialized;
        public WeaponType[] AvailableWeaponSerialized;

        public int Crystals => CrystalsSerialized;
        public float CastleHealth => CastleHealthSerialized;
        public WeaponType[] AvailableWeapons => AvailableWeaponSerialized;


        public SerializedPlayerConfig(IPlayerConfig gameData)
        {
            CrystalsSerialized = gameData.Crystals;
            CastleHealthSerialized = gameData.CastleHealth;
            AvailableWeaponSerialized = gameData.AvailableWeapons;
        }

        private SerializedPlayerConfig()
        {
            CrystalsSerialized = int.MinValue;
            CastleHealthSerialized = float.NaN;
            AvailableWeaponSerialized = Array.Empty<WeaponType>();
        }
    }
}