using System;

namespace GofRPG_API
{
    public class Defense : Stat
    {
        public Defense(double boost, double reduction)
        {
            StatName = "DEFENSE";
            BoostPercent = boost;
            ReductionPercent = reduction;

        }

        public Defense()
        {
            StatName = "DEFENSE";
            BoostPercent = 0.05;
            ReductionPercent = 0.05;
        }
        
       public override void boostStat(Character character)
       {
           //TODO: boost defense base stat of the character
       }

        public override void reduceStat(Character character)
        {
            //TODO: reduce defense base stat of the character
        }
    }
}