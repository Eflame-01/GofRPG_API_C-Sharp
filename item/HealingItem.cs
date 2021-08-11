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
            SetNewHp(character);

            //TODO: item would not be discarded since DiscardAfterUse is false. Decide if you wish to keep it.
            DiscardItemAfterUse(character);
        }

        private int GetHealBoost(Character character)
        {
            int fullHp = character.CharacterBaseStat.FullHp;
            return  Math.Clamp((int)(fullHp * HealPercent), 1, fullHp);
        }
        private void SetNewHp(Character character)
        {
            int healBoost = GetHealBoost(character);
            int hp = character.CharacterBaseStat.Hp;
            int fullHp = character.CharacterBaseStat.FullHp + 1;
            int newHp =  Math.Clamp(hp + healBoost, hp + 1, fullHp);

            character.CharacterBaseStat.Hp = newHp;
        }
    }
}