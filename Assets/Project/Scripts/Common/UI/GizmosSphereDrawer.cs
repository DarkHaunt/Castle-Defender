using UnityEngine;


namespace Project.Scripts.Common.UI
{
    [DisallowMultipleComponent]
    public sealed class GizmosSphereDrawer : MonoBehaviour
    {
        [SerializeField] private float _radius = 0.5f;
        [SerializeField] private Color _color = Color.green;
        

        private void OnDrawGizmos()
        {
            Gizmos.color = _color;
            Gizmos.DrawSphere(transform.position, _radius);
            Gizmos.color = Color.white;
        }
    }
}