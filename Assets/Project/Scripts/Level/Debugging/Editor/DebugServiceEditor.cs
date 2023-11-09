using UnityEditor;


namespace Project.Scripts.Level.Debugging.Editor
{
    [CustomEditor(typeof(DebugService))]
    public class DebugServiceEditor : UnityEditor.Editor
    {
        private SerializedProperty isDebugEnabledProp;
        private SerializedProperty isDebugPlayerProp;
        private SerializedProperty debugPlayerConfigProp;
        private SerializedProperty isDebugLevelProp;
        private SerializedProperty debugLevelConfigProp;

        private void OnEnable()
        {
            isDebugEnabledProp = serializedObject.FindProperty("_isDebugEnabled");
            isDebugPlayerProp = serializedObject.FindProperty("_isDebugPlayer");
            debugPlayerConfigProp = serializedObject.FindProperty("_debugPlayerConfig");
            isDebugLevelProp = serializedObject.FindProperty("_isDebugLevel");
            debugLevelConfigProp = serializedObject.FindProperty("_debugLevelConfig");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(isDebugEnabledProp);

            if (isDebugEnabledProp.boolValue)
            {
                EditorGUILayout.PropertyField(isDebugPlayerProp);
                
                if (isDebugPlayerProp.boolValue)
                    EditorGUILayout.PropertyField(debugPlayerConfigProp);

                EditorGUILayout.PropertyField(isDebugLevelProp);
                
                if (isDebugLevelProp.boolValue)
                    EditorGUILayout.PropertyField(debugLevelConfigProp);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}