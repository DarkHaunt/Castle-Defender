using System.Collections;
using UnityEngine;


namespace Game.Common.Interfaces
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);

        void StopCoroutine(Coroutine coroutine);
    }
}