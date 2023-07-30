using UnityEngine;
using System;


namespace Game.Level.Common.Triggers
{
    public class CollisionObserver : MonoBehaviour, ICollisionObserver
    {
        public event Action<Collision2D> OnCollideEnter;
        public event Action<Collision2D> OnCollideExit;


        private void OnCollisionEnter2D(Collision2D other)
            => OnCollideEnter?.Invoke(other);
        
        private void OnCollisionExit2D(Collision2D other)
            => OnCollideExit?.Invoke(other);
    }
}
