using Project.Scripts.Level.Enemies;
using UnityEngine;


namespace Project.Scripts.Level.Debugging
{
    public class DebugParamsProvider : MonoBehaviour
    {
        [field: SerializeField] public Enemy DebugEnemyPrefab { get; private set; }
    }
}