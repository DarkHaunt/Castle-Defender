using UnityEngine;


namespace Game.UI.Common
{
    [RequireComponent(typeof(Canvas))]
    public class UICanvasValidator : MonoBehaviour
    {
        private void OnValidate()
        {
            var uiCamera = FindObjectOfType<UICamera>();

            if (uiCamera)
            {
                var canvas = GetComponent<Canvas>();
                canvas.worldCamera = uiCamera.Camera;
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
            }
        }
    }
}