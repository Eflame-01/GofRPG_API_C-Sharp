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

        public void GainXPFromBattle(Character enemy)
        {
            Player player = Player.GetInstance();
            player.CharacterCurrentXP += (int) Math.Pow(enemy.CharacterLevel, _battleXP);
        }

        public void GainXpFromQuest(bool isMajor)
        {
            Player player = Player.GetInstance();
            if(isMajor)
            {
                player.CharacterCurrentXP += (int) Math.Pow(player.CharacterLevel, _majorQuestXP);
            }
            else
            {
                player.CharacterCurrentXP += (int) Math.Pow(player.CharacterLevel, _minorQuestXP);
            }
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
            List<Move> list = new MoveDriver().GetMoves();
            foreach(Move move in list)
            {
                player.CharacterMoveSet.AddMoveToBattleSlot(move);
                player.CharacterMoveSet.AddMoveToList(move);
            }
        }
    }
}