using System;

namespace GofRPG_API
{
    public abstract class Character
    {
        private String _characterName;
        private String _characterSex;
        private int _characterGold;
        private int _characterLevel;

        protected String _characterType;
        //TODO: Archetype _characterArchetype;
        private BaseStat _characterBaseStat;
        private BattleStatus _characterBattleStatus;
        //TODO: MoveSet _characterMoveSet;

        private Item _characterItem;

        protected int _characterID;

        public String CharacterName
        {
            get
            {
                return _characterName;
            }
            set
            {
                _characterName = value;
            }
        }
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
        public String CharacterType
        {
            get
            {
                return _characterType;
            }
        }
        public abstract void SetCharacterType(String type);
        public BaseStat CharacterBaseStat
        {
            get
            {
                return _characterBaseStat;
            }
            set
            {
                _characterBaseStat = value;
            }
        }
        public BattleStatus CharacterBattleStatus
        {
            get
            {
                return _characterBattleStatus;
            }
            set
            {
                _characterBattleStatus = value;
            }
        }
        public Item CharacterItem
        {
            get
            {
                return _characterItem;
            }
            set
            {
                _characterItem = value;
            }
        }
        public int CharacterID
        {
            get
            {
                return _characterID;
            }
        }
        public abstract void SetCharacterID(int id);

        //TODO: add getters and setters for Archetype and MoveSet
    }
}