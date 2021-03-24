using System;

namespace GofRPG_API
{
    public class RegularMove : PhysicalMove
    {
        public double RecoilDamagePercent {get; set;}
        public RegularMove(Move secondaryMove, String name, String description, double accuracy, String target, int level, int energyPoints, int maxEnergyPoints, double powerPercent, double recoildDamagePercent)
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
        public RegularMove(String name, String description, double accuracy, String target, int level, int energyPoints, int maxEnergyPoints, double powerPercent, double recoildDamagePercent)
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
            if(user == null || target == null)
            {
                return;
            }
            int damage = CalculateDamage(user, target);
            HitTarget(damage, target);
        }
        public override void PerformSideEffect(Character target)
        {
            if(target == null)
            {
                return;
            }
            int recoilDamage = (int) (target.CharacterBaseStat.Hp * RecoilDamagePercent);
            int hp = target.CharacterBaseStat.Hp - recoilDamage;
            if(hp < 0)
            {
                target.CharacterBaseStat.Hp = 0;
            }
            else{
                target.CharacterBaseStat.Hp = hp;
            }
        }
    }
}