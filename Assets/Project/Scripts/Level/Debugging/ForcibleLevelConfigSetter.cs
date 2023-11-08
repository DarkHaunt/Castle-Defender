﻿using Game.Common.Save;
using Game.Configs.Level;
using Game.Static;
using UnityEngine;


namespace Project.Scripts.Level.Debugging
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