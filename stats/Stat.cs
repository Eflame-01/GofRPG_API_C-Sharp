using System;

namespace GofRPG_API
{
    public abstract class Stat
    {
        //Data Members
        protected String name;
        protected double boostPercent;
        protected double reductionPercent;

        //Getters (do not add setters because the changes need to be final).
        public String getStatName()
        {
            return name;
        }
        public double getBoostPercent()
        {
            return boostPercent;
        }
        public double getReductionPercent()
        {
            return reductionPercent;
        }

        //Abstract Methods
        //TODO: make these take in Character character parameter
        public abstract void boostStat();
        public abstract void reduceStat();
    }
}