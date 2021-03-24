using System;

namespace GofRPG_API
{
    public class Burn : StatusCondition
    {
        public String StatusName 
        {
            get
            {
                return "BURN";
            }
        }
        public double BurnDamage {get; set;}

        public Burn(double damage)
        {
            BurnDamage = SetBurnDamage(damage);
        }
        public Burn()
        {
            BurnDamage = 0.05;
        }

        public String GetStatusConditionName()
        {
            return StatusName;
        }
        public void ImplementStatusCondition(Character character)
        {
            if(character.CharacterBattleStatus.StatusCondition.Equals(this))
            {
                int hp = character.CharacterBaseStat.Hp;
                hp -= (int)(hp * BurnDamage);
                character.CharacterBaseStat.Hp = hp;
            }
        }
        public void RemoveStatusCondition(Character character)
        {
            if(character.CharacterBattleStatus.StatusCondition.Equals(this))
            {
                character.CharacterBattleStatus.StatusCondition = null;
            }
        }
        private double SetBurnDamage(double damage)
        {
            if(damage < 0.05 ){
                damage = 0.05;
            }
            else if(damage > 0.25){
                damage = 0.25;
            }
            return damage;
        }
    }
}