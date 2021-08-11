using System;

namespace GofRPG_API
{
    public class StatChangingItem : Item
    {
        private Stat StatOne {get; set;}
        private Stat StatTwo {get; set;}
        private int StatOneDifference {get; set;}
        private int StatTwoDifference {get; set;}

        public StatChangingItem(String name, String description, int level, Stat statOne, Stat statTwo)
        {
            ItemName = name;
            ItemDescription = description;
            ItemLevel = level;
            ItemID = "STAT_CHANGING";
            StatOne = statOne;
            StatTwo = statTwo;
            DiscardAfterUse = false;
        }

        public override void UseItem(Character character)
        {
            //check if the character is holding the item before granting the user the effects
            if(!CharacterHoldingItem(character) || ItemInUse)
            {
                return;
            }

            //switch ItemInUse flag to true
            ItemInUse = true;

            //use item
            UpdateStats(character);

            //TODO: item will not be discarded because DiscardAfterUSe = false
            DiscardItemAfterUse(character);
        }

        public override void StopItemUse(Character character)
        {
            ItemInUse = false;
            if(StatOne != null)
            {
                StatOne.RevertStat(character);
            }
            if(StatTwo != null)
            {
                StatTwo.RevertStat(character);
            }
        }

        private void UpdateStats(Character character)
        {
            if(StatOne != null)
            {
                StatOne.BoostStat(character);
                StatTwo.ReduceStat(character);
            }
            if(StatTwo != null)
            {
                StatTwo.BoostStat(character);
                StatTwo.ReduceStat(character);
            }
        }
    }
}