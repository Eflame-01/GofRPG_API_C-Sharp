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

        public override void UseItem()
        {
            //TODO: heal/revive character based on heal amount
            //TODO: give status restore based on stausCure
        }
    }
}