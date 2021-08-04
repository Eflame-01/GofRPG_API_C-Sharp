using System;

namespace GofRPG_API
{
    public class PriorityMove : PhysicalMove
    {
        public double FlinchProbability {get; set;}
        public double SuccessionRate {get; set;}
        public double OriginalFlinchProbability {get; set;}

        public PriorityMove(Move secondaryMove, String name, String description, double accuracy, String target, int level, int energyPoints, int maxEnergyPoints, double powerPercent, int priorityLevel)
        {
            SecondaryMove = secondaryMove;
            MoveName = name;
            MoveDescription = description;
            PrimaryMoveAccuracy = accuracy;
            MoveTarget = target;
            MoveLevel = level;
            MoveEnergyPoints = energyPoints;
            MoveMaxEnergyPoints = maxEnergyPoints;
            MovePowerPercent = powerPercent;
            AdjustPriorityMove(priorityLevel);
        }

        public PriorityMove(String name, String description, double accuracy, String target, int level, int energyPoints, int maxEnergyPoints, double powerPercent, int priorityLevel)
        {
            MoveName = name;
            MoveDescription = description;
            PrimaryMoveAccuracy = accuracy;
            MoveTarget = target;
            MoveLevel = level;
            MoveEnergyPoints = energyPoints;
            MoveMaxEnergyPoints = maxEnergyPoints;
            MovePowerPercent = powerPercent;
            AdjustPriorityMove(priorityLevel);
        }

        public override void PerformMove(Character user, Character target)
        {
            if(user == null || target == null)
            {
                return;
            }
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

        private void AdjustPriorityMove(int priorityLevel)
        {
            switch(priorityLevel)
            {
                case 1:
                FlinchProbability = 1.0;
                SuccessionRate = 0.21;
                OriginalFlinchProbability = 1.0;
                MoveType = "PRIORITY ONE";
                break;
                case 2:
                FlinchProbability = 0.21;
                SuccessionRate = 0.42;
                OriginalFlinchProbability = 0.21;
                MoveType = "PRIORITY TWO";
                break;
                case 3:
                FlinchProbability = 0.0441;
                SuccessionRate = 1.0;
                OriginalFlinchProbability = 0.0441;
                MoveType = "PRIORITY THREE";
                break;
                default:
                FlinchProbability = 1.0;
                SuccessionRate = 0.21;
                OriginalFlinchProbability = 1.0;
                MoveType = "PRIORITY ONE";
                break;
            }
        }
    }
}