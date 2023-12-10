using Project.Scripts.Global;
using UnityEngine;


namespace Project.Scripts.Configs.Game
{
    [CreateAssetMenu(fileName = "Global_Game_Data", menuName = "Scriptables/GlobalGameData", order = 52)]
    public class PlayerConfig : ScriptableObject, IPlayerConfig
    {
        [field: SerializeField] public int Crystals { get; private set; }
        [field: SerializeField] public float CastleHealth { get; private set; }
        [field: SerializeField] public WeaponType[] AvailableWeapons { get; private set; }
    }
}