using Game.Level.Common.Triggers;
using System;


namespace Game.Level.Params.Castles
{
    [Serializable]
    public record CastleParams
    {
        public float Health;
        public CollisionObserver CastleCollision;
    }
}