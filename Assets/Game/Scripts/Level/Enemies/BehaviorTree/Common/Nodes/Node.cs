namespace Game.Level.Enemies.BehaviorTree
{
    public abstract class Node
    {
        protected NodeProcessState _currentNodeProcessState;

        public abstract NodeProcessState Process(float timeStep);
    }
}