using System;

namespace GofRPG_API
{
  public class CounterMove : PhysicalMove
  {
    public CounterMove(Move secondaryMove, String name, String description, double accuracy, double powerPercent, String target, int level, ArchetypeID moveArchetype, int energyPoints, int maxEnergyPoints)
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
      MoveType = "COUNTER";
    }
    public CounterMove(String name, String description, double powerPercent, double accuracy, String target, int level, ArchetypeID moveArchetype, int energyPoints, int maxEnergyPoints)
    {
      MoveName = name;
      MoveDescription = description;  
      PrimaryMoveAccuracy = accuracy;  
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