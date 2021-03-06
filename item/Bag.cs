using System;
using System.Collections.Generic;

namespace GofRPG_API
{
    public class Bag
    {
        private Dictionary<Item, int> _itemList = new Dictionary<Item, int>();
        public int TotalItemAmount {get; private set;}

        public Dictionary<Item, int> ItemList 
        {
            get
            {
                return _itemList;
            }
        }

        public void SetTotalItemAmount()
        {
            int numOfItems = 0;
            foreach(KeyValuePair<Item, int> itemList in ItemList)
            {
                numOfItems += itemList.Value;
            }
            if(TotalItemAmount != numOfItems)
            {
                TotalItemAmount = numOfItems;
            }
        }

        public void AddItemToBag(Item item, int amount)
        {
            if(!ItemExist(item)){
                return;
            }
            int currentAmount = amount;
            if(ItemList.ContainsKey(item))
            {
                currentAmount += ItemList[item];
                ItemList[item] = currentAmount;
            }
            else
            {
                ItemList.Add(item, currentAmount);
            }

            TotalItemAmount += amount;
        }

        public void DiscardItemFromBag(Item item, int amount)
        {
            if(!ItemExist(item))
            {
                return;
            }
            if(ItemList.ContainsKey(item))
            {
                int currentAmount = ItemList[item];
                if(amount >= currentAmount)
                {
                    ItemList.Remove(item);
                    TotalItemAmount -= currentAmount;
                }
                else
                {
                    ItemList[item] -= amount;
                    TotalItemAmount -= amount;
                }
            }
        }

        public void EquipItemToPlayer(Item item)
        {
            if(ItemExist(item) && PlayerHasItem())
            {
                UnequipItemFromPlayer();
                Player player = Player.GetInstance();
                player.CharacterItem = item;
                DiscardItemFromBag(item, 1);
            }
        }

        public void UnequipItemFromPlayer()
        {
            if(PlayerHasItem())
            {
                Player player = Player.GetInstance();
                Item item = player.CharacterItem;
                item.StopItemUse(player);
                player.CharacterItem = null;
                AddItemToBag(item, 1);
            }
        }

        private bool PlayerHasItem()
        {
            //If the character's item is not null, then the player is holding an item
            return Player.GetInstance().CharacterItem != null;
        }

        private bool ItemExist(Item item)
        {
            //The item cannot be null, and the item has to be in the database
            return (item != null && new ItemDriver().GetItem(item.ItemName) != null);
        }
    }
}