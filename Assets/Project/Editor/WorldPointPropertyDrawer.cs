using Project.Scripts.Common.World;
using UnityEditor;
using UnityEngine;


namespace Project.Editor
{
    [CustomPropertyDrawer(typeof(WorldPoint))]
    public sealed class WorldPointPropertyDrawer : PropertyDrawer
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