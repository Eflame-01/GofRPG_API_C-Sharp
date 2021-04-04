using System;
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
                if(item == null)
                {
                    return;
                }
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
            if(!ItemList.ContainsKey(item))
            {
                return;
            }

            int currentAmount = ItemList[item];
            if(amount >= currentAmount)
            {
                ItemList.Remove(item);
                TotalItemAmount -= currentAmount;
            }
            else
            {
                ItemList[item] = currentAmount - amount;
                TotalItemAmount -= amount;
            }
        }

        public void EquipItemToPlayer(Item item)
        {
            if(PlayerHasItem() && !ItemExist(item))
            {
                return;
            }
            Player player = Player.GetInstance();
            player.CharacterItem = item;
            DiscardItemFromBag(item, 1);
        }

        public void UnequipItemFromPlayer()
        {
            if(!PlayerHasItem())
            {
                return;
            }
            Player player = Player.GetInstance();
            Item item = player.CharacterItem;
            item.StopItemUse(player);
            player.CharacterItem = null;
            AddItemToBag(item, 1);
        }

        public bool PlayerHasItem()
        {
            return Player.GetInstance().CharacterItem != null;
        }

        private bool ItemExist(Item item)
        {
            return (item != null && new ItemDriver().GetItem(item.ItemName) != null);
        }
    }
}