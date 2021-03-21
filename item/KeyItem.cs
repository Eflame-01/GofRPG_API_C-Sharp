using System;

namespace GofRPG_API
{
    public class KeyItem : Item
    {
        public KeyItem(String name, String description, int level)
        {
            itemName = name;
            itemDescription = description;
            itemID = "KEY";
            itemLevel = level;
        }
    }
}