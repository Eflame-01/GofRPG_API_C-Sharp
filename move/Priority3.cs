using System;

namespace GofRPG_API
{
    public class Priority3 : PriorityMove
    {
        public Priority3(Move secondaryMove, String name, String description, double accuracy, String target, int level, int energyPoints, int maxEnergyPoints, double powerPercent)
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
            FlinchProbability = 0.0441;
            SuccessionRate = 1.0;
            OriginalFlinchProbability = 0.0441;
            MoveType = "PRIORITY THREE";
        }

        public Priority3(String name, String description, double accuracy, String target, int level, int energyPoints, int maxEnergyPoints, double powerPercent)
        {
            MoveName = name;
            MoveDescription = description;
            PrimaryMoveAccuracy = accuracy;
            MoveTarget = target;
            MoveLevel = level;
            MoveEnergyPoints = energyPoints;
            MoveMaxEnergyPoints = maxEnergyPoints;
            MovePowerPercent = powerPercent;
            FlinchProbability = 0.0441;
            SuccessionRate = 1.0;
            OriginalFlinchProbability = 0.0441;
            MoveType = "PRIORITY THREE";
        }
    }
}