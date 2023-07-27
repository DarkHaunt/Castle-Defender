using Interfaces;
using VContainer.Unity;


namespace Game.Level
{
    public class CastleService : IStartable
    {
        private readonly ICastle _castle;
        

        public CastleService(ICastle castle)
        {
            _castle = castle;
        }


        void IStartable.Start()
        {
            _castle.TestPrint();
        }
    }
}