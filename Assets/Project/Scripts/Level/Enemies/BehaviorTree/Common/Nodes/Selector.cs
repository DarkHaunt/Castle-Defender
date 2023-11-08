using System;


namespace Project.Scripts.Level.Enemies.BehaviorTree.Common.Nodes
{
    public class Selector : Node
    {
        private readonly Node[] _children;

        
        public Selector(params Node[] children)
        {
            _children = children;
        }


        public override ProcessState Process(float timeStep)
        {
            foreach (var child in _children)
            {
                var processResult = child.Process(timeStep);
                
                switch (processResult)
                {
                    case ProcessState.Running:
                        return UpdateStateFor(ProcessState.Running);
                    case ProcessState.Success:
                        return UpdateStateFor(ProcessState.Success);
                    case ProcessState.Failure:
                        continue;
                    default:
                        throw new ArgumentOutOfRangeException($"{nameof(ProcessState)} doesn't have state {processResult}!");
                }
            }

            return UpdateStateFor(ProcessState.Failure);
        }
    }
}