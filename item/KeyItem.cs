using System;

namespace GofRPG_API
{
    public class KeyItem : Item
    {
        public KeyItem(String name, String description, int level)
        {
            ItemName = name;
            ItemDescription = description;
            ItemID = "KEY";
            ItemLevel = level;
        }
    }
}