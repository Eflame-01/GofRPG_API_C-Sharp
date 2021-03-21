using System.Collections.Generic;

namespace GofRPG_API
{
    public class Bag
    {
        public Dictionary<Item, int> itemList = new Dictionary<Item, int>();
        private int totalItemAmount = 0;

        public Dictionary<Item, int> getItemList()
        {
            return itemList;
        }
        public int getTotalItemAmount()
        {
            return totalItemAmount;
        }

        public void addItemToBag(Item item, int amount)
        {
            int currentAmount = 1;
            if(itemList.ContainsKey(item)){
                currentAmount += itemList[item];
                itemList[item] = currentAmount;
            }
            else{
                if(item == null){
                    return;
                }
                itemList.Add(item, currentAmount);
            }

            totalItemAmount += amount;
        }

        public void discardItemFromBag(Item item, int amount)
        {
            if(!itemList.ContainsKey(item)){
                return;
            }

            int currentAmount = itemList[item];
            if(amount > currentAmount){
                itemList.Remove(item);
                totalItemAmount -= currentAmount;
            }
            else{
                itemList[item] = currentAmount - amount;
                totalItemAmount -= amount;
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