using System;

namespace GofRPG_API
{
    public class PriorityItem: Item
    {
        public double PriorityPercent {get; private set;}
        public PriorityItem(String name, String description, int level, double priroityPercent)
        {
            ItemName = name;
            ItemDescription = description;
            ItemID = "PRIORITY";
            ItemLevel = level;
            PriorityPercent = priroityPercent;
            DiscardAfterUse = false;
        }
        public override void UseItem(Character character)
        {
            //check if the character is holding the item before granting the user the effects
            if(!CharacterHoldingItem(character))
            {
                return;
            }

            //switch ItemInUse flag to true
            ItemInUse = true;

            //use item
            MakeUserGoFirst(character);

            //TODO: item will not be discared after use because DiscardAfterUse = false
            DiscardItemAfterUse(character);
        }
        private bool CanGoFirst()
        {
            Random rand = new Random();
            return (rand.NextDouble() <= PriorityPercent);
        }

        private void MakeUserGoFirst(Character character)
        {
            if(CanGoFirst())
            {
                character.CharacterBattleStatus.TurnStatus = TurnStatus.GO_FIRST;
            }
        }
    }
}