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

        //Constructors
        public Burn(double damage)
        {
            BurnDamage = setBurnDamage(damage);
        }
        public Burn()
        {
            BurnDamage = 0.05;
        }

        //Override Methods
        public String getStatusConditionName()
        {
            return StatusName;
        }

        public void implementStatusCondition(Character character)
        {
            if(character.CharacterBattleStatus.StatusCondition.Equals(this))
            {
                int hp = character.CharacterBaseStat.Hp;
                hp -= (int)(hp * BurnDamage);
                character.CharacterBaseStat.Hp = hp;
            }
        }

        public void removeStatusCondition(Character character)
        {
            if(character.CharacterBattleStatus.StatusCondition.Equals(this))
            {
                character.CharacterBattleStatus.StatusCondition = null;
            }
        }

        //Private Methods
        private double setBurnDamage(double damage)
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