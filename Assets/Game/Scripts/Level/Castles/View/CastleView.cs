using Game.Level.Castles.Binder;
using System;
using UnityEngine;
using VContainer;


namespace Game.Level.Castles
{
    public abstract class CastleView : MonoBehaviour
    {
        protected CastleBinder _castleBinder;


        [Inject]
        private void Construct(CastleBinder castleBinder)
        {
            _castleBinder = castleBinder;
        }

        private void OnEnable()
        {
            Enable();
        }

        private void OnDisable()
        {
            Disable();
        }

        public abstract void Enable();
        public abstract void Disable();
    }
}