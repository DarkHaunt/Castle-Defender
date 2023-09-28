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
        
        private readonly ISet<IEnemy> _detectedEnemies = new HashSet<IEnemy>();

        private CircleCollider2D _circleCollider2D;


        private void OnValidate()
        {
            var col = GetComponent<CircleCollider2D>();
            col.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IEnemy enemy))
            {
                OnEnemyDetected?.Invoke();                
                RegisterDetectedEnemy(enemy);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IEnemy enemy))
                UnregisterDetectedEnemy(enemy);
        }
        
        public void Init(float radius)
            => _circleCollider2D.radius = radius;

        public IEnumerable<IEnemy> GetDetectedEnemies()
            => _detectedEnemies;
        
        private void RegisterDetectedEnemy(IEnemy targetBehaviorHandler)
        {
            _detectedEnemies.Add(targetBehaviorHandler);

            targetBehaviorHandler.OnDeath += UnregisterDetectedEnemy;
        }  
        
        private void UnregisterDetectedEnemy(IEnemy targetBehaviorHandler)
        {
            _detectedEnemies.Remove(targetBehaviorHandler);

            targetBehaviorHandler.OnDeath -= UnregisterDetectedEnemy; 
        }
    }
}