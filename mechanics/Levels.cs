using System;
using System.Collections.Generic;

namespace GofRPG_API
{
    public class Level
    {
        public static Level Instance {get; private set;}
        public double XpMultiplier {get; private set;}
        
        private Level()
        {
            XpMultiplier = 3;
        }

        public void GainXPFromBattle(Character enemy)
        {
            Player player = Player.GetInstance();
            player.CharacterCurrentXP += (int) Math.Pow(enemy.CharacterLevel, 1.2);
        }

        public void GainXpFromQuest(bool isMajor)
        {
            Player player = Player.GetInstance();
            if(isMajor)
            {
                player.CharacterCurrentXP += (int) Math.Pow(player.CharacterLevel, 2);
            }
            else
            {
                player.CharacterCurrentXP += (int) Math.Pow(player.CharacterLevel, 1.5);
            }
        }

        public bool CanLevelUp()
        {
            Player player = Player.GetInstance();
            return player.CharacterCurrentXP >= player.CharacterLimitXP;
        }

        public void LevelUpPlayer()
        {
            //check if they can level up
            if(!CanLevelUp())
            {
                return;
            }
            Player player = Player.GetInstance();
            //level up the player
            player.CharacterLevel++;
            //change current xp and limit xp values
            player.CharacterCurrentXP -= player.CharacterLimitXP;
            player.CharacterLimitXP = (int) Math.Pow(player.CharacterLevel, XpMultiplier);
            //boost stat of player
            player.CharacterArchetype.LevelUpPlayerStats();
            //check if the player can learn new move, get the moves, and add it to the list in the player's move set
            // List<Move> list = new MoveDriver().GetMoves();
            // foreach(Move move in list)
            // {
            //     player.CharacterMoveSet.AddMoveToBattleSlot(move);
            //     player.CharacterMoveSet.AddMoveToList(move);
            // }
        }

        public static Level GetInstance()
        {
            if(Instance == null)
            {
                Instance = new Level();
            }
            return Instance;
        }
    }
}