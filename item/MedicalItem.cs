using System;

namespace GofRPG_API
{
    public class MedicalItem : Item
    {
        private int healAmount;
        private String statusCure;

        public MedicalItem(String name, String description, int level, int heal, String status)
        {
            itemName = name;
            itemDescription = description;
            itemID = "MEDICAL";
            itemLevel = level;
            healAmount = heal;
            statusCure = status;
        }

        public override void useItem()
        {
            //TODO: heal/revive character based on heal amount
            //TODO: give status restore based on stausCure
        }
    }
}