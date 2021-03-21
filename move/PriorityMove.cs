using System;

namespace GofRPG_API
{
    public class PriorityMove : PhysicalMove
    {
        public double FlinchProbability {get; set;}
        public double SuccessionRate {get; set;}
        public double OriginalFlinchProbability {get; set;}
        public override void PerformMove(Character user, Character target)
        {
            int damage = CalculateDamage(user, target);
            HitTarget(damage, target);
            if(TargetFlinched())
            {
                target.CharacterBattleStatus.TurnStatus = TurnStatus.CANNOT_MOVE;
                FlinchProbability *= SuccessionRate;
            }
        }
        public override void ResetMove()
        {
            FlinchProbability = OriginalFlinchProbability;
        }
        private bool TargetFlinched()
        {
            Random rand = new Random();
            return (rand.NextDouble() <= FlinchProbability);
        }
    }
}