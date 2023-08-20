using Game.Level.Common.Triggers;
using System;


namespace Game.Level.Castles.Params
{
    [Serializable]
    public record CastleParams
    {
        public float Health;
        public CollisionObserver CastleCollision;
    }
}