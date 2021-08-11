using System;

namespace GofRPG_API
{
    public abstract class Item
    {
        public String ItemName {get; protected set;}
        public String ItemDescription {get; protected set;}
        public String ItemID {get; protected set;}
        public int ItemLevel {get; protected set;}
        public Boolean DiscardAfterUse {get; protected set;}

        public Boolean ItemInUse {get; set;}

        public virtual void UseItem(Character character)
        {
            //set boolean to true
            ItemInUse = true;
        }
        public virtual void StopItemUse(Character character)
        {
            //set boolean to false
            ItemInUse = false;
        }

        protected bool CharacterHoldingItem(Character character)
        {
            //if character is null it cannot hold an item
            if(character == null)
            {
                return false;
            }
            //if character's item is null it is not holding an item
            if(character.CharacterItem == null)
            {
                return false;
            }
            //if character's item does not equal the current item then character is holding a different item
            if(!character.CharacterItem.Equals(this))
            {
                return false;
            }
            return true;
        }

        protected void DiscardItemAfterUse(Character character)
        {
            //only discard item if item has been used, and if the item should be disposable after use.
            if(ItemInUse && DiscardAfterUse)
            {
                character.CharacterItem = null;
            }
        }
    }
}