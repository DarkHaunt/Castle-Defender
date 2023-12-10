using Project.Scripts.Level.Common.Damage;
using Project.Scripts.Level.Weapons.Handling.WeaponPoints.MVP;
using System.Collections.Generic;
using UnityEngine;


namespace Project.Scripts.Level.Castles
{
    public class Castle : MonoBehaviour
    {
        [field: SerializeField] public CollideAttackTarget PhysicBody { get; private set; }
        [field: SerializeField] public List<WeaponPointView> WeaponHandlePoints { get; private set; }
    }
}