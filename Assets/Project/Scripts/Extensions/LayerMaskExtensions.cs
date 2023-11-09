using System;
using UnityEngine;


namespace Project.Scripts.Extensions
{
    public static class LayerMaskExtensions
    {
        public static LayerMask GetMaskFromLayer(int layer)
            => (int)Math.Pow(2, layer);

        public static bool ContainsLayer(this LayerMask mask, int layer)
        {
            var bit = 1 << layer;

            return (mask.value & bit) != 0;
        }
    }
}