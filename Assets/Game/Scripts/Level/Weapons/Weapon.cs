using Game.Level.Weapons.StateMachine;
using UnityEngine;


namespace Game.Level.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Collider2D _attackRange;

        private WeaponStateMachine _weaponStateMachine;
        
                
    }
}