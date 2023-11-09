using System;
using UnityEngine;


namespace Project.Scripts.Extra
{
    [Serializable]
    public sealed record WorldPoint
    {
        [SerializeField] private Transform _point;


        public static implicit operator Vector3(WorldPoint point)
        {
            var transform = point._point;

            if (!transform)
                throw new ArgumentException("World point have null transform");

            return transform.position;
        }
    }
}