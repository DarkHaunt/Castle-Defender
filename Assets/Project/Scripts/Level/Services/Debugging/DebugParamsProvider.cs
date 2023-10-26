using Game.Level.Enemies;
using UnityEngine;


namespace Game.Level.Services.Debugging
{
    public class DebugParamsProvider : MonoBehaviour
    {
        [field: SerializeField] public Enemy DebugEnemyPrefab { get; private set; }
    }
}