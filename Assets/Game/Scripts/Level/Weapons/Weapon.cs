using Game.Level.Weapons.StateMachine;
using UnityEngine.UI;
using UnityEngine;
using System;


namespace Game.Level.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Collider2D _attackRange;

        private WeaponStateMachine _weaponStateMachine;
    }
}