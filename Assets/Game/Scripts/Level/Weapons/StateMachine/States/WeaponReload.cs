using Game.Level.StateMachine.States;
using Game.Level.StateMachine;
using Game.Common.Interfaces;
using System.Collections;
using Game.Extensions;
using UnityEngine;


namespace Game.Level.Weapons.StateMachine.States
{
    public class WeaponReload : IState
    {
        private readonly IStateSwitcher _weaponStateSwitcher;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly float _reloadTime;
         
        private Coroutine _currentReloading;


        public WeaponReload(IStateSwitcher weaponStateSwitcher, ICoroutineRunner coroutineRunner, float reloadTime)
        {
            _weaponStateSwitcher = weaponStateSwitcher;
            _coroutineRunner = coroutineRunner;
            _reloadTime = reloadTime;
        }

        
        public void Enter()
            => _currentReloading = _coroutineRunner.StartCoroutine(Reloading());

        public void Exit()
            => _coroutineRunner.TryToStopCoroutine(_currentReloading);

        private IEnumerator Reloading()
        {
            yield return MonoExtensions.GetWait(_reloadTime);

            _weaponStateSwitcher.SwitchToState<WeaponSearchForTarget>();
        }
    }
}