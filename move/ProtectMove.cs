using System;

namespace GofRPG_API
{
    public class ProtectMove : PrimaryMove
    {
        public ProtectionStatus ProtectMoveType {get; set;}
        public double SuccessionRate {get; set;}
        public double ProtectionAccuracy {get; set;}
        public ProtectMove(Move secondaryMove, String name, String description, double accuracy, String target, int level, int energyPoints, int maxEnergyPoints, ProtectionStatus protectMoveType, double successionPercent)
        {
            SecondaryMove = secondaryMove;
            MoveName = name;
            MoveDescription = description;
            PrimaryMoveAccuracy = accuracy;
            MoveTarget = target;
            MoveLevel = level;
            MoveEnergyPoints = energyPoints;
            MoveMaxEnergyPoints = maxEnergyPoints;
            ProtectMoveType = protectMoveType;
            SuccessionRate = successionPercent;
            ProtectionAccuracy = PrimaryMoveAccuracy;
            MoveType = "PROTECT";
        }
        public ProtectMove(String name, String description, double accuracy, String target, int level, int energyPoints, int maxEnergyPoints, ProtectionStatus protectMoveType, double successionPercent)
        {
            MoveName = name;
            MoveDescription = description;
            PrimaryMoveAccuracy = accuracy;
            MoveTarget = target;
            MoveLevel = level;
            MoveEnergyPoints = energyPoints;
            MoveMaxEnergyPoints = maxEnergyPoints;
            ProtectMoveType = protectMoveType;
            SuccessionRate = successionPercent;
            ProtectionAccuracy = PrimaryMoveAccuracy;
            MoveType = "PROTECT";
        }
        public override void PerformMove(Character user, Character target)
        {
            if(user == null || target == null)
            {
                return;
            }
            target.CharacterBattleStatus.ProtectionStatus = ProtectMoveType;
            PrimaryMoveAccuracy *= SuccessionRate;
        }
        public override void ResetMove()
        {
            base.ResetMove();
            PrimaryMoveAccuracy = ProtectionAccuracy;
        }
    }
}