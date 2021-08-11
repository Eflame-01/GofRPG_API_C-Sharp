using System;

namespace GofRPG_API
{
    public class RegularMove : PhysicalMove
    {
        public double RecoilDamagePercent {get; set;}
        public RegularMove(Move secondaryMove, String name, String description, double accuracy, String target, int level, ArchetypeID moveArchetype, int energyPoints, int maxEnergyPoints, double powerPercent, double recoildDamagePercent)
        {
            SecondaryMove = secondaryMove;
            MoveName = name;
            MoveDescription = description;
            PrimaryMoveAccuracy = accuracy;
            MoveTarget = target;
            MoveLevel = level;
            MoveEnergyPoints = energyPoints;
            MoveMaxEnergyPoints = maxEnergyPoints;
            RecoilDamagePercent = recoildDamagePercent;
            MovePowerPercent = powerPercent;
            MoveType = "REGULAR";
        }
        public RegularMove(String name, String description, double accuracy, String target, int level, ArchetypeID moveArchetype, int energyPoints, int maxEnergyPoints, double powerPercent, double recoildDamagePercent)
        {
            MoveName = name;
            MoveDescription = description;
            PrimaryMoveAccuracy = accuracy;
            MoveTarget = target;
            MoveLevel = level;
            MoveEnergyPoints = energyPoints;
            MoveMaxEnergyPoints = maxEnergyPoints;
            RecoilDamagePercent = recoildDamagePercent;
            MovePowerPercent = powerPercent;
            MoveType = "REGULAR";
        }
        public override void PerformMove(Character user, Character target)
        {
            if(CanUseMove(user, target))
            {
                int damage = CalculateDamage(user, target);
                HitTarget(damage, target);
            }
        }
        public override void PerformSideEffect(Character target)
        {
            if(CanPerformSideEffect(target))
            {
                int recoilDamage = (int) (target.CharacterBaseStat.Hp * RecoilDamagePercent);
                int hp = target.CharacterBaseStat.Hp;
                target.CharacterBaseStat.Hp = Math.Clamp(hp - recoilDamage, 0, hp);
            }
        }
    }
}