using UnityEngine;


namespace Project.Scripts.Level.Projectiles
{
    [RequireComponent(typeof(Projectile))]
    public class ProjectileRotator : MonoBehaviour
    {
        private Projectile _projectile;


        private void Awake()
            => _projectile = GetComponent<Projectile>();
        
        private void OnEnable()
            => _projectile.OnDirectionChanged += Rotate;

        private void OnDisable()
            => _projectile.OnDirectionChanged -= Rotate;

        private void Rotate(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var targetRotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

            transform.rotation = targetRotation;
        }
    }
}