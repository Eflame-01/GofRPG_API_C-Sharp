using System;

namespace GofRPG_API
{
    public abstract class Stat
    {
        public String StatName {get; protected set;}
        public double BoostPercent {get; protected set;}
        public double ReductionPercent {get; protected set;}
        public int StatAmount {get; protected set;}

        //Abstract Methods
        public abstract void BoostStat(Character character);
        public abstract void ReduceStat(Character character);
        public abstract void RevertStat(Character character);

        protected Boolean CanUpdateStat()
        {
            //stat must either boost or reduce, not both
            if(BoostPercent > 0 && ReductionPercent > 0)
            {
                return false;
            }
            
            //stat must either boost or reduce, not neither
            if(BoostPercent <= 0 && ReductionPercent <= 0)
            {
                return false;
            }

            return true;
        }
    }
}