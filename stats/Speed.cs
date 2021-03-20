using System;

namespace GofRPG_API
{
    public class Speed : Stat
    {
        public Speed(double boost, double reduction)
        {
            name = "SPEED";
            boostPercent = boost;
            reductionPercent = reduction;

        }

        public Speed()
        {
            name = "SPEED";
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