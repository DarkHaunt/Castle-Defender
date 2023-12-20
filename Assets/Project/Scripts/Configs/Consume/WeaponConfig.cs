using Project.Scripts.Global;
using UnityEngine;

namespace Project.Scripts.Configs.Consume
{
    [CreateAssetMenu(fileName = "Weapon_Config", menuName = "Scriptables/WeaponConfig", order = 52)]
    public class WeaponConfig : ScriptableObject
    {
        [field: SerializeField] public WeaponType Type { get; private set; }
        
        [field: Space]
        [field: SerializeField] public bool IsFree { get; private set; }
        [field: SerializeField] public int Price { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}