using Game.Level.Weapons;
using Game.Level.Enemies;
using Game.Level.Common;


namespace Game.Level.Configs
{
    public record LevelInitializeData
    {
        public LevelComponentsContainer Level;
        public Weapon[] AvailableWeapons;
        public EnemyBehaviorHandler[] Enemies;

        public float EnemiesWaveSpawnTime;
        public float CastleHealth;
    }
}