using Interfaces;
using VContainer.Unity;


namespace Game.Level
{
    public class CastleService
    {
        private readonly ICastle _castle;
        

        public CastleService(ICastle castle)
        {
            _castle = castle;
        }
    }
}