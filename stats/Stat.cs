using System;

namespace GofRPG_API
{
    public abstract class Stat
    {
        public String StatName {get; protected set;}
        public double BoostPercent {get; protected set;}
        public double ReductionPercent {get; protected set;}

        //Abstract Methods
        public abstract void boostStat(Character character);
        public abstract void reduceStat(Character character);

        public static Stat GetStat(String name, double boost, double reduction)
        {
            switch(name)
            {
                case "ATK":
                return new Attack(boost, reduction);
            }

            return null;
        }
    }
}