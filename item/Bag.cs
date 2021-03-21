using System.Collections.Generic;

namespace GofRPG_API
{
    public class Bag
    {
        private Dictionary<Item, int> _itemList = new Dictionary<Item, int>();
        private int _totalItemAmount = 0;

        public Dictionary<Item, int> ItemList 
        {
            get
            {
                return _itemList;
            }
        }
        public int TotalItemAmount
        {
            get
            {
                return _totalItemAmount;
            }
            set
            {
                _totalItemAmount = value;
            }
        }

        public void addItemToBag(Item item, int amount)
        {
            int currentAmount = 1;
            if(ItemList.ContainsKey(item)){
                currentAmount += ItemList[item];
                ItemList[item] = currentAmount;
            }
            else{
                if(item == null){
                    return;
                }
                ItemList.Add(item, currentAmount);
            }

            TotalItemAmount += amount;
        }

        public void discardItemFromBag(Item item, int amount)
        {
            if(!ItemList.ContainsKey(item)){
                return;
            }

            int currentAmount = ItemList[item];
            if(amount > currentAmount){
                ItemList.Remove(item);
                TotalItemAmount -= currentAmount;
            }
            else{
                ItemList[item] = currentAmount - amount;
                TotalItemAmount -= amount;
            }
        }

        public void equipItemToPlayer(Item item)
        {
            //TODO: set the item in the player's item's data member to the item
            //TODO: discard an item from the bag
        }

        public void unequipItemFromPlayer(Item item)
        {
            //TODO: set the item in the player's item's data member to null
            //TODO: if the item was a stat changing item then call the function stop item in use to get rid of the stat changes
            //TODO: add the item to the bag
        }
    }
}