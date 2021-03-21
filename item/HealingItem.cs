using System;

namespace GofRPG_API
{
    public class HealingItem : Item
    {
        public double HealPercent{get; private set;}

        public HealingItem(String name, String description, int level, double heal)
        {
            ItemName = name;
            ItemDescription = description;
            ItemID = "HEALING";
            ItemLevel = level;
            HealPercent = heal;
        }

        public override void UseItem()
        {
            //TODO: get the amount to heal character based on healPercent
            //TODO: heal character by at most that amount
        }
    }
}