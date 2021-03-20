using System;

namespace GofRPG_API
{
    public class HitPoints : Stat
    {
        public HitPoints(double boost, double reduction)
        {
            name = "HIT POINTS";
            boostPercent = boost;
            reductionPercent = reduction;

        }

        public HitPoints()
        {
            name = "HIT POINTS";
            boostPercent = 0.05;
            reductionPercent = 0.05;
        }
        
       public override void boostStat()
       {
           //TODO: boost speed base stat of the character
       }

        public override void reduceStat()
        {
            //TODO: reduce speed base stat of the character
        }
    }
}