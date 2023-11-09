using System;


namespace Project.Scripts.Configs.Game
{
    [Serializable]
    public class SerializedPlayerConfig : IPlayerConfig
    {
        public float CastleHealthSerialized;
        public string[] AvailableWeaponSerialized;

        public float CastleHealth => CastleHealthSerialized;
        public string[] AvailableWeapons => AvailableWeaponSerialized;


        public SerializedPlayerConfig(IPlayerConfig gameData)
        {
            CastleHealthSerialized = gameData.CastleHealth;
            AvailableWeaponSerialized = gameData.AvailableWeapons;
        }

        private SerializedPlayerConfig(float castleHealthSerialized, string[] availableWeaponsSerialized)
        {
            CastleHealthSerialized = castleHealthSerialized;
            AvailableWeaponSerialized = availableWeaponsSerialized;
        }

        public SerializedPlayerConfig() : this(float.NaN, Array.Empty<string>()) {}
    }
}