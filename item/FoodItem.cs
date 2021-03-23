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
        }

        public override void UseItem(Character character)
        {
            if(!CharacterHoldingItem(character))
            {
                return;
            }
            int hp = character.CharacterBaseStat.Hp + HealAmount;
            if(hp >= character.CharacterBaseStat.FullHp)
            {
                hp = character.CharacterBaseStat.FullHp;
            }
            character.CharacterBaseStat.Hp = hp;
        }
    }
}