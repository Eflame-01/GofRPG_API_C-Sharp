using System;

namespace GofRPG_API
{
    public class FoodItem : Item
    {
        public int HealAmount {get; private set;}

        public FoodItem(String name, String description, int level, int healAmount)
        {
            ItemName = name;
            ItemDescription = description;
            ItemID = "FOOD";
            ItemLevel = level;
            HealAmount = healAmount;
            DiscardAfterUse = true;
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
            SetNewHp(character);

            //discard item
            DiscardItemAfterUse(character);
        }

        private void SetNewHp(Character character)
        {
            int hp = character.CharacterBaseStat.Hp;
            int fullHp = character.CharacterBaseStat.FullHp + 1;
            int newHp =  Math.Clamp(hp + HealAmount, hp + 1, fullHp);

            character.CharacterBaseStat.Hp = newHp;
        }
    }
}