using System;

namespace GofRPG_API
{
    public class Evasion : Stat
    {
        public Evasion(double boost, double reduction)
        {
            name = "EVASION";
            boostPercent = boost;
            reductionPercent = reduction;

        }

        public Evasion()
        {
            name = "EVASION";
            boostPercent = 0.05;
            reductionPercent = 0.05;
        }
        
       public override void boostStat()
       {
           //TODO: boost evasion base stat of the character
       }

        public override void reduceStat()
        {
            //TODO: reduce evasion base stat of the character
        }
    }
}