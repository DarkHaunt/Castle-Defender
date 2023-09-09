using UnityEngine;


namespace Game.Level.Configs
{
    [CreateAssetMenu(fileName = "Global_Game_Data", menuName = "Scriptables/GlobalGameData", order = 52)]
    public class PlayerProgressData : ScriptableObject, IPlayerProgressData
    {
        [field: SerializeField] public float CastleHealth { get; private set; }
        [field: SerializeField] public string[] AvailableWeapons { get; private set; }
    }
}