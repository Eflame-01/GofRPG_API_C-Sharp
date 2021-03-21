using System;

namespace GofRPG_API
{
    public class KnockoutMove : PrimaryMove
    {
        public KnockoutMove(Move secondaryMove, String name, String description, double accuracy, String target, int level, int energyPoints, int maxEnergyPoints)
        {
            SecondaryMove = secondaryMove;
            MoveName = name;
            MoveDescription = description;
            PrimaryMoveAccuracy = accuracy;
            MoveTarget = target;
            MoveLevel = level;
            MoveEnergyPoints = energyPoints;
            MoveMaxEnergyPoints = maxEnergyPoints;
            MoveType = "KNOCKOUT";
        }
        public KnockoutMove(String name, String description, double accuracy, String target, int level, int energyPoints, int maxEnergyPoints)
        {
            MoveName = name;
            MoveDescription = description;
            PrimaryMoveAccuracy = accuracy;
            MoveTarget = target;
            MoveLevel = level;
            MoveEnergyPoints = energyPoints;
            MoveMaxEnergyPoints = maxEnergyPoints;
            MoveType = "KNOCKOUT";
        }
        public override void PerformMove(Character user, Character target)
        {
            target.CharacterBaseStat.Hp = 0;
        }
    }
}