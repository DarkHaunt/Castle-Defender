using Game.Level.Weapons;
using Game.Level.Enemies;
using Game.Level.Common;


namespace Game.Level.Configs
{
    public record LevelInitializeData
    {
        public LevelComponentsContainer Level;
        public Weapon[] AvailableWeapons;
        public Enemy[] Enemies;
        public float CastleHealth;
    }
}