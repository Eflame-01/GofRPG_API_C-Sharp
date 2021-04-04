using System;

namespace GofRPG_API
{
    public abstract class Item
    {
        public String ItemName {get; protected set;}
        public String ItemDescription {get; protected set;}
        public String ItemID {get; protected set;}
        public int ItemLevel {get; protected set;}

        public Boolean ItemInUse {get; set;}

        //TODO: pass in Character parameter
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

        public bool CharacterHoldingItem(Character character)
        {
            if(character == null)
            {
                return false;
            }
            if(character.CharacterItem == null)
            {
                return false;
            }
            if(!character.CharacterItem.Equals(this))
            {
                return false;
            }
            return true;
        }
    }
}