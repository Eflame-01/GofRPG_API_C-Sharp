using System;

namespace GofRPG_API
{
    public class Priority1 : PriorityMove
    {
        public Priority1(Move secondaryMove, String name, String description, double accuracy, String target, int level, int energyPoints, int maxEnergyPoints)
        {
            SecondaryMove = secondaryMove;
            MoveName = name;
            MoveDescription = description;
            PrimaryMoveAccuracy = accuracy;
            MoveTarget = target;
            MoveLevel = level;
            MoveEnergyPoints = energyPoints;
            MoveMaxEnergyPoints = maxEnergyPoints;
            FlinchProbability = 1.0;
            SuccessionRate = 0.21;
            OriginalFlinchProbability = 1.0;
            MoveType = "PRIORITY ONE";
        }

        public Priority1(String name, String description, double accuracy, String target, int level, int energyPoints, int maxEnergyPoints)
        {
            MoveName = name;
            MoveDescription = description;
            PrimaryMoveAccuracy = accuracy;
            MoveTarget = target;
            MoveLevel = level;
            MoveEnergyPoints = energyPoints;
            MoveMaxEnergyPoints = maxEnergyPoints;
            FlinchProbability = 1.0;
            SuccessionRate = 0.21;
            OriginalFlinchProbability = 1.0;
            MoveType = "PRIORITY ONE";
        }
    }
}