using System;

namespace GofRPG_API
{
    public class StatChangingItem : Item
    {
        private Stat statBoost;
        private Stat statReduction;

        private int statBoostDifference;
        private int statReductionDifference;

        public StatChangingItem(String name, String description, int level, Stat boost, Stat reduction)
        {
            itemName = name;
            itemDescription = description;
            itemID = "STAT CHANGING";
            itemLevel = level;
            statBoost = boost;
            statReduction = reduction;
        }

        public override void useItem()
        {
            //TODO: get the base stat of the player
            //TODO: boost/reduce stat of player based on points
            //TODO: calculate the difference and add it to stat boost difference/stat reduction difference
        }

        public override void stopItemUse()
        {
            //TODO: subtract the amount of points from the use by the stat boost difference
            //TODO: add the amount of points from the user by the stat reduction difference
        }
    }
}