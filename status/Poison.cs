using System;

namespace GofRPG_API
{
    public class Poison : StatusCondition
    {
        //Data Members
        private String name = "POISON";
        private double poisonDamage;
        private double poisonIncrementer;

        //Constructors
        public Poison(double damage, double incrementer)
        {
            poisonDamage = setPoisonDamage(damage);
            poisonIncrementer = setPoisonIncrementer(incrementer);
        }
        public Poison()
        {
            poisonDamage = 0.05;
            poisonIncrementer = 1.0;
        }

        //Override Methods
        public String getStatusConditionName()
        {
            return name;
        }
        public void implementStatusCondition()
        {
            //TODO: decrement the character's health by the poison damage
            //TODO: increase the poison damage by the poison incrementer
        }
        public void removeStatusCondition()
        {
            //TODO: remvoe this status condition from the character
        }

        //Private Methods
        private double setPoisonDamage(double damage)
        {
            if(damage < 0.05){
                damage = 0.05;
            }
            else if(damage > 0.25){
                damage = 0.25;
            }
            return damage;
        }
        private double setPoisonIncrementer(double incrementer)
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