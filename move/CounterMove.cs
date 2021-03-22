using System;

namespace GofRPG_API
{
    public class CounterMove : PhysicalMove
    {
        public CounterMove(Move secondaryMove, String name, String description, double powerPercent, String target, int level, int energyPoints, int maxEnergyPoints)
        {
          SecondaryMove = secondaryMove;
          MoveName = name;
          MoveDescription = description;
          PrimaryMoveAccuracy = 1.0;  
          MoveTarget = target;
          MoveLevel = level;
          MoveEnergyPoints = energyPoints;
          MoveMaxEnergyPoints = maxEnergyPoints;
          MovePowerPercent = powerPercent;
          MoveType = "COUNTER";
        }
        public CounterMove(String name, String description, double powerPercent, String target, int level, int energyPoints, int maxEnergyPoints)
        {
          MoveName = name;
          MoveDescription = description;  
          PrimaryMoveAccuracy = 1.0;  
          MoveTarget = target;
          MoveLevel = level;
          MoveEnergyPoints = energyPoints;
          MoveMaxEnergyPoints = maxEnergyPoints;
          MovePowerPercent = powerPercent;
          MoveType = "COUNTER";
        }

        public override void PerformMove(Character user, Character target)
        {
            target.CharacterBattleStatus.ProtectionStatus = ProtectionStatus.COUNTER;
        }
    }
}