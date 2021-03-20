using System;

namespace GofRPG_API
{
    abstract class Stat
    {
        String name;
        double boostPercent;
        double reductionPercent;

        //TODO: make these take in Character character parameter
        public abstract void boostStat();
        public abstract void reduceStat();
    }
}