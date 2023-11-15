using UnityEditor;
using UnityEngine;


namespace Project.Editor
{
    public class ClearPlayerPrefs : EditorWindow
    {
        [MenuItem("Tools/Clear PlayerPrefs")]
        private static void ClearPrefs()
        {
            PlayerPrefs.DeleteAll();
            Debug.Log($"<color=red>!!! PLAYER PREFS HAS BEEN CLEARED !!!</color>");
        }
    }
}