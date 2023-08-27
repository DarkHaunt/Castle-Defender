using Game.Level.Enemies;
using System;


namespace Game.Level.Params.Castles
{
    [Serializable]
    public record CastleParams
    {
        public float Health;
        public IAttackTarget PhysicBody;
    }
}