using Game.Level.Castles;
using UnityEngine;


namespace Game.Level.Common
{
    public class LevelComponentsContainer : MonoBehaviour
    {
        [field: SerializeField] public Castle Castle { get; private set; }
        
        
    }
}