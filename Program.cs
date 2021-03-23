using System;
using System.Collections.Generic;

namespace GofRPG_API
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = Player.GetInstance();
            player.PlayerBag.AddItemToBag(new ItemDriver().GetItem("Potion"), 1);
            player.PlayerBag.AddItemToBag(new KeyItem("Key Item", "chicken", 1), 1);
            player.PlayerBag.AddItemToBag(null, 1);

            foreach(Item item in player.PlayerBag.ItemList.Keys)
            {
                Console.WriteLine(item.ItemName);
            }
        }
    }
}
