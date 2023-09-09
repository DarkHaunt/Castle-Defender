using System;


namespace Game.Level.Configs
{
    [Serializable]
    public class SerializedGlobalGameData : IGlobalGameData
    {
        public float CastleHealthSerialized;
        public string[] AvailableWeaponSerialized;

        public float CastleHealth => CastleHealthSerialized;
        public string[] AvailableWeapons => AvailableWeaponSerialized;


        public SerializedGlobalGameData(float castleHealthSerialized, string[] availableWeaponsSerialized)
        {
            CastleHealthSerialized = castleHealthSerialized;
            AvailableWeaponSerialized = availableWeaponsSerialized;
        }

        public SerializedGlobalGameData() : this(float.NaN, Array.Empty<string>()) {}
    }
}