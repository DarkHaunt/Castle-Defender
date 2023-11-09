using Project.Scripts.Common.Save;
using Project.Scripts.Configs.Game;
using Project.Scripts.Configs.Level;
using Project.Scripts.Static;
using UnityEngine;


namespace Project.Scripts.Level.Debugging
{
    public class DebugService : MonoBehaviour
    {
        [SerializeField] private bool _isDebugEnabled;

        [Header("--- Player Debug ---")]
        [SerializeField] private bool _isDebugPlayer;
        [SerializeField] private PlayerConfig _debugPlayerConfig;
        
        [Header("--- Level Debug ---")]
        [SerializeField] private bool _isDebugLevel;
        [SerializeField] private LevelConfig _debugLevelConfig;
        
        
        public void PerformDebug()
        {
            if (_isDebugEnabled)
                return;

            Debug.Log($"<color=blue>!!! Debug Enabled !!!</color>");
            
            if (_isDebugPlayer)
                ForceSetCachedPlayerProgressData();

            if (_isDebugLevel)
                ForceSetCachedConfig();
        }
        
        private void ForceSetCachedPlayerProgressData()
        {
            var serializedLevelConfigs = new SerializedPlayerConfig(_debugPlayerConfig);
            
            JsonSerializer.SaveToFile(StaticDataContainer.PlayerConfigPath, serializedLevelConfigs);
        }
        
        private void ForceSetCachedConfig()
        {
            var serializedLevelConfigs = new SerializedLevelConfig(_debugLevelConfig);
            
            JsonSerializer.SaveToFile(StaticDataContainer.LevelConfigsPath, serializedLevelConfigs);
        }
    }
}