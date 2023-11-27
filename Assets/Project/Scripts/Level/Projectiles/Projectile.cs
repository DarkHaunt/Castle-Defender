using Project.Scripts.Level.Common.Damage;
using Project.Scripts.Extensions;
using System.Collections;
using UnityRangeValue;
using UnityEngine;
using System;


namespace Project.Scripts.Level.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Projectile : MonoBehaviour
    {
        public event Action<Vector2> OnDirectionChanged;
        
        private const float LimitLifeTime = 5f;

        [SerializeField] private RangeValue _flyForce;

        [Header("--- Components ---")]
        [SerializeField] private ParticleSystem _flyParticles;
        [SerializeField] private ParticleSystem _hitParticle;
        [SerializeField] private GameObject _visuals;
        
        private Vector2 _lastVelocity;
        private float _damage;
        
        private Rigidbody2D _rigidbody;
        private Collider2D _collider;
        private Coroutine _lifetime;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out CollideAttackTarget attackTarget))
                attackTarget.GetDamage(_damage);

            StartCoroutine(HitProcess());
        }

        public void Fly(float damage, Vector2 startPos, Vector2 direction)
        {
            OnDirectionChanged?.Invoke(direction);
            transform.SetInPosition(startPos);

            _damage = damage;
            _rigidbody.AddForce(direction * _flyForce.Rand(), ForceMode2D.Impulse);
            
            _lifetime = StartCoroutine(LifetimeProcess());
        }

        private IEnumerator HitProcess()
        {
            _visuals.SetActive(false);
            _collider.enabled = false;
            _rigidbody.simulated = false;

            /*var duration = _hitParticle.main.duration;
            _hitParticle.Play();

            yield return MonoExtensions.GetWait(duration);*/

            yield return null;

            DeactivateProjectile();
        }

        private IEnumerator LifetimeProcess()
        {
            _visuals.SetActive(true);
            _collider.enabled = true;
            _rigidbody.simulated = true;
            
            yield return MonoExtensions.GetWait(LimitLifeTime);

            DeactivateProjectile();
        }

        private void DeactivateProjectile()
        {
            _visuals.SetActive(false);
            
            gameObject.SetActive(false);
            StopCoroutine(_lifetime);
        }
    }
}