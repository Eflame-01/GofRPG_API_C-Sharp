using System;
using System.Collections.Generic;

namespace GofRPG_API
{
    class Program
    {
        static void Main(string[] args)
        {
            Move move = new MoveDriver().GetMove("Fire Fist");

            Console.WriteLine(move.MoveName);
        }
    }
}
