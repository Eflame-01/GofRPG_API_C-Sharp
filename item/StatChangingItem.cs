using System;

namespace GofRPG_API
{
    public class StatChangingItem : Item
    {
        public Stat StatBoost {get; private set;}
        public Stat StatReduction {get; private set;}
        public int StatBoostDifference {get; private set;}
        public int StatReductionDifference {get; private set;}

        public StatChangingItem(String name, String description, int level, Stat statBoost, Stat statReduction)
        {
            ItemName = name;
            ItemDescription = description;
            ItemID = "STAT CHANGING";
            ItemLevel = level;
            StatBoost = statBoost;
            StatReduction = statReduction;
        }

        public override void UseItem()
        {
            //TODO: get the base stat of the player
            //TODO: boost/reduce stat of player based on points
            //TODO: calculate the difference and add it to stat boost difference/stat reduction difference
        }

        public override void StopItemUse()
        {
            //TODO: subtract the amount of points from the use by the stat boost difference
            //TODO: add the amount of points from the user by the stat reduction difference
        }
    }
}