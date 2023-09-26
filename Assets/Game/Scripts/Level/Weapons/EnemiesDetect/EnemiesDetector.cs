using System.Collections.Generic;
using Game.Level.Enemies;
using UnityEngine;


namespace Game.Level.Weapons.EnemiesDetect
{
    [RequireComponent(typeof(Collider2D))]
    public class EnemiesDetector : MonoBehaviour
    {
        private readonly ISet<IEnemy> _detectedEnemies = new HashSet<IEnemy>();

        public IEnumerable<IEnemy> DetectedEnemies => _detectedEnemies;


        private void OnValidate()
        {
            var col = GetComponent<Collider2D>();
            col.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IEnemy enemy))
                RegisterDetectedEnemy(enemy);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IEnemy enemy))
                UnregisterDetectedEnemy(enemy);
        }
        
        private void RegisterDetectedEnemy(IEnemy enemy)
        {
            _detectedEnemies.Add(enemy);

            enemy.OnDeath += UnregisterDetectedEnemy;
        }  
        
        private void UnregisterDetectedEnemy(IEnemy enemy)
        {
            _detectedEnemies.Remove(enemy);

            enemy.OnDeath -= UnregisterDetectedEnemy; 
        }
    }
}