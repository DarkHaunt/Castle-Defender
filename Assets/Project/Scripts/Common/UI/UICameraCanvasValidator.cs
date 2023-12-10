﻿#if UNITY_EDITOR
using Project.Scripts.Global;
using UnityEngine;


namespace Project.Scripts.Common.UI
{
    [ExecuteInEditMode]
    public class UICameraCanvasValidator : MonoBehaviour
    {
        private void Awake()
        {
            var canvas = GetComponent<Canvas>();
            var obj = GameObject.Find(InfrastructureKeys.UICameraName);

            if (obj && obj.TryGetComponent(out Camera uiCamera))
            {
                canvas.worldCamera = uiCamera;
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
            }
        }
    }
}
#endif