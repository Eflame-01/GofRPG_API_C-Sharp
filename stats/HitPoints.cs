using System;

namespace GofRPG_API
{
    public class HitPoints : Stat
    {
        public HitPoints(double boost, double reduction)
        {
            StatName = "HIT POINTS";
            BoostPercent = boost;
            ReductionPercent = reduction;

        }

        public HitPoints()
        {
            StatName = "HIT POINTS";
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