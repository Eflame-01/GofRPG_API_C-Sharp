using System;

namespace GofRPG_API
{
    public class Burn : StatusCondition
    {
        //Data Members
        private String name = "BURN";
        private double burnDamage;

        //Constructors
        public Burn(double damage)
        {
            burnDamage = setBurnDamage(damage);
        }
        public Burn()
        {
            burnDamage = 0.05;
        }

        //Override Methods
        public String getStatusConditionName()
        {
            return name;
        }

        public void implementStatusCondition()
        {
            //TODO: decrement the hp based on the burn damage
        }

        public void removeStatusCondition()
        {
            //TODO: remove this status condition from the character
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