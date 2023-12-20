using Project.Scripts.Global;
using UnityEngine;


namespace Project.Scripts.Configs.Game
{
    [CreateAssetMenu(fileName = "Player_Config", menuName = "Scriptables/PlayerConfig", order = 52)]
    public class PlayerConfig : ScriptableObject, IPlayerConfig
    {
        [field: SerializeField] public int Coins { get; private set; }
        [field: SerializeField] public float CastleHealth { get; private set; }
        [field: SerializeField] public WeaponType[] AvailableWeapons { get; private set; }
    }
}