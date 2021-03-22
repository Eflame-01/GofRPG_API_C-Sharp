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
        public override void UseItem(Character character)
        {
            //TODO: get the amount to heal character based on healPercent
            int fullHp = character.CharacterBaseStat.FullHp;
            int hp = character.CharacterBaseStat.Hp;
            int healBoost = (int)(fullHp * HealPercent);
            if(healBoost <= 0)
            {
                healBoost = 1;
            }
            int newHp = hp + healBoost;

            //TODO: heal character by at most that amount
            if(newHp > fullHp)
            {
                character.CharacterBaseStat.Hp = fullHp;
            }
            else
            {
                character.CharacterBaseStat.Hp = newHp;
            }
        }
    }
}