using System;

namespace GofRPG_API
{
    public class Poison : StatusCondition
    {
        public String StatusName
        {
            get
            {
                return "POISON";
            }
        }
        public double PoisonDamage {get; set;}
        public double PoisonIncrementer {get; set;}

        public Poison(double damage, double incrementer)
        {
            PoisonDamage = SetPoisonDamage(damage);
            PoisonIncrementer = SetPoisonIncrementer(incrementer);
        }
        public Poison()
        {
            PoisonDamage = 0.05;
            PoisonIncrementer = 1.0;
        }

        public String GetStatusConditionName()
        {
            return StatusName;
        }
        public void ImplementStatusCondition(Character character)
        {
            if(character.CharacterBattleStatus.StatusCondition != this)
            {
                return;
            }

            int hp = character.CharacterBaseStat.Hp;
            hp -= (int)(hp * PoisonDamage);
            character.CharacterBaseStat.Hp = hp;

            if(PoisonDamage < 0.25)
            {
                PoisonDamage += PoisonDamage * PoisonIncrementer;
                if(PoisonDamage > 0.25)
                {
                    PoisonDamage = 0.25;
                }
            }
        }
        public void RemoveStatusCondition(Character character)
        {
            if(character.CharacterBattleStatus.StatusCondition.Equals(this)){
                character.CharacterBattleStatus.StatusCondition = null;
            }
        }
        private double SetPoisonDamage(double damage)
        {
            if(damage < 0.05){
                damage = 0.05;
            }
            else if(damage > 0.25){
                damage = 0.25;
            }
            return damage;
        }
        private double SetPoisonIncrementer(double incrementer)
        {
            if(incrementer < 1.0){
                incrementer = 1.0;
            }
            else if(incrementer > 1.25){
                incrementer = 1.25;
            }
            return incrementer;
        }
    }
}