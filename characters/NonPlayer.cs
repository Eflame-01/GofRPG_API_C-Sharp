using System;

namespace GofRPG_API
{
    public class NonPlayer : Character
    {
        public NonPlayer(String name, String sex, int gold, int level, String type, BaseStat baseStat, BattleStatus battleStatus, Item item, int id)
        {
            CharacterName = name;
            CharacterSex = sex;
            CharacterGold = gold;
            CharacterLevel = level;
            CharacterBaseStat = baseStat;
            CharacterBattleStatus = battleStatus;
            CharacterItem = item;
            SetCharacterType(type);
            SetCharacterID(id);
        }

        public override void SetCharacterID(int id)
        {
            _characterID = id;
        }
        public override void SetCharacterType(string type)
        {
            if(type.Equals("ALLY") || type.Equals("ENEMY") || type.Equals("STRANGER"))
            {
                _characterType = type;
            }
            else
            {
                _characterType = "STRANGER";
            }
        }
    }
}