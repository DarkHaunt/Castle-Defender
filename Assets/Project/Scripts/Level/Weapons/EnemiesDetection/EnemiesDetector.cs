using Game.Level.Enemies;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Level.Weapons.EnemiesDetection
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

        private void Awake()
            => _circleCollider2D = GetComponent<CircleCollider2D>();

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
            => _circleCollider2D.radius = radius;

        public void Enable()
            => _circleCollider2D.enabled = true;
				
        public void Disable() 
            => _circleCollider2D.enabled = false;

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