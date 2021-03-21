using System;

namespace GofRPG_API
{
    public abstract class Item
    {
        protected String itemName;
        protected String itemDescription;
        protected String itemID;
        protected int itemLevel;

        //TODO: pass in Character parameter
        public virtual void useItem()
        {
            //do nothing
        }
        public virtual void stopItemUse()
        {
            //do nothing
        }
    }
}