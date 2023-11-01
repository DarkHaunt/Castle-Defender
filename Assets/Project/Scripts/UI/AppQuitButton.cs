using UnityEngine.UI;
using UnityEngine;


namespace Game.UI.Common
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
