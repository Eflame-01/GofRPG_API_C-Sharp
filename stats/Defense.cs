using System;

namespace GofRPG_API
{
    public class Defense : Stat
    {
        public Defense(double boost, double reduction)
        {
            name = "DEFENSE";
            boostPercent = boost;
            reductionPercent = reduction;

        }

        public Defense()
        {
            name = "DEFENSE";
            boostPercent = 0.05;
            reductionPercent = 0.05;
        }
        
       public override void boostStat()
       {
           //TODO: boost defense base stat of the character
       }

        public override void reduceStat()
        {
            //TODO: reduce defense base stat of the character
        }
    }
}