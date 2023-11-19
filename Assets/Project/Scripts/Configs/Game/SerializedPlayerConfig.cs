using Project.Scripts.Global;
using System;


namespace Project.Scripts.Configs.Game
{
    [Serializable]
    public class SerializedPlayerConfig : IPlayerConfig
    {
        public float CastleHealthSerialized;
        public WeaponType[] AvailableWeaponSerialized;

        public float CastleHealth => CastleHealthSerialized;
        public WeaponType[] AvailableWeapons => AvailableWeaponSerialized;


        public SerializedPlayerConfig(IPlayerConfig gameData)
        {
            CastleHealthSerialized = gameData.CastleHealth;
            AvailableWeaponSerialized = gameData.AvailableWeapons;
        }

        private SerializedPlayerConfig(float castleHealthSerialized, WeaponType[] availableWeaponsSerialized)
        {
            CastleHealthSerialized = castleHealthSerialized;
            AvailableWeaponSerialized = availableWeaponsSerialized;
        }

        public SerializedPlayerConfig() : this(float.NaN, Array.Empty<WeaponType>()) {}
    }
}