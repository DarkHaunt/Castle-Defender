using System;


namespace Game.Level.Enemies.BehaviorTree
{
    public class Sequence : Node
    {
        private readonly Node[] _children;


        public Sequence(params Node[] children)
        {
            _children = children;
        }


        public override NodeProcessState Process(float timeStep)
        {
            var anyChildIsRunning = false;

            foreach (var child in _children)
            {
                var processResult = child.Process(timeStep);

                switch (processResult)
                {
                    case NodeProcessState.Running:
                        anyChildIsRunning = true;
                        continue;
                    case NodeProcessState.Failure:
                        _currentNodeProcessState = NodeProcessState.Failure;
                        return _currentNodeProcessState;
                    case NodeProcessState.Success:
                        continue;
                    default:
                        throw new ArgumentOutOfRangeException(
                            $"{nameof(NodeProcessState)} doesn't have state {processResult}!");
                }
            }

            _currentNodeProcessState = anyChildIsRunning ? NodeProcessState.Running : NodeProcessState.Success;

            return _currentNodeProcessState;
        }
    }
}