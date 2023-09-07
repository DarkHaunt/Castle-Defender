using UnityEngine;

 
namespace Game.Level.Configs
{
    [CreateAssetMenu(fileName = "Level_Config", menuName = "Scriptables/LevelConfig", order = 52)]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField] public string LevelPrefab { get; private set; }
        [field: SerializeField] public string[] EnemiesPrefabsPath { get; private set; }

        [field: Header("--- TEST ---")]
        [field: SerializeField] public float CastleHealth { get; private set; }
    }
}