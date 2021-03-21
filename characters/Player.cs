using System;

namespace GofRPG_API
{
    public class Player : Character
    {
        
        public Player()
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

        public int CharacterCurrentXP{get; set;}
        public int CharacterLimitXP{get; set;}
        public Bag PlayerBag{get; set;}
        public override void SetCharacterID(int id)
        {
            _characterID = 1;
        }
        public override void SetCharacterType(string type)
        {
            _characterType = "PLAYER";
        }
    }
}