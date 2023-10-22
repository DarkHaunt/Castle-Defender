﻿using Game.Level.Enemies.BehaviorTree.Common.Nodes;
using Game.Level.Health;


namespace Game.Level.Enemies.BehaviorTree.Common
{
    public abstract class EnemyBehaviorTree
    {
        protected Node _root;
        private IAttackTarget _target;
        
        public abstract void Construct();


        public void SetTarget(IAttackTarget attackTarget)
            => _target = attackTarget;

        public IAttackTarget GetTarget()
            => _target;
        
        public void UpdateTreeBehavior(float timeStep)
            => _root?.Process(timeStep);
    }
}