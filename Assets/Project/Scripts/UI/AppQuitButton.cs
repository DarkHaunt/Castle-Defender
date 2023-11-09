using UnityEngine;
using UnityEngine.UI;


namespace Project.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class AppQuitButton : MonoBehaviour
    {
        private void Awake()
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                Debug.Log($"<color=black>EXIT APPLICATION</color>");
                
#if UNITY_STANDALONE
                Application.Quit();
#endif

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            });
        }
    }
}
