using Project.Scripts.Level.Enemies;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Project.Scripts.Level.Weapons.EnemiesDetection
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class EnemiesDetector : MonoBehaviour
    {
        public event Action OnEnemyDetected;

        private readonly ISet<IEnemy> _detectedEnemies = new HashSet<IEnemy>();

        private CircleCollider2D _collider;


        private void OnValidate()
        {
            var col = GetComponent<CircleCollider2D>();
            col.isTrigger = true;
        }

        private void Awake()
            => _collider = GetComponent<CircleCollider2D>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IEnemy enemy))
            {
                RegisterDetectedEnemy(enemy);
                OnEnemyDetected?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IEnemy enemy))
                UnregisterDetectedEnemy(enemy);
        }

        public void Init(float radius)
            => _collider.radius = radius;

        public void Enable()
            => _collider.enabled = true;
				
        public void Disable() 
            => _collider.enabled = false;

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