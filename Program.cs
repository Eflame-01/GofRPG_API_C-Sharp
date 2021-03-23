using System;
using System.Collections.Generic;

namespace GofRPG_API
{
    class Program
    {
        static void Main(string[] args)
        {
            Move move = new MoveDriver().GetMove("Fire Fist");
            Item item = new ItemDriver().GetItem("Potion");

            Console.WriteLine(move.MoveName);
            Console.WriteLine(item.ItemName);
        }
    }
}
