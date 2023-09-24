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


        public override ProcessState Process(float timeStep)
        {
            var anyChildIsRunning = false;

            foreach (var child in _children)
            {
                var processResult = child.Process(timeStep);

                switch (processResult)
                {
                    case ProcessState.Running:
                        anyChildIsRunning = true;
                        continue;
                    case ProcessState.Failure:
                        return UpdateStateFor(ProcessState.Failure);
                    case ProcessState.Success:
                        continue;
                    default:
                        throw new ArgumentOutOfRangeException(
                            $"{nameof(ProcessState)} doesn't have state {processResult}!");
                }
            }

            var state = anyChildIsRunning ? ProcessState.Running : ProcessState.Success;
            return UpdateStateFor(state);
        }
    }
}