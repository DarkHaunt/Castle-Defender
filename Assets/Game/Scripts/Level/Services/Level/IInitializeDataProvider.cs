using System;


namespace Game.Level.Configs
{
    public interface IInitializeDataProvider
    {
        event Action OnInitializeDataReady;
        
        void LoadInitializeData();
        LevelInitializeData GetInitializeData();
    }
}