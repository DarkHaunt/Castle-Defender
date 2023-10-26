using UnityEngine;
using System;


namespace Game.Level.Common.Triggers
{
    public interface ICollisionObserver
    {
        event Action<Collision2D> OnCollideEnter;
        event Action<Collision2D> OnCollideExit;
    }
}