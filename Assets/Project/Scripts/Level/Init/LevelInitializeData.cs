using Project.Scripts.Level.Common.Prefab;
using Project.Scripts.Level.Enemies;
using Project.Scripts.Level.Weapons;


namespace Project.Scripts.Level.Init
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