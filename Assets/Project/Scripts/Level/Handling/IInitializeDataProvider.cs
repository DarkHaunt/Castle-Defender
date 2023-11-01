using System;


namespace Game.Level.Services.Level
{
    public interface IInitializeDataProvider
    {
        event Action OnInitializeDataReady;
        
        void LoadInitializeData();
        LevelInitializeData GetInitializeData();
    }
}