using System;

namespace GofRPG_API
{
    public class MedicalItem : Item
    {
        public int HealAmount {get; private set;}
        public String StatusCure {get; private set;}

        public MedicalItem(String name, String description, int level, int healAmount, String statusCure)
        {
            ItemName = name;
            ItemDescription = description;
            ItemID = "MEDICAL";
            ItemLevel = level;
            HealAmount = healAmount;
            StatusCure = statusCure;
        }

        public override void UseItem(Character character)
        {
            if(!CharacterHoldingItem(character))
            {
                return;
            }
            int newHp = GetHealAmount(character);
            character.CharacterBaseStat.Hp = newHp;

            CureStatusCondition(character);
        }

        private int GetHealAmount(Character character)
        {
            int fullHp = character.CharacterBaseStat.FullHp;
            int hp = character.CharacterBaseStat.Hp;
            int newHp = 0;
            if(HealAmount == -1)
            {
                int healAmount = (int) (fullHp * 0.5);
                if(healAmount <= 0)
                {
                    healAmount = 1;
                }
                newHp = healAmount;
            }
            else if(HealAmount == -2)
            {
                if(hp > 0)
                {
                    return 0;
                }
                int healAmount = fullHp;
                newHp = healAmount;
            }
            else
            {
                newHp += HealAmount;
            }
            if(newHp >= fullHp)
            {
                newHp = fullHp;
            }
            return newHp;
        }

        private void CureStatusCondition(Character character)
        {
            StatusCondition characterStatusCondition = character.CharacterBattleStatus.StatusCondition;

            if(characterStatusCondition == null || !characterStatusCondition.GetStatusConditionName().Equals(StatusCure) || !StatusCure.Equals("ALL"))
            {
                return;
            }
            else
            {
                character.CharacterBattleStatus.StatusCondition = null;
            }
        }
    }
}