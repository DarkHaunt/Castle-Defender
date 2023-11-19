using Project.Scripts.Level.Weapons;
using Project.Scripts.Level.Enemies;
using Project.Scripts.Level.Common.Prefab;


namespace Project.Scripts.Level.Handling
{
    public record LevelInitializeData
    {
        public LevelComponentsContainer Level;
        public Weapon[] AvailableWeapons;
        public Enemy[] Enemies;

        public float EnemiesWaveSpawnTime;
        public int CountEnemiesToKill;
        public float CastleHealth;
    }
}