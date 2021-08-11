using System;

namespace GofRPG_API
{
    public class Burn : StatusCondition
    {
        public double BurnDamage {get; set;}

        public Burn(double damage)
        {
            BurnDamage = Math.Clamp(damage, 0.05, 0.25);
        }
        public Burn()
        {
            BurnDamage = 0.05;
        }

        public String GetStatusConditionName()
        {
            return "BURN";
        }
        public void ImplementStatusCondition(Character character)
        {
            if(character.CharacterBattleStatus.StatusCondition.Equals(this))
            {
                int hp = character.CharacterBaseStat.Hp;
                character.CharacterBaseStat.Hp = Math.Clamp((int) (hp * BurnDamage), 0, hp);
            }
        }
        public void RemoveStatusCondition(Character character)
        {
            if(character.CharacterBattleStatus.StatusCondition.Equals(this))
            {
                character.CharacterBattleStatus.StatusCondition = null;
            }
        }
    }
}