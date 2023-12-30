using Project.Scripts.Level.Weapons;
using Project.Scripts.Global;
using UnityEngine;

namespace Project.Scripts.Configs.Game.Weapons
{
    [CreateAssetMenu(fileName = "Weapon_Create_Config", menuName = "Scriptables/WeaponCreateConfig", order = 52)]
    public class WeaponCreateConfig : ScriptableObject
    {
        [field: SerializeField] public WeaponType WeaponType { get; private set; }
        
        [field: Space]
        [field: SerializeField] public Weapon Prefab { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public int Price { get; private set; }
    }
}