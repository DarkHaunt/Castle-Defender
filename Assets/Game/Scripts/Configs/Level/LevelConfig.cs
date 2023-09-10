using UnityEngine;

 
namespace Game.Level.Configs
{
    [CreateAssetMenu(fileName = "Level_Config", menuName = "Scriptables/LevelConfig", order = 52)]
    public class LevelConfig : ScriptableObject, ILevelConfig
    {
        [field: Header("--- Prefabs ---")]
        [field: SerializeField] public string LevelPrefabPath { get; private set; }
        [field: SerializeField] public string[] EnemiesPrefabsPatches { get; private set; }
        
        
        [field: Header("--- Time Params ---")]
        [field: SerializeField] public float EnemiesSpawnWaveTime { get; private set; }
    }
}