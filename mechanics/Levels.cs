using System;
using System.Collections.Generic;

namespace GofRPG_API
{
    public class Level
    {
        private double _battleXP = 1.2;
        private double _majorQuestXP = 2;
        private double _minorQuestXP = 1.5;
        private double _xpMultiplier = 3;
        
        private Level()
        {
        }

        public int GainXPFromBattle(Character enemy)
        {
            Player player = Player.GetInstance();
            int xp = 0;
            if(enemy == null){
                return 0;
            }
            xp += (int) Math.Pow(enemy.CharacterLevel, _battleXP);
            player.CharacterCurrentXP += xp;
            return xp;
        }

        public int GainXpFromQuest(Quest quest)
        {
            Player player = Player.GetInstance();
            int currentXp = player.CharacterCurrentXP;
            int xp = 0;
            if(quest == null)
            {
                return 0;
            }
            if(quest.IsMajor)
            {
                xp += (int) Math.Pow(player.CharacterLevel, _majorQuestXP);
            }
            else
            {
                xp += (int) Math.Pow(player.CharacterLevel, _minorQuestXP);
            }
            
            player.CharacterCurrentXP += xp;
            return xp;
        }

        public bool CanLevelUp()
        {
            Player player = Player.GetInstance();
            return player.CharacterCurrentXP >= player.CharacterLimitXP;
        }

        public void LevelUpPlayer()
        {
            if(!CanLevelUp())
            {
                return;
            }
            Player player = Player.GetInstance();
            player.CharacterLevel++;
            player.CharacterCurrentXP -= player.CharacterLimitXP;
            player.CharacterLimitXP = (int) Math.Pow(player.CharacterLevel, _xpMultiplier);
            player.CharacterArchetype.LevelUpPlayerStats();

            //TODO: dead code. Do not retrieve moves from here, moves should be retrieved after the player has leveled up
            // List<Move> list = new MoveDriver().GetMoves();
            // foreach(Move move in list)
            // {
            //     player.CharacterMoveSet.AddMoveToBattleSlot(move);
            //     player.CharacterMoveSet.AddMoveToList(move);
            // }
        }
    }
}