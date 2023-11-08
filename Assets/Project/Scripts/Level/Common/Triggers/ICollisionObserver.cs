using System;
using UnityEngine;


namespace Project.Scripts.Level.Common.Triggers
{
    public interface ICollisionObserver
    {
        event Action<Collision2D> OnCollideEnter;
        event Action<Collision2D> OnCollideExit;
    }
}