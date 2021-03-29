using System;

namespace GofRPG_API
{
    public class Player : Character
    {   
        private Player()
        {
            CharacterName = "Player1";
            CharacterSex = "MALEFE";
            CharacterGold = 500;
            CharacterLevel = 1;
            CharacterCurrentXP = 0;
            CharacterLimitXP = 1;
            CharacterBaseStat = new BaseStat();
            CharacterBattleStatus = new BattleStatus();
            PlayerBag = new Bag();
            CharacterItem = null;
            CharacterType = "PLAYER";
            CharacterID = "PLAYER_1";
        }

        private static Player InstanceOfPlayer{get; set;}
        public int CharacterCurrentXP{get; set;}
        public int CharacterLimitXP{get; set;}
        public Bag PlayerBag{get; set;}
        public Level PlayerLevel{get; private set;}
        
        public static Player GetInstance()
        {
            if(InstanceOfPlayer == null){
                InstanceOfPlayer = new Player();
            }
            return InstanceOfPlayer;
        }
    }
}