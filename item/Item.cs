using System;

namespace GofRPG_API
{
    public abstract class Item
    {
        public String ItemName {get; protected set;}
        public String ItemDescription {get; protected set;}
        public String ItemID {get; protected set;}
        public int ItemLevel {get; protected set;}

        //TODO: pass in Character parameter
        public virtual void UseItem()
        {
            //do nothing
        }
        public virtual void StopItemUse()
        {
            //do nothing
        }
    }
}