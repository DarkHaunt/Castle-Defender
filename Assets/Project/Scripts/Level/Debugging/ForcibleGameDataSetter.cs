using Game.Common.Save;
using Game.Configs.Game;
using Game.Static;
using UnityEngine;
using UnityEngine.Serialization;


namespace Project.Scripts.Level.Debugging
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