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
            CureStatusCondition(character);

            //discard item
            DiscardItemAfterUse(character);
        }

        private void SetNewHp(Character character)
        {
            int fullHp = character.CharacterBaseStat.FullHp + 1;
            int hp = character.CharacterBaseStat.Hp;
            int newHp = 0;
            if(HealAmount == -1 && hp == 0)
            {
                //set hp to half the player's full hp
                newHp = Math.Clamp((int) (fullHp * 0.05), 1, fullHp);
            }
            else if(HealAmount == -2 && hp == 0)
            {
                //set hp to player's full hp
                newHp = fullHp;
            }
            else
            {
                newHp = Math.Clamp(hp + HealAmount, hp, fullHp);
            }
            character.CharacterBaseStat.Hp = newHp;
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