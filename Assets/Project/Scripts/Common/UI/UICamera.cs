using UnityEngine;


namespace Project.Scripts.Common.UI
{
    [RequireComponent(typeof(Camera))]
    public class UICamera : MonoBehaviour
    {
        [field: SerializeField] public Camera Camera { get; private set; }

        private void OnValidate()
        {
            name = "UICamera";
            Camera = GetComponent<Camera>();
        }
    }
}