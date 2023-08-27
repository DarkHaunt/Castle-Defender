using Game.Level.Common.Damage;
using UnityEngine;


namespace Game.Level.Params.Castles
{
    public class DebugCastleParamsProvider : MonoBehaviour, ICastleParamsProvider
    {
        [Header("--- Debug Params ---")]
        [SerializeField] private float _health;
        [SerializeField] private CollideAttackTarget _castleCollision;
        
        
        public CastleParams GetCastleParams()
        {
            var castleParams = new CastleParams
            {
                Health = _health,
                PhysicBody = _castleCollision,
            };

            return castleParams;
        }
    }
}