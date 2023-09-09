using Game.Common.Save;
using Game.Level.Configs;
using UnityEngine;
using UnityEngine.Serialization;


namespace Game.Level.Services.Debugging
{
    public class ForcibleGameDataSetter : MonoBehaviour
    {
        [FormerlySerializedAs("_forceGlobalGameData")] [SerializeField] private PlayerProgressData _forcePlayerProgressData;


        public void ForceSetCachedPlayerProgressData()
        {
            var serializedLevelConfigs = new SerializedPlayerProgressData(_forcePlayerProgressData);
            
            JsonSerializer.SaveToFile(StaticDataContainer.UserConsumedProgressDataPath, serializedLevelConfigs);
        }
    }
}