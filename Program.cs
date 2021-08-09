using System;
using System.Collections.Generic;

namespace GofRPG_API
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = Player.GetInstance();
            Files f = new Files();
            CharacterDriver characterDriver = new CharacterDriver();
            NonPlayer npc = characterDriver.GetNPC("wild_wolf_lvl_01");
            Console.WriteLine("Name: " + npc.CharacterName);
            Console.WriteLine("Sex: " + npc.CharacterSex);
            Console.WriteLine("Archetype: " + npc.CharacterArchetype.ArchetypeName);
            Console.WriteLine("Type: " + npc.CharacterType);
            Console.WriteLine("Level: " + npc.CharacterLevel);
            Console.WriteLine("Gold: " + npc.CharacterGold);
            Console.WriteLine("Item: " + npc.CharacterItem);
            Console.WriteLine("Moves:");
            foreach(Move move in npc.CharacterMoveSet.BattleMoves)
            {
                if(move != null)
                {
                    Console.WriteLine("  " + move.MoveName);
                }
            }
            Console.WriteLine("BaseStat:");
            Console.WriteLine("  HP:  " + npc.CharacterBaseStat.FullHp);
            Console.WriteLine("  ATK: " + npc.CharacterBaseStat.FullAtk);
            Console.WriteLine("  DEF: " + npc.CharacterBaseStat.FullDef);
            Console.WriteLine("  EVA: " + npc.CharacterBaseStat.FullEva);
            Console.WriteLine("  SPD: " + npc.CharacterBaseStat.FullSpd);
        }
    }
}
