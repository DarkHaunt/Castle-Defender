using Game.Level.Common.Triggers;
using UnityEngine;


namespace Game.Level.Params.Castles
{
    public class DebugCastleParamsProvider : MonoBehaviour, ICastleParamsProvider
    {
        [Header("--- Debug Params ---")]
        [SerializeField] private float _health;
        [SerializeField] private CollisionObserver _castleCollision;
        
        
        public CastleParams GetCastleParams()
        {
            var castleParams = new CastleParams
            {
                Health = _health,
                CastleCollision = _castleCollision,
            };

            return castleParams;
        }
    }
}