using System;

namespace GofRPG_API
{
    public class Attack : Stat
    {
        public Attack(double boost, double reduction)
        {
            StatName = "ATTACK";
            BoostPercent = boost;
            ReductionPercent = reduction;
        }

        public Attack()
        {
            StatName = "ATTACK";
            BoostPercent = 0.05;
            ReductionPercent = 0.05;
        }
        
       public override void boostStat(Character character)
       {
           //TODO: boost attack base stat of the character
       }

        public override void reduceStat(Character character)
        {
            //TODO: reduce attack base stat of the character
        }
    }
}