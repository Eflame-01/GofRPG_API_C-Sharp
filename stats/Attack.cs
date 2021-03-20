using System;

namespace GofRPG_API
{
    public class Attack : Stat
    {
        public Attack(double boost, double reduction)
        {
            name = "ATTACK";
            boostPercent = boost;
            reductionPercent = reduction;

        }

        public Attack()
        {
            name = "ATTACK";
            boostPercent = 0.05;
            reductionPercent = 0.05;
        }
        
       public override void boostStat()
       {
           //TODO: boost attack base stat of the character
       }

        public override void reduceStat()
        {
            //TODO: reduce attack base stat of the character
        }
    }
}