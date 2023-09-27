using System.Collections.Generic;
using Game.Level.Enemies;
using UnityEngine;
using System;


namespace Game.Level.Weapons.EnemiesDetect
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class EnemiesDetector : MonoBehaviour
    {
        public event Action OnEnemyDetected;
        
        private readonly ISet<IEnemyBehaviorHandler> _detectedEnemies = new HashSet<IEnemyBehaviorHandler>();

        private CircleCollider2D _circleCollider2D;


        private void OnValidate()
        {
            var col = GetComponent<CircleCollider2D>();
            col.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IEnemyBehaviorHandler enemy))
            {
                OnEnemyDetected?.Invoke();                
                RegisterDetectedEnemy(enemy);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IEnemyBehaviorHandler enemy))
                UnregisterDetectedEnemy(enemy);
        }
        
        public void Init(float radius)
            => _circleCollider2D.radius = radius;

        public IEnumerable<IEnemyBehaviorHandler> GetDetectedEnemies()
            => _detectedEnemies;
        
        private void RegisterDetectedEnemy(IEnemyBehaviorHandler enemyBehaviorHandler)
        {
            _detectedEnemies.Add(enemyBehaviorHandler);

            enemyBehaviorHandler.OnDeath += UnregisterDetectedEnemy;
        }  
        
        private void UnregisterDetectedEnemy(IEnemyBehaviorHandler enemyBehaviorHandler)
        {
            _detectedEnemies.Remove(enemyBehaviorHandler);

            enemyBehaviorHandler.OnDeath -= UnregisterDetectedEnemy; 
        }
    }
}