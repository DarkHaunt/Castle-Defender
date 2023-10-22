﻿using Game.Level.Health;
using Game.Level.Weapons.HandlePoints;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Level.Castles
{
    public class Castle : MonoBehaviour
    {
        [field: SerializeField] public CollideAttackTarget PhysicBody { get; private set; }
        [field: SerializeField] public List<WeaponPointView> WeaponHandlePoints { get; private set; }
    }
}