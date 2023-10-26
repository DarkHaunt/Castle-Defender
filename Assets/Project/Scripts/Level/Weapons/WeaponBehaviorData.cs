using UnityEngine;
using System;


namespace Game.Level.Weapons
{
    [Serializable]
    public class WeaponBehaviorData
    {
        [field: SerializeField] public float ReloadTime { get; private set; }
        [field: SerializeField] public float AttackRadius { get; private set; }
    }
}