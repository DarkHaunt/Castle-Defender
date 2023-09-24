namespace Game.Level.Enemies.BehaviorTree
{
    public abstract class Node
    {
        private ProcessState _currentProcessState;

        public abstract ProcessState Process(float timeStep);

        protected ProcessState UpdateStateFor(ProcessState newProcessState)
        {
            _currentProcessState = newProcessState;
            return _currentProcessState;
        }
    }
}