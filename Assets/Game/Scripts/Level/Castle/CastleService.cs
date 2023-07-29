namespace Game.Level.Castle
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