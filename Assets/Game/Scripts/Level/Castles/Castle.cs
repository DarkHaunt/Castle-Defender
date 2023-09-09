using Game.Level.Common.Damage;
using UnityEngine;


namespace Game.Level.Castles
{
    public class Castle : MonoBehaviour
    {
        [field: SerializeField] public CollideAttackTarget PhysicBody { get; private set; }
    }
}