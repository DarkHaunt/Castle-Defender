using System;


namespace Game.Level.Enemies.BehaviorTree
{
    public class Selector : Node
    {
        private readonly Node[] _children;

        
        public Selector(params Node[] children)
        {
            _children = children;
        }


        public override NodeProcessState Process(float timeStep)
        {
            foreach (var child in _children)
            {
                var processResult = child.Process(timeStep);
                
                switch (processResult)
                {
                    case NodeProcessState.Running:
                        _currentNodeProcessState = NodeProcessState.Running;
                        return _currentNodeProcessState;
                    case NodeProcessState.Success:
                        _currentNodeProcessState = NodeProcessState.Success;
                        return _currentNodeProcessState;
                    case NodeProcessState.Failure:
                        continue;
                    default:
                        throw new ArgumentOutOfRangeException($"{nameof(NodeProcessState)} doesn't have state {processResult}!");
                }
            }

            _currentNodeProcessState = NodeProcessState.Failure;

            return _currentNodeProcessState;
        }
    }
}