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
      if(CanUseMove(user, target))
      {
        //setting the protection status to COUNTER enables the target to reflect physical moves back to any character that attacked them.
        target.CharacterBattleStatus.ProtectionStatus = ProtectionStatus.COUNTER;
      }
    }
  }
}