using Project.Scripts.Level.Common;
using Project.Scripts.Level.Enemies;
using Project.Scripts.Level.Weapons;


namespace Project.Scripts.Level.Handling
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