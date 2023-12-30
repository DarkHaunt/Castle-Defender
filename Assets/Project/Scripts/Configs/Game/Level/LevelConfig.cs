using UnityEngine;


namespace Project.Scripts.Configs.Level
{
    [CreateAssetMenu(fileName = "Level_Config", menuName = "Scriptables/LevelConfig", order = 52)]
    public class LevelConfig : ScriptableObject, ILevelConfig
    {
        [field: SerializeField] public int Number { get; private set; }
 
        
        [field: Header("--- Prefabs ---")]
        [field: SerializeField] public string LevelPrefabPath { get; private set; }
        [field: SerializeField] public string[] EnemiesPrefabsPatches { get; private set; }


        [field: Header("--- Settings  ---")]
        [field: SerializeField] public int CountToKillEnemies { get; private set; }
        [field: SerializeField] public int StartCountOfCrystals { get; private set; }
        [field: SerializeField] public float EnemiesSpawnWaveTime { get; private set; }
    }
}