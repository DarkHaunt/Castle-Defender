using System.Collections.Generic;
using UnityEngine.Events;
using System.Collections;
using UnityEngine;


namespace Game.Extensions
{
    public static class MonoExtensions
    {
        private static readonly Dictionary<float, WaitForSeconds> WaitForSecondsDictionary = new();

        private static readonly WaitForFixedUpdate WaitForEndOfFixedUpdate = new();
        private static readonly WaitForEndOfFrame WaitForEndOfFrame = new();


        public static Coroutine Wait(this MonoBehaviour mono, float delay, UnityAction action)
            => mono.StartCoroutine(ExecuteAction(delay, action));

        public static WaitForEndOfFrame GetWaitForEndOfFrame()
            => WaitForEndOfFrame;

        public static WaitForFixedUpdate GetWaitForFixedUpdate()
            => WaitForEndOfFixedUpdate;

        public static WaitForSeconds GetWait(float time)
        {
            if (!WaitForSecondsDictionary.TryGetValue(time, out var wait))
            {
                wait = new WaitForSeconds(time);
                
                WaitForSecondsDictionary[time] = wait;
            }

            return wait;
        }

        private static IEnumerator ExecuteAction(float delay, UnityAction action)
        {
            yield return new WaitForSecondsRealtime(delay);

            action?.Invoke();
        }

        public static bool IsNull(this MonoBehaviour obj) =>
            (object)obj == null;

        public static bool IsNotNull(this MonoBehaviour obj) =>
            !IsNull(obj);
    }
}