using System;
using UnityEditor;
using UnityEngine;


namespace Game.Extensions
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

    [CustomPropertyDrawer(typeof(WorldPoint))]
    public class WorldPointPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var transformSerializedProperty = property.FindPropertyRelative("_point");
            EditorGUI.ObjectField(position, transformSerializedProperty, typeof(Transform), label);

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}