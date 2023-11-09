using System.Collections;
using UnityEngine;


namespace Project.Scripts.Common.Interfaces
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);

        void StopCoroutine(Coroutine coroutine);
    }
}