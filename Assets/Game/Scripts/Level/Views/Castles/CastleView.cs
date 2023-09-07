using Game.Level.Binders;
using UnityEngine;
using VContainer;


namespace Game.Level.Views.Castles
{
    public abstract class CastleView : MonoBehaviour
    {
        protected CastleBinder _castleBinder;


        [Inject]
        private void Construct(CastleBinder castleBinder)
        {
            _castleBinder = castleBinder;
        }

        /*private void OnEnable()
        {
            Enable();
            
            _castleBinder.Enable();
        }

        private void OnDisable()
        {
            Disable();
            
            _castleBinder.Disable();
        }*/

        protected abstract void Enable();
        protected abstract void Disable();
    }
}