using Game.Level.Common;
using Game.Level.Enemies;
using Game.Level.Weapons;


namespace Game.Level.Services.Level
{
    public record LevelInitializeData
    {
        public LevelComponentsContainer Level;
        public Weapon[] AvailableWeapons;
        public Enemy[] Enemies;

        public float EnemiesWaveSpawnTime;
        public float CastleHealth;
    }
}