using System;

namespace GofRPG_API
{
    public abstract class PhysicalMove : PrimaryMove
    {
        public int CalculateDamage(Character user, Character target)
        {
            if(user.Equals(null) || target.Equals(null))
            {
                return 0;
            }
            int attack = (int)(user.CharacterBaseStat.Atk * MovePowerPercent);
            int defense = target.CharacterBaseStat.Def;
            int damage = attack - defense;
            if(damage < 1)
            {
                damage = 1;
            }
            return 1;
        }
        public void HitTarget(int damage, Character target)
        {
            int hp = target.CharacterBaseStat.Hp - damage;
            if(hp < 0)
            {
                hp = 0;
            }
            target.CharacterBaseStat.Hp = hp;
        }
    }
}