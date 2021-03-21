using System;

namespace GofRPG_API
{
    public class Speed : Stat
    {
        public Speed(double boost, double reduction)
        {
            StatName = "SPEED";
            BoostPercent = boost;
            ReductionPercent = reduction;

        }

        public Speed()
        {
            StatName = "SPEED";
            BoostPercent = 0.05;
            ReductionPercent = 0.05;
        }
        
       public override void boostStat(Character character)
       {
           //TODO: boost speed base stat of the character
       }

        public override void reduceStat(Character character)
        {
            //TODO: reduce speed base stat of the character
        }
    }
}