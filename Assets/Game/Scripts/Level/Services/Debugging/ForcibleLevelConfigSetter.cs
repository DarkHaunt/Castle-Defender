using Game.Level.Configs;
using Game.Common.Save;
using UnityEngine;


namespace Game.Test
{
    public class ForcibleLevelConfigSetter : MonoBehaviour
    {
        [SerializeField] private LevelConfig _forceLevelConfig;


        public void ForceSetCachedConfig()
        {
            var serializedLevelConfigs = new SerializedLevelConfig(_forceLevelConfig);
            
            JsonSerializer.SaveToFile(StaticDataContainer.LevelConfigsPath, serializedLevelConfigs);
        }
    }
}