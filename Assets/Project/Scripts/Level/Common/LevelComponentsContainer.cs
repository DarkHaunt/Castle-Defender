using Project.Scripts.Level.Castles;
using System.Collections.Generic;
using UnityEngine;


namespace Project.Scripts.Level.Common
{
    public class LevelComponentsContainer : MonoBehaviour
    {
        [field: SerializeField] public Castle Castle { get; private set; }
        [field: SerializeField] public List<Transform> EnemiesSpawnPoints { get; private set; }
    }
}