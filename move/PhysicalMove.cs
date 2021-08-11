using System;

namespace GofRPG_API
{
    public abstract class PhysicalMove : PrimaryMove
    {
        public int CalculateDamage(Character user, Character target)
        {
            //TODO: do not need to check this because every Physical Moves checks if they can use the move before calculating damage
            if(user == null || target == null)
            {
                return 0;
            }

            //if the user is using a move that doesn't belong to their archetype, power percent needs to be reduce
            double newMovePowerPercent = MovePowerPercent;
            if(!user.CharacterArchetype.MainArchetypeName.Equals(MoveArchetype))
            {
                newMovePowerPercent = MovePowerPercent * 0.90;
            }

            //calculate damage = (how much attack power the user has with move) - (how much of the attack the target can withstand with their defense)
            int attack = (int)(user.CharacterBaseStat.Atk * newMovePowerPercent);
            int defense = target.CharacterBaseStat.Def;
            int damage = Math.Clamp(attack - defense, 1, attack);

            return damage;
        }
        public void HitTarget(int damage, Character target)
        {
            //TODO: do not need to check this because target will never be null at this point, and damage will always be >= 1
            if(target == null || damage == 0)
            {
                return;
            }
            
            int hp = target.CharacterBaseStat.Hp;
            target.CharacterBaseStat.Hp = Math.Clamp(hp - damage, 0, hp);
        }
    }
}