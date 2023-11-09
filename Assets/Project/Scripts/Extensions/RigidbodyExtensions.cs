using UnityEngine;


namespace Project.Scripts.Extensions
{
    public static class RigidbodyExtensions
    {
        public static void Deactivate(this Rigidbody2D rb)
        {
            rb.velocity = Vector2.zero;
            rb.simulated = false;
        }
    }
}