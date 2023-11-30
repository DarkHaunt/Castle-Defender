namespace Project.Scripts.Level.Enemies.Animation
{
    public class AnimationData
    {
        public readonly string AttackAnimName;
        public readonly string DeathAnimName;
        public readonly string IdleAnimName;
        public readonly string WalkAnimName;
        
        
        public AnimationData(string idleAnimName, string walkAnimName, string attackAnimName, string deathAnimName)
        {
            AttackAnimName = attackAnimName;
            DeathAnimName = deathAnimName;
            IdleAnimName = idleAnimName;
            WalkAnimName = walkAnimName;
        }
    }
}