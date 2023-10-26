using System;


namespace Game.Configs.Game
{
    [Serializable]
    public class SerializedPlayerProgressData : IPlayerProgressData
    {
        public float CastleHealthSerialized;
        public string[] AvailableWeaponSerialized;

        public float CastleHealth => CastleHealthSerialized;
        public string[] AvailableWeapons => AvailableWeaponSerialized;


        public SerializedPlayerProgressData(IPlayerProgressData gameData)
        {
            CastleHealthSerialized = gameData.CastleHealth;
            AvailableWeaponSerialized = gameData.AvailableWeapons;
        }

        private SerializedPlayerProgressData(float castleHealthSerialized, string[] availableWeaponsSerialized)
        {
            CastleHealthSerialized = castleHealthSerialized;
            AvailableWeaponSerialized = availableWeaponsSerialized;
        }

        public SerializedPlayerProgressData() : this(float.NaN, Array.Empty<string>()) {}
    }
}