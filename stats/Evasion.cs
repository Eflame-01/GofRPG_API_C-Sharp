using System;

namespace GofRPG_API
{
    public class Evasion : Stat
    {
        public Evasion(double boost, double reduction)
        {
            StatName = "EVASION";
            BoostPercent = boost;
            ReductionPercent = reduction;

        }

        public Evasion()
        {
            StatName = "EVASION";
            BoostPercent = 0.05;
            ReductionPercent = 0.05;
        }
        
       public override void boostStat(Character character)
       {
           //TODO: boost evasion base stat of the character
       }

        public override void reduceStat(Character character)
        {
            //TODO: reduce evasion base stat of the character
        }
    }
}