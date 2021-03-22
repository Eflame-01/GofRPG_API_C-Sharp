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
            CharacterBaseStat = new BaseStat();//TODO
            CharacterBattleStatus = new BattleStatus();//TODO
            CharacterItem = null;
            SetCharacterType("PLAYER");
            SetCharacterID(1);
        }
        private static Player InstanceOfPlayer{get; set;}
        public int CharacterCurrentXP{get; set;}
        public int CharacterLimitXP{get; set;}
        public Bag PlayerBag{get; set;}
        public override void SetCharacterID(int id)
        {
            CharacterID = 1;
        }
        public override void SetCharacterType(string type)
        {
            CharacterType = "PLAYER";
        }
        public static Player GetInstance()
        {
            if(InstanceOfPlayer == null){
                InstanceOfPlayer = new Player();
            }

            return InstanceOfPlayer;
        }
    }
}