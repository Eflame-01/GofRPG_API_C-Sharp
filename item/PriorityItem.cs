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
        }
        public override void UseItem(Character character)
        {
            if(!CharacterHoldingItem(character))
            {
                return;
            }
            //TODO: check if they can go first
            if(CanGoFirst())
            {
                //TODO: make player go first
                character.CharacterBattleStatus.TurnStatus = TurnStatus.GO_FIRST;
            }
        }
        private bool CanGoFirst()
        {
            Random rand = new Random();
            return (rand.NextDouble() <= PriorityPercent);
        }
    }
}