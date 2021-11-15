using System;

namespace GofRPG_API
{
    public abstract class Character
    {
        private String _characterSex;
        private int _characterGold;
        private int _characterLevel;

        public String CharacterName {get; protected set;}
        public String CharacterType {get; protected set;}
        public BaseStat CharacterBaseStat {get; set;}
        public BattleStatus CharacterBattleStatus {get; set;}
        public Item CharacterItem{get; set;}
        public String CharacterID{ get; protected set;}
        public Archetype CharacterArchetype {get; set;}
        public MoveSet CharacterMoveSet {get; protected set;}
        public String CharacterSex
        {
            get
            {
                return _characterSex;
            }
            set
            {
                if(value.Equals("MALE") || value.Equals("FEMALE") || value.Equals("MALEFE"))
                {
                    _characterSex = value;
                }
                else
                {
                    _characterSex = "MALEFE";
                }
            }
        }
        public int CharacterGold
        {
            get
            {
                return _characterGold;
            }
            set
            {
                if(value > 0)
                {
                    _characterGold = value;
                }
                else
                {
                    _characterGold = 0;
                }
            }
        }
        public int CharacterLevel
        {
            get
            {
                return _characterLevel;
            }
            set
            {
                if(value > 1)
                {
                    _characterLevel = value;
                }
                else
                {
                    _characterLevel = 1;
                }
            }
        }
    }
}