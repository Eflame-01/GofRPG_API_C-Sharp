using System;

namespace GofRPG_API
{
    public class Priority2 : PriorityMove
    {
        public Priority2(Move secondaryMove, String name, String description, double accuracy, String target, int level, int energyPoints, int maxEnergyPoints, double powerPercent)
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
            FlinchProbability = 0.21;
            SuccessionRate = 0.42;
            OriginalFlinchProbability = 0.21;
            MoveType = "PRIORITY TWO";
        }

        public Priority2(String name, String description, double accuracy, String target, int level, int energyPoints, int maxEnergyPoints, double powerPercent)
        {
            MoveName = name;
            MoveDescription = description;
            PrimaryMoveAccuracy = accuracy;
            MoveTarget = target;
            MoveLevel = level;
            MoveEnergyPoints = energyPoints;
            MoveMaxEnergyPoints = maxEnergyPoints;
            MovePowerPercent = powerPercent;
            FlinchProbability = 0.21;
            SuccessionRate = 0.42;
            OriginalFlinchProbability = 0.21;
            MoveType = "PRIORITY TWO";
        }
    }
}