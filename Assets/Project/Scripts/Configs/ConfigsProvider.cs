using Project.Scripts.Common.Infrastructure;
using Project.Scripts.Configs.Level;
using Project.Scripts.Configs.Game;
using Project.Scripts.Global;


namespace Project.Scripts.Configs
{
    public class ConfigsProvider
    {
        public IPlayerConfig PlayerConfig { get; private set; }
        public ILevelConfig LevelConfig { get; private set; }


        public void SaveConfigs()
        {
            var playerConfig = new SerializedPlayerConfig(PlayerConfig);
            var levelConfig = new SerializedLevelConfig(LevelConfig);

            JsonSerializer.SaveToFile(InfrastructureKeys.PlayerConfigPath, playerConfig);
            JsonSerializer.SaveToFile(InfrastructureKeys.LevelConfigsPath, levelConfig);
        }

        public void LoadConfigs()
        {
            PlayerConfig = JsonSerializer.LoadFile<SerializedPlayerConfig>(InfrastructureKeys.PlayerConfigPath);
            LevelConfig = JsonSerializer.LoadFile<SerializedLevelConfig>(InfrastructureKeys.LevelConfigsPath);
        }
        
        public void UpdatePlayerConfig(IPlayerConfig newPlayerConfig)
            => PlayerConfig = newPlayerConfig;

        public void UpdateLevelConfig(ILevelConfig newLevelConfig)
            => LevelConfig = newLevelConfig;
    }
}