using System;

namespace GofRPG_API
{
    public class Poison : StatusCondition
    {
        public double PoisonDamage {get; set;}
        public double PoisonIncrementer {get; set;}

        public Poison(double damage, double incrementer)
        {
            PoisonDamage = Math.Clamp(damage, 0.05, 0.25);
            PoisonIncrementer = Math.Clamp(incrementer, 1, 1.25);
        }
        public Poison()
        {
            PoisonDamage = 0.05;
            PoisonIncrementer = 1.0;
        }

        public String GetStatusConditionName()
        {
            return "POISON";
        }
        public void ImplementStatusCondition(Character character)
        {
            if(character.CharacterBattleStatus.StatusCondition != this)
            {
                return;
            }

            int hp = character.CharacterBaseStat.Hp;
            character.CharacterBaseStat.Hp = Math.Clamp((int)(hp * PoisonDamage), 0, hp);
            IncrementPoisonDamage();
        }
        public void RemoveStatusCondition(Character character)
        {
            if(character.CharacterBattleStatus.StatusCondition.Equals(this)){
                character.CharacterBattleStatus.StatusCondition = null;
            }
        }
        private void IncrementPoisonDamage()
        {
            double oldPoisonDamage = PoisonDamage;
            PoisonDamage = Math.Clamp(oldPoisonDamage + (oldPoisonDamage * PoisonIncrementer), 0.05, 0.25);
        }
    }
}