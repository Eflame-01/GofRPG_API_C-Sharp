using System;

namespace GofRPG_API
{
    public class HealingItem : Item
    {
        private double healPercent;

        public HealingItem(String name, String description, int level, double heal)
        {
            itemName = name;
            itemDescription = description;
            itemID = "HEALING";
            itemLevel = level;
            healPercent = heal;
        }

        public override void useItem()
        {
            //TODO: get the amount to heal character based on healPercent
            //TODO: heal character by at most that amount
        }
    }
}